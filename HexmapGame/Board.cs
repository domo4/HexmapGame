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
                for(int j = 0; j < height; j++)
                {
                    if(i % 2 == 0) //even columns
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
