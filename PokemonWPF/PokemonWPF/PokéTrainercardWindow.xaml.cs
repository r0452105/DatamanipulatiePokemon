using PokemonDAL;
using System.Windows;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for PokéTrainercardWindow.xaml
    /// </summary>
    public partial class PokéTrainercardWindow : Window
    {
        public Trainer trainerCard;



        public PokéTrainercardWindow()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            //labels vullen met de data van de trainer
            lblname.Content = trainerCard.TrainerName;
            lblid.Content = trainerCard.Id;
            lblmoney.Content = trainerCard.MoneyOwned;
            lblpokedox.Content = trainerCard.PokemonOwned;
            lblplaytime.Content = trainerCard.TimePlayed.Hours + " Hr(s)  " + trainerCard.TimePlayed.Minutes + " Min(s)  " + trainerCard.TimePlayed.Seconds + " Sec(s)  ";

        }


        private void BtnBadges_Click(object sender, RoutedEventArgs e)
        {
            //linken aan badges window
            PokéBadgesWindow objPokéBadgesWindow = new PokéBadgesWindow();
            Visibility = Visibility.Hidden;
            objPokéBadgesWindow.Show();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
