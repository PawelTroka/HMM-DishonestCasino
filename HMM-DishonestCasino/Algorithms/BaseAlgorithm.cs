//#define _USE_ARRAYS_INSTEAD_OF_MATRIX_HASHTABLE

using System;
using System.Collections.Generic;
using System.Linq;
using HMMDishonestCasino.Collections;

namespace HMMDishonestCasino.Algorithms
{
    public abstract class BaseAlgorithm<TObservation, TState>
    {
        protected BaseAlgorithm()
        {
        }

        protected BaseAlgorithm(BaseAlgorithm<TObservation, TState> baseAlgorithm)
        {
            ObservationSpace = baseAlgorithm.ObservationSpace;
            StateSpace = baseAlgorithm.StateSpace;
            SequenceOfObservations = baseAlgorithm.SequenceOfObservations;
            ObservationSpace = baseAlgorithm.ObservationSpace;
            TransitionMatrix = baseAlgorithm.TransitionMatrix;

            TransitionMatrix = baseAlgorithm.TransitionMatrix;
            EmissionMatrix = baseAlgorithm.EmissionMatrix;
            InitialProbabilitiesOfStates = baseAlgorithm.InitialProbabilitiesOfStates;
        }

        public int N => ObservationSpace.Length; // count of all possible results

        public int K => StateSpace.Length; // count of all possible states

        public int T => SequenceOfObservations.Length; // count of all observations done

        public TObservation[] ObservationSpace { get; set; } //space of all possible results // size N

        public TState[] StateSpace { get; set; } //space of all possible states // size  K

        public TObservation[] SequenceOfObservations { get; set; } //actual results // size T

#if _USE_ARRAYS_INSTEAD_OF_MATRIX_HASHTABLE
        public double[,] TransitionMatrix { get; set; } // size K*K
        public double[,] EmissionMatrix { get; set; } // size K*N
        public double[] InitialProbabilitiesOfStates { get; set; } // size K
#else
        public MatrixHashTable<TState, TState, double> TransitionMatrix { get; set; } // size K*K
        public MatrixHashTable<TState, TObservation, double> EmissionMatrix { get; set; } // size K*N
        public Dictionary<TState, double> InitialProbabilitiesOfStates { get; set; } // size K
#endif

        // public List<int> Input { get; set; }


        public virtual void DoWork()
        {
            ValidateParameters();
        }

        private void ValidateParameters()
        {
            if (EmissionMatrix == null || TransitionMatrix == null || SequenceOfObservations == null ||
                StateSpace == null || ObservationSpace == null)
                throw new ArgumentException("Parameters cannot be null");

            if (ObservationSpace.Length != EmissionMatrix.GetLength(1) || ObservationSpace.Length == 0)
                throw new ArgumentException("N should be greater than 0 and consistent");

#if _USE_ARRAYS_INSTEAD_OF_MATRIX_HASHTABLE
                        if (StateSpace.Length != TransitionMatrix.GetLength(0) || TransitionMatrix.GetLength(0) != TransitionMatrix.GetLength(1) || TransitionMatrix.GetLength(1)!= EmissionMatrix.GetLength(0)|| EmissionMatrix.GetLength(0)!= InitialProbabilitiesOfStates.Length || StateSpace.Length==0)
                throw new ArgumentException("K should be greater than 0 and consistent");
#else

            if (StateSpace.Length != TransitionMatrix.GetLength(0) ||
                TransitionMatrix.GetLength(0) != TransitionMatrix.GetLength(1) ||
                TransitionMatrix.GetLength(1) != EmissionMatrix.GetLength(0) ||
                EmissionMatrix.GetLength(0) != InitialProbabilitiesOfStates.Count || StateSpace.Length == 0)
                throw new ArgumentException("K should be greater than 0 and consistent");
#endif
            if (SequenceOfObservations.Length == 0)
                throw new ArgumentException("T should be greater than 0 and consistent");

            if (
                StateSpace.Select(state => ObservationSpace.Sum(observation => EmissionMatrix[state, observation]))
                    .Any(sum => sum <= 0.99 || sum >= 1.01))
            {
                throw new ArgumentException("EmissionMatrix has not normalized probabilities"); //Exception("Emi");
            }

            if (
                StateSpace.Select(state1 => StateSpace.Sum(state2 => TransitionMatrix[state1, state2]))
                    .Any(sum => sum <= 0.99 || sum >= 1.01))
            {
                throw new ArgumentException("TransitionMatrix has not normalized probabilities"); //Exception("Emi");
            }
        }
    }
}