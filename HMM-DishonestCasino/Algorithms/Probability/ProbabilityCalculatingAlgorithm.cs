using System;
using System.Collections.Generic;
using System.Linq;

namespace HMMDishonestCasino.Algorithms
{
    abstract class ProbabilityCalculatingAlgorithm<TObservation, TState> : BaseAlgorithm<TObservation, TState>
    {
        protected Dictionary<TState, double[]> f;

        public ProbabilityCalculatingAlgorithm()
        {

        }
        public ProbabilityCalculatingAlgorithm(BaseAlgorithm<TObservation, TState> baseAlgorithm) : base(baseAlgorithm)
        {

        }

        public override void DoWork()
        {
            base.DoWork();
            f = new Dictionary<TState, double[]>();
            foreach (var state in StateSpace)
            {
                f[state] = new double[T];
            }
        }

        public abstract double P();
    }
}