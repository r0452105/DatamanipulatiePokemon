using PokemonDAL;
using PokemonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for PokemonParty.xaml
    /// </summary>
    public partial class PokemonParty : Window
    {
        private readonly List<Label> NameLabels = new List<Label>();
        private readonly List<Label> HealthLabels = new List<Label>();
        private readonly List<Border> Cards = new List<Border>();
        private readonly List<Image> Sprites = new List<Image>();
        public Trainer trainerParty;
        private List<PokemonGroup> Pokemonparty = new List<PokemonGroup>();
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

        private void OrderElements()
        {

            //Laad de elementen van de party cards in arrays zodat ze met een index teller gezaamlijk en sequentieel aangesproken kunnen worden
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
            foreach (Border item in Cards)
            {
                if (counter < Pokemonparty.Count)
                {
                    //Voor elk item in pokemonparty, verhul één kaart en vul de relevante gegevens in
                    PokemonSpriteById targetPokemon = new PokemonSpriteById((int)Pokemonparty[counter].Pokemon.PokedexID);
                    item.Visibility = Visibility.Visible;
                    NameLabels[counter].Content = Pokemonparty[counter].ToString();
                    HealthLabels[counter].Content = Pokemonparty[counter].Pokemon.ReturnHP();
                    //Neem een vierkant met de gespecificieerde coordinated uit de spritesheet en laad het naar het Image element
                    Sprites[counter].Source = new CroppedBitmap(sprite, targetPokemon.target);
                    counter++; //Handmatig de index optellen aangezien dit niet is ondersteunt in foreach
                }

            }
            if (Pokemonparty.Count >= 6)
            {
                //Pokemon mogen enkel toegevoegd worden als de party niet vol is
                btnAdd.IsEnabled = false;
            }


        }

        //Verander de randkleur van de kaarten waar de muis over gaat
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

            //In geval dat er links word geklikt, word het infoscherm van de geklikte pokemon geopend
            PokemonInfo infoscreen = new PokemonInfo
            {
                pokemonstats = DatabaseOperations.SelectPokemonFromParty(currentPokemon)
            };
            Visibility = Visibility.Hidden;
            //Topmost forceerd een hogere z-index zodat mainwindow zich niet bovenop dit scherm plaatst wanneer info gesloten is
            Topmost = false;
            infoscreen.ShowDialog();
            Topmost = true;

            Visibility = Visibility.Visible;

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
            //In geval je een rechterklik voor een pokemon doet, word deze pokemon naar de CRUD geladen voor delete en update operaties
            PokemonPartyCRUD CRUDwindow = new PokemonPartyCRUD();
            CRUDwindow.btnChange.IsEnabled = true;
            CRUDwindow.btnDelete.IsEnabled = true;
            CRUDwindow.cmbPokemon.IsEnabled = false;
            CRUDwindow.cmbPosition.Items.Clear();
            for (int i = 0; i < Pokemonparty.Count(); i++)
            {
                //Zorg dat alle momentele posities ingeladen worden, zodat je enkel kan wisselen met een bestaande pokemon
                CRUDwindow.cmbPosition.Items.Add(i + 1);
            }

            //Instellen van gegevens
            CRUDwindow.CurrentPkmParty = currentPokemon;
            CRUDwindow.CurrentPkm = currentPokemon.Pokemon;
            CRUDwindow.cmbPosition.SelectedIndex = currentPokemon.Position - 1;
            CRUDwindow.cmbPokemon.SelectedIndex = (int)currentPokemon.Pokemon.PokedexID - 1;
            CRUDwindow.cmbAbility.SelectedIndex = (int)currentPokemon.Pokemon.AbilityID - 1;
            CRUDwindow.txtLvl.Text = currentPokemon.Pokemon.PokemonLevel.ToString();
            CRUDwindow.txtName.Text = currentPokemon.Pokemon.Nickname;
            CRUDwindow.cmbGender.SelectedIndex = Convert.ToInt32(currentPokemon.Pokemon.Gender);
            CRUDwindow.currentTrainer = trainerParty;
            Topmost = false;
            CRUDwindow.ShowDialog();
            Topmost = true;

            //Hernieuw de lijst zodat de veranderingen gereflecteerd zijn in deze pagina
            Pokemonparty.Clear();
            foreach (Border card in Cards)
            {
                card.Visibility = Visibility.Collapsed;
            }
            Pokemonparty = DatabaseOperations.SelectParty(trainerParty.Id);
            LoadPokemon();
        }



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PokemonPartyCRUD CRUDwindow = new PokemonPartyCRUD();
            //als er op Add word gedrukt, word het Crud scherm met enkel Add functionaliteit geopened
            if (Pokemonparty.Max(x => x.Position) < 6)
            {
                CRUDwindow.btnAdd.IsEnabled = true;
                CRUDwindow.cmbPosition.SelectedIndex = Pokemonparty.Max(x => x.Position);
                CRUDwindow.cmbPosition.IsEnabled = false;

                CRUDwindow.currentTrainer = trainerParty;
                CRUDwindow.cmbPokemon.SelectedIndex = 0;
                CRUDwindow.txtName.Text = "Bulbasaur";
                CRUDwindow.txtLvl.Text = "5";
                Topmost = false;
                CRUDwindow.ShowDialog();
                Topmost = true;
                Pokemonparty = DatabaseOperations.SelectParty(trainerParty.Id);
                LoadPokemon();
            }
            else
            {
                MessageBox.Show("You already have 6 pokemon, remove one before adding more");
            }





        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
