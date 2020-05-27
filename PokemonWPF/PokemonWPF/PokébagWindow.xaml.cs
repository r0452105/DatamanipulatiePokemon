using PokemonDAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for PokébagWindow.xaml
    /// </summary>
    public partial class PokébagWindow : Window
    {
        public Trainer trainerInventory;
        private List<PokemonDAL.PlayerInventory> lstInventory;
        private  PokébagCRUD CRUDwindow = new PokébagCRUD();
        public Trainer trainerToAddTo;




        public PokébagWindow()
        {
            InitializeComponent();
            onLoad();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SortListView(string sortingindicator, System.ComponentModel.ListSortDirection direction)
        {

            //sortingindicator meegegeven en direction (ascending of descending)

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvInventory.ItemsSource); //collectionview genaamd view aangemaakt om de data van de lvinventory in te steken
            view.SortDescriptions.Clear(); //mogelijk maken om opnieuw te sorteren

            if (sortingindicator != string.Empty)
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

            //listview vullen zodat alle items erin staan bij het laden van het screen
            lstInventory = DatabaseOperations.GetItems(2);
            lvInventory.ItemsSource = lstInventory;
        }

        private void fillCategoryListBox(List<string> Data)
        {//listbox categorie vullen 
            foreach (string item in Data)
            {
                ListBoxItem lbItem = new ListBoxItem();

                TextBlock textBlock = new TextBlock
                {
                    Text = item,
                    FontSize = 16,
                    Foreground = Brushes.DarkRed,
                    Margin = new Thickness(5, 5, 5, 5),
                    FontWeight = FontWeights.Bold,
                    Padding = new Thickness(5, 5, 5, 5)
                };

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

        private void BtnCRUD_Click(object sender, RoutedEventArgs e)
        {
            PokébagCRUD objPokébagCRUD = new PokébagCRUD();
            Visibility = Visibility.Hidden;

            objPokébagCRUD.trainerToAddTo = trainerInventory;

            objPokébagCRUD.ShowDialog();

            lstInventory = DatabaseOperations.GetItems(2);
            lvInventory.ItemsSource = lstInventory;
            lvInventory.Items.Refresh();

        }




    }
}
