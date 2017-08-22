using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JYSwitchDemo
{
    public partial class LED : UserControl
    {
        SolidBrush mySolidBrush;

        public bool Light
        {
            set
            {
                if (value)
                {
                    mySolidBrush = new SolidBrush(Color.Green);
                }

                else
                {
                    mySolidBrush = new SolidBrush(Color.Red);
                }

                this.Invalidate();
            }
        }

        public LED()
        {
            InitializeComponent();
            mySolidBrush = new SolidBrush(Color.Red);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.FillEllipse(mySolidBrush, rec);
        }
    }
}
