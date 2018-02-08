namespace Demo
{
    partial class WorkingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkingForm));
            this.fileToSaveList = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileDialog = new System.Windows.Forms.SaveFileDialog();
            this.inputFileLabel = new System.Windows.Forms.Label();
            this.deleteFileRLabel = new System.Windows.Forms.Label();
            this.outputFileLabel = new System.Windows.Forms.Label();
            this.deleteFileLabel = new System.Windows.Forms.Label();
            this.saveFileLabel = new System.Windows.Forms.Label();
            this.MyStatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BottomStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.BottomDataNumLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BottomRddtNumLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BottomFaultNumLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.recoverBtn = new System.Windows.Forms.Button();
            this.rightPonter = new System.Windows.Forms.PictureBox();
            this.InputBtn = new System.Windows.Forms.Button();
            this.deletFileBtn = new System.Windows.Forms.Button();
            this.deleteChosenFileBtn = new System.Windows.Forms.Button();
            this.outputFileBtn = new System.Windows.Forms.Button();
            this.chooseFileBtn = new System.Windows.Forms.Button();
            this.savedFileListView = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SliceSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.popInfoForm = new System.Windows.Forms.CheckBox();
            this.deviceGridView = new System.Windows.Forms.DataGridView();
            this.MyStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightPonter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // fileToSaveList
            // 
            this.fileToSaveList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileToSaveList.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileToSaveList.FormattingEnabled = true;
            this.fileToSaveList.ItemHeight = 19;
            this.fileToSaveList.Location = new System.Drawing.Point(62, 485);
            this.fileToSaveList.Name = "fileToSaveList";
            this.fileToSaveList.Size = new System.Drawing.Size(430, 173);
            this.fileToSaveList.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // inputFileLabel
            // 
            this.inputFileLabel.AutoSize = true;
            this.inputFileLabel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputFileLabel.Location = new System.Drawing.Point(136, 449);
            this.inputFileLabel.Name = "inputFileLabel";
            this.inputFileLabel.Size = new System.Drawing.Size(61, 19);
            this.inputFileLabel.TabIndex = 11;
            this.inputFileLabel.Text = "选择文件";
            // 
            // deleteFileRLabel
            // 
            this.deleteFileRLabel.AutoSize = true;
            this.deleteFileRLabel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteFileRLabel.Location = new System.Drawing.Point(354, 449);
            this.deleteFileRLabel.Name = "deleteFileRLabel";
            this.deleteFileRLabel.Size = new System.Drawing.Size(61, 19);
            this.deleteFileRLabel.TabIndex = 12;
            this.deleteFileRLabel.Text = "移除文件";
            // 
            // outputFileLabel
            // 
            this.outputFileLabel.AutoSize = true;
            this.outputFileLabel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.outputFileLabel.Location = new System.Drawing.Point(762, 449);
            this.outputFileLabel.Name = "outputFileLabel";
            this.outputFileLabel.Size = new System.Drawing.Size(61, 19);
            this.outputFileLabel.TabIndex = 13;
            this.outputFileLabel.Text = "输出文件";
            // 
            // deleteFileLabel
            // 
            this.deleteFileLabel.AutoSize = true;
            this.deleteFileLabel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteFileLabel.Location = new System.Drawing.Point(977, 449);
            this.deleteFileLabel.Name = "deleteFileLabel";
            this.deleteFileLabel.Size = new System.Drawing.Size(87, 19);
            this.deleteFileLabel.TabIndex = 14;
            this.deleteFileLabel.Text = "从系统中移除";
            // 
            // saveFileLabel
            // 
            this.saveFileLabel.AutoSize = true;
            this.saveFileLabel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveFileLabel.Location = new System.Drawing.Point(558, 617);
            this.saveFileLabel.Name = "saveFileLabel";
            this.saveFileLabel.Size = new System.Drawing.Size(61, 19);
            this.saveFileLabel.TabIndex = 15;
            this.saveFileLabel.Text = "存入系统";
            // 
            // MyStatusStrip
            // 
            this.MyStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStripLabel,
            this.BottomStatusLabel,
            this.ProgressBar,
            this.BottomDataNumLabel,
            this.BottomRddtNumLabel,
            this.BottomFaultNumLabel});
            this.MyStatusStrip.Location = new System.Drawing.Point(0, 675);
            this.MyStatusStrip.Name = "MyStatusStrip";
            this.MyStatusStrip.Size = new System.Drawing.Size(1188, 28);
            this.MyStatusStrip.TabIndex = 16;
            this.MyStatusStrip.Text = "statusStrip1";
            // 
            // StatusStripLabel
            // 
            this.StatusStripLabel.Name = "StatusStripLabel";
            this.StatusStripLabel.Size = new System.Drawing.Size(63, 23);
            this.StatusStripLabel.Text = "当前状态: ";
            // 
            // BottomStatusLabel
            // 
            this.BottomStatusLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BottomStatusLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.BottomStatusLabel.Name = "BottomStatusLabel";
            this.BottomStatusLabel.Size = new System.Drawing.Size(42, 23);
            this.BottomStatusLabel.Text = "待命";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(400, 22);
            // 
            // BottomDataNumLabel
            // 
            this.BottomDataNumLabel.Margin = new System.Windows.Forms.Padding(60, 3, 0, 2);
            this.BottomDataNumLabel.Name = "BottomDataNumLabel";
            this.BottomDataNumLabel.Size = new System.Drawing.Size(80, 23);
            this.BottomDataNumLabel.Text = "数据盘数量：";
            // 
            // BottomRddtNumLabel
            // 
            this.BottomRddtNumLabel.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
            this.BottomRddtNumLabel.Name = "BottomRddtNumLabel";
            this.BottomRddtNumLabel.Size = new System.Drawing.Size(80, 23);
            this.BottomRddtNumLabel.Text = "冗余盘数量：";
            // 
            // BottomFaultNumLabel
            // 
            this.BottomFaultNumLabel.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
            this.BottomFaultNumLabel.Name = "BottomFaultNumLabel";
            this.BottomFaultNumLabel.Size = new System.Drawing.Size(59, 23);
            this.BottomFaultNumLabel.Text = "容错数量:";
            // 
            // recoverBtn
            // 
            this.recoverBtn.BackgroundImage = global::Demo.Properties.Resources.appbar_return;
            this.recoverBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.recoverBtn.Location = new System.Drawing.Point(560, 379);
            this.recoverBtn.Name = "recoverBtn";
            this.recoverBtn.Size = new System.Drawing.Size(64, 64);
            this.recoverBtn.TabIndex = 9;
            this.recoverBtn.UseVisualStyleBackColor = true;
            this.recoverBtn.Click += new System.EventHandler(this.recoverBtn_Click);
            // 
            // rightPonter
            // 
            this.rightPonter.BackgroundImage = global::Demo.Properties.Resources.appbar_arrow_right;
            this.rightPonter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightPonter.Location = new System.Drawing.Point(566, 574);
            this.rightPonter.Name = "rightPonter";
            this.rightPonter.Size = new System.Drawing.Size(40, 40);
            this.rightPonter.TabIndex = 8;
            this.rightPonter.TabStop = false;
            // 
            // InputBtn
            // 
            this.InputBtn.BackgroundImage = global::Demo.Properties.Resources.appbar_save;
            this.InputBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InputBtn.Location = new System.Drawing.Point(560, 523);
            this.InputBtn.Name = "InputBtn";
            this.InputBtn.Size = new System.Drawing.Size(52, 52);
            this.InputBtn.TabIndex = 7;
            this.InputBtn.UseVisualStyleBackColor = true;
            this.InputBtn.Click += new System.EventHandler(this.InputBtn_Click);
            // 
            // deletFileBtn
            // 
            this.deletFileBtn.BackgroundImage = global::Demo.Properties.Resources.appbar_delete;
            this.deletFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deletFileBtn.Location = new System.Drawing.Point(994, 385);
            this.deletFileBtn.Name = "deletFileBtn";
            this.deletFileBtn.Size = new System.Drawing.Size(52, 52);
            this.deletFileBtn.TabIndex = 6;
            this.deletFileBtn.UseVisualStyleBackColor = true;
            this.deletFileBtn.Click += new System.EventHandler(this.deletFileBtn_Click);
            // 
            // deleteChosenFileBtn
            // 
            this.deleteChosenFileBtn.BackgroundImage = global::Demo.Properties.Resources.appbar_delete;
            this.deleteChosenFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteChosenFileBtn.Location = new System.Drawing.Point(356, 385);
            this.deleteChosenFileBtn.Name = "deleteChosenFileBtn";
            this.deleteChosenFileBtn.Size = new System.Drawing.Size(52, 52);
            this.deleteChosenFileBtn.TabIndex = 5;
            this.deleteChosenFileBtn.UseVisualStyleBackColor = true;
            this.deleteChosenFileBtn.Click += new System.EventHandler(this.deleteChosenFileBtn_Click);
            // 
            // outputFileBtn
            // 
            this.outputFileBtn.BackgroundImage = global::Demo.Properties.Resources.appbar_cabinet_out;
            this.outputFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.outputFileBtn.Location = new System.Drawing.Point(765, 385);
            this.outputFileBtn.Name = "outputFileBtn";
            this.outputFileBtn.Size = new System.Drawing.Size(52, 52);
            this.outputFileBtn.TabIndex = 4;
            this.outputFileBtn.UseVisualStyleBackColor = true;
            this.outputFileBtn.Click += new System.EventHandler(this.outputFileBtn_Click);
            // 
            // chooseFileBtn
            // 
            this.chooseFileBtn.BackgroundImage = global::Demo.Properties.Resources.appbar_cabinet_in;
            this.chooseFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chooseFileBtn.Location = new System.Drawing.Point(139, 385);
            this.chooseFileBtn.Margin = new System.Windows.Forms.Padding(0);
            this.chooseFileBtn.Name = "chooseFileBtn";
            this.chooseFileBtn.Size = new System.Drawing.Size(52, 52);
            this.chooseFileBtn.TabIndex = 2;
            this.chooseFileBtn.UseVisualStyleBackColor = true;
            this.chooseFileBtn.Click += new System.EventHandler(this.chooseFileBtn_Click);
            // 
            // savedFileListView
            // 
            this.savedFileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.FileSize,
            this.SliceSize});
            this.savedFileListView.FullRowSelect = true;
            this.savedFileListView.Location = new System.Drawing.Point(674, 485);
            this.savedFileListView.Name = "savedFileListView";
            this.savedFileListView.Size = new System.Drawing.Size(423, 173);
            this.savedFileListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.savedFileListView.TabIndex = 17;
            this.savedFileListView.UseCompatibleStateImageBehavior = false;
            this.savedFileListView.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "文件名";
            this.FileName.Width = 150;
            // 
            // FileSize
            // 
            this.FileSize.Text = "文件大小(Bytes)";
            this.FileSize.Width = 150;
            // 
            // SliceSize
            // 
            this.SliceSize.Text = "分块大小(Bytes)";
            this.SliceSize.Width = 150;
            // 
            // popInfoForm
            // 
            this.popInfoForm.AutoSize = true;
            this.popInfoForm.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.popInfoForm.Checked = true;
            this.popInfoForm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.popInfoForm.Location = new System.Drawing.Point(965, 345);
            this.popInfoForm.Name = "popInfoForm";
            this.popInfoForm.Size = new System.Drawing.Size(132, 16);
            this.popInfoForm.TabIndex = 19;
            this.popInfoForm.Text = "是否弹出信息窗口？";
            this.popInfoForm.UseVisualStyleBackColor = true;
            this.popInfoForm.CheckedChanged += new System.EventHandler(this.popInfoForm_CheckedChanged);
            // 
            // deviceGridView
            // 
            this.deviceGridView.AllowUserToAddRows = false;
            this.deviceGridView.AllowUserToDeleteRows = false;
            this.deviceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deviceGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.deviceGridView.Location = new System.Drawing.Point(62, 28);
            this.deviceGridView.Name = "deviceGridView";
            this.deviceGridView.ReadOnly = true;
            this.deviceGridView.RowTemplate.Height = 23;
            this.deviceGridView.Size = new System.Drawing.Size(1035, 279);
            this.deviceGridView.TabIndex = 20;
            // 
            // WorkingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 703);
            this.Controls.Add(this.deviceGridView);
            this.Controls.Add(this.popInfoForm);
            this.Controls.Add(this.savedFileListView);
            this.Controls.Add(this.MyStatusStrip);
            this.Controls.Add(this.saveFileLabel);
            this.Controls.Add(this.deleteFileLabel);
            this.Controls.Add(this.outputFileLabel);
            this.Controls.Add(this.deleteFileRLabel);
            this.Controls.Add(this.inputFileLabel);
            this.Controls.Add(this.recoverBtn);
            this.Controls.Add(this.rightPonter);
            this.Controls.Add(this.InputBtn);
            this.Controls.Add(this.deletFileBtn);
            this.Controls.Add(this.deleteChosenFileBtn);
            this.Controls.Add(this.outputFileBtn);
            this.Controls.Add(this.chooseFileBtn);
            this.Controls.Add(this.fileToSaveList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WorkingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkingForm";
            this.Load += new System.EventHandler(this.WorkingForm_Load);
            this.MyStatusStrip.ResumeLayout(false);
            this.MyStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightPonter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox fileToSaveList;
        private System.Windows.Forms.Button chooseFileBtn;
        private System.Windows.Forms.Button outputFileBtn;
        private System.Windows.Forms.Button deleteChosenFileBtn;
        private System.Windows.Forms.Button deletFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button InputBtn;
        private System.Windows.Forms.PictureBox rightPonter;
        private System.Windows.Forms.SaveFileDialog fileDialog;
        private System.Windows.Forms.Button recoverBtn;
        private System.Windows.Forms.Label inputFileLabel;
        private System.Windows.Forms.Label deleteFileRLabel;
        private System.Windows.Forms.Label outputFileLabel;
        private System.Windows.Forms.Label deleteFileLabel;
        private System.Windows.Forms.Label saveFileLabel;
        private System.Windows.Forms.StatusStrip MyStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripLabel;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel BottomDataNumLabel;
        private System.Windows.Forms.ToolStripStatusLabel BottomRddtNumLabel;
        private System.Windows.Forms.ToolStripStatusLabel BottomStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel BottomFaultNumLabel;
        private System.Windows.Forms.ListView savedFileListView;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader FileSize;
        private System.Windows.Forms.ColumnHeader SliceSize;
        private System.Windows.Forms.CheckBox popInfoForm;
        public System.Windows.Forms.DataGridView deviceGridView;
    }
}