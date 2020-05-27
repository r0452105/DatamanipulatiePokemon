using PokemonDAL;
using PokemonModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> menuElements = new List<string>();
        public Trainer trainer = DatabaseOperations.SelectTrainer(2);


        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         //Inladen van menu elementen.
            menuElements.Add("Pokedex");
            menuElements.Add("Party");
            menuElements.Add("Inventory");
            menuElements.Add(trainer.TrainerName);
            menuElements.Add("Exit");

            lbMenu.ItemsSource = menuElements;


        }

        private void lbMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //Het infolabel aanpassen op basis van de geselecteerde text
            switch (lbMenu.SelectedIndex)
            {
                case 0:
                    txbInfo.Text = "A encyclopedia of all seen pokemon";
                    break;

                case 1:
                    txbInfo.Text = "Access your party screen";
                    break;
                case 2:
                    txbInfo.Text = $"Show inventory of {trainer.TrainerName}";
                    break;
                case 3:
                    txbInfo.Text = $"Show the trainercard of {trainer.TrainerName}";
                    break;

                    //Exit is default zodat case getallen niet aangepast moeten worden in geval van meer menu elementen
                default:
                    txbInfo.Text = "Close the program";
                    break;
            }
        }

        private void lbMenu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Wanneer er dubbel geklikt word, word het van het aangeduide item het scherm geopend
            switch (lbMenu.SelectedIndex)
            {
                case 0:

                    PokédexWindow pokédexWindow1 = new PokédexWindow
                    {
                        //De trainer variabelen word doorgegeven (zodat we maar in één scherm trainer moeten aanpassen om het hele programma aan te passen)

                        trainerToSelect = trainer
                    };
                    //Verhult dit scherm tot dat het dialoog voorbij is. Werkt niet correct vanwege problemen met geneste dialogen
                    Visibility = Visibility.Hidden;
                    pokédexWindow1.ShowDialog();
                    Visibility = Visibility.Visible;
                    break;
                case 1:

                    PokemonParty partyscreen = new PokemonParty
                    {
                        trainerParty = trainer
                    };
                    Visibility = Visibility.Hidden;
                    partyscreen.ShowDialog();
                    Visibility = Visibility.Visible;
                    break;
                case 2:
                    PokébagWindow inventoryscreen = new PokébagWindow
                    {
                        trainerInventory = trainer
                    };

                    Visibility = Visibility.Hidden;
                    inventoryscreen.ShowDialog();
                    Visibility = Visibility.Visible;
                    break;
                case 3:
                    PokéTrainercardWindow trainerscreen = new PokéTrainercardWindow
                    {
                        trainerCard = trainer
                    };
                    Visibility = Visibility.Hidden;
                    trainerscreen.ShowDialog();
                    Visibility = Visibility.Visible;
                    break;
                //Exit is default zodat case getallen niet aangepast moeten worden in geval van meer menu elementen
                default:
                    Close();

                    break;
            }
        }


    }
}
