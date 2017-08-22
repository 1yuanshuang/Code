using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JYSwitchDemo
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void jySwitch1_CheckChanged(object sender, EventArgs e)
        {
            JYSwitch sw = (JYSwitch)sender;
            this.Led.Light = sw.Checked;
        }

        private void Led_Load(object sender, EventArgs e)
        {

        }
    }
}
