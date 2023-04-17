using System.Drawing.Drawing2D;

namespace HexmapGame
{
    public partial class FormMain : Form
    {
        Board? b;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            b = new Board(13, 8, 40);
        }

        private void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Gainsboro);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int boardWidth = b.getWidth();
            int boardHeight = b.getHeight();

            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    e.Graphics.DrawPolygon(p, b.hexArray[i, j].points);
                    e.Graphics.FillPolygon(brush, b.hexArray[i, j].points);
                }
            }
        }
    }
}