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
    public partial class SearchDexWindow : Window
    {

        public Types poketype = new Types();
        List<Types> poketypeentries = DatabaseOperations.Typinglist();
        public PokédexWindow DexWindowToAlter;
        public Pokedex pokedex = new Pokedex();
        IList<Pokedex> pokeEntries = DatabaseOperations.PokedexEntry();
        IList<Pokedex> pokeEntriesAZ = DatabaseOperations.PokedexEntryAZ();
        public SearchDexWindow()
        {
            InitializeComponent();
            foreach (Types poketype in poketypeentries)
            {
                cbType.Items.Add(poketype.TypeName);
            }

            cbSortBy.Items.Add("Alfabetisch");
            cbSortBy.Items.Add("National Dex");

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            DexWindowToAlter.Visibility = Visibility.Visible;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnStartSorting_Click(object sender, RoutedEventArgs e)
        {
            
            switch (cbSortBy.SelectedIndex)
            {
                case 0:
                    // eerst volgorde van de pokemons aanpassen, dan terugleiden naar pokedexscherm
                    foreach (Pokedex pokedex in pokeEntriesAZ)
                    {
                        DexWindowToAlter.lbPokédex.Items.Remove(pokedex.PokemonName);
                    }
                    foreach (Pokedex pokedex in pokeEntriesAZ)
                    {
                        DexWindowToAlter.lbPokédex.Items.Add(pokedex.PokemonName);
                    }
                    DexWindowToAlter.Show();
                    this.Close();
                    break;
                case 1:
                    foreach (Pokedex pokedex in pokeEntries)
                    {
                        DexWindowToAlter.lbPokédex.Items.Remove(pokedex.PokemonName);
                    }
                    foreach (Pokedex pokedex in pokeEntries)
                    {
                        DexWindowToAlter.lbPokédex.Items.Add(pokedex.PokemonName);
                    }
                    DexWindowToAlter.Show();
                    this.Close();
                    break;
                default:
                    MessageBox.Show("Je moet een sorteervorm selecteren.");
                    break;
            }
        }
    }
}
