using System;
using System.Collections.Generic;
using System.Linq;
using HMMDishonestCasino.Algorithms.Probability;

namespace HMMDishonestCasino.Algorithms.Prediction
{
    /*
     * Based on
     * A Revealing Introduction to Hidden Markov Models
     * Mark Stamp∗
     * Associate Professor
     * Department of Computer Science
     * San Jose State University     * April 26, 2012
     */

    public class APosterioriAlgorithm<TObservation, TState> : PredictionAlgorithm<TObservation, TState>
    {
      //  private ProbabilityCalculatingAlgorithm<TObservation, TState> suffixAlgorithm, prefixAlgorithm;
        private Dictionary<TState, double[]> alpha;
        private Dictionary<TState, double[]> beta;
        public APosterioriAlgorithm()
        {
            c = new double[T];
            alpha = new Dictionary<TState, double[]>();
            foreach (var state in StateSpace)
            {
                alpha[state] = new double[T];
            }

            beta = new Dictionary<TState, double[]>();
            foreach (var state in StateSpace)
            {
                beta[state] = new double[T];
            }
        }

        public APosterioriAlgorithm(BaseAlgorithm<TObservation, TState> baseAlgorithm) : base(baseAlgorithm)
        {
            c = new double[T];
            alpha = new Dictionary<TState, double[]>();
            foreach (var state in StateSpace)
            {
                alpha[state] = new double[T];
            }

            beta = new Dictionary<TState, double[]>();
            foreach (var state in StateSpace)
            {
                beta[state] = new double[T];
            }
        }

        public override void DoWork()
        {
            base.DoWork();

           /* suffixAlgorithm = new SuffixAlgorithm<TObservation, TState>(this);
            prefixAlgorithm = new PrefixAlgorithm<TObservation, TState>(this);
            suffixAlgorithm.DoWork();
            prefixAlgorithm.DoWork();*/

            AlphaPass();BetaPass();

            var probabilitySuffix = StateSpace.Sum(
                    state =>
                        InitialProbabilitiesOfStates[state] * EmissionMatrix[state, SequenceOfObservations[0]] *
                        beta[state][0]); //suffixAlgorithm.P();
            var probabilityPrefix = StateSpace.Sum(state => alpha[state][T - 1]);//prefixAlgorithm.P();

            var TOLERANCE = 1e-3;
            if (Math.Abs((probabilitySuffix - probabilityPrefix)/probabilityPrefix) > TOLERANCE)
                throw new Exception("Probabilities are not equal");

            var probability = (probabilitySuffix + probabilityPrefix)/2.0;
            Output = new TState[T];

            for (var i = 0; i < T; i++)
            {
                var mostProbableState = StateSpace.Aggregate(
                    (s1, s2) =>
                        alpha[s1][i]*beta[s1][i] >
                        alpha[s2][i]*beta[s2][i]
                            ? s1
                            : s2);
                Output[i] = mostProbableState;
            }
        }

        private readonly double[] c;

        private void AlphaPass()
        {
       

            // compute α0(i)
            c[0] = 0.0;
            foreach (var state in StateSpace)
            {
                alpha[state][0] = InitialProbabilitiesOfStates[state] * EmissionMatrix[state, SequenceOfObservations[0]];
                c[0] += alpha[state][0];
            }

            // scale the α0(i)
            c[0] = 1 / c[0];
            foreach (var state in StateSpace)
                alpha[state][0] *= c[0];


            // compute αt(i)
            for (var t = 1; t < T; t++)
            {

                c[t] = 0;
                foreach (var iState in StateSpace)
                {
                    alpha[iState][t] = 0;
                    foreach (var jState in StateSpace)
                    {
                        alpha[iState][t] += alpha[jState][t - 1] * TransitionMatrix[jState, iState];
                    }
                    alpha[iState][t] *= EmissionMatrix[iState, SequenceOfObservations[t]];
                    c[t] += alpha[iState][t];

                    //  fb[iState][t] = EmissionMatrix[iState, SequenceOfObservations[t]]*
                    //  StateSpace.Sum(lState => fb[lState][t - 1]*TransitionMatrix[lState, iState]);
                }


                // scale αt(i)
                c[t] = 1 / c[t];
                foreach (var iState in StateSpace)
                    alpha[iState][t] *= c[t];
            }
        }

        private void BetaPass()
        {
            // Let βT −1(i) = 1 scaled by cT −1
            foreach (var iState in StateSpace)
            {
                beta[iState][T - 1] = c[T - 1];
            }

            // β-pass
            for (var t = T - 2; t >= 0; t--)
                foreach (var iState in StateSpace)
                {
                    beta[iState][t] = 0;
                    foreach (var jState in StateSpace)
                    {
                        beta[iState][t] += TransitionMatrix[iState, jState]*
                                           EmissionMatrix[jState, SequenceOfObservations[t + 1]]*beta[jState][t + 1];
                    }
                    // scale βt(i) with same scale factor as αt(i)

                    beta[iState][t] *= c[t];
                }
        }
    }
}