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
using PokemonModels;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for PokemonParty.xaml
    /// </summary>
    public partial class PokemonParty : Window
    {
        List<Label> NameLabels = new List<Label>();
        List<Label> HealthLabels = new List<Label>();
        List<Border> Cards = new List<Border>();
        List<Image> Sprites = new List<Image>();
        public Trainer trainerParty;
        
        List<PokemonGroup> Pokemonparty = new List<PokemonGroup>();
        public PokemonParty()
        {
            InitializeComponent();
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Pokemonparty = DatabaseOperations.SelectParty(trainerParty.Id);
            OrderElements();
            LoadPokemon();
        }

        private void OrderElements() {
            Cards.Add(Card1);
            Cards.Add(Card2);
            Cards.Add(Card3);
            Cards.Add(Card4);
            Cards.Add(Card5);
            Cards.Add(Card6);

            HealthLabels.Add(lblHealth1);
            HealthLabels.Add(lblHealth2);
            HealthLabels.Add(lblHealth3);
            HealthLabels.Add(lblHealth4);
            HealthLabels.Add(lblHealth5);
            HealthLabels.Add(lblHealth6);

            NameLabels.Add(lblName1);
            NameLabels.Add(lblName2);
            NameLabels.Add(lblName3);
            NameLabels.Add(lblName4);
            NameLabels.Add(lblName5);
            NameLabels.Add(lblName6);

            Sprites.Add(imgSprite1);
            Sprites.Add(imgSprite2);
            Sprites.Add(imgSprite3);
            Sprites.Add(imgSprite4);
            Sprites.Add(imgSprite5);
            Sprites.Add(imgSprite6);
           
        }
        private void LoadPokemon()
        {
           
            BitmapImage sprite = new BitmapImage(new Uri("Images/PokemonSprites.png", UriKind.Relative));
          
            int counter = 0;
            foreach (var item in Cards)
            {
                if (counter < Pokemonparty.Count)
                {

                    PokemonSpriteById targetPokemon = new PokemonSpriteById((int)Pokemonparty[counter].Pokemon.PokedexID);
                    item.Visibility = Visibility.Visible;
                    NameLabels[counter].Content = Pokemonparty[counter].ToString();
                    HealthLabels[counter].Content = Pokemonparty[counter].Pokemon.ReturnHP();
                    Sprites[counter].Source = new CroppedBitmap(sprite, targetPokemon.target);
                    counter++;
                }
              
            }
            if (Pokemonparty.Count == 6)
            {
                btnAdd.IsEnabled = false;
            }
          

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border thisBorder = sender as Border;
            PokemonGroup currentPokemon = new PokemonGroup();

            switch (thisBorder.Name)
            {
                case "Card1":
                    currentPokemon = Pokemonparty[0];
                    break;
                case "Card2":
                    currentPokemon = Pokemonparty[1];
                    break;
                case "Card3":
                    currentPokemon = Pokemonparty[2];
                    break;
                case "Card4":
                    currentPokemon = Pokemonparty[3];
                    break;
                case "Card5":
                    currentPokemon = Pokemonparty[4];
                    break;
                case "Card6":
                    currentPokemon = Pokemonparty[5];
                    break;
                default:
                    MessageBox.Show("???");
                    break;
            }
            PokemonInfo infoscreen = new PokemonInfo();
            infoscreen.pokemonstats = DatabaseOperations.SelectPokemonFromParty(currentPokemon);
            this.Visibility = Visibility.Hidden;
            this.Topmost = false;
            infoscreen.ShowDialog();
            this.Topmost = true;

            this.Visibility = Visibility.Visible;

        }

        private void Border_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
           
            Border thisBorder = sender as Border;
            PokemonGroup currentPokemon = new PokemonGroup();

            switch (thisBorder.Name)
            {
                case "Card1":
                    currentPokemon = Pokemonparty[0];
                    break;
                case "Card2":
                    currentPokemon = Pokemonparty[1];
                    break;
                case "Card3":
                    currentPokemon = Pokemonparty[2];
                    break;
                case "Card4":
                    currentPokemon = Pokemonparty[3];
                    break;
                case "Card5":
                    currentPokemon = Pokemonparty[4];
                    break;
                case "Card6":
                    currentPokemon = Pokemonparty[5];
                    break;
                default:
                    MessageBox.Show("???");
                    break;
            }

            PokemonPartyCRUD CRUDwindow = new PokemonPartyCRUD();
            CRUDwindow.btnChange.IsEnabled = true;
            CRUDwindow.btnDelete.IsEnabled = true;
            CRUDwindow.cmbPokemon.IsEnabled = false;
            CRUDwindow.cmbPosition.Items.Clear();
            for (int i = 0; i < Pokemonparty.Count(); i++)
            {
                CRUDwindow.cmbPosition.Items.Add(i +1);
            }
            
     
            CRUDwindow.CurrentPkmParty = currentPokemon;
            CRUDwindow.CurrentPkm = currentPokemon.Pokemon;
            CRUDwindow.cmbPosition.SelectedIndex = currentPokemon.Position - 1;
            CRUDwindow.cmbPokemon.SelectedIndex = (int)currentPokemon.Pokemon.PokedexID - 1;
            CRUDwindow.cmbAbility.SelectedIndex = (int)currentPokemon.Pokemon.AbilityID - 1;
            CRUDwindow.txtLvl.Text = currentPokemon.Pokemon.PokemonLevel.ToString();
            CRUDwindow.txtName.Text = currentPokemon.Pokemon.Nickname;
            CRUDwindow.cmbGender.SelectedIndex =  Convert.ToInt32(currentPokemon.Pokemon.Gender);
            CRUDwindow.currentTrainer = trainerParty;
            this.Topmost = false;
            CRUDwindow.ShowDialog();
            this.Topmost = true;
            Pokemonparty = DatabaseOperations.SelectParty(trainerParty.Id);
            LoadPokemon();
        }

      

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PokemonPartyCRUD CRUDwindow = new PokemonPartyCRUD();

            if (Pokemonparty.Max(x => x.Position) < 6)
            {
                CRUDwindow.btnAdd.IsEnabled = true;
                CRUDwindow.cmbPosition.SelectedIndex = Pokemonparty.Max(x => x.Position);
                CRUDwindow.cmbPosition.IsEnabled = false;

                CRUDwindow.currentTrainer = trainerParty;
                CRUDwindow.cmbPokemon.SelectedIndex = 0;
                CRUDwindow.txtName.Text = "Bulbasaur";
                CRUDwindow.txtLvl.Text = "5";
                this.Topmost = false;
                CRUDwindow.ShowDialog();
             this.Topmost = true;
                Pokemonparty = DatabaseOperations.SelectParty(trainerParty.Id);
                LoadPokemon();
            }
            else
            {
                MessageBox.Show("You already have 6 pokemon, remove one before adding more");
            }
           


           
           
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border thisBorder = sender as Border;
            thisBorder.BorderBrush = Brushes.Red;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border thisBorder = sender as Border;
            thisBorder.BorderBrush = Brushes.Gray;
        }
    }
}
