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
                f[state] = new decimal[T];

                f[state][0] = ArrayOfInitialProbabilitiesOfStates[state] * EmissionMatrix[state, SequenceOfObservations[0]];
            }

            //f[default(TState)] = new decimal[T];

            //f[default(TState)][0] = 1;

            for (int i = 1; i < T; i++)
            {

                foreach (var kState in StateSpace)
                {
                    decimal sum = 0;
                    foreach (var lState in StateSpace)
                        sum += f[lState][i - 1]*TransitionMatrix[lState, kState];
                    f[kState][i] = EmissionMatrix[kState, SequenceOfObservations[i]] * sum;
                }
            }
        }
    }
}
