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

namespace TestWindow
{
    public partial class Form1 : Form
    {
        static int i = 0;
        ArrayList array = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            btn_back.Enabled = false;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 m = (array[i]) as Form1;
            m.Visible = false;
            m.btn_next.Enabled = true;
            i--;
          
            Form1 m1 = (array[i]) as Form1;
            m1.Visible = true;

            if (i == 0)
            {
                m1.btn_back.Enabled = false;
            }


        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 m = (array[i]) as Form1;
            m.Visible = false;
            m.btn_back.Enabled = true;
            i++;
     
            Form1 m1 = (array[i]) as Form1;

            m1.btn_back.Enabled = true;
            m1.Visible = true;
            if (i == array.Count - 1)
            {
                m1.btn_next.Enabled = false;
            }

        }

        private void btn_end_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            PictureBox p = new PictureBox();
            p.Size = new Size(300, 300);
            p.Location = new Point(200, 100);
            p.BackColor = Color.Blue;
            form1.Controls.Add(p);

            Form1 form2 = new Form1();
            ListBox l = new ListBox();
            l.Size = new Size(300, 300);
            l.Location = new Point(200, 100);
            l.BackColor = Color.Red;
            form2.Controls.Add(l);

            Form1 form3 = new Form1();
            Button b = new Button();
            b.BackColor = Color.Pink;
            b.Text = "这是一个按钮";
            b.Size = new Size(300, 100);
            b.Location = new Point(200, 150);
            form3.Controls.Add(b);

            array.Add(form1);
            array.Add(form2);
            array.Add(form3);
        }
    }
}


// f1.Visible = false;
//f1.Close();
//SaveFileDialog s = new SaveFileDialog();
//s.ShowDialog();

//OpenFileDialog o = new OpenFileDialog();
//  o.ShowDialog();

// f.Close();
// f.Visible = false;
//label1.Text = "欢迎进入";

//  DialogResult MsgBoxResult;//设置对话框的返回值
//  MsgBoxResult = MessageBox.Show("请选择你要按下的按钮",//对话框的显示内容
//"提示",//对话框的标题
//  MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮
//  MessageBoxIcon.Exclamation,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号
//  MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
//  if (MsgBoxResult == DialogResult.Yes)//如果对话框的返回值是YES（按"Y"按钮）
//  {
//      this.label1.ForeColor = System.Drawing.Color.Red;//字体颜色设定
//      label1.Text = " 你选择了按下”Yes“的按钮！";
//  }
//  if (MsgBoxResult == DialogResult.No)//如果对话框的返回值是NO（按"N"按钮）
//  {
//      this.label1.ForeColor = System.Drawing.Color.Blue;//字体颜色设定
//      label1.Text = " 你选择了按下”No“的按钮！";
//  }
//f.ShowDialog();