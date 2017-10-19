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

namespace PluginDLL
{
    /// <summary>
    /// WebControl1.xaml 的交互逻辑
    /// </summary>
    public partial class WebControl1 : UserControl
    {
        public WebControl1()
        {
            InitializeComponent();
            //string szTmp = "http://www.baidu.com";
            // string szTmp = "https://hao.360.cn/?h_lnk";
            string szTmp = "https://www.btime.com/?from=gjl";
            Uri uri = new Uri(szTmp);
            Web.Navigate(uri);
        }
    }
}
