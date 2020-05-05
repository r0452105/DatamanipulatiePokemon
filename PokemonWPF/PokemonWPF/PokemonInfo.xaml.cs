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


      

        
      

      

        private void btnYellow_Click(object sender, RoutedEventArgs e)
        {
    
            
                Button buttonColor = sender as Button;
                CardInfo.Background = buttonColor.Background;
           
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
          
                    Button buttonColor = sender as Button;
                    CardInfo.Background = buttonColor.Background;
             
        }

        private void btnPink_Click(object sender, RoutedEventArgs e)
        {
            Button buttonColor = sender as Button;
            CardInfo.Background = buttonColor.Background;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
