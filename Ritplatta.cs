using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace mypaint
{
    class Ritplatta : Panel
    {
        protected Point startPos;
        protected Point currentPos;
        protected bool drawing;
        int pX = -1;
        int pY = -1;
        Bitmap drawer;
           
        public List<Rectangle> figures = new List<Rectangle>();
        List<Rectangle> rectangles = new List<Rectangle>();
        public string Ritläge;
        public Ritplatta()
        
        
        {
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 400;
            this.Height = 600;
        }
        protected Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {

           currentPos = startPos = e.Location;
           drawing = true;
            
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {if (Ritläge == "rektangel")
            {


                if (drawing)
                {
                    currentPos = e.Location;
                    this.Invalidate();
                }
            }
        if (Ritläge == "cirkel")
            { if (drawing)
                {
                    currentPos = e.Location;
                    this.Invalidate();

                }
                        
                        
                        }
        if (Ritläge == "penna")
            { if (drawing)

                {
                    Graphics panel = Graphics.FromImage(drawer);

                    Pen pen = new Pen(Color.Black, 14);

                    pen.EndCap = LineCap.Round;
                    pen.StartCap = LineCap.Round;

                    panel.DrawLine(pen, pX, pY, e.X, e.Y);

                    this.CreateGraphics().DrawImageUnscaled(drawer, new Point(0, 0));
                }
                
            }
            pX = e.X;
            pY = e.Y;


        }

        protected override void OnMouseUp(MouseEventArgs e)
        {if (Ritläge == "rektangel")
            {
                if (drawing)
                {
                    drawing = false;
                    var rc = getRectangle();
                    if (rc.Width > 0 && rc.Height > 0) figures.Add(rc);
                    this.Invalidate(); //ritar om fönstret
                }
            }
             if(Ritläge == "cirkel") {
                if (drawing)
                {
                    drawing = false;
                    var rc = getRectangle();
                    if (rc.Width > 0 && rc.Height > 0) rectangles.Add(rc);
                    this.Invalidate();
                }
            }
            if(Ritläge == "penna")
            {
                if (drawing)
                {
                    drawing = false;
                }
            }
        }




        protected override void OnPaint(PaintEventArgs e)

        {
            //if (Ritläge == "rektangel")
            {
                if (figures.Count > 0) e.Graphics.DrawRectangles(Pens.Red, figures.ToArray());
                if (drawing) e.Graphics.DrawRectangle(Pens.Black, getRectangle());
            }
            //if (Ritläge == "cirkel")
            {
                if (rectangles.Count > 0)
                {
                    foreach (Rectangle r in rectangles)
                        e.Graphics.DrawEllipse(Pens.Red, r);
                }
                if (drawing) e.Graphics.DrawEllipse(Pens.Black, getRectangle());
            }
            if (Ritläge == "penna")
            {

                e.Graphics.DrawImageUnscaled(drawer, new Point(0, 0));


            }
        }


    }
}

