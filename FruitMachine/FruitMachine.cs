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
            var groupIconAndCount = getGroupIconAndCount(reelResult);
            if (groupIconAndCount.Count==1)
            {
                return GetBaseScore(reels[0][reelsStopAt[0]]) * 10;
            }

            if (groupIconAndCount.Count==2)
            {
                
                return GetBaseScore(groupIconAndCount.First(item => item.Item2==2).Item1);
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

        private List<Tuple<string, int>> getGroupIconAndCount(List<string> reelResult)
        {
            return reelResult.GroupBy(item => item)
                .Select(item => new Tuple<string, int>(item.First().ToString(), item.Count())).ToList();
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
