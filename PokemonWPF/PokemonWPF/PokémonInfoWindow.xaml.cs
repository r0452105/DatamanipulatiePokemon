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
using PokemonModels;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PokémonInfoWindow : Window
    {
        public PokédexWindow DexWindowToAlter;
        public Pokedex pokedex = new Pokedex();
        List<Pokedex> pokeEntries = DatabaseOperations.PokedexEntry();
        public Types poketype = new Types();
        List<Types> poketypeentries = DatabaseOperations.Typinglist();
        Bulbasaur pokedexPic1 = new Bulbasaur();
       


        public PokémonInfoWindow()
        {
            InitializeComponent();

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string pokerefer = DexWindowToAlter.lvPokedex.SelectedItem.ToString();
            
            foreach (Pokedex pokedex in pokeEntries)
            {
                string pokenum = pokedex.PokemonName;
                if ((pokerefer.Contains(pokenum)) == true)
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

                    tbGewicht.Text = "Gewicht: " + pokedex.PokemonWeight + " kg";
                    tbNumber.Text = "No. " + pokedex.Id + "";
                    tbType.Text = type1 + "  " + type2;
                    tbDescription.Text = pokedex.PokemonDescription;
                    tbPokémonnaam.Text = pokedex.PokemonName;

                    BitmapImage pokemonbitmap = new BitmapImage(new Uri("Images/PokemonSprites.png", UriKind.Relative));
                    imgPokéSprite.Source = new CroppedBitmap(pokemonbitmap, pokedexPic1.target);

                }
                
                
            }
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            DexWindowToAlter.Visibility = Visibility.Visible;
            DexWindowToAlter.Topmost=true;
        }

        
    }
}
