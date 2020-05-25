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
    public partial class PokedexCRUDWindow : Window
    {
        public PokédexWindow DexWindowToAlter;
        List<Pokedex> pokedexentries = DatabaseOperations.PokedexEntry();
        Pokedex pokedexEntry = new Pokedex();
        List<Types> types = DatabaseOperations.Typinglist();
        Types type = new Types();

        public PokedexCRUDWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datagridPokedexEntries.ItemsSource = pokedexentries;
            cmbType1.ItemsSource = types;
            cmbType2.ItemsSource= types;
        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            DexWindowToAlter.lvPokedex.ItemsSource = DatabaseOperations.PokedexEntry();
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            List<int> Idlist = new List<int>();

            foreach (Pokedex pokedexEntry in pokedexentries)
            {
                Idlist.Add(pokedexEntry.Id);
            }
            pokedexEntry.Id = 1;
            while (Idlist.Contains(pokedexEntry.Id))
            {
                pokedexEntry.Id += 1;
            }
            pokedexEntry.PokemonName = txtNaam.Text;
            pokedexEntry.Type1 = cmbType1.SelectedIndex+1;
            pokedexEntry.Type2 = cmbType2.SelectedIndex+1;//remember index must be same as the real id's of the types

            pokedexEntry.PokemonDescription = "Nothing";
            pokedexEntry.PokemonWeight = 50.0M;
            pokedexEntry.ExpMax = 160;
            pokedexEntry.EvolveItems = null;
            pokedexEntry.CaptureRate = 45;
            pokedexEntry.EvolveThreshold = null;

            DatabaseOperations.AddPokedexEntry(pokedexEntry);
            datagridPokedexEntries.ItemsSource = DatabaseOperations.PokedexEntry();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            pokedexEntry = datagridPokedexEntries.SelectedItem as Pokedex;
            string verwijdernaam=pokedexEntry.PokemonName;
            DatabaseOperations.DeletePokedexEntry(pokedexEntry);

            datagridPokedexEntries.ItemsSource = DatabaseOperations.PokedexEntry();
            MessageBox.Show(verwijdernaam + " is verwijderd.");
        }
        private void BtnReplace_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            int index=datagridPokedexEntries.SelectedIndex;
            pokedexEntry = datagridPokedexEntries.SelectedItem as Pokedex;
            pokedexEntry.PokemonName = txtNaam.Text;
            
            
            pokedexEntry.Types = null;
            pokedexEntry.Types1 = null;
            pokedexEntry.Type1=cmbType1.SelectedIndex+1;
            pokedexEntry.Type2 = cmbType2.SelectedIndex + 1;
            int ok = DatabaseOperations.UpdatePokedexEntry(pokedexEntry);
            if (ok > 0)
            {
                datagridPokedexEntries.ItemsSource = DatabaseOperations.PokedexEntry();
            }
            else
            {
                MessageBox.Show("Pokemon is niet aangepast");
            }
            datagridPokedexEntries.SelectedIndex = index;
        }
        private void DatagridPokedexEntries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(datagridPokedexEntries.SelectedItem is Pokedex pokedexEntry)
            {

                cmbType1.SelectedIndex = pokedexEntry.Type1.GetValueOrDefault()-1;
                cmbType2.SelectedIndex = pokedexEntry.Type2.GetValueOrDefault()-1;
               txtNaam.Text = pokedexEntry.PokemonName;
           }
        }
        
    }
}
