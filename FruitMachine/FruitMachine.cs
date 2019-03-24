using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitMachineTest
{
    class FruitMachine
    {
        public int Score(List<List<string>> reels, List<int> reelsStopAt)
        {
            List<string> reelResult = getReelResult(reels, reelsStopAt);
            if (EqualCounter(reelResult) ==reels.Count)
            {
                return GetBaseScore(reels[0][reelsStopAt[0]]) * 10;
            }

            if (EqualCounter(reelResult) == 2)
            {
                return GetBaseScore(reels[0][reelsStopAt[0]]);
            }
            return 0;
        }

        private List<string> getReelResult(List<List<string>> reels, List<int> reelsStopAt)
        {
            var reelResult = new List<string>();
            for (int i = 0; i < reels.Count; i++)
            {
                reelResult.Add(reels[i][reelsStopAt[i]]);
            }

            return reelResult;
        }

        private int EqualCounter(List<string> reelResult)
        {
            var equalCounter = reelResult.GroupBy(item => item)
                .Where(item => item.Count() > 1)
                .Select(item => new{iconName = item.First().ToString(), equalTimes = item.Count()});
            return !equalCounter.Any()?0: equalCounter.First().equalTimes;
        }

        private int GetBaseScore(string iconName)
        {
            return iconBaseScore[iconName];
        }

        private readonly Dictionary<string, int> iconBaseScore = new Dictionary<string, int>()
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
