using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HexmapGame
{
    public partial class FormTerrain : Form
    {
        public FormMain MyParent { get; set; }
        string selectedTerrain;
        Hex hex;
        int cost = 1;
        int x, y;

        public FormTerrain()
        {
            InitializeComponent();
        }

        private void FormTerrain_Load(object sender, EventArgs e)
        {
            comboBoxTerrain.Items.Clear();
            comboBoxTerrain.Items.Add("Plains");
            comboBoxTerrain.Items.Add("Forest");
            comboBoxTerrain.Items.Add("Mountains");
            comboBoxTerrain.SelectedIndex = 0;

            int side = 40;
            float h = (float)(Math.Sin(30 * Math.PI / 180) * side);
            float r = (float)(Math.Cos(30 * Math.PI / 180) * side);
            float x = h, y = 0;
            hex = new Hex(40, x, y, h, r);
            pictureBoxTerrain.Width = (int)(side + 2 * r);
            pictureBoxTerrain.Height = (int)(side + 2 * h);
        }

        private void comboBoxTerrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTerrain = comboBoxTerrain.SelectedItem.ToString();
            switch (selectedTerrain)
            {
                case "Plains":
                    cost = 1;
                    break;
                case "Forest":
                    cost = 2;
                    break;
                case "Mountains":
                    cost = 3;
                    break;
            }
            if (hex != null)
            {
                hex.cost = cost;
            }
            labelTerrainName.Text = selectedTerrain;
            labelCostV.Text = cost.ToString();
            pictureBoxTerrain.Invalidate();
        }

        private void pictureBoxTerrain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPolygon(new Pen(Color.Black), hex.points);
            e.Graphics.FillPolygon(new SolidBrush(hex.color), hex.points);

            if (hex.cost == 2) //forest
            {
                PointF pf = hex.center;

                e.Graphics.FillRectangle(new SolidBrush(Color.Green), pf.X - 20, pf.Y - 20, 40, 6);
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), pf.X - 20, pf.Y - 3, 40, 6);
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), pf.X - 20, pf.Y + 14, 40, 6);
            }
            if (hex.cost == 3) //mountains
            {
                PointF pf = hex.center;
                PointF[] pts = new PointF[6];
                pts[0].X = pf.X - 20; pts[0].Y = pf.Y + 20;
                pts[1].X = pf.X - 10; pts[1].Y = pf.Y;
                pts[2].X = pf.X; pts[2].Y = pf.Y + 20;
                pts[3].X = pf.X - 5; pts[3].Y = pf.Y + 10;
                pts[4].X = pf.X + 5; pts[4].Y = pf.Y - 10;
                pts[5].X = pf.X + 20; pts[5].Y = pf.Y + 20;

                e.Graphics.DrawLines(new Pen(new SolidBrush(Color.Magenta), 5), pts);
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            this.MyParent.ChangeTerrainFromSubform(x, y, cost);
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

