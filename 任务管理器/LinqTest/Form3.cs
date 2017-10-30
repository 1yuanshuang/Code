using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqTest
{
    public partial class Form3 : Form
    {
        Form1 f = new Form1();       
        ListView l = new ListView();
        ListViewItem lvi = new ListViewItem();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {                  
                    lvi.SubItems.Add(checkedListBox1.GetItemText(checkedListBox1.Items[i]));
                    
                    //MessageBox.Show(checkedListBox1.GetItemText(checkedListBox1.Items[i]));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
