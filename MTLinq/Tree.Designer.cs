namespace MTLinq
{
    partial class Tree
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
            this.devices = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // devices
            // 
            this.devices.Location = new System.Drawing.Point(13, 13);
            this.devices.Name = "devices";
            this.devices.Size = new System.Drawing.Size(377, 361);
            this.devices.TabIndex = 0;
            // 
            // Tree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 386);
            this.Controls.Add(this.devices);
            this.Name = "Tree";
            this.Text = "Tree";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView devices;
    }
}