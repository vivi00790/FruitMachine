﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FruitMachineTest
{
    [TestClass]
    public class FruitMachineTest
    {
        private List<List<string>> _fixedReels = new List<List<string>>();

        private readonly List<string> _fixedReel = new List<string>()
            {"Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack"};

        private FruitMachine _fruitMachine;

        private readonly int _reelNum = 3;

        

        [TestInitialize]
        public void SetUp()
        {
            for (int i = 0; i < _reelNum; i++)
            {
                _fixedReels.Add(_fixedReel);
            } 
            _fruitMachine = new FruitMachine();
        }

        [TestCleanup]
        public void TearDown()
        {
            _fruitMachine = null;
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

        [TestMethod]
        public void Two_matching_should_return_base_score()
        {

            Assert.AreEqual(10,GetFruitMachineScoreWithFixedReels(0,0,1));
            Assert.AreEqual(9,GetFruitMachineScoreWithFixedReels(1,2,1));
            Assert.AreEqual(8,GetFruitMachineScoreWithFixedReels(3,2,2));
        }

        [TestMethod]
        public void Two_matching_With_one_wild_should_return_two_times_of_base_score()
        {

            Assert.AreEqual(18,GetFruitMachineScoreWithFixedReels(1,1,0));
            Assert.AreEqual(16, GetFruitMachineScoreWithFixedReels(2, 0, 2));
            Assert.AreEqual(14, GetFruitMachineScoreWithFixedReels(0, 3, 3));
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
