using Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestPlugin
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
            TreeViewItem item = sender as TreeViewItem;
            if (item != null)
            {
                if (item.Tag != null)
                {
                    IEditor editor = item.Tag as IEditor;
                    if (editor != null)
                    {
                        // 运行该插件
                        editor.Execute(TextBox1);
                        editor.Execute1(TextBox2);
                    }
                }
            }    
        }

        private void TreeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            string title = TreeView1.SelectedItem.ToString().Substring(40, 5);
            title += "-Measurement & Automation Explorer";
            this.Title = title;
        }
    }
}
