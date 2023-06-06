namespace HexmapGame
{
    partial class FormTerrain
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
            panel1 = new Panel();
            labelT = new Label();
            labelRow = new Label();
            comboBoxTerrain = new ComboBox();
            labelColumn = new Label();
            numericUpDownY = new NumericUpDown();
            numericUpDownX = new NumericUpDown();
            panelUnit = new Panel();
            labelCostV = new Label();
            labelCost = new Label();
            labelTerrainName = new Label();
            pictureBoxTerrain = new PictureBox();
            labelTerrain = new Label();
            buttonChange = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownX).BeginInit();
            panelUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTerrain).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(labelT);
            panel1.Controls.Add(labelRow);
            panel1.Controls.Add(comboBoxTerrain);
            panel1.Controls.Add(labelColumn);
            panel1.Controls.Add(numericUpDownY);
            panel1.Controls.Add(numericUpDownX);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 136);
            panel1.TabIndex = 10;
            // 
            // labelT
            // 
            labelT.AutoSize = true;
            labelT.Location = new Point(3, 88);
            labelT.Name = "labelT";
            labelT.Size = new Size(42, 15);
            labelT.TabIndex = 9;
            labelT.Text = "Terrain";
            // 
            // labelRow
            // 
            labelRow.AutoSize = true;
            labelRow.Location = new Point(3, 44);
            labelRow.Name = "labelRow";
            labelRow.Size = new Size(62, 15);
            labelRow.TabIndex = 8;
            labelRow.Text = "Row Index";
            // 
            // comboBoxTerrain
            // 
            comboBoxTerrain.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTerrain.FormattingEnabled = true;
            comboBoxTerrain.Location = new Point(3, 105);
            comboBoxTerrain.Name = "comboBoxTerrain";
            comboBoxTerrain.Size = new Size(120, 23);
            comboBoxTerrain.TabIndex = 6;
            comboBoxTerrain.SelectedIndexChanged += comboBoxTerrain_SelectedIndexChanged;
            // 
            // labelColumn
            // 
            labelColumn.AutoSize = true;
            labelColumn.Location = new Point(3, 0);
            labelColumn.Name = "labelColumn";
            labelColumn.Size = new Size(82, 15);
            labelColumn.TabIndex = 7;
            labelColumn.Text = "Column Index";
            // 
            // numericUpDownY
            // 
            numericUpDownY.Location = new Point(3, 60);
            numericUpDownY.Maximum = new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownY.Name = "numericUpDownY";
            numericUpDownY.Size = new Size(120, 23);
            numericUpDownY.TabIndex = 4;
            numericUpDownY.ValueChanged += numericUpDownY_ValueChanged;
            // 
            // numericUpDownX
            // 
            numericUpDownX.Location = new Point(3, 15);
            numericUpDownX.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numericUpDownX.Name = "numericUpDownX";
            numericUpDownX.Size = new Size(120, 23);
            numericUpDownX.TabIndex = 3;
            numericUpDownX.ValueChanged += numericUpDownX_ValueChanged;
            // 
            // panelUnit
            // 
            panelUnit.Controls.Add(labelCostV);
            panelUnit.Controls.Add(labelCost);
            panelUnit.Controls.Add(labelTerrainName);
            panelUnit.Controls.Add(pictureBoxTerrain);
            panelUnit.Controls.Add(labelTerrain);
            panelUnit.Location = new Point(218, 12);
            panelUnit.Name = "panelUnit";
            panelUnit.Size = new Size(219, 83);
            panelUnit.TabIndex = 10;
            // 
            // labelCostV
            // 
            labelCostV.AutoSize = true;
            labelCostV.Location = new Point(54, 30);
            labelCostV.Name = "labelCostV";
            labelCostV.Size = new Size(38, 15);
            labelCostV.TabIndex = 12;
            labelCostV.Text = "CostV";
            // 
            // labelCost
            // 
            labelCost.AutoSize = true;
            labelCost.Location = new Point(3, 30);
            labelCost.Name = "labelCost";
            labelCost.Size = new Size(31, 15);
            labelCost.TabIndex = 11;
            labelCost.Text = "Cost";
            // 
            // labelTerrainName
            // 
            labelTerrainName.AutoSize = true;
            labelTerrainName.Location = new Point(3, 15);
            labelTerrainName.Name = "labelTerrainName";
            labelTerrainName.Size = new Size(77, 15);
            labelTerrainName.TabIndex = 10;
            labelTerrainName.Text = "Terrain Name";
            // 
            // pictureBoxTerrain
            // 
            pictureBoxTerrain.Location = new Point(134, 3);
            pictureBoxTerrain.Name = "pictureBoxTerrain";
            pictureBoxTerrain.Size = new Size(60, 60);
            pictureBoxTerrain.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxTerrain.TabIndex = 0;
            pictureBoxTerrain.TabStop = false;
            pictureBoxTerrain.Paint += pictureBoxTerrain_Paint;
            // 
            // labelTerrain
            // 
            labelTerrain.AutoSize = true;
            labelTerrain.Location = new Point(3, 0);
            labelTerrain.Name = "labelTerrain";
            labelTerrain.Size = new Size(89, 15);
            labelTerrain.TabIndex = 0;
            labelTerrain.Text = "Selected Terrain";
            // 
            // buttonChange
            // 
            buttonChange.Location = new Point(218, 100);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(219, 48);
            buttonChange.TabIndex = 11;
            buttonChange.Text = "Change";
            buttonChange.UseVisualStyleBackColor = true;
            buttonChange.Click += buttonChange_Click;
            // 
            // FormTerrain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 161);
            Controls.Add(buttonChange);
            Controls.Add(panelUnit);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormTerrain";
            Text = "Edit Terrain";
            Load += FormTerrain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownX).EndInit();
            panelUnit.ResumeLayout(false);
            panelUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTerrain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelT;
        private Label labelRow;
        private ComboBox comboBoxTerrain;
        private Label labelColumn;
        private NumericUpDown numericUpDownY;
        private NumericUpDown numericUpDownX;
        private Panel panelUnit;
        private Label labelTerrainName;
        private PictureBox pictureBoxTerrain;
        private Label labelTerrain;
        private Button buttonChange;
        private Label labelCostV;
        private Label labelCost;
    }
}