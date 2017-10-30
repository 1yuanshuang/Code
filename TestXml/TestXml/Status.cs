using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TestXml
{
    class Status
    {
        private string _Path;

        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }
        public bool FileExit()
        {
            if (File.Exists(_Path))
            { return true; }
            else return false;
        }

        public void LoadAllStatus(StatusStrip statusStrip)
        {
            //读取XML配置文件
            XmlTextReader xmlReader = new XmlTextReader(_Path);
            while (xmlReader.Read())
            {
                //判断是否循环到MainStatus节点
                if (!xmlReader.IsEmptyElement && xmlReader.Name == "MainStatus")
                {
                    //创建一级菜单项
                    ToolStripMenuItem toolItem = new ToolStripMenuItem();
                    //获取属性ID值
                    string id = xmlReader.GetAttribute("id");
                    toolItem.Name = "Item" + id;
                    //获取属性TITLE值
                    string title = xmlReader.GetAttribute("title");
                    toolItem.Text = title;
                    if (title != null && title.Length > 1)
                    {
                        //动态添加一项菜单
                        statusStrip.Items.Add(toolItem);
                    }
                }
                ////判断是否到子菜单节点
                else if (!xmlReader.IsEmptyElement && xmlReader.Name == "SubTool")
                {
                    //创建子菜单对象
                    ToolStripMenuItem statusSubItem = new ToolStripMenuItem();
                    string id = xmlReader.GetAttribute("id");
                    statusSubItem.Name = "Item" + id;
                    //获取子菜单树
                    XmlReader xmlSubReader = xmlReader.ReadSubtree();
                    StatusMethod statusMethod = new StatusMethod();
                    while (xmlSubReader.Read())
                    {
                        if (!xmlSubReader.IsEmptyElement && xmlSubReader.Name == "Title")
                        {
                            //添加子菜单的文字
                            statusSubItem.Text = xmlSubReader.ReadElementString();
                            //为菜单添加单击事件
                            statusSubItem.Click += new EventHandler(toolSubItem_Click);
                        }
                        //获取母菜单对象
                        ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)statusStrip.Items["Item" + id.Substring(0, 2)];
                        //添加子菜单
                        toolStripMenuItem.DropDownItems.Add(statusSubItem);
                    }
                }
            }
        }

        void toolSubItem_Click(object sender, EventArgs e)
        {
            //创建菜单调用方法类的实例
            StatusMethod statusMethod = new StatusMethod();
            Type type = statusMethod.GetType();
            //动态获取方法对象
            MethodInfo mi = type.GetMethod(((ToolStripMenuItem)sender).Name);
            //调用指定方法
            mi.Invoke(statusMethod, null);

        }
    }
}
