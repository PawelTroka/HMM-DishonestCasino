using System;
using System.Linq;
using HMMDishonestCasino.Algorithms.Probability;

namespace HMMDishonestCasino.Algorithms.Prediction
{
    public class APosterioriAlgorithm<TObservation, TState> : PredictionAlgorithm<TObservation, TState>
    {
        private ProbabilityCalculatingAlgorithm<TObservation, TState> suffixAlgorithm, prefixAlgorithm;

        public APosterioriAlgorithm()
        {
        }

        public APosterioriAlgorithm(BaseAlgorithm<TObservation, TState> baseAlgorithm) : base(baseAlgorithm)
        {
        }

        public override void DoWork()
        {
            base.DoWork();

            suffixAlgorithm = new SuffixAlgorithm<TObservation, TState>(this);
            prefixAlgorithm = new PrefixAlgorithm<TObservation, TState>(this);
            suffixAlgorithm.DoWork();
            prefixAlgorithm.DoWork();

            var probabilitySuffix = suffixAlgorithm.P();
            var probabilityPrefix = prefixAlgorithm.P();
            var TOLERANCE = 1e-3;
            if (Math.Abs((probabilitySuffix - probabilityPrefix)/probabilityPrefix) > TOLERANCE)
                throw new Exception("Probabilities are not equal");

            var probability = (probabilitySuffix + probabilityPrefix)/2.0;
            Output = new TState[T];

            for (var i = 0; i < T; i++)
            {
                var mostProbableState = StateSpace.Aggregate(
                    (s1, s2) =>
                        prefixAlgorithm.fb[s1][i]*suffixAlgorithm.fb[s1][i]/probability >
                        prefixAlgorithm.fb[s2][i]*suffixAlgorithm.fb[s2][i]/probability
                            ? s1
                            : s2);
                Output[i] = mostProbableState;
            }
        }
    }
}