namespace Demo
{
    partial class SetPathForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetPathForm));
            this.RootPathLabel = new System.Windows.Forms.Label();
            this.RootPathText = new System.Windows.Forms.TextBox();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.RootPathDial = new System.Windows.Forms.FolderBrowserDialog();
            this.FolderNameLabel = new System.Windows.Forms.Label();
            this.FolderNameText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RootPathLabel
            // 
            this.RootPathLabel.AutoSize = true;
            this.RootPathLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RootPathLabel.Location = new System.Drawing.Point(37, 51);
            this.RootPathLabel.Name = "RootPathLabel";
            this.RootPathLabel.Size = new System.Drawing.Size(135, 20);
            this.RootPathLabel.TabIndex = 0;
            this.RootPathLabel.Text = "请选择存储根目录：";
            // 
            // RootPathText
            // 
            this.RootPathText.Location = new System.Drawing.Point(41, 93);
            this.RootPathText.Name = "RootPathText";
            this.RootPathText.Size = new System.Drawing.Size(281, 21);
            this.RootPathText.TabIndex = 1;
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(342, 93);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(60, 23);
            this.BrowseBtn.TabIndex = 2;
            this.BrowseBtn.Text = "浏览...";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(422, 93);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(45, 23);
            this.ClearBtn.TabIndex = 3;
            this.ClearBtn.Text = "清空";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Enabled = false;
            this.AcceptBtn.Location = new System.Drawing.Point(392, 217);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(75, 23);
            this.AcceptBtn.TabIndex = 4;
            this.AcceptBtn.Text = "确认";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // RootPathDial
            // 
            this.RootPathDial.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.RootPathDial.ShowNewFolderButton = false;
            // 
            // FolderNameLabel
            // 
            this.FolderNameLabel.AutoSize = true;
            this.FolderNameLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FolderNameLabel.Location = new System.Drawing.Point(41, 138);
            this.FolderNameLabel.Name = "FolderNameLabel";
            this.FolderNameLabel.Size = new System.Drawing.Size(149, 20);
            this.FolderNameLabel.TabIndex = 5;
            this.FolderNameLabel.Text = "请输入子文件夹名称：";
            // 
            // FolderNameText
            // 
            this.FolderNameText.Location = new System.Drawing.Point(41, 176);
            this.FolderNameText.Name = "FolderNameText";
            this.FolderNameText.Size = new System.Drawing.Size(281, 21);
            this.FolderNameText.TabIndex = 6;
            this.FolderNameText.TextChanged += new System.EventHandler(this.FolderNameText_TextChanged);
            // 
            // SetPathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 273);
            this.Controls.Add(this.FolderNameText);
            this.Controls.Add(this.FolderNameLabel);
            this.Controls.Add(this.AcceptBtn);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.RootPathText);
            this.Controls.Add(this.RootPathLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SetPathForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetPathForm";
            this.Load += new System.EventHandler(this.SetPathForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RootPathLabel;
        private System.Windows.Forms.TextBox RootPathText;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button AcceptBtn;
        private System.Windows.Forms.FolderBrowserDialog RootPathDial;
        private System.Windows.Forms.Label FolderNameLabel;
        private System.Windows.Forms.TextBox FolderNameText;
    }
}