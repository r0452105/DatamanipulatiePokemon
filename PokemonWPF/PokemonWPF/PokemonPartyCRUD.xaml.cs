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
    /// Interaction logic for PokemonPartyCRUD.xaml
    /// </summary>
    public partial class PokemonPartyCRUD : Window
    {
        public Trainer currentTrainer;
       public Pokemon CurrentPkm;
        public List<Pokedex> pokedexList ;
        public PokemonPartyCRUD()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string error = Validate();
            if (! string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
            }
           
        }

        private string Validate()
        {
            string errormsg = "";
            if (! int.TryParse(txtLvl.Text, out int fieldvalue))
            {
                errormsg += "Level moet numeriek zijn";
                if (fieldvalue < 1 || fieldvalue > 100)
                {
                    errormsg += "Level moet tussen 1 en 100 liggen";
                }
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errormsg += "Nickname mag niet leeg zijn";
            }
          

            return errormsg;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pokedexList = DatabaseOperations.PokedexEntry();
            cmbPokemon.ItemsSource = pokedexList;
            cmbPokemon.SelectionChanged += new SelectionChangedEventHandler(cmbPokemon_SelectionChanged);
        }

        private void cmbPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
                txtName.Text = pokedexList[cmbPokemon.SelectedIndex].PokemonName;
            
        
        }
    }
}
