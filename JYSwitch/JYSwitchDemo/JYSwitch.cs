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
    public partial class JYSwitch : UserControl
    {
        public JYSwitch()
        {
            InitializeComponent();
            //设置Style支持透明背景色并且双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
            //鼠标移动到控件时变成手型
            this.Cursor = Cursors.Hand;
            //初始生成时候的大小
            this.Size = new Size(87, 27);
            //注册控件单击事件
            this.Click += new System.EventHandler(this.JYSwitch_Click);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bitMapOn = null;
            Bitmap bitMapOff = null;
            if (checkStyle == CheckStyle.style1)
            {
                bitMapOn = global::JYSwitchDemo.Properties.Resources.垂直开;
                bitMapOff = global::JYSwitchDemo.Properties.Resources.垂直关;
            }
            else if (checkStyle == CheckStyle.style2)
            {
                bitMapOn = global::JYSwitchDemo.Properties.Resources.垂直开2;
                bitMapOff = global::JYSwitchDemo.Properties.Resources.垂直关1;
            }
            else if (checkStyle == CheckStyle.style3)
            {
                bitMapOn = global::JYSwitchDemo.Properties.Resources.按钮开;
                bitMapOff = global::JYSwitchDemo.Properties.Resources.按钮关;
            }
            else if (checkStyle == CheckStyle.style4)
            {
                bitMapOn = global::JYSwitchDemo.Properties.Resources.水平开;
                bitMapOff = global::JYSwitchDemo.Properties.Resources.水平关;
            }
            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            if (isCheck)
            {
                g.DrawImage(bitMapOn, rec);
            }
            else
            {
                g.DrawImage(bitMapOff, rec);
            }
        }
    }
}
