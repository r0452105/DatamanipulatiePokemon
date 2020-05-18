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
   

            //arrange
            List<PokemonGroup> party1 = new List<PokemonGroup>();
            List<PokemonGroup> party2 = new List<PokemonGroup>();

           
            //act
            party1 = DatabaseOperations.SelectParty(1);
            party2 = DatabaseOperations.SelectParty(2);

            Assert.IsTrue(party1.Count < 7 && party2.Count < 7);

        }
    }
}
