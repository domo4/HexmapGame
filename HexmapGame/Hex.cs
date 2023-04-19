using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexmapGame
{
    internal class Hex
    {
        public PointF[] points;
        private float side;
        private float h, r, x, y; 
        int difficulty = 1; //determines cost to pass through this hex
        public Color color = Color.Gainsboro;

        public Hex(float side, float x, float y, float h, float r)
        {
            this.side = side;
            this.x = x;
            this.y = y;

            //we are using flat top orientation
            points = new PointF[6];
            points[0] = new PointF(x, y); //top left
            points[1] = new PointF(x + side, y); //top right
            points[2] = new PointF(x + side + h, y + r); //center right
            points[3] = new PointF(x + side, y + 2 * r); //bottom right
            points[4] = new PointF(x, y + 2 * r); //bottom left
            points[5] = new PointF(x - h, y + r); //center left
        }
    }
}
