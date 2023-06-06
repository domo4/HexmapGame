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
        public PointF center;
        public float side;
        public float h, r, x, y; 
        public int cost = 1; //determines cost to pass through this hex
        public Color color = Color.Gainsboro;
        public Unit? unit = null;

        public Hex(float side, float x, float y, float h, float r)
        {
            this.side = side;
            this.x = x;
            this.y = y;
            this.h = h;
            this.r = r;

            //we are using flat top orientation
            points = new PointF[6];
            points[0] = new PointF(x, y); //top left
            points[1] = new PointF(x + side, y); //top right
            points[2] = new PointF(x + side + h, y + r); //center right
            points[3] = new PointF(x + side, y + 2 * r); //bottom right
            points[4] = new PointF(x, y + 2 * r); //bottom left
            points[5] = new PointF(x - h, y + r); //center left

            center = new PointF(x + side / 2, y + r); //center
        }
    }
}
