using System.Collections.Generic;

namespace HMMDishonestCasino.Algorithms
{
    internal abstract class ProbabilityCalculatingAlgorithm<TObservation, TState> : BaseAlgorithm<TObservation, TState>
    {
        protected Dictionary<TState, double[]> fb;

        public ProbabilityCalculatingAlgorithm()
        {
        }

        public ProbabilityCalculatingAlgorithm(BaseAlgorithm<TObservation, TState> baseAlgorithm) : base(baseAlgorithm)
        {
        }

        public override void DoWork()
        {
            base.DoWork();
            fb = new Dictionary<TState, double[]>();
            foreach (var state in StateSpace)
            {
                fb[state] = new double[T];
            }
        }

        public abstract double P();
    }
}