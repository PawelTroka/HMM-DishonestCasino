using System;

namespace HMMDishonestCasino.Casino
{
    public class Dice
    {
        protected Random random;

        public Dice(int numberOfSides, Random random)
        {
            NumberOfSides = numberOfSides;
            this.random = random;
        }

        //protected int numberOfSides;
        public virtual int NumberOfSides { get; set; }

        public virtual int Roll()
        {
            return random.Next(1, NumberOfSides + 1);
        }
    }
}