using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
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

        //public string GetName()
        //{
        //    try
        //    {
        //        ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process");
        //        string name = "";
        //        foreach (ManagementObject mo in searcher.Get())
        //        {
        //            name = mo["Name"].ToString().Trim();
        //            break;
        //        }
        //        return name;
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}


        //public string GetID()
        //{
        //    try
        //    {
        //        ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process");
        //        string id = "";
        //        foreach (ManagementObject mo in searcher.Get())
        //        {
        //            id = mo["ProcessId"].ToString().Trim();
        //            break;
        //        }
        //        return id;
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}

        //public string GetVersion()
        //{
        //    try
        //    {
        //        ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process");
        //        string version = "";
        //        foreach (ManagementObject mo in searcher.Get())
        //        {
        //            version = mo["ProcessName"].ToString().Trim();
        //            break;
        //        }
        //        return version;
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}

        //public string GetDescription()
        //{
        //    try
        //    {
        //        ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process");
        //        string dc = "";
        //        foreach (ManagementObject mo in searcher.Get())
        //        {
        //            dc = mo["Description"].ToString().Trim();
        //            break;
        //        }
        //        return dc;
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}

        public static void GetLogicalDiskInfo()
        {
            try
            {
                Console.WriteLine("逻辑磁盘信息");
                string dc = "";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_LogicalDisk");
                foreach (ManagementObject mo in searcher.Get())
                {
                    dc = mo["FreeSpace"].ToString().Trim();
                    break;
                }
                //foreach (ManagementObject mo in searcher.Get())
                //{
                //    // mo["FileSystem"]，文件系统，如“FAT32”  
                //    // mo["FreeSpace"]，剩余空间，如“4554891264”（4G多）  
                //    // mo["Name"]，卷标，如“C：”  
                //    // mo["Size"]，大小，如“10476945408”（10G）  
                    
                //    Console.WriteLine(mo["FileSystem"]);
                //    Console.WriteLine(mo["FreeSpace"]);
                //    Console.WriteLine(mo["Name"]);
                //    Console.WriteLine(mo["Size"]);
                //}
            }
            catch
            {
            }
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
                if (p.MainModule != null)
                {
                    string path = "";
                    path = p.MainModule.FileName.ToString();
                    FileInfo fi = new FileInfo(path);

                    label10.Text = p.ProcessName;

                    label11.Text = p.MainModule.FileVersionInfo.FileDescription;
                    label12.Text = path;
                    label13.Text = Math.Ceiling(fi.Length / 1024.0) + " KB";
                    label14.Text = Math.Ceiling(fi.Length / 1024.0) + " KB";

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
            catch
            {

            }

            //catch(Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, "出现异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
