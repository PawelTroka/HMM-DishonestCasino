//#define _USE_ARRAYS_INSTEAD_OF_MATRIX_HASHTABLE
using System;
using System.Collections.Generic;
using HMMDishonestCasino.Collections;


namespace HMMDishonestCasino.Algorithms
{
    public abstract class BaseAlgorithm<TObservation, TState>
    {
        public int N => ObservationSpace.Length; // count of all possible results

        public int K => StateSpace.Length; // count of all possible states

        public int T => SequenceOfObservations.Length; // count of all observations done

        public TObservation[] ObservationSpace { get; set; } //space of all possible results // size N
        
        public TState[] StateSpace { get; set; } //space of all possible states // size  K

        public TObservation[] SequenceOfObservations { get; set; } //actual results // size T

#if _USE_ARRAYS_INSTEAD_OF_MATRIX_HASHTABLE
        public decimal[,] TransitionMatrix { get; set; } // size K*K
        public decimal[,] EmmisionMatrix { get; set; } // size K*N
        public decimal[] ArrayOfInitialProbabilitiesOfStates { get; set; } // size K
#else
        public MatrixHashTable<TState, TState,decimal> TransitionMatrix { get; set; } // size K*K
        public MatrixHashTable<TState, TObservation, decimal> EmmisionMatrix { get; set; } // size K*N
        public Dictionary<TState,decimal> ArrayOfInitialProbabilitiesOfStates { get; set; } // size K
#endif

        // public List<int> Input { get; set; }
        public TState[] Output { get; set; } //possible sequence of states // size T 

        public virtual void DoWork()
        {
            ValidateParameters();
        }

        private void ValidateParameters()
        {
            if(EmmisionMatrix==null|| TransitionMatrix==null|| SequenceOfObservations==null|| StateSpace==null|| ObservationSpace==null)
                throw new ArgumentException("Parameters cannot be null");

            if(ObservationSpace.Length != EmmisionMatrix.GetLength(1)|| ObservationSpace.Length==0)
                throw new ArgumentException("N should be greater than 0 and consistent");

#if _USE_ARRAYS_INSTEAD_OF_MATRIX_HASHTABLE
                        if (StateSpace.Length != TransitionMatrix.GetLength(0) || TransitionMatrix.GetLength(0) != TransitionMatrix.GetLength(1) || TransitionMatrix.GetLength(1)!= EmmisionMatrix.GetLength(0)|| EmmisionMatrix.GetLength(0)!= ArrayOfInitialProbabilitiesOfStates.Length || StateSpace.Length==0)
                throw new ArgumentException("K should be greater than 0 and consistent");
#else

            if (StateSpace.Length != TransitionMatrix.GetLength(0) || TransitionMatrix.GetLength(0) != TransitionMatrix.GetLength(1) || TransitionMatrix.GetLength(1)!= EmmisionMatrix.GetLength(0)|| EmmisionMatrix.GetLength(0)!= ArrayOfInitialProbabilitiesOfStates.Count || StateSpace.Length==0)
                throw new ArgumentException("K should be greater than 0 and consistent");
#endif
            if(SequenceOfObservations.Length==0)
                throw new ArgumentException("T should be greater than 0 and consistent");
        }
    }
}