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
    /// Interaction logic for PokéTrainercardWindow.xaml
    /// </summary>
    public partial class PokéTrainercardWindow : Window
    {
        public Trainer trainerCard;
        public PokéTrainercardWindow()
        {
            InitializeComponent();
        }

 

        private void BtnBadges_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
