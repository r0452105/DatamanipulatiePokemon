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
        public MainWindow WindowToAlter; //link to menu
        public Trainer trainerToSelect = new Trainer(); //voor partycount (pokemon owned)
        public Pokedex pokedex = new Pokedex();
        private List<Pokedex> pokeEntries = DatabaseOperations.PokedexEntry(); //pokeEntries krijgt de gehele database van pokedex entries in de lijst
        public Types poketype = new Types();
        private  List<PokemonGroup> pokeparty = new List<PokemonGroup>();

        public PokédexWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pokeparty = DatabaseOperations.SelectParty(trainerToSelect.Id); //selecteer juiste trainer voor partycount
            int partycount = pokeparty.Count;
            lvPokedex.ItemsSource = pokeEntries;//lv is lijst van alle entries in table pokedex
            lblSeenCaptured.Content = "\nSeen: " + pokeEntries.Count + " \nOwned: " + partycount;// owned nog automatiseren
            lvPokedex.SelectedIndex = 0;
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();// sluiten en terug naar menu
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e) //open searchscreen
        {
            SearchDexWindow searchDexWindow1 = new SearchDexWindow();
            Visibility = Visibility.Hidden;
            searchDexWindow1.DexWindowToAlter = this; 
            searchDexWindow1.ShowDialog();
            Visibility = Visibility.Visible;
        }

        private void BtnCRUD_Click(object sender, RoutedEventArgs e) //open crud screen
        {
            PokedexCRUDWindow CRUDWindow1 = new PokedexCRUDWindow();
            Visibility = Visibility.Hidden;
            CRUDWindow1.DexWindowToAlter = this;
            CRUDWindow1.ShowDialog();
            Visibility = Visibility.Visible;
        }

        private void LvPokedex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvPokedex.SelectedIndex < 0) //omdat selected index nooit negatief kan zijn -> geeft error
            {
                lvPokedex.SelectedIndex = 0;
            }
            foreach (Pokedex pokedex1 in lvPokedex.Items) //zoeken naar juiste pokedex entry
            {
                if (lvPokedex.SelectedItem.ToString().Contains(pokedex1.PokemonName))
                {
                    BitmapImage sprite = new BitmapImage(new Uri("Images/PokemonSprites.png", UriKind.Relative));
                    PokemonSpriteById spriteTarget = new PokemonSpriteById(pokedex1.Id);
                    imgPicturePokémon.Source = new CroppedBitmap(sprite, spriteTarget.target);
                    tbPicName.Text = pokedex1.PokemonName;
                }
            }
        }

        private void LvPokedex_MouseDoubleClick(object sender, MouseButtonEventArgs e)// open infoscreen (pokedex)
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
