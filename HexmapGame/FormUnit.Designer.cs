namespace HexmapGame
{
    partial class FormUnit
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
            pictureBoxUnit = new PictureBox();
            panelUnit = new Panel();
            labelUnitType = new Label();
            labelMPv = new Label();
            labelAVv = new Label();
            labelHPv = new Label();
            labelMP = new Label();
            labelAV = new Label();
            labelHP = new Label();
            labelUnit = new Label();
            numericUpDownX = new NumericUpDown();
            numericUpDownY = new NumericUpDown();
            buttonAdd = new Button();
            comboBoxUnit = new ComboBox();
            labelColumn = new Label();
            labelRow = new Label();
            panel1 = new Panel();
            labelU = new Label();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUnit).BeginInit();
            panelUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownY).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxUnit
            // 
            pictureBoxUnit.Location = new Point(156, 3);
            pictureBoxUnit.Name = "pictureBoxUnit";
            pictureBoxUnit.Size = new Size(60, 60);
            pictureBoxUnit.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxUnit.TabIndex = 0;
            pictureBoxUnit.TabStop = false;
            // 
            // panelUnit
            // 
            panelUnit.Controls.Add(labelUnitType);
            panelUnit.Controls.Add(labelMPv);
            panelUnit.Controls.Add(labelAVv);
            panelUnit.Controls.Add(pictureBoxUnit);
            panelUnit.Controls.Add(labelHPv);
            panelUnit.Controls.Add(labelMP);
            panelUnit.Controls.Add(labelAV);
            panelUnit.Controls.Add(labelHP);
            panelUnit.Controls.Add(labelUnit);
            panelUnit.Location = new Point(218, 12);
            panelUnit.Name = "panelUnit";
            panelUnit.Size = new Size(219, 83);
            panelUnit.TabIndex = 2;
            // 
            // labelUnitType
            // 
            labelUnitType.AutoSize = true;
            labelUnitType.Location = new Point(3, 15);
            labelUnitType.Name = "labelUnitType";
            labelUnitType.Size = new Size(56, 15);
            labelUnitType.TabIndex = 10;
            labelUnitType.Text = "Unit Type";
            // 
            // labelMPv
            // 
            labelMPv.AutoSize = true;
            labelMPv.Location = new Point(85, 60);
            labelMPv.Name = "labelMPv";
            labelMPv.Size = new Size(56, 15);
            labelMPv.TabIndex = 8;
            labelMPv.Text = "labelMPv";
            // 
            // labelAVv
            // 
            labelAVv.AutoSize = true;
            labelAVv.Location = new Point(85, 45);
            labelAVv.Name = "labelAVv";
            labelAVv.Size = new Size(52, 15);
            labelAVv.TabIndex = 7;
            labelAVv.Text = "labelAVv";
            // 
            // labelHPv
            // 
            labelHPv.AutoSize = true;
            labelHPv.Location = new Point(85, 30);
            labelHPv.Name = "labelHPv";
            labelHPv.Size = new Size(54, 15);
            labelHPv.TabIndex = 6;
            labelHPv.Text = "labelHPv";
            // 
            // labelMP
            // 
            labelMP.AutoSize = true;
            labelMP.Location = new Point(3, 60);
            labelMP.Name = "labelMP";
            labelMP.Size = new Size(73, 15);
            labelMP.TabIndex = 4;
            labelMP.Text = "Move Points";
            // 
            // labelAV
            // 
            labelAV.AutoSize = true;
            labelAV.Location = new Point(3, 45);
            labelAV.Name = "labelAV";
            labelAV.Size = new Size(72, 15);
            labelAV.TabIndex = 3;
            labelAV.Text = "Attack Value";
            // 
            // labelHP
            // 
            labelHP.AutoSize = true;
            labelHP.Location = new Point(3, 30);
            labelHP.Name = "labelHP";
            labelHP.Size = new Size(78, 15);
            labelHP.TabIndex = 2;
            labelHP.Text = "Health Points";
            // 
            // labelUnit
            // 
            labelUnit.AutoSize = true;
            labelUnit.Location = new Point(3, 0);
            labelUnit.Name = "labelUnit";
            labelUnit.Size = new Size(76, 15);
            labelUnit.TabIndex = 0;
            labelUnit.Text = "Selected Unit";
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
            // numericUpDownY
            // 
            numericUpDownY.Location = new Point(3, 60);
            numericUpDownY.Maximum = new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownY.Name = "numericUpDownY";
            numericUpDownY.Size = new Size(120, 23);
            numericUpDownY.TabIndex = 4;
            numericUpDownY.ValueChanged += numericUpDownY_ValueChanged;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(337, 100);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(100, 48);
            buttonAdd.TabIndex = 5;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // comboBoxUnit
            // 
            comboBoxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUnit.FormattingEnabled = true;
            comboBoxUnit.Location = new Point(3, 105);
            comboBoxUnit.Name = "comboBoxUnit";
            comboBoxUnit.Size = new Size(120, 23);
            comboBoxUnit.TabIndex = 6;
            comboBoxUnit.SelectedIndexChanged += comboBoxUnit_SelectedIndexChanged;
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
            // labelRow
            // 
            labelRow.AutoSize = true;
            labelRow.Location = new Point(3, 44);
            labelRow.Name = "labelRow";
            labelRow.Size = new Size(62, 15);
            labelRow.TabIndex = 8;
            labelRow.Text = "Row Index";
            // 
            // panel1
            // 
            panel1.Controls.Add(labelU);
            panel1.Controls.Add(labelRow);
            panel1.Controls.Add(comboBoxUnit);
            panel1.Controls.Add(labelColumn);
            panel1.Controls.Add(numericUpDownY);
            panel1.Controls.Add(numericUpDownX);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 136);
            panel1.TabIndex = 9;
            // 
            // labelU
            // 
            labelU.AutoSize = true;
            labelU.Location = new Point(3, 88);
            labelU.Name = "labelU";
            labelU.Size = new Size(29, 15);
            labelU.TabIndex = 9;
            labelU.Text = "Unit";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(218, 100);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(100, 48);
            buttonDelete.TabIndex = 10;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // FormUnit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 161);
            Controls.Add(buttonDelete);
            Controls.Add(panel1);
            Controls.Add(buttonAdd);
            Controls.Add(panelUnit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormUnit";
            Text = "Unit Management";
            Load += FormUnit_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxUnit).EndInit();
            panelUnit.ResumeLayout(false);
            panelUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownY).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxUnit;
        private Panel panelUnit;
        private Label labelUnitType;
        private Label labelMPv;
        private Label labelAVv;
        private Label labelHPv;
        private Label labelMP;
        private Label labelAV;
        private Label labelHP;
        private Label labelUnit;
        private NumericUpDown numericUpDownX;
        private NumericUpDown numericUpDownY;
        private Button buttonAdd;
        private ComboBox comboBoxUnit;
        private Label labelColumn;
        private Label labelRow;
        private Panel panel1;
        private Label labelU;
        private Button buttonDelete;
    }
}