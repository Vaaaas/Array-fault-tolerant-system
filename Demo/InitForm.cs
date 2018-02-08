using System;
using System.IO;
using System.Windows.Forms;
using FileHandle;
using File = FileHandle.File;

namespace Demo
{
    public partial class InitForm : Form
    {
        public InitForm()
        {
            InitializeComponent();
            FormClosing += InitForm_FormClosing;
        }

        private static void InitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FolderInfo.FirstInit(dataDeviceList);

            var tooltip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 500,
                ReshowDelay = 500
            };
            tooltip1.SetToolTip(faultNRowAcceptBtn, "确认容错数和阵列行数");
            tooltip1.SetToolTip(acceptDataBtn, "确认数据文件夹选择");
            tooltip1.SetToolTip(resetDeviceBtn, "重新选择");
            tooltip1.SetToolTip(AcceptSettingBtn, "确认设定");
            faultNumBox_ValueChanged(sender, e);
            rowNumBox_ValueChanged(sender, e);
        }

        private void faultNumBox_ValueChanged(object sender, EventArgs e)
        {
            File.Faults = (int) faultNumBox.Value;
        }

        private void rowNumBox_ValueChanged(object sender, EventArgs e)
        {
            File.Rows = (int) rowNumBox.Value;
        }

        private void faultNRowAcceptBtnAcceptBtn_Click(object sender, EventArgs e)
        {
            faultNRowAcceptBtn.Enabled = false;
            faultNumBox.Enabled = false;
            rowNumBox.Enabled = false;

            var dataFolder = File.Rows*File.Faults - File.Faults + 1;
            // ReSharper disable once PossibleLossOfFraction
            var rddtDevice = File.Faults*dataFolder/File.Rows;
            dataNumLabel.Text = "应该选择 " + dataFolder + " 个";
            rddtNumLabel.Text = "应该选择 " + Math.Ceiling(rddtDevice) + " 个";

            FolderInfo.FirstInit(dataFolder + Math.Ceiling(rddtDevice));
            foreach (var folder in Folder.AllFolders)
            {
                dataFolderList.Items.Add(folder.Name);
            }

            selectAllDataBtn.Enabled = true;
            toggleDataBtn.Enabled = true;
            AutoSelectBtn.Enabled = true;
            resetDeviceBtn.Enabled = true;
            dataFolderList.Enabled = true;
            acceptDataBtn.Enabled = true;
        }

        private void dataDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            deviceNumBox.Text = dataFolderList.CheckedItems.Count.ToString();
        }

        private void acceptDataBtn_Click(object sender, EventArgs e)
        {
            var dataDevice = File.Rows*File.Faults - File.Faults + 1;
            if (dataFolderList.CheckedItems.Count < dataDevice)
            {
                MessageBox.Show("应该选择 " + dataDevice + " 个");
                return;
            }
            rddtFolderList.Items.Clear();
            // ReSharper disable once PossibleLossOfFraction
            var rddtDevice = File.Faults*dataFolderList.CheckedItems.Count/File.Rows;
            rddtNumLabel.Text = "应该选择 " + Math.Ceiling(rddtDevice) + " 个";
            if (dataFolderList.Items.Count - dataFolderList.CheckedItems.Count < rddtDevice)
            {
                MessageBox.Show("必须选择更少的数据文件夹");
                return;
            }
            acceptDataBtn.Enabled = false;
            dataFolderList.Enabled = false;

            for (var i = 0; i < dataFolderList.Items.Count;)
            {
                if (dataFolderList.CheckedItems.Contains(dataFolderList.Items[i]))
                {
                    var devicePath = Folder.RootPath + "\\" + dataFolderList.Items[i];
                    for (var j = 0; j < Folder.AllFolders.Count; j++)
                    {
                        if (Folder.AllFolders[j].Path != devicePath) continue;
                        Folder.AllFolders[j].Type = Folder.FolderType.Data;
                        Folder.AllFolders[j].Name = "[" + Folder.AllFolders[j].Type + "]" + Folder.AllFolders[j].Name;
                        Directory.Delete(Folder.AllFolders[j].Path);
                        Folder.AllFolders[j].Path = Folder.RootPath + "\\" + Folder.AllFolders[j].Name;
                        Directory.CreateDirectory(Folder.AllFolders[j].Path);
                        Folder.DataFolders.Add(j);
                        Folder.EmptyFolders.Remove(j);
                        break;
                    }
                    i++;
                }

                else
                {
                    rddtFolderList.Items.Add(dataFolderList.Items[i]);
                    dataFolderList.Items.Remove(dataFolderList.Items[i]);
                }
            }

            selectAllDataBtn.Enabled = false;
            toggleDataBtn.Enabled = false;
            AutoSelectBtn.Enabled = false;
            rddtFolderList.Enabled = true;
            resetDeviceBtn.Enabled = true;
            AcceptSettingBtn.Enabled = true;
            selectAllRddtBtn.Enabled = true;
            toggleRddtBtn.Enabled = true;
        }

        private void rddtDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            rddtDeviceNumBox.Text = rddtFolderList.CheckedItems.Count.ToString();
        }

        private void AcceptSettingBtn_Click(object sender, EventArgs e)
        {
            AcceptSettingBtn.Enabled = false;
            // ReSharper disable once PossibleLossOfFraction
            var expectRddtDevice = File.Faults*dataFolderList.CheckedItems.Count/File.Rows;
            var realRddtDevice = rddtFolderList.CheckedItems.Count;
            if (realRddtDevice < Math.Ceiling(expectRddtDevice))
            {
                MessageBox.Show("冗余文件夹必须多于 " + Math.Ceiling(expectRddtDevice) + " 个");
                resetDeviceBtn.PerformClick();
                return;
            }

            foreach (var itemChecked in rddtFolderList.CheckedItems)
            {
                var rddtDevicePath = itemChecked.ToString();
                for (var i = 0; i < Folder.AllFolders.Count; i++)
                {
                    if (Folder.AllFolders[i].Path != Folder.RootPath + "\\" + rddtDevicePath) continue;
                    Folder.AllFolders[i].Type = Folder.FolderType.Rddt;
                    Folder.AllFolders[i].Name = "[" + Folder.AllFolders[i].Type + "]" + Folder.AllFolders[i].Name;
                    Directory.Delete(Folder.AllFolders[i].Path);
                    Folder.AllFolders[i].Path = Folder.RootPath + "\\" + Folder.AllFolders[i].Name;
                    Directory.CreateDirectory(Folder.AllFolders[i].Path);
                    Folder.RddtFolders.Add(i);
                    Folder.EmptyFolders.Remove(i);
                    break;
                }
            }

            Form workingForm = new WorkingForm();
            workingForm.Show();
            Hide();
        }

        private void resetDeviceBtn_Click(object sender, EventArgs e)
        {
            resetDeviceBtn.Enabled = false;
            Folder.AllFolders.Clear();
            Folder.EmptyFolders.Clear();
            Folder.DataFolders.Clear();
            Folder.RddtFolders.Clear();
            dataFolderList.Items.Clear();
            rddtFolderList.Items.Clear();
            //FolderInfo.FirstInit(dataDeviceList);
            dataNumLabel.Text = " ";
            rddtNumLabel.Text = " ";
            deviceNumBox.Text = "0";
            rddtDeviceNumBox.Text = "0";

            faultNumBox.Enabled = true;
            rowNumBox.Enabled = true;
            faultNRowAcceptBtn.Enabled = true;
            dataFolderList.Enabled = false;
            rddtFolderList.Enabled = false;
            AcceptSettingBtn.Enabled = false;
            selectAllDataBtn.Enabled = false;
            toggleDataBtn.Enabled = false;
            selectAllRddtBtn.Enabled = false;
            toggleRddtBtn.Enabled = false;
        }

        private void selectAllDataBtn_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < dataFolderList.Items.Count; i++)
            {
                dataFolderList.SetItemChecked(i, true);
            }
            deviceNumBox.Text = dataFolderList.CheckedItems.Count.ToString();
        }

        private void toggleDataBtn_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < dataFolderList.Items.Count; i++)
            {
                dataFolderList.SetItemChecked(i, !dataFolderList.GetItemChecked(i));
            }
            deviceNumBox.Text = dataFolderList.CheckedItems.Count.ToString();
        }

        private void selectAllRddtBtn_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < rddtFolderList.Items.Count; i++)
            {
                rddtFolderList.SetItemChecked(i, true);
            }
            rddtDeviceNumBox.Text = rddtFolderList.CheckedItems.Count.ToString();
        }

        private void toggleRddtBtn_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < rddtFolderList.Items.Count; i++)
            {
                rddtFolderList.SetItemChecked(i, !rddtFolderList.GetItemChecked(i));
            }
            rddtDeviceNumBox.Text = rddtFolderList.CheckedItems.Count.ToString();
        }

        private void AutoSelectBtn_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < File.Rows*File.Faults - File.Faults + 1; i++)
            {
                dataFolderList.SetItemChecked(i, true);
            }
            deviceNumBox.Text = dataFolderList.CheckedItems.Count.ToString();
        }
    }
}