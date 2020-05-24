using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonDAL;
using System.Collections;
using System.Collections.Generic;
using PokemonWPF;

namespace PokemonUnitTests
{
    [TestClass]
    public class DatabaseOperationUnitTests
    {
        [TestMethod]
        public void TestPartySize()
        {

            //Tests whether no parties exceed allowable size

            //arrange
            List<Trainer> allTrainers = new List<Trainer>();
            List<PokemonGroup> GroupToCheck = new List<PokemonGroup>();


            //act
            allTrainers = DatabaseOperations.TrainerList();

            //Assert
            foreach (var trainer in allTrainers)
            {
                GroupToCheck = DatabaseOperations.SelectParty(trainer.Id);
                Assert.IsTrue(GroupToCheck.Count < 7);
            }

        }
        [TestMethod]
        public void TestMovePoolSize()
        {

            //Tests whether no pokemonMoves exceed allowable size

            //arrange
            List<Pokemon> allPokemon = new List<Pokemon>();
            List<LearnedMoves> MovesToCheck = new List<LearnedMoves>();


            //act
            allPokemon = DatabaseOperations.PokemonList();

            //Assert
            foreach (var pokemon in allPokemon)
            {
                MovesToCheck = DatabaseOperations.SelectMovesFromPokemon(pokemon);
                Assert.IsTrue(MovesToCheck.Count < 5);
            }

        }

        [TestMethod]
        public void TestQuantity()
        {
            //Tests wheter no item exceed allowable quantity
            //arrange
            List < PokemonDAL.Items > allItems = new List<Items>();
            List<PokemonDAL.PlayerInventory> QuantityToCheck = new List<PlayerInventory>();

            //act
            allItems = DatabaseOperations.ItemList();

            //asert
            foreach (var item in allItems)
            {
                QuantityToCheck = DatabaseOperations.SelectQuantityFromItems(item);
                Assert.IsTrue(QuantityToCheck.Count < 100);
            }
        }
    }
}
