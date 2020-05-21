using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PokébagCRUD : Window
    {
        public Trainer trainerInventory;
        List<PokemonDAL.PlayerInventory> lstInventory;
        
        public PokébagCRUD()
        {
            InitializeComponent();
            OnLoad();
            
        }

        private void OnLoad()
        {
            
            lstInventory = DatabaseOperations.GetItems(2);
            lvInventory.ItemsSource = lstInventory;

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

            

        }
    }
}
