namespace HW_Lib_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.buttonEnable = new System.Windows.Forms.Button();
            this.buttonDisable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CommonName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FriendlyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HardwareId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listdevices = new System.Windows.Forms.ListView();
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // buttonEnable
            // 
            this.buttonEnable.Location = new System.Drawing.Point(259, 665);
            this.buttonEnable.Name = "buttonEnable";
            this.buttonEnable.Size = new System.Drawing.Size(89, 29);
            this.buttonEnable.TabIndex = 1;
            this.buttonEnable.Text = "Enable";
            this.buttonEnable.UseVisualStyleBackColor = true;
            this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
            // 
            // buttonDisable
            // 
            this.buttonDisable.Location = new System.Drawing.Point(518, 665);
            this.buttonDisable.Name = "buttonDisable";
            this.buttonDisable.Size = new System.Drawing.Size(89, 29);
            this.buttonDisable.TabIndex = 2;
            this.buttonDisable.Text = "Disable";
            this.buttonDisable.UseVisualStyleBackColor = true;
            this.buttonDisable.Click += new System.EventHandler(this.buttonDisable_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "XX Devices Attached";
            // 
            // CommonName
            // 
            this.CommonName.Text = "Name";
            this.CommonName.Width = 236;
            // 
            // FriendlyName
            // 
            this.FriendlyName.Text = "Friendly Name";
            this.FriendlyName.Width = 235;
            // 
            // HardwareId
            // 
            this.HardwareId.Text = "Hardware Id";
            this.HardwareId.Width = 270;
            // 
            // listdevices
            // 
            this.listdevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CommonName,
            this.FriendlyName,
            this.HardwareId,
            this.Status});
            this.listdevices.FullRowSelect = true;
            this.listdevices.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listdevices.Location = new System.Drawing.Point(34, 26);
            this.listdevices.MultiSelect = false;
            this.listdevices.Name = "listdevices";
            this.listdevices.Size = new System.Drawing.Size(858, 615);
            this.listdevices.TabIndex = 5;
            this.listdevices.UseCompatibleStateImageBehavior = false;
            this.listdevices.View = System.Windows.Forms.View.Details;
            this.listdevices.SelectedIndexChanged += new System.EventHandler(this.listdevices_SelectedIndexChanged);
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Status.Width = 93;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 723);
            this.Controls.Add(this.listdevices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDisable);
            this.Controls.Add(this.buttonEnable);
            this.Name = "Form1";
            this.Text = "Devices manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonEnable;
        private System.Windows.Forms.Button buttonDisable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader CommonName;
        private System.Windows.Forms.ColumnHeader FriendlyName;
        private System.Windows.Forms.ColumnHeader HardwareId;
        private System.Windows.Forms.ListView listdevices;
        private System.Windows.Forms.ColumnHeader Status;
    }
}

