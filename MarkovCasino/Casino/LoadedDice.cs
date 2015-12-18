using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace HMMDishonestCasino.Casino
{
    public class LoadedDice : Dice
    {
        private const decimal MAX_UNFAIR_PROBABILITY = 0.5m;

        public LoadedDice(int numberOfSides, Random random) : base(numberOfSides, random)
        {
            Probabilities = new BindingList<Probabilities>();

            //Probabilities[numberOfSides - 1] = MAX_UNFAIR_PROBABILITY;
            for (var i = 0; i < numberOfSides - 1; i++)
            {
                Probabilities.Add(new Probabilities(i + 1, (1 - MAX_UNFAIR_PROBABILITY)/(numberOfSides - 1)));
            }
            Probabilities.Add(new Probabilities(numberOfSides, MAX_UNFAIR_PROBABILITY));
        }


        public override int NumberOfSides => Probabilities.Count;

        public BindingList<Probabilities> Probabilities { get; set; } //={0.1, 0.1, 0.1, 0.1, 0.1, 0.5};


        private Probabilities[] GetDistribution() //like CDF
        {
            var cdf = new List<Probabilities>(Probabilities.ToList());
            cdf.Sort((p1, p2) => p1.Probability.CompareTo(p2.Probability));

            cdf[0] = new Probabilities(cdf[0].Number, cdf[0].Probability);
            for (var i = 1; i < cdf.Count; i++)
            {
                cdf[i] = new Probabilities(cdf[i].Number, cdf[i].Probability + cdf[i - 1].Probability);
            }

            return cdf.ToArray();
        }

        public override int Roll()
        {
            var randomValue = (decimal) random.NextDouble();

            var distribution = GetDistribution();

            foreach (var probobalities in distribution)
            {
                if (randomValue < probobalities.Probability)
                    return probobalities.Number;
            }
            throw new ArgumentException();
        }
    }
}