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
    /// CalControl.xaml 的交互逻辑
    /// </summary>
    public partial class CalControl1 : UserControl
    {
        public CalControl1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var total = Int32.Parse(textBox1.Text) + Int32.Parse(textBox2.Text);
                label3.Content = "Sum is : " + total;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
