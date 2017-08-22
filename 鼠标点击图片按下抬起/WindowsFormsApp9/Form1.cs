using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }  
        //bool flag = false;

        ////响应点击事件
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (!flag)
        //    {
        //        this.button1.Image = Image.FromFile(@"2.png");
        //    }
        //    else
        //    {
        //        this.button1.Image = Image.FromFile(@"1.png");
        //    }
        //    flag = true;
        //}

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            this.button1.Image = Image.FromFile(@"2.png");
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            this.button1.Image = Image.FromFile(@"1.png");
        }


        //private void button1_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    this.button1.Image = Image.FromFile(@"2.png");
        //}

        //private void button1_MouseLeave(object sender, EventArgs e)
        //{
        //    this.button1.Image = Image.FromFile(@"1.png");
        //}
    }
}
