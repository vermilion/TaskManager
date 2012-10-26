﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Model
{
    public class SQLiteDatabaseHelper
    {
        private static string _dbConnection;

        /// <summary>
        /// Single Param Constructor for specifying the DB file.
        /// </summary>
        /// <param name="inputFile">The File containing the DB</param>
        public SQLiteDatabaseHelper(string inputFile)
        {
            _dbConnection = string.Format("Data Source={0};Version=3;Pooling=True;Max Pool Size=100;", inputFile);
            Trace.Write(_dbConnection);
        }

        /// <summary>
        /// Allows the programmer to interact with the database for purposes other than a query.
        /// </summary>
        /// <param name="sql">The SQL to be run.</param>
        public void ExecuteNonQuery(string sql)
        {
            using (var cnn = new SQLiteConnection(_dbConnection))
            {
                cnn.Open();
                var mycommand = new SQLiteCommand(cnn) {CommandText = sql};
                mycommand.ExecuteNonQuery();
                Trace.Write(sql);
            }
        }


        /// <summary>
        /// Allows the programmer to retrieve single items from the DB.
        /// </summary>
        /// <param name="sql">The query to run.</param>
        /// <returns>A string.</returns>
        public string ExecuteScalar(string sql)
        {
            using (var cnn = new SQLiteConnection(_dbConnection))
            {
                cnn.Open();
                var mycommand = new SQLiteCommand(cnn) {CommandText = sql};
                object value = mycommand.ExecuteScalar();
                Trace.Write(sql);
                if (value != null)
                    return value.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// Allows to get last inserted row
        /// </summary>
        /// <returns>rowid</returns>
        public Int64 GetLastInsertRowId()
        {
            using (var cnn = new SQLiteConnection(_dbConnection))
            {
                cnn.Open();
                using (var mycommand = new SQLiteCommand(cnn) {CommandText = "Select last_insert_rowid();"})
                {
                    mycommand.ExecuteNonQuery();
                    Trace.Write("get rowid");
                    return Int64.Parse(mycommand.ExecuteScalar().ToString());
                }
            }
        }

        /// <summary>
        /// Allows the programmer to easily update rows in the DB.
        /// </summary>
        /// <param name="tableName">The table to update.</param>
        /// <param name="data">A dictionary containing Column names and their new values.</param>
        /// <param name="whereCase">The where clause for the update statement.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public void Update(string tableName, Dictionary<string, string> data, string whereCase)
        {
            string vals = string.Empty;
            if (data.Count > 0)
            {
                vals = data.Aggregate(vals,
                                      (current, val) => String.Format("{0} {1} = '{2}',", current, val.Key, val.Value));
                vals = vals.Substring(0, vals.Length - 1);
            }
            ExecuteNonQuery(String.Format("update {0} set {1} where {2};", tableName, vals, whereCase));
            Trace.Write("update", tableName);
        }


        /// <summary>
        /// Allows the programmer to easily insert into the DB
        /// </summary>
        /// <param name="tableName">The table into which we insert the data.</param>
        /// <param name="data">A dictionary containing the column names and data for the insert.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public void Insert(string tableName, Dictionary<string, string> data)
        {
            string columns = string.Empty;
            string values = string.Empty;
            foreach (var val in data)
            {
                columns += String.Format(" {0},", val.Key);
                values += String.Format(" '{0}',", val.Value);
            }
            columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);
            ExecuteNonQuery(String.Format("insert into {0}({1}) values({2});", tableName, columns, values));
            Trace.Write("insert", tableName);
        }

        /// <summary>
        /// Allows to fill dataset with dbdata
        /// </summary>
        /// <param name="sql">sql query</param>
        /// <returns>Filled DataTable</returns>
        public DataTable FillDataset(string sql)
        {
            using (var ds = new DataSet())
            {
                using (var cnn = new SQLiteConnection(_dbConnection))
                {
                    cnn.Open();
                    new SQLiteDataAdapter(sql, cnn).Fill(ds);
                }
                Trace.Write("fill", sql);
                return ds.Tables[0];
            }
        }
    }
}