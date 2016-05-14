using System;
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

        public Dictionary<TState, double[]> fb { get; private set; }


        public override void DoWork()
        {
            base.DoWork();
            fb = new Dictionary<TState, double[]>();
            foreach (var state in StateSpace)
            {
                fb[state] = new double[T];
            }
        }

        protected double log(double x)
        {
            return Math.Log(x);
        }

        protected double antilog(double x)
        {
            return Math.Exp(x); //Math.Pow(10, x);
        }

        public abstract double P();
    }
}