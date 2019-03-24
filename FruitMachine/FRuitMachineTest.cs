using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FruitMachineTest
{
    [TestClass]
    public class FruitMachineTest
    {
        private static List<List<string>> _fixedReels = new List<List<string>>();

        private static List<string> _fixedReel = new List<string>()
            {"Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack"};

        private static FruitMachine _fruitMachine;

        private static int _reelNum = 3;

        

        [TestInitialize]
        public void SetUp()
        {
            for (int i = 0; i < _reelNum; i++)
            {
                _fixedReels.Add(_fixedReel);
            } 
            _fruitMachine = new FruitMachine();
        }

        [TestMethod]
        public void No_matching_should_return_zero()
        {

            Assert.AreEqual(0,GetFruitMachineScoreWithFixedReels(0,1,2));
        }

        [TestMethod]
        public void All_matching_should_return_ten_times_of_base_score()
        {

            Assert.AreEqual(100,GetFruitMachineScoreWithFixedReels(0,0,0));
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
