using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FileHandle
{
    public static class FormFunction
    {
        public static void EnableToggle(Button inputFileBtn, Button deleteTempFileBtn, Button outputBtn,
            Button deleteFileBtn, Button saveFileBtn, Button recoverBtn)
        {
            inputFileBtn.Enabled = !inputFileBtn.Enabled;
            deleteTempFileBtn.Enabled = !deleteTempFileBtn.Enabled;
            outputBtn.Enabled = !outputBtn.Enabled;
            deleteFileBtn.Enabled = !deleteFileBtn.Enabled;
            saveFileBtn.Enabled = !saveFileBtn.Enabled;
            recoverBtn.Enabled = !recoverBtn.Enabled;
        }

        public static Stream OpenDialog(SaveFileDialog dialog, string name, string extension)
        {
            dialog.OverwritePrompt = true;
            dialog.FileName = name;
            dialog.DefaultExt = extension;
            dialog.Filter = "All Files | *.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var fileStream = dialog.OpenFile();
                return fileStream;
            }
            //MessageBox.Show("请选择一个路径");
            return dialog.OpenFile();
        }

        public static void AddDeviceWatcher(ToolStripStatusLabel dataNum, ToolStripStatusLabel rddtNum, ToolStripStatusLabel faultNum)
        {
            dataNum.Text = "数据盘数量： " + Folder.DataFolders.Count;
            rddtNum.Text = "冗余盘数量： " + Folder.RddtFolders.Count;
            faultNum.Text = "容错数量： " + File.Faults;
            
        }
    }
}