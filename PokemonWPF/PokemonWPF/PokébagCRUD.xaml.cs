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
            
            lstInventory = DatabaseOperations.GetItems(2);
            lvInventory.ItemsSource = lstInventory;

            itemList = DatabaseOperations.ItemList();
            lvItems.ItemsSource = itemList;
            lvItems.SelectedIndex = 0;


            categorylist = DatabaseOperations.GetDistinctCategory();
            
            //cbChooseCategory.Items.Add(categorylist);
            cbChooseCategory.ItemsSource = categorylist.Select(x=>x.Catagory).Distinct(); 
            //cbChooseCategory.DisplayMemberPath = "Catagory";


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
            if ( (string.IsNullOrWhiteSpace(txtQuantity.Text)) || (string.IsNullOrWhiteSpace(txtItemName.Text)))
            {
                errormsg += "veld mag niet leeg zijn";
                
            }
           


            return errormsg;

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            PlayerInventory playerInventory = (PlayerInventory)lvInventory.SelectedItem;

            int quantity = int.Parse(txtQuantity.Text);
            playerInventory.Quantity = quantity;

            if (DatabaseOperations.UpdatePlayerInventory(playerInventory) != 0)
            {
                MessageBox.Show($"{playerInventory.id} succesfully added to the itemlist of {lvInventory.Items}");
                Close();
            }
            else
            {
                MessageBox.Show("Addition failed");
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
                Items item = new Items();
                item.Id = DatabaseOperations.CurrentItems() +1;
                item.ItemName = txtItemName.Text;
                //van het geselecteerde item pak je de categorie
               // Items selectedItem = (Items)lvItems.SelectedItem;

                item.Catagory = cbChooseCategory.SelectedItem.ToString();
                //Items itemType = (Items)lvItems.SelectedItem;

                //Create a new player inventory
                PlayerInventory playerInventory = new PlayerInventory();
                //Take quantity from textbox
                int quantity = int.Parse(txtQuantity.Text);
                playerInventory.Quantity = quantity;
                playerInventory.ItemID = item.Id;

                playerInventory.PlayerId = trainerToAddTo.Id;
                  
                playerInventory.id = DatabaseOperations.CurrentPlayerItems() + 1;

              

                if (DatabaseOperations.AddItem(item) != 0)
                {
                    MessageBox.Show($"{item} succesfully added to the itemlist of {lvInventory.Items}");
                    Close();
                }
                else
                {
                    MessageBox.Show("Addition failed");
                }



                if (DatabaseOperations.AddPlayerinvtoryItem(playerInventory) !=0)
                {
                    MessageBox.Show($"{playerInventory.Quantity} succesfully added to the itemlist of {lvInventory.Items}");
                    Close();
                }
                else
                {
                    MessageBox.Show("Addition failed");
                }

                lvInventory.Items.Refresh();
                
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void combobox_changed(object sender, SelectionChangedEventArgs e)
        {
            cbChooseCategory.DataContext = categorylist;
        }
    }
}
