using System;
using System.Collections.Generic;
using System.IO;

namespace MyIVDatabase
{
    public class Pokemon
    {
        public static List<Pokemon> pokemonList = new List<Pokemon>();
        private int id_ = 0;
        public static void Init()
        {
            try
            {
                using (var sr = new StreamReader("/pokemondata.txt"))
                {
                    var line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] spl = line.Split(';');
                        if (spl.Length == 2)
                        {
                            try
                            {
                                new Pokemon(Convert.ToInt32(spl[0]), spl[1]);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Pokemon(int id, string name)
        {

            id_ = id;
            Name = name;
           
            pokemonList.Add(this);
        }

        public string Name { get; } = "";
    }
}