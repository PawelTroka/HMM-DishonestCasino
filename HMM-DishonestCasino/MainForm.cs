using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HMMDishonestCasino.Algorithms;
using HMMDishonestCasino.Casino;
using HMMDishonestCasino.Collections;
using HMMDishonestCasino.Controls.DataGridViewNumericUpDownElements;

namespace HMMDishonestCasino
{
    public partial class MainForm : Form
    {
        public BaseAlgorithm<int, StateSpace> viterbiAlgorithm, aposterioriAlgorithm;
        private readonly DishonestCasino casino;
        public MainForm()
        {
            casino = new DishonestCasino();
            InitializeComponent();
            probalbilitiesOfEachNumberDataGridView.DataSource = casino.UnfairProbabilities;

            //probalbilitiesOfEachNumberDataGridView.DataBindings.Add()
            NumbersColumn.DataPropertyName = "Number";
            ProbabilitiesColumn.DataPropertyName = "Probability";

            //dirty hack, will do for now
            probalbilitiesOfEachNumberDataGridView.Columns.RemoveAt(
                probalbilitiesOfEachNumberDataGridView.Columns.Count - 1);
            probalbilitiesOfEachNumberDataGridView.Columns.RemoveAt(
                probalbilitiesOfEachNumberDataGridView.Columns.Count - 1);
            //probalbilitiesOfEachNumberDataGridView.Columns[0].DataPropertyName = "Number";
            //probalbilitiesOfEachNumberDataGridView.Columns[1].DataPropertyName = "Probability";
            //probalbilitiesOfEachNumberDataGridView.Rows.Add(1, 0.1);
            //probalbilitiesOfEachNumberDataGridView.CellValueChanged += ProbalbilitiesOfEachNumberDataGridView_CellValueChanged;
            //probalbilitiesOfEachNumberDataGridView.RowsAdded += ProbalbilitiesOfEachNumberDataGridView_RowsAdded;
            //probalbilitiesOfEachNumberDataGridView.RowsRemoved += ProbalbilitiesOfEachNumberDataGridView_RowsRemoved;
        }

        private void EmitButton_Click(object sender, EventArgs e)
        {
            casino.ValidateState();

            if (clearOutputsCheckBox.Checked)
            {
                casino.History.Clear();
                outputSequenceListBox.Items.Clear();
            }

            if (emitNTimesCheckBox.Checked)
                for (var i = 0; i < nTimesNumericUpDown.Value; i++)
                {
                    outputSequenceListBox.Items.Add(casino.Emit());
                }
            else
            {
                outputSequenceListBox.Items.Add(casino.Emit());
            }

        }

        private void numberOfSidesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (numberOfSidesNumericUpDown.Value > casino.UnfairProbabilities.Count)
            {
                while (numberOfSidesNumericUpDown.Value != casino.UnfairProbabilities.Count)
                    casino.UnfairProbabilities.Add(new Probabilities(casino.UnfairProbabilities.Count + 1, 0m));
            }
            else if (numberOfSidesNumericUpDown.Value < casino.UnfairProbabilities.Count)
            {
                while (numberOfSidesNumericUpDown.Value != casino.UnfairProbabilities.Count)
                    casino.UnfairProbabilities.RemoveAt(casino.UnfairProbabilities.Count - 1);
            }
            casino.NumberOfSides = (int)numberOfSidesNumericUpDown.Value;
        }

        private void switchToFairDiceProbabilityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            casino.SwitchToFairDiceProbability = switchToFairDiceProbabilityNumericUpDown.Value;
        }

        private void switchToUnfairDiceProbabilityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            casino.SwitchToUnfairDiceProbability = switchToUnfairDiceProbabilityNumericUpDown.Value;
        }

        private void makeComparisonButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            InitAlgorithms();
            viterbiAlgorithm.DoWork();
            aposterioriAlgorithm.DoWork();

            for (int index  = 0; index < casino.History.Count; index++)
            {
                dataGridView1.Rows.Add(casino.History[index].Result, viterbiAlgorithm.Output[index],
                    casino.History[index].StateSpace
                    /*, aposterioriAlgorithm.Output[index]*/);
            }

            var sumOfViterbiMatches = 0.0;
            var sumOfAposterioriMatches = 0.0;
            for (int i = 0; i < casino.History.Count; i++)
            {
                sumOfViterbiMatches += (casino.History[i].StateSpace == viterbiAlgorithm.Output[i]) ? 1 : 0;
                //sumOfAposterioriMatches += (casino.History[i].StateSpace == aposterioriAlgorithm.Output[i]) ? 1 : 0;
            }

            MessageBox.Show(
                $"Viterbi match = {100*sumOfViterbiMatches/casino.History.Count}%\nAPosteriori match = {100 * sumOfAposterioriMatches /casino.History.Count}%");
        }

        private void InitAlgorithms()
        {
            var stateSpace = new StateSpace[] {StateSpace.FairDice, StateSpace.LoadedDice,};
            var observationSpace = Enumerable.Range(1, (int) numberOfSidesNumericUpDown.Value).ToArray();

            aposterioriAlgorithm = new APosterioriAlgorithm<int, StateSpace>()
            {
                StateSpace = stateSpace,
                ObservationSpace = Enumerable.Range(1, casino.NumberOfSides).ToArray(),
                SequenceOfObservations = casino.History.Select(el => el.Result).ToArray(),
                ArrayOfInitialProbabilitiesOfStates = new Dictionary<StateSpace, decimal>()
                {
                    {StateSpace.FairDice, casino.SwitchToFairDiceProbability},
                    {StateSpace.LoadedDice, casino.SwitchToUnfairDiceProbability}
                },
                TransitionMatrix = new MatrixHashTable<StateSpace, StateSpace, decimal>(stateSpace, stateSpace)
                {
                    [StateSpace.FairDice, StateSpace.FairDice] = 1 - casino.SwitchToUnfairDiceProbability,
                    [StateSpace.FairDice, StateSpace.LoadedDice] = casino.SwitchToUnfairDiceProbability,
                    [StateSpace.LoadedDice, StateSpace.FairDice] = casino.SwitchToFairDiceProbability,
                    [StateSpace.LoadedDice, StateSpace.LoadedDice] = 1 - casino.SwitchToFairDiceProbability,
                },
                EmissionMatrix = new MatrixHashTable<StateSpace, int, decimal>(stateSpace, observationSpace)
            };

            viterbiAlgorithm = new ViterbiAlgorithm<int, StateSpace>()
            {
                StateSpace = stateSpace,
                ObservationSpace = Enumerable.Range(1, casino.NumberOfSides).ToArray(),
                SequenceOfObservations = casino.History.Select(el => el.Result).ToArray(),
                ArrayOfInitialProbabilitiesOfStates = new Dictionary<StateSpace, decimal>()
                {
                    {StateSpace.FairDice, casino.SwitchToFairDiceProbability},
                    {StateSpace.LoadedDice, casino.SwitchToUnfairDiceProbability}
                },
                TransitionMatrix = new MatrixHashTable<StateSpace, StateSpace, decimal>(stateSpace, stateSpace)
                {
                    [StateSpace.FairDice, StateSpace.FairDice] = 1 - casino.SwitchToUnfairDiceProbability,
                    [StateSpace.FairDice, StateSpace.LoadedDice] = casino.SwitchToUnfairDiceProbability,
                    [StateSpace.LoadedDice, StateSpace.FairDice] = casino.SwitchToFairDiceProbability,
                    [StateSpace.LoadedDice, StateSpace.LoadedDice] = 1 - casino.SwitchToFairDiceProbability,
                },
                EmissionMatrix = new MatrixHashTable<StateSpace, int, decimal>(stateSpace, observationSpace)
            };


            for (int i = 1; i <= casino.NumberOfSides; i++)
            {
                viterbiAlgorithm.EmissionMatrix[StateSpace.FairDice, i] = 1.0m/casino.NumberOfSides;
                viterbiAlgorithm.EmissionMatrix[StateSpace.LoadedDice, i] = (decimal)probalbilitiesOfEachNumberDataGridView[1, i-1].Value;

                aposterioriAlgorithm.EmissionMatrix[StateSpace.FairDice, i] = 1.0m / casino.NumberOfSides;
                aposterioriAlgorithm.EmissionMatrix[StateSpace.LoadedDice, i] = (decimal)probalbilitiesOfEachNumberDataGridView[1, i - 1].Value;
            }
            
        }
    }
}