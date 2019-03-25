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
    class FigurRektangel : Figur
    {
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                var rc = getRectangle();
                if (rc.Width > 0 && rc.Height > 0) figures.Add(rc);
                this.Invalidate(); //ritar om fönstret
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            
            if (figures.Count > 0) e.Graphics.DrawRectangles(Pens.Red, figures.ToArray());
            if (drawing) e.Graphics.DrawRectangle(Pens.Black, getRectangle());
        }
    }
}
