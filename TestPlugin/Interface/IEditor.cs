using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Interface
{
    public interface IEditor
    {
        string PluginName
        {
            get;
        }

        void Execute(TextBox txtbox);
        void Execute1(TextBox text);
    }
}
