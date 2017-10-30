using Interface;
using System.Windows.Controls;

namespace ChangeTitle1
{
    public class ChangeTitle1:IEditor
    {
        public string PluginName
        {
            get
            {
                return "改变标题和窗体字体";
            }
        }

        public void Execute(TextBox txtbox)
        {
            txtbox.Text = "2222222222222222";
        }

        public void Execute1(TextBox text)
        {
            text.Text= "@@@@@@@@@@@@@@@@@@@@@@@@@@";
        }
    }
}
