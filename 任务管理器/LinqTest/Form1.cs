using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Management;

namespace LinqTest
{
    public partial class Form1 : Form
    {
       // public ListViewItem lv = new ListViewItem();
        private int length = 100;
        private int index = 0;
        public int pid=0;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            Process[] pro = Process.GetProcesses();
            for (int i = 0; i < pro.Length; i++)
            {
                string userName = GetProcessUserName(pro[i].Id);
                PerformanceCounter curCpu = new PerformanceCounter("Process", "% Processor Time", pro[i].ProcessName);
                PerformanceCounter curMem = new PerformanceCounter("Process", "Working Set", pro[i].ProcessName);

                ListViewItem lvi = new ListViewItem();
                lvi.Text = pro[i].ProcessName.ToString();
                lvi.SubItems.Add(pro[i].Id.ToString());
                lvi.SubItems.Add(userName);
                string cpuInfo = (curCpu.NextValue() / Environment.ProcessorCount).ToString();
                lvi.SubItems.Add(cpuInfo);

                string MemInfo = (curMem.NextValue() / 1024).ToString();
                lvi.SubItems.Add(MemInfo + "K");

                lvi.SubItems.Add(pro[i].WorkingSet64.ToString());

               // lvi.SubItems.Add(pro[i].MainModule.FileVersionInfo.FileDescription);

                pro[i].Refresh();
                this.listView1.Items.Add(lvi);

                SystemInfo s = new SystemInfo();
                string phy = s.PhysicalMemory.ToString();
                label13.Text = phy;

                string mea = s.MemoryAvailable.ToString();
                label15.Text = mea;

                string no = pro[i].NonpagedSystemMemorySize.ToString();
                label23.Text = no;

                string fenye = pro[i].PagedMemorySize.ToString();
                label22.Text = fenye;

                string xiancheng = pro[i].Threads.Count.ToString();
                label18.Text = xiancheng;

                DateTime dt = DateTime.Now.AddMilliseconds(0 - Environment.TickCount);
                label20.Text = dt.ToString();

                string tijiao = (pro[i].PagedMemorySize64 / 1024).ToString();
                label21.Text = tijiao;

            }
            this.listView1.EndUpdate();

            Process[] processes = Process.GetProcessesByName("taskmgr");
            foreach (Process instance in processes)
            {
                string jubing = instance.HandleCount.ToString();
                label17.Text = jubing;
            }
        }



        private string GetProcessUserName(int pID)
        {
            string text1 = null;
            SelectQuery query1 = new SelectQuery("Select * from Win32_Process" + pID);
            ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(query1);
            try
            {
                foreach (ManagementObject disk in searcher1.Get())
                {
                    ManagementBaseObject inPar = null;
                    ManagementBaseObject outPar = null;
                    inPar = disk.GetMethodParameters("GetOwner");
                    outPar = disk.InvokeMethod("GetOwner", inPar, null);
                    text1 = outPar["User"].ToString();
                    break;
                }
            }
            catch
            {
                string name = SystemInformation.UserName.ToString();
                text1 = name;
            }
            return text1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                try
                {
                    string proName = listView1.SelectedItems[0].Text;
                    Process[] p = Process.GetProcessesByName(proName);
                    p[0].Kill();
                    p[0].Close();

                    MessageBox.Show("进程关闭成功！");
                    // GetProcess();
                }
                catch
                {
                    MessageBox.Show("无法关闭此进程！");
                }
            }
            //if (listView1.SelectedItems.Count > 0)
            //{

            //    int pid = Int32.Parse(listView1.SelectedItems[0].SubItems[1].Text);
            //    Process p = Process.GetProcessById(pid);
            //    if(p==null)
            //    {
            //        return;
            //    }

            //    if(!p.CloseMainWindow())
            //    {
            //        p.Kill();

            //    }
            //   // p.WaitForExit();
            //    p.Close();

            //}
            //else
            //{
            //    MessageBox.Show("请选择要终止的进程!");
            //}

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开文件";
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
            DialogResult oK = openFileDialog.ShowDialog();

            if (oK == DialogResult.OK)
            {
                try
                {
                    string file = openFileDialog.FileName;
                    StreamReader read = File.OpenText(file);    //创建从字符串进行读取的StreamReader对象  
                    string str = read.ReadToEnd();
                    MessageBox.Show(str);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            SystemInfo s = new SystemInfo();
            waveChart2.Draw(s.CpuLoad);

            if (index == (length - 1))
            {
                index = 0;
            }
            index++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            SystemInfo s = new SystemInfo();
            waveChart3.Draw(s.PhysicalMemory);

            if (index == (length - 1))
            {
                index = 0;
            }
            index++;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            SystemInfo s = new SystemInfo();
            waveChart4.Draw(s.MemoryAvailable);

            if (index == (length - 1))
            {
                index = 0;
            }
            index++;
        }


        private void 结束进程EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                try
                {
                    string proName = listView1.SelectedItems[0].Text;
                    Process[] p = Process.GetProcessesByName(proName);
                    p[0].Kill();
                    p[0].Close();
                    MessageBox.Show("进程关闭成功！");
                    //GetProcess();
                }
                catch
                {
                    MessageBox.Show("无法关闭此进程！");
                }
            }
            else
            {
                MessageBox.Show("请选择要终止的进程!");
            }


            //string proName = listView1.SelectedItems[0].Text;
            //    foreach (var pTempProcess in Process.GetProcesses())
            //    {
            //        try
            //        {
            //            string sProcessName = pTempProcess.ProcessName; //获取进程名称
            //            if (sProcessName == proName)
            //            {
            //                string sProcessID = pTempProcess.Id.ToString(); //获取进程ID
            //                Process pProcessTemp = Process.GetProcessById(Convert.ToInt32(sProcessID));

            //                pProcessTemp.Kill(); //杀死进程
            //                pProcessTemp.Close();
            //            }
            //        }
            //        catch
            //        {

            //        }
            //    }

        }



        private void 打开文件位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {            
                Process ps = Process.GetProcessById(Int32.Parse(listView1.SelectedItems[0].SubItems[1].Text));      

                string path = "";
                path = ps.MainModule.FileName.ToString();            
                Process.Start("explorer.exe", "/select," + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取进程路径出错，Error：" + ex.Message, "失败信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            ////定义一个ProcessStartInfo实例
            //ProcessStartInfo info = new ProcessStartInfo();
            ////设置启动进程的初始目录
            //info.WorkingDirectory = Application.StartupPath;
            ////设置启动进程的应用程序或文档名
            //info.FileName = @"test.txt";
            ////设置启动进程的参数
            //info.Arguments = "";
            ////启动由包含进程启动信息的进程资源
            //try
            //{
            //    Process.Start(info);
            //}
            //catch (System.ComponentModel.Win32Exception we)
            //{
            //    MessageBox.Show(this, we.Message);
            //    return;
            //}

        }

        private void 属性RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 dlg = new Form1();
            if(listView1.SelectedItems.Count!=0)
            {
                dlg.Text = "进程" + listView1.SelectedItems[0].Text + "属性";
                dlg.pid = Int32.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                
                dlg.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择一个进程");
            }
        }
    }
}
