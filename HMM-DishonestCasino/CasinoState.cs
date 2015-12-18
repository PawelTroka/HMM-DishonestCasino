namespace HMMDishonestCasino
{
    public class CasinoState
    {
        public CasinoState(bool isLoadedDice, int result)
        {
            IsLoadedDice = isLoadedDice;
            Result = result;
        }

        public bool IsLoadedDice { get; set; }
        public int Result { get; set; }
    }
}