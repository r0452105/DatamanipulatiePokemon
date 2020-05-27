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

        private void SortListView(string sortingindicator, System.ComponentModel.ListSortDirection direction)//sortingindicator = op welk veld we gaan sorten en directen = asc of desc
        {

            
            

            CollectionView view = (CollectionView) CollectionViewSource.GetDefaultView(lvInventory.ItemsSource); //c# klasse om sorteringen en andere bewerkingen te doen 
            view.SortDescriptions.Clear(); //mogelijk maken om opnieuw te sorteren

            if (sortingindicator != string.Empty)
            {
                view.SortDescriptions.Add(new SortDescription(sortingindicator, direction));
                view.Refresh();
            }
        }

        private void onLoad()
        {//bij laden -->categoriebox vullen met data
            List<Items> lstItems = DatabaseOperations.GetDistinctCategory(); //categories verkrijgen
            List<string> data = lstItems.Select(x => x.Catagory).Distinct().ToList();//dubbels van categories eruit halen en in lijst steken
            fillCategoryListBox(data);

            //listview vullen zodat alle items erin staan bij het laden van het screen
            lstInventory = DatabaseOperations.GetItems(2);
            lvInventory.ItemsSource = lstInventory;
        }

        private void fillCategoryListBox(List<string> Data)//lijst van data binnengekregen
        {//listbox categorie vullen 
            foreach (string item in Data)//voor elk item in de lijst geld de opmaak
            {

                ListBoxItem lbItem = new ListBoxItem();

                TextBlock textBlock = new TextBlock
                {
                    //opmaak items category
                    Text = item,
                    FontSize = 16,
                    Foreground = Brushes.DarkRed,
                    Margin = new Thickness(5, 5, 5, 5),
                    FontWeight = FontWeights.Bold,
                    Padding = new Thickness(5, 5, 5, 5)
                };
                //items toevoegen aan listbox
                lbItem.Content = textBlock;
                lbItem.Tag = item;
                lbCategory.Items.Add(lbItem);
            }

            lbCategory.SelectionChanged += LbCategory_SelectionChanged;
            lbCategory.SelectedIndex = -1;
            lbCategory.SelectionMode = SelectionMode.Single;
        }

        private void LbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//sorteren op de aangeduide categorie
            ListBoxItem listItem = (ListBoxItem)e.AddedItems[0];
            string SelectedItem = listItem.Tag.ToString();//selected item = categorie die geselecteerd is
            lstInventory = DatabaseOperations.SelectAllInventory(SelectedItem);//weergeven in de lvinventory : inventory (items) van het selected item
            lvInventory.ItemsSource = lstInventory;
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            //inventory sorteren 
            lvInventory.ItemsSource = lstInventory;
            if (radioasc.IsChecked == true)//ascending
            {
                ComboBoxItem cItem = cbSortBy.SelectedItem as ComboBoxItem;//sorteren op de aangeduide waarde in de combobox
                SortListView(cItem.Uid.ToString(), ListSortDirection.Ascending);
            }
            else if (radiodesc.IsChecked == true)//descending
            {
                ComboBoxItem cItem = cbSortBy.SelectedItem as ComboBoxItem;
                SortListView(cItem.Uid.ToString(), ListSortDirection.Descending);
            }
        }

        private void BtnCRUD_Click(object sender, RoutedEventArgs e)
        {
            PokébagCRUD objPokébagCRUD = new PokébagCRUD();
            Visibility = Visibility.Hidden;

            objPokébagCRUD.trainerToAddTo = trainerInventory;//waarden van trainer doorgeven

            objPokébagCRUD.ShowDialog();

            lstInventory = DatabaseOperations.GetItems(2);
            lvInventory.ItemsSource = lstInventory;
            lvInventory.Items.Refresh();

        }




    }
}
