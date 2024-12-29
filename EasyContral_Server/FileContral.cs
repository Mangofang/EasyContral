using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyContral_Server
{
    public partial class FileContral : Form
    {
        TreeNode Node_root = new TreeNode();
        public FileContral()
        {
            InitializeComponent();
        }

        private void FileContral_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            listView1.Items.Clear();
            Dictionary<string, string> Jobe = new Dictionary<string, string>();
            Jobe.Add("Type", "Drives");
            Jobe.Add("Data", "GetDrives");
            Form1.Jobes.Enqueue(Jobe);
        }
        public void UpdateTreeView(string Drives)
        {
            try
            {
                Drives = Drives.Remove(Drives.LastIndexOf('|'), 1);
                string[] Drives_ = Drives.Split('|');
                foreach (string D in Drives_)
                {
                    treeView1.Invoke(new Action(() =>
                    {
                        treeView1.Nodes.Add(D);
                    }));
                }
            }
            catch (InvalidOperationException ex)
            {
                return;
            }
        }
        public void UpdateListView(Dictionary<string, Dictionary<string,string>> Files)
        {
            listView1.Items.Clear();
            Node_root.Nodes.Clear();
            foreach (string Name in Files.Keys)
            {
                listView1.Invoke(new Action(() =>
                {
                    ListViewItem li = new ListViewItem();
                    li.SubItems.Add(Name);
                    li.SubItems.Add(Files[Name]["Size"]);
                    li.SubItems.Add(Files[Name]["CreateTime"]);
                    listView1.Items.Add(li);
                    Node_root.Nodes.Add(Name);
                    Node_root.Expand();
                }));
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Node_root = treeView1.SelectedNode;
            Dictionary<string, string> Jobe = new Dictionary<string, string>();
            string path = e.Node.FullPath;
            Jobe.Add("Type", "Files");
            Jobe.Add("Data", path);
            Form1.Jobes.Enqueue(Jobe);
        }

        private void File_Update_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> Jobe = new Dictionary<string, string>();
            string path = treeView1.SelectedNode.FullPath;
            Jobe.Add("Type", "Files");
            Jobe.Add("Data", path);
            Form1.Jobes.Enqueue(Jobe);
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

        private void File_Upload_Click(object sender, EventArgs e)
        {
            string FileContent = "";
            string FileName = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "所有文件 (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    FileName = Path.GetFileName(filePath);
                    FileContent = File.ReadAllText(filePath);
                }
            }
            Dictionary<string, string> Jobe = new Dictionary<string, string>();
            Jobe.Add("Type", "File_Upload");
            Jobe.Add("Path", treeView1.SelectedNode.FullPath + $"\\{FileName}");
            Jobe.Add("Data", FileContent);
            Form1.Jobes.Enqueue(Jobe);
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.contextMenuStrip2.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void File_Upload__Click(object sender, EventArgs e)
        {
            File_Upload_Click(sender, e);
        }

        private void File_Updata__Click(object sender, EventArgs e)
        {
            File_Update_Click(sender, e);
        }

        private void File_Download_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.listView1.SelectedIndices;
            string filename = "";
            if (indexes.Count > 0)
            {
                int index = indexes[0];
                filename = treeView1.SelectedNode.FullPath + @"\" + listView1.Items[index].SubItems[1].Text;
            }
            Dictionary<string, string> Jobe = new Dictionary<string, string>();
            Jobe.Add("Type", "File_Download");
            Jobe.Add("Data", filename);
            Form1.Jobes.Enqueue(Jobe);
        }

        private void File_ReName_Click(object sender, EventArgs e)
        {
            string Name = Interaction.InputBox("新名称","重命名");
            string NewName = "";
            ListView.SelectedIndexCollection indexes = this.listView1.SelectedIndices;
            string OldName = "";
            if (indexes.Count > 0)
            {
                int index = indexes[0];
                OldName = treeView1.SelectedNode.FullPath + @"\" + listView1.Items[index].SubItems[1].Text;
                NewName = treeView1.SelectedNode.FullPath + @"\" + Name;
            }
            Dictionary<string, string> Jobe = new Dictionary<string, string>();
            Jobe.Add("Type", "File_ReName");
            Jobe.Add("Data", NewName + "?" + OldName);
            Form1.Jobes.Enqueue(Jobe);
        }

        private void File_Delete_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.listView1.SelectedIndices;
            string filename = "";
            if (indexes.Count > 0)
            {
                int index = indexes[0];
                filename = treeView1.SelectedNode.FullPath + @"\" + listView1.Items[index].SubItems[1].Text;
            }
            Dictionary<string, string> Jobe = new Dictionary<string, string>();
            Jobe.Add("Type", "File_Delete");
            Jobe.Add("Data", filename);
            Form1.Jobes.Enqueue(Jobe);
        }
    }
}
