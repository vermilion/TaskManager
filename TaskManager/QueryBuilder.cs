using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Model;

namespace TaskManager
{
    public class QueryBuilder
    {
        /// <summary>
        /// Allows to convert datagridview to query list
        /// </summary>
        /// <param name="dgv">source</param>
        /// <param name="path">path to save</param>
        public static void SaveQuery(DataGridView dgv, string path)
        {
            var queryList = new List<Query>();
            dgv.EndEdit();
            dgv.Rows[0].Cells["AndOr"].Value = "";

            foreach (DataGridViewRow row in dgv.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells["Field"].Value != null
                              && row.Cells["Operator"].Value != null
                              && row.Cells["Value"].Value != null))
            {
                queryList.Add(new Query
                                  {
                                      AndOr = row.Cells["AndOr"].Value != null
                                                  ? row.Cells["AndOr"].Value.ToString()
                                                  : "",
                                      Field = row.Cells["Field"].Value.ToString(),
                                      Operator = row.Cells["Operator"].Value.ToString(),
                                      Value = row.Cells["Value"].Value.ToString()
                                  });
            }

            using (var myWriter = new StreamWriter(path, false, Encoding.Default))
            {
                new XmlSerializer(typeof (List<Query>), new[] {typeof (Query)}).Serialize(myWriter, queryList);
            }
        }

        public static void RestoreQuery(DataGridView dgv, string path)
        {
            if (!File.Exists(path)) return;
            dgv.Rows.Clear();
            using (var myReader = new StreamReader(path, Encoding.Default))
            {
                var mySerializer = new XmlSerializer(typeof (List<Query>), new[] {typeof (Query)});
                foreach (Query query in (List<Query>) mySerializer.Deserialize(myReader))
                {
                    dgv.Rows.Add(new object[]
                                     {
                                         query.AndOr,
                                         query.Field,
                                         query.Operator,
                                         query.Value
                                     });
                }
            }
        }

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

                var value = row.Cells["Value"].Value.ToString() == "@me"
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
            }
        }

        public static void ReloadQueries(ToolStripComboBox cbx)
        {
            cbx.Items.Clear();
            foreach (string file in Directory.GetFiles(Application.StartupPath + @"\Query", "*.xml"))
            {
                cbx.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
        }

        #region Nested type: Query

        public class Query
        {
            public string AndOr;
            public string Field;
            public string Operator;
            public string Value;
        }

        #endregion
    }
}