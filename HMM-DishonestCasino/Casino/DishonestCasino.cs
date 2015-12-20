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
        private double TOLERANCE = 0.01;

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

        public double SwitchToFairDiceProbability { get; set; } = 0.1;
        public double SwitchToUnfairDiceProbability { get; set; } = 0.05;

        public int Emit()
        {
            TrySwitchDice();
            var result = currentDice.Roll();
            History.Add(new CasinoState((currentDice is LoadedDice) ? StateSpace.LoadedDice : StateSpace.FairDice, result));
            return result;
        }

        private void TrySwitchDice()
        {
            var randomValue = (double) random.NextDouble();
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
            if (Math.Abs(UnfairProbabilities.Sum(el => el.Probability) - 1.0) > TOLERANCE)
                throw new Exception();

            if (SwitchToFairDiceProbability > 1.0 || SwitchToFairDiceProbability < 0.0 ||
                SwitchToUnfairDiceProbability < 0.0 || SwitchToUnfairDiceProbability > 1.0)
                throw new Exception();
        }
    }
}