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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PokedexCRUDWindow : Window
    {
        public PokédexWindow DexWindowToAlter;
        List<Pokedex> pokedexentries = DatabaseOperations.PokedexEntry();
        Pokedex pokedexEntry = new Pokedex();
        List<Types> types = DatabaseOperations.Typinglist();

        public PokedexCRUDWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datagridPokedexEntries.ItemsSource = pokedexentries;
            cmbType1.ItemsSource = types;
            cmbType2.ItemsSource= types;
        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            pokedexEntry.Id = 1000;//needs to be lowest available slot
            
            pokedexEntry.PokemonName = txtNaam.Text;
            pokedexEntry.Type1 = cmbType1.SelectedIndex+1;
            pokedexEntry.Type2 = cmbType2.SelectedIndex+1;//remember index must be same as the real id's of the types

            pokedexEntry.PokemonDescription = "Nothing";
            pokedexEntry.PokemonWeight = 50.0M;
            pokedexEntry.ExpMax = 160;
            pokedexEntry.EvolveItems = null;
            pokedexEntry.CaptureRate = 45;
            pokedexEntry.EvolveThreshold = null;

        }
    }
}
