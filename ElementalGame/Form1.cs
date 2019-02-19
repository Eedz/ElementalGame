using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Engine;

namespace ElementalGame
{
    public partial class Form1 : Form
    {
        List<PointF> Hexagons; // the hexes involved in the game board
        int boardWidth = 11;
        int boardHeight = 11;
        int FormHeight = 506;
        int FormWidth = 432;
        int HexHeight =40;
        PointF Selected;
        MarbleType Ascendency;

        bool Loaded;

        List<Marble> Marbles { get; set; }

        

        public Form1()
        {
            InitializeComponent();

            // select the area that will be used for the game

            Hexagons = new List<PointF>();
            Marbles = new List<Marble>();
            DefineBoard();

        }

        private void DefineBoard()
        {
            // top point
            Hexagons.Add(new PointF(0, 5));

            // top left diagonal
            Hexagons.Add(new PointF(1, 4));
            Hexagons.Add(new PointF(1, 3));
            Hexagons.Add(new PointF(2, 2));
            Hexagons.Add(new PointF(2, 1));

            // top right diagonal
            Hexagons.Add(new PointF(1, 6));
            Hexagons.Add(new PointF(1, 7));
            Hexagons.Add(new PointF(2, 8));
            Hexagons.Add(new PointF(2, 9));

            // left side vertical
            Hexagons.Add(new PointF(3, 0));
            Hexagons.Add(new PointF(4, 0));
            Hexagons.Add(new PointF(5, 0));
            Hexagons.Add(new PointF(6, 0));
            Hexagons.Add(new PointF(7, 0));
            Hexagons.Add(new PointF(8, 0));

            // right side vertical
            Hexagons.Add(new PointF(3, 10));
            Hexagons.Add(new PointF(4, 10));
            Hexagons.Add(new PointF(5, 10));
            Hexagons.Add(new PointF(6, 10));
            Hexagons.Add(new PointF(7, 10));
            Hexagons.Add(new PointF(8, 10));

            // bottom left diagonal
            Hexagons.Add(new PointF(8, 1));
            Hexagons.Add(new PointF(9, 2));
            Hexagons.Add(new PointF(9, 3));
            Hexagons.Add(new PointF(10, 4));

            // bottom right diagonal
            Hexagons.Add(new PointF(9, 8));
            Hexagons.Add(new PointF(8, 9));
            Hexagons.Add(new PointF(9, 7));
            Hexagons.Add(new PointF(10, 6));

            // bottom point 
            Hexagons.Add(new PointF(10, 5));

            // inner hexes
            for (int i = 1; i < 10; i++)
            {
                Hexagons.Add(new PointF(3, i));
                Hexagons.Add(new PointF(4, i));
                Hexagons.Add(new PointF(5, i));
                Hexagons.Add(new PointF(6, i));
                Hexagons.Add(new PointF(7, i));
            }

            for (int i = 2; i < 9; i++)
            {
                Hexagons.Add(new PointF(8, i));
              
            }

            Hexagons.Add(new PointF(9, 4));
            Hexagons.Add(new PointF(9, 5));
            Hexagons.Add(new PointF(9, 6));

            Hexagons.Add(new PointF(1,5));

            for (int i = 2; i < 8; i++)
            {
                Hexagons.Add(new PointF(2, i));

            }

        }

        private void CreateMarbles()
        {

            
            // gold doesn't need any matchers, but is frozen until Lead is upgraded enough
            Marble Gold = new Marble(MarbleState.Frozen, MarbleType.Gold)
            {
                Matchers = null
            };
            // place gold marble in the center
            Gold.Location = new PointF(Math.Abs(boardWidth / 2), Math.Abs(boardHeight / 2));
            Marbles.Add(Gold);

            // one of each of the lesser metals
            Marble Silver = new Marble(MarbleState.Frozen, MarbleType.Silver);
            Marbles.Add(Silver);
            Marble Copper = new Marble(MarbleState.Frozen, MarbleType.Copper);
            Marbles.Add(Copper);
            Marble Iron = new Marble(MarbleState.Frozen, MarbleType.Iron);
            Marbles.Add(Iron);
            Marble Tin = new Marble(MarbleState.Frozen, MarbleType.Tin);
            Marbles.Add(Tin);
            Marble Lead = new Marble(MarbleState.Frozen, MarbleType.Lead);
            Marbles.Add(Lead);
            // one quicksilver for each lesser metal
            Marble Quick1 = new Marble(MarbleState.Frozen, MarbleType.Quicksilver);
            Marbles.Add(Quick1);
            Marble Quick2 = new Marble(MarbleState.Frozen, MarbleType.Quicksilver);
            Marbles.Add(Quick2);
            Marble Quick3 = new Marble(MarbleState.Frozen, MarbleType.Quicksilver);
            Marbles.Add(Quick3);
            Marble Quick4 = new Marble(MarbleState.Frozen, MarbleType.Quicksilver);
            Marbles.Add(Quick4);
            Marble Quick5 = new Marble(MarbleState.Frozen, MarbleType.Quicksilver);
            Marbles.Add(Quick5);
            // 8 of each basic element
            Marble Air1 = new Marble(MarbleState.Frozen, MarbleType.Air);
            Marbles.Add(Air1);
            Marble Air2 = new Marble(MarbleState.Frozen, MarbleType.Air);
            Marbles.Add(Air2);
            Marble Air3 = new Marble(MarbleState.Frozen, MarbleType.Air);
            Marbles.Add(Air3);
            Marble Air4 = new Marble(MarbleState.Frozen, MarbleType.Air);
            Marbles.Add(Air4);
            Marble Air5 = new Marble(MarbleState.Frozen, MarbleType.Air);
            Marbles.Add(Air5);
            Marble Air6 = new Marble(MarbleState.Frozen, MarbleType.Air);
            Marbles.Add(Air6);
            Marble Air7 = new Marble(MarbleState.Frozen, MarbleType.Air);
            Marbles.Add(Air7);
            Marble Air8 = new Marble(MarbleState.Frozen, MarbleType.Air);
            Marbles.Add(Air8);

            Marble Earth1 = new Marble(MarbleState.Frozen, MarbleType.Earth);
            Marbles.Add(Earth1);
            Marble Earth2 = new Marble(MarbleState.Frozen, MarbleType.Earth);
            Marbles.Add(Earth2);
            Marble Earth3 = new Marble(MarbleState.Frozen, MarbleType.Earth);
            Marbles.Add(Earth3);
            Marble Earth4 = new Marble(MarbleState.Frozen, MarbleType.Earth);
            Marbles.Add(Earth4);
            Marble Earth5 = new Marble(MarbleState.Frozen, MarbleType.Earth);
            Marbles.Add(Earth5);
            Marble Earth6 = new Marble(MarbleState.Frozen, MarbleType.Earth);
            Marbles.Add(Earth6);
            Marble Earth7 = new Marble(MarbleState.Frozen, MarbleType.Earth);
            Marbles.Add(Earth7);
            Marble Earth8 = new Marble(MarbleState.Frozen, MarbleType.Earth);
            Marbles.Add(Earth8);

            Marble Fire1 = new Marble(MarbleState.Frozen, MarbleType.Fire);
            Marbles.Add(Fire1);
            Marble Fire2 = new Marble(MarbleState.Frozen, MarbleType.Fire);
            Marbles.Add(Fire2);
            Marble Fire3 = new Marble(MarbleState.Frozen, MarbleType.Fire);
            Marbles.Add(Fire3);
            Marble Fire4 = new Marble(MarbleState.Frozen, MarbleType.Fire);
            Marbles.Add(Fire4);
            Marble Fire5 = new Marble(MarbleState.Frozen, MarbleType.Fire);
            Marbles.Add(Fire5);
            Marble Fire6 = new Marble(MarbleState.Frozen, MarbleType.Fire);
            Marbles.Add(Fire6);
            Marble Fire7 = new Marble(MarbleState.Frozen, MarbleType.Fire);
            Marbles.Add(Fire7);
            Marble Fire8 = new Marble(MarbleState.Frozen, MarbleType.Fire);
            Marbles.Add(Fire8);

            Marble Water1 = new Marble(MarbleState.Frozen, MarbleType.Water);
            Marbles.Add(Water1);
            Marble Water2 = new Marble(MarbleState.Frozen, MarbleType.Water);
            Marbles.Add(Water2);
            Marble Water3 = new Marble(MarbleState.Frozen, MarbleType.Water);
            Marbles.Add(Water3);
            Marble Water4 = new Marble(MarbleState.Frozen, MarbleType.Water);
            Marbles.Add(Water4);
            Marble Water5 = new Marble(MarbleState.Frozen, MarbleType.Water);
            Marbles.Add(Water5);
            Marble Water6 = new Marble(MarbleState.Frozen, MarbleType.Water);
            Marbles.Add(Water6);
            Marble Water7 = new Marble(MarbleState.Frozen, MarbleType.Water);
            Marbles.Add(Water7);
            Marble Water8 = new Marble(MarbleState.Frozen, MarbleType.Water);
            Marbles.Add(Water8);

            // 4 salt marbles
            Marble Salt1 = new Marble(MarbleState.Frozen, MarbleType.Salt);
            Marbles.Add(Salt1);
            Marble Salt2 = new Marble(MarbleState.Frozen, MarbleType.Salt);
            Marbles.Add(Salt2);
            Marble Salt3 = new Marble(MarbleState.Frozen, MarbleType.Salt);
            Marbles.Add(Salt3);
            Marble Salt4 = new Marble(MarbleState.Frozen, MarbleType.Salt);
            Marbles.Add(Salt4);

            // 4 each of vitae and mors
            Marble Vitae1 = new Marble(MarbleState.Frozen, MarbleType.Vitae);
            Marbles.Add(Vitae1);
            Marble Vitae2 = new Marble(MarbleState.Frozen, MarbleType.Vitae);
            Marbles.Add(Vitae2);
            Marble Vitae3 = new Marble(MarbleState.Frozen, MarbleType.Vitae);
            Marbles.Add(Vitae3);
            Marble Vitae4 = new Marble(MarbleState.Frozen, MarbleType.Vitae);
            Marbles.Add(Vitae4);

            Marble Mors1 = new Marble(MarbleState.Frozen, MarbleType.Mors);
            Marbles.Add(Mors1);
            Marble Mors2 = new Marble(MarbleState.Frozen, MarbleType.Mors);
            Marbles.Add(Mors2);
            Marble Mors3 = new Marble(MarbleState.Frozen, MarbleType.Mors);
            Marbles.Add(Mors3);
            Marble Mors4 = new Marble(MarbleState.Frozen, MarbleType.Mors);
            Marbles.Add(Mors4);


        }

        private void PlaceMarbles()
        {
            Random rand = new Random();
            int randInt;
            
            // for each hex in the play area, try to add a marble, if the random number is outside the bounds of the list, nothing is added (blank space)
            foreach (PointF p in Hexagons)
            {
                if (p.X == 8 && p.Y == 10)
                {
                    int i = 0;
                }

                while (true)
                {
                    randInt = rand.Next(Marbles.Count + 10);

                    if (randInt >= Marbles.Count)
                    {
                        break;
                    }
                    if (!Marbles[randInt].Placed())
                    {
                        Marbles[randInt].Location = new PointF(p.Y, p.X);
                        break;
                    }
                }
                
                
            }
           
              

        }

        private void UnfreezeMarbles()
        {
            
            foreach (Marble m in Marbles)
            {
                // if this is a metal, check if it matches the current level of ascendency
                if (m.IsMetal() && m.Element != this.Ascendency)
                    continue;


                // check each side, if there is no marble in 3 consecutive spots, unfreeze it

                // check "top" means to check for 3 consecutive empty spaces involving the hex directly above this one
                if (CheckTop(m) == 3)
                {
                    m.State = MarbleState.Free;
                    continue;
                }
                
                if (CheckTopRight(m) == 3)
                {
                    m.State = MarbleState.Free;
                    continue;
                }

                if (CheckBottomRight(m) == 3)
                {
                    m.State = MarbleState.Free;
                    continue;
                }

                if (CheckBottom(m) == 3)
                {
                    m.State = MarbleState.Free;
                    continue;
                }

                if (CheckBottomLeft(m) == 3)
                {
                    m.State = MarbleState.Free;
                    continue;
                }

                if (CheckTopLeft(m) == 3)
                {
                    m.State = MarbleState.Free;
                    continue;
                }

            }
        }

        private int CheckTop(Marble m)
        {
            int count = 0;
            // check top
            if (GetMarble(m.GetTopXY()) == null)
            {
                count++;
                // top right
                if (GetMarble(m.GetTopRightXY()) == null)
                    count++;
                // top left
                if (GetMarble(m.GetTopLeftXY()) == null)
                    count++;

                if (count != 3)
                {
                    count = 1;
                    // top right
                    if (GetMarble(m.GetTopRightXY()) == null)
                        count++;
                    // bottom right
                    if (GetMarble(m.GetBottomRightXY()) == null)
                        count++;
                }

                if (count != 3)
                {
                    count = 1;
                    // top left
                    if (GetMarble(m.GetTopLeftXY()) == null)
                        count++;
                    // bottom left
                    if (GetMarble(m.GetBottomLeftXY()) == null)
                        count++;
                }

            }
            return count;
            
        }

        private int CheckTopRight(Marble m)
        {
            int count = 0;
            // check top right
            if (GetMarble(m.GetTopRightXY()) == null)
            {
                count++;
                // top 
                if (GetMarble(m.GetTopXY()) == null)
                    count++;
                // bottom right left
                if (GetMarble(m.GetBottomRightXY()) == null)
                    count++;

                if (count != 3)
                {
                    count = 1;
                    // top right
                    if (GetMarble(m.GetTopLeftXY()) == null)
                        count++;
                    // bottom right
                    if (GetMarble(m.GetTopXY()) == null)
                        count++;
                }

                if (count != 3)
                {
                    count = 1;
                    // top left
                    if (GetMarble(m.GetBottomRightXY()) == null)
                        count++;
                    // bottom left
                    if (GetMarble(m.GetBottomXY()) == null)
                        count++;
                }

            }
            return count;

        }

        private int CheckBottomRight(Marble m)
        {
            int count = 0;
            // check top right
            if (GetMarble(m.GetBottomRightXY()) == null)
            {
                count++;
                // top 
                if (GetMarble(m.GetTopRightXY()) == null)
                    count++;
                // bottom right left
                if (GetMarble(m.GetBottomXY()) == null)
                    count++;

                if (count != 3)
                {
                    count = 1;
                    // top right
                    if (GetMarble(m.GetTopXY()) == null)
                        count++;
                    // bottom right
                    if (GetMarble(m.GetTopRightXY()) == null)
                        count++;
                }

                if (count != 3)
                {
                    count = 1;
                    // top left
                    if (GetMarble(m.GetBottomXY()) == null)
                        count++;
                    // bottom left
                    if (GetMarble(m.GetBottomLeftXY()) == null)
                        count++;
                }

            }
            return count;

        }

        private int CheckBottom(Marble m)
        {
            int count = 0;
            // check top right
            if (GetMarble(m.GetBottomXY()) == null)
            {
                count++;
                // top 
                if (GetMarble(m.GetBottomRightXY()) == null)
                    count++;
                // bottom right left
                if (GetMarble(m.GetBottomLeftXY()) == null)
                    count++;

                if (count != 3)
                {
                    count = 1;
                    // top right
                    if (GetMarble(m.GetTopRightXY()) == null)
                        count++;
                    // bottom right
                    if (GetMarble(m.GetBottomRightXY()) == null)
                        count++;
                }

                if (count != 3)
                {
                    count = 1;
                    // top left
                    if (GetMarble(m.GetTopLeftXY()) == null)
                        count++;
                    // bottom left
                    if (GetMarble(m.GetBottomLeftXY()) == null)
                        count++;
                }

            }
            return count;

        }

        private int CheckBottomLeft(Marble m)
        {
            int count = 0;
            // check top right
            if (GetMarble(m.GetBottomLeftXY()) == null)
            {
                count++;
                // top 
                if (GetMarble(m.GetTopLeftXY()) == null)
                    count++;
                // bottom right left
                if (GetMarble(m.GetBottomXY()) == null)
                    count++;

                if (count != 3)
                {
                    count = 1;
                    // top right
                    if (GetMarble(m.GetBottomRightXY()) == null)
                        count++;
                    // bottom right
                    if (GetMarble(m.GetBottomXY()) == null)
                        count++;
                }

                if (count != 3)
                {
                    count = 1;
                    // top left
                    if (GetMarble(m.GetTopLeftXY()) == null)
                        count++;
                    // bottom left
                    if (GetMarble(m.GetTopXY()) == null)
                        count++;
                }

            }
            return count;

        }

        private int CheckTopLeft(Marble m)
        {
            int count = 0;
            // check top right
            if (GetMarble(m.GetTopLeftXY()) == null)
            {
                count++;
                // top 
                if (GetMarble(m.GetBottomLeftXY()) == null)
                    count++;
                // bottom right left
                if (GetMarble(m.GetTopXY()) == null)
                    count++;

                if (count != 3)
                {
                    count = 1;
                    // top right
                    if (GetMarble(m.GetTopXY()) == null)
                        count++;
                    // bottom right
                    if (GetMarble(m.GetTopRightXY()) == null)
                        count++;
                }

                if (count != 3)
                {
                    count = 1;
                    // top left
                    if (GetMarble(m.GetBottomLeftXY()) == null)
                        count++;
                    // bottom left
                    if (GetMarble(m.GetBottomXY()) == null)
                        count++;
                }

            }
            return count;

        }


        private Brush GetBrush(PointF p)
        {
            Brush result = null;
            Marble m = GetMarble((int)p.X, (int)p.Y);
            if (m == null)
                return Brushes.Beige;
            

            switch (m.Element)
            {
                case MarbleType.Air:
                    result = Brushes.WhiteSmoke;
                    break;
                case MarbleType.Water:
                    result = Brushes.Blue;
                    break;
                case MarbleType.Earth:
                    result = Brushes.Brown;
                    break;
                case MarbleType.Fire:
                    result = Brushes.Red;
                    break;
                case MarbleType.Salt:
                    result = Brushes.Gray;
                    break;
                case MarbleType.Vitae:
                    result = Brushes.Pink;
                    break;
                case MarbleType.Mors:
                    result = Brushes.Black;
                    break;
                case MarbleType.Quicksilver:
                    result = Brushes.LightGray;
                    break;
                case MarbleType.Lead:
                    result = Brushes.DarkBlue;
                    break;
                case MarbleType.Tin:
                    result = Brushes.DarkGray;
                    break;
                case MarbleType.Iron:
                    result = Brushes.DarkSlateBlue;
                    break;
                case MarbleType.Copper:
                    result = Brushes.SandyBrown;
                    break;
                case MarbleType.Silver:
                    result = Brushes.Silver;
                    break;
                case MarbleType.Gold:
                    result = Brushes.Gold;
                    break;
            }
            return result;
        }

        // Redraw the grid.
        private void picGrid_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            

            // Draw the selected hexagons.
           
            foreach (PointF point in Hexagons)
            {
                Brush b = GetBrush(point);
                //e.Graphics.FillPolygon(Brushes.Beige,                    HexToPoints(HexHeight, point.X, point.Y));
                e.Graphics.FillPolygon(b, HexToPoints(HexHeight, point.X, point.Y));
            }
            

            if (Selected.X >0 || Selected.Y > 0)
                e.Graphics.FillPolygon(Brushes.White,
                    HexToPoints(HexHeight, Selected.Y, Selected.X));


            // Draw the grid.
            Pen p = new Pen(Color.Black, 1);
            p.Alignment = PenAlignment.Outset;

            if (Loaded) return;
            DrawHexGrid(e.Graphics, p,
                0,this.ClientSize.Width ,
                0, this.ClientSize.Height,
                HexHeight);
            //Loaded = true;

            
        }



        // Draw a hexagonal grid for the indicated area.
        // (You might be able to draw the hexagons without
        // drawing any duplicate edges, but this is a lot easier.)
        private void DrawHexGrid(Graphics gr, Pen pen,
            float xmin, float xmax, float ymin, float ymax,
            float height)
        {
            // Loop until a hexagon won't fit.
            for (int row = 0; ; row++)
            {
                // Get the points for the row's first hexagon.
                PointF[] points = HexToPoints(height, row, 0);

                // If it doesn't fit, we're done.
                if (points[4].Y > ymax) break;

                // Draw the row.
                for (int col = 0; ; col++)
                {
                    // Get the points for the row's next hexagon.
                    points = HexToPoints(height, row, col);

                    // If it doesn't fit horizontally,
                    // we're done with this row.
                    if (points[3].X > xmax) break;

                    // If it fits vertically, draw it.
                    if (points[4].Y <= ymax)
                    {
                        gr.DrawPolygon(pen, points);
                    }
                }
            }
        }

        // Return the points that define the indicated hexagon.
        private PointF[] HexToPoints(float height, float row, float col)
        {
            // Start with the leftmost corner of the upper left hexagon.
            float width = HexWidth(height);
            float y = height / 2;
            float x = 0;

            // Move down the required number of rows.
            y += row * height;

            // If the column is odd, move down half a hex more.
            if (col % 2 == 1) y += height / 2;

            // Move over for the column number.
            x += col * (width * 0.75f);

            // Generate the points.
            return new PointF[]
                {
            new PointF(x, y),
            new PointF(x + width * 0.25f, y - height / 2),
            new PointF(x + width * 0.75f, y - height / 2),
            new PointF(x + width, y),
            new PointF(x + width * 0.75f, y + height / 2),
            new PointF(x + width * 0.25f, y + height / 2),
                };
        }

        // Return the width of a hexagon.
        private float HexWidth(float height)
        {
            return (float)(4 * (height / 2 / Math.Sqrt(3)));
        }

        // Return the row and column of the hexagon at this point.
        private void PointToHex(float x, float y, float height,
            out int row, out int col)
        {
            // Find the test rectangle containing the point.
            float width = HexWidth(height);
            col = (int)(x / (width * 0.75f));

            if (col % 2 == 0)
                row = (int)(y / height);
            else
                row = (int)((y - height / 2) / height);

            // Find the test area.
            float testx = col * width * 0.75f;
            float testy = row * height;
            if (col % 2 == 1) testy += height / 2;

            // See if the point is above or
            // below the test hexagon on the left.
            bool is_above = false, is_below = false;
            float dx = x - testx;
            if (dx < width / 4)
            {
                float dy = y - (testy + height / 2);
                if (dx < 0.001)
                {
                    // The point is on the left edge of the test rectangle.
                    if (dy < 0) is_above = true;
                    if (dy > 0) is_below = true;
                }
                else if (dy < 0)
                {
                    // See if the point is above the test hexagon.
                    if (-dy / dx > Math.Sqrt(3)) is_above = true;
                }
                else
                {
                    // See if the point is below the test hexagon.
                    if (dy / dx > Math.Sqrt(3)) is_below = true;
                }
            }

            // Adjust the row and column if necessary.
            if (is_above)
            {
                if (col % 2 == 0) row--;
                col--;
            }
            else if (is_below)
            {
                if (col % 2 == 1) row++;
                col--;
            }
        }

        // Display the row and column under the mouse.
        private void picGrid_MouseMove(object sender, MouseEventArgs e)
        {
            int row, col;
           
            PointToHex(e.X, e.Y, HexHeight, out row, out col);
            Marble m = GetMarble(row, col);
            if (m == null)
                this.Text = "(" + col + ", " + row + ")";
            else
                this.Text = "(" + m.Element + ", " + m.State.ToString() + ")" + " (" + col + ", " + row + ")";
        }

        // Add the clicked hexagon to the Hexagons list.
        private void picGrid_MouseClick(object sender, MouseEventArgs e)
        {
            int row, col;
            PointToHex(e.X, e.Y, HexHeight, out row, out col);
            

            Marble m = GetMarble(row, col);
            if (m != null && m.State != MarbleState.Frozen)
            {
                // a free marble is clicked on


                if (Selected.X == m.Location.X && Selected.Y == m.Location.Y) // clicked on the previously selected marble, deselect it
                {
                    Selected.X = 0;
                    Selected.Y = 0;
                } else if ((Selected.X !=0 && Selected.Y != 0) && GetMarble(Selected).Matchers.Contains(m.Element)) // clicked on a matching marble, remove them both from the game, clear selection
                {
                    if (m.IsMetal() || GetMarble(Selected).IsMetal())
                    {
                        Ascend();
                    }
                    Marbles.Remove(GetMarble(Selected));
                    Marbles.Remove(m);
                    
                    Selected.X = 0;
                    Selected.Y = 0;
                }
                else
                    Selected = new PointF(col, row);

                UnfreezeMarbles();
                this.Refresh();

                if (Marbles.Count == 0)
                    MessageBox.Show("Winner!");
            }
            
            return;
            // original code for selecting hexes with the mouse
            //int row, col;
            //PointToHex(e.X, e.Y, HexHeight, out row, out col);
            //Hexagons.Add(new PointF(row, col));

            //this.Refresh();
        }
        private void Ascend()
        {
            switch (Ascendency)
            {
                case MarbleType.Lead:
                    Ascendency = MarbleType.Tin;
                    break;
                case MarbleType.Tin:
                    Ascendency = MarbleType.Iron;
                    break;
                case MarbleType.Iron:
                    Ascendency = MarbleType.Copper;
                    break;
                case MarbleType.Copper:
                    Ascendency = MarbleType.Silver;
                    break;
                case MarbleType.Silver:
                    Ascendency = MarbleType.Gold;
                    break;
                default:
                    break;
            }
        }

        private Marble GetMarble(int row, int col)
        {
            foreach (Marble m in Marbles)
            {
                if (m.Location.X == col && m.Location.Y == row)
                    return m;
            }
            return null;
        }

        private Marble GetMarble(PointF p)
        {
            foreach (Marble m in Marbles)
            {
                if (m.Location.X == p.X && m.Location.Y == p.Y)
                    return m;
            }
            return null;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ascendency = MarbleType.Lead;
            Marbles.Clear();
            CreateMarbles();
            PlaceMarbles();
            UnfreezeMarbles();
            this.Refresh();
        }
    }
}
