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
using PokemonWPF;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PokémonInfoWindow : Window
    {
        public PokédexWindow DexWindowToAlter;
        public Pokedex pokedex = new Pokedex();
        IList<Pokedex> pokeEntries = DatabaseOperations.PokedexEntry();
        public Types poketype = new Types();
        List<Types> poketypeentries = DatabaseOperations.Typinglist();


        public PokémonInfoWindow()
        {
            InitializeComponent();

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbPokémonnaam.Text = DexWindowToAlter.lbPokédex.SelectedItem.ToString();
            decimal gewicht = 0;
            int number = 0;
            string type1 = "";
            string type2 = "";
            string uitleg = "";

            foreach (Pokedex pokedex in pokeEntries)
            {
                if (pokedex.PokemonName == tbPokémonnaam.Text)
                {
                    gewicht = pokedex.PokemonWeight;
                    number = pokedex.Id;
                    uitleg = pokedex.PokemonDescription;


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
                }
            }
            tbGewicht.Text = "Gewicht: " + gewicht + " kg";
            tbNumber.Text = "No. " + number + "";
            tbType.Text = type1 + "  " + type2;
            lblDescription.Content = uitleg;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            DexWindowToAlter.Visibility = Visibility.Visible;
        }

        
    }
}
