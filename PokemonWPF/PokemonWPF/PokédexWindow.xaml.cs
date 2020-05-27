using PokemonDAL;
using PokemonModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PokédexWindow : Window
    {
        public MainWindow WindowToAlter;
        public Trainer trainerToSelect = new Trainer();
        public Pokedex pokedex = new Pokedex();
        private IList<Pokedex> pokeEntries = DatabaseOperations.PokedexEntry();
        public Types poketype = new Types();
        private readonly List<Types> poketypeentries = DatabaseOperations.Typinglist();
        private  List<PokemonGroup> pokeparty = new List<PokemonGroup>();

        public PokédexWindow()
        {
            InitializeComponent();

            //if searchscherm is zonet gebruikt dan komt er mogelijks een alternatief else zie hieronder
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            pokeparty = DatabaseOperations.SelectParty(trainerToSelect.Id);
            int partycount = pokeparty.Count;
            lvPokedex.ItemsSource = pokeEntries;
            lblSeenCaptured.Content = "\nSeen: " + pokeEntries.Count + " \nOwned: " + partycount;// owned nog automatiseren

            lvPokedex.SelectedIndex = 0;
         
        }



        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e) //search nog compleet uitwerken
        {
            SearchDexWindow searchDexWindow1 = new SearchDexWindow();
            Visibility = Visibility.Hidden;
            searchDexWindow1.DexWindowToAlter = this;
            searchDexWindow1.ShowDialog();
            Visibility = Visibility.Visible;
        }

        private void BtnCRUD_Click(object sender, RoutedEventArgs e)
        {
            PokedexCRUDWindow CRUDWindow1 = new PokedexCRUDWindow();
            Visibility = Visibility.Hidden;
            CRUDWindow1.DexWindowToAlter = this;
            CRUDWindow1.ShowDialog();
            Visibility = Visibility.Visible;
        }

        private void LvPokedex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            foreach (Pokedex pokedex1 in pokeEntries)
            {
                if (lvPokedex.SelectedIndex == (pokedex1.Id - 1))
                {
                    BitmapImage sprite = new BitmapImage(new Uri("Images/PokemonSprites.png", UriKind.Relative));
                    PokemonSpriteById spriteTarget = new PokemonSpriteById(pokedex1.Id);
                    imgPicturePokémon.Source = new CroppedBitmap(sprite, spriteTarget.target);
                }
            }


        }

        private void LvPokedex_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PokémonInfoWindow PokéInfoWindow1 = new PokémonInfoWindow();
            Visibility = Visibility.Hidden;
            PokéInfoWindow1.DexWindowToAlter = this;
            PokéInfoWindow1.ShowDialog();
            //problem opening main
            Visibility = Visibility.Visible;
        }
    }
}
