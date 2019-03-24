using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitMachineTest
{
    class FruitMachine
    {
        public int Score(List<List<string>> fixedReels, List<int> reelsStopAt)
        {
            if (fixedReels[0][reelsStopAt[0]] == fixedReels[1][reelsStopAt[1]] &&
                fixedReels[1][reelsStopAt[1]] == fixedReels[2][reelsStopAt[2]])
            {
                return GetBaseScore(fixedReels[0][reelsStopAt[0]]) * 10;
            }
            return 0;
        }

        private int GetBaseScore(string iconName)
        {
            return iconBaseScore[iconName];
        }

        private Dictionary<string, int> iconBaseScore = new Dictionary<string, int>()
        {
            { "Wild",10},
            { "Star",9},
            { "Bell",8},
            { "Shell",7},
            { "Seven",6},
            { "Cherry",5},
            { "Bar",4},
            { "King",3},
            { "Queen",2},
            { "Jack",1},
        };
    }
}
