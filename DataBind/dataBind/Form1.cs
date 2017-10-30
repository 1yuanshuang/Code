using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataBind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MyData data = new MyData();


        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.DataBindings.Add("Text", data, "Text", false, DataSourceUpdateMode.OnPropertyChanged);
            button1.DataBindings.Add("Enabled", data, "Enabled", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data.Text += "dguiw";
        }
    }
}
