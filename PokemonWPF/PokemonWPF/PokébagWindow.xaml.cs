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
    /// Interaction logic for PokébagWindow.xaml
    /// </summary>
    public partial class PokébagWindow : Window
    {
        public Trainer trainerInventory;
        List<PokemonDAL.PlayerInventory> lstInventory;



        public PokébagWindow()
        {
            InitializeComponent();
            onLoad();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SortListView(string sortingindicator, System.ComponentModel.ListSortDirection direction)
        {
            
            //sortingindicator meegegeven en direction (ascending of descending)

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvInventory.ItemsSource); //collectionview genaamd view aangemaakt om de data van de lvinventory in te steken
            view.SortDescriptions.Clear(); //mogelijk maken om opnieuw te sorteren

            if (sortingindicator != String.Empty)
            {
                view.SortDescriptions.Add(new SortDescription(sortingindicator, direction));
                view.Refresh(); 
            }
        }

        private void onLoad()
        {//bij laden -->categoriebox vullen met data
            List<Items> lstItems = DatabaseOperations.GetDistinctCategory(); //items sorteren per categorie
            List<string> data = lstItems.Select(x => x.Catagory).Distinct().ToList();
            fillCategoryListBox(data);
        }

        private void fillCategoryListBox(List<string> Data)
        {//listbox categorie vullen 
            foreach (string item in Data)
            {
                ListBoxItem lbItem = new ListBoxItem();

                TextBlock textBlock = new TextBlock();
                textBlock.Text = item;
                textBlock.FontSize = 16;
                textBlock.Foreground = Brushes.DarkRed;
                textBlock.Margin = new Thickness(5, 5, 5, 5);
                textBlock.FontWeight = FontWeights.Bold;
                textBlock.Padding = new Thickness(5, 5, 5, 5);

                lbItem.Content = textBlock;
                lbItem.Tag = item;
                lbCategory.Items.Add(lbItem);
            }

            lbCategory.SelectionChanged += LbCategory_SelectionChanged;
            lbCategory.SelectedIndex = -1;
            lbCategory.SelectionMode = SelectionMode.Single;
        }

        private void LbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//listview vullen
            ListBoxItem listItem = (ListBoxItem)e.AddedItems[0];
            string SelectedItem = listItem.Tag.ToString();
            lstInventory = DatabaseOperations.SelectAllInventory(SelectedItem);
            lvInventory.ItemsSource = lstInventory;
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            lvInventory.ItemsSource = lstInventory;
            if (radioasc.IsChecked == true)
            {
                ComboBoxItem cItem = cbSortBy.SelectedItem as ComboBoxItem;
                SortListView(cItem.Uid.ToString(), ListSortDirection.Ascending);
            }
            else if (radiodesc.IsChecked == true)
            {
                ComboBoxItem cItem = cbSortBy.SelectedItem as ComboBoxItem;
                SortListView(cItem.Uid.ToString(), ListSortDirection.Descending);
            }
        }







    }
}
