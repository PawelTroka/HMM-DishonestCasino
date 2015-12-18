using HMMDishonestCasino.Controls.DataGridViewNumericUpDownElements;

namespace HMMDishonestCasino
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.probalbilitiesOfEachNumberDataGridView = new System.Windows.Forms.DataGridView();
            this.NumbersColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProbabilitiesColumn = new DataGridViewNumericUpDownColumn();
            this.outputSequenceListBox = new System.Windows.Forms.ListBox();
            this.emitButton = new System.Windows.Forms.Button();
            this.emitNTimesCheckBox = new System.Windows.Forms.CheckBox();
            this.nTimesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numberOfSidesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.switchToFairDiceProbabilityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.switchToUnfairDiceProbabilityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewNumericUpDownColumn1 = new DataGridViewNumericUpDownColumn();
            ((System.ComponentModel.ISupportInitialize)(this.probalbilitiesOfEachNumberDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTimesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfSidesNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.switchToFairDiceProbabilityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchToUnfairDiceProbabilityNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // probalbilitiesOfEachNumberDataGridView
            // 
            this.probalbilitiesOfEachNumberDataGridView.AllowUserToAddRows = false;
            this.probalbilitiesOfEachNumberDataGridView.AllowUserToDeleteRows = false;
            this.probalbilitiesOfEachNumberDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.probalbilitiesOfEachNumberDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.probalbilitiesOfEachNumberDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumbersColumn,
            this.ProbabilitiesColumn});
            this.probalbilitiesOfEachNumberDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.probalbilitiesOfEachNumberDataGridView.Location = new System.Drawing.Point(5, 55);
            this.probalbilitiesOfEachNumberDataGridView.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.probalbilitiesOfEachNumberDataGridView.Name = "probalbilitiesOfEachNumberDataGridView";
            this.probalbilitiesOfEachNumberDataGridView.Size = new System.Drawing.Size(437, 345);
            this.probalbilitiesOfEachNumberDataGridView.TabIndex = 0;
            // 
            // NumbersColumn
            // 
            this.NumbersColumn.HeaderText = "Number";
            this.NumbersColumn.MinimumWidth = 100;
            this.NumbersColumn.Name = "NumbersColumn";
            this.NumbersColumn.ReadOnly = true;
            // 
            // ProbabilitiesColumn
            // 
            this.ProbabilitiesColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProbabilitiesColumn.DecimalPlaces = 3;
            this.ProbabilitiesColumn.HeaderText = "Probability";
            this.ProbabilitiesColumn.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.ProbabilitiesColumn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ProbabilitiesColumn.Name = "ProbabilitiesColumn";
            // 
            // outputSequenceListBox
            // 
            this.outputSequenceListBox.ColumnWidth = 30;
            this.outputSequenceListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputSequenceListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputSequenceListBox.FormattingEnabled = true;
            this.outputSequenceListBox.ItemHeight = 18;
            this.outputSequenceListBox.Location = new System.Drawing.Point(3, 27);
            this.outputSequenceListBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.outputSequenceListBox.MultiColumn = true;
            this.outputSequenceListBox.Name = "outputSequenceListBox";
            this.outputSequenceListBox.Size = new System.Drawing.Size(964, 174);
            this.outputSequenceListBox.TabIndex = 1;
            // 
            // emitButton
            // 
            this.emitButton.Location = new System.Drawing.Point(14, 18);
            this.emitButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.emitButton.Name = "emitButton";
            this.emitButton.Size = new System.Drawing.Size(192, 44);
            this.emitButton.TabIndex = 2;
            this.emitButton.Text = "Emit";
            this.emitButton.UseVisualStyleBackColor = true;
            this.emitButton.Click += new System.EventHandler(this.EmitButton_Click);
            // 
            // emitNTimesCheckBox
            // 
            this.emitNTimesCheckBox.AutoSize = true;
            this.emitNTimesCheckBox.Location = new System.Drawing.Point(216, 27);
            this.emitNTimesCheckBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.emitNTimesCheckBox.Name = "emitNTimesCheckBox";
            this.emitNTimesCheckBox.Size = new System.Drawing.Size(196, 29);
            this.emitNTimesCheckBox.TabIndex = 3;
            this.emitNTimesCheckBox.Text = "Emit N times, N =";
            this.emitNTimesCheckBox.UseVisualStyleBackColor = true;
            // 
            // nTimesNumericUpDown
            // 
            this.nTimesNumericUpDown.Location = new System.Drawing.Point(422, 26);
            this.nTimesNumericUpDown.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.nTimesNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nTimesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nTimesNumericUpDown.Name = "nTimesNumericUpDown";
            this.nTimesNumericUpDown.Size = new System.Drawing.Size(80, 31);
            this.nTimesNumericUpDown.TabIndex = 4;
            this.nTimesNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of sides of dice =";
            // 
            // numberOfSidesNumericUpDown
            // 
            this.numberOfSidesNumericUpDown.Location = new System.Drawing.Point(346, 78);
            this.numberOfSidesNumericUpDown.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.numberOfSidesNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numberOfSidesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfSidesNumericUpDown.Name = "numberOfSidesNumericUpDown";
            this.numberOfSidesNumericUpDown.Size = new System.Drawing.Size(85, 31);
            this.numberOfSidesNumericUpDown.TabIndex = 7;
            this.numberOfSidesNumericUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numberOfSidesNumericUpDown.ValueChanged += new System.EventHandler(this.numberOfSidesNumericUpDown_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.probalbilitiesOfEachNumberDataGridView);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(523, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Size = new System.Drawing.Size(447, 406);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unfair dice properties";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(5, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Probabilities of each number:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.switchToFairDiceProbabilityNumericUpDown);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.switchToUnfairDiceProbabilityNumericUpDown);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numberOfSidesNumericUpDown);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Size = new System.Drawing.Size(523, 406);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Casino properties";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.emitNTimesCheckBox);
            this.panel2.Controls.Add(this.emitButton);
            this.panel2.Controls.Add(this.nTimesNumericUpDown);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 329);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 71);
            this.panel2.TabIndex = 10;
            // 
            // switchToFairDiceProbabilityNumericUpDown
            // 
            this.switchToFairDiceProbabilityNumericUpDown.DecimalPlaces = 3;
            this.switchToFairDiceProbabilityNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.switchToFairDiceProbabilityNumericUpDown.Location = new System.Drawing.Point(346, 148);
            this.switchToFairDiceProbabilityNumericUpDown.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.switchToFairDiceProbabilityNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.switchToFairDiceProbabilityNumericUpDown.Name = "switchToFairDiceProbabilityNumericUpDown";
            this.switchToFairDiceProbabilityNumericUpDown.Size = new System.Drawing.Size(115, 31);
            this.switchToFairDiceProbabilityNumericUpDown.TabIndex = 11;
            this.switchToFairDiceProbabilityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.switchToFairDiceProbabilityNumericUpDown.ValueChanged += new System.EventHandler(this.switchToFairDiceProbabilityNumericUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Switch to fair dice probability =";
            // 
            // switchToUnfairDiceProbabilityNumericUpDown
            // 
            this.switchToUnfairDiceProbabilityNumericUpDown.DecimalPlaces = 3;
            this.switchToUnfairDiceProbabilityNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.switchToUnfairDiceProbabilityNumericUpDown.Location = new System.Drawing.Point(346, 225);
            this.switchToUnfairDiceProbabilityNumericUpDown.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.switchToUnfairDiceProbabilityNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.switchToUnfairDiceProbabilityNumericUpDown.Name = "switchToUnfairDiceProbabilityNumericUpDown";
            this.switchToUnfairDiceProbabilityNumericUpDown.Size = new System.Drawing.Size(115, 31);
            this.switchToUnfairDiceProbabilityNumericUpDown.TabIndex = 9;
            this.switchToUnfairDiceProbabilityNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.switchToUnfairDiceProbabilityNumericUpDown.ValueChanged += new System.EventHandler(this.switchToUnfairDiceProbabilityNumericUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 227);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(328, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Switch to unfair dice probability =";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.outputSequenceListBox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 406);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(970, 204);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output sequence:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 406);
            this.panel1.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Number";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewNumericUpDownColumn1
            // 
            this.dataGridViewNumericUpDownColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewNumericUpDownColumn1.DecimalPlaces = 3;
            this.dataGridViewNumericUpDownColumn1.HeaderText = "Probability";
            this.dataGridViewNumericUpDownColumn1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.dataGridViewNumericUpDownColumn1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dataGridViewNumericUpDownColumn1.Name = "dataGridViewNumericUpDownColumn1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 610);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MinimumSize = new System.Drawing.Size(840, 550);
            this.Name = "MainForm";
            this.Text = "HMM-DishonestCasino : Pawel Troka, Krzysztof Pastuszak, Marta Pazderska";
            ((System.ComponentModel.ISupportInitialize)(this.probalbilitiesOfEachNumberDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTimesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfSidesNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.switchToFairDiceProbabilityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switchToUnfairDiceProbabilityNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.DataGridView probalbilitiesOfEachNumberDataGridView;
        private System.Windows.Forms.ListBox outputSequenceListBox;
        private System.Windows.Forms.Button emitButton;
        private System.Windows.Forms.CheckBox emitNTimesCheckBox;
        private System.Windows.Forms.NumericUpDown nTimesNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numberOfSidesNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown switchToUnfairDiceProbabilityNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown switchToFairDiceProbabilityNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumbersColumn;
        private DataGridViewNumericUpDownColumn ProbabilitiesColumn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn1;
    }
}

