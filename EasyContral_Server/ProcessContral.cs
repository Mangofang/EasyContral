using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyContral_Server
{
    public partial class ProcessContral : Form
    {
        public ProcessContral()
        {
            InitializeComponent();
        }

        private void ProcessContral_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> Jobe = new Dictionary<string, string>();
            Jobe.Add("Type", "GetProcess");
            Jobe.Add("Data", "GetAllProcess");
            Form1.Jobes.Enqueue(Jobe);
        }
        public void UpdateListView(Dictionary<string,Dictionary<string,string>> DicProcess)
        {
            listView1.Items.Clear();
            foreach (string ProcessId in DicProcess.Keys)
            {
                ListViewItem li = new ListViewItem();
                li.SubItems.Add(DicProcess[ProcessId]["ProcessName"]);
                li.SubItems.Add(ProcessId);
                li.SubItems.Add(DicProcess[ProcessId]["SessionId"]);
                li.SubItems.Add((int.Parse(DicProcess[ProcessId]["MemoryUsage"])/1024).ToString());
                listView1.Items.Add(li);
            }
        }

        private void Process_Kill_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.listView1.SelectedIndices;
            if (indexes.Count > 0)
            {
                int index = indexes[0];
                string ProcessId = listView1.Items[index].SubItems[2].Text;
                Dictionary<string, string> Jobe = new Dictionary<string, string>();
                Jobe.Add("Type", "KillProcess");
                Jobe.Add("Data", ProcessId);
                Form1.Jobes.Enqueue(Jobe);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;
            ListViewItem item = listView.GetItemAt(e.X, e.Y);
            if (item != null && e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip2.Show(listView, e.X, e.Y);
            }
        }
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }
        private void Update__Click(object sender, EventArgs e)
        {
            ProcessContral_Load(sender, e);
        }

        private void Process_Start_Click(object sender, EventArgs e)
        {
            string path = Interaction.InputBox("启动路径", "新建进程");
            Dictionary<string, string> Jobe = new Dictionary<string, string>();
            Jobe.Add("Type", "CreateProcess");
            Jobe.Add("Data", path);
            Form1.Jobes.Enqueue(Jobe);
        }

        private void CreateProcess_Click(object sender, EventArgs e)
        {
            Process_Start_Click(sender, e);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Update__Click(sender, e);
        }
    }
}
