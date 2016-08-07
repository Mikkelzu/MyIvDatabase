using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace MyIVDatabase
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : MetroWindow
    {
        public AddWindow()
        {
            InitializeComponent();

            Pokemon.Init();
        }

        private async void btnDone_Click(object sender, RoutedEventArgs e)
        {
            int hp = Convert.ToInt32(txtHp.Text);
            int att = Convert.ToInt32(txtAttack.Text);
            int def = Convert.ToInt32(txtDefense.Text);
            int spatt = Convert.ToInt32(txtSpAttack.Text);
            int spdef = Convert.ToInt32(txtSpDefense.Text);
            int speed = Convert.ToInt32(txtSpeed.Text);

            AddPoke.AddPokemon(txtName.Text, hp, att, def, spatt, spdef, speed);

            await this.ShowMessageAsync("Completed", $"Succesfully added your {txtName.Text}");

            Close();
        }
    }
}