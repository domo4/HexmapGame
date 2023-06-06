using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HexmapGame
{
    internal class Board
    {
        public Hex[,] hexArray;
        public int width;
        public int height;
        private int side;
        readonly int[,,] neighborArray = new int[2, 6, 2] {
            { {1, 0} , {1, -1}, {0, -1}, {-1, -1}, {-1, 0}, {0, 1} }, //even columns
            { {1, 1} , {1, 0}, {0, -1}, {-1, 0}, {-1, 1}, {0, 1} }, //odd columns
            };
        public int[,] hexToVertex; //to find vertex k by its coordinates
        public List<Dijkstra.Node> graph;

        public int blueUnitCount = 0;
        public int redUnitCount = 0;

        public Board(int width, int height, int side)
        {
            hexArray = new Hex[width, height];
            hexToVertex = new int[width, height];
            this.width = width;
            this.height = height;   
            this.side = side;
            
            float x, y;
            float h = (float)(Math.Sin(30 * Math.PI / 180) * side);
            float r = (float)(Math.Cos(30 * Math.PI / 180) * side);
            int k = 0;
            //
            graph = new List<Dijkstra.Node>();
            //
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
                    hexToVertex[i, j] = k;
                    graph.Add(new Dijkstra.Node(k));
                    k++;
                }
            }
        }

        public void AddUnit(int x, int y, Unit unit)
        {
            if (hexArray[x, y].unit == null)
            {
                hexArray[x, y].unit = unit;
                switch (unit)
                {
                    case InfantryB:
                    case KnightB:
                    case CavalryB:
                    case MageB:
                        blueUnitCount++;
                        break;
                    case InfantryR:
                    case KnightR:
                    case CavalryR:
                    case MageR:
                        redUnitCount++;
                        break;
                }
            }
        }

        public void DeleteUnit(int x, int y)
        {
            if (hexArray[x, y].unit != null)
            {
                switch (hexArray[x, y].unit)
                {
                    case InfantryB:
                    case KnightB:
                    case CavalryB:
                    case MageB:
                        blueUnitCount--;
                        break;
                    case InfantryR:
                    case KnightR:
                    case CavalryR:
                    case MageR:
                        redUnitCount--;
                        break;
                }
                hexArray[x, y].unit = null;
            }
        }
        
        public bool IsUnitBlue(Unit unit)
        {
            switch (unit)
            {
                case InfantryB:
                case KnightB:
                case CavalryB:
                case MageB:
                    return true;
                default:
                    return false;
            }
        }

        public void ResetUnitStatus()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (hexArray[i, j].unit != null) 
                    {
                        hexArray[i, j].unit.ResetUnitStatus();
                    }

                }
            }
        }

        public void UpdateVerticeList(Tuple <int, int> src)
        {
            List<int> excludedNodes = new List<int>();
            graph.Clear();
            int k = 0;
            graph = new List<Dijkstra.Node>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (hexArray[i, j].unit != null && (i != src.Item1 || j != src.Item2))
                    {
                        excludedNodes.Add(k);
                    }
                    graph.Add(new Dijkstra.Node(k));
                    k++;
                }
            }

            int t = 0;
            int nX, nY;
            for (int xx = 0; xx < width; xx++)
            {
                for (int yy = 0; yy < height; yy++)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        nX = xx + neighborArray[xx % 2, i, 0];
                        nY = yy + neighborArray[xx % 2, i, 1];
                        if (nX >= 0 && nX < width && nY >= 0 && nY < height)
                        {
                            if (!excludedNodes.Contains(hexToVertex[nX, nY]))
                            {
                                graph[t].Add_child(hexToVertex[nX, nY], hexArray[nX, nY].cost);
                            }
                        }
                    }
                    t++;
                }
            }
        }

        public bool IsNeighbor(int sourceX, int sourceY, int targetX, int targetY)
        {
            int nX, nY;
            for (int i = 0; i < 6; i++)
            {
                nX = sourceX + neighborArray[sourceX % 2, i, 0];
                nY = sourceY + neighborArray[sourceX % 2, i, 1];
                if (nX == targetX && nY == targetY)
                {
                    return true;
                }
            }
            return false;
        }

        public void Neighbors(int x, int y)
        {
            int nX, nY;
            for (int i = 0; i < 6; i++)
            {
                nX = x + neighborArray[x % 2, i, 0];
                nY = y + neighborArray[x % 2, i, 1];
                if (nX >= 0 && nX < width && nY >= 0 && nY < height && hexArray[nX, nY].unit != null)
                {
                    hexArray[nX, nY].color = Color.IndianRed;
                }
            }
        }

        public bool IsPointInPolygon(PointF[] polygon, PointF point)
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

        public Tuple<int,int> FindClickedHex(PointF point)
        {
            //Hex? clickedHex = null; //might be useful later
            bool breakFlag = false;
            int i = 0, j = 0;
            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    if (IsPointInPolygon(hexArray[i, j].points, point)) 
                    {
                        breakFlag = true;
                        break;
                    }
                }
                if (breakFlag) break;
            }

            return new Tuple<int, int>(i, j); //returns i = width, j = height if clicked outside of hexes (blank area)
        }

        public int DetermineCost(int currentVertex, List<int> vertices)
        {
            int i = 0, j = 0;
            bool t = false;
            int cost = 1; //default
            
            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    if (hexToVertex[i, j] == vertices[currentVertex + 1])
                    {
                        cost = hexArray[i, j].cost;
                        t = true; break;
                    }
                }
                if (t) break;
            }
            
            return cost;
        }

        public int AttackUnit(Unit attacker, Unit defender, int defenderX, int defenderY)
        {
            if (attacker.attack == true)
            {
                defender.healthPoints -= attacker.attackValue;
                attacker.attack = false;
                attacker.movePoints = 0;

                if (defender.healthPoints <= 0) 
                { 
                    hexArray[defenderX, defenderY].unit = null;
                    switch (defender)
                    {
                        case InfantryB:
                        case KnightB:
                        case CavalryB:
                        case MageB:
                            blueUnitCount--;
                            break;
                        case InfantryR:
                        case KnightR:
                        case CavalryR:
                        case MageR:
                            redUnitCount--;
                            break;
                    }
                }

                if (blueUnitCount == 0)
                {
                    return 1; //Red won
                }
                if (redUnitCount == 0)
                {
                    return 2; //Blue won
                }
            }
            return 0; //continue
            
        }

        public Tuple<int, int> MoveUnit(Unit u, List<int> vertices)
        {
            int k, i = 0, j = 0;
            int movePointsLeft = u.movePoints;

            for (k = 0; k < vertices.Count - 1; k++)
            {
                if ((movePointsLeft - DetermineCost(k, vertices)) < 0) break;
                movePointsLeft -= DetermineCost(k, vertices);
                u.movePoints -= DetermineCost(k, vertices);
            }

            bool test = false;
            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    if (hexToVertex[i, j] == vertices[k])
                    {
                        test = true; break;
                    }
                }
                if (test) break;
            }
            return new Tuple<int, int>(i, j);
        }

        //Color the path to the target
        public void ColorPath(Unit u, List<int> vertices)
        {
            int movePointsLeft = u.movePoints;
            int maxMovePoints = movePointsLeft;
            
            for (int k = 0; k < vertices.Count; k++)
            {
                bool test = false;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (hexToVertex[i, j] == vertices[k])
                        {
                            if (k == 0) { test = true; break; }
                            movePointsLeft -= DetermineCost(k - 1, vertices);
                            if (movePointsLeft >= 0) hexArray[i, j].color = Color.Blue;
                            else hexArray[i, j].color = Color.Orange;
                            test = true;  break;
                        }
                    }
                    if (test) break;
                }
            }
        }

        //Color the source hex whenever you mouse over other, already taken hex
        public void ColorHex(int vertex)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (hexToVertex[i, j] == vertex)
                    {
                        hexArray[i, j].color = Color.Blue;
                        return;
                    }
                }
            }
        }

        //Uncolor all of the hexes
        public void Uncolor()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (hexArray[i, j].color != Color.Gainsboro)
                    {
                        hexArray[i, j].color = Color.Gainsboro;
                    }
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
