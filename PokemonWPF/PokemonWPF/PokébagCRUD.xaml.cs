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
        public List<PlayerInventory> itemList;
        

        

        
        public PokébagCRUD()
        {
            InitializeComponent();
            OnLoad();
            
        }

        private void OnLoad()
        {
            
            lstInventory = DatabaseOperations.GetItems(2);
            lvInventory.ItemsSource = lstInventory;

            itemList = DatabaseOperations.GetItems(2);
            lvItems.ItemsSource = itemList;

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
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                errormsg += "Quantity mag niet leeg zijn";
                
            }
           


            return errormsg;

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            

            string error = Validate();
            if (!string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
            }
            else
            {
                PlayerInventory item = new PlayerInventory();
                int quantity = int.Parse(txtQuantity.Text);
                item.Quantity = quantity;


                Items itemType = (Items)lvItems.SelectedItem;
                item.ItemID = itemType.Id;

                item.PlayerId = trainerToAddTo.Id;
                    


                item.id = DatabaseOperations.CurrentPlayerItems() + 1;

                if (DatabaseOperations.AddItem(item) !=0)
                {
                    MessageBox.Show($"{item.Quantity} succesfully added to the itemlist of {lvInventory.Items}");
                    Close();
                }
                else
                {
                    MessageBox.Show("Addition failed");
                }
                
                
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
