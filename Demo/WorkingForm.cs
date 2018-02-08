using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FileHandle;
using File = FileHandle.File;

namespace Demo
{
    public partial class WorkingForm : Form
    {
        private static Stopwatch sw = new Stopwatch();

        public WorkingForm()
        {
            InitializeComponent();
            FormClosing += WorkingForm_FormClosing;
        }

        private static void WorkingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void StartWatch()
        {
            var folderWatcher = new FileSystemWatcher();
            folderWatcher.Path = Folder.RootPath;
            folderWatcher.IncludeSubdirectories = true;
            folderWatcher.Deleted += OnProgress;
            folderWatcher.EnableRaisingEvents = true;
        }

        private void OnProgress(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                OnDeleted(source, e);
            }
        }

        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            Console.WriteLine(e.FullPath);
            var isSliceFolder = Folder.AllFolders.Any(folder => folder.Path == e.FullPath);

            if (isSliceFolder)
            {
                BottomStatusLabel.Text = "请稍候 ...";
                BottomStatusLabel.ForeColor = Color.FromArgb(231, 27, 27);
                FolderInfo.LostDeviceHandle(e.FullPath, deviceGridView);
                //MessageBox.Show("Lost Device");
                BottomStatusLabel.ForeColor = Color.Orange;
                BottomStatusLabel.Text = "可恢复";
                recoverBtn.Enabled = true;
            }
        }

        private void WorkingForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            StartWatch();
            FormFunction.AddDeviceWatcher(BottomDataNumLabel, BottomRddtNumLabel, BottomFaultNumLabel);
            deviceGridView.ColumnCount = 3;
            deviceGridView.Columns[0].Name = "节点名称";
            deviceGridView.Columns[1].Name = "节点类型";
            deviceGridView.Columns[2].Name = "节点状态";
            deviceGridView.Columns[2].DefaultCellStyle.ForeColor = Color.Red;
        }

        private void UpdateButton()
        {
            if (Folder.LostFolders.Count <= 0)
            {
                BottomStatusLabel.ForeColor = Color.LimeGreen;
                BottomStatusLabel.Text = "待命";
                EnableBtn();
            }
            else if (Folder.LostFolders.Count <= File.Faults)
            {
                BottomStatusLabel.ForeColor = Color.Orange;
                BottomStatusLabel.Text = "可恢复";
                EnableBtn();
                recoverBtn.Enabled = true;
            }
            else
            {
                BottomStatusLabel.ForeColor = Color.FromArgb(231, 27, 27);
                BottomStatusLabel.Text = "无法继续运行";
                DisableBtn();
            }
        }

        private void DisableBtn()
        {
            chooseFileBtn.Enabled = false;
            deletFileBtn.Enabled = false;
            deleteChosenFileBtn.Enabled = false;
            outputFileBtn.Enabled = false;
            InputBtn.Enabled = false;
            recoverBtn.Enabled = false;
        }

        private void EnableBtn()
        {
            chooseFileBtn.Enabled = true;
            deletFileBtn.Enabled = true;
            deleteChosenFileBtn.Enabled = true;
            outputFileBtn.Enabled = true;
            InputBtn.Enabled = true;
            recoverBtn.Enabled = true;
        }

        private void SetMax(int maxValue)
        {
            ProgressBar.Value = 0;
            ProgressBar.Maximum = maxValue;
        }

        private void SetNow(int nowValue)
        {
            ProgressBar.Value = nowValue;
        }

        private void SetZero()
        {
            DisableBtn();
            if (Folder.LostFolders.Count == 0)
            {
                BottomStatusLabel.ForeColor = Color.LimeGreen;
                BottomStatusLabel.Text = "待命";
            }
            ProgressBar.Value = 0;
            UpdateButton();
        }

        private void method_threadStartEvent(object sender, EventArgs e)
        {
            var maxValue = Convert.ToInt32(sender);
            MaxValueDelegate max = SetMax;
            BeginInvoke(max, maxValue);
        }

        private void method_threadEvent(object sender, EventArgs e)
        {
            var nowValue = Convert.ToInt32(sender);
            NowValueDelegate now = SetNow;
            BeginInvoke(now, nowValue);
        }

        private void method_threadEndEvent(object sender, EventArgs e)
        {
            ZeroValueDelegate zero = SetZero;
            BeginInvoke(zero);
        }

        private void chooseFileBtn_Click(object sender, EventArgs e)
        {
            BottomStatusLabel.Text = "选择文件 ...";
            BottomStatusLabel.ForeColor = Color.FromArgb(231, 27, 27);
            DisableBtn();

            var fileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "All Files | *.*",
                FilterIndex = 1,
                RestoreDirectory = false,
                Multiselect = true
            };

            var dr = fileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (var file in fileDialog1.FileNames)
                {
                    var thisFile = new FileInfo(file);
                    var newFile = new File(thisFile.Name, thisFile.Length, thisFile.FullName);
                    File.FilesToSave.Add(newFile);
                    if (!thisFile.Exists)
                    {
                        throw new FileNotFoundException("未找到: " + file);
                    }
                    fileToSaveList.Items.Add(thisFile.Name);
                }
            }
            EnableBtn();
            UpdateButton();
        }

        private void InputBtn_Click(object sender, EventArgs e)
        {
            DisableBtn();
            if (File.FilesToSave.Count == 0 || fileToSaveList.Items.Count == 0)
            {
                MessageBox.Show("未选取文件");
                EnableBtn();
                return;
            }
            BottomStatusLabel.Text = "请稍候 ...";
            BottomStatusLabel.ForeColor = Color.FromArgb(231, 27, 27);
            var saveDataThread = new Thread(InputThreadFunc);
            saveDataThread.Start();
        }

        private void InputThreadFunc()
        {
            try
            {
                long rddtTime = 0;
                sw = new Stopwatch();
                sw.Start();
                double fullSize = 0;
                double rddtSize = 0;
                var fileToSaveNum = File.FilesToSave.Count;
                ProgressBar.Maximum = File.FilesToSave.Count*2;
                var tempFileList = new List<File>();
                foreach (var file in File.FilesToSave)
                {
                    tempFileList.Add(file);
                }
                foreach (var file in tempFileList)
                {
                    fullSize += file.SliceSize*file.Slices;
                    rddtSize += file.SliceSize*Folder.RddtFolders.Count*File.Rows;
                    file.DataFileInit();
                    ProgressBar.Value++;
                    var rddtStopwatch = new Stopwatch();
                    rddtStopwatch.Start();
                    file.RddtFileInit();
                    rddtStopwatch.Stop();
                    rddtTime += rddtStopwatch.ElapsedMilliseconds;
                    ProgressBar.Value++;
                }
                savedFileListView.BeginUpdate();
                foreach (var file in File.FilesToSave)
                {
                    File.SavedFiles.Add(file);
                    //savedFileList.Items.Add(file.FullName);
                    var item = new ListViewItem();
                    item.Text = file.FullName;
                    item.SubItems.Add(file.Size.ToString());
                    item.SubItems.Add(file.SliceSize.ToString());
                    savedFileListView.Items.Add(item);
                }

                savedFileListView.EndUpdate();
                File.FilesToSave.Clear();
                fileToSaveList.Items.Clear();
                if (Folder.LostFolders.Count > 0)
                {
                    for (var i = 0; i < Folder.LostFolders.Count; i++)
                    {
                        var lostIndex = Folder.LostFolders[i];
                        var di = new DirectoryInfo(Folder.IndexToDevice(lostIndex).Path);
                        di.Delete(true);
                    }
                }
                UpdateButton();
                sw.Stop();
                File.FuncInfo.Clear();
                File.FuncInfo.Add("本次存入 " + fileToSaveNum + " 个文件\r\n");
                File.FuncInfo.Add("源文件总大小为：" + fullSize + " bytes\r\n");
                File.FuncInfo.Add("生成的冗余文件总大小为：" + rddtSize + " bytes\r\n");
                File.FuncInfo.Add("本次存储用时为： " + sw.ElapsedMilliseconds + " 毫秒\r\n");
                File.FuncInfo.Add("本次计算用时为： " + rddtTime + " 毫秒\r\n");

                ProgressBar.Value = 0;

                var t = new Thread(ExecCreate);
                t.IsBackground = true;
                t.Start();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("出错" + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("出错" + ex.Message);
            }
        }

        private void deleteChosenFileBtn_Click(object sender, EventArgs e)
        {
            BottomStatusLabel.Text = "请稍候 ...";
            BottomStatusLabel.ForeColor = Color.FromArgb(231, 27, 27);
            DisableBtn();
            if (fileToSaveList.SelectedItems.Count == 0)
            {
                //MessageBox.Show("请至少选择一个文件");
                EnableBtn();
                return;
            }
            var fileName = fileToSaveList.SelectedItem.ToString();
            if (
                MessageBox.Show("确定要删除 " + fileName + " ?", "确认", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
            {
                File.FilesToSave.Remove(
                    File.FilesToSave.Find(finder => finder.FullName == fileName));
                fileToSaveList.Items.RemoveAt(fileToSaveList.SelectedIndex);
            }
            UpdateButton();
        }

        private void outputFileBtn_Click(object sender, EventArgs e)
        {
            DisableBtn();
            if (savedFileListView.SelectedItems.Count == 0)
            {
                UpdateButton();
                //MessageBox.Show("请至少选择一个文件");
                return;
            }
            sw = new Stopwatch();
            sw.Start();
            BottomStatusLabel.Text = "请稍候 ...";
            BottomStatusLabel.ForeColor = Color.FromArgb(231, 27, 27);
            var fileName = savedFileListView.SelectedItems[0].Text;
            var targetFile =
                new File(File.SavedFiles.Find(finder => finder.FullName == fileName));
            var saveFileDialog1 = new SaveFileDialog();
            targetFile.OutputStream = FormFunction.OpenDialog(saveFileDialog1, targetFile.Name, targetFile.Extension);

            if (Folder.LostFolders.Count > 0 && targetFile.Size > 1000)
            {
                for (var i = 0; i < Folder.LostFolders.Count; i++)
                {
                    var lostIndex = Folder.LostFolders[i];
                    Directory.CreateDirectory(Folder.IndexToDevice(lostIndex).Path);
                }

                bool recFinish;
                do
                {
                    recFinish = true;
                    foreach (var index in Folder.LostFolders)
                    {
                        var result = Folder.IndexToDevice(index).DetectDevice(targetFile);
                        recFinish = recFinish && result;
                    }
                } while (recFinish == false);
                targetFile.RddtFileInit();
            }

            File.ThreadStartEvent += method_threadStartEvent;
            File.ThreadEvent += method_threadEvent;
            File.ThreadEndEvent += method_threadEndEvent;

            var outputFileThread = new Thread(targetFile.OutputFile);
            outputFileThread.Start();
            outputFileThread.Join();
            sw.Stop();
            File.FuncInfo.Clear();
            File.FuncInfo.Add("源文件大小为：" + targetFile.Size + " bytes\r\n");
            File.FuncInfo.Add("本次输出用时为：" + sw.ElapsedMilliseconds + " 毫秒\r\n");
            var t = new Thread(ExecCreate);
            t.IsBackground = true;
            t.Start();
        }

        private void deletFileBtn_Click(object sender, EventArgs e)
        {
            BottomStatusLabel.Text = "请稍候 ...";
            BottomStatusLabel.ForeColor = Color.FromArgb(231, 27, 27);
            DisableBtn();
            if (savedFileListView.SelectedItems.Count == 0)
            {
                //MessageBox.Show("请至少选择一个文件");
                EnableBtn();
                return;
            }
            var fileName = savedFileListView.SelectedItems[0].Text;
            var targetFile =
                new File(File.SavedFiles.Find(finder => finder.FullName == fileName));
            var deleteRddtThread = new Thread(targetFile.DeleteRddtFile);
            deleteRddtThread.Start();
            deleteRddtThread.Join();
            var deleteDataThread = new Thread(targetFile.DeleteDataFile);
            deleteDataThread.Start();
            deleteDataThread.Join();
            savedFileListView.Items.RemoveAt(savedFileListView.SelectedItems[0].Index);
            File.SavedFiles.Remove(targetFile);
            UpdateButton();
        }

        private void recoverBtn_Click(object sender, EventArgs e)
        {
            DisableBtn();
            BottomStatusLabel.Text = "请稍候 ...";
            BottomStatusLabel.ForeColor = Color.FromArgb(231, 27, 27);
            if (Folder.LostFolders.Count <= 0)
            {
                MessageBox.Show("当前工作正常，不需要恢复");
                BottomStatusLabel.ForeColor = Color.LimeGreen;
                BottomStatusLabel.Text = "待命";
                UpdateButton();
            }

            else if (Folder.LostFolders.Count > File.Faults)
            {
                MessageBox.Show("丢失设备数量超过上限");
                BottomStatusLabel.ForeColor = Color.FromArgb(231, 27, 27);
                BottomStatusLabel.Text = "请重新启动系统";
                DisableBtn();
            }
            else
            {
                sw = new Stopwatch();
                sw.Start();
                var lostNum = Folder.LostFolders.Count;
                File.ThreadStartEvent += method_threadStartEvent;
                File.ThreadEvent += method_threadEvent;
                File.ThreadEndEvent += method_threadEndEvent;
                var recoverThread = new Thread(File.LostHandle);
                recoverThread.Start();
                recoverThread.Join();

                recoverBtn.Enabled = false;

                sw.Stop();
                File.FuncInfo.Clear();
                long fullSize = 0;
                var fileCount = (int) (File.SavedFiles.Count*lostNum*File.Rows);
                for (var i = 0; i < File.SavedFiles.Count; i++)
                {
                    fullSize += File.SavedFiles[i].SliceSize*lostNum;
                }
                int nRows = deviceGridView.Rows.Count;
                for (int k = 0; k < nRows; k++)
                {
                    deviceGridView[2, k].Style.ForeColor = Color.Green;
                    deviceGridView[2, k].Value = "已恢复";
                }
                File.FuncInfo.Add("本次生成文件大小为：" + fullSize + " bytes\r\n");
                File.FuncInfo.Add("本次生成 " + fileCount + " 个文件\r\n");
                File.FuncInfo.Add("本次系统恢复用时为：" + sw.ElapsedMilliseconds + " 毫秒\r\n");
                var t = new Thread(ExecCreate);
                t.IsBackground = true;
                t.Start();
            }
        }

        private void ExecCreate()
        {
            if (popInfoForm.Checked)
            {
                MethodInvoker mi = OpenInfoForm;
                BeginInvoke(mi);
            }
        }

        private static void OpenInfoForm()
        {
            Form infoForm = new InfoOutput();
            infoForm.Show();
        }

        private void popInfoForm_CheckedChanged(object sender, EventArgs e)
        {
        }

        private delegate void MaxValueDelegate(int maxValue);

        private delegate void NowValueDelegate(int nowValue);

        private delegate void ZeroValueDelegate();
    }
}