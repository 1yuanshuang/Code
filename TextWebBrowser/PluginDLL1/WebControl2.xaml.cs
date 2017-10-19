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

namespace PluginDLL1
{
    /// <summary>
    /// WebControl2.xaml 的交互逻辑
    /// </summary>
    public partial class WebControl2 : UserControl
    {
        public WebControl2()
        {
            InitializeComponent();
            string szTmp = "https://www.baidu.com";
            Uri uri = new Uri(szTmp);
            Web.Navigate(uri);
        }
    }
}
