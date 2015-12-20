using System;
using System.Linq;

namespace HMMDishonestCasino.Algorithms.Probability
{
    internal class SuffixAlgorithm<TObservation, TState> : ProbabilityCalculatingAlgorithm<TObservation, TState>
    {
        public SuffixAlgorithm()
        {
        }

        public SuffixAlgorithm(BaseAlgorithm<TObservation, TState> baseAlgorithm) : base(baseAlgorithm)
        {
        }

        public override void DoWork()
        {
            base.DoWork();
            foreach (var state in StateSpace)
            {
                fb[state][T - 1] = 1;
                //InitialProbabilitiesOfStates[state] * EmissionMatrix[state, SequenceOfObservations[T - 1]];
            }
            for (var i = T - 2; i >= 0; i--)
            {
                foreach (var kState in StateSpace)
                {
                    fb[kState][i] =
                        StateSpace.Sum(
                            lState =>
                                TransitionMatrix[kState, lState]*EmissionMatrix[lState, SequenceOfObservations[i + 1]]*
                                fb[lState][i + 1]);
                }
            }
        }

        public override double P()
        {
            if (fb == null || fb.Count == 0)
                throw new Exception("You have to call DoWork() first");

            return
                StateSpace.Sum(
                    state =>
                        InitialProbabilitiesOfStates[state]*EmissionMatrix[state, SequenceOfObservations[0]]*
                        fb[state][0]);
        }
    }
}