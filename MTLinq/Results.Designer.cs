using System.Windows.Forms;

namespace MTLinq
{
    partial class Results
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
            this.data = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // data
            // 
            this.data.AllowColumnReorder = true;
            this.data.FullRowSelect = true;
            this.data.Location = new System.Drawing.Point(13, 13);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(637, 363);
            this.data.TabIndex = 0;
            this.data.UseCompatibleStateImageBehavior = false;
            this.data.View = System.Windows.Forms.View.Details;
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 388);
            this.Controls.Add(this.data);
            this.Name = "Results";
            this.Text = "Results";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView data;

    }
}