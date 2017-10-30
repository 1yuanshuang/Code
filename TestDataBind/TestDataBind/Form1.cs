using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace TestDataBind
{
    public partial class Form1 : Form
    {
      //public event PropertyChangedEventHandler PropertyChanged;
        public Form1()
        {
            InitializeComponent();
        }

        //public bool TheValue
        //{
        //    get { return s; }
        //    set
        //    {
        //        if (s != value)
        //        {
        //            s = value;
        //            FirePropertyChanged("TheValue");
        //        }
        //    }
        //}

        //private void FirePropertyChanged(string propertyName)
        //{
        //    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //private void textBox7_TextChanged(object sender, EventArgs e)
        //{
        //    if (!IsInteger(textBox7.Text))
        //    {
        //        TheValue = false;
        //    }
        //    else
        //    {
        //        TheValue = true;
        //    }
        //}

        //public int pointNum(string str)
        //{
        //    int count = 0;
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        if (str[i] == '.')
        //        {
        //            count++;

        //        }
        //    }
        //    return count;
        //}

        //public bool IsInteger(string str)
        //{
        //    bool result = true;
        //    if (str == "")
        //    {
        //        result = false;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < str.Length; i++)
        //        {
        //            if (str[i] >= '0' && str[i] <= '9' || (str[i] == '.' && (pointNum(str) == 1)))
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                result = false;
        //                break;
        //            }
        //        }
        //    }
        //    return result;
        //}

        //public string IsDigit(string str)
        //{
        //    string result = null;
        //    if (IsInteger(str))
        //    {
        //        result = str;
        //    }
        //    return result;
        //}

        MyDataSource mydatasource = new MyDataSource();  

        public BindingList<BlogNew> blogNewsRegardUI { get; set; }
        public int Num { get; set; }

        MyData1 data = new MyData1();

        private void button4_Click(object sender, EventArgs e)
        {
            data.Text +=  "dguiw" ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyData myData = new MyData();
            textBox1.DataBindings.Add("Text", trackBar1, "Value", false, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", myData, "TheValue", false, DataSourceUpdateMode.OnPropertyChanged);
            textBox3.DataBindings.Add("Text", myData, "TheValue", false, DataSourceUpdateMode.Never);

            label1.DataBindings.Add("Text", textBox6, "Text");         

            blogNewsRegardUI = new BindingList<BlogNew>();
            blogNewsRegardUI.Add(new BlogNew { BlogID = 1, BlogTitle = "yuan" });
            blogNewsRegardUI.Add(new BlogNew { BlogID = 2, BlogTitle = "shuang" });
            blogNewsRegardUI.Add(new BlogNew { BlogID = 3, BlogTitle = "C#" });
            dataGridView1.DataBindings.Add("DataSource", this, "blogNewsRegardUI", false, DataSourceUpdateMode.OnPropertyChanged);

            Num = 5;
            textBox8.DataBindings.Add("Text", this, "Num", false, DataSourceUpdateMode.OnPropertyChanged);

            textBox7.DataBindings.Add("Text", data, "Text", false, DataSourceUpdateMode.OnPropertyChanged);
            button1.DataBindings.Add("Enabled", data, "Enabled", false, DataSourceUpdateMode.OnPropertyChanged);
        }


        public class MyData : INotifyPropertyChanged
        {
            private string _theValue = string.Empty;

            public string TheValue
            {
                get { return _theValue; }
                set
                {
                    if (string.IsNullOrEmpty(value) && value == _theValue)
                        return;

                    _theValue = value;
                    NotifyPropertyChanged(() => TheValue);
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public void NotifyPropertyChanged<T>(Expression<Func<T>> property)
            {
                if (PropertyChanged == null)
                    return;

                var memberExpression = property.Body as MemberExpression;
                if (memberExpression == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(mydatasource.Myvalue);
           
        }

        public class MyDataSource
        {
            public string Myvalue { get; set; }
        }

        public class BlogNew
        {
            public int BlogID { get; set; }
            public string BlogTitle { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dataRegardUI = dataGridView1.DataSource as BindingList<BlogNew>;
            
            List<BlogNew> data = new List<BlogNew>();
            for (int i = 4; i < 9; i++)
            {
                data.Add(new BlogNew { BlogID = i, BlogTitle = "yuan"+i.ToString() });
            }
            //for (int j = 0; j < data.Count; j++)
            //{
            //    if (!dataRegardUI.Contains(data[j]))
            //    {
            //        dataRegardUI.Add(data[j]);
            //    }
            //    else
            //    {
            //        MessageBox.Show("表中已经包含此数据");
            //    }
            //}
            foreach (var item in data)
            {
                if (!dataRegardUI.Contains(item))
                {
                    dataRegardUI.Add(item);
                }
                else
                {
                    MessageBox.Show("表格中已存在数据");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Num.ToString());
        }
    }
}
