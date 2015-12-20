//#define _OLD_VERSION

using System.Collections.Generic;
using System.Linq;

namespace HMMDishonestCasino.Algorithms.Prediction
{
    public class ViterbiAlgorithm<TObservation, TState> : PredictionAlgorithm<TObservation, TState>
    {
        public ViterbiAlgorithm()
        {
        }

        public ViterbiAlgorithm(BaseAlgorithm<TObservation, TState> baseAlgorithm) : base(baseAlgorithm)
        {
        }

#if !_OLD_VERSION
        public override void DoWork() //based on https://en.wikipedia.org/wiki/Viterbi_algorithm#Pseudocode
        {
            base.DoWork();
            var T1 = new Dictionary<TState, double[]>();
            var T2 = new Dictionary<TState, TState[]>();

            foreach (var state in StateSpace)
            {
                T1[state] = new double[T];
                T2[state] = new TState[T];
                T1[state][0] = InitialProbabilitiesOfStates[state]*EmissionMatrix[state, SequenceOfObservations[0]];
                T2[state][0] = state;
            }

            for (var i = 1; i < SequenceOfObservations.Length; i++)
            {
                foreach (var state in StateSpace)
                {
                    var value = max(T1, i, state);
                    T1[state][i] = EmissionMatrix[state, SequenceOfObservations[i]]*value.max;
                    T2[state][i] = value.argmax;
                }
            }
            Output = new TState[T];

            //z_T \gets \arg\max_{k}{(T_1[k,T])} 
            Output[T - 1] = T1.Select((value, index) => new {Value = value, Index = index})
                .Aggregate((a, b) => a.Value.Value[T - 1] > b.Value.Value[T - 1] ? a : b)
                .Value.Key;

            for (var i = T - 1; i > 0; i--)
                Output[i - 1] = T2[Output[i]][i];
        }

        private dynamic max(Dictionary<TState, double[]> T1, int i, TState state)
        {
            var max = double.MinValue;
            var argmax = default(TState);
            foreach (var t in StateSpace)
            {
                var value = T1[t][i - 1]*TransitionMatrix[t, state];
                if (value <= max) continue;
                max = value;
                argmax = t;
            }

            return new {max, argmax};
        }
#else
    private struct ArgMax
    {
        public double Arg;
        public double Max;
    }
        public override void DoWork() //based on https://en.wikipedia.org/wiki/Viterbi_algorithm#Pseudocode
        {
            base.DoWork();
            double[,] T1 = new double[StateSpace.Length, T];
            double[,] T2 = new double[StateSpace.Length, T];

            for (int i = 0; i < StateSpace.Length; i++)
            {
                var state = StateSpace[i];
                T1[i, 0] = InitialProbabilitiesOfStates[i] * EmissionMatrix[i, 0];
                T2[i, 0] = 0;
            }

            for (int i = 1; i < T; i++)
            {
                for (int j = 0; j < StateSpace.Length; j++)
                {
                    var argmax = ArgMax(T1, i, j);

                    T1[j, i] = argmax.max;
                    T2[j, i] = argmax.argmax;
                }
            }
        }

        private dynamic ArgMax(double[,] T1, int i, int j)
        {
            var max = double.MinValue;
            var argmax = double.MinusOne;
            for (int k = 0; k < T1.Length; k++)
            {
                var value = T1[k, i - 1] * TransitionMatrix[k, j] * EmissionMatrix[j, i];
                if (value <= max) continue;
                max = value;
                argmax = k;
            }

            if (argmax == double.MinusOne)
                throw new Exception();

            return new { max, argmax };
        }
#endif
    }
}