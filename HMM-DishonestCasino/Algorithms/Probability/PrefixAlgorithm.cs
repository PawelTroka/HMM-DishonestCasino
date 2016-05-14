using System;
using System.Collections.Generic;
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
            
            var c = new double[T];

            // compute α0(i)
            c[0] = 0.0;
            foreach (var state in StateSpace)
            {
                fb[state][0] = InitialProbabilitiesOfStates[state]*EmissionMatrix[state, SequenceOfObservations[0]];
                c[0] += fb[state][0];
            }

            // scale the α0(i)
            c[0] = 1/ c[0];
            foreach (var state in StateSpace)
                fb[state][0] *= c[0];


            // compute αt(i)
            for (var t = 1; t < T; t++)
            {

                c[t] = 0;
                foreach (var iState in StateSpace)
                {
                    fb[iState][t] = 0;
                    foreach (var jState in StateSpace)
                    {
                        fb[iState][t] += fb[jState][t - 1]*TransitionMatrix[jState, iState];
                    }
                    fb[iState][t] *= EmissionMatrix[iState, SequenceOfObservations[t]];
                    c[t] += fb[iState][t];

                    //  fb[iState][t] = EmissionMatrix[iState, SequenceOfObservations[t]]*
                    //  StateSpace.Sum(lState => fb[lState][t - 1]*TransitionMatrix[lState, iState]);
                }


                // scale αt(i)
                c[t] = 1 / c[t];
                foreach (var iState in StateSpace)
                    fb[iState][t] *= c[t];
            }
        }

        public override
            double P()
        {
            if (fb == null || fb.Count == 0)
                throw new Exception("You have to call DoWork() first");

            return StateSpace.Sum(state => fb[state][T - 1]);
        }
    }
}