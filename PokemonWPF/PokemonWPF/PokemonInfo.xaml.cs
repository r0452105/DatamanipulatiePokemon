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
        List<Label> NameLabels = new List<Label>();
        List<Label> DamageLabels = new List<Label>();
        List<Label> AccuracyLabels = new List<Label>();
        List<Label> PPLabels = new List<Label>();
        List<Label> TypeLabels = new List<Label>();
        List<Border> TypeCards = new List<Border>();
        List<Border> MoveCards = new List<Border>();
        List<LearnedMoves> MovesOfPokemon; 
        public Pokemon pokemonstats = null;

        public PokemonInfo()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MovesOfPokemon = DatabaseOperations.SelectMovesFromPokemon(pokemonstats);
            SetContentPartyCard();

            SetContentRedCard();
            SetContentYellowCard();
            OrderElementsMoves();
            SetContentPinkCard();
        }

        private void OrderElementsMoves()
        {
            MoveCards.Add(CardMove1);
            MoveCards.Add(CardMove2);
            MoveCards.Add(CardMove3);
            MoveCards.Add(CardMove4);

            NameLabels.Add(lblMoveName1);
            NameLabels.Add(lblMoveName2);
            NameLabels.Add(lblMoveName3);
            NameLabels.Add(lblMoveName4);

            TypeLabels.Add(lblMoveType1);
            TypeLabels.Add(lblMoveType2);
            TypeLabels.Add(lblMoveType3);
            TypeLabels.Add(lblMoveType4);

            TypeCards.Add(borderMoveType1);
            TypeCards.Add(borderMoveType2);
            TypeCards.Add(borderMoveType3);
            TypeCards.Add(borderMoveType4);

            AccuracyLabels.Add(lblMoveAccuracy1);
            AccuracyLabels.Add(lblMoveAccuracy2);
            AccuracyLabels.Add(lblMoveAccuracy3);
            AccuracyLabels.Add(lblMoveAccuracy4);

            DamageLabels.Add(lblMoveDamage1);
            DamageLabels.Add(lblMoveDamage2);
            DamageLabels.Add(lblMoveDamage3);
            DamageLabels.Add(lblMoveDamage4);

            PPLabels.Add(lblPP1);
            PPLabels.Add(lblPP2);
            PPLabels.Add(lblPP3);
            PPLabels.Add(lblPP4);
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

        private void SetContentPinkCard()
        {
            int counter = 0;
            foreach (var item in MoveCards)
            {
                if (counter < MovesOfPokemon.Count)
                {
                    item.Visibility = Visibility.Visible;
                    SetTypes(TypeCards[counter], TypeLabels[counter], MovesOfPokemon[counter].PokemonMoves.MoveTypeID, MovesOfPokemon[counter].PokemonMoves.Types.ToString());
                    NameLabels[counter].Content = MovesOfPokemon[counter].PokemonMoves.MoveName;
                    AccuracyLabels[counter].Content = $"Accuracy: {MovesOfPokemon[counter].PokemonMoves.Accuracy}%";
                    DamageLabels[counter].Content = $"Damage: {MovesOfPokemon[counter].PokemonMoves.DamagePoints}";
                    PPLabels[counter].Content = MovesOfPokemon[counter].ReturnPP();
                 }
                counter++;
            }

            GridPink.Visibility = Visibility.Collapsed;
        }
        private void btnYellow_Click(object sender, RoutedEventArgs e)
        {
            SetColor((Button)sender);
            GridRed.Visibility = Visibility.Collapsed;
            GridYellow.Visibility = Visibility.Visible;
            GridPink.Visibility = Visibility.Collapsed;
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            SetColor((Button)sender);
            GridRed.Visibility = Visibility.Visible;
            GridYellow.Visibility = Visibility.Collapsed;
            GridPink.Visibility = Visibility.Collapsed;
        }

        private void btnPink_Click(object sender, RoutedEventArgs e)
        {
            SetColor((Button)sender);
            GridRed.Visibility = Visibility.Collapsed;
            GridYellow.Visibility = Visibility.Collapsed;
            GridPink.Visibility = Visibility.Visible;
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
