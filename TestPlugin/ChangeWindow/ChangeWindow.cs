using Interface;
using System.Windows.Controls;

namespace ChangeWindow
{
    public class ChangeWindow : IEditor
    {
        public string PluginName
        {
            get
            {
                return "改变标题和窗体颜色";
            }
        }

        public void Execute(TextBox txtbox)
        {       
            txtbox.Text = "@#%&$&$&$&$&$^*(*(*(*(*(*(";     
        }

        public void Execute1(TextBox text)
        {
           text.Text= "@#%&$&$&$&$&$^*(*(*(*(*(*(";
        }

    }

}
