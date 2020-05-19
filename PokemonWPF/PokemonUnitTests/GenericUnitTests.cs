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
    }
}
