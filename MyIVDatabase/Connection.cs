using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace MyIVDatabase
{
    public class Connection
    {
        public static string ConnectString()
        {
            string c = " Data Source=mypokes.s3db;Version=3;datetimeformat=CurrentCulture;foreign keys=true;";

            return c;
        }

        public static async Task<DataSet> ShowDatabaseInGrid()
        {
            using (SQLiteConnection cnc = new SQLiteConnection(ConnectString()))
            {
                cnc.Open();
                string sql = Queries.Pokemon;

                SQLiteCommand cmd = new SQLiteCommand(sql, cnc);

                await cmd.ExecuteNonQueryAsync();

                DataSet dataSet = new DataSet();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(dataSet);
                cnc.Close();

                return dataSet;
            }
        }
    }
}
