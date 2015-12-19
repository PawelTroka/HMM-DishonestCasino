namespace HMMDishonestCasino
{
    public class CasinoState
    {
        public CasinoState(StateSpace stateSpace, int result)
        {
            StateSpace = stateSpace;
            Result = result;
        }

        public StateSpace StateSpace { get; set; }
        public int Result { get; set; }
    }
}