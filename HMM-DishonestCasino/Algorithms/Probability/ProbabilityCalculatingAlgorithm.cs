using System.Collections.Generic;

namespace HMMDishonestCasino.Algorithms.Probability
{
    internal abstract class ProbabilityCalculatingAlgorithm<TObservation, TState> : BaseAlgorithm<TObservation, TState>
    {
        protected ProbabilityCalculatingAlgorithm()
        {
        }

        protected ProbabilityCalculatingAlgorithm(BaseAlgorithm<TObservation, TState> baseAlgorithm)
            : base(baseAlgorithm)
        {
        }

        public Dictionary<TState, double[]> fb { get; set; }

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