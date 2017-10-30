using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LinqTest
{
    public partial class WaveChart : UserControl
    {
        private Series s1 = new Series("series1");
        private int maxPoint = 1024;
        private Queue<double> dataQueue;
        private int pointIndex = 0;


        public WaveChart()
        {
            InitializeComponent();
            s1.Color = Color.Blue;
            s1.ChartType = SeriesChartType.FastLine;
            //chart1.ChartAreas[0].AxisX.Minimum =0;
            //chart1.ChartAreas[0].AxisX.Maximum =2000;
            //chart1.ChartAreas[0].AxisY.Minimum = 0;
            //chart1.ChartAreas[0].AxisY.Maximum = 40000;

            chart1.Series.Add(s1);
        }

        public int MaxPoints
        {
            get { return maxPoint; }
            set
            {
                maxPoint = value;
                dataQueue = new Queue<double>(maxPoint);
            }
        }


        private delegate void TimerCallback(double a);
        private void UpdateUI(double y)
        {
            chart1.Series[0].Points.AddXY(pointIndex, y);
            chart1.ResetAutoValues();

            if (chart1.Series[0].Points.Count > maxPoint)
            {
                while (chart1.Series[0].Points.Count > (maxPoint - 1))
                {
                    chart1.Series[0].Points.RemoveAt(0);
                }

                chart1.ChartAreas[0].AxisX.Minimum = pointIndex - maxPoint;
                chart1.ChartAreas[0].AxisX.Maximum = pointIndex;
            }

            pointIndex++;
            chart1.Invalidate();
        }

        public void Draw(double y, int xStart = 0, double xIncrement = 1)
        {
            if (chart1.InvokeRequired == true)
            {
                TimerCallback tcb = UpdateUI;
                this.Invoke(tcb, y);
            }
            else
            {
                UpdateUI(y);
            }
        }
    }
}
