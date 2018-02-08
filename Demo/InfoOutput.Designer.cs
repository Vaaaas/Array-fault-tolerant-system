namespace Demo
{
    partial class InfoOutput
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
            this.InfoBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InfoBox
            // 
            this.InfoBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoBox.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InfoBox.Location = new System.Drawing.Point(0, 0);
            this.InfoBox.Multiline = true;
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(484, 361);
            this.InfoBox.TabIndex = 0;
            // 
            // InfoOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.InfoBox);
            this.Name = "InfoOutput";
            this.Text = "InfoOutput";
            this.Load += new System.EventHandler(this.InfoOutput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InfoBox;
    }
}