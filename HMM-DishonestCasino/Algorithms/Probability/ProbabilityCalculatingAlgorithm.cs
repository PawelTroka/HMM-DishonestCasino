using System;
using System.Collections.Generic;
using System.Linq;

namespace HMMDishonestCasino.Algorithms
{
    abstract class ProbabilityCalculatingAlgorithm<TObservation, TState> : BaseAlgorithm<TObservation, TState>
    {
        protected Dictionary<TState, decimal[]> f = new Dictionary<TState, decimal[]>();

        public ProbabilityCalculatingAlgorithm()
        {

        }
        public ProbabilityCalculatingAlgorithm(BaseAlgorithm<TObservation, TState> baseAlgorithm) : base(baseAlgorithm)
        {

        }

        public decimal P(int? i = null)
        {
            if (f == null||f.Count==0)
                throw new Exception("You have to call DoWork() first");
            if (i == null)
                return P(T - 1);

            return StateSpace.Sum(state => f[state][i.Value]);
        }
    }
}