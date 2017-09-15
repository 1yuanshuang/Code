using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqTest
{
    public partial class Form2 : Form
    {
        public int pid = 0;
        public long totalMemery = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
             if(pid==0)
            {
                return;
            }
            Process p=Process.GetProcessById(pid);
            if(p==null)
                return;
            try
            {
                if(p.MainModule!=null)
                {
                    string path = "";
                    path = p.MainModule.FileName.ToString();
                    FileInfo fi = new FileInfo(path);

                    label10.Text = p.ProcessName;
                    label11.Text = p.MainModule.FileVersionInfo.FileDescription;
                    label12.Text = path;
                    label13.Text = Math.Ceiling(fi.Length / 1024.0) + " KB";
                    totalMemery += p.PrivateMemorySize64 / 1024;
                    label14.Text = totalMemery.ToString();
                    label15.Text = fi.CreationTime.ToString();
                    label16.Text = fi.LastWriteTime.ToString();
                    label17.Text = fi.LastAccessTime.ToString();
                    textBox1.Text = p.ProcessName;

                    FileVersionInfo info = FileVersionInfo.GetVersionInfo(path);
                    label33.Text = info.FileDescription;
                    label34.Text = fi.Extension;
                    label35.Text = info.FileVersion;
                    label36.Text = info.ProductName;
                    label37.Text = info.ProductVersion;
                    label38.Text = info.LegalCopyright;
                    label39.Text = Math.Ceiling(fi.Length / 1024.0) + " KB";
                    label40.Text = fi.LastWriteTime.ToString();
                    label41.Text = info.Language;
                    label42.Text = info.OriginalFilename;
                }

            }

            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "出现异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
