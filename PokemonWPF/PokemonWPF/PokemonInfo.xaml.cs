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
            SetContentPartyCard();

            SetContentRedCard();
            SetContentYellowCard();
            
        }
        private void SetContentPartyCard()
        {
            lblPokemonNick.Content = pokemonstats.Nickname;

            if (pokemonstats.Gender == false)
            {
                lblPokemonGenderMale.Visibility = Visibility.Visible;
            }
            else if (pokemonstats.Gender == true)
            {
                lblPokemonGenderFemale.Visibility = Visibility.Visible;
            }

            lblPokemonLvl.Content = $"Lvl\t{pokemonstats.PokemonLevel}";

            if (pokemonstats.ItemID != null)
            {
                lblPokemonItem.Content = $"Held: {pokemonstats.Items.ItemName}";
            }
        }
        private void SetContentRedCard()
        {
            lblDexNr.Content = pokemonstats.PokedexID;
            lblSpecies.Content = pokemonstats.Pokedex.PokemonName;
            lblOriginalTrainer.Content = pokemonstats.Trainer.TrainerName;
            lblPokemonID.Content = pokemonstats.Id;
            lblTotalXp.Content = pokemonstats.PokemonExp;

            if (pokemonstats.Pokedex.Type1 != null)
            {
                SetTypes(borderType1, lblType1, pokemonstats.Pokedex.Type1, pokemonstats.Pokedex.Types.ToString()); //type1

            }

            if (pokemonstats.Pokedex.Type2 != null)
            {
                SetTypes(borderType2, lblType2, pokemonstats.Pokedex.Type2, pokemonstats.Pokedex.Types1.ToString()); //type1
            }



            if (pokemonstats.PokemonLevel == 100)
            {
                lblXpToNextLevel.Content = pokemonstats.PokemonLevel * pokemonstats.PokemonLevel * pokemonstats.PokemonLevel - pokemonstats.PokemonExp;
            }
            else
            {
                lblXpToNextLevel.Content = (pokemonstats.PokemonLevel + 1) * (pokemonstats.PokemonLevel + 1) * (pokemonstats.PokemonLevel + 1) - pokemonstats.PokemonExp;
            }


        }

        private void SetContentYellowCard()
        {
            lblHPstat.Content = pokemonstats.ReturnHP();
            lblAttackstat.Content = pokemonstats.StatPool.TotalAttack(pokemonstats);
            lblDefensestat.Content = pokemonstats.StatPool.TotalDefense(pokemonstats);
            lblspAttackstat.Content = pokemonstats.StatPool.TotalSpAttack(pokemonstats);
            lblSpdefencestat.Content = pokemonstats.StatPool.TotalSpDefense(pokemonstats);
            lblSpeed.Content = pokemonstats.StatPool.TotalSpeed(pokemonstats);
            lblNature.Content = pokemonstats.StatPool.Nature;
            lblAbility.Content = pokemonstats.Ability.AbilityName;
            GridYellow.Visibility = Visibility.Collapsed;
        }
        private void SetTypes(Border bordertoalter, Label labelToAlter, int? typeId, string typeName)
        {
            labelToAlter.Content = typeName;
            switch (typeId)
            {
                case 1: bordertoalter.Background = Brushes.Green;                     
                    break;
                case 2: bordertoalter.Background = Brushes.Purple;
                    labelToAlter.Foreground = Brushes.White;
                    break;
                case 3:
                    bordertoalter.Background = Brushes.OrangeRed;
                    break;
                case 4:
                    bordertoalter.Background = Brushes.LightGray;
                    break;
                case 5:
                    bordertoalter.Background = Brushes.Blue;
                    break;
                case 6:
                    bordertoalter.Background = Brushes.Beige;
                    break;
                case 7:
                    bordertoalter.Background = Brushes.White;
                    break;
                case 8:
                    bordertoalter.Background = Brushes.DeepPink;
                    break;
                case 9:
                    bordertoalter.Background = Brushes.Black;
                    labelToAlter.Foreground = Brushes.White;
                    break;
                case 10:
                    bordertoalter.Background = Brushes.DarkBlue;
                    labelToAlter.Foreground = Brushes.White;
                    break;
                case 11:
                    bordertoalter.Background = Brushes.SaddleBrown;
                    labelToAlter.Foreground = Brushes.White;
                    break;
            }
            

        }
        private void btnYellow_Click(object sender, RoutedEventArgs e)
        {
            SetColor((Button)sender);
            GridRed.Visibility = Visibility.Collapsed;
            GridYellow.Visibility = Visibility.Visible;
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            SetColor((Button)sender);
            GridRed.Visibility = Visibility.Visible;
            GridYellow.Visibility = Visibility.Collapsed;
        }

        private void btnPink_Click(object sender, RoutedEventArgs e)
        {
            SetColor((Button)sender);
            GridRed.Visibility = Visibility.Collapsed;
            GridYellow.Visibility = Visibility.Collapsed;
            
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
