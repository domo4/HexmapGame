using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Security.Policy;
using System.Windows.Forms;

namespace HexmapGame
{
    public partial class FormMain : Form
    {
        Board b;
        Tuple<int, int>? currentHexXY;
        Tuple<int, int>? targetHexXY;
        int lastKnownTargetVertex; //Keeps the number of previously hovered vertex in case of mouse cursor leaving the board
        Unit? selectedUnit;
        Unit? targetUnit;
        List<int> res; //path
        bool blueTurn = true; //turn

        int[,] backupMap;

        public FormMain()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            b = new Board(13, 8, 40);
            currentHexXY = null;
            targetHexXY = null;
            lastKnownTargetVertex = 0;
            selectedUnit = null;
            targetUnit = null;
            res = null!;
            blueTurn = true;

            ClearUnitInfo();
            ClearTargetInfo();

            labelTurn.Text = "Blue's Turn";
            labelTurn.ForeColor = Color.Blue;
        }

        private void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Gainsboro);
            SolidBrush circleBrush = new SolidBrush(Color.Red);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int boardWidth = b.getWidth();
            int boardHeight = b.getHeight();
            int offset = 5; //offset used for bmp [px]

            //(Re)Draw the board
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    e.Graphics.DrawPolygon(p, b.hexArray[i, j].points);
                    e.Graphics.FillPolygon(new SolidBrush(b.hexArray[i, j].color), b.hexArray[i, j].points); //change to single
                                                                                                             //declaration if no diff backgrounds
                    Unit? unit = b.hexArray[i, j].unit;
                    if (unit != null)
                    {
                        RectangleF rec = new RectangleF(
                                    b.hexArray[i, j].x + offset,
                                    b.hexArray[i, j].y + offset,
                                    b.hexArray[i, j].side - offset,
                                    2 * b.hexArray[i, j].r - offset
                                    );
                        e.Graphics.DrawImage(unit.bmp, rec);
                    }

                    //
                    if (b.hexArray[i, j].cost == 2) //forest
                    {
                        PointF pf = b.hexArray[i, j].center;

                        e.Graphics.FillRectangle(new SolidBrush(Color.Green), pf.X - 20, pf.Y - 20, 40, 6);
                        e.Graphics.FillRectangle(new SolidBrush(Color.Green), pf.X - 20, pf.Y - 3, 40, 6);
                        e.Graphics.FillRectangle(new SolidBrush(Color.Green), pf.X - 20, pf.Y + 14, 40, 6);
                    }
                    if (b.hexArray[i, j].cost == 3) //mountains
                    {
                        PointF pf = b.hexArray[i, j].center;
                        PointF[] pts = new PointF[6];
                        pts[0].X = pf.X - 20; pts[0].Y = pf.Y + 20;
                        pts[1].X = pf.X - 10; pts[1].Y = pf.Y;
                        pts[2].X = pf.X; pts[2].Y = pf.Y + 20;
                        pts[3].X = pf.X - 5; pts[3].Y = pf.Y + 10;
                        pts[4].X = pf.X + 5; pts[4].Y = pf.Y - 10;
                        pts[5].X = pf.X + 20; pts[5].Y = pf.Y + 20;

                        e.Graphics.DrawLines(new Pen(new SolidBrush(Color.Magenta), 5), pts);
                    }
                    //
                }
            }
        }

        private void UpdateTargetInfo(Tuple<int, int> h)
        {
            if (b.hexArray[h.Item1, h.Item2].unit != null)
            {
                labelUnitTypeT.Text = b.hexArray[h.Item1, h.Item2].unit.name.ToString();
                labelHPTv.Text = b.hexArray[h.Item1, h.Item2].unit.healthPoints.ToString();
                labelAVTv.Text = b.hexArray[h.Item1, h.Item2].unit.attackValue.ToString();
                labelMPTv.Text = b.hexArray[h.Item1, h.Item2].unit.movePoints.ToString();
                labelAPTTv.Text = b.hexArray[h.Item1, h.Item2].unit.attack.ToString();
            }
        }
        private void ClearTargetInfo()
        {
            labelUnitTypeT.Text = "";
            labelHPTv.Text = "";
            labelAVTv.Text = "";
            labelMPTv.Text = "";
            labelAPTTv.Text = "";
        }

        private void UpdateUnitInfo(Tuple<int, int> h)
        {
            if (b.hexArray[h.Item1, h.Item2].unit != null)
            {
                labelUnitType.Text = b.hexArray[h.Item1, h.Item2].unit.name.ToString();
                labelHPv.Text = b.hexArray[h.Item1, h.Item2].unit.healthPoints.ToString();
                labelAVv.Text = b.hexArray[h.Item1, h.Item2].unit.attackValue.ToString();
                labelMPv.Text = b.hexArray[h.Item1, h.Item2].unit.movePoints.ToString();
                labelAPTv.Text = b.hexArray[h.Item1, h.Item2].unit.attack.ToString();
            }
        }

        private void ClearUnitInfo()
        {
            labelUnitType.Text = "";
            labelHPv.Text = "";
            labelAVv.Text = "";
            labelMPv.Text = "";
            labelAPTv.Text = "";
        }

        private void pictureBoxBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (b != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (selectedUnit != null)
                    {
                        int attackResult;
                        //attack logic
                        if (targetUnit != null && targetUnit != selectedUnit)
                        {
                            if (b.IsNeighbor(currentHexXY.Item1, currentHexXY.Item2, targetHexXY.Item1, targetHexXY.Item2))
                            {
                                attackResult = b.AttackUnit(selectedUnit, targetUnit, targetHexXY.Item1, targetHexXY.Item2);
                                UpdateTargetInfo(targetHexXY);
                                UpdateUnitInfo(currentHexXY);
                                b.UpdateVerticeList(currentHexXY);
                                switch (attackResult)
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        MessageBox.Show("Red won!");
                                        ReloadGame();
                                        return;
                                    case 2:
                                        MessageBox.Show("Blue won!");
                                        ReloadGame();
                                        return;
                                }
                            }
                        }

                        //movement logic
                        if (res.Count == 0) return; //isolated hexes
                        Tuple<int, int> target = b.MoveUnit(selectedUnit, res);
                        if (b.hexArray[target.Item1, target.Item2].unit != null) return; //is it even useful anymore?
                        b.hexArray[currentHexXY.Item1, currentHexXY.Item2].unit = null;
                        b.hexArray[target.Item1, target.Item2].unit = selectedUnit;
                        currentHexXY = target;
                        UpdateUnitInfo(currentHexXY);
                    }
                    else
                    {
                        PointF mouseClick = new PointF(e.X, e.Y);
                        Tuple<int, int> temp = b.FindClickedHex(mouseClick);
                        if (temp.Item1 != b.width && temp.Item2 != b.height)
                        {
                            currentHexXY = temp; //Guarantees that one of the hexes was selected
                            //selectedUnit = b.hexArray[temp.Item1, temp.Item2].unit;
                            //UpdateUnitInfo(temp);
                            if (blueTurn && b.IsUnitBlue(b.hexArray[temp.Item1, temp.Item2].unit))
                            {
                                selectedUnit = b.hexArray[temp.Item1, temp.Item2].unit;
                                UpdateUnitInfo(temp);
                            }
                            else if (!blueTurn && !b.IsUnitBlue(b.hexArray[temp.Item1, temp.Item2].unit))
                            {
                                selectedUnit = b.hexArray[temp.Item1, temp.Item2].unit;
                                UpdateUnitInfo(temp);
                            }

                        }
                        b.UpdateVerticeList(temp);//WIP
                        pictureBoxBoard.Invalidate();
                    }
                }
                else
                {
                    currentHexXY = null;
                    selectedUnit = null;
                    ClearUnitInfo();
                }
            }
        }

        private void pictureBoxBoard_MouseMove(object sender, MouseEventArgs e)
        {
            res = new List<int>();
            bool wasInPolygon = false;
            if (b != null)
            {
                //Attack logic
                PointF mousePositionx = new PointF(e.X, e.Y);
                for (int i = 0; i < b.width; i++)
                {
                    for (int j = 0; j < b.height; j++)
                    {
                        if (b.IsPointInPolygon(b.hexArray[i, j].points, mousePositionx))
                        {
                            if (b.hexArray[i, j].unit != null)
                            {
                                targetHexXY = new Tuple<int, int>(i, j);
                                targetUnit = b.hexArray[i, j].unit;
                                UpdateTargetInfo(targetHexXY);
                            }
                            else
                            {
                                targetHexXY = null;
                                targetUnit = null;
                                ClearTargetInfo();
                            }
                            wasInPolygon = true;
                        }
                    }
                }
                if (!wasInPolygon)
                {
                    targetHexXY = null;
                    targetUnit = null;
                    ClearTargetInfo();
                }
                //Movement logic
                if (selectedUnit != null && currentHexXY != null && currentHexXY.Item1 < b.width && currentHexXY.Item2 < b.height)
                {
                    int sourceVertex = b.hexToVertex[currentHexXY.Item1, currentHexXY.Item2];
                    int targetVertex = lastKnownTargetVertex;
                    PointF mousePosition = new PointF(e.X, e.Y);
                    bool breakFlag = false;
                    int i = 0, j = 0;
                    bool isBlocked = false;

                    //Check if cursor is hovering over one of the hexes
                    for (i = 0; i < b.width; i++)
                    {
                        for (j = 0; j < b.height; j++)
                        {
                            if (b.IsPointInPolygon(b.hexArray[i, j].points, mousePosition))
                            {
                                targetVertex = b.hexToVertex[i, j]; //targetVertex = hex the cursor is hovering over
                                if (b.hexArray[i, j].unit != null && targetVertex != sourceVertex) isBlocked = true;
                                lastKnownTargetVertex = targetVertex;
                                breakFlag = true;
                                break;
                            }
                        }
                        if (breakFlag) break;
                    }

                    //Dijkstra
                    int[] path = Dijkstra.Dist(b.graph, sourceVertex);
                    res = Dijkstra.GetPath(path, targetVertex);
                    if (res.Count > 0) res.Add(targetVertex); //adding to empty res would result in units 'teleporting' to isolated hexes

                    //Paint the path etc
                    b.Uncolor();
                    b.ColorHex(sourceVertex);
                    if (isBlocked == false) b.ColorPath(selectedUnit, res);
                    if (selectedUnit.attack) b.Neighbors(currentHexXY.Item1, currentHexXY.Item2); //att
                    pictureBoxBoard.Invalidate();
                }
                else if (currentHexXY == null)
                {
                    b.Uncolor();
                    pictureBoxBoard.Invalidate();
                }
            }
        }

        private void buttonEndTurn_Click(object sender, EventArgs e)
        {
            if (blueTurn)
            {
                labelTurn.Text = "Red's Turn";
                labelTurn.ForeColor = Color.Red;
            }
            else
            {
                labelTurn.Text = "Blue's Turn";
                labelTurn.ForeColor = Color.Blue;
            }
            blueTurn = !blueTurn;
            currentHexXY = null;
            selectedUnit = null;
            ClearUnitInfo();
            b.ResetUnitStatus();
            b.Uncolor();
            pictureBoxBoard.Invalidate();
        }

        private void scenario1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadGame();

            //blue
            b.AddUnit(0, 0, new MageB()); //column row unit
            b.AddUnit(0, 1, new KnightB());
            b.AddUnit(0, 2, new KnightB());
            b.AddUnit(0, 3, new CavalryB());
            b.AddUnit(1, 0, new InfantryB());
            b.AddUnit(1, 1, new InfantryB());
            b.AddUnit(1, 2, new InfantryB());
            b.AddUnit(1, 3, new CavalryB());
            //red
            b.AddUnit(3, 2, new CavalryR());
            b.AddUnit(3, 3, new CavalryR());
            b.AddUnit(3, 4, new CavalryR());
            b.AddUnit(3, 1, new KnightR());
            b.AddUnit(4, 1, new KnightR());
            b.AddUnit(4, 2, new KnightR());
            b.AddUnit(5, 1, new KnightR());
            b.AddUnit(4, 3, new MageR());
            b.AddUnit(0, 6, new MageR());
            b.AddUnit(1, 6, new InfantryR());
        }

        private void scenario2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadGame();

            //blue
            b.AddUnit(0, 6, new InfantryB()); //column row unit
            b.AddUnit(0, 7, new InfantryB());
            b.AddUnit(1, 5, new KnightB());
            b.AddUnit(1, 6, new InfantryB());
            b.AddUnit(1, 7, new MageB());
            b.AddUnit(2, 6, new InfantryB());
            b.AddUnit(2, 7, new InfantryB());
            b.AddUnit(3, 6, new KnightB());
            b.AddUnit(3, 7, new InfantryB());
            b.AddUnit(11, 0, new CavalryB());
            b.AddUnit(12, 0, new CavalryB());
            b.AddUnit(12, 1, new CavalryB());
            //red
            b.AddUnit(0, 0, new KnightR());
            b.AddUnit(0, 1, new CavalryR());
            b.AddUnit(0, 2, new CavalryR());
            b.AddUnit(0, 3, new InfantryR());
            b.AddUnit(1, 0, new CavalryR());
            b.AddUnit(1, 1, new CavalryR());
            b.AddUnit(1, 2, new InfantryR());
            b.AddUnit(2, 0, new InfantryR());
            b.AddUnit(2, 1, new InfantryR());
            b.AddUnit(2, 2, new InfantryR());
        }

        private void scenario3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadGame();

            //blue
            b.AddUnit(0, 0, new CavalryB()); //column row unit
            b.AddUnit(0, 1, new CavalryB());
            b.AddUnit(0, 2, new KnightB());
            b.AddUnit(0, 3, new MageB());
            b.AddUnit(0, 4, new MageB());
            b.AddUnit(0, 5, new KnightB());
            b.AddUnit(0, 6, new CavalryB());
            b.AddUnit(0, 7, new CavalryB());
            b.AddUnit(1, 0, new InfantryB());
            b.AddUnit(1, 1, new InfantryB());
            b.AddUnit(1, 2, new InfantryB());
            b.AddUnit(1, 3, new InfantryB());
            b.AddUnit(1, 4, new InfantryB());
            b.AddUnit(1, 5, new InfantryB());
            b.AddUnit(1, 6, new InfantryB());
            b.AddUnit(1, 7, new InfantryB());
            //red
            b.AddUnit(12, 0, new CavalryR());
            b.AddUnit(12, 1, new CavalryR());
            b.AddUnit(12, 2, new KnightR());
            b.AddUnit(12, 3, new MageR());
            b.AddUnit(12, 4, new MageR());
            b.AddUnit(12, 5, new KnightR());
            b.AddUnit(12, 6, new CavalryR());
            b.AddUnit(12, 7, new CavalryR());
            b.AddUnit(11, 0, new InfantryR());
            b.AddUnit(11, 1, new InfantryR());
            b.AddUnit(11, 2, new InfantryR());
            b.AddUnit(11, 3, new InfantryR());
            b.AddUnit(11, 4, new InfantryR());
            b.AddUnit(11, 5, new InfantryR());
            b.AddUnit(11, 6, new InfantryR());
            b.AddUnit(11, 7, new InfantryR());
        }

        private void emptyGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadGame();
        }

        private void map1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMap();

            b.hexArray[0, 0].cost = 3;
            b.hexArray[0, 1].cost = 3;

            b.hexArray[0, 2].cost = 2;
            b.hexArray[0, 3].cost = 2;
            b.hexArray[0, 4].cost = 2;
            b.hexArray[1, 0].cost = 2;
            b.hexArray[1, 1].cost = 2;
            b.hexArray[1, 2].cost = 2;
            b.hexArray[1, 3].cost = 2;
            b.hexArray[2, 0].cost = 2;
            b.hexArray[2, 1].cost = 2;
            b.hexArray[2, 2].cost = 2;
            b.hexArray[2, 3].cost = 2;
            b.hexArray[3, 0].cost = 2;
            b.hexArray[3, 1].cost = 2;
            b.hexArray[3, 2].cost = 2;
            b.hexArray[4, 1].cost = 2;
            b.hexArray[4, 2].cost = 2;

            b.hexArray[6, 6].cost = 2;
            b.hexArray[6, 7].cost = 2;
            b.hexArray[7, 5].cost = 3;
            b.hexArray[7, 6].cost = 3;
            b.hexArray[7, 7].cost = 2;
            b.hexArray[8, 6].cost = 3;
            b.hexArray[8, 7].cost = 2;
            b.hexArray[9, 4].cost = 3;
            b.hexArray[9, 5].cost = 3;
            b.hexArray[9, 6].cost = 3;
            b.hexArray[9, 7].cost = 2;
            b.hexArray[10, 6].cost = 3;
            b.hexArray[10, 7].cost = 3;

            b.hexArray[8, 2].cost = 2;
            b.hexArray[8, 3].cost = 2;
            b.hexArray[9, 2].cost = 2;
            b.hexArray[10, 2].cost = 2;
        }

        private void map2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMap();

            b.hexArray[0, 0].cost = 2;
            b.hexArray[0, 1].cost = 2;
            b.hexArray[1, 0].cost = 2;
            b.hexArray[1, 1].cost = 2;
            b.hexArray[2, 0].cost = 2;
            b.hexArray[2, 1].cost = 2;
            b.hexArray[2, 2].cost = 2;
            b.hexArray[3, 0].cost = 2;
            b.hexArray[3, 1].cost = 2;
            b.hexArray[4, 0].cost = 2;
            b.hexArray[4, 1].cost = 2;
            b.hexArray[5, 0].cost = 2;

            b.hexArray[6, 0].cost = 2;
            b.hexArray[7, 0].cost = 2;
            b.hexArray[8, 0].cost = 2;

            b.hexArray[8, 4].cost = 2;
            b.hexArray[9, 4].cost = 2;
            b.hexArray[9, 5].cost = 2;
            b.hexArray[10, 3].cost = 2;
            b.hexArray[10, 4].cost = 2;

            b.hexArray[11, 7].cost = 2;
            b.hexArray[12, 6].cost = 2;
            b.hexArray[12, 7].cost = 2;

            b.hexArray[4, 3].cost = 3;
            b.hexArray[5, 3].cost = 3;
            b.hexArray[6, 3].cost = 3;
            b.hexArray[6, 4].cost = 3;
            b.hexArray[7, 3].cost = 3;
            b.hexArray[8, 3].cost = 3;
            b.hexArray[9, 3].cost = 3;

            b.hexArray[3, 7].cost = 3;
            b.hexArray[4, 6].cost = 3;
            b.hexArray[4, 7].cost = 3;
        }

        private void map3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMap();

            Random random = new Random();
            for (int i = 0; i < b.width; i++)
            {
                for (int j = 0; j < b.height; j++)
                {
                    //b.hexArray[i, j].cost = random.Next(1, 4);
                    int l = random.Next(1, 10);
                    if (l <= 5)
                    {
                        b.hexArray[i, j].cost = 1;
                    }
                    else if (l >= 6 && l <= 8)
                    {
                        b.hexArray[i, j].cost = 2;
                    }
                    else
                    {
                        b.hexArray[i, j].cost = 3;
                    }
                }
            }
            backupMap = BackupMap();
        }

        private void emptyMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearMap();
        }

        private void ClearMap()
        {
            for (int i = 0; i < b.width; i++)
            {
                for (int j = 0; j < b.height; j++)
                {
                    b.hexArray[i, j].cost = 1; //default
                }
            }
        }

        private int[,] BackupMap()
        {
            int[,] backup = new int[b.width, b.height];

            for (int i = 0; i < b.width; i++)
            {
                for (int j = 0; j < b.height; j++)
                {
                    backup[i, j] = b.hexArray[i, j].cost;
                }
            }

            return backup;
        }

        private void LoadBackupMap()
        {
            for (int i = 0; i < b.width; i++)
            {
                for (int j = 0; j < b.height; j++)
                {
                    b.hexArray[i, j].cost = backupMap[i, j];
                }
            }
        }

        private void ReloadGame()
        {
            backupMap = BackupMap();
            Init();
            LoadBackupMap();
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUnit formUnit = new FormUnit();
            formUnit.MyParent = this;
            formUnit.Show();
        }

        public void AddUnitFromSubform(int x, int y, Unit u)
        {
            if (b.hexArray[x, y].unit != null)
            {
                b.DeleteUnit(x, y);
            }
            b.AddUnit(x, y, u);
            pictureBoxBoard.Invalidate();
        }

        public void DeleteUnitFromSubform(int x, int y)
        {
            b.DeleteUnit(x, y);
            pictureBoxBoard.Invalidate();
        }

        private void terrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTerrain formTerrain = new FormTerrain();
            formTerrain.MyParent = this;
            formTerrain.Show();
        }

        public void ChangeTerrainFromSubform(int x, int y, int cost)
        {
            b.hexArray[x, y].cost = cost;
            pictureBoxBoard.Invalidate();
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            currentHexXY = null;
            selectedUnit = null;
            ClearUnitInfo();
            b.Uncolor();
            pictureBoxBoard.Invalidate();
        }
    }
}