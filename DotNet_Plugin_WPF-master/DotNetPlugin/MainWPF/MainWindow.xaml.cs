using System;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using System.Xml;
using System.IO;
using System.Web.UI.WebControls;
using Interface;
using System.Collections.Generic;

namespace MainWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadPlugins();
        }

        private void LoadPlugins()
        {
           
            String[] dlls = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "plugins", "*.dll");

            foreach (string dllPath in dlls)
            {
                Assembly assembly = Assembly.LoadFile(dllPath);
                Type[] types = assembly.GetExportedTypes();
                Type typeIEditor = typeof(IEditor);

                for (int i = 0; i < types.Length; i++)
                {
                    if (typeIEditor.IsAssignableFrom(types[i]) && !types[i].IsAbstract)
                    {
                        IEditor editor = (IEditor)Activator.CreateInstance(types[i]);
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = editor.PluginName;
                        MySystem.Items.Add(subitem);
                        subitem.Selected += new RoutedEventHandler(treeItem_Click);
                        subitem.Tag = editor;
                    }
                }
            }
        }

        private void treeItem_Click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            TreeViewItem item = sender as TreeViewItem;
            if (item != null)
            {
                if (item.Tag != null)
                {
                    IEditor editor = item.Tag as IEditor;
                    if (editor != null)
                    {
                        // 运行该插件
                       // editor.Execute(TextBox1);
                        UserControl wnd = editor.GetControl();
                        WrapPanel panel = new WrapPanel();
                        panel.Children.Add(wnd);
                        panel.Width = wnd.Width;
                        panel.Height = wnd.Height;

                        stackPanel1.Height += panel.Height;
                        stackPanel1.Width = (stackPanel1.Width > panel.Width ? stackPanel1.Width : panel.Width);

                        stackPanel1.Children.Add(panel);
                    }
                }
            }

        }

        private void TreeView1_Selected(object sender, RoutedEventArgs e)
        {
            string title = TreeView1.SelectedItem.ToString().Substring(40, 5);
            title += "-Measurement & Automation Explorer";
            this.Title = title;
        }
    }
}






























//        System.Windows.Controls.UserControl wnd = obj.GetControl();

//        WrapPanel panel = new WrapPanel();
//        panel.Children.Add(wnd);
//        panel.Width = wnd.Width;
//        panel.Height = wnd.Height;

//        stackPanel1.Height += panel.Height;
//        stackPanel1.Width = (stackPanel1.Width > panel.Width ? stackPanel1.Width : panel.Width);

//        stackPanel1.Children.Add(panel);
//    }
//    String[] dlls = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
//}



//    private void TreeView1_Selected1(object sender, RoutedEventArgs e)
//    {
//        //string title = TreeView1.SelectedItem.ToString().Substring(40, 5);
//        //title += "-Measurement & Automation Explorer";
//        //this.Title = title;

//        stackPanel1.Children.Clear();
//        XmlDocument doc = new XmlDocument();
//        doc.Load(@"C:\Users\y0019.SYNTHFLEX\Desktop\DotNet_Plugin_WPF-master1\DotNet_Plugin_WPF-master\DotNetPlugin\MainWPF\XMLFile1.xml");
//        //获取根节点
//        XmlNode rootNode = doc.SelectSingleNode("Data");
//        //获取根节点的所有子节点，以列表形式存
//        XmlNodeList subNode = rootNode.ChildNodes;

//        foreach (XmlNode xNode in subNode)
//        {
//            XmlElement x = (XmlElement)xNode;
//            if (x.GetAttribute("Name") == "我的系统")
//            {

//                XmlNodeList sub = x.ChildNodes;
//                string dll = sub[1].InnerText;
//                Assembly assembly = Assembly.LoadFile(dll);
//                string treeViewName = sub[0].ChildNodes[0].InnerText;

//                string sp = sub[2].InnerText;
//                Type type = assembly.GetType(sp);

//                dynamic obj = Activator.CreateInstance(type);

//                //TreeViewItem[] tree = new TreeViewItem[4];
//                //int i = 0;
//                //tree[i] = new TreeViewItem();
//                //TreeView1.Items.Add(tree[i]);


//                UserControl wnd = obj.GetControl();
//                WrapPanel panel = new WrapPanel();
//                panel.Children.Add(wnd);
//                panel.Width = wnd.Width;
//                panel.Height = wnd.Height;

//                stackPanel1.Height += panel.Height;
//                stackPanel1.Width = (stackPanel1.Width > panel.Width ? stackPanel1.Width : panel.Width);
//                stackPanel1.Children.Add(panel);

//            }
//        }
//    }

//    private void TreeView1_Selected2(object sender, RoutedEventArgs e)
//    {
//        string title = TreeView1.SelectedItem.ToString().Substring(40, 5);
//        title += "-Measurement & Automation Explorer";
//        this.Title = title;

//        stackPanel1.Children.Clear();
//        XmlDocument doc = new XmlDocument();
//        doc.Load(@"C:\Users\y0019.SYNTHFLEX\Desktop\DotNet_Plugin_WPF-master1\DotNet_Plugin_WPF-master\DotNetPlugin\MainWPF\XMLFile1.xml");
//        //获取根节点
//        XmlNode rootNode = doc.SelectSingleNode("Data");
//        //获取根节点的所有子节点，以列表形式存
//        XmlNodeList subNode = rootNode.ChildNodes;

//        foreach (XmlNode xNode in subNode)
//        {
//            XmlElement x = (XmlElement)xNode;
//            if (x.GetAttribute("Name") == "数据和邻居")
//            {
//                XmlNodeList sub1 = x.ChildNodes;
//                string dll1 = sub1[2].InnerText;
//                Assembly assembly1 = Assembly.LoadFile(dll1);

//                string sp1 = sub1[3].InnerText;
//                Type type1 = assembly1.GetType(sp1);
//                dynamic obj1 = Activator.CreateInstance(type1);

//                UserControl wnd1 = obj1.GetControl();
//                WrapPanel panel1 = new WrapPanel();
//                panel1.Children.Add(wnd1);
//                panel1.Width = wnd1.Width;
//                panel1.Height = wnd1.Height;

//                stackPanel1.Height += panel1.Height;
//                stackPanel1.Width = (stackPanel1.Width > panel1.Width ? stackPanel1.Width : panel1.Width);
//                stackPanel1.Children.Add(panel1);
//            }
//        }
//    }