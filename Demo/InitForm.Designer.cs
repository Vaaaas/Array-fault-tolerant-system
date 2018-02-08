namespace Demo
{
    partial class InitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitForm));
            this.dataFolderList = new System.Windows.Forms.CheckedListBox();
            this.rddtFolderList = new System.Windows.Forms.CheckedListBox();
            this.deviceNumLabel = new System.Windows.Forms.Label();
            this.deviceNumBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.faultNumBox = new System.Windows.Forms.NumericUpDown();
            this.rowNumBox = new System.Windows.Forms.NumericUpDown();
            this.rddtDeviceNumBox = new System.Windows.Forms.TextBox();
            this.deviceNumLabel2 = new System.Windows.Forms.Label();
            this.dataNumLabel = new System.Windows.Forms.Label();
            this.rddtNumLabel = new System.Windows.Forms.Label();
            this.acceptDataBtn = new System.Windows.Forms.Button();
            this.rddtPic = new System.Windows.Forms.PictureBox();
            this.resetDeviceBtn = new System.Windows.Forms.Button();
            this.faultNRowAcceptBtn = new System.Windows.Forms.Button();
            this.dataPic = new System.Windows.Forms.PictureBox();
            this.rowPic = new System.Windows.Forms.PictureBox();
            this.faultPic = new System.Windows.Forms.PictureBox();
            this.AcceptSettingBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.selectAllDataBtn = new System.Windows.Forms.Button();
            this.toggleDataBtn = new System.Windows.Forms.Button();
            this.toggleRddtBtn = new System.Windows.Forms.Button();
            this.selectAllRddtBtn = new System.Windows.Forms.Button();
            this.AutoSelectBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.faultNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddtPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faultPic)).BeginInit();
            this.SuspendLayout();
            // 
            // dataFolderList
            // 
            this.dataFolderList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataFolderList.CheckOnClick = true;
            this.dataFolderList.Enabled = false;
            this.dataFolderList.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataFolderList.FormattingEnabled = true;
            this.dataFolderList.Location = new System.Drawing.Point(50, 185);
            this.dataFolderList.Name = "dataFolderList";
            this.dataFolderList.Size = new System.Drawing.Size(320, 222);
            this.dataFolderList.TabIndex = 0;
            this.dataFolderList.SelectedIndexChanged += new System.EventHandler(this.dataDeviceList_SelectedIndexChanged);
            // 
            // rddtFolderList
            // 
            this.rddtFolderList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rddtFolderList.CheckOnClick = true;
            this.rddtFolderList.Enabled = false;
            this.rddtFolderList.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rddtFolderList.FormattingEnabled = true;
            this.rddtFolderList.Location = new System.Drawing.Point(433, 185);
            this.rddtFolderList.Name = "rddtFolderList";
            this.rddtFolderList.Size = new System.Drawing.Size(320, 222);
            this.rddtFolderList.TabIndex = 2;
            this.rddtFolderList.SelectedIndexChanged += new System.EventHandler(this.rddtDeviceList_SelectedIndexChanged);
            // 
            // deviceNumLabel
            // 
            this.deviceNumLabel.AutoSize = true;
            this.deviceNumLabel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.deviceNumLabel.Location = new System.Drawing.Point(196, 484);
            this.deviceNumLabel.Name = "deviceNumLabel";
            this.deviceNumLabel.Size = new System.Drawing.Size(79, 20);
            this.deviceNumLabel.TabIndex = 7;
            this.deviceNumLabel.Text = "数据盘数量";
            // 
            // deviceNumBox
            // 
            this.deviceNumBox.BackColor = System.Drawing.SystemColors.Control;
            this.deviceNumBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.deviceNumBox.Enabled = false;
            this.deviceNumBox.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.deviceNumBox.Location = new System.Drawing.Point(211, 452);
            this.deviceNumBox.Name = "deviceNumBox";
            this.deviceNumBox.Size = new System.Drawing.Size(49, 18);
            this.deviceNumBox.TabIndex = 8;
            this.deviceNumBox.Text = "0";
            this.deviceNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(245, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "容错数量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.Location = new System.Drawing.Point(485, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "阵列行数";
            // 
            // faultNumBox
            // 
            this.faultNumBox.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.faultNumBox.Location = new System.Drawing.Point(255, 58);
            this.faultNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.faultNumBox.Name = "faultNumBox";
            this.faultNumBox.Size = new System.Drawing.Size(44, 25);
            this.faultNumBox.TabIndex = 11;
            this.faultNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.faultNumBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.faultNumBox.ValueChanged += new System.EventHandler(this.faultNumBox_ValueChanged);
            // 
            // rowNumBox
            // 
            this.rowNumBox.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rowNumBox.Location = new System.Drawing.Point(494, 58);
            this.rowNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rowNumBox.Name = "rowNumBox";
            this.rowNumBox.Size = new System.Drawing.Size(44, 25);
            this.rowNumBox.TabIndex = 12;
            this.rowNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rowNumBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.rowNumBox.ValueChanged += new System.EventHandler(this.rowNumBox_ValueChanged);
            // 
            // rddtDeviceNumBox
            // 
            this.rddtDeviceNumBox.BackColor = System.Drawing.SystemColors.Control;
            this.rddtDeviceNumBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rddtDeviceNumBox.Enabled = false;
            this.rddtDeviceNumBox.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.rddtDeviceNumBox.Location = new System.Drawing.Point(619, 452);
            this.rddtDeviceNumBox.Name = "rddtDeviceNumBox";
            this.rddtDeviceNumBox.Size = new System.Drawing.Size(49, 18);
            this.rddtDeviceNumBox.TabIndex = 18;
            this.rddtDeviceNumBox.Text = "0";
            this.rddtDeviceNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // deviceNumLabel2
            // 
            this.deviceNumLabel2.AutoSize = true;
            this.deviceNumLabel2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.deviceNumLabel2.Location = new System.Drawing.Point(601, 484);
            this.deviceNumLabel2.Name = "deviceNumLabel2";
            this.deviceNumLabel2.Size = new System.Drawing.Size(79, 20);
            this.deviceNumLabel2.TabIndex = 17;
            this.deviceNumLabel2.Text = "冗余盘数量";
            // 
            // dataNumLabel
            // 
            this.dataNumLabel.AutoSize = true;
            this.dataNumLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataNumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataNumLabel.Location = new System.Drawing.Point(188, 155);
            this.dataNumLabel.Name = "dataNumLabel";
            this.dataNumLabel.Size = new System.Drawing.Size(0, 17);
            this.dataNumLabel.TabIndex = 19;
            // 
            // rddtNumLabel
            // 
            this.rddtNumLabel.AutoSize = true;
            this.rddtNumLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rddtNumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rddtNumLabel.Location = new System.Drawing.Point(569, 155);
            this.rddtNumLabel.Name = "rddtNumLabel";
            this.rddtNumLabel.Size = new System.Drawing.Size(0, 17);
            this.rddtNumLabel.TabIndex = 20;
            // 
            // acceptDataBtn
            // 
            this.acceptDataBtn.BackgroundImage = global::Demo.Properties.Resources.appbar_arrow1;
            this.acceptDataBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.acceptDataBtn.Enabled = false;
            this.acceptDataBtn.Location = new System.Drawing.Point(373, 452);
            this.acceptDataBtn.Name = "acceptDataBtn";
            this.acceptDataBtn.Size = new System.Drawing.Size(52, 52);
            this.acceptDataBtn.TabIndex = 21;
            this.acceptDataBtn.UseVisualStyleBackColor = true;
            this.acceptDataBtn.Click += new System.EventHandler(this.acceptDataBtn_Click);
            // 
            // rddtPic
            // 
            this.rddtPic.Image = global::Demo.Properties.Resources.appbar_database;
            this.rddtPic.Location = new System.Drawing.Point(517, 452);
            this.rddtPic.Name = "rddtPic";
            this.rddtPic.Size = new System.Drawing.Size(52, 52);
            this.rddtPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rddtPic.TabIndex = 16;
            this.rddtPic.TabStop = false;
            // 
            // resetDeviceBtn
            // 
            this.resetDeviceBtn.Enabled = false;
            this.resetDeviceBtn.Image = global::Demo.Properties.Resources.appbar_reset;
            this.resetDeviceBtn.Location = new System.Drawing.Point(526, 552);
            this.resetDeviceBtn.Name = "resetDeviceBtn";
            this.resetDeviceBtn.Size = new System.Drawing.Size(64, 64);
            this.resetDeviceBtn.TabIndex = 15;
            this.resetDeviceBtn.UseVisualStyleBackColor = true;
            this.resetDeviceBtn.Click += new System.EventHandler(this.resetDeviceBtn_Click);
            // 
            // faultNRowAcceptBtn
            // 
            this.faultNRowAcceptBtn.BackgroundImage = global::Demo.Properties.Resources.appbar_cabinet_in;
            this.faultNRowAcceptBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.faultNRowAcceptBtn.Location = new System.Drawing.Point(619, 60);
            this.faultNRowAcceptBtn.Name = "faultNRowAcceptBtn";
            this.faultNRowAcceptBtn.Size = new System.Drawing.Size(52, 52);
            this.faultNRowAcceptBtn.TabIndex = 13;
            this.faultNRowAcceptBtn.UseVisualStyleBackColor = true;
            this.faultNRowAcceptBtn.Click += new System.EventHandler(this.faultNRowAcceptBtnAcceptBtn_Click);
            // 
            // dataPic
            // 
            this.dataPic.Image = global::Demo.Properties.Resources.appbar_database;
            this.dataPic.Location = new System.Drawing.Point(113, 452);
            this.dataPic.Name = "dataPic";
            this.dataPic.Size = new System.Drawing.Size(52, 52);
            this.dataPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.dataPic.TabIndex = 5;
            this.dataPic.TabStop = false;
            // 
            // rowPic
            // 
            this.rowPic.Image = global::Demo.Properties.Resources.appbar_cabinet_variant;
            this.rowPic.Location = new System.Drawing.Point(373, 60);
            this.rowPic.Name = "rowPic";
            this.rowPic.Size = new System.Drawing.Size(52, 52);
            this.rowPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rowPic.TabIndex = 4;
            this.rowPic.TabStop = false;
            // 
            // faultPic
            // 
            this.faultPic.Image = global::Demo.Properties.Resources.appbar_warning_circle;
            this.faultPic.Location = new System.Drawing.Point(136, 60);
            this.faultPic.Name = "faultPic";
            this.faultPic.Size = new System.Drawing.Size(52, 52);
            this.faultPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.faultPic.TabIndex = 3;
            this.faultPic.TabStop = false;
            // 
            // AcceptSettingBtn
            // 
            this.AcceptSettingBtn.Enabled = false;
            this.AcceptSettingBtn.Image = global::Demo.Properties.Resources.appbar_check;
            this.AcceptSettingBtn.Location = new System.Drawing.Point(647, 552);
            this.AcceptSettingBtn.Name = "AcceptSettingBtn";
            this.AcceptSettingBtn.Size = new System.Drawing.Size(64, 64);
            this.AcceptSettingBtn.TabIndex = 1;
            this.AcceptSettingBtn.UseVisualStyleBackColor = true;
            this.AcceptSettingBtn.Click += new System.EventHandler(this.AcceptSettingBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(46, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 22;
            this.label3.Text = "数据盘列表 ：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(429, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "冗余盘列表：";
            // 
            // selectAllDataBtn
            // 
            this.selectAllDataBtn.Enabled = false;
            this.selectAllDataBtn.Location = new System.Drawing.Point(50, 414);
            this.selectAllDataBtn.Name = "selectAllDataBtn";
            this.selectAllDataBtn.Size = new System.Drawing.Size(45, 23);
            this.selectAllDataBtn.TabIndex = 24;
            this.selectAllDataBtn.Text = "全选";
            this.selectAllDataBtn.UseVisualStyleBackColor = true;
            this.selectAllDataBtn.Click += new System.EventHandler(this.selectAllDataBtn_Click);
            // 
            // toggleDataBtn
            // 
            this.toggleDataBtn.Enabled = false;
            this.toggleDataBtn.Location = new System.Drawing.Point(101, 414);
            this.toggleDataBtn.Name = "toggleDataBtn";
            this.toggleDataBtn.Size = new System.Drawing.Size(45, 23);
            this.toggleDataBtn.TabIndex = 25;
            this.toggleDataBtn.Text = "反选";
            this.toggleDataBtn.UseVisualStyleBackColor = true;
            this.toggleDataBtn.Click += new System.EventHandler(this.toggleDataBtn_Click);
            // 
            // toggleRddtBtn
            // 
            this.toggleRddtBtn.Enabled = false;
            this.toggleRddtBtn.Location = new System.Drawing.Point(484, 414);
            this.toggleRddtBtn.Name = "toggleRddtBtn";
            this.toggleRddtBtn.Size = new System.Drawing.Size(45, 23);
            this.toggleRddtBtn.TabIndex = 27;
            this.toggleRddtBtn.Text = "反选";
            this.toggleRddtBtn.UseVisualStyleBackColor = true;
            this.toggleRddtBtn.Click += new System.EventHandler(this.toggleRddtBtn_Click);
            // 
            // selectAllRddtBtn
            // 
            this.selectAllRddtBtn.Enabled = false;
            this.selectAllRddtBtn.Location = new System.Drawing.Point(433, 414);
            this.selectAllRddtBtn.Name = "selectAllRddtBtn";
            this.selectAllRddtBtn.Size = new System.Drawing.Size(45, 23);
            this.selectAllRddtBtn.TabIndex = 26;
            this.selectAllRddtBtn.Text = "全选";
            this.selectAllRddtBtn.UseVisualStyleBackColor = true;
            this.selectAllRddtBtn.Click += new System.EventHandler(this.selectAllRddtBtn_Click);
            // 
            // AutoSelectBtn
            // 
            this.AutoSelectBtn.Enabled = false;
            this.AutoSelectBtn.Location = new System.Drawing.Point(152, 414);
            this.AutoSelectBtn.Name = "AutoSelectBtn";
            this.AutoSelectBtn.Size = new System.Drawing.Size(64, 23);
            this.AutoSelectBtn.TabIndex = 28;
            this.AutoSelectBtn.Text = "自动选择";
            this.AutoSelectBtn.UseVisualStyleBackColor = true;
            this.AutoSelectBtn.Click += new System.EventHandler(this.AutoSelectBtn_Click);
            // 
            // InitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 660);
            this.Controls.Add(this.AutoSelectBtn);
            this.Controls.Add(this.toggleRddtBtn);
            this.Controls.Add(this.selectAllRddtBtn);
            this.Controls.Add(this.toggleDataBtn);
            this.Controls.Add(this.selectAllDataBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.acceptDataBtn);
            this.Controls.Add(this.rddtNumLabel);
            this.Controls.Add(this.dataNumLabel);
            this.Controls.Add(this.rddtDeviceNumBox);
            this.Controls.Add(this.deviceNumLabel2);
            this.Controls.Add(this.rddtPic);
            this.Controls.Add(this.resetDeviceBtn);
            this.Controls.Add(this.faultNRowAcceptBtn);
            this.Controls.Add(this.rowNumBox);
            this.Controls.Add(this.faultNumBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deviceNumBox);
            this.Controls.Add(this.deviceNumLabel);
            this.Controls.Add(this.dataPic);
            this.Controls.Add(this.rowPic);
            this.Controls.Add(this.faultPic);
            this.Controls.Add(this.rddtFolderList);
            this.Controls.Add(this.AcceptSettingBtn);
            this.Controls.Add(this.dataFolderList);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devices";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.faultNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddtPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faultPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox dataFolderList;
        private System.Windows.Forms.Button AcceptSettingBtn;
        private System.Windows.Forms.CheckedListBox rddtFolderList;
        private System.Windows.Forms.PictureBox faultPic;
        private System.Windows.Forms.PictureBox rowPic;
        private System.Windows.Forms.PictureBox dataPic;
        private System.Windows.Forms.Label deviceNumLabel;
        private System.Windows.Forms.TextBox deviceNumBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown faultNumBox;
        private System.Windows.Forms.NumericUpDown rowNumBox;
        private System.Windows.Forms.Button faultNRowAcceptBtn;
        private System.Windows.Forms.Button resetDeviceBtn;
        private System.Windows.Forms.TextBox rddtDeviceNumBox;
        private System.Windows.Forms.Label deviceNumLabel2;
        private System.Windows.Forms.PictureBox rddtPic;
        private System.Windows.Forms.Label dataNumLabel;
        private System.Windows.Forms.Label rddtNumLabel;
        private System.Windows.Forms.Button acceptDataBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button selectAllDataBtn;
        private System.Windows.Forms.Button toggleDataBtn;
        private System.Windows.Forms.Button toggleRddtBtn;
        private System.Windows.Forms.Button selectAllRddtBtn;
        private System.Windows.Forms.Button AutoSelectBtn;
    }
}

