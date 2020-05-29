using PokemonDAL;
using System.Collections.Generic;
using System.Windows;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SearchDexWindow : Window
    {
        public Types poketype = new Types();
        private  List<Types> poketypeentries = DatabaseOperations.Typinglist();
        public PokédexWindow DexWindowToAlter;
        public Pokedex pokedex = new Pokedex();
        private  List<Pokedex> pokeEntries = DatabaseOperations.PokedexEntry();
        private  List<Pokedex> pokeEntriesAZ = DatabaseOperations.PokedexEntryAZ();

        public SearchDexWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbType.Items.Add(" ");
            foreach (Types poketype in poketypeentries) //lijst maken om handmatig types te illustreren in cb
            {
                cbType.Items.Add(poketype.TypeName);
            }
            cbSortBy.Items.Add("Alfabetisch");
            cbSortBy.Items.Add("National Dex");
            cbType.SelectedIndex = 0; //geen keuze ingesteld nog niet
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
            DexWindowToAlter.Topmost = true; //zodat menu op achtergrond blijft
        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<Pokedex> pokeEntriesTemporary = new List<Pokedex>(); //tijdelijke pokedex aanmaken met enkel de specifiek gekozen pokemon
            foreach (Pokedex pokedex in pokeEntries)
            {
                if (pokedex.PokemonName.ToLower().Contains(tbName.Text.ToLower()))
                {
                    string type1 = "";
                    string type2 = "";

                    foreach (Types poketype in poketypeentries) //kijken of type(s) overeenkomen
                    {
                        if (poketype.Id == pokedex.Type1)
                        {
                            type1 = poketype.TypeName;
                        }
                        else if (poketype.Id == pokedex.Type2)
                        {
                            type2 = poketype.TypeName;
                        }
                    }
                    if (cbType.SelectedIndex == 0) // indien geen specifiek type gekozen, geen extra restricties op toevoegen pokedex entry
                    {
                        pokeEntriesTemporary.Add(pokedex);
                    }
                    else if (type1 == cbType.SelectedItem.ToString() || type2 == cbType.SelectedItem.ToString())//indien wel, wel restricties namelijk types
                    {
                        pokeEntriesTemporary.Add(pokedex);
                    }
                }
            }
            DexWindowToAlter.gvBinder.DisplayMemberBinding = null; //ledigen van gvBinder voor terug aanvullen, voorkomt veel errors
            DexWindowToAlter.lvPokedex.ItemsSource = pokeEntriesTemporary;
            if (DexWindowToAlter.lvPokedex.Items.Count < 1)//indien er geen items zijn, geeft "none" als item weer
            {
                List<string> noitems = new List<string>{"none"};
                DexWindowToAlter.lvPokedex.ItemsSource = noitems;
            }
            DexWindowToAlter.Show();
            DexWindowToAlter.Topmost = true;
            DexWindowToAlter.lvPokedex.SelectedIndex = 0;
            Close();
        }

        private void BtnStartSorting_Click(object sender, RoutedEventArgs e)
        {
            List<Pokedex> pokeEntriesTemporary = new List<Pokedex>();
            switch (cbSortBy.SelectedIndex)
            {
                case 0:
                    foreach (Pokedex pokedex in pokeEntriesAZ) //gewoon toevoegen maar dan alfabetisch
                    {
                    pokeEntriesTemporary.Add(pokedex);
                    }
                    DexWindowToAlter.gvBinder.DisplayMemberBinding = null;
                    DexWindowToAlter.lvPokedex.ItemsSource = pokeEntriesTemporary;
                    DexWindowToAlter.Show();
                    DexWindowToAlter.Topmost = true;
                    DexWindowToAlter.lvPokedex.SelectedIndex = 0;
                    Close();
                    break;
                case 1:
                    foreach (Pokedex pokedex in pokeEntries) //toevoegen op dexnummer
                    {
                        pokeEntriesTemporary.Add(pokedex);
                    }
                    DexWindowToAlter.gvBinder.DisplayMemberBinding = null;
                    DexWindowToAlter.lvPokedex.ItemsSource = pokeEntriesTemporary;
                    DexWindowToAlter.Show();
                    DexWindowToAlter.Topmost = true;
                    DexWindowToAlter.lvPokedex.SelectedIndex = 0;
                    Close();
                    break;
                default:
                    MessageBox.Show("Je moet een sorteervorm selecteren."); // wanneer er geen case gekozen is of bij letterlijk defaults
                    break;
            }
        }


    }
}
