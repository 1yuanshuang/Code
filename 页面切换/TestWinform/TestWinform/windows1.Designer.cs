namespace TestWinform
{
    partial class windows1
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
            this.窗口一 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // 窗口一
            // 
            this.窗口一.AutoSize = true;
            this.窗口一.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.窗口一.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.窗口一.Location = new System.Drawing.Point(192, 103);
            this.窗口一.Name = "窗口一";
            this.窗口一.Size = new System.Drawing.Size(100, 29);
            this.窗口一.TabIndex = 0;
            this.窗口一.Text = "窗口一";
            this.窗口一.Click += new System.EventHandler(this.窗口一_Click);
            // 
            // windows1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.窗口一);
            this.Name = "windows1";
            this.Size = new System.Drawing.Size(500, 296);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label 窗口一;
    }
}
