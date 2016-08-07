using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MyIVDatabase
{
    public class AddPoke
    {
        public static async void AddPokemon(string name, int hp, int att, int def, int spatt, int spdef, int speed)
        {
            SQLiteConnection cnc = new SQLiteConnection(Connection.ConnectString());

            await cnc.OpenAsync();

            SQLiteCommand cmd = new SQLiteCommand(Queries.AddPokemon(name, hp, att, def, spatt, spdef, speed), cnc);

            await cmd.ExecuteNonQueryAsync();

            cnc.Close();
        }
    }
}
