using System.Collections.Generic;
using Extensions;

namespace Game
{
    public class MemoryGame
    {
        private readonly List<Position> list = new();
        private int pairs;
        public int Pairs { get => pairs; }
        
        public MemoryGame(int countPairs)
        {
            NewGame(countPairs);
        }
        public List<Position> NewGame(int countPairs)
        {
            pairs = countPairs;
            ResetList(); 
            CreatePairs();
            RandomizeList();
            return list;
        }
        private void ResetList()
        {
            list.Clear();
        }
        private void CreatePairs()
        {
            for (var i = 0; i < pairs; i++)
            {
                list.Add(new Position(i, i, false));
                list.Add(new Position(i+1, i, false));
            }    
        }
        private void RandomizeList()
        {
            list.Shuffle();
        }
    }
}

