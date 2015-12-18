using System;
using System.Windows.Forms;
using HMMDishonestCasino.Casino;
using HMMDishonestCasino.Controls.DataGridViewNumericUpDownElements;

namespace HMMDishonestCasino
{
    public partial class MainForm : Form
    {
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

        private void ProbalbilitiesOfEachNumberDataGridView_RowsRemoved(object sender,
            DataGridViewRowsRemovedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void ProbalbilitiesOfEachNumberDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ProbalbilitiesOfEachNumberDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (probalbilitiesOfEachNumberDataGridView[e.ColumnIndex, e.RowIndex] is DataGridViewNumericUpDownCell)
            {
            }
        }

        private void EmitButton_Click(object sender, EventArgs e)
        {
            casino.ValidateState();

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
            casino.NumberOfSides = (int) numberOfSidesNumericUpDown.Value;
        }

        private void switchToFairDiceProbabilityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            casino.SwitchToFairDiceProbability = switchToFairDiceProbabilityNumericUpDown.Value;
        }

        private void switchToUnfairDiceProbabilityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            casino.SwitchToUnfairDiceProbability = switchToUnfairDiceProbabilityNumericUpDown.Value;
        }
    }
}