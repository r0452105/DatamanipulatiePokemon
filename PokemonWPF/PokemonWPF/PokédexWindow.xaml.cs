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

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PokédexWindow : Window
    {
        public MainWindow WindowToAlter;
        public PokédexWindow()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            // open search screen
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            //go back to menu screen
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblSeenCaptured.Content = "Pokémon \n\nSeen: 2 \nCaptured: 1";
        }


        private void LbPokédex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Image bulba = new Image();
            //bulba = "";

            //Image bulba = Image.FromFile("c:\\Bulba.jpg");

            if (lbPokédex.SelectedItems == lbiNumber1)
            {
                //PokédexPicture.Source = bulba;

            }
            //PokédexPicture.Source= pokemon.photolink (property)


        }
    }
}
