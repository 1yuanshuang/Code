using System;
using System.Collections;
using System.Windows.Forms;

namespace TestWinform
{
    public partial class Form1 : Form
    {
        public windows1 w1;
        public Windows2 w2;
        public Windows3 w3;
        public Windows4 w4;

        static int i = 0;

        ArrayList array = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            w1 = new windows1();
            w2 = new Windows2();
            w3 = new Windows3();
            w4 = new Windows4();

            array.Add(w1);
            array.Add(w2);
            array.Add(w3);
            array.Add(w4);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button1.Enabled = false;

            for (int j = 0; j < array.Count; j++)
            {
                System.Windows.Forms.Control s = (array[j]) as System.Windows.Forms.Control;
                gpbWindows.Controls.Add(s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = true;
            System.Windows.Forms.Control m = (array[i]) as System.Windows.Forms.Control;
            m.Visible = false;
            --i;

            System.Windows.Forms.Control m1 = (array[i]) as System.Windows.Forms.Control;
            if (i == 0)
            {
                this.button1.Enabled = false;
            }
            m1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.button1.Enabled = true;

            System.Windows.Forms.Control m = (array[i]) as System.Windows.Forms.Control;
            m.Visible = false;
            i++;
            System.Windows.Forms.Control m1 = (array[i]) as System.Windows.Forms.Control;
            m1.Visible = true;
            //gpbWindows.Controls.Add(m1);
            if (i == array.Count - 1)
            {
                this.button2.Enabled = false; ;
            }
            //gpbWindows.Controls.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}


        //w1.Show();
        //gpbWindows.Controls.Clear();
        //gpbWindows.Controls.Add(w1);
        //w1.Show();

        //gpbWindows.Controls.Clear();
        //gpbWindows.Controls.Add(w1);
        //this.button1.Enabled = false;

        //w2.Show();
        //gpbWindows.Controls.Clear();
        //gpbWindows.Controls.Add(w2);
        ////gpbWindows.Controls.Clear();
        ////w1.Visible = false;
        //w2.Invalidate();
        //gpbWindows.Controls.Add(w3);
        // w3.Show();


        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    tabControl1.SizeMode = TabSizeMode.Fixed;
        //    tabControl1.ItemSize = new Size(0, 1);
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    TabPage Page = new TabPage();
        //    Page.Name = "Page" + index.ToString();
        //    Page.Text = "tabPage" + index.ToString();
        //    Page.TabIndex = index;
        //    this.tabControl1.Controls.Add(Page);

        //    #region 三种设置某个选项卡为当前选项卡的方法  
        //    //this.tabControl1.SelectedIndex = index;  
        //    this.tabControl1.SelectedTab = Page;
        //    //this.tabControl1.SelectTab("Page" + index.ToString());  
        //    #endregion

        //    index++;
        //}

        //private void tabControl1_Selected(object sender, TabControlEventArgs e)
        //{
        // //   this.tabControl1.SelectedIndex = selected;
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    bool first = true;
        //    if (index > 0)
        //    {
        //        #region 两种删除某个选项卡的方法  
        //        this.tabControl1.Controls.RemoveAt(this.tabControl1.SelectedIndex);
        //        //this.tabControl1.Controls.Remove(this.tabControl1.TabPages[this.tabControl1.TabPages.Count-1]);  
        //        #endregion
        //    }
        //    else
        //    {
        //        return;
        //    }

        //    #region 用于设置删除最后一个TabPage后，将倒数第二个设置为当前选项卡  
        //    if (first)
        //    {
        //        this.tabControl1.SelectedIndex = --index - 1;
        //        first = false;
        //    }
        //    else
        //    {
        //        this.tabControl1.SelectedIndex = index--;
        //    }
        //    #endregion
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    this.tabControl1.SelectedTab.Text = "xyt";//修改当前选项卡的属性  
        //}

        //private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

