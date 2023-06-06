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
            panelUnit = new Panel();
            labelUnitType = new Label();
            labelAPTv = new Label();
            labelMPv = new Label();
            labelAVv = new Label();
            labelHPv = new Label();
            labelAPT = new Label();
            labelMP = new Label();
            labelAV = new Label();
            labelHP = new Label();
            labelUnit = new Label();
            buttonEndTurn = new Button();
            panelTarget = new Panel();
            labelUnitTypeT = new Label();
            labelAPTTv = new Label();
            labelMPTv = new Label();
            labelAVTv = new Label();
            labelHPTv = new Label();
            labelAPTT = new Label();
            labelMPT = new Label();
            labelAVT = new Label();
            labelHPT = new Label();
            labelUnitH = new Label();
            labelTurn = new Label();
            menuStrip = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            scenario1ToolStripMenuItem = new ToolStripMenuItem();
            scenario2ToolStripMenuItem = new ToolStripMenuItem();
            scenario3ToolStripMenuItem = new ToolStripMenuItem();
            emptyToolStripMenuItem = new ToolStripMenuItem();
            mapToolStripMenuItem = new ToolStripMenuItem();
            map1ToolStripMenuItem = new ToolStripMenuItem();
            map2ToolStripMenuItem = new ToolStripMenuItem();
            map3ToolStripMenuItem = new ToolStripMenuItem();
            emptyToolStripMenuItem1 = new ToolStripMenuItem();
            addToolStripMenuItem = new ToolStripMenuItem();
            unitToolStripMenuItem = new ToolStripMenuItem();
            terrainToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoard).BeginInit();
            panelUnit.SuspendLayout();
            panelTarget.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxBoard
            // 
            pictureBoxBoard.BackColor = Color.White;
            pictureBoxBoard.Location = new Point(12, 27);
            pictureBoxBoard.Name = "pictureBoxBoard";
            pictureBoxBoard.Size = new Size(801, 590);
            pictureBoxBoard.TabIndex = 0;
            pictureBoxBoard.TabStop = false;
            pictureBoxBoard.Paint += pictureBoxBoard_Paint;
            pictureBoxBoard.MouseClick += pictureBoxBoard_MouseClick;
            pictureBoxBoard.MouseMove += pictureBoxBoard_MouseMove;
            // 
            // panelUnit
            // 
            panelUnit.Controls.Add(labelUnitType);
            panelUnit.Controls.Add(labelAPTv);
            panelUnit.Controls.Add(labelMPv);
            panelUnit.Controls.Add(labelAVv);
            panelUnit.Controls.Add(labelHPv);
            panelUnit.Controls.Add(labelAPT);
            panelUnit.Controls.Add(labelMP);
            panelUnit.Controls.Add(labelAV);
            panelUnit.Controls.Add(labelHP);
            panelUnit.Controls.Add(labelUnit);
            panelUnit.Location = new Point(819, 142);
            panelUnit.Name = "panelUnit";
            panelUnit.Size = new Size(200, 109);
            panelUnit.TabIndex = 1;
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
            // labelAPTv
            // 
            labelAPTv.AutoSize = true;
            labelAPTv.Location = new Point(85, 75);
            labelAPTv.Name = "labelAPTv";
            labelAPTv.Size = new Size(58, 15);
            labelAPTv.TabIndex = 9;
            labelAPTv.Text = "labelAPTv";
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
            // labelAPT
            // 
            labelAPT.AutoSize = true;
            labelAPT.Location = new Point(3, 75);
            labelAPT.Name = "labelAPT";
            labelAPT.Size = new Size(41, 15);
            labelAPT.TabIndex = 5;
            labelAPT.Text = "Attack";
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
            // buttonEndTurn
            // 
            buttonEndTurn.Location = new Point(819, 321);
            buttonEndTurn.Name = "buttonEndTurn";
            buttonEndTurn.Size = new Size(200, 23);
            buttonEndTurn.TabIndex = 4;
            buttonEndTurn.Text = "End Turn";
            buttonEndTurn.UseVisualStyleBackColor = true;
            buttonEndTurn.Click += buttonEndTurn_Click;
            // 
            // panelTarget
            // 
            panelTarget.Controls.Add(labelUnitTypeT);
            panelTarget.Controls.Add(labelAPTTv);
            panelTarget.Controls.Add(labelMPTv);
            panelTarget.Controls.Add(labelAVTv);
            panelTarget.Controls.Add(labelHPTv);
            panelTarget.Controls.Add(labelAPTT);
            panelTarget.Controls.Add(labelMPT);
            panelTarget.Controls.Add(labelAVT);
            panelTarget.Controls.Add(labelHPT);
            panelTarget.Controls.Add(labelUnitH);
            panelTarget.Location = new Point(819, 27);
            panelTarget.Name = "panelTarget";
            panelTarget.Size = new Size(200, 109);
            panelTarget.TabIndex = 11;
            // 
            // labelUnitTypeT
            // 
            labelUnitTypeT.AutoSize = true;
            labelUnitTypeT.Location = new Point(3, 15);
            labelUnitTypeT.Name = "labelUnitTypeT";
            labelUnitTypeT.Size = new Size(56, 15);
            labelUnitTypeT.TabIndex = 10;
            labelUnitTypeT.Text = "Unit Type";
            // 
            // labelAPTTv
            // 
            labelAPTTv.AutoSize = true;
            labelAPTTv.Location = new Point(85, 75);
            labelAPTTv.Name = "labelAPTTv";
            labelAPTTv.Size = new Size(64, 15);
            labelAPTTv.TabIndex = 9;
            labelAPTTv.Text = "labelAPTTv";
            // 
            // labelMPTv
            // 
            labelMPTv.AutoSize = true;
            labelMPTv.Location = new Point(85, 60);
            labelMPTv.Name = "labelMPTv";
            labelMPTv.Size = new Size(61, 15);
            labelMPTv.TabIndex = 8;
            labelMPTv.Text = "labelMPTv";
            // 
            // labelAVTv
            // 
            labelAVTv.AutoSize = true;
            labelAVTv.Location = new Point(85, 45);
            labelAVTv.Name = "labelAVTv";
            labelAVTv.Size = new Size(57, 15);
            labelAVTv.TabIndex = 7;
            labelAVTv.Text = "labelAVTv";
            // 
            // labelHPTv
            // 
            labelHPTv.AutoSize = true;
            labelHPTv.Location = new Point(85, 30);
            labelHPTv.Name = "labelHPTv";
            labelHPTv.Size = new Size(59, 15);
            labelHPTv.TabIndex = 6;
            labelHPTv.Text = "labelHPTv";
            // 
            // labelAPTT
            // 
            labelAPTT.AutoSize = true;
            labelAPTT.Location = new Point(3, 75);
            labelAPTT.Name = "labelAPTT";
            labelAPTT.Size = new Size(41, 15);
            labelAPTT.TabIndex = 5;
            labelAPTT.Text = "Attack";
            // 
            // labelMPT
            // 
            labelMPT.AutoSize = true;
            labelMPT.Location = new Point(3, 60);
            labelMPT.Name = "labelMPT";
            labelMPT.Size = new Size(73, 15);
            labelMPT.TabIndex = 4;
            labelMPT.Text = "Move Points";
            // 
            // labelAVT
            // 
            labelAVT.AutoSize = true;
            labelAVT.Location = new Point(3, 45);
            labelAVT.Name = "labelAVT";
            labelAVT.Size = new Size(72, 15);
            labelAVT.TabIndex = 3;
            labelAVT.Text = "Attack Value";
            // 
            // labelHPT
            // 
            labelHPT.AutoSize = true;
            labelHPT.Location = new Point(3, 30);
            labelHPT.Name = "labelHPT";
            labelHPT.Size = new Size(78, 15);
            labelHPT.TabIndex = 2;
            labelHPT.Text = "Health Points";
            // 
            // labelUnitH
            // 
            labelUnitH.AutoSize = true;
            labelUnitH.Location = new Point(3, 0);
            labelUnitH.Name = "labelUnitH";
            labelUnitH.Size = new Size(64, 15);
            labelUnitH.TabIndex = 0;
            labelUnitH.Text = "Target Unit";
            // 
            // labelTurn
            // 
            labelTurn.AutoSize = true;
            labelTurn.Location = new Point(819, 303);
            labelTurn.Name = "labelTurn";
            labelTurn.Size = new Size(38, 15);
            labelTurn.TabIndex = 12;
            labelTurn.Text = "label1";
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, mapToolStripMenuItem, addToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1024, 24);
            menuStrip.TabIndex = 13;
            menuStrip.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { scenario1ToolStripMenuItem, scenario2ToolStripMenuItem, scenario3ToolStripMenuItem, emptyToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(50, 20);
            gameToolStripMenuItem.Text = "Game";
            // 
            // scenario1ToolStripMenuItem
            // 
            scenario1ToolStripMenuItem.Name = "scenario1ToolStripMenuItem";
            scenario1ToolStripMenuItem.Size = new Size(128, 22);
            scenario1ToolStripMenuItem.Text = "Scenario 1";
            scenario1ToolStripMenuItem.Click += scenario1ToolStripMenuItem_Click;
            // 
            // scenario2ToolStripMenuItem
            // 
            scenario2ToolStripMenuItem.Name = "scenario2ToolStripMenuItem";
            scenario2ToolStripMenuItem.Size = new Size(128, 22);
            scenario2ToolStripMenuItem.Text = "Scenario 2";
            scenario2ToolStripMenuItem.Click += scenario2ToolStripMenuItem_Click;
            // 
            // scenario3ToolStripMenuItem
            // 
            scenario3ToolStripMenuItem.Name = "scenario3ToolStripMenuItem";
            scenario3ToolStripMenuItem.Size = new Size(128, 22);
            scenario3ToolStripMenuItem.Text = "Scenario 3";
            scenario3ToolStripMenuItem.Click += scenario3ToolStripMenuItem_Click;
            // 
            // emptyToolStripMenuItem
            // 
            emptyToolStripMenuItem.Name = "emptyToolStripMenuItem";
            emptyToolStripMenuItem.Size = new Size(128, 22);
            emptyToolStripMenuItem.Text = "Empty";
            emptyToolStripMenuItem.Click += emptyGameToolStripMenuItem_Click;
            // 
            // mapToolStripMenuItem
            // 
            mapToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { map1ToolStripMenuItem, map2ToolStripMenuItem, map3ToolStripMenuItem, emptyToolStripMenuItem1 });
            mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            mapToolStripMenuItem.Size = new Size(43, 20);
            mapToolStripMenuItem.Text = "Map";
            // 
            // map1ToolStripMenuItem
            // 
            map1ToolStripMenuItem.Name = "map1ToolStripMenuItem";
            map1ToolStripMenuItem.Size = new Size(119, 22);
            map1ToolStripMenuItem.Text = "Map 1";
            map1ToolStripMenuItem.Click += map1ToolStripMenuItem_Click;
            // 
            // map2ToolStripMenuItem
            // 
            map2ToolStripMenuItem.Name = "map2ToolStripMenuItem";
            map2ToolStripMenuItem.Size = new Size(119, 22);
            map2ToolStripMenuItem.Text = "Map 2";
            map2ToolStripMenuItem.Click += map2ToolStripMenuItem_Click;
            // 
            // map3ToolStripMenuItem
            // 
            map3ToolStripMenuItem.Name = "map3ToolStripMenuItem";
            map3ToolStripMenuItem.Size = new Size(119, 22);
            map3ToolStripMenuItem.Text = "Random";
            map3ToolStripMenuItem.Click += map3ToolStripMenuItem_Click;
            // 
            // emptyToolStripMenuItem1
            // 
            emptyToolStripMenuItem1.Name = "emptyToolStripMenuItem1";
            emptyToolStripMenuItem1.Size = new Size(119, 22);
            emptyToolStripMenuItem1.Text = "Empty";
            emptyToolStripMenuItem1.Click += emptyMapToolStripMenuItem_Click;
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { unitToolStripMenuItem, terrainToolStripMenuItem });
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(41, 20);
            addToolStripMenuItem.Text = "Add";
            // 
            // unitToolStripMenuItem
            // 
            unitToolStripMenuItem.Name = "unitToolStripMenuItem";
            unitToolStripMenuItem.Size = new Size(109, 22);
            unitToolStripMenuItem.Text = "Unit";
            unitToolStripMenuItem.Click += unitToolStripMenuItem_Click;
            // 
            // terrainToolStripMenuItem
            // 
            terrainToolStripMenuItem.Name = "terrainToolStripMenuItem";
            terrainToolStripMenuItem.Size = new Size(109, 22);
            terrainToolStripMenuItem.Text = "Terrain";
            terrainToolStripMenuItem.Click += terrainToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 621);
            Controls.Add(labelTurn);
            Controls.Add(panelTarget);
            Controls.Add(buttonEndTurn);
            Controls.Add(panelUnit);
            Controls.Add(pictureBoxBoard);
            Controls.Add(menuStrip);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "FormMain";
            Text = "HexmapGame";
            Deactivate += FormMain_Deactivate;
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoard).EndInit();
            panelUnit.ResumeLayout(false);
            panelUnit.PerformLayout();
            panelTarget.ResumeLayout(false);
            panelTarget.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxBoard;
        private Panel panelUnit;
        private Label labelHP;
        private Label labelUnit;
        private Label labelAPT;
        private Label labelMP;
        private Label labelAV;
        private Label labelUnitType;
        private Label labelAPTv;
        private Label labelMPv;
        private Label labelAVv;
        private Label labelHPv;
        private Button buttonEndTurn;
        private Panel panelTarget;
        private Label labelUnitTypeT;
        private Label labelAPTTv;
        private Label labelMPTv;
        private Label labelAVTv;
        private Label labelHPTv;
        private Label labelAPTT;
        private Label labelMPT;
        private Label labelAVT;
        private Label labelHPT;
        private Label labelUnitH;
        private Label labelTurn;
        private MenuStrip menuStrip;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem scenario1ToolStripMenuItem;
        private ToolStripMenuItem scenario2ToolStripMenuItem;
        private ToolStripMenuItem scenario3ToolStripMenuItem;
        private ToolStripMenuItem emptyToolStripMenuItem;
        private ToolStripMenuItem unitToolStripMenuItem;
        private ToolStripMenuItem terrainToolStripMenuItem;
        private ToolStripMenuItem mapToolStripMenuItem;
        private ToolStripMenuItem map1ToolStripMenuItem;
        private ToolStripMenuItem map2ToolStripMenuItem;
        private ToolStripMenuItem map3ToolStripMenuItem;
        private ToolStripMenuItem emptyToolStripMenuItem1;
    }
}