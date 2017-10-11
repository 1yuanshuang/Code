using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormTest
{
    public partial class Circle : UserControl
    {
        public Circle()
        {
            InitializeComponent();
        }

        private void Circle_Load(object sender, EventArgs e)
        {

        }

        private void Circle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen p = new Pen(Color.Blue, 1);
            g.DrawLine(new Pen(Color.Red, 3), 250, 250, 251, 251);

            g.DrawEllipse(p, 200, 200, 100, 100);
            g.DrawEllipse(p, 150, 150, 200, 200);
            g.DrawEllipse(p, 100, 100, 300, 300);
            g.DrawEllipse(p, 50, 50, 400, 400);
            g.DrawEllipse(p, 0, 0, 500, 500);
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = -1;
            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)(HTTRANSPARENT);
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
