using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static DevManager.HardwareClass;

namespace DevManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Dictionary<Guid, HardwareInfo> ParentDic = new Dictionary<Guid, HardwareInfo>();
            IList<HardwareInfo> xsList = GetHardwareTable(out ParentDic);
            TreeNode[] treeNodes = new TreeNode[ParentDic.Count];
            uint i = 0;
            
            treeView1.Nodes.Add(GetUserName().ToString().Substring(10, 5) + "-PC");
     
            foreach (KeyValuePair<Guid, HardwareInfo> kvp in ParentDic)
            {
                treeNodes[i] = new TreeNode();
                treeNodes[i].Name = kvp.Value.ClassGuid.ToString();
                treeNodes[i].Text = kvp.Value.DeviceName;

                foreach (var xInfo in xsList)
                {
                    if (treeNodes[i].Name == xInfo.ClassGuid.ToString())
                    {
                        //子节点添加到对应的父节点下面
                        TreeNode treeNode = new TreeNode();
                        treeNode.Name = xInfo.ClassGuid.ToString();
                        treeNode.Text = xInfo.DeviceName;
                        treeNodes[i].Nodes.Add(treeNode);
                    }

                }
                treeView1.Nodes.Add(treeNodes[i]);       //将父节点添加到treeView中
                i++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //IList<HardwareClass.HardwareInfo> _HardwareInfo = HardwareClass.GetHardwareTable();
            //treeView1.Nodes.Add(GetUserName().ToString().Substring(10, 5) + "-PC");
            // string temp = _HardwareInfo[0].DeviceName.ToString();


            //for (; i < _HardwareInfo.Count(); i++)
            //{
            //    for (j = _HardwareInfo.Count - 1; j > i; j--)
            //    {
            //        if (_HardwareInfo[i].DeviceName.ToString() == _HardwareInfo[j].DeviceName.ToString())
            //        {
            //            _HardwareInfo.RemoveAt(j);
            //        }
            //        else
            //        {
            //            treeView1.Nodes.Add(_HardwareInfo[i].DeviceName.ToString());
            //        }
            //    }

            //for (int j = 0; j < _HardwareInfo.Count; j++)
            //{
            //    treeView1.Nodes.Add(_HardwareInfo[j].DeviceName.ToString());
            //}
        }
    }
}
