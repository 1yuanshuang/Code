using System;
using System.Collections;
using System.Windows.Forms;

namespace testForm
{
    public partial class Form1 : Form
    {
        static int i = 0;
        ArrayList array = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            array.Add(panel1);
            array.Add(panel2);
            array.Add(panel3);

            gpbWindows.Controls.Add(panel1);
            gpbWindows.Controls.Add(panel2);
            gpbWindows.Controls.Add(panel3);
            this.button1.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = true;

            System.Windows.Forms.Control m = (array[i]) as System.Windows.Forms.Control;
            m.Visible = false;
            --i;

            if (i == 0)
            {
                this.button1.Enabled = false;
            }
    
            System.Windows.Forms.Control m1 = (array[i]) as System.Windows.Forms.Control;
            m1.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = true;

            System.Windows.Forms.Control m = (array[i]) as System.Windows.Forms.Control;
            m.Visible = false;
            i++;
            System.Windows.Forms.Control m1 = (array[i]) as System.Windows.Forms.Control;
            m1.Visible = true;

            if (i == array.Count - 1)
            {
                this.button2.Enabled = false; ;
            }

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
    }
}
