using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TaskManager.Forms
{
    public partial class DGVOptions : Form
    {
        public DGVOptions(DataTable dataTable, DataGridViewColumnCollection columnCollection)
        {
            InitializeComponent();

            IEnumerable<object> existingColumns =
                columnCollection.Cast<DataGridViewColumn>().Select(x => (object) x.Name);
            IEnumerable<object> availiableColumns =
                dataTable.Columns.Cast<DataColumn>().Select(x => (object) x.ColumnName);
            listBox1.Items.AddRange(availiableColumns.Except(existingColumns).ToArray());
            listBox2.Items.AddRange(existingColumns.ToArray());
        }

        private void Button1Click(object sender, EventArgs e)
        {
            MoveItem(listBox1, listBox2);
        }

        private void Button2Click(object sender, EventArgs e)
        {
            MoveItem(listBox2, listBox1);
        }

        private void MoveItem(ListBox sourceList, ListBox targetList)
        {
            if (sourceList.SelectedItem != null)
                targetList.Items.Add(listBox1.SelectedItem);
            sourceList.Items.Remove(listBox1.SelectedItem);
        }
    }
}