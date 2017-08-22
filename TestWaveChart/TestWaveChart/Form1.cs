using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWaveChart
{
    public partial class Form1 : Form
    {
        private double[] a = new double[1000];
        private double[] b = new double[1000];
        private double[] c = new double[1000];
        private double[] d = new double[1000];
        private double[] e = new double[1000];

        private double[,] x = new double[5,1000];

        Random r = new Random();

        public Form1()
        {
            double increment = 0.01;
            InitializeComponent();
            for (int i = 0; i < 1000; i++)
            {
                a[i] = Math.Sin(i * increment);
                b[i] = Math.Cos(i * increment);
                c[i] = r.NextDouble();
                d[i] = i * 0.001;
                e[i] = Math.Sin(i*increment);

            }

            for (int i = 0; i < 1000; i++)
            {
                x[0, i] = a[i];
                x[1, i] = b[i];
                x[2, i] = c[i];
                x[3, i] = d[i];
                x[4, i] = e[i];

            }
        }

        private void start_Click(object sender, EventArgs e)
        {
             waveChart1.Plot(x);
            //waveChart1.Plot(a, b);
            //waveChart1.Plot(d);


        }

    }
}
