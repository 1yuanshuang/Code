using System;
using System.Collections.Generic;
using System.Linq;
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

namespace PluginDLL3
{
    /// <summary>
    /// WebControl.xaml 的交互逻辑
    /// </summary>
    public partial class WebControl : UserControl
    {
        public WebControl()
        {
            InitializeComponent();
            string szTmp = "http://192.168.0.11/sample2.htm";
            Uri uri = new Uri(szTmp);
            Web.Navigate(uri);
        }
    }
}
