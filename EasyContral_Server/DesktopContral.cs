using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace EasyContral_Server
{
    public partial class DesktopContral : Form
    {
        public DesktopContral()
        {
            InitializeComponent();
        }
        bool Switch = true;
        private void DesktopContral_Load(object sender, EventArgs e)
        {
            Switch = true;
            MessageBox.Show("画面传输依赖于http心跳包，为保证画面帧数请先调整响应时间");
            ThreadPool.QueueUserWorkItem(update =>
            {
                while (Switch) 
                {
                    Dictionary<string, string> Jobe = new Dictionary<string, string>();
                    Jobe.Add("Type", "GetDesktop");
                    Jobe.Add("Data", "GetDesktop");
                    Form1.Jobes.Enqueue(Jobe);
                    Thread.Sleep(1000);
                }
            });
        }

        public void UpdateView(byte[] imgByte)
        {
            using (MemoryStream ms = new MemoryStream(imgByte))
            {
                Image image = Image.FromStream(ms);
                pictureBox1.Image = image;
            }
        }

        private void DesktopContral_FormClosing(object sender, FormClosingEventArgs e)
        {
            Switch = false;
            Form1.Jobes.Clear();
        }
    }
}
