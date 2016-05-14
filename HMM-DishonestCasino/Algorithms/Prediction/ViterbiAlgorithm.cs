//#define _OLD_VERSION

using System;
using System.Collections.Generic;
using System.Linq;

namespace HMMDishonestCasino.Algorithms.Prediction
{
    public class ViterbiAlgorithm<TObservation, TState> : PredictionAlgorithm<TObservation, TState>
    {
        private Dictionary<TState, StateWithProbability[]> delta;

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

            delta = new Dictionary<TState,StateWithProbability[]>();
            Output = new TState[T];

            foreach (var iState in StateSpace)
            {
                delta[iState] = new StateWithProbability[T];
                delta[iState][0] = new StateWithProbability(iState, Math.Log(InitialProbabilitiesOfStates[iState]));
            }

            for (var t = 1; t < T; t++)
                foreach (var iState in StateSpace)
                    delta[iState][t] = max(t, iState);
         
            Output[T - 1] = delta.Aggregate((a, b) => a.Value[T - 1].Probability > b.Value[T - 1].Probability ? a : b).Key;

            for (var i = T - 1; i > 0; i--)
                Output[i - 1] = delta[Output[i]][i].State;
        }

        private StateWithProbability max(int t, TState iState)
        {
            var max = new StateWithProbability(default(TState),double.MinValue);

            foreach (var jState in StateSpace)
            {
                var value = delta[jState][t - 1].Probability + Math.Log(TransitionMatrix[jState, iState]) +
                            Math.Log(EmissionMatrix[iState, SequenceOfObservations[t]]);
                if(value<=max.Probability) continue;
                max = new StateWithProbability(jState, value);
            }
            return max;
        }

        private struct StateWithProbability
        {
            public double Probability { get; }
            public TState State { get; }

            public StateWithProbability(TState state, double probability)
            {
                State = state;
                Probability = probability;
            }
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