using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace PluginDLL1
{
    public class Plugin : IEditor
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
            return new WebControl2();
        }
    }
}
