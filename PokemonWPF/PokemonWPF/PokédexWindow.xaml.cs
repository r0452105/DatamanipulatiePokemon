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

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PokédexWindow : Window
    {
        public MainWindow WindowToAlter;
        public PokédexWindow()
        {
            InitializeComponent();
            lblSeenCaptured.Content = "Pokémon \n\nSeen: 2 \nCaptured: 1";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            WindowToAlter.Visibility = Visibility.Visible;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            SearchDexWindow searchDexWindow1 = new SearchDexWindow();
            searchDexWindow1.DexWindowToAlter = this;
            searchDexWindow1.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {       
        }


        private void LbPokédex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Image bulba = new Image();
            //bulba = "";

            //Image bulba = Image.FromFile("c:\\Bulba.jpg");

            if (lbPokédex.SelectedItems == lbiNumber1)
            {
                //PokédexPicture.Source = bulba;

            }
            //PokédexPicture.Source= pokemon.photolink (property)


        }

        private void LbPokédex_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (lbPokédex.SelectedIndex)
            {
                case 0:
                    PokémonInfoWindow PokéInfoWindow1 = new PokémonInfoWindow();
                    PokéInfoWindow1.DexWindowToAlter = this;
                    //PokéInfoWindow1.indiPokemon = PokemonDAL.Pokedex pokedex;
                    PokéInfoWindow1.Show();
                    this.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    this.Visibility = Visibility.Hidden;
                    //MAAK HIER DE CODE VOOR DE PARTY AAN TE ROEPEN MET SHOW DIALOG, EN PASS DE TRAINER VARIABLE ER NAAR TOE



                    this.Visibility = Visibility.Visible;
                    break;
                case 2:
                    this.Visibility = Visibility.Hidden;
                    //MAAK HIER DE CODE VOOR DE INVENTORY  TE ROEPEN MET SHOW DIALOG, EN PASS DE TRAINER VARIABLE ER NAAR TOE



                    this.Visibility = Visibility.Visible;
                    break;
                case 3:
                    this.Visibility = Visibility.Hidden;
                    //MAAK HIER DE CODE VOOR DE TRAINER CARRD AAN TE ROEPEN MET SHOW DIALOG, EN PASS DE TRAINER VARIABLE ER NAAR TOE

                    this.Visibility = Visibility.Visible;
                    break;
                default:
                    Close();

                    break;
            }
        }
    }
}
