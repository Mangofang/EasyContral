using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System;

namespace EasyContral
{
    internal class FileContral
    {
        public static string GetFileList(string path)
        {
            try
            {
                DirectoryInfo rootDir = new DirectoryInfo(path);
                FileSystemInfo[] allFileSystemInfos = rootDir.GetFileSystemInfos("*.*", SearchOption.TopDirectoryOnly);
                Dictionary<string, Dictionary<string, string>> fileSystemInfo = new Dictionary<string, Dictionary<string, string>>();
                foreach (FileSystemInfo fileSystemInfoItem in allFileSystemInfos)
                {
                    Dictionary<string, string> info = new Dictionary<string, string>();
                    if (fileSystemInfoItem is FileInfo file)
                    {
                        info.Add("Name", file.Name);
                        info.Add("Size", file.Length.ToString());
                        info.Add("CreateTime", file.CreationTime.ToString());
                    }
                    else if (fileSystemInfoItem is DirectoryInfo directory)
                    {
                        info.Add("Name", directory.Name);
                        info.Add("Size", "Directory");
                        info.Add("CreateTime", directory.CreationTime.ToString());
                    }
                    else
                    {
                        continue;
                    }
                    fileSystemInfo.Add(fileSystemInfoItem.Name, info);
                }
                string jsonResult = JsonConvert.SerializeObject(fileSystemInfo, Formatting.Indented);
                return jsonResult;
            }
            catch (DirectoryNotFoundException ex)
            {

                return "";
            }
        }
        public static void UploadFile(string path, string file)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(file);
            }
        }
        public static string DownloadFile(string path)
        {
            return File.ReadAllText(path);
        }
        public static void RenameFile(string sourceDirectory, string destDirectory)
        {
            Directory.Move(sourceDirectory, destDirectory);
        }
        public static void DownloadWebFile(string url, string path,string savename)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, path + $@"\{savename}");
            }
        }
        public static void DeleteFile(string path)
        {
            Console.WriteLine("Delete:" + path);
            File.Delete(path);
        }
    }
}
