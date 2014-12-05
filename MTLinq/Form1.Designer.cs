namespace MTLinq
{
    partial class Main
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
            this.agentURI = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.current = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // agentURI
            // 
            this.agentURI.Location = new System.Drawing.Point(13, 13);
            this.agentURI.Name = "agentURI";
            this.agentURI.Size = new System.Drawing.Size(241, 20);
            this.agentURI.TabIndex = 0;
            this.agentURI.Text = "http://24.73.86.186:63392/";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(13, 39);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 1;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // current
            // 
            this.current.Location = new System.Drawing.Point(13, 68);
            this.current.Name = "current";
            this.current.Size = new System.Drawing.Size(75, 21);
            this.current.TabIndex = 0;
            this.current.Text = "Current";
            this.current.UseVisualStyleBackColor = true;
            this.current.Click += new System.EventHandler(this.current_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 271);
            this.Controls.Add(this.current);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.agentURI);
            this.Name = "Main";
            this.Text = "MTConnect Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox agentURI;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button current;
    }
}

