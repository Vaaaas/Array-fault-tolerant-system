using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace FileHandle
{
    public class Folder
    {
        public enum FolderType : byte
        {
            None,
            Data,
            Rddt
        }

        public static string RootPath;
        public static string FolderName;

        public static List<Folder> AllFolders = new List<Folder>();

        public static List<int> DataFolders = new List<int>();
        public static List<int> RddtFolders = new List<int>();
        public static List<int> LostFolders = new List<int>();
        public static List<int> EmptyFolders = new List<int>();

        public Folder()
        {
            Name = "";
            Path = "";
            Type = FolderType.None;
            Status = false;
        }

        public Folder(string name, string path)
        {
            Name = name;
            Path = path;
            Type = FolderType.None;
            Status = true;
        }

        public string Name { get; set; }

        public string Path { get; set; }

        public FolderType Type { get; set; }

        public bool Status { get; set; }

        public static int GetIndexInAll(Folder device)
        {
            return AllFolders.FindIndex(obj => obj.Name == device.Name);
        }

        public static Folder IndexToDevice(int index)
        {
            return AllFolders[index];
        }

        public bool DetectDevice(File file)
        {
            if (Type == FolderType.Data)
            {
                var allExist = false;
                for (var faultCount = 0; faultCount < File.Faults; faultCount++)
                {
                    if (allExist)
                    {
                        break;
                    }
                    allExist = true;
                    for (var rowCount = 0; rowCount < File.Rows; rowCount++)
                    {
                        var result = file.DetectDataFile(this, faultCount, rowCount);
                        allExist = allExist && result;
                    }
                }
                return allExist;
            }
            if (Type == FolderType.Rddt)
            {
                var allExist = false;
                var indexInAll = AllFolders.FindIndex(obj => obj.Name == Name);
                //Rddt节点 在 所有Rddt节点列表 中的索引
                var rddtNum = RddtFolders.FindIndex(obj => obj == indexInAll);
                var deviceCount = rddtNum*File.Rows%DataFolders.Count;
                int fCount = (int)(rddtNum*File.Rows/DataFolders.Count);
                // ReSharper disable once PossibleLossOfFraction
                int k = (int) ((fCount + 2)/2*Math.Pow(-1, fCount + 2));
                for (var rowCount = 0; rowCount < File.Rows; rowCount++)
                {
                    allExist = true;
                    var result = file.DetectRddtFile(this, k, (int) deviceCount);
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    allExist = allExist && result;
                    if (deviceCount == DataFolders.Count - 1)
                    {
                        deviceCount = 0;
                        fCount++;
                        // ReSharper disable once PossibleLossOfFraction
                        k = (int) ((fCount + 2)/2*Math.Pow(-1, fCount + 2));
                    }
                    else
                    {
                        deviceCount++;
                    }
                }
                return allExist;
            }
            MessageBox.Show("Folder Type ERROR");
            return false;
        }
    }

    public static class FolderInfo
    {
        private static void ClearFolder(string path)
        {
            path = path.Trim();
            if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }
            Directory.CreateDirectory(path);
        }

        private static string InitFolder(string path)
        {
            var device = new Folder(Folder.FolderName + "." + Folder.AllFolders.Count, path);
            ClearFolder(path);
            return device.Name;
        }

        public static void FirstInit(double FoldersNum)
        {
            for (var i = 0; i < FoldersNum; i++)
            {
                if (Directory.Exists(Folder.RootPath + "\\" + Folder.FolderName + "." + i))
                {
                    Directory.Delete(Folder.RootPath + "\\" + Folder.FolderName + "." + i);
                }
                Directory.CreateDirectory(Folder.RootPath + "\\" + Folder.FolderName + "." + i);
                InitFolder(Folder.RootPath + "\\" + Folder.FolderName + "." + i);
                var folder = new Folder(Folder.FolderName + "." + i,
                    Folder.RootPath + "\\" + Folder.FolderName + "." + i);
                Folder.AllFolders.Add(folder);
                Folder.EmptyFolders.Add(Folder.AllFolders.Count - 1);
            }
        }

        private static object obj = new object();

        private delegate void ChangeFunction(DataGridView dgv, string[] row);

        private static void addRow(DataGridView dgv, string[] row)
        {
            DataGridViewRowCollection rows = dgv.Rows;
            rows.Add(row);
        }

        public static void LostDeviceHandle(string folderPath, DataGridView gridView)
        {
            for (var i = 0; i < Folder.AllFolders.Count; i++)
            {
                if (Folder.AllFolders[i].Path == folderPath)
                {
                    Folder.AllFolders[i].Status = false;
                    if (Folder.AllFolders[i].Type != Folder.FolderType.None)
                    {
                        if (!Folder.LostFolders.Contains(i))
                        {
                            Folder.LostFolders.Add(i);
                            int nRows = gridView.Rows.Count;

                            if (nRows > 0)
                            {
                                bool bFound = false;
                                for (int k = 0; k < nRows; k++)
                                {
                                    if (Folder.AllFolders[i].Name == gridView.Rows[k].Cells[0].Value.ToString())
                                    {
                                        gridView.CurrentCell = gridView[0, k];
                                        gridView[2, k].Style.ForeColor = Color.Red;
                                        gridView[2, k].Value = "丢失";
                                        bFound = true;
                                        break;
                                    }
                                }
                                if (!bFound)
                                {
                                    if (gridView.InvokeRequired)
                                    {
                                        string[] row =
                                            {Folder.AllFolders[i].Name, Folder.AllFolders[i].Type.ToString(), "丢失"};

                                        ChangeFunction max = addRow;
                                        gridView.Invoke(max, new object[] {gridView, row });
                                        //MessageBox.Show("ss");
                                    }
                                    else
                                    {
                                        string[] row =
                                            {Folder.AllFolders[i].Name, Folder.AllFolders[i].Type.ToString(), "丢失"};
                                        DataGridViewRowCollection rows = gridView.Rows;
                                        rows.Add(row);
                                    }


                                }

                            }
                            else
                            {
                                if (gridView.InvokeRequired)
                                {
                                    string[] row =
                                        {Folder.AllFolders[i].Name, Folder.AllFolders[i].Type.ToString(), "丢失"};

                                    ChangeFunction max = addRow;
                                    gridView.Invoke(max, new object[] { gridView, row });
                                    //MessageBox.Show("ss");
                                }
                                else
                                {
                                    string[] row =
                                        {Folder.AllFolders[i].Name, Folder.AllFolders[i].Type.ToString(), "丢失"};
                                    DataGridViewRowCollection rows = gridView.Rows;
                                    rows.Add(row);
                                }
                            }
                        }
                    }
                    else
                    {
                        //Remove DeviceCtrl
                        Folder.EmptyFolders.Remove(i);
                    }
                }
            }
            if (Folder.LostFolders.Count > File.Faults)
            {
                MessageBox.Show("丢失分区文件夹数量超过上限");
            }
        }
    }
}