using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Interface
{
    public interface IEditor
    {
        String PluginName
        {
            get;
        }

        UserControl GetControl();
        //void Execute(TextBox txtbox);

    }
}
