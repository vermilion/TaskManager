using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Model
{
    public class SqliteCommunicator : ICommunicator
    {
        private readonly SQLiteDatabaseHelper _db;

        /// <summary>
        /// Constructor with database name
        /// </summary>
        public SqliteCommunicator()
        {
            _db = new SQLiteDatabaseHelper(FileName);
        }

        private string FileName
        {
            get { return ConfigurationManager.AppSettings["FileName"]; }
        }

        #region ICommunicator Members

        /// <summary>
        /// Allows to select * from tablename
        /// </summary>
        /// <typeparam name="T">Class to convert to</typeparam>
        /// <param name="table">target table</param>
        /// <returns>List of T</returns>
        public IEnumerable<T> GetList<T>(string table) where T : new()
        {
            return _db.FillDataset(string.Format("select * from '{0}'", table)).ToList<T>();
        }

        public void DeleteItem(object key, object id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows to insert or update item in database by Key
        /// </summary>
        /// <param name="item"> </param>
        /// <param name="key">unique key name</param>
        /// <param name="id">unique key value</param>
        /// <param name="table">sqlite table</param>
        /// <returns>rowid</returns>
        public long ModifyItem<T>(T item, object key, object id, string table) where T : class
        {
            Dictionary<string, string> dict = item.GetType()
                .GetFields()
                .ToDictionary(x => x.Name,
                              x => x.GetValue(item).ToString().Replace("'", "''"));

            if (_db.ExecuteScalar(String.Format("select {0} from '{1}' where {2}='{3}'", key, table, key, id)) ==
                string.Empty)
            {
                dict.Remove("ID");
                _db.Insert(table, dict);
                return _db.GetLastInsertRowId();
            }
            _db.Update(table, dict, String.Format("{0}={1}", key, id));
            return long.Parse(id.ToString());
        }

        #endregion

        public DataTable GetTable(string table)
        {
            return _db.FillDataset(string.Format("select * from '{0}'", table));
        }

        /// <summary>
        /// Allows to upgrade sqlite database file
        /// </summary>
        /// <returns>PRAGMA user_version</returns>
        public long UpgradeDatabase()
        {
            const int newVersion = 1;
            int oldVersion = int.Parse(_db.ExecuteScalar("PRAGMA user_version"));
            if (newVersion == oldVersion) return newVersion;
            for (int i = oldVersion; i < newVersion; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            _db.ExecuteNonQuery(
                                "CREATE TABLE Data (" +
                                "ID integer PRIMARY KEY, " +
                                "Title text, " +
                                "CreationDate text, " +
                                "User text, " +
                                "ModifyDate text, " +
                                "CreatedBy text, " +
                                "AssignedTo text, " +
                                "State text, " +
                                "Progress text, " +
                                "Priority text, " +
                                "Datetime text, " +
                                "Related text, " +
                                "Description text" +
                                ")");
                            _db.ExecuteNonQuery(
                                "CREATE TABLE History (" +
                                "ID integer PRIMARY KEY, " +
                                "DataID text, " +
                                "Datetime text, " +
                                "User text, " +
                                "Text text" +
                                ")");
                            _db.ExecuteNonQuery(
                                "CREATE TABLE Users (" +
                                "Login text UNIQUE, " +
                                "Pass text, " +
                                "ShowAs text" +
                                ")");
                            _db.ExecuteNonQuery("PRAGMA user_version = 1");
                            break;
                        }
                }
            }
            return long.Parse(_db.ExecuteScalar("PRAGMA user_version"));
        }
    }

    /// <summary>
    /// Allows to convert DataTable to List of T
    /// </summary>
    public static class DataTableExtensions
    {
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            return table.Rows
                .Cast<object>()
                .Select(row => CreateItemFromRow<T>((DataRow) row, typeof (T).GetFields().ToList()))
                .ToList();
        }

        private static T CreateItemFromRow<T>(DataRow row, IEnumerable<FieldInfo> properties) where T : new()
        {
            var item = new T();
            properties.ToList().ForEach(x => { if (!(row[x.Name] is DBNull)) x.SetValue(item, row[x.Name]); });
            return item;
        }
    }
}