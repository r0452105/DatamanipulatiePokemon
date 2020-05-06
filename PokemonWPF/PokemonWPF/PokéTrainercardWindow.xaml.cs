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

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for PokéTrainercardWindow.xaml
    /// </summary>
    public partial class PokéTrainercardWindow : Window
    {
        public MainWindow WindowToAlter;
        public PokéTrainercardWindow()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            WindowToAlter.Visibility = Visibility.Visible;
        }
    }
}
