using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace EasyContral_Server
{
    public partial class Shell : Form
    {
        public Shell()
        {
            InitializeComponent();
        }

        private void Shell_Load(object sender, EventArgs e)
        {
            textBox1.Select();
            richTextBox1.Text = "";
            string Open_ClientID = Form1.Open_ClientID;
            if (Open_ClientID == "")
            {
                MessageBox.Show("空ID");
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Command = textBox1.Text;
            textBox1.Text = "";
            Dictionary<string, string> Jobe = new Dictionary<string, string>();
            Jobe.Add("Type", "CMD");
            Jobe.Add("Data", Command);
            Form1.Jobes.Enqueue(Jobe);
        }
        public void UpdateRichTextBox(string txt)
        {
            richTextBox1.AppendText(txt);
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
