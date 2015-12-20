namespace HMMDishonestCasino.Algorithms.Prediction
{
    public abstract class PredictionAlgorithm<TObservation, TState> : BaseAlgorithm<TObservation, TState>
    {
        protected PredictionAlgorithm()
        {
        }

        protected PredictionAlgorithm(BaseAlgorithm<TObservation, TState> baseAlgorithm) : base(baseAlgorithm)
        {
        }

        public TState[] Output { get; set; } //possible sequence of states // size T 
    }
}