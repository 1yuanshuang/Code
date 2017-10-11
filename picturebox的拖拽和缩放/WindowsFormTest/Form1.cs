using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormTest
{
    public partial class Form1 : Form
    {
        const int Band = 5;
        const int MinWidth = 10;
        const int MinHeight = 10;
        private EnumMousePointPosition m_MousePointPosition;
        private Point p, p1;
        private bool MoveFlag;
        private int xPos;
        private int yPos;

        private enum EnumMousePointPosition
        {
            MouseSizeNone = 0, //'无  
            MouseSizeRight = 1, //'拉伸右边框  
            MouseSizeLeft = 2, //'拉伸左边框  
            MouseSizeBottom = 3, //'拉伸下边框  
            MouseSizeTop = 4, //'拉伸上边框  
            MouseSizeTopLeft = 5, //'拉伸左上角  
            MouseSizeTopRight = 6, //'拉伸右上角  
            MouseSizeBottomLeft = 7, //'拉伸左下角  
            MouseSizeBottomRight = 8, //'拉伸右下角  
            MouseDrag = 9   // '鼠标拖动  
        }

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < this.panel1.Controls.Count; i++)
            {
                this.panel1.Controls[i].MouseDown += new MouseEventHandler(MyMouseDown);
                this.panel1.Controls[i].MouseLeave += new EventHandler(MyMouseLeave);
                this.panel1.Controls[i].MouseMove += new MouseEventHandler(MyMouseMove);
            }
            this.circle1.BackColor = Color.Transparent;
            //this.circle1.BringToFront();
            //pictureBox1.SendToBack();
            //pictureBox1.Controls.Add(circle1);
            

        }

        private void MyMouseLeave(object sender, System.EventArgs e)
        {
            m_MousePointPosition = EnumMousePointPosition.MouseSizeNone;
            this.Cursor = Cursors.Arrow;
        }

        private void MyMouseMove(object sender,MouseEventArgs e)
        {
            Control lCtrl = (sender as Control);

            if (e.Button == MouseButtons.Left)
            {
                switch (m_MousePointPosition)
                {
                    case EnumMousePointPosition.MouseDrag:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Top = lCtrl.Top + e.Y - p.Y;
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;

                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点  
 
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        lCtrl.Width = lCtrl.Width + e.X - p1.X;
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
 
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点  
 
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        lCtrl.Width = lCtrl.Width + e.X - p1.X;
 
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点  
 
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;

                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点

                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Width = lCtrl.Width + (e.X - p1.X);

                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点  
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        break;
                    default:
                        break;
                }
                if (lCtrl.Width < MinWidth) lCtrl.Width = MinWidth;
                if (lCtrl.Height < MinHeight) lCtrl.Height = MinHeight;

            }
            else
            {
                m_MousePointPosition = MousePointPosition(lCtrl.Size, e);   //'判断光标的位置状态  
                switch (m_MousePointPosition)   //'改变光标  
                {
                    case EnumMousePointPosition.MouseSizeNone:
                        this.Cursor = Cursors.Arrow;        //'箭头  
                        break;
                    case EnumMousePointPosition.MouseDrag:
                        this.Cursor = Cursors.SizeAll;      //'四方向  
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        this.Cursor = Cursors.SizeNS;       //'南北  
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        this.Cursor = Cursors.SizeNS;       //'南北  
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        this.Cursor = Cursors.SizeWE;       //'东西  
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        this.Cursor = Cursors.SizeWE;       //'东西  
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        this.Cursor = Cursors.SizeNESW;     //'东北到南西  
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        this.Cursor = Cursors.SizeNWSE;     //'东南到西北  
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        this.Cursor = Cursors.SizeNWSE;     //'东南到西北  
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        this.Cursor = Cursors.SizeNESW;     //'东北到南西  
                        break;
                    default:
                        break;
                }
            }

        }

        private EnumMousePointPosition MousePointPosition(Size size, MouseEventArgs e)
        {
            if ((e.X >= -1 * Band) | (e.X <= size.Width) | (e.Y >= -1 * Band) | (e.Y <= size.Height))
            {
                if (e.X < Band)
                {
                    if (e.Y < Band)
                    {
                        return EnumMousePointPosition.MouseSizeTopLeft;
                    }
                    else
                    {
                        if (e.Y > -1 * Band + size.Height)
                        {
                            return EnumMousePointPosition.MouseSizeBottomLeft;
                        }
                        else
                        {
                            return EnumMousePointPosition.MouseSizeLeft;
                        }
                    }
                }
                else
                {
                    if (e.X > -1 * Band + size.Width)
                    {
                        if (e.Y < Band)
                        {
                            return EnumMousePointPosition.MouseSizeTopRight;
                        }
                        else
                        {
                            if (e.Y > -1 * Band + size.Height)
                            {
                                return EnumMousePointPosition.MouseSizeBottomRight;
                            }
                            else
                            {
                                return EnumMousePointPosition.MouseSizeRight;
                            }
                        }
                    }
                    else
                    {
                        if (e.Y < Band)
                        {
                            return EnumMousePointPosition.MouseSizeTop;
                        }
                        else
                        {
                            if (e.Y > -1 * Band + size.Height)
                            {
                                return EnumMousePointPosition.MouseSizeBottom;
                            }
                            else
                            {
                                return EnumMousePointPosition.MouseDrag;
                            }
                        }
                    }
                }
            }
            else
            {
                return EnumMousePointPosition.MouseSizeNone;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            m_MousePointPosition = EnumMousePointPosition.MouseSizeNone;
            this.Cursor = Cursors.Arrow;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
        }


        void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            double scale = 1;
            if (pictureBox1.Height > 0)
            {
                scale = (double)pictureBox1.Width / (double)pictureBox1.Height;
            }
            pictureBox1.Width += (int)(e.Delta * scale);
            pictureBox1.Height += e.Delta;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            MoveFlag = true;//已经按下.
            xPos = e.X;//当前x坐标.
            yPos = e.Y;//当前y坐标.
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            MoveFlag = false;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (MoveFlag)
            {
                circle1.Left += Convert.ToInt16(e.X - xPos);//设置x坐标.
                circle1.Top += Convert.ToInt16(e.Y - yPos);//设置y坐标.
            }
        }


        //private void pictureBox2_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics; 
        //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        //    Pen p = new Pen(Color.Blue, 1);
        //    g.DrawLine(new Pen(Color.Red,3), 250, 250, 251, 251);

        //    g.DrawEllipse(p, 200, 200, 100, 100); 
        //    g.DrawEllipse(p, 150, 150, 200, 200);
        //    g.DrawEllipse(p, 100, 100, 300, 300);
        //    g.DrawEllipse(p, 50, 50, 400, 400);
        //    g.DrawEllipse(p, 0, 0, 500, 500);

        //}

        private void MyMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            p.X = e.X;
            p.Y = e.Y;
            p1.X = e.X;
            p1.Y = e.Y;

            if (e.Button == MouseButtons.Left)
            {
                if (pictureBox1.Width < 1000)
                {
                    pictureBox1.Width = Convert.ToInt32(pictureBox1.Width * 1.2);
                    pictureBox1.Height = Convert.ToInt32(pictureBox1.Height * 1.2);
                }

            }
            if (e.Button == MouseButtons.Right)
            {
                if (pictureBox1.Width > 600)
                {
                    pictureBox1.Width = Convert.ToInt32(pictureBox1.Width / 1.2);
                    pictureBox1.Height = Convert.ToInt32(pictureBox1.Height / 1.2);
                }
            }
        }
    }
}
