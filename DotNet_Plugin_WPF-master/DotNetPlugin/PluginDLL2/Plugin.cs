using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PluginDLL2
{
    public class Plugin:IEditor
    {
        public string PluginName
        {
            get
            {
                return "数据和邻居";
            }
        }

        public UserControl GetControl()
        {
            return new CalControl();
        }

        //public void Execute(TextBox txtbox)
        //{
        //    txtbox.Text = "保存  刷新";
        //}
    }
}
