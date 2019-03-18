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
    class Penna : Panel
    {
        bool draw = false;

        int pX = -1;
        int pY = -1;


        Bitmap drawing;  
        
        public Penna()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 400;
            this.Height = 600;

            drawing = new Bitmap(this.Width, this.Height, this.CreateGraphics());
            Graphics.FromImage(drawing).Clear(Color.White);
          
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            draw = true;

            pX = e.X;
            pY = e.Y;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (draw)
            {
                Graphics panel = Graphics.FromImage(drawing);

                Pen pen = new Pen(Color.Black, 14);

                pen.EndCap = LineCap.Round;
                pen.StartCap = LineCap.Round;

                panel.DrawLine(pen, pX, pY, e.X, e.Y);

                this.CreateGraphics().DrawImageUnscaled(drawing, new Point(0, 0));
            }
            pX = e.X;
            pY = e.Y;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            draw = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(drawing, new Point(0, 0));
            
        }

    }
}
