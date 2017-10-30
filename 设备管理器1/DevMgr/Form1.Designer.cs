namespace DevMgr
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.更新驱动程序软件PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.禁用DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.卸载UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.扫描检测硬件改动AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(24, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(571, 427);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(520, 490);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新驱动程序软件PToolStripMenuItem,
            this.禁用DToolStripMenuItem,
            this.卸载UToolStripMenuItem,
            this.扫描检测硬件改动AToolStripMenuItem,
            this.属性RToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(205, 114);
            // 
            // 更新驱动程序软件PToolStripMenuItem
            // 
            this.更新驱动程序软件PToolStripMenuItem.Name = "更新驱动程序软件PToolStripMenuItem";
            this.更新驱动程序软件PToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.更新驱动程序软件PToolStripMenuItem.Text = "更新驱动程序软件（P）";
            // 
            // 禁用DToolStripMenuItem
            // 
            this.禁用DToolStripMenuItem.Name = "禁用DToolStripMenuItem";
            this.禁用DToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.禁用DToolStripMenuItem.Text = "禁用（D）";
            this.禁用DToolStripMenuItem.Click += new System.EventHandler(this.禁用DToolStripMenuItem_Click);
            // 
            // 卸载UToolStripMenuItem
            // 
            this.卸载UToolStripMenuItem.Name = "卸载UToolStripMenuItem";
            this.卸载UToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.卸载UToolStripMenuItem.Text = "卸载（U）";
            this.卸载UToolStripMenuItem.Click += new System.EventHandler(this.卸载UToolStripMenuItem_Click);
            // 
            // 扫描检测硬件改动AToolStripMenuItem
            // 
            this.扫描检测硬件改动AToolStripMenuItem.Name = "扫描检测硬件改动AToolStripMenuItem";
            this.扫描检测硬件改动AToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.扫描检测硬件改动AToolStripMenuItem.Text = "扫描检测硬件改动（A）";
            // 
            // 属性RToolStripMenuItem
            // 
            this.属性RToolStripMenuItem.Name = "属性RToolStripMenuItem";
            this.属性RToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.属性RToolStripMenuItem.Text = "属性（R）";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 523);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 更新驱动程序软件PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 禁用DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 卸载UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 扫描检测硬件改动AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性RToolStripMenuItem;
    }
}

