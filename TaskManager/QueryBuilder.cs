using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using Model;

namespace TaskManager
{
    public static class QueryBuilder
    {
        private static readonly string DirectoryPath = Path.Combine(Application.StartupPath, "Query");

        /// <summary>
        /// Allows to convert datagridview to query list
        /// </summary>
        /// <param name="dgv">source</param>
        /// <param name="filename">path to save</param>
        public static void SaveQuery(DataGridView dgv, string filename)
        {
            dgv.EndEdit();
            dgv.Rows[0].Cells["AndOr"].Value = string.Empty;

            IEnumerable queryList = dgv.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells["Field"].Value != null
                              && row.Cells["Operator"].Value != null
                              && row.Cells["Value"].Value != null)
                .Select(row => new Query
                                   {
                                       AndOr = row.Cells["AndOr"].Value != null
                                                   ? row.Cells["AndOr"].Value.ToString()
                                                   : "",
                                       Field = row.Cells["Field"].Value.ToString(),
                                       Operator = row.Cells["Operator"].Value.ToString(),
                                       Value = row.Cells["Value"].Value.ToString()
                                   })
                .ToList();

            using (var sw = new StreamWriter(Path.Combine(DirectoryPath, filename), false, Encoding.Default))
            {
                queryList.Serialize(sw);
            }
        }

        /// <summary>
        /// Allows to fill query grid from file
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="name">query name</param>
        public static void RestoreQuery(DataGridView dgv, string name)
        {
            dgv.Rows.Clear();
            using (var sr = new StreamReader(Path.Combine(DirectoryPath, name), Encoding.Default))
            {
                foreach (Query query in SerializerHelper.Deserialize<List<Query>>(sr, typeof (Query)))
                {
                    dgv.Rows.Add(query.AndOr, query.Field, query.Operator, query.Value);
                }
            }
        }

        /// <summary>
        /// Allows to convert DataGridView rows to BindingSource filter
        /// </summary>
        /// <param name="bindingSource">target BindingSource</param>
        /// <param name="dgv">source DataGridView</param>
        public static void ApplyFilter(BindingSource bindingSource, DataGridView dgv)
        {
            dgv.EndEdit();
            string filtertext = "";
            dgv.Rows[0].Cells["AndOr"].Value = "";
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Field"].Value == null ||
                    row.Cells["Operator"].Value == null ||
                    row.Cells["Value"].Value == null)
                    continue;

                string value = row.Cells["Value"].Value.ToString() == "@me"
                                   ? UserData.UserName
                                   : row.Cells["Value"].Value.ToString();

                filtertext += string.Format("{0} {1} {2} '{3}' ",
                                            row.Cells["AndOr"].Value,
                                            row.Cells["Field"].Value,
                                            row.Cells["Operator"].Value,
                                            value);
            }

            try
            {
                bindingSource.Filter = filtertext;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid query\r\n" + ex.Message, "Query error");
                bindingSource.Filter = string.Empty;
            }
        }

        /// <summary>
        /// Reloads all xml queries
        /// </summary>
        /// <param name="cbx">combobox to fill</param>
        /// <param name="extension">file extention</param>
        public static void ReloadQueries(ToolStripComboBox cbx, string extension = "*.xml")
        {
            cbx.Items.Clear();
            foreach (var file in new DirectoryInfo(DirectoryPath).GetFiles(extension))
            {
                cbx.Items.Add(file.Name.Replace(extension, ""));
            }
        }
    }

    public class Query
    {
        public string AndOr;
        public string Field;
        public string Operator;
        public string Value;
    }
}