using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FruitMachineTest
{
    [TestClass]
    public class FruitMachineTest
    {
        private static List<List<string>> _fixedReels = new List<List<string>>()
        {
            new List<string>(){"Wild", "Star", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack"},
            new List<string>(){"Wild", "Star", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack"},
            new List<string>(){"Wild", "Star", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack"},
        };

        private static FruitMachine _fruitMachine;

        

        [TestInitialize]
        public void SetUp()
        {
            _fruitMachine = new FruitMachine();
        }

        [TestMethod]
        public void No_matching_should_return_zero()
        {

            Assert.AreEqual(0,GetFruitMachineScoreWithFixedReels(0,1,2));
        }

        private int GetFruitMachineScoreWithFixedReels(int reelOneAt, int reelTwoAt, int reelThreeAt)
        {
            return _fruitMachine.Score(_fixedReels, GetReelsStopAt(reelOneAt, reelTwoAt, reelThreeAt));
        }

        private List<int> GetReelsStopAt(int reelOneAt, int reelTwoAt, int reelThreeAt)
        {
            return new List<int>() {reelOneAt, reelTwoAt, reelThreeAt};
        }
    }

    
}
