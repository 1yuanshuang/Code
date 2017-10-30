using System;

namespace JYSwitchDemo
{
    partial class JYSwitch
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
            this.SuspendLayout();
   
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "JYSwitch";
            this.ResumeLayout(false);

        }

        #endregion

        bool isCheck = false;
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked
        {
            set { isCheck = value; this.Invalidate(); }
            get { return isCheck; }
        }
        public enum CheckStyle
        {
            style1,
            style2,
            style3,
            style4,
        };
        CheckStyle checkStyle = CheckStyle.style3;
        /// <summary>
        /// 样式
        /// </summary>
        public CheckStyle CheckStyleX
        {
            set { checkStyle = value; this.Invalidate(); }
            get { return checkStyle; }
        }

        /// <summary>
        /// 事件
        /// </summary>
        public event EventHandler CheckChanged;
        /// <summary>
        /// 单机按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JYSwitch_Click(object sender, EventArgs e)
        {
            isCheck = !isCheck;
            this.Invalidate();
            //这个需要在外部去定义才可以使用，这才是真正的内容
            if (CheckChanged != null)
            {
                //TODO
                CheckChanged(sender, e);
            }
        }
    }
}
