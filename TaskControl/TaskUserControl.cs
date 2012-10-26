using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Model;
using TaskControl.Properties;

namespace TaskControl
{
    public sealed partial class TaskUserControl : UserControl
    {
        #region Delegates

        public delegate void TaskChanged(long id, TabControl tabControl);

        public delegate void TaskClose(TaskUserControl uc);

        #endregion

        private readonly SqliteCommunicator _communicator = new SqliteCommunicator();


        private readonly IView _view;

        private List<History> _history;
        private long _id;
        private List<string> _related = new List<string>();

        public TaskUserControl(IView frm, long id)
        {
            InitializeComponent();
            _view = frm;

            _id = id;
            AssignedToComboBox.Items.AddRange(
                _communicator.GetList<User>("Users").Select(x => (object) x.ShowAs).ToArray());
        }

        private List<History> HistoryItem
        {
            set
            {
                _history = value;
                PopulateHistory(GetTreeView, value.OrderByDescending(x => x.Datetime).ToList());
            }
            get { return _history; }
        }


        private Data DataItem
        {
            set
            {
                try
                {
                    if (_id == -1) throw new Exception("new task");

                    IDtext.Text = value.ID.ToString(CultureInfo.InvariantCulture);
                    _id = value.ID;

                    TitleText.Text = value.Title;
                    AssignedToComboBox.SelectedItem = value.AssignedTo;
                    StateComboBox.Text = value.State;
                    CreatedByText.Text = value.CreatedBy;
                    CreationDateText.Text = value.CreationDate.ToString(CultureInfo.InvariantCulture);
                    ModifiedDateBox.Text = value.Datetime.ToString(CultureInfo.InvariantCulture);
                    DescriptionText.Text = value.Description;
                    ProgressBar.Value = int.Parse(value.Progress);
                    PriorityBox.SelectedItem = value.Priority;

                    _related = value.Related.Split(',').ToList();
                }
                catch
                {
                    CreatedByText.Text = UserData.UserName;
                    CreationDateText.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                    StateComboBox.Text = "Proposed";
                    PriorityBox.Text = "10";
                }
            }
            get
            {
                return new Data
                           {
                               ID = _id,
                               Title = TitleText.Text,
                               AssignedTo = AssignedToComboBox.Text,
                               State = StateComboBox.Text,
                               CreatedBy = CreatedByText.Text,
                               Datetime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                               CreationDate = CreationDateText.Text,
                               Description = DescriptionText.Text,
                               Progress = ProgressBar.Value.ToString(CultureInfo.InvariantCulture),
                               User = UserData.UserName,
                               Priority = PriorityBox.Text,
                               Related = string.Join(",", _related)
                           };
            }
        }

        private TreeView GetTreeView
        {
            get { return treeView1; }
        }

        public event TaskChanged TaskOpened;
        public event TaskClose TaskClosed;

        private void PopulateRelated(string related, IEnumerable<Data> item)
        {
            dataGridView1.Rows.Clear();

            if (related != string.Empty)
                PopulateListView(item
                                     .Where(x => related.Split(',')
                                                     .Any(y => y == x.ID.ToString(CultureInfo.InvariantCulture))),
                                 dataGridView1);
        }

        /// <summary>
        /// Allows to populate history  tree
        /// </summary>
        /// <param name="tw">tree to populate</param>
        /// <param name="list">source list of History</param>
        private static void PopulateHistory(TreeView tw, IEnumerable<History> list)
        {
            tw.BeginUpdate();
            tw.Nodes.Clear();

            foreach (History history in list)
            {
                var root = new TreeNode {Text = string.Format("{0}: {1}", history.User, history.Text)};
                tw.Nodes.Add(root);

                root.Nodes.Add(history.Datetime);
            }
            tw.ExpandAll();
            tw.EndUpdate();
        }

        /// <summary>
        /// Allows to refresh all data in UC
        /// </summary>
        /// <param name="id">task ID</param>
        private void ReloadData(long id)
        {
            IEnumerable<Data> list = _view.DataList;
            DataItem = list.FirstOrDefault(x => x.ID == id);

            if (id == -1 || DataItem == null) return;
            PopulateRelated(DataItem.Related, list);

            HistoryItem = _view.HistoryList
                .Where(x => x.DataID == id)
                .OrderByDescending(x => x.Datetime)
                .ToList();

            Parent.Text = string.Format("[{0}] {1}", DataItem.ID, DataItem.Title);
            Parent.Tag = id;
        }


        private void ToolStripButton4Click(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(toolStripTextBox1.Text, out i) && i <= _view.DataList.Select(x => x.ID).Max())
            {
                _related.Add(toolStripTextBox1.Text);
                PopulateRelated(string.Join(",", _related), _view.DataList);
                toolStripTextBox1.Text = "";
            }
            else MessageBox.Show(Resources.Input_valid_task_ID);
        }

        /// <summary>
        /// Allows to populate listview
        /// </summary>
        /// <param name="list">list with values</param>
        /// <param name="dgv">target DataGridView</param>
        private static void PopulateListView(IEnumerable<Data> list, DataGridView dgv)
        {
            dgv.Rows.Clear();

            list
                .ToList()
                .ForEach(x => dgv.Rows.Add(new object[]
                                               {
                                                   x.ID,
                                                   x.Title,
                                                   x.AssignedTo,
                                                   x.State,
                                                   x.Priority,
                                                   x.Progress
                                               }));
        }


        //close
        private void ToolStripButton3Click(object sender, EventArgs e)
        {
            if (TaskClosed != null)
                TaskClosed(this);
        }

        //save
        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            Data item = DataItem;
            _id = _communicator.ModifyItem(item, "ID", item.ID, "Data");

            if (!string.IsNullOrWhiteSpace(historyBox.Text))
            {
                HistoryItem.Add(new History
                                    {
                                        Text = historyBox.Text,
                                        User = UserData.UserName,
                                        DataID = _id
                                    });

                historyBox.Text = string.Empty;
                HistoryItem.ToList().ForEach(x => _communicator.ModifyItem(x, "ID", x.ID, "History"));
            }

            ReloadData(_id);
        }

        private void ToolStripButton5Click(object sender, EventArgs e)
        {
            _related.Remove(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
            PopulateRelated(string.Join(",", _related), _view.DataList);
        }

        //reload
        private void TaskUserControlLoad(object sender, EventArgs e)
        {
            ReloadData(_id);
        }

        private void DataGridView1MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
                if (TaskOpened != null)
                    TaskOpened(long.Parse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString()),
                               _view.GetTabControl);
        }
    }
}