using System;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private int len = 1000;
        private double[] a = new double[1000];
        private double[] b = new double[1000];
        private double[] c = new double[1000];
        private double[] d = new double[1000];
        private double[,] x = new double[4, 1000];
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
            double start = 0;
            double inc = 0.01;
            for (int i = 0; i < len; i++)
            {
                a[i] = Math.Sin(i*inc*2*Math.PI);
                b[i] = Math.Cos(start + i * inc);
                c[i] = r.NextDouble();
                d[i] = i * 0.001;
            }

            for (int i = 0; i < len; i++)
            {
                x[0, i] = a[i];
                x[1, i] = b[i];
                x[2, i] = c[i];
                x[3, i] = d[i];
            }

       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int len = 1000;
            //double[] a = new double[len];
            //double[] b = new double[len];
            //double[] c = new double[len];
            //double[] d = new double[len];
            //double[,] x=new double[4,len];
            //Random r = new Random();

            //double start = 0;
            //double inc = 0.01;
            //for (int i = 0; i < len; i++)
            //{
            //    a[i] = Math.Sin(start + i * inc);
            //    b[i] = Math.Cos(start + i * inc);
            //    c[i] = r.NextDouble();
            //    d[i] = i * 0.001;
            //}

            //for (int i = 0; i < len; i++)
            //{
            //    x[0, i] = a[i];
            //    x[1, i] = b[i];
            //    x[2, i] = c[i];
            //    x[3, i] = d[i];
            //}


            // waveChart1.Plot(a);
           // waveChart1.Plot(a,b);


            //waveChart1.Plot(b);
           waveChart1.Plot(x);

        }
    }
}
