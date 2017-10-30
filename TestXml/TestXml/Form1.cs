using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Path = @"C:\Users\y0019.SYNTHFLEX\Documents\Visual Studio 2017\Projects\TestXml\TestXml\Menu.xml";
           
            if (menu.FileExit())
            {
                menu.LoadAllMenu(MainMenu);
            }
            else
            {
                MessageBox.Show("XML文件加载失败！");
            }

            Tool tool = new Tool();
            tool.Path = @"C:\Users\y0019.SYNTHFLEX\Documents\Visual Studio 2017\Projects\TestXml\TestXml\Tool.xml";

            if (tool.FileExit())
            {
                tool.LoadAllTool(MainTool);
            }
            else
            {
                MessageBox.Show("XML文件加载失败！");
            }

            Status status = new Status();
            status.Path = @"C:\Users\y0019.SYNTHFLEX\Documents\Visual Studio 2017\Projects\TestXml\TestXml\Status.xml";

            if (tool.FileExit())
            {
                status.LoadAllStatus(MainStatus);
            }
            else
            {
                MessageBox.Show("XML文件加载失败！");
            }

            //string language = MultiLanguage.GetDefaultLanguage();
            //if (language == "ChineseSimplified")
            //{
            //    languageTxt.Text = "简体中文(默认)";
            //}

            //else if (language == "English")
            //{
            //    languageTxt.Text = "English";
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void languageTxt_SelectedIndexChanged(object sender, EventArgs e)
        //{           
        //        languageTxt.Enabled = false;
        //        if (languageTxt.Text == "简体中文(默认)")
        //        {
        //            //修改默认语言  
        //            MultiLanguage.SetDefaultLanguage("ChineseSimplified");
        //            //对所有打开的窗口重新加载语言  
        //            foreach (Form form in Application.OpenForms)
        //            {
        //                MultiLanguage.LoadLanguage(form);
        //            }
        //        }           
        //        else if (languageTxt.Text == "English")
        //        {
        //            //修改默认语言  
        //            MultiLanguage.SetDefaultLanguage("English");
        //            //对所有打开的窗口重新加载语言  
        //            foreach (Form form in Application.OpenForms)
        //            {
        //                MultiLanguage.LoadLanguage(form);
        //            }
        //        }
        //        languageTxt.Enabled = true;
        //    }
        }
}
