using System.Drawing.Drawing2D;

namespace HexmapGame
{
    public partial class FormMain : Form
    {
        Board b = new Board(13, 8, 40);

        public FormMain()
        {
            InitializeComponent();
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
                    e.Graphics.FillPolygon(new SolidBrush(b.hexArray[i, j].color), b.hexArray[i, j].points);
                }
            }
        }

        private void pictureBoxBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (b != null && e.Button == MouseButtons.Left)
            {
                PointF mouseClick = new PointF(e.X, e.Y);
                b.FindClickedHex(mouseClick);
                pictureBoxBoard.Invalidate();
            }
        }
    }
}