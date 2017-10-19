using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PluginDLL2
{
    public class Plugin : IEditor
    {
        public string PluginName
        {
            get
            {
                return "远程系统";
            }
        }

        public UserControl GetControl()
        {
            return new WebControl3();
        }
    }
}
