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
    public partial class PokédexWindow : Window
    {
        public MainWindow WindowToAlter;
        public Pokedex pokedex = new Pokedex();
        IList<Pokedex> pokeEntries = DatabaseOperations.PokedexEntry();
        public Types poketype = new Types();
        List<Types> poketypeentries = DatabaseOperations.Typinglist(); 

        public PokédexWindow()
        {
            InitializeComponent();
            
            
            foreach (Pokedex pokedex in pokeEntries)
            {
                lbPokédex.Items.Add(pokedex.PokemonName);
            }
            lblSeenCaptured.Content = "Pokémon \n\nSeen: " + pokeEntries.Count+" \nOwned: 6";// owned nog automatiseren
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            WindowToAlter.Visibility = Visibility.Visible;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e) //search nog compleet uitwerken
        {
            this.Visibility = Visibility.Hidden;
            SearchDexWindow searchDexWindow1 = new SearchDexWindow();
            searchDexWindow1.DexWindowToAlter = this;
            searchDexWindow1.Show();
            
        }


        private void LbPokédex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //voor foto aanpassing


        }

        private void LbPokédex_MouseDoubleClick(object sender, MouseButtonEventArgs e) //code mss in effectieve scherm zetten
        {
            PokémonInfoWindow PokéInfoWindow1 = new PokémonInfoWindow();
            PokéInfoWindow1.DexWindowToAlter = this;
            PokéInfoWindow1.tbPokémonnaam.Text = lbPokédex.SelectedItem.ToString();
            decimal gewicht = 0;
            int number = 0;
            string type1 = "";
            string type2 = "";
            string uitleg = "";
                        



            foreach (Pokedex pokedex in pokeEntries)
            {
                if(pokedex.PokemonName == PokéInfoWindow1.tbPokémonnaam.Text)
                {
                    gewicht = pokedex.PokemonWeight;
                    number = pokedex.Id;
                    uitleg = pokedex.PokemonDescription;

                    
                   foreach(Types poketype in poketypeentries)
                    {
                        if (poketype.Id == pokedex.Type1)
                        {
                            type1 = poketype.TypeName;
                        }else if (poketype.Id == pokedex.Type2)
                        {
                            type2 = poketype.TypeName;
                        }
                    }
                }
            }
            PokéInfoWindow1.tbGewicht.Text = "Gewicht: "+gewicht + " kg";
            PokéInfoWindow1.tbNumber.Text = "No. "+number+ "";
            PokéInfoWindow1.tbType.Text = type1+"  "+type2;
            PokéInfoWindow1.lblDescription.Content = uitleg;
            PokéInfoWindow1.Show();
            this.Visibility = Visibility.Hidden;




        }
    }
}
