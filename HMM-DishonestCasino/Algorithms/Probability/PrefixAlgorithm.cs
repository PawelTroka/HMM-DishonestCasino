using System;
using System.Linq;

namespace HMMDishonestCasino.Algorithms.Probability
{
    internal class PrefixAlgorithm<TObservation, TState> : ProbabilityCalculatingAlgorithm<TObservation, TState>
    {
        public PrefixAlgorithm()
        {
        }

        public PrefixAlgorithm(BaseAlgorithm<TObservation, TState> baseAlgorithm) : base(baseAlgorithm)
        {
        }

        public override void DoWork()
        {
            base.DoWork();

            foreach (var state in StateSpace)
            {
                fb[state][0] = InitialProbabilitiesOfStates[state]*EmissionMatrix[state, SequenceOfObservations[0]];
            }

            //fb[default(TState)] = new double[T];
            //fb[default(TState)][0] = 1;

            for (var i = 1; i < T; i++)
            {
                foreach (var kState in StateSpace)
                {
                    fb[kState][i] = EmissionMatrix[kState, SequenceOfObservations[i]]*
                                   StateSpace.Sum(lState => fb[lState][i - 1]*TransitionMatrix[lState, kState]);
                }
            }
        }

        public override double P()
        {
            if (fb == null || fb.Count == 0)
                throw new Exception("You have to call DoWork() first");

            return StateSpace.Sum(state => fb[state][T - 1]);
        }
    }
}