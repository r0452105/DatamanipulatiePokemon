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
            cbType.Items.Add("Geen Specifieke typing");
            foreach (Types poketype in poketypeentries)
            {
                cbType.Items.Add(poketype.TypeName);
            }
            cbSortBy.Items.Add("Alfabetisch");
            cbSortBy.Items.Add("National Dex");

            cbType.SelectedIndex = 0;

        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            DexWindowToAlter.Visibility = Visibility.Visible;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (Pokedex pokedex in pokeEntries)
            {
                DexWindowToAlter.lbPokédex.Items.Remove(pokedex.PokemonName);
            }
            foreach (Pokedex pokedex in pokeEntries)
            {
                if (pokedex.PokemonName.ToLower().Contains(tbName.Text.ToLower()))
                {
                    string type1 = "";
                    string type2 = "";

                    foreach (Types poketype in poketypeentries)
                    {
                        if (poketype.Id == pokedex.Type1)
                        {
                            type1 = poketype.TypeName;
                        }
                        else if (poketype.Id == pokedex.Type2)
                        {
                            type2 = poketype.TypeName;
                        }
                    }
                    if (cbType.SelectedIndex==0)
                    {
                        DexWindowToAlter.lbPokédex.Items.Add(pokedex.PokemonName);
                    }
                    else if (type1 == cbType.SelectedItem.ToString() || type2 == cbType.SelectedItem.ToString())
                    {
                        DexWindowToAlter.lbPokédex.Items.Add(pokedex.PokemonName);
                    } 
                }
            }
            DexWindowToAlter.Show();
            this.Close();
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

        private void CbType_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
