using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Common;
using Model;
using TaskControl;

namespace TaskManager.Forms
{
    public partial class MainForm : Form, IView
    {
        private readonly SqliteCommunicator _sqlite = new SqliteCommunicator();

        public MainForm()
        {
            InitializeComponent();
            taskGridView.AutoGenerateColumns = false;

            var column = (DataGridViewComboBoxColumn) queryGridView.Columns["Field"];
            if (column != null)
                column.Items.AddRange(
                    taskGridView.Columns
                        .Cast<DataGridViewColumn>()
                        .Select(x => (object) x.Name)
                        .ToArray());

            QueryBuilder.ReloadQueries(queriesBox);
            queriesBox.SelectedItem = ConfigurationManager.AppSettings["StartupQuery"];
            QueryBuilder.RestoreQuery(queryGridView, string.Format("{0}.xml",
                                                                   ConfigurationManager.AppSettings["StartupQuery"]));
        }

        private DataTable Table
        {
            get { return _sqlite.GetTable("Data"); }
        }

        #region IView Members

        public TabControl GetTabControl
        {
            get { return tabControl1; }
        }

        public IEnumerable<Data> DataList
        {
            get { return Table.ToList<Data>(); }
        }

        public IEnumerable<History> HistoryList
        {
            get { return _sqlite.GetList<History>("History"); }
        }

        #endregion

        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            Populate();
        }

        /// <summary>
        /// Populates main grid
        /// </summary>
        private void Populate()
        {
            Cursor = Cursors.WaitCursor;
            bindingSource1.DataSource = Table;
            QueryBuilder.ApplyFilter(bindingSource1, queryGridView);
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Allows to add new task control
        /// </summary>
        /// <param name="id">task ID</param>
        /// <param name="tabControl">TabControl to add to</param>
        private void AddUserControl(TabControl tabControl, long id = -1)
        {
            try
            {
                tabControl.SelectTab(
                    tabControl.TabPages
                        .Cast<TabPage>()
                        .First(x => x.Tag != null
                                    && x.Tag.ToString() == id.ToString(CultureInfo.InvariantCulture)));
            }
            catch (Exception)
            {
                var tp = new TabPage {Tag = id};
                var tuc = new TaskUserControl(this, id) {Dock = DockStyle.Fill};
                tuc.TaskOpened += AddUserControl;
                tuc.TaskClosed += TucTaskClosed;
                tp.Controls.Add(tuc);

                tabControl.TabPages.Add(tp);
                tabControl.SelectTab(tp);
            }
        }

        /// <summary>
        /// Event of task closed
        /// </summary>
        /// <param name="uc">TaskUserControl</param>
        private void TucTaskClosed(TaskUserControl uc)
        {
            Populate();
            GetTabControl.TabPages.Remove((TabPage) uc.Parent);
        }

        private void AddToolStripMenuItemClick(object sender, EventArgs e)
        {
            AddUserControl(tabControl1);
        }

        private void DataGridViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (taskGridView.SelectedRows.Count == 0) return;
            AddUserControl(tabControl1, int.Parse(taskGridView.SelectedRows[0].Cells["ID"].Value.ToString()));
        }

        private void DataGridView2MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            DataGridView.HitTestInfo hti = queryGridView.HitTest(e.X, e.Y);
            if (hti.RowIndex == -1) return;
            queryGridView.ClearSelection();
            queryGridView.Rows[hti.RowIndex].Selected = true;
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            using (var frm = new DGVOptions(Table, taskGridView.Columns))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    MessageBox.Show("not yet implemented", "TODO");
            }
        }

        private void ToolStripButton3Click(object sender, EventArgs e)
        {
            queryGridView.EndEdit();
            using (var sfd = new SaveFileDialog())
            {
                sfd.FileName = "query";
                sfd.Filter = "xml files |*.xml";
                sfd.RestoreDirectory = true;
                sfd.InitialDirectory = Application.StartupPath + @"\Query";
                if (sfd.ShowDialog() != DialogResult.OK) return;
                QueryBuilder.SaveQuery(queryGridView, sfd.FileName);
                QueryBuilder.ReloadQueries(queriesBox);
            }
        }

        private void QueriesBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            QueryBuilder.RestoreQuery(queryGridView, string.Format("{0}.xml", queriesBox.Text));
            ToolStripButton2Click(sender, e);
            ConfigurationHelper.SaveSettings("StartupQuery", queriesBox.Text);
        }
    }
}