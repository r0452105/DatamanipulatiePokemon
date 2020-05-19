﻿using System;
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
    public partial class SearchDexWindow : Window
    {
        public Types poketype = new Types();
        List<Types> poketypeentries = DatabaseOperations.Typinglist();
        public PokédexWindow DexWindowToAlter;
        public Pokedex pokedex = new Pokedex();
        List<Pokedex> pokeEntries = DatabaseOperations.PokedexEntry();
        List<Pokedex> pokeEntriesAZ = DatabaseOperations.PokedexEntryAZ();
        


        public SearchDexWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbType.Items.Add(" ");
            foreach (Types poketype in poketypeentries)
            {
                cbType.Items.Add(poketype.TypeName);
            }
            cbSortBy.Items.Add("Alfabetisch");
            cbSortBy.Items.Add("National Dex");
            cbType.SelectedIndex = 0;
        }


        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            DexWindowToAlter.Topmost = true;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            IList<string> pokeEntriesTemporary = new List<string>();
            foreach (Pokedex pokedex in pokeEntries)
            {
                if (pokedex.PokemonName.ToLower().Contains(tbName.Text.ToLower()))
                {
                    string type1 = "";
                    string type2 = "";

                    foreach (Types poketype in poketypeentries)
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
                    if (cbType.SelectedIndex==0)
                    {
                        pokeEntriesTemporary.Add(pokedex.PokemonName);
                    }
                    else if (type1 == cbType.SelectedItem.ToString() || type2 == cbType.SelectedItem.ToString())
                    {
                        pokeEntriesTemporary.Add(pokedex.PokemonName);
                    }

                    
                }

            }
            DexWindowToAlter.gvBinder.DisplayMemberBinding = null;
            DexWindowToAlter.lvPokedex.ItemsSource = pokeEntriesTemporary;
            if (DexWindowToAlter.lvPokedex.Items.Count < 1)
            {
                List<string> noitems = new List<string>();
                noitems.Add("none");
                DexWindowToAlter.lvPokedex.ItemsSource = noitems;
            }
            DexWindowToAlter.Show();
            DexWindowToAlter.lvPokedex.SelectedIndex = 0;
            this.Close();
        }

        private void BtnStartSorting_Click(object sender, RoutedEventArgs e)
        {
            IList<string> pokeEntriesTemporary = new List<string>();
            switch (cbSortBy.SelectedIndex)
            {
                case 0:
                    // eerst volgorde van de pokemons aanpassen, dan terugleiden naar pokedexscherm
                    foreach (Pokedex pokedex in pokeEntriesAZ)
                    {
                        pokeEntriesTemporary.Add(pokedex.PokemonName);
                    }
                    DexWindowToAlter.gvBinder.DisplayMemberBinding = null;
                    DexWindowToAlter.lvPokedex.ItemsSource = pokeEntriesTemporary;
                    DexWindowToAlter.Show();
                    DexWindowToAlter.lvPokedex.SelectedIndex = 0;
                    this.Close();
                    break;
                case 1:
                 
                    foreach (Pokedex pokedex in pokeEntries)
                    {
                        pokeEntriesTemporary.Add(pokedex.PokemonName);
                    }
                    DexWindowToAlter.gvBinder.DisplayMemberBinding = null;
                    
                    DexWindowToAlter.lvPokedex.ItemsSource = pokeEntriesTemporary;
                    DexWindowToAlter.Show();
                    DexWindowToAlter.lvPokedex.SelectedIndex = 0;
                    this.Close();
                    break;
                default:
                    MessageBox.Show("Je moet een sorteervorm selecteren.");
                    break;
            }
        }

        private void CbType_Selected(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
