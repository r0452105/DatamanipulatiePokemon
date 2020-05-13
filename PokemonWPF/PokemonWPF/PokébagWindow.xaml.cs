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
using PokemonDAL;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for PokébagWindow.xaml
    /// </summary>
    public partial class PokébagWindow : Window
    {
        public Trainer trainerInventory;


        public PokébagWindow()
        {
            InitializeComponent();
    
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           
        }

        private void LbPokébag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LbPokébag_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnCatagory1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCatagory2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCatagory3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCatagory4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {

        }

     
    }
}
