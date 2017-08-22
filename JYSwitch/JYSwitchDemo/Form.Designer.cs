namespace JYSwitchDemo
{
    partial class Form
    {
        private System.ComponentModel.IContainer components = null;

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
            this.jySwitch1 = new JYSwitchDemo.JYSwitch();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Led = new JYSwitchDemo.LED();
            this.SuspendLayout();
            // 
            // jySwitch1
            // 
            this.jySwitch1.BackColor = System.Drawing.Color.Transparent;
            this.jySwitch1.Checked = false;
            this.jySwitch1.CheckStyleX = JYSwitchDemo.JYSwitch.CheckStyle.style1;
            this.jySwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jySwitch1.Location = new System.Drawing.Point(74, 94);
            this.jySwitch1.Name = "jySwitch1";
            this.jySwitch1.Size = new System.Drawing.Size(59, 71);
            this.jySwitch1.TabIndex = 0;
            this.jySwitch1.CheckChanged += new System.EventHandler(this.jySwitch1_CheckChanged);
            // 
            // Led
            // 
            this.Led.Checked = false;
            this.Led.Location = new System.Drawing.Point(300, 79);
            this.Led.Name = "Led";
            this.Led.Size = new System.Drawing.Size(99, 99);
            this.Led.TabIndex = 2;
            this.Led.Load += new System.EventHandler(this.Led_Load);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(478, 330);
            this.Controls.Add(this.Led);
            this.Controls.Add(this.jySwitch1);
            this.Name = "Form";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private JYSwitchDemo.JYSwitch jySwitch1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private LED Led;
    }
}

