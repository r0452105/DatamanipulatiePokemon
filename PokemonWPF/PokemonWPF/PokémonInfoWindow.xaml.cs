using PokemonDAL;
using PokemonModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PokémonInfoWindow : Window
    {
        public PokédexWindow DexWindowToAlter;
        public Pokedex pokedex = new Pokedex();
        private  List<Pokedex> pokeEntries = DatabaseOperations.PokedexEntry();
        public Types poketype = new Types();
        private readonly List<Types> poketypeentries = DatabaseOperations.Typinglist();




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
                    BitmapImage sprite = new BitmapImage(new Uri("Images/PokemonSprites.png", UriKind.Relative));
                    PokemonSpriteById spriteTarget = new PokemonSpriteById(pokedex.Id);
                    imgPokéSprite.Source = new CroppedBitmap(sprite, spriteTarget.target);
                    tbGewicht.Text = "Gewicht: " + pokedex.PokemonWeight + " kg";
                    tbNumber.Text = "No. " + pokedex.Id + "";
                    tbType.Text = type1 + "  " + type2;
                    tbDescription.Text = pokedex.PokemonDescription;
                    tbPokémonnaam.Text = pokedex.PokemonName;
                }


            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
            DexWindowToAlter.Visibility = Visibility.Visible;
            DexWindowToAlter.Topmost = true;
        }


    }
}
