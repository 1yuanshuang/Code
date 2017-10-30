namespace DevManager
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.更新驱动程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.禁用设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.卸载设备UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.扫描检测硬件驱动AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Location = new System.Drawing.Point(2, 21);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(247, 596);
            this.treeView1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(255, 21);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(598, 596);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新驱动程序ToolStripMenuItem,
            this.禁用设备ToolStripMenuItem,
            this.卸载设备UToolStripMenuItem,
            this.扫描检测硬件驱动AToolStripMenuItem,
            this.属性RToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(205, 114);
            // 
            // 更新驱动程序ToolStripMenuItem
            // 
            this.更新驱动程序ToolStripMenuItem.Name = "更新驱动程序ToolStripMenuItem";
            this.更新驱动程序ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.更新驱动程序ToolStripMenuItem.Text = "更新驱动程序（P）";
            // 
            // 禁用设备ToolStripMenuItem
            // 
            this.禁用设备ToolStripMenuItem.Name = "禁用设备ToolStripMenuItem";
            this.禁用设备ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.禁用设备ToolStripMenuItem.Text = "禁用设备（D）";
            // 
            // 卸载设备UToolStripMenuItem
            // 
            this.卸载设备UToolStripMenuItem.Name = "卸载设备UToolStripMenuItem";
            this.卸载设备UToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.卸载设备UToolStripMenuItem.Text = "卸载设备（U）";
            // 
            // 扫描检测硬件驱动AToolStripMenuItem
            // 
            this.扫描检测硬件驱动AToolStripMenuItem.Name = "扫描检测硬件驱动AToolStripMenuItem";
            this.扫描检测硬件驱动AToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.扫描检测硬件驱动AToolStripMenuItem.Text = "扫描检测硬件驱动（A）";
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
            this.ClientSize = new System.Drawing.Size(865, 629);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 更新驱动程序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 禁用设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 卸载设备UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 扫描检测硬件驱动AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性RToolStripMenuItem;
    }
}

