using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TestXml
{
    class MultiLanguage
    {
        public static string DefaultLanguage = "ChineseSimplified";

        public static string GetDefaultLanguage()
        {
            string defaultLanguage = "ChineseSimplified";
            XmlReader reader = new XmlTextReader("Languages/DefaultLanguage.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode root = doc.DocumentElement;
            //选取DefaultLangugae节点   
            XmlNode node = root.SelectSingleNode("DefaultLanguage");
            if (node != null)
            {
                //取出节点中的内容   
                defaultLanguage = node.InnerText;
            }
            reader.Close();
            reader.Dispose();
            return defaultLanguage;
        }

        public static void SetDefaultLanguage(string lang)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("Languages/DefaultLanguage.xml");
            DataTable dt = ds.Tables["Softimite"];
            dt.Rows[0]["DefaultLanguage"] = lang;
            ds.AcceptChanges();
            ds.WriteXml("Languages/DefaultLanguage.xml");
            DefaultLanguage = lang;
        }

        private static Hashtable ReadXMLText(string frmName, string lang)
        {
            try
            {
                Hashtable hashResult = new Hashtable();
                XmlReader reader = null;
                //判断是否存在该语言的配置文件  
                if (!(new System.IO.FileInfo("Languages/" + lang + ".xml")).Exists)
                {
                    return null;
                }
                else
                {
                    reader = new XmlTextReader("Languages/" + lang + ".xml");
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                XmlNode root = doc.DocumentElement;
                //获取XML文件中对应该窗口的内容  
                XmlNodeList nodeList = root.SelectNodes("Form[Name='" + frmName + "']/Controls/Control");
                foreach (XmlNode node in nodeList)
                {
                    try
                    {
                        //修改内容为控件的Text值  
                        XmlNode node1 = node.SelectSingleNode("@name");
                        XmlNode node2 = node.SelectSingleNode("@text");
                        if (node1 != null)
                        {
                            hashResult.Add(node1.InnerText.ToLower(), node2.InnerText);
                        }
                    }
                    catch { }
                }
                reader.Close();
                reader.Dispose();
                return hashResult;
            }
            catch
            {
                return null;
            }
        }

        public static void LoadLanguage(Form form)
        {
            //获取当前默认语言  
            string language = GetDefaultLanguage();
            //根据用户选择的语言获得表的显示文字   
            Hashtable hashText = ReadXMLText(form.Name, language);
            if (hashText == null)
            {
                return;
            }
            //获取当前窗口的所有控件  
            Control.ControlCollection sonControls = form.Controls;
            try
            {
                //遍历所有控件  
                foreach (Control control in sonControls)
                {
                    if (control.GetType() == typeof(ComboBox))      
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(ToolStrip))      
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(MenuStrip))      
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(StatusStrip))     
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(ListBox))        
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(TreeView))      
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    if (hashText.Contains(control.Name.ToLower()))
                    {
                        control.Text = (string)hashText[control.Name.ToLower()];
                    }
                }
                if (hashText.Contains(form.Name.ToLower()))
                {
                    form.Text = (string)hashText[form.Name.ToLower()];
                }
            }
            catch { }
        }

        /// <summary>  
        /// 获取并设置控件中的子控件  
        /// </summary>  
        /// <param name="controls">父控件</param>  
        /// <param name="hashResult">哈希表</param>  
        private static void GetSetSubControls(Control.ControlCollection controls, Hashtable hashText)
        {
            try
            {
                foreach (Control control in controls)
                {
                    if (control.GetType() == typeof(Panel))     //Panel  
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(GroupBox))     //GroupBox  
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(TabControl))       //TabControl  
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    else if (control.GetType() == typeof(TabPage))      //TabPage  
                    {
                        GetSetSubControls(control.Controls, hashText);
                    }
                    if (hashText.Contains(control.Name.ToLower()))
                    {
                        control.Text = (string)hashText[control.Name.ToLower()];
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
