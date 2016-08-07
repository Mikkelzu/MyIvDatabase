using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MyIVDatabase
{
    public class DeletePoke
    {
        public static async void DeleteRow(string name)
        {
            SQLiteConnection cnc = new SQLiteConnection(Connection.ConnectString());

            cnc.Open();

            SQLiteCommand cmd = new SQLiteCommand(Queries.DeletePoke(name), cnc);

            await cmd.ExecuteNonQueryAsync();

            cnc.Close();
        }
    }
}
