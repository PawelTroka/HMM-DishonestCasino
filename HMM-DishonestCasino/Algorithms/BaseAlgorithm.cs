using System.Collections.Generic;

namespace HMMDishonestCasino.Algorithms
{
    internal abstract class BaseAlgorithm
    {
        public int NumberOfSides { get; set; }

        public List<int> Input { get; set; }
        public List<CasinoState> Output { get; set; }

        public abstract void DoWork();
    }
}