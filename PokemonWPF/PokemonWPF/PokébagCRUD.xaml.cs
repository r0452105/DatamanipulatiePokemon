using PokemonDAL;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PokébagCRUD : Window
    {
        public Trainer trainerInventory;
        private List<PokemonDAL.PlayerInventory> lstInventory;
        public Trainer trainerToAddTo;
        public List<Items> itemList;
        public List<Items> categorylist;


        public string cbCategory;


        public PokébagCRUD()
        {
            InitializeComponent();
            OnLoad();

        }

        private void OnLoad()
        {
            //lstinventory vullen 
            lstInventory = DatabaseOperations.GetItems(2);
            lvInventory.ItemsSource = lstInventory;

            //lvitems vullen
            itemList = DatabaseOperations.ItemList();
            lvItems.ItemsSource = itemList;
            lvItems.SelectedIndex = 0;

            //categories krijgen en deze in categorylist steken
            categorylist = DatabaseOperations.GetDistinctCategory();
            //categories in de combobox steken zonder dubbels
            cbChooseCategory.ItemsSource = categorylist.Select(x => x.Catagory).Distinct();

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (DatabaseOperations.RemoveItemFromList(lstInventory[lvInventory.SelectedIndex]) != 0)
            {
                MessageBox.Show("deletion successful");
                OnLoad();
                Close();
            }
            else
            {
                MessageBox.Show("Deletion failed");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private string Validate()
        {
            string errormsg = "";
            if ((string.IsNullOrWhiteSpace(txtQuantity.Text)) || (string.IsNullOrWhiteSpace(txtItemName.Text)))
            {
                errormsg += "velden quantity en itemname mogen niet leeg zijn";

            }

            return errormsg;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //update is enkel om de quantity van het item aan te passen, dus de velden itemname en category mogen niet ingevuld zijn
            if ((cbChooseCategory.SelectedItem == null) && (string.IsNullOrEmpty(txtItemName.Text)))
            {

                //obj playerinventory is het geselecteerde item in de lvinventory 
                PlayerInventory playerInventory = (PlayerInventory)lvInventory.SelectedItem;

                //quantity nemen van de textbox quantity en deze in obj quantity steken
                int quantity = int.Parse(txtQuantity.Text);
                playerInventory.Quantity = quantity;


                if (DatabaseOperations.UpdatePlayerInventory(playerInventory) != 0)
                {
                    MessageBox.Show($" The quantity of the item has been succesfully updated to {playerInventory.Quantity}.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Addition failed");
                }

            }

            else
            {
                MessageBox.Show("velden ItemName en Category moeten leeg zijn");
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {


            string error = Validate();
            if (!string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
            }
            else
            {   //Create new item
                Items item = new Items
                {
                    //nieuwe id geven aan het nieuwe item
                    Id = DatabaseOperations.CurrentItems() + 1,
                    ItemName = txtItemName.Text,
                    //van het geselecteerde item pak je de categorie die aangeduid is in de combobox
                    Catagory = cbChooseCategory.SelectedItem.ToString()
                };
                //doen voor items en playerinvtory want items is een collectie die in playerinventory zit dus we moeten het aangemaakte item daarna ook nog in playerinventory zetten
                //Create a new player inventory
                PlayerInventory playerInventory = new PlayerInventory();
                //quantity nemen van textbox
                int quantity = int.Parse(txtQuantity.Text);
                playerInventory.Quantity = quantity;
                playerInventory.ItemID = item.Id;
                playerInventory.PlayerId = trainerToAddTo.Id;
                playerInventory.id = DatabaseOperations.CurrentPlayerItems() + 1;

                if (DatabaseOperations.AddItem(item) != 0)//validatie als de addition failt en dus 0 geeft --> zie else
                {
                    MessageBox.Show($"{item} is succesfully added to the itemlist.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Addition failed");
                }

                if (DatabaseOperations.AddPlayerinvtoryItem(playerInventory) != 0)
                {
                    MessageBox.Show($"{item} is succesfully added to the playerinventory.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Addition failed");
                }

                lvInventory.Items.Refresh();//refreshen om te zien of het item bij in de lijst is gekomen

            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void combobox_changed(object sender, SelectionChangedEventArgs e)
        {
            //wanneer de waarde in de combobox veranderd 
            cbChooseCategory.DataContext = categorylist;
        }
    }
}
