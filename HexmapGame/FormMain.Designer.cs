namespace HexmapGame
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxBoard = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoard).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxBoard
            // 
            pictureBoxBoard.BackColor = Color.White;
            pictureBoxBoard.Location = new Point(12, 11);
            pictureBoxBoard.Name = "pictureBoxBoard";
            pictureBoxBoard.Size = new Size(801, 590);
            pictureBoxBoard.TabIndex = 0;
            pictureBoxBoard.TabStop = false;
            pictureBoxBoard.Paint += pictureBoxBoard_Paint;
            pictureBoxBoard.MouseClick += pictureBoxBoard_MouseClick;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 621);
            Controls.Add(pictureBoxBoard);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMain";
            Text = "HexmapGame";
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxBoard;
    }
}