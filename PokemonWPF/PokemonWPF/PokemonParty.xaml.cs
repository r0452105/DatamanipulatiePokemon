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
            Pokemonparty = DatabaseOperations.SelectParty(2);
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
        }
        private void LoadPokemon()
        {
            int counter = 0;
            foreach (var item in Cards)
            {
                if (counter < Pokemonparty.Count)
                {
                    item.Visibility = Visibility.Visible;
                    NameLabels[counter].Content = Pokemonparty[counter].ToString();
                    HealthLabels[counter].Content = Pokemonparty[counter].Pokemon.ReturnHP();
                    counter++;
                }
              
            }
          

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border thisBorder =  sender as Border;
            PokemonGroup currentPokemon = new PokemonGroup();

            switch (thisBorder.Name)
            {
                case "Card1": currentPokemon = Pokemonparty[0];
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
                default: MessageBox.Show("???");
                    break;
            }
            PokemonInfo infoscreen = new PokemonInfo();
            infoscreen.pokemonstats = DatabaseOperations.SelectPokemonFromParty(currentPokemon);
            this.Visibility = Visibility.Hidden;
            infoscreen.ShowDialog();
           
            this.Visibility = Visibility.Visible;
           

        }

        
    }
}
