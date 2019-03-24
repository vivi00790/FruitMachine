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
            List<string> reelResult = GetReelResult(reels, reelsStopAt);
            var groupIconAndCount = GetGroupIconAndCount(reelResult);
            if (groupIconAndCount.Count==1)
            {
                return GetBaseScore(reels[0][reelsStopAt[0]]) * 10;
            }

            if (groupIconAndCount.Count==2)
            {
                return groupIconAndCount.First(item => item.Item2 == 1).Item1 == "Wild"
                    ? GetBaseScore(groupIconAndCount.First(item => item.Item2 == 2).Item1) * 2
                    : GetBaseScore(groupIconAndCount.First(item => item.Item2 == 2).Item1);
            }
            return 0;
        }

        private List<string> GetReelResult(List<List<string>> reels, List<int> reelsStopAt)
        {
            return reels.Select((reel, i) => reel[reelsStopAt[i]]).ToList();
        }

        private List<Tuple<string, int>> GetGroupIconAndCount(List<string> reelResult)
        {
            return reelResult.GroupBy(item => item)
                .Select(item => new Tuple<string, int>(item.First().ToString(), item.Count())).ToList();
        }

        private int GetBaseScore(string iconName)
        {
            return _iconBaseScore[iconName];
        }

        private readonly Dictionary<string, int> _iconBaseScore = new Dictionary<string, int>()
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
