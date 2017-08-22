namespace TestWaveChart
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.waveChart1 = new TestWaveChart.WaveChart();
            this.start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // waveChart1
            // 
            this.waveChart1.Location = new System.Drawing.Point(25, 3);
            this.waveChart1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.waveChart1.Name = "waveChart1";
            this.waveChart1.Size = new System.Drawing.Size(750, 560);
            this.waveChart1.TabIndex = 0;
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.start.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.start.Image = ((System.Drawing.Image)(resources.GetObject("start.Image")));
            this.start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.start.Location = new System.Drawing.Point(296, 559);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(146, 66);
            this.start.TabIndex = 1;
            this.start.Text = "点击开始";
            this.start.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 637);
            this.Controls.Add(this.start);
            this.Controls.Add(this.waveChart1);
            this.Name = "Form1";
            this.Text = "WaveChart";
            this.ResumeLayout(false);

        }

        #endregion

        private WaveChart waveChart1;
        private System.Windows.Forms.Button start;
    }
}

