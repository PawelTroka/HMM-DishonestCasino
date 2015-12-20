using System;
using System.Linq;

namespace HMMDishonestCasino.Algorithms.Probability
{
    class SuffixAlgorithm<TObservation, TState> : ProbabilityCalculatingAlgorithm<TObservation, TState>
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
                f[state][T - 1] = 1;
                //InitialProbabilitiesOfStates[state] * EmissionMatrix[state, SequenceOfObservations[T - 1]];
            }
            for (int i = T-2; i >= 0; i--)
            {
                foreach (var kState in StateSpace)
                {
                    f[kState][i] =
                        StateSpace.Sum(
                            lState =>
                                TransitionMatrix[kState, lState]*EmissionMatrix[lState, SequenceOfObservations[i + 1]]*
                                f[lState][i + 1]);
                }
            }
        }

        public override double P()
        {
            if (f == null || f.Count == 0)
                throw new Exception("You have to call DoWork() first");
            
            return StateSpace.Sum(state => InitialProbabilitiesOfStates[state]*EmissionMatrix[state,SequenceOfObservations[0]] *f[state][0]);
        }
    }
}