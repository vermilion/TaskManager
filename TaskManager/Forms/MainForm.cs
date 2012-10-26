using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
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
            dataGridView1.AutoGenerateColumns = false;

            ((DataGridViewComboBoxColumn) dataGridView2.Columns["Field"]).Items.AddRange(
                dataGridView1.Columns
                    .Cast<DataGridViewColumn>()
                    .Select(x => (object) x.Name)
                    .ToArray());


            QueryBuilder.ReloadQueries(queriesBox);
            queriesBox.SelectedItem = ConfigurationManager.AppSettings["StartupQuery"];
            QueryBuilder.RestoreQuery(dataGridView2, string.Format("{0}\\Query\\{1}.xml",
                                                                   Application.StartupPath,
                                                                   ConfigurationManager.AppSettings["StartupQuery"]));
        }

        #region IView Members

        public TabControl GetTabControl
        {
            get { return tabControl1; }
        }

        public DataTable Table
        {
            get { return _sqlite.GetTable("Data"); }
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


        private void Populate()
        {
            bindingSource1.DataSource = Table;
            bindingSource1.Sort = "ID DESC";
            QueryBuilder.ApplyFilter(bindingSource1, dataGridView2);
        }

        private void AddUserControl(long id, TabControl tabControl)
        {
            foreach (TabPage tabPage in tabControl.TabPages
                .Cast<TabPage>()
                .Where(
                    tabPage =>
                    tabPage.Tag != null &&
                    tabPage.Tag.ToString() == id.ToString(CultureInfo.InvariantCulture)))
            {
                tabControl.SelectTab(tabPage);
                return;
            }

            var tp = new TabPage {Tag = id};
            var tuc = new TaskUserControl(this, id) {Dock = DockStyle.Fill};
            tuc.TaskOpened += AddUserControl;
            tuc.TaskClosed += TucTaskClosed;
            tp.Controls.Add(tuc);

            tabControl.TabPages.Add(tp);
            tabControl.SelectTab(tp);
        }

        private void TucTaskClosed(TaskUserControl uc)
        {
            Populate();
            GetTabControl.TabPages.Remove((TabPage) uc.Parent);
        }

        private void AddToolStripMenuItemClick(object sender, EventArgs e)
        {
            AddUserControl(-1, tabControl1);
        }

        private void ListView1MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddUserControl(int.Parse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString()), tabControl1);
        }


        private void InsertClauseToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0) return;
            dataGridView2.Rows.Insert(dataGridView2.SelectedRows[0].Index);
        }

        private void DeleteSelectedClauseToolStripMenuItemClick(object sender, EventArgs e)
        {
            dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
        }

        private void DataGridView2MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            DataGridView.HitTestInfo hti = dataGridView2.HitTest(e.X, e.Y);
            if (hti.RowIndex == -1) return;
            dataGridView2.ClearSelection();
            dataGridView2.Rows[hti.RowIndex].Selected = true;
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            using (var frm = new DGVOptions(Table, dataGridView1.Columns))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    MessageBox.Show("not yet implemented", "TODO");
            }
        }

        private void ToolStripButton3Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.FileName = "query";
                sfd.Filter = "xml files |*.xml";
                sfd.RestoreDirectory = true;
                sfd.InitialDirectory = Application.StartupPath + @"\Query";
                if (sfd.ShowDialog() != DialogResult.OK) return;
                QueryBuilder.SaveQuery(dataGridView2, sfd.FileName);
                QueryBuilder.ReloadQueries(queriesBox);
            }
        }

        private void QueriesBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            QueryBuilder.RestoreQuery(dataGridView2,
                                      string.Format("{0}\\Query\\{1}.xml", Application.StartupPath, queriesBox.Text));
            ToolStripButton2Click(sender, e);
            DataClass.SaveSettings("StartupQuery", queriesBox.Text);
        }
    }
}