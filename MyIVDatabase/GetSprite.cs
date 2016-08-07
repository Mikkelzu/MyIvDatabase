using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.IO;

namespace MyIVDatabase
{
    public class GetSprite
    {
        public static string Path = Directory.GetCurrentDirectory();
        public static BitmapImage GetNormalSprite(object currentPokemonIndex, AddWindow add)
        {
            try
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Path + @"\Sprites\" + currentPokemonIndex + ".png");
                bitmap.EndInit();
                return bitmap;
            }
            catch
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Path + @"\Sprites\0.png");
                bitmap.EndInit();
                return null;
            }
        }

        public static BitmapImage GetShinySprite(object currentPokemonIndex, AddWindow add)
        {
            try
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Path + @"\Sprites Shiny\" + currentPokemonIndex + ".png");
                bitmap.EndInit();
                return bitmap;
            }
            catch
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Path + @"\Sprites Shiny\0.png");
                bitmap.EndInit();
                return null;
            }
        }

        public static BitmapImage NoImageFound()
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Path + @"\Sprites\0.png");
            bitmap.EndInit();
            return bitmap;
        }
    }
}