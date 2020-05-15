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
           
            lblname.Content = trainerCard.TrainerName;
            lblid.Content = trainerCard.Id; 
            lblmoney.Content = trainerCard.MoneyOwned;
            lblpokedox.Content = trainerCard.PokemonOwned; 
            lblplaytime.Content = trainerCard.TimePlayed.Hours + " Hr(s)  " + trainerCard.TimePlayed.Minutes + " Min(s)  " + trainerCard.TimePlayed.Seconds + " Sec(s)  ";
            
        }


        private void BtnBadges_Click(object sender, RoutedEventArgs e)
        {
            PokéBadgesWindow objPokéBadgesWindow = new PokéBadgesWindow();
            this.Visibility = Visibility.Hidden;
            objPokéBadgesWindow.Show();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
