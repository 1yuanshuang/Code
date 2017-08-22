using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowTest
{
    public partial class Form1 : Form
    {
        static int i = 0;

        public Form1()
        {
            InitializeComponent();
            this.button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = true;
          
            tabControl2.SelectedIndex = --i;
            if (tabControl2.SelectedIndex == 0)
            {
                this.button1.Enabled = false;
            }                 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i++;
            this.button1.Enabled = true;
            tabControl2.SelectedIndex = i;

            if(tabControl2.SelectedIndex ==2)
            {
                this.button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl2.SizeMode = TabSizeMode.Fixed;
            tabControl2.ItemSize = new Size(0, 1);
        }
    }
}

// this.tabControl2 = new TabControl();
// TabPage tabPage1 = new TabPage();
//tabPage1.Text = "上一步";
// TabPage tabPage2 = new TabPage();
// tabPage2.Text = "下一步";
// TabPage tabPage3 = new TabPage();
//tabPage3.Text = "结束";

// TabPage tabPage4 = new TabPage();
// TabPage tabPage5 = new TabPage();

// TabPage[] tabPages = { tabPage1, tabPage2, tabPage3, tabPage4, tabPage5 };
// this.tabControl2.Controls.AddRange(new Control[] {
// tabPage1, tabPage2, tabPage3, tabPage4, tabPage5});
//// this.tabControl1.Location = new Point(35, 25);
// this.tabControl2.Size = new Size(520, 520);

// this.Size = new Size(600, 600);
// this.Controls.Add(tabControl2);
