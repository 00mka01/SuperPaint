using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace mypaint
{
    class FigurCirkel : Figur
    {
        List<Rectangle> rectangles = new List<Rectangle>();
        
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                var rc = getRectangle();
                if (rc.Width > 0 && rc.Height > 0) rectangles.Add(rc);
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (rectangles.Count > 0)
            {
                foreach (Rectangle r in rectangles)
                    e.Graphics.DrawEllipse(Pens.Red, r);
            }
            if (drawing) e.Graphics.DrawEllipse(Pens.Black, getRectangle());
        }
    }
}