using System;
using System.Collections.Generic;
using System.Linq;

namespace HMMDishonestCasino.Algorithms.Probability
{
    class PrefixAlgorithm<TObservation, TState> : ProbabilityCalculatingAlgorithm<TObservation, TState>
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
                f[state][0] = InitialProbabilitiesOfStates[state] * EmissionMatrix[state, SequenceOfObservations[0]];
            }

            //f[default(TState)] = new double[T];
            //f[default(TState)][0] = 1;

            for (int i = 1; i < T; i++)
            {
                foreach (var kState in StateSpace)
                {
                    f[kState][i] = EmissionMatrix[kState, SequenceOfObservations[i]] * StateSpace.Sum(lState => f[lState][i - 1] * TransitionMatrix[lState, kState]);
                }
            }
        }

        public override double P()
        {
            if (f == null || f.Count == 0)
                throw new Exception("You have to call DoWork() first");

            return StateSpace.Sum(state => f[state][T - 1]);
        }
    }
}
