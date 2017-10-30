using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevMgr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void 禁用DToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 卸载UToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IList<HardwareClass.HardwareInfo> _HardwareInfo = HardwareClass.GetHardwareTable();

            dataGridView1.DataSource = _HardwareInfo;
            for (int i = 0; i != _HardwareInfo.Count; i++)
            {
                if (_HardwareInfo[i].DeviceName.IndexOf("打印机端口") != -1)
                {
                    _HardwareInfo[i].SetEnabled(false);
                    MessageBox.Show("去看看 设备管理器的状态:)");
                    _HardwareInfo[i].SetEnabled(true);//修改为启动状态
                }
            }
        }
    }
}
