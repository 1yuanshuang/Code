using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp5
{
    public partial class waveChart : UserControl
    {
        private Series s1 = new Series("series1");
        //private Series s2 = new Series("series2");
        //private Series s3 = new Series("series3");
        //private Series s4 = new Series("series4");

        private Series[] s = new Series[4];

        private Color[] myColors = { Color.Red, Color.Blue, Color.Black, Color.BlueViolet, Color.DarkRed };
        public waveChart()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                s[i] = new Series(string.Format("series{0}", i));
                s[i].Color = myColors[i];
                s[i].ChartType = SeriesChartType.Spline;
                chart1.Series.Add(s[i]);
            }

            //s1.Color = Color.Green;
            //s1.ChartType = SeriesChartType.Spline;
            //chart1.Series.Add(s1);

            //s2.Color = Color.Blue;
            //s2.ChartType = SeriesChartType.Spline;
            //chart1.Series.Add(s2);

            //s3.Color = Color.Red;
            //s3.ChartType = SeriesChartType.Spline;
            //chart1.Series.Add(s3);

            //s4.Color = Color.Black;
            //s4.ChartType = SeriesChartType.Spline;
            //chart1.Series.Add(s4);
        }
   
        public void Plot(double[] y, int xStart = 0, double xIncrement = 1)
        {
            for (int j = 0; j < y.Length; j++)
            {
                s1.Points.AddY(y[j]);
            }            
        }

        public void Plot(double[] a, double[] b)
        {
            for (int j = 0; j < b.Length; j++)
            {
                s1.Points.AddXY(a[j], b[j]);
            }
        }

        public void Plot(double[,] a)
        {
            int row = a.GetLength(0);
            int col = a.GetLength(1);

            for (int j = 0; j < col; j++)
            {               
                s[0].Points.AddY(a[0, j]);
                s[1].Points.AddY(a[1, j]);
                s[2].Points.AddY(a[2, j]);
                s[3].Points.AddY(a[3, j]);
            }


            //Color[] myColors = { Color.Red, Color.Blue, Color.Black, Color.BlueViolet, Color.DarkRed };
            // chart1.Series.Clear();
            //Series s = new Series();
            //s.ChartType = SeriesChartType.Spline;
            //s1.Color = myColors[i];
            //for (int j = 0; j < col; j++)
            //{
            //s1.Points.AddY(a[i, i]);
            //s2.Points.AddY(a[i, j]);
            //s3.Points.AddY(a[i, j]);
            //s4.Points.AddY(a[i, j]);

            //s.Points.DataBindXY();
            //}
            //chart1.Series.Add(s1);
            //chart1.Legends.Insert(i, new Legend(string.Format("波形{0}", i)));
            // }
        }
    }
}
