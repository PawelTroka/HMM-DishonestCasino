namespace HMMDishonestCasino.Algorithms.Prediction
{
    public class APosterioriAlgorithm<TObservation, TState> : PredictionAlgorithm<TObservation, TState>
    {
        public APosterioriAlgorithm()
        {
        }

        public APosterioriAlgorithm(BaseAlgorithm<TObservation, TState> baseAlgorithm) : base(baseAlgorithm)
        {
        }

        public override void DoWork()
        {
            base.DoWork();

            //throw new NotImplementedException();
        }
    }
}