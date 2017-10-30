using Interface;
using PluginDLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextWebBrowser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
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

            String[] dlls = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");

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
                        //editor.Execute(WebControl1.TextBox1);
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

    }
}
