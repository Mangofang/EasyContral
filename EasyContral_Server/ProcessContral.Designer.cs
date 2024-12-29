namespace EasyContral_Server
{
    partial class ProcessContral
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SessionID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MemoryUse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreateProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.Update = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Process_Kill = new System.Windows.Forms.ToolStripMenuItem();
            this.Process_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.Update_ = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.ProcessName,
            this.ProcessID,
            this.SessionID,
            this.MemoryUse});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1309, 786);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // ProcessName
            // 
            this.ProcessName.Text = "进程名";
            this.ProcessName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProcessName.Width = 140;
            // 
            // ProcessID
            // 
            this.ProcessID.Text = "PID";
            this.ProcessID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SessionID
            // 
            this.SessionID.Text = "会话";
            this.SessionID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SessionID.Width = 120;
            // 
            // MemoryUse
            // 
            this.MemoryUse.Text = "内存占用";
            this.MemoryUse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MemoryUse.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateProcess,
            this.Update});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 80);
            // 
            // CreateProcess
            // 
            this.CreateProcess.Name = "CreateProcess";
            this.CreateProcess.Size = new System.Drawing.Size(184, 38);
            this.CreateProcess.Text = "新建进程";
            this.CreateProcess.Click += new System.EventHandler(this.CreateProcess_Click);
            // 
            // Update
            // 
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(184, 38);
            this.Update.Text = "刷新";
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Process_Kill,
            this.Process_Start,
            this.Update_});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(185, 118);
            // 
            // Process_Kill
            // 
            this.Process_Kill.Name = "Process_Kill";
            this.Process_Kill.Size = new System.Drawing.Size(184, 38);
            this.Process_Kill.Text = "关闭进程";
            this.Process_Kill.Click += new System.EventHandler(this.Process_Kill_Click);
            // 
            // Process_Start
            // 
            this.Process_Start.Name = "Process_Start";
            this.Process_Start.Size = new System.Drawing.Size(184, 38);
            this.Process_Start.Text = "新建进程";
            this.Process_Start.Click += new System.EventHandler(this.Process_Start_Click);
            // 
            // Update_
            // 
            this.Update_.Name = "Update_";
            this.Update_.Size = new System.Drawing.Size(184, 38);
            this.Update_.Text = "刷新";
            this.Update_.Click += new System.EventHandler(this.Update__Click);
            // 
            // ProcessContral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 810);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProcessContral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProcessContral";
            this.Load += new System.EventHandler(this.ProcessContral_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader ProcessName;
        private System.Windows.Forms.ColumnHeader ProcessID;
        private System.Windows.Forms.ColumnHeader SessionID;
        private System.Windows.Forms.ColumnHeader MemoryUse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CreateProcess;
        private System.Windows.Forms.ToolStripMenuItem Update;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Process_Kill;
        private System.Windows.Forms.ToolStripMenuItem Process_Start;
        private System.Windows.Forms.ToolStripMenuItem Update_;
    }
}