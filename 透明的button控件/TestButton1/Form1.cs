using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestButton1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.BackColor = Color.FromArgb(0, 0, 0, 0);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 0);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi!");
        }

    }
}
