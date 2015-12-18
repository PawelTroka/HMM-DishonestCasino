namespace HMMDishonestCasino.Casino
{
    public class Probabilities
    {
        public Probabilities(int number, decimal probability)
        {
            Number = number;
            Probability = probability;
        }


        public Probabilities(Probabilities probabilities)
        {
            Number = probabilities.Number;
            Probability = probabilities.Probability;
        }

        public int Number { get; set; }

        public decimal Probability { get; set; }
    }
}