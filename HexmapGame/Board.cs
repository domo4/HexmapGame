using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexmapGame
{
    internal class Board
    {
        public Hex[,] hexArray;
        private int width;
        private int height;
        private int side;
        readonly int[,,] neighborArray = new int[2, 6, 2] {
            { {1, 0} , {1, -1}, {0, -1}, {-1, -1}, {-1, 0}, {0, 1} }, //even columns
            { {1, 1} , {1, 0}, {0, -1}, {-1, 0}, {-1, 1}, {0, 1} }, //odd columns
            };

        public Board(int width, int height, int side)
        {
            hexArray = new Hex[width, height];
            this.width = width;
            this.height = height;   
            this.side = side;

            float x, y;
            float h = (float)(Math.Sin(30 * Math.PI / 180) * side);
            float r = (float)(Math.Cos(30 * Math.PI / 180) * side);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i % 2 == 0) //even columns
                    {
                        x = h + i * side + i * h;
                        y = 2 * j * r;
                    }
                    else //odd columns
                    {
                        x = h + i * side + i * h;
                        y = 2 * j * r + r;
                    }
                    hexArray[i, j] = new Hex(side, x, y, h, r);
                }
            }
        }

        private void Neighbors(int x, int y)
        {
            int nX, nY;
            for (int i = 0; i < 6; i++)
            {
                nX = x + neighborArray[x % 2, i, 0];
                nY = y + neighborArray[x % 2, i, 1];
                if (nX >= 0 && nX < width && nY >= 0 && nY < height)
                {
                    hexArray[nX, nY].color = Color.Green;
                }
            }
        }

        private static bool IsPointInPolygon(PointF[] polygon, PointF point)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public void FindClickedHex(PointF point)
        {
            Hex? clickedHex = null;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (IsPointInPolygon(hexArray[i, j].points, point)) 
                    {
                        System.Diagnostics.Debug.WriteLine("x = " + i + " y = " + j);
                        clickedHex = hexArray[i, j]; 
                        Neighbors(i, j);
                    }
                }
            }
            if (clickedHex!=null) clickedHex.color = Color.Red;
        }



        public int getWidth()
        {
            return this.width;
        }

        public int getHeight()
        {
            return this.height;
        }

        public int getSide()
        {
            return this.side;
        }
    }
}
