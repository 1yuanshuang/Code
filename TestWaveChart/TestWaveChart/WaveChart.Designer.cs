namespace TestWaveChart
{
    partial class WaveChart
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.showXYValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.legendVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoYScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.savePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.setYAxisRangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ContextMenuStrip = this.contextMenuStrip1;
            this.chart1.Cursor = System.Windows.Forms.Cursors.IBeam;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(53, 15);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(557, 537);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.showXYValueToolStripMenuItem,
            this.toolStripSeparator1,
            this.legendVisibleToolStripMenuItem,
            this.autoYScaleToolStripMenuItem,
            this.toolStripSeparator2,
            this.savePictureToolStripMenuItem,
            this.saveAsCSVToolStripMenuItem,
            this.toolStripSeparator3,
            this.setYAxisRangeToolStripMenuItem,
            this.gridToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 286);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Checked = true;
            this.toolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem2.Text = "Zoom XAxis";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem3.Text = "Zoom YAxis";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem4.Text = "Zoom Window";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem5.Text = "Zoom Reset";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // showXYValueToolStripMenuItem
            // 
            this.showXYValueToolStripMenuItem.Name = "showXYValueToolStripMenuItem";
            this.showXYValueToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.showXYValueToolStripMenuItem.Text = "Show XYValue";
            this.showXYValueToolStripMenuItem.Click += new System.EventHandler(this.showXYValueToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // legendVisibleToolStripMenuItem
            // 
            this.legendVisibleToolStripMenuItem.Checked = true;
            this.legendVisibleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.legendVisibleToolStripMenuItem.Name = "legendVisibleToolStripMenuItem";
            this.legendVisibleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.legendVisibleToolStripMenuItem.Text = "LegendVisible";
            this.legendVisibleToolStripMenuItem.Click += new System.EventHandler(this.legendVisibleToolStripMenuItem_Click);
            // 
            // autoYScaleToolStripMenuItem
            // 
            this.autoYScaleToolStripMenuItem.Checked = true;
            this.autoYScaleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoYScaleToolStripMenuItem.Name = "autoYScaleToolStripMenuItem";
            this.autoYScaleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.autoYScaleToolStripMenuItem.Text = "Auto YScale";
            this.autoYScaleToolStripMenuItem.Click += new System.EventHandler(this.autoYScaleToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // savePictureToolStripMenuItem
            // 
            this.savePictureToolStripMenuItem.Name = "savePictureToolStripMenuItem";
            this.savePictureToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.savePictureToolStripMenuItem.Text = "Save Picture";
            this.savePictureToolStripMenuItem.Click += new System.EventHandler(this.savePictureToolStripMenuItem_Click);
            // 
            // saveAsCSVToolStripMenuItem
            // 
            this.saveAsCSVToolStripMenuItem.Name = "saveAsCSVToolStripMenuItem";
            this.saveAsCSVToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveAsCSVToolStripMenuItem.Text = "Save as CSV";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(166, 6);
            // 
            // setYAxisRangeToolStripMenuItem
            // 
            this.setYAxisRangeToolStripMenuItem.Name = "setYAxisRangeToolStripMenuItem";
            this.setYAxisRangeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.setYAxisRangeToolStripMenuItem.Text = "Set YAxis Range";
            this.setYAxisRangeToolStripMenuItem.Click += new System.EventHandler(this.setYAxisRangeToolStripMenuItem_Click);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // WaveChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.chart1);
            this.Name = "WaveChart";
            this.Size = new System.Drawing.Size(721, 601);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showXYValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legendVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoYScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setYAxisRangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
    }
}
