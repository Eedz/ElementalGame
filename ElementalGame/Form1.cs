using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace ElementalGame
{
    public partial class Form1 : Form
    {

        List<Rectangle> BoardSpaces;
        int SpaceHeight = 10;
        int SpaceWidth = 10;
        public Form1()
        {
            InitializeComponent();

            BoardSpaces.Add(new Rectangle(this.Width / 2 - SpaceWidth, this.Height / 2 + SpaceHeight, SpaceWidth, SpaceHeight));
            BoardSpaces.Add(new Rectangle(this.Width / 2 - SpaceWidth, this.Height / 2 + SpaceHeight, SpaceWidth, SpaceHeight));
        }



        private void DrawRectangle(Rectangle r)
        {
            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            List<Point> points;
            points.Add(new Point(this.Width / 2 - SpaceWidth, this.Height / 2 + SpaceHeight))
            
            formGraphics.DrawPolygon(myPen, points);
            myPen.Dispose();
            formGraphics.Dispose();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach(Rectangle r in BoardSpaces)
                DrawRectangle(r);
        }
    }
}
