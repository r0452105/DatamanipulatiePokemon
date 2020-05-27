﻿using PokemonDAL;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for PokemonPartyCRUD.xaml
    /// </summary>
    public partial class PokemonPartyCRUD : Window
    {
        public Trainer currentTrainer;
        public Pokemon CurrentPkm;
        public PokemonGroup CurrentPkmParty;
        public List<Pokedex> pokedexList;
        public List<Ability> abilityList;
        
        public LearnedMoves DefaultMoves1 = new LearnedMoves();
        public LearnedMoves DefaultMoves2 = new LearnedMoves();

        public int baseHP;
        public int baseAtt;
        public int baseDef;
        public int baseSpAtt;
        public int baseSpDef;
        public int baseSpeed;

        public int EVHP;
        public int EVAtt;
        public int EVDef;
        public int EVSpAtt;
        public int EVSpDef;
        public int EVSpeed;

        public PokemonPartyCRUD()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            abilityList = DatabaseOperations.AbilityList();
            pokedexList = DatabaseOperations.PokedexEntry();
            cmbPokemon.ItemsSource = pokedexList;
            cmbAbility.ItemsSource = abilityList;
            cmbPokemon.SelectionChanged += new SelectionChangedEventHandler(cmbPokemon_SelectionChanged);
            cmbPosition.SelectionChanged += new SelectionChangedEventHandler(cmbPosition_SelectionChanged);



        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Validate()))
            {
                //Update functionaliteit uitvoeren
                Ability newAbility = (Ability)cmbAbility.SelectedItem;
                CurrentPkm.AbilityID = newAbility.Id ;
                CurrentPkm.Nickname = txtName.Text;
                CurrentPkm.PokemonLevel = int.Parse(txtLvl.Text);
                CurrentPkm.PokemonExp = CurrentPkm.PokemonLevel * CurrentPkm.PokemonLevel * CurrentPkm.PokemonLevel;

                if (cmbGender.SelectedIndex == 0)
                {
                    CurrentPkm.Gender = false;
                }
                else
                {
                    CurrentPkm.Gender = true;
                }

                if (DatabaseOperations.UpdatePokemon(CurrentPkm) != 0)
                {
                    MessageBox.Show($"The stats of {CurrentPkm.Nickname} have been succesfully altered");
                    Close();
                }
                else
                {
                    MessageBox.Show("Update was unsuccessful");
                }

            }
            else
            {
                MessageBox.Show(Validate());
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Delete functionaliteit uitvoeren
            if (DatabaseOperations.RemovePokemonFromGroup(CurrentPkmParty) != 0)
            {
                MessageBox.Show($"{CurrentPkm.Nickname} succesfully removed from the party of {currentTrainer.TrainerName}");
                Close();
            }
            else
            {
                MessageBox.Show("Deletion failed");
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
            {
                PokemonStats statWindow = new PokemonStats
                {
                    StatPass = this
                };
                statWindow.ShowDialog();

                //Initialize statPool
                StatPool statPool = new StatPool
                {
                    Id = DatabaseOperations.CurrentStatpools() + 1
                };


                //Initialize stat collections
                StatCollection BaseStats = new StatCollection();
                StatCollection EVStats = new StatCollection();
                StatCollection IVStats = new StatCollection();
                StatCollection EVRewardStats = new StatCollection();

                //Assign Values
                BaseStats.Id = DatabaseOperations.CurrentStatCollections() + 1;
                BaseStats.HP = baseHP;
                BaseStats.Attack = baseAtt;
                BaseStats.Defense = baseDef;
                BaseStats.SpecialAttack = baseSpAtt;
                BaseStats.SpecialDefence = baseSpDef;
                BaseStats.Speed = baseSpeed;

                EVStats.Id = DatabaseOperations.CurrentStatCollections() + 2;
                EVStats.HP = 0;
                EVStats.Attack = 0;
                EVStats.Defense = 0;
                EVStats.SpecialAttack = 0;
                EVStats.SpecialDefence = 0;
                EVStats.Speed = 0;

                Random rnd = new Random();
                IVStats.Id = DatabaseOperations.CurrentStatCollections() + 3;
                IVStats.HP = rnd.Next(1, 32);
                IVStats.Attack = rnd.Next(1, 32);
                IVStats.Defense = rnd.Next(1, 32);
                IVStats.SpecialAttack = rnd.Next(1, 32);
                IVStats.SpecialDefence = rnd.Next(1, 32);
                IVStats.Speed = rnd.Next(1, 32);

                EVRewardStats.Id = DatabaseOperations.CurrentStatCollections() + 4;
                EVRewardStats.HP = EVHP;
                EVRewardStats.Attack = EVAtt;
                EVRewardStats.Defense = EVDef;
                EVRewardStats.SpecialAttack = EVSpAtt;
                EVRewardStats.SpecialDefence = EVSpDef;
                EVRewardStats.Speed = EVSpeed;

                
                //Bind with statpool
                if (DatabaseOperations.AddStatCollection(BaseStats) != 0
                    && DatabaseOperations.AddStatCollection(EVStats) != 0
                    && DatabaseOperations.AddStatCollection(IVStats) != 0
                    && DatabaseOperations.AddStatCollection(EVRewardStats) != 0)
                {


                    statPool.BaseStatId = BaseStats.Id;
                    statPool.EVStatId = EVStats.Id;
                    statPool.IVStatId = IVStats.Id;
                    statPool.EffortValueYield = EVRewardStats.Id;

                    statPool.Nature = "Timid";

                    if (DatabaseOperations.AddStatPool(statPool) != 0)
                    {
                        Pokemon PokemonToAdd = new Pokemon
                        {
                            Id = DatabaseOperations.CurrentPokemons() + 1,
                            PokedexID = cmbPokemon.SelectedIndex + 1,
                            PokemonLevel = int.Parse(txtLvl.Text)
                        };
                        PokemonToAdd.PokemonExp = PokemonToAdd.PokemonLevel * PokemonToAdd.PokemonLevel * PokemonToAdd.PokemonLevel;
                        PokemonToAdd.TrainerID = currentTrainer.Id;
                        PokemonToAdd.AbilityID = abilityList[cmbAbility.SelectedIndex].Id;
                        PokemonToAdd.StatPoolID = statPool.Id;
                        if (cmbGender.SelectedIndex == 0)
                        {
                            PokemonToAdd.Gender = false;
                        }
                        else
                        {
                            PokemonToAdd.Gender = true;
                        }
                        PokemonToAdd.Nickname = txtName.Text;
                        PokemonToAdd.Shiny = false;
                        PokemonToAdd.PokeRus = false;

                        if (DatabaseOperations.AddPokemon(PokemonToAdd) != 0)
                        {

                            LoadDefaultMoves(PokemonToAdd.Id);

                            if (DatabaseOperations.LearnNewMove(DefaultMoves1) != 0
                                 && DatabaseOperations.LearnNewMove(DefaultMoves2) != 0)
                            {
                                PokemonGroup GroupToAddTo = new PokemonGroup
                                {
                                    Id = DatabaseOperations.CurrentPokemonGroups() + 1,
                                    PlayerId = currentTrainer.Id,
                                    PokemonId = PokemonToAdd.Id,
                                    Position = int.Parse(cmbPosition.Text)
                                };
                                //Enkel als alle stats correct er in zijn geplaatst, word de pokemon in de groep geplaatsts
                                //Bij falen word het een onbereikbaar database element binnen de context van dit programma
                                if (DatabaseOperations.AddToGroup(GroupToAddTo) != 0)
                                {
                                    MessageBox.Show($"{PokemonToAdd.Nickname} is succesvol toegevoegd aan de party van {currentTrainer.TrainerName}");
                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show("Fout in groep creatie; toevoeging niet afgerond");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Geen moves meegegeven; Toevoeging niet afgerond");
                            }



                        }
                        else
                        {
                            MessageBox.Show("Geen valide pokemon; Toevoeging niet afgerond");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Fout in de statpool; toevoeging niet afgerond");
                    }





                }
                else
                {
                    MessageBox.Show("één of meerder van de statcollections zijn niet valide; toevoeging niet afgerond");
                }


            }

        }

        private string Validate()
        {

            //Standaard gegevens validatie
            string errormsg = "";
            if (!int.TryParse(txtLvl.Text, out int fieldvalue))
            {
                errormsg += "Level moet numeriek zijn";
                if (fieldvalue < 1 || fieldvalue > 100)
                {
                    errormsg += "Level moet tussen 1 en 100 liggen";
                }
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errormsg += "Nickname mag niet leeg zijn";
            }


            return errormsg;

        }
        

        private void LoadDefaultMoves(int pokemonID)
        {
            DefaultMoves1.Id = DatabaseOperations.CurrentLearnedMoves() + 1;
            DefaultMoves2.Id = DatabaseOperations.CurrentLearnedMoves() + 2;
            DefaultMoves1.CurrentPP = 30;
            DefaultMoves1.MoveId = 42;
            DefaultMoves1.Position = 1;
            DefaultMoves2.CurrentPP = 30;
            DefaultMoves2.MoveId = 10;
            DefaultMoves2.Position = 2;
            DefaultMoves1.PokemonId = pokemonID;
            DefaultMoves2.PokemonId = pokemonID;

        }
        private void cmbPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            txtName.Text = pokedexList[cmbPokemon.SelectedIndex].PokemonName;


        }

        private void cmbPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Positie aanpassen word gezien als een directe handeling, en word uitgevoerd voor dat andere veranderingen ingerekent kunnen worden
            PokemonGroup pokemonToSwap = DatabaseOperations.SelectPokemonFromParty(currentTrainer.Id, int.Parse(cmbPosition.SelectedItem.ToString()));
            int position1 = CurrentPkmParty.Position;
            int position2 = pokemonToSwap.Position;
            CurrentPkmParty.Position = position2;
            pokemonToSwap.Position = position1;
            if (DatabaseOperations.ChangePosition(CurrentPkmParty) != 0 && DatabaseOperations.ChangePosition(pokemonToSwap) != 0)
            {
                MessageBox.Show($"Position changed, {CurrentPkmParty.Pokemon.Nickname} has been swapped with {pokemonToSwap.Pokemon.Nickname}");
            }
            else
            {
                MessageBox.Show("Position swap unsuccessful");
            }



        }
    }
}
