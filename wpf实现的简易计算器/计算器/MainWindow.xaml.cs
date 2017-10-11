using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace 计算器
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static int temp = 0; //暂存运行过程中的操作数值
        static bool isFirstNumberInput = true; //第一次按下数字按钮
        static string delOpt1, delOpt2; //存放用于重复计算的操作符和操作数
        static bool isLastInputOp = false; //上次输入是不是运算符,用于解决连续输入运算符的情况
        List<string> value = new List<string>();//存放算式

        private void num_Click(object sender, RoutedEventArgs e)
        {
            if (value.Count == 1) //value集合中只存放了一个数,按下数字键就要清零.
            {
                isFirstNumberInput = true;
                value.RemoveAt(0);
            }
            string currentInput = ((Button)sender).Content.ToString();
            if (isFirstNumberInput)
            {
                temp = Convert.ToInt32(currentInput);
                isFirstNumberInput = false;
            }
            else
            {
                temp = temp * 10 + Convert.ToInt32(currentInput);
            }
            valueBox.Text = temp.ToString();
            isLastInputOp = false;
        }

        private void opt_Click(object sender, RoutedEventArgs e)
        {
            string currentInput = ((Button)sender).Content.ToString();
            if (isLastInputOp) //如果上一次输入的也是运算符
            {
                if (value.Count == 1)
                {
                    value.Add(currentInput); //计算完一个等式后的情况
                }
                else
                {
                    value[1] = currentInput; //最后一次输入的运算符有效
                }
                return;
            }
            if (value.Count == 1) //这是一个算式用=号算出来之后, 只剩一个值
            {
                value.Add(currentInput);
                temp = 0;
            }
            else
            {
                value.Add(temp.ToString());
                value.Add(currentInput);
                temp = 0; //temp清零, 为下一次数据输入做准备
                if (value.Count == 4) //3+3+ 这样的输入组合,这时候需要先计算前面的算式 
                {
                    temp = Calculate();
                    value[0] = temp.ToString();
                    value[1] = value[3];
                    value.RemoveAt(2);
                    value.RemoveAt(2);
                    valueBox.Text = temp.ToString();
                    temp = 0;
                }
                isLastInputOp = true;
            }
        }

        private int Calculate()
        {
            int result = 0;
            string opt = value[1];
            int op1 = Convert.ToInt32(value[0]);
            int op2 = Convert.ToInt32(value[2]);
            switch (opt)
            {
                case "+": result = op1 + op2; break;
                case "-": result = op1 - op2; break;
                case "*": result = op1 * op2; break;
                case "/": result = op1 / op2; break;
            }
            return result;
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            value.Clear();
            temp = 0;
            isFirstNumberInput = true;
            valueBox.Text = temp.ToString();
            delOpt1 = null;
            delOpt2 = null;
            isLastInputOp = false;
        }

        private void Equ_Click(object sender, RoutedEventArgs e)
        {
            //等于号有效的情况有三种, 一种是value.Count为0,第二种值为1时,第三种为2时.
            if (value.Count == 0)
            {
                value.Add(valueBox.Text);
                temp = Convert.ToInt32(value[0]);
                valueBox.Text = temp.ToString();
                return; //没有return的话会执行下面的判断
            }
            if (value.Count == 1)
            {
                value.Add(delOpt1);
                value.Add(delOpt2);
                EqualOperation();
            }
            if (value.Count == 2) //3+3=这种输入组合
            {
                value.Add(temp.ToString());
                EqualOperation();
            }
        }

        private void EqualOperation() //用于按下=按钮后的计算函数
        {
            temp = Calculate();
            value[0] = temp.ToString();
            delOpt1 = value[1]; //存放将要删除的操作符
            delOpt2 = value[2]; //存放将要删除的操作数
            value.RemoveAt(1);
            value.RemoveAt(1);
            valueBox.Text = temp.ToString();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (valueBox.Text.Length > 0)
            {
                valueBox.Text = valueBox.Text.Substring(0, valueBox.Text.Length - 1);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
