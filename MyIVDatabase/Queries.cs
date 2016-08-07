using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIVDatabase
{
    public class Queries
    {
        public static string Pokemon
        {
            get
            {
                return "SELECT name, HpIV, AttackIV, DefenseIV, SpAttackIV, SpDefenseIV, SpeedIV FROM pokemon";
            }
        }

        public static string AddPokemon(string name,int hp, int att, int def, int spatt, int spdef, int speed)
        {
            return $"INSERT INTO pokemon (name, HpIV, AttackIV, DefenseIV, SpAttackIV, SpDefenseIV, SpeedIV) VALUES ('{name}', {hp}, {att} ,{def}, {spatt},{spdef},{speed})";
        }

        public static string DeletePoke(string name)
        {
            return $"DELETE FROM pokemon WHERE name = '{name}'";
        }
    }
}
