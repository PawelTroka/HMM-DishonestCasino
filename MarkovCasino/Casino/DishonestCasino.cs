using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace HMMDishonestCasino.Casino
{
    public class DishonestCasino
    {
        private const int DEFAULT_NUMBER_OF_SIDES = 6;

        private readonly LoadedDice _loadedDice;

        private Dice currentDice;
        private readonly Dice fairDice;

        private readonly Random random;

        public DishonestCasino()
        {
            random = new Random();
            fairDice = new Dice(DEFAULT_NUMBER_OF_SIDES, random);
            _loadedDice = new LoadedDice(DEFAULT_NUMBER_OF_SIDES, random);
            currentDice = fairDice;
        }

        public int NumberOfSides
        {
            get { return fairDice.NumberOfSides; }
            set { fairDice.NumberOfSides = _loadedDice.NumberOfSides = value; }
        }

        public List<CasinoState> History { get; } = new List<CasinoState>();

        public BindingList<Probabilities> UnfairProbabilities
        {
            get { return _loadedDice.Probabilities; }
            set { _loadedDice.Probabilities = value; }
        }

        public decimal SwitchToFairDiceProbability { get; set; } = 0.1m;
        public decimal SwitchToUnfairDiceProbability { get; set; } = 0.05m;

        public int Emit()
        {
            TrySwitchDice();
            var result = currentDice.Roll();
            History.Add(new CasinoState(currentDice is LoadedDice, result));
            return result;
        }

        private void TrySwitchDice()
        {
            var randomValue = (decimal) random.NextDouble();
            if (currentDice is LoadedDice && randomValue <= SwitchToFairDiceProbability)
                currentDice = fairDice;
            else if (randomValue <= SwitchToUnfairDiceProbability)
                currentDice = _loadedDice;
        }

        public void ValidateState()
        {
            if (currentDice == null || _loadedDice == null || fairDice == null || _loadedDice.Probabilities == null ||
                UnfairProbabilities == null)
                throw new Exception();

            if (currentDice != _loadedDice && currentDice != fairDice)
                throw new Exception();

            if (fairDice.NumberOfSides != _loadedDice.NumberOfSides)
                throw new Exception();

            if (currentDice.NumberOfSides != fairDice.NumberOfSides ||
                currentDice.NumberOfSides != _loadedDice.NumberOfSides)
                throw new Exception();
            if (UnfairProbabilities.Sum(el => el.Probability) != 1.0m)
                throw new Exception();

            if (SwitchToFairDiceProbability > 1.0m || SwitchToFairDiceProbability < 0.0m ||
                SwitchToUnfairDiceProbability < 0.0m || SwitchToUnfairDiceProbability > 1.0m)
                throw new Exception();
        }
    }
}