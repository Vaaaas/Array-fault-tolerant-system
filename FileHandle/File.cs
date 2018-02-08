using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace FileHandle
{
    public class File
    {
        public static List<File> SavedFiles = new List<File>();
        public static List<File> FilesToSave = new List<File>();
        public static List<string> FuncInfo = new List<string>();

        public File()
        {
            Name = "";
            Extension = "";
            FullName = "";
            SourcePath = "";
            Size = 0;
            Slices = 0;
            FillLast = false;
            FillSpace = 0;
            SliceSize = 0;
        }

        public File(File file)
        {
            Name = file.Name;
            Extension = file.Extension;
            FullName = file.FullName;
            SourcePath = file.SourcePath;
            Size = file.Size;
            Slices = file.Slices;
            FillLast = file.FillLast;
            FillSpace = file.FillSpace;
            SliceSize = file.SliceSize;
        }

        public File(string fullName, long size, string path)
        {
            FullName = fullName;
            Name = FileInfo.GetPureName(fullName);
            Extension = FileInfo.GetExtension(fullName);
            Size = size;
            SourcePath = path;
            Slices = GetSlices();

            if (Size <= 1000)
            {
                FillLast = false;
                SliceSize = Size;
                FillSpace = 0;
            }
            else
            {
                if (Size % Slices == 0)
                {
                    FillLast = false;
                    SliceSize = Size / Slices;
                    FillSpace = 0;
                }
                else
                {
                    FillLast = true;
                    SliceSize = Size / Slices + 1;
                    FillSpace = (int) (SliceSize * Slices - Size);
                }
            }
        }

        public static int Faults { get; set; }

        public static float Rows { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string FullName { get; }

        private string SourcePath { get; }

        public long Size { get; }

        public int Slices { get; }

        private bool FillLast { get; }

        private int FillSpace { get; }

        public long SliceSize { get; }

        public Stream OutputStream { private get; set; }
        public static event EventHandler ThreadStartEvent;
        public static event EventHandler ThreadEvent;
        public static event EventHandler ThreadEndEvent;


        private int GetSlices()
        {
            return Folder.DataFolders.Count*(int) Rows;
        }

        public void DataFileInit()
        {
            var deviceNumbers = Folder.DataFolders.Count;
            if (Size <= 1000)
            {
                for (var i = 0; i < deviceNumbers; i++)
                {
                    if (!Directory.Exists(Folder.IndexToDevice(Folder.DataFolders[i]).Path))
                    {
                        Directory.CreateDirectory(Folder.IndexToDevice(Folder.DataFolders[i]).Path);
                    }
                    var fileStrWrite =
                        new FileStream(
                            Folder.IndexToDevice(Folder.DataFolders[i]).Path + "\\" + Name + "." + i + 0 + ".data",
                            FileMode.Create);
                    var fileWrite = new BinaryWriter(fileStrWrite);
                    var tempBytes = System.IO.File.ReadAllBytes(SourcePath);
                    foreach (var bytes in tempBytes)
                    {
                        fileWrite.Write(bytes);
                    }
                    fileWrite.Close();
                    fileStrWrite.Close();
                }
            }
            else
            {
                var fileStrRead = new FileStream(SourcePath, FileMode.Open);
                var fileRead = new BinaryReader(fileStrRead);
                for (var i = 0; i < Rows; i++)
                {
                    for (var j = 0; j < deviceNumbers; j++)
                    {
                        InitOneDataFile(j, i, deviceNumbers, fileRead);
                        //MediaTypeNames.Application.DoEvents();
                    }
                }
                fileRead.Close();
                fileStrRead.Close();
            }
        }

        private void BackupDataFile()
        {
            for (var i = 0; i < Folder.RddtFolders.Count; i++)
            {
                if (!Directory.Exists(Folder.IndexToDevice(Folder.RddtFolders[i]).Path))
                {
                    Directory.CreateDirectory(Folder.IndexToDevice(Folder.RddtFolders[i]).Path);
                }
                var rddtFile =
                    new FileStream(
                        Folder.IndexToDevice(Folder.RddtFolders[i]).Path + "\\" + Name + "." + i + 0 + ".rddt",
                        FileMode.OpenOrCreate);
                var rddtWriter = new BinaryWriter(rddtFile);
                var tempBytes =
                    System.IO.File.ReadAllBytes(Folder.IndexToDevice(Folder.DataFolders[0]).Path + "\\" + Name + "." +
                                                0 + 0 + ".data");
                foreach (var bytes in tempBytes)
                {
                    rddtWriter.Write(bytes);
                }
                rddtWriter.Close();
                rddtFile.Close();
            }
        }

        private void InitOneDataFile(int j, int i, int deviceNumbers, BinaryReader fileRead)
        {
            try
            {
                //检查该数据文件所在文件夹是否存在
                if (!Directory.Exists(Folder.IndexToDevice(Folder.DataFolders[j]).Path))
                {
                    //不存在则新建文件夹
                    Directory.CreateDirectory(Folder.IndexToDevice(Folder.DataFolders[j]).Path);
                }
                //初始化用于写入数据分快的 FileStream
                var fileStrWrite =
                    new FileStream(
                        Folder.IndexToDevice(Folder.DataFolders[j]).Path + "\\" + Name + "." + j + i + ".data",
                        FileMode.Create);
                var fileWrite = new BinaryWriter(fileStrWrite);

                //此处应该判断哪一个分块是原数据文件的结尾，那么该分块仍需要读取文件，剩下的分块就只需要填充
                var fillSliceCount = (int)(FillSpace / SliceSize) + 1;

                if (FillLast && i * deviceNumbers + j  == Slices - fillSliceCount)
                {
                    if ((int)Size % (int)SliceSize == 0)
                    {
                        for (var k = 0; k < SliceSize; k++)
                        {
                            fileWrite.Write((byte)0);
                        }
                    }
                    else
                    {
                        var readBytes = fileRead.ReadBytes((int)Size % (int)SliceSize);

                        foreach (var preByte in readBytes)
                        {
                            fileWrite.Write(preByte);
                        }
                        for (var k = 0; k < SliceSize - readBytes.Length; k++)
                        {
                            fileWrite.Write((byte)0);
                        }
                    }
                }else if (FillLast && FillLast && i * deviceNumbers + j + 1 > Slices - fillSliceCount)
                {
                    for (var k = 0; k < SliceSize; k++)
                    {
                        fileWrite.Write((byte) 0);
                    }
                }
                else
                {
                    var readBytes = fileRead.ReadBytes((int)SliceSize);
                    foreach (var preByte in readBytes)
                    {
                        fileWrite.Write(preByte);
                    }
                }
                fileWrite.Close();
                fileStrWrite.Close();
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

        public void RddtFileInit()
        {
            if (Size <= 1000)
            {
                BackupDataFile();
            }
            else
            {
                var rddtDeviceCounter = 0;
                var rddtFileCounter = 0;

                for (var faultCount = 0; faultCount < Faults; faultCount++)
                {
                    // ReSharper disable once PossibleLossOfFraction
                    int k = (int) ((faultCount + 2)/2*Math.Pow(-1, faultCount + 2));
                    for (var i = 0; i < Folder.DataFolders.Count; i++)
                    {
                        if (rddtFileCounter%Rows == 0 && (i != 0 || faultCount != 0))
                        {
                            rddtFileCounter = 1;
                            rddtDeviceCounter++;
                        }
                        else
                        {
                            rddtFileCounter++;
                        }
                        InitOneRddtFile(i, k, rddtDeviceCounter);
                        //MediaTypeNames.Application.DoEvents();
                    }
                }
            }
        }

        private void InitOneRddtFile(int startDeviceNum, int k, int rddtNum)
        {
            try
            {
                if (!Directory.Exists(Folder.IndexToDevice(Folder.RddtFolders[rddtNum]).Path))
                {
                    Directory.CreateDirectory(Folder.IndexToDevice(Folder.RddtFolders[rddtNum]).Path);
                }
                var rddtFile =
                    new FileStream(
                        Folder.IndexToDevice(Folder.RddtFolders[rddtNum]).Path + "\\" + Name + "." + k + startDeviceNum +
                        ".rddt",
                        FileMode.OpenOrCreate);
                var rddtWriter = new BinaryWriter(rddtFile);

                var result = new List<byte>();
                for (var j = 0; j < Rows; j++)
                {
                    var devicePosi = startDeviceNum + k*j;
                    if (devicePosi >= Folder.DataFolders.Count)
                    {
                        devicePosi = devicePosi - Folder.DataFolders.Count;
                    }
                    else if (devicePosi < 0)
                    {
                        devicePosi = Folder.DataFolders.Count + devicePosi;
                    }

                    var tempBytes =
                        System.IO.File.ReadAllBytes(Folder.IndexToDevice(Folder.DataFolders[devicePosi]).Path + "\\" +
                                                    Name + "." +
                                                    devicePosi + j + ".data");
                    if (j == 0)
                    {
                        result.AddRange(tempBytes);
                    }
                    else
                    {
                        for (var byteCounter = 0; byteCounter < tempBytes.Length; byteCounter++)
                        {
                            result[byteCounter] = (byte) (result[byteCounter] ^ tempBytes[byteCounter]);
                            if (j == Rows - 1)
                            {
                                rddtWriter.Write(result[byteCounter]);
                            }
                        }
                    }
                }
                rddtWriter.Close();
                rddtFile.Close();
            }
            catch (FileNotFoundException ex)
            {
                ExceptionBack();
                Console.WriteLine("出错" + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                ExceptionBack();
                Console.WriteLine("出错" + ex.Message);
            }
        }

        private void ExceptionBack()
        {
            //DeleteDataFile();
            //DeleteRddtFile();
            FilesToSave.Remove(this);
            //Thread.CurrentThread.Abort();
        }

        public void DeleteRddtFile()
        {
            try
            {
                if (Size <= 1000)
                {
                    for (var i = 0; i < Folder.RddtFolders.Count; i++)
                    {
                        if (
                            System.IO.File.Exists(Folder.IndexToDevice(Folder.RddtFolders[i]).Path + "\\" + Name + "." +
                                                  i + 0 + ".rddt"))
                        {
                            System.IO.File.Delete(Folder.IndexToDevice(Folder.RddtFolders[i]).Path + "\\" + Name + "." +
                                                  i + 0 + ".rddt");
                        }
                    }
                }
                else
                {
                    var deviceCounter = 0;
                    var fileCounter = 0;
                    var rddtFileCounter = 0;
                    for (var i = 0; i < Faults; i++)
                    {
                        // ReSharper disable once PossibleLossOfFraction
                        int k = (int) ((i + 2)/2*Math.Pow(-1, i + 2));
                        while (fileCounter < Folder.DataFolders.Count)
                        {
                            if (
                                System.IO.File.Exists(Folder.IndexToDevice(Folder.RddtFolders[deviceCounter]).Path +
                                                      "\\" +
                                                      Name + "." + k +
                                                      fileCounter + ".rddt"))
                            {
                                System.IO.File.Delete(Folder.IndexToDevice(Folder.RddtFolders[deviceCounter]).Path +
                                                      "\\" + Name + "." + k +
                                                      fileCounter + ".rddt");
                            }

                            fileCounter++;
                            rddtFileCounter++;
                            if (rddtFileCounter%(Slices/Folder.DataFolders.Count) == 0)
                            {
                                deviceCounter++;
                                rddtFileCounter = 0;
                            }
                            if (fileCounter != Folder.DataFolders.Count) continue;
                            fileCounter = 0;
                            break;
                        }
                    }
                    //MessageBox.Show("Delete Rddt File Finished.");
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("出错" + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("出错" + ex.Message);
            }
        }

        public void DeleteDataFile()
        {
            try
            {
                if (Size <= 1000)
                {
                    for (var i = 0; i < Folder.DataFolders.Count; i++)
                    {
                        if (
                            System.IO.File.Exists(Folder.IndexToDevice(Folder.DataFolders[i]).Path + "\\" + Name +
                                                  "." +
                                                  i + 0 + ".data"))
                        {
                            System.IO.File.Delete(Folder.IndexToDevice(Folder.DataFolders[i]).Path + "\\" + Name +
                                                  "." + i + 0 + ".data");
                        }
                    }
                }
                else
                {
                    for (var i = 0; i < Folder.DataFolders.Count; i++)
                    {
                        for (var j = 0; j < Slices/Folder.DataFolders.Count; j++)
                        {
                            if (
                                System.IO.File.Exists(Folder.IndexToDevice(Folder.DataFolders[i]).Path + "\\" + Name +
                                                      "." +
                                                      i + j + ".data"))
                            {
                                System.IO.File.Delete(Folder.IndexToDevice(Folder.DataFolders[i]).Path + "\\" + Name +
                                                      "." + i + j + ".data");
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("出错" + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("出错" + ex.Message);
            }
            //FileInfo.getFileInfo(this.FullName, true);
            SavedFiles.Remove(this);
            //MessageBox.Show("Delete Data File Finished.");
        }

        public void OutputFile()
        {
            try
            {
                if (Size <= 1000)
                {
                    int index = 0;
                    for (int i = 0; i < Folder.DataFolders.Count; i++)
                    {
                        if (Folder.IndexToDevice(Folder.DataFolders[i]).Status)
                        {
                            index = i;
                            break;
                        }
                    }
                    var saveFileWriter = new BinaryWriter(OutputStream);
                    ThreadStartEvent?.Invoke(Rows*Folder.DataFolders.Count, new EventArgs());

                    var folder = Folder.AllFolders.Find(obj => obj.Status);

                    var tempBytes =
                        System.IO.File.ReadAllBytes(folder.Path + "\\" + Name + "." + Folder.GetIndexInAll(folder) + index +
                                                    ".data");
                    foreach (var bytes in tempBytes)
                    {
                        saveFileWriter.Write(bytes);
                    }
                    //ThreadEvent?.Invoke(j * Folder.DataFolders.Count + i + 1, new EventArgs());
                    saveFileWriter.Close();
                    OutputStream.Close();
                    ThreadEndEvent?.Invoke(null, new EventArgs());
                }
                else
                {
                    var saveFileWriter = new BinaryWriter(OutputStream);
                    ThreadStartEvent?.Invoke(Rows*Folder.DataFolders.Count, new EventArgs());

                    for (var j = 0; j < Rows; j++)
                    {
                        for (var i = 0; i < Folder.DataFolders.Count; i++)
                        {
                            OutputOneDataFile(i, j, saveFileWriter);
                            ThreadEvent?.Invoke(j*Folder.DataFolders.Count + i + 1, new EventArgs());
                        }
                        //FileInfo.getFileInfo(this.FullName, true);
                    }
                    if (Folder.LostFolders.Count > 0)
                    {
                        for (var i = 0; i < Folder.LostFolders.Count; i++)
                        {
                            var lostIndex = Folder.LostFolders[i];
                            var di = new DirectoryInfo(Folder.IndexToDevice(lostIndex).Path);
                            di.Delete(true);
                        }
                    }
                    saveFileWriter.Close();
                    OutputStream.Close();
                    ThreadEndEvent?.Invoke(null, new EventArgs());
                }
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

        private void OutputOneDataFile(int i, int j, BinaryWriter saveFileWriter)
        {
            try
            {
                Stream tempStr =
                    new FileStream(
                        Folder.IndexToDevice(Folder.DataFolders[i]).Path + "\\" + Name + "." + i + j + ".data",
                        FileMode.Open);
                var tempReader = new BinaryReader(tempStr);

                var fillSliceCount = (int)(FillSpace / SliceSize) + 1;

                if (FillLast && j * Folder.DataFolders.Count + i == Slices - fillSliceCount)
                {
                    var readBytes = tempReader.ReadBytes((int)Size % (int)SliceSize);
                    foreach (var preByte in readBytes)
                    {
                        saveFileWriter.Write(preByte);
                    }
                }else if (FillLast && j * Folder.DataFolders.Count + i > Slices - fillSliceCount)
                {
                    
                }
                else
                {
                    var readBytes = tempReader.ReadBytes((int) SliceSize);
                    foreach (var preByte in readBytes)
                    {
                        saveFileWriter.Write(preByte);
                    }
                }
                tempReader.Close();
                tempStr.Close();
                //System.IO.File.Delete(Device.IndexToDevice(Device.DataFolders[i]).Path + "\\" + Name + i + j + ".data");
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

        public static void LostHandle()
        {
            //if (Folder.EmptyFolders.Count < Folder.LostFolders.Count)
            //{
            //    MessageBox.Show("Not Enough Empty Devices.");
            //    return;
            //}

            //MessageBox.Show("Start Restore File.");
            ThreadStartEvent?.Invoke(SavedFiles.Count, new EventArgs());
            var counter = 0;

            for (var i = 0; i < Folder.LostFolders.Count; i++)
            {
                var lostIndex = Folder.LostFolders[i];
                Directory.CreateDirectory(Folder.IndexToDevice(lostIndex).Path);
            }

            foreach (var file in SavedFiles)
            {
                if (file.Size <= 1000)
                {
                    foreach (var index in Folder.LostFolders)
                    {
                        var folder = Folder.AllFolders.Find(obj => obj.Status);

                        if (Folder.IndexToDevice(index).Type == Folder.FolderType.Data)
                        {
                            var fileStrWrite =
                                new FileStream(
                                    Folder.IndexToDevice(Folder.DataFolders[index]).Path + "\\" + file.Name + "." +
                                    index + 0 + ".data",
                                    FileMode.Create);
                            var fileWrite = new BinaryWriter(fileStrWrite);
                            var tempBytes =
                                System.IO.File.ReadAllBytes(folder.Path +
                                                            "\\" + file.Name + "." +
                                                            Folder.GetIndexInAll(folder) + 0 + "." + folder.Type);
                            foreach (var bytes in tempBytes)
                            {
                                fileWrite.Write(bytes);
                            }
                            fileWrite.Close();
                            fileStrWrite.Close();
                        }
                        else
                        {
                            var fileStrWrite =
                                new FileStream(
                                    Folder.IndexToDevice(Folder.RddtFolders[index]).Path + "\\" + file.Name + "." +
                                    index + 0 + ".rddt",
                                    FileMode.Create);
                            var fileWrite = new BinaryWriter(fileStrWrite);
                            var tempBytes =
                                System.IO.File.ReadAllBytes(folder.Path +
                                                            "\\" + file.Name + "." +
                                                            Folder.GetIndexInAll(folder) + 0 + "." + folder.Type);
                            foreach (var bytes in tempBytes)
                            {
                                fileWrite.Write(bytes);
                            }
                            fileWrite.Close();
                            fileStrWrite.Close();
                        }
                    }
                    counter++;
                    ThreadEvent?.Invoke(counter, new EventArgs());
                }
                else
                {
                    bool recFinish;
                    do
                    {
                        recFinish = true;
                        foreach (var index in Folder.LostFolders)
                        {
                            var result = Folder.IndexToDevice(index).DetectDevice(file);
                            recFinish = recFinish && result;
                        }
                    } while (recFinish == false);
                    file.RddtFileInit();
                    counter++;
                    ThreadEvent?.Invoke(counter, new EventArgs());
                }
            }

            Folder.LostFolders.Clear();
            //MessageBox.Show("Recover Devices Finished!");
            ThreadEndEvent?.Invoke(null, new EventArgs());
        }

        public bool DetectDataFile(Folder device, int fCount, int targetRow)
        {
            // ReSharper disable once PossibleLossOfFraction
            int k = (int) ((fCount + 2)/2*Math.Pow(-1, fCount + 2));
            var startDeviceNum = (Folder.GetIndexInAll(device) - targetRow*k + Folder.DataFolders.Count)%
                                 Folder.DataFolders.Count;
            var rddtDeviceNum = (fCount*Folder.DataFolders.Count + startDeviceNum)/Rows;
            if (
                System.IO.File.Exists(device.Path + "\\" + Name + "." +
                                      Folder.DataFolders.FindIndex(
                                          obj => obj == Folder.GetIndexInAll(device)) + targetRow +
                                      ".data"))
            {
                return true;
            }
            if (
                !DetectRddtFile(Folder.IndexToDevice(Folder.RddtFolders[(int) rddtDeviceNum]), k,
                    startDeviceNum))
            {
                return false;
            }
            if (!DetectKLine(Folder.GetIndexInAll(device), targetRow, (int) rddtDeviceNum, k, false))
            {
                return false;
            }
            RestoreDataFile(
                Folder.DataFolders.FindIndex(obj => obj == Folder.GetIndexInAll(device)),
                (int) rddtDeviceNum, k, targetRow);
            return true;
        }

        public bool DetectRddtFile(Folder device, int k, int dataDeviceNum)
        {
            if (System.IO.File.Exists(device.Path + "\\" + Name + "." + k + dataDeviceNum + ".rddt"))
            {
                return true;
            }
            if (
                !DetectKLine(dataDeviceNum, 0,
                    Folder.RddtFolders.FindIndex(obj => obj == Folder.GetIndexInAll(device)), k,
                    true))
            {
                return false;
            }
            InitOneRddtFile(dataDeviceNum, k,
                Folder.RddtFolders.FindIndex(obj => obj == Folder.GetIndexInAll(device)));
            return true;
        }

        private bool DetectKLine(int dataDeviceNum, int targetRow, int rddtDeviceNum, int k, bool isForRddt)
        {
            var result = true;
            var startIndex = (dataDeviceNum - k*targetRow + Folder.DataFolders.Count)%Folder.DataFolders.Count;
            // ReSharper disable once RedundantAssignment
            var tempResult = true;
            for (var rowCount = 0; rowCount < Rows; rowCount++)
            {
                if ((targetRow == rowCount) && !isForRddt)
                {
                    continue;
                }
                tempResult = System.IO.File.Exists(
                    Folder.IndexToDevice(
                        Folder.DataFolders[
                            (startIndex + rowCount*k + Folder.DataFolders.Count)%Folder.DataFolders.Count]).Path + "\\" +
                    Name + "." + (startIndex + rowCount*k + Folder.DataFolders.Count)%Folder.DataFolders.Count +
                    rowCount +
                    ".data");
                result = result && tempResult;
            }
            if (isForRddt)
            {
                return result;
            }
            tempResult =
                System.IO.File.Exists(Folder.IndexToDevice(Folder.RddtFolders[rddtDeviceNum]).Path + "\\" + Name + "." +
                                      k +
                                      startIndex + ".rddt");
            result = result && tempResult;
            return result;
        }

        private void RestoreDataFile(int dataDeviceNum, int rddtDeviceNum, int k, int targetRow)
        {
            var startIndex = (dataDeviceNum - k*targetRow + Folder.DataFolders.Count)%Folder.DataFolders.Count;
            var result =
                System.IO.File.ReadAllBytes(Folder.IndexToDevice(Folder.RddtFolders[rddtDeviceNum]).Path + "\\" + Name +
                                            "." + k +
                                            startIndex + ".rddt");
            for (var rowCount = 0; rowCount < Rows; rowCount++)
            {
                if (targetRow == rowCount)
                {
                    continue;
                }
                var tempBytes =
                    System.IO.File.ReadAllBytes(
                        Folder.IndexToDevice(
                            Folder.DataFolders[
                                (startIndex + rowCount*k + Folder.DataFolders.Count)%Folder.DataFolders.Count]).Path +
                        "\\" +
                        Name + "." + (startIndex + rowCount*k + Folder.DataFolders.Count)%Folder.DataFolders.Count +
                        rowCount +
                        ".data");
                for (var j = 0; j < result.Length; j++)
                {
                    result[j] = (byte) (result[j] ^ tempBytes[j]);
                }
            }

            var dataFile =
                new FileStream(
                    Folder.IndexToDevice(Folder.DataFolders[dataDeviceNum]).Path + "\\" + Name + "." + dataDeviceNum +
                    targetRow +
                    ".data", FileMode.OpenOrCreate);
            var dataWriter = new BinaryWriter(dataFile);
            if (FillLast &&
                Folder.IndexToDevice(Folder.DataFolders[dataDeviceNum]).Name ==
                Folder.IndexToDevice(Folder.DataFolders[Folder.DataFolders.Count - 1]).Name && targetRow == Rows - 1)
            {
                for (var bt = 0; bt < result.Length - FillSpace; bt++)
                {
                    dataWriter.Write(result[bt]);
                }
            }
            else
            {
                foreach (var bt in result)
                {
                    dataWriter.Write(bt);
                }
            }
            dataWriter.Close();
            dataFile.Close();
        }
    }

    internal static class FileInfo
    {
        public static string GetPureName(string fileName)
        {
            var pureName = "";
            var length = fileName.Split('.').Length;
            if (length == 2)
            {
                pureName = fileName.Split('.')[0];
            }
            else
            {
                for (var i = 0; i < length - 1; i++)
                {
                    pureName += fileName.Split('.')[i];
                }
            }
            return pureName;
        }

        public static string GetExtension(string fileName)
        {
            var extension = fileName.Split('.')[fileName.Split('.').Length - 1];
            return extension;
        }
    }
}