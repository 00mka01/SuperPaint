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

namespace mypaint // Ändring 13:58 4/3
{
    public partial class Form1 : Form
    {
        FigurRektangel rekt;
        FigurCirkel cirk;
        Penna pen;        

        public Form1()
        {
            InitializeComponent();            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Rectangle_CheckedChanged(object sender, EventArgs e)
        {
            rekt = new FigurRektangel();
            this.Controls.Add(rekt);
        }

        private void Circle_CheckedChanged(object sender, EventArgs e)
        {
            cirk = new FigurCirkel();
            this.Controls.Add(cirk);
        }

        private void Pen1_CheckedChanged(object sender, EventArgs e)
        {
            pen = new Penna();           
            this.Controls.Add(pen);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if(c.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = c.Color;                                 
            }
        }

    }
}
