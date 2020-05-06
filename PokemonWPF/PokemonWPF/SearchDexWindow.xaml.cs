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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SearchDexWindow : Window
    {

        public Types poketype = new Types();
        List<Types> poketypeentries = DatabaseOperations.Typinglist();
        public PokédexWindow DexWindowToAlter;
        public SearchDexWindow()
        {
            InitializeComponent();
            foreach (Types poketype in poketypeentries)
            {
                cbType.Items.Add(poketype.TypeName);
            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            DexWindowToAlter.Visibility = Visibility.Visible;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnStartSorting_Click(object sender, RoutedEventArgs e)
        {
            switch (cbSortBy.SelectedItem)
            {
                case 0:
                    // eerst volgorde van de pokemons aanpassen, dan terugleiden naar pokedexscherm
                    break;
                case 1:
                    
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                default:
                    MessageBox.Show("Je moet een sorteervorm selecteren.");
                    break;
            }
        }
    }
}
