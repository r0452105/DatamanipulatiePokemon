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
        public void TestPokedexType1IsNotNull()
        {

            //Tests whether Type 1 of a pokemon is not null

            //arrange
            List<Pokedex> pokedexentries = new List<Pokedex>();


            //act
            pokedexentries = DatabaseOperations.PokedexEntry(); ;

            //Assert
            foreach (var pokedex in pokedexentries)
            {

                Assert.IsTrue(pokedex.Type1!=null);
            }

        }

        public void TestPokedexWeightIsAboveZero()
        {

            //Tests whether the weight of the pokemon is above 0

            //arrange
            List<Pokedex> pokedexentries = new List<Pokedex>();


            //act
            pokedexentries = DatabaseOperations.PokedexEntry(); ;

            //Assert
            foreach (var pokedex in pokedexentries)
            {

                Assert.IsTrue(pokedex.PokemonWeight>0);
            }

        }
    }
}
