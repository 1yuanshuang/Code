//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace WindowsFormsApp6
//{
//    static class Program
//    {
//        /// <summary>
//        /// 应用程序的主入口点。
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new Form1());
//        }
//    }
//}

using System;
using System.Threading;

//进程同步
//共50张票，3个窗口售卖

namespace Chapter10_Practice
{

    class TicketRest
    {
        int ticket = 1;
        public void sell()
        {
            while (ticket <= 50)
            {
                lock (this)
                {
                    if (ticket > 50) break; //这里一定要判断。
                    Console.WriteLine("窗口{0}售票员：售出第{1}号车票", Thread.CurrentThread.Name, ticket);
                    ticket++;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TicketRest a = new TicketRest();
            Thread t1 = new Thread(a.sell);
            t1.Name = "1";
            Thread t2 = new Thread(a.sell);
            t2.Name = "2";
            Thread t3 = new Thread(a.sell);
            t3.Name = "3";
            t1.Start();
            t2.Start();
            t3.Start();
            Console.Read();
        }
    }

}