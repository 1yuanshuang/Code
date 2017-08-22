using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestWaveChart
{
    public partial class WaveChart : UserControl
    {
        public WaveChart()
        {
            InitializeComponent();
        }

        public void Plot(double[] y)
        {
            Series s = new Series();
            s.ChartType = SeriesChartType.Spline;
            s.Color = Color.Red;
            for (int j = 0; j < y.Length; j++)
            {
                s.Points.Add(y[j]);
            }
            chart1.Series.Add(s);
        }

        public void Plot(double[] a, double[] b)
        {
            Series s1 = new Series();
            s1.ChartType = SeriesChartType.Spline;
            s1.Color = Color.Red;
            if(a.Length<b.Length)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    s1.Points.AddXY(a[j], b[j]);
                }
            }
            else
            {
                for (int j = 0; j < b.Length; j++)
                {
                    s1.Points.AddXY(a[j], b[j]);
                }
            }
            chart1.Series.Add(s1);
        }

        public void Plot(double[,] y)
        {
            int row = y.GetLength(0);
            int col = y.GetLength(1);
            Series[] s1 = new Series[row];

            for (int i = 0; i < row; i++)
            {
                s1[i] = new Series(string.Format("series{0}", i + 1));
                s1[i].ChartType = SeriesChartType.Spline;
                //s1[i] = new Series("series" + i.ToString());
                chart1.Series.Add(s1[i]);
                for (int j = 0; j < col; j++)
                {
                    chart1.Series[i].Points.AddXY(j, y[i, j]);
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem2.Checked)
            {
                toolStripMenuItem2.Checked = false;
                chart1.ChartAreas[0].CursorX.IsUserEnabled = false;
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            }
            else
            {
                toolStripMenuItem2.Checked = true;
                chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chart1.ChartAreas[0].CursorX.Interval = 0;
                chart1.ChartAreas[0].CursorX.IntervalOffset = 0;
                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            }
        }



        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem3.Checked)
            {
                toolStripMenuItem3.Checked = false;

                chart1.ChartAreas[0].CursorY.IsUserEnabled = false;
                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
                chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = false;
            }
            else
            {
                toolStripMenuItem3.Checked = true;

                chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                chart1.ChartAreas[0].CursorY.Interval = 0;
                chart1.ChartAreas[0].CursorY.IntervalOffset = 0;
                chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            }
        }


        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem4.Checked)
            {
                toolStripMenuItem4.Checked = false;

                chart1.ChartAreas[0].CursorX.IsUserEnabled = false;
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
                chart1.ChartAreas[0].CursorY.IsUserEnabled = false;
                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
                chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = false;
            }
            else
            {
                toolStripMenuItem4.Checked = true;
                chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chart1.ChartAreas[0].CursorX.Interval = 0;
                chart1.ChartAreas[0].CursorX.IntervalOffset = 0;
                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

                chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                chart1.ChartAreas[0].CursorY.Interval = 0;
                chart1.ChartAreas[0].CursorY.IntervalOffset = 0;
                chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem5.Checked)
            {
                toolStripMenuItem5.Checked = false;
            }
            else
            {
                toolStripMenuItem5.Checked = true;
                chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
            }
        }

        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridToolStripMenuItem.Checked)
            {
                gridToolStripMenuItem.Checked = false;
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            }
            else
            {
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Red;
                chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 0.1;
                chart1.ChartAreas[0].AxisY.MinorGrid.Interval = 0.1;
                chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;

                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Red;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 20;//网格间隔
                chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 20;
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;

                gridToolStripMenuItem.Checked = true;
            }
        }

        private void setYAxisRangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setYAxisRangeToolStripMenuItem.Checked)
            {
                setYAxisRangeToolStripMenuItem.Checked = false;

            }
            else
            {
                chart1.ChartAreas[0].AxisY.Minimum = 10;
                chart1.ChartAreas[0].AxisY.Maximum = 900;
                setYAxisRangeToolStripMenuItem.Checked = true;
            }
        }

        private void autoYScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autoYScaleToolStripMenuItem.Checked)
            {
                autoYScaleToolStripMenuItem.Checked = false;
                chart1.ChartAreas[0].AxisY.Maximum = 50;
                chart1.ChartAreas[0].AxisY.Minimum = 10;
            }
            else
            {
                autoYScaleToolStripMenuItem.Checked = true;
                chart1.ChartAreas[0].AxisY.Minimum = Double.NaN;
                chart1.ChartAreas[0].AxisY.Maximum = Double.NaN;
            }
        }

        private void legendVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (legendVisibleToolStripMenuItem.Checked)
            {
                //chart1.Legends.Clear();
                for (int i = 0; i < chart1.Series.Count; i++)
                {
                    chart1.Series[i].IsVisibleInLegend = false;  //是否显示数据说明   
                }
                legendVisibleToolStripMenuItem.Checked = false;
            }
            else
            {
                for (int i = 0; i < chart1.Series.Count; i++)
                {
                    chart1.Series[i].IsVisibleInLegend = true;  //是否显示数据说明   
                }
                legendVisibleToolStripMenuItem.Checked = true;

            }
        }

        private void showXYValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showXYValueToolStripMenuItem.Checked)
            {
                showXYValueToolStripMenuItem.Checked = false;
                for (int i = 0; i < chart1.Series.Count; i++)
                {
                    chart1.Series[i].IsValueShownAsLabel = false;
                }
            }

            else
            {
                for (int i = 0; i < chart1.Series.Count; i++)
                {
                    chart1.Series[i].ToolTip = "#VALX,#VALY";
                    chart1.Series[i].IsValueShownAsLabel = true;
                }
                showXYValueToolStripMenuItem.Checked = true;
            }
        }
        private void savePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "picture|*.png";
            if ((save.ShowDialog() == DialogResult.OK) && !string.Empty.Equals(save.FileName))
            {
                chart1.SaveImage(save.FileName, ChartImageFormat.Png);
            }
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
                {
                    var item = contextMenuStrip1.Items[i];
                    if (item.GetType().Name.CompareTo("ToolStripMenuItem") == 0)
                    {
                        ToolStripMenuItem it = item as ToolStripMenuItem;
                        if ((it.Tag != null) && (it.Tag.ToString().CompareTo("Serials") == 0))
                        {
                            contextMenuStrip1.Items.RemoveAt(i);
                            i--;
                        }
                    }
                }

                foreach (var serial in chart1.Series)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(serial.Name);
                    item.Tag = "Serials";
                    item.Checked = serial.Enabled;
                    contextMenuStrip1.Items.Add(item);
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if ((e.ClickedItem.Tag != null) && (e.ClickedItem.Tag.ToString().CompareTo("Serials") == 0))
            {
                chart1.Series[e.ClickedItem.Text].Enabled = !((ToolStripMenuItem)e.ClickedItem).Checked;
            }
        }

        //private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    this.contextMenuStrip1.Visible = false;

        //    switch (e.ClickedItem.Text)
        //    {
        //        case "Zoom XAxis":
        //            ToolStripMenuItem t= (ToolStripMenuItem)contextMenuStrip1.Items[0];
        //            if(t.Checked)
        //            {
        //                t.Checked = false;
        //                chart1.ChartAreas[0].CursorX.IsUserEnabled = false;
        //                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
        //                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
        //            }
        //            else
        //            {
        //                t.Checked = true;
        //                chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
        //                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
        //                chart1.ChartAreas[0].CursorX.Interval = 0;
        //                chart1.ChartAreas[0].CursorX.IntervalOffset = 0;
        //                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
        //            }
        //            break;

        //        case "Zoom YAxis":
        //            ToolStripMenuItem t1 = (ToolStripMenuItem)contextMenuStrip1.Items[1];
        //            if (t1.Checked)
        //            {
        //                t1.Checked = false;

        //                chart1.ChartAreas[0].CursorY.IsUserEnabled = false;
        //                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
        //                chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = false;
        //            }
        //            else
        //            {
        //                t1.Checked = true;

        //                chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
        //                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        //                chart1.ChartAreas[0].CursorY.Interval = 0;
        //                chart1.ChartAreas[0].CursorY.IntervalOffset = 0;
        //                chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
        //            }
        //            break;

        //        case "Zoom Window":
        //            ToolStripMenuItem t3 = (ToolStripMenuItem)contextMenuStrip1.Items[2];
        //            if (t3.Checked)
        //            {
        //                t3.Checked = false;

        //                chart1.ChartAreas[0].CursorX.IsUserEnabled = false;
        //                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
        //                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
        //                chart1.ChartAreas[0].CursorY.IsUserEnabled = false;
        //                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
        //                chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = false;
        //            }
        //            else
        //            {
        //                t3.Checked = true;
        //                chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
        //                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
        //                chart1.ChartAreas[0].CursorX.Interval = 0;
        //                chart1.ChartAreas[0].CursorX.IntervalOffset = 0;
        //                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

        //                chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
        //                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        //                chart1.ChartAreas[0].CursorY.Interval = 0;
        //                chart1.ChartAreas[0].CursorY.IntervalOffset = 0;
        //                chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
        //            }
        //            break;
        //        case "Zoom Reset":
        //            ToolStripMenuItem t4 = (ToolStripMenuItem)contextMenuStrip1.Items[3];
        //            if(t4.Checked)
        //            {
        //                t4.Checked = false;
        //            }
        //            else
        //            {
        //                t4.Checked = true;
        //                chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
        //                chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        //            }
        //            break;

        //        case "Show XYValue":
        //            if(showXYValueToolStripMenuItem.Checked)
        //            {
        //                showXYValueToolStripMenuItem.Checked = false;
        //                for (int i = 0; i < chart1.Series.Count; i++)
        //                {
        //                    chart1.Series[i].IsValueShownAsLabel = false;
        //                }
        //            }

        //            else
        //            {
        //                for(int i=0;i<chart1.Series.Count;i++)
        //                {
        //                    chart1.Series[i].ToolTip = "#VALX,#VALY";
        //                    chart1.Series[i].IsValueShownAsLabel = true;
        //                }
        //                showXYValueToolStripMenuItem.Checked = true;
        //            }
        //            break;

        //        case "LegendVisible":
        //            if(legendVisibleToolStripMenuItem.Checked)
        //            {
        //                chart1.Legends.Clear();
        //                legendVisibleToolStripMenuItem.Checked = false;
        //            }
        //            else
        //            {
        //                legendVisibleToolStripMenuItem.Checked = true;
        //            }
        //            break;

        //        case "Auto YScale":
        //            if(autoYScaleToolStripMenuItem.Checked)
        //            {
        //                autoYScaleToolStripMenuItem.Checked = false;
        //                chart1.ChartAreas[0].AxisY.Maximum = 50;
        //                chart1.ChartAreas[0].AxisY.Minimum = 10;
        //            }
        //            else
        //            {
        //                autoYScaleToolStripMenuItem.Checked = true;
        //                chart1.ChartAreas[0].AxisY.Minimum = Double.NaN;
        //                chart1.ChartAreas[0].AxisY.Maximum = Double.NaN;
        //            }
        //            break;

        //        case "Save Picture":
        //            SaveFileDialog save = new SaveFileDialog();
        //            save.Filter = "pic|*.png";
        //            if ((save.ShowDialog() == DialogResult.OK)&& !string.Empty.Equals(save.FileName))
        //            {
        //                chart1.SaveImage(save.FileName, ChartImageFormat.Png);
        //            }
        //            break;

        //        case "Grid":
        //            if(gridToolStripMenuItem.Checked)
        //            {
        //                gridToolStripMenuItem.Checked = false;
        //                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        //                chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        //            }
        //            else
        //            {
        //                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Red;
        //                chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 20;
        //                chart1.ChartAreas[0].AxisY.MinorGrid.Interval = 20;
        //                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;

        //                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Aqua;
        //                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 20;//网格间隔
        //                chart1.ChartAreas[0].AxisX.MinorGrid.Interval = 20;
        //                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;

        //                gridToolStripMenuItem.Checked = true;
        //            }
        //            break;

        //        case "Save as CSV":
        //            if(saveAsCSVToolStripMenuItem.Checked)
        //            {

        //            }
        //            else
        //            {

        //            }
        //            break;

        //        case "Set YAxis Range":
        //            if(setYAxisRangeToolStripMenuItem.Checked)
        //            {
        //                setYAxisRangeToolStripMenuItem.Checked = false;
        //            }
        //            else
        //            {
        //                chart1.ChartAreas[0].AxisY.Minimum = 10;
        //                chart1.ChartAreas[0].AxisY.Maximum = 900;
        //                setYAxisRangeToolStripMenuItem.Checked = true;
        //            }
        //            break;
        //case "Series1":
        //    if (series1ToolStripMenuItem.Checked)
        //    {
        //        series1ToolStripMenuItem.Checked = false;
        //        chart1.Series[0].Enabled = false;
        //    }
        //    else
        //    {
        //        series1ToolStripMenuItem.Checked = true;
        //        chart1.Series[0].Enabled = true;
        //    }
        //    break;

        //case "Series2":
        //    if (series2ToolStripMenuItem.Checked)
        //    {
        //        series2ToolStripMenuItem.Checked = false;
        //        chart1.Series[1].Enabled = false;
        //    }
        //    else
        //    {
        //        series2ToolStripMenuItem.Checked = true;
        //        chart1.Series[1].Enabled = true;
        //    }
        //    break;

        //case "Series3":
        //    if (series3ToolStripMenuItem.Checked)
        //    {
        //        series3ToolStripMenuItem.Checked = false;
        //        chart1.Series[2].Enabled = false;
        //    }
        //    else
        //    {
        //        series3ToolStripMenuItem.Checked = true;
        //        chart1.Series[2].Enabled = true;
        //    }
        //    break;

        //case "Series4":
        //    if (series4ToolStripMenuItem.Checked)
        //    {
        //        series4ToolStripMenuItem.Checked = false;
        //        chart1.Series[3].Enabled = false;
        //    }
        //    else
        //    {
        //        series4ToolStripMenuItem.Checked = true;
        //        chart1.Series[3].Enabled = true;
        //    }
        //    break;
        //        default:
        //            if ((e.ClickedItem.Tag != null) && (e.ClickedItem.Tag.ToString().CompareTo("Serials") == 0))
        //            {
        //                chart1.Series[e.ClickedItem.Text].Enabled = !((ToolStripMenuItem)e.ClickedItem).Checked;
        //            }
        //            break;
        //    }
        //}

    }
}

