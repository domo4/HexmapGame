using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HexmapGame
{
    public partial class FormUnit : Form
    {
        public FormMain MyParent { get; set; }
        string selectedUnit;
        Unit u;
        int x, y;

        public FormUnit()
        {
            InitializeComponent();
        }

        private void FormUnit_Load(object sender, EventArgs e)
        {
            comboBoxUnit.Items.Clear();
            comboBoxUnit.Items.Add("InfantryB");
            comboBoxUnit.Items.Add("KnightB");
            comboBoxUnit.Items.Add("CavalryB");
            comboBoxUnit.Items.Add("MageB");
            comboBoxUnit.Items.Add("InfantryR");
            comboBoxUnit.Items.Add("KnightR");
            comboBoxUnit.Items.Add("CavalryR");
            comboBoxUnit.Items.Add("MageR");
            comboBoxUnit.SelectedIndex = 0;
        }

        private void comboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedUnit = comboBoxUnit.SelectedItem.ToString();
            switch (selectedUnit)
            {
                case "InfantryB":
                    u = new InfantryB();
                    break;
                case "KnightB":
                    u = new KnightB();
                    break;
                case "CavalryB":
                    u = new CavalryB();
                    break;
                case "MageB":
                    u = new MageB();
                    break;
                case "InfantryR":
                    u = new InfantryR();
                    break;
                case "KnightR":
                    u = new KnightR();
                    break;
                case "CavalryR":
                    u = new CavalryR();
                    break;
                case "MageR":
                    u = new MageR();
                    break;
            }
            if (u != null)
            {
                labelUnitType.Text = u.name.ToString();
                labelHPv.Text = u.healthPoints.ToString();
                labelAVv.Text = u.attackValue.ToString();
                labelMPv.Text = u.movePoints.ToString();

                int side = 40;
                int offset = 5;
                float r = (float)(Math.Cos(30 * Math.PI / 180) * side);
                pictureBoxUnit.Width = side - offset;
                pictureBoxUnit.Height = (int)((2 * r) - offset);
                pictureBoxUnit.Image = u.bmp;
            }
        }

        private Unit UnitCreator()
        {
            switch (selectedUnit)
            {
                case "InfantryB":
                    u = new InfantryB();
                    break;
                case "KnightB":
                    u = new KnightB();
                    break;
                case "CavalryB":
                    u = new CavalryB();
                    break;
                case "MageB":
                    u = new MageB();
                    break;
                case "InfantryR":
                    u = new InfantryR();
                    break;
                case "KnightR":
                    u = new KnightR();
                    break;
                case "CavalryR":
                    u = new CavalryR();
                    break;
                case "MageR":
                    u = new MageR();
                    break;
            }
            return u;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.MyParent.AddUnitFromSubform(x, y, UnitCreator());
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.MyParent.DeleteUnitFromSubform(x, y);
        }

        private void numericUpDownX_ValueChanged(object sender, EventArgs e)
        {
            x = (int)numericUpDownX.Value;
        }

        private void numericUpDownY_ValueChanged(object sender, EventArgs e)
        {
            y = (int)numericUpDownY.Value;
        }
    }
}
