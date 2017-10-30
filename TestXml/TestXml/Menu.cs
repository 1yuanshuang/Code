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
    public class Menu
　{
　　　　private string _Path;

　　　　/**//// <summary>
　　　　/// 设置XML配置文件路径
　　　　/// </summary>
　　　　public string Path
　　　　{
　　　　　　get { return _Path; }
　　　　　　set { _Path = value; }
　　　　}

        /**//// <summary>
            　　　　/// 判断文件是否存在
            　　　　/// </summary>
            　　　/// <returns>文件是否存在</returns>
        public bool FileExit()
        {
            if (File.Exists(_Path))
            { return true; }
            else return false;
        }　　
　　　　/**//// <summary>
　　　　/// 加载菜单
　　　　/// </summary>
　　　　/// <param name="menuStrip">母菜单对象</param>
　　　　public void LoadAllMenu(MenuStrip menuStrip)
　　  　{
　　　　　　//读取XML配置文件
　　　　　　XmlTextReader xmlReader = new XmlTextReader(_Path);
　　　　　　while (xmlReader.Read())
　　　　　　{
　　　　　　　　//判断是否循环到MainMenu节点
　　　　　　　　if (!xmlReader.IsEmptyElement && xmlReader.Name == "MainMenu")
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
　　　　　　　　　　　　menuStrip.Items.Add(toolItem);
　　　　　　　　　　}
　　　　　　　　}
　　　　　　　　//判断是否到子菜单节点
　　　　　　　　else if (!xmlReader.IsEmptyElement && xmlReader.Name == "SubMenu")
　　　　　　　　{
　　　　　　　　　　//创建子菜单对象
　　　　　　　　　　ToolStripMenuItem toolSubItem = new ToolStripMenuItem();
　　　　　　　　　　string id = xmlReader.GetAttribute("id");
　　　　　　　　　　toolSubItem.Name = "Item" + id;
　　　　　　　　　　//获取子菜单树

　　　　　　　　　　XmlReader xmlSubReader = xmlReader.ReadSubtree();
　　　　　　　　　　MenuMethod menuMethod = new MenuMethod();
　　　　　　　　　　while (xmlSubReader.Read())
　　　　　　　　　　{
　　　　　　　　　　　　if (!xmlSubReader.IsEmptyElement && xmlSubReader.Name == "Title")
　　　　　　　　　　　　{
　　　　　　　　　　　　　　//添加子菜单的文字
　　　　　　　　　　　　　　toolSubItem.Text = xmlSubReader.ReadElementString();
　　　　　　　　　　　　　　//为菜单添加单击事件
　　　　　　　　　　　　　　toolSubItem.Click += new EventHandler(toolSubItem_Click);
　　　　　　　　　　　　}
　　　　　　　　　　　　//获取母菜单对象
　　　　　　　　　　　　ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)menuStrip.Items["Item" + id.Substring(0, 2)];
　　　　　　　　　　　　//添加子菜单
　　　　　　　　　　　　toolStripMenuItem.DropDownItems.Add(toolSubItem);
　　　　　　　　　　}
　　　　　　　　}
　　　　　　}
　　　　}

　　　　void toolSubItem_Click(object sender, EventArgs e)
　　　　{
　　　　　　//创建菜单调用方法类的实例
　　　　　　MenuMethod menuMethod = new MenuMethod();
　　　　　　Type type = menuMethod.GetType();
　　　　　　//动态获取方法对象
　　　　　　MethodInfo mi = type.GetMethod(((ToolStripMenuItem)sender).Name);
　　　　　　//调用指定方法
　　　　　　mi.Invoke(menuMethod, null);　　　　　　
　　　　}
　　}
}

