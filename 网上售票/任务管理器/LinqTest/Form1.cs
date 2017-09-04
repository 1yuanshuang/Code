using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Management;
using System.Threading;
using System.Globalization;
using System.ServiceProcess;

namespace LinqTest
{
    public partial class Form1 : Form
    {
        private int length = 100;
        private int index = 0;
        public int pid=0;

        //public string GetName()
        //{
        //    try
        //    {
        //        ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");
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

        //public string GetTotalPhysicalMemory()
        //{
        //    try
        //    {
        //        ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");
        //        string name = "";
        //        foreach (ManagementObject mo in searcher.Get())
        //        {
        //            name = mo["TotalPhysicalMemory"].ToString().Trim();
        //            break;
        //        }
        //        return name;
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}

        public void ListProcess()
        {
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

                //  lvi.SubItems.Add(pro[i].WorkingSet64.ToString());
                lvi.SubItems.Add(pro[i].WorkingSet64.ToString());

                lvi.SubItems.Add(pro[i].Responding.ToString());

                pro[i].Refresh();
                this.listView1.Items.Add(lvi);

                SystemInfo s = new SystemInfo();
                string phy = s.PhysicalMemory.ToString();
                label13.Text = phy;
                //label13.Text = GetTotalPhysicalMemory();


                string mea = s.MemoryAvailable.ToString();
                label15.Text = mea;

                //string no = pro[i].NonpagedSystemMemorySize64.ToString();
                //label23.Text = no;

                //string fenye = pro[i].PagedMemorySize64.ToString();
                //label22.Text = fenye;

                //string xiancheng = pro[i].Threads.Count.ToString();
                //label18.Text = xiancheng;

                //string jincheng = listView1.Items.Count.ToString();
                //label19.Text = jincheng;

                DateTime dt = DateTime.Now.AddMilliseconds(0 - Environment.TickCount);
                label20.Text = dt.ToString();

                //string tijiao = (pro[i].PagedMemorySize64 / 1024).ToString();
                //label21.Text = tijiao;

            }
            this.listView1.EndUpdate();

            Process[] processes = Process.GetProcessesByName("taskmgr");
            foreach (Process instance in processes)
            {
                string jubing = instance.HandleCount.ToString();
                label17.Text = jubing;
            }
        }

        public void ListService()
        {
            this.listView2.BeginUpdate();
            ServiceController[] Services = ServiceController.GetServices();

            foreach (ServiceController svc in Services)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = svc.ServiceName;

                //if (svc.Status == ServiceControllerStatus.Stopped)
                //{
                //    lv.SubItems.Add("");
                //}
                //else if (svc.Status == ServiceControllerStatus.Running)
                //{
                //    Process[] processes = Process.GetProcessesByName(svc.ServiceName);
                //    foreach (Process instance in processes)
                //    {                                             
                //         lv.SubItems.Add(instance.Id.ToString());
                //    }
                //}
                lv.SubItems.Add("");
                lv.SubItems.Add(svc.ServiceType.ToString());
                lv.SubItems.Add(svc.Status.ToString());

                listView2.Items.Add(lv);
            }
            listView2.EndUpdate();
        }


        public Form1()
        {
            InitializeComponent();
            ListProcess();
            ListService();
            Control.CheckForIllegalCrossThreadCalls = false;
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
                    Process ps = Process.GetProcessById(Int32.Parse(listView1.SelectedItems[0].SubItems[1].Text));
                    ps.Kill();
                    ps.Close();
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                    MessageBox.Show("进程关闭成功！");
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
            Thread t = new Thread(new ThreadStart(DeService));
            t.Start();

        }

        private void DeService()
        {
            while (true)
            {
                listView1.Refresh();
                Thread.Sleep(1000);
            }
        }

        //private delegate void TimerCallback();
        //private void UpdateUI()
        //{
        //    while (true)
        //    {
        //        listView1.Refresh();
        //        Thread.Sleep(1000);
        //    }
        //}

        //private void DeService()
        //{
        //    if (listView1.InvokeRequired == true)
        //    {
        //        TimerCallback tcb = new TimerCallback(UpdateUI);
        //        this.Invoke(tcb);
        //    }
        //    else
        //    {
        //        listView1.Refresh();
        //    }
        //}


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
                    Process ps = Process.GetProcessById(Int32.Parse(listView1.SelectedItems[0].SubItems[1].Text));
                    ps.Kill();
                    ps.Close();
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                    MessageBox.Show("进程关闭成功！");
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
            catch //Exception ex)
            {
               // MessageBox.Show("获取进程路径出错，Error：" + ex.Message, "失败信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void 属性RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();
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

        public static void FindAndKillProcess(int id)
        {
            killProcess(id);
        }

        private static bool killProcess(int pid)
        {
            Process[] procs = Process.GetProcesses();
            for (int i = 0; i < procs.Length; i++)
            {
                if (getParentProcess(procs[i].Id) == pid)
                    killProcess(procs[i].Id);
            }

            try
            {
                Process myProc = Process.GetProcessById(pid);
                myProc.Kill();
            }

            catch (ArgumentException)
            {
                ;
            }
            return true;
        }

        private static int getParentProcess(int Id)
        {
            int parentPid = 0;
            using (ManagementObject mo = new ManagementObject("win32_process.handle='" + Id.ToString(CultureInfo.InvariantCulture) + "'"))
            {
                try
                {
                    mo.Get();
                }
                catch (ManagementException)
                {
                    return -1;
                }
                parentPid = Convert.ToInt32(mo["ParentProcessId"], CultureInfo.InvariantCulture);
            }
            return parentPid;
        }


        private void 结束进程树TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindAndKillProcess(Int32.Parse(listView1.SelectedItems[0].SubItems[1].Text));
            //foreach (ListViewItem item in this.listView1.Items)
            //{
            //    for (int i = 0; i < item.SubItems.Count; i++)
            //    {
            //           if(item.SubItems[i].Text==listView1.SelectedItems[0].Text)
          
            //                listView1.Items.Remove(listView1.SelectedItems[0]);
            //        MessageBox.Show(item.SubItems[i].Text);
            //    }
            //}
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void 转到服务SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process ps = Process.GetProcessById(Int32.Parse(listView1.SelectedItems[0].SubItems[1].Text));
     
            if(ps.Responding.Equals("True"))
            {
                tabControl1.SelectedIndex = 2;
               // ListService(Int32.Parse(ps.Id.ToString()));

            }
            else
            {
                tabControl1.SelectedIndex = 2;

            }
   
        }
    }
}
