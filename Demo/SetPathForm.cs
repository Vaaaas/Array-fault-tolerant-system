using System;
using System.IO;
using System.Windows.Forms;
using FileHandle;

namespace Demo
{
    public partial class SetPathForm : Form
    {
        public SetPathForm()
        {
            InitializeComponent();
            FormClosing += SetPathForm_FormClosing;
        }

        private void DisableBtns()
        {
            BrowseBtn.Enabled = false;
            ClearBtn.Enabled = false;
            AcceptBtn.Enabled = false;
        }

        private void EnableBtns()
        {
            BrowseBtn.Enabled = true;
            ClearBtn.Enabled = true;
            AcceptBtn.Enabled = true;
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            DisableBtns();

            var result = RootPathDial.ShowDialog();
            if (result == DialogResult.OK)
            {
                var folderName = RootPathDial.SelectedPath;
                RootPathText.Text = folderName;
            }

            EnableBtns();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            RootPathText.Text = "";
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(RootPathText.Text))
            {
                Directory.CreateDirectory(RootPathText.Text);
            }
            if (FolderNameText.Text != null)
            {
                if (
                    MessageBox.Show(
                        "确定要将 " + RootPathText.Text + " 设为系统根目录?（如果文件夹存在将删除其中所有内容）", "确认",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Folder.RootPath = RootPathText.Text;
                    Folder.FolderName = FolderNameText.Text;

                    if (Directory.Exists(Folder.RootPath))
                    {
                        try
                        {
                            //Directory.Delete(Folder.RootPath);
                            var di = new DirectoryInfo(Folder.RootPath);
                            di.Delete(true);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Directory.CreateDirectory(Folder.RootPath);
                    }
                    else
                    {
                        Directory.CreateDirectory(Folder.RootPath);
                    }

                    Form initForm = new InitForm();
                    initForm.Show();
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("请输入有效的子文件夹名称");
            }
        }

        private void FolderNameText_TextChanged(object sender, EventArgs e)
        {
            var isValid = !string.IsNullOrEmpty(FolderNameText.Text);
            AcceptBtn.Enabled = isValid;
            //string[] errorStr = new string[] { "/", "\\", ":", ",", "*", "?", "\"", "<", ">", "|" };
            //else
            //{
            //    for (int i = 0; i < errorStr.Length; i++)
            //    {
            //        if (FolderNameText.Text.Contains("errorStr[i]"))
            //        {
            //            isValid = false;
            //            break;
            //        }
            //    }
            //}
            //errLabel.Visible = !isValid;
        }

        private void SetPathForm_Load(object sender, EventArgs e)
        {
            FolderNameText_TextChanged(sender, e);
        }

        private static void SetPathForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}