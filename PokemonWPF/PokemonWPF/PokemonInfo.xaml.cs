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
    /// Interaction logic for PokemonInfo.xaml
    /// </summary>
    public partial class PokemonInfo : Window
    {

        public Pokemon pokemonstats = null;

        public PokemonInfo()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblPokemonNick.Content = pokemonstats.Nickname;

            if (pokemonstats.Gender == false)
            {
                lblPokemonGenderMale.Visibility = Visibility.Visible;
            }
            else if(pokemonstats.Gender == true)
            {
                lblPokemonGenderFemale.Visibility = Visibility.Visible;
            }

            lblPokemonLvl.Content = $"Lvl\t{pokemonstats.PokemonLevel}";

            if (pokemonstats.ItemID != null)
            {
                lblPokemonItem.Content = $"Held: {pokemonstats.Items.ItemName}";
            }

            lblDexNr.Content = pokemonstats.PokedexID;
            lblSpecies.Content = pokemonstats.Pokedex.PokemonName;
            lblOriginalTrainer.Content = pokemonstats.Trainer.TrainerName;
            lblPokemonID.Content = pokemonstats.Id;
            lblTotalXp.Content = pokemonstats.PokemonExp;
            lblXpToNextLevel.Content =  pokemonstats.PokemonLevel * pokemonstats.PokemonLevel * pokemonstats.PokemonLevel  - pokemonstats.PokemonExp;
        }

        private void btnYellow_Click(object sender, RoutedEventArgs e)
        {
            SetColor((Button)sender);

        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            SetColor((Button)sender);

        }

        private void btnPink_Click(object sender, RoutedEventArgs e)
        {
            SetColor((Button)sender);
           
           
        }

        private void SetColor(Button buttonColor)
        {
            CardInfo.Background = buttonColor.Background;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
