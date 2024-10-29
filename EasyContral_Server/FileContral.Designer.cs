namespace EasyContral_Server
{
    partial class FileContral
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.File_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.File_Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.File_CreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.File_ReName = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Download = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Upload = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Update = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.File_Upload_ = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Updata_ = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(296, 773);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.File_Name,
            this.File_Size,
            this.File_CreateTime});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(320, 12);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(878, 773);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // File_Name
            // 
            this.File_Name.Text = "文件名";
            this.File_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.File_Name.Width = 180;
            // 
            // File_Size
            // 
            this.File_Size.Text = "文件大小";
            this.File_Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // File_CreateTime
            // 
            this.File_CreateTime.Text = "创建时间";
            this.File_CreateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.File_CreateTime.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_ReName,
            this.File_Delete,
            this.File_Download,
            this.File_Upload,
            this.File_Update});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 194);
            // 
            // File_ReName
            // 
            this.File_ReName.Name = "File_ReName";
            this.File_ReName.Size = new System.Drawing.Size(184, 38);
            this.File_ReName.Text = "重命名";
            this.File_ReName.Click += new System.EventHandler(this.File_ReName_Click);
            // 
            // File_Delete
            // 
            this.File_Delete.Name = "File_Delete";
            this.File_Delete.Size = new System.Drawing.Size(184, 38);
            this.File_Delete.Text = "删除";
            this.File_Delete.Click += new System.EventHandler(this.File_Delete_Click);
            // 
            // File_Download
            // 
            this.File_Download.Name = "File_Download";
            this.File_Download.Size = new System.Drawing.Size(184, 38);
            this.File_Download.Text = "下载";
            this.File_Download.Click += new System.EventHandler(this.File_Download_Click);
            // 
            // File_Upload
            // 
            this.File_Upload.Name = "File_Upload";
            this.File_Upload.Size = new System.Drawing.Size(184, 38);
            this.File_Upload.Text = "文件上传";
            this.File_Upload.Click += new System.EventHandler(this.File_Upload_Click);
            // 
            // File_Update
            // 
            this.File_Update.Name = "File_Update";
            this.File_Update.Size = new System.Drawing.Size(184, 38);
            this.File_Update.Text = "刷新";
            this.File_Update.Click += new System.EventHandler(this.File_Update_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_Upload_,
            this.File_Updata_});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(185, 80);
            // 
            // File_Upload_
            // 
            this.File_Upload_.Name = "File_Upload_";
            this.File_Upload_.Size = new System.Drawing.Size(184, 38);
            this.File_Upload_.Text = "文件上传";
            this.File_Upload_.Click += new System.EventHandler(this.File_Upload__Click);
            // 
            // File_Updata_
            // 
            this.File_Updata_.Name = "File_Updata_";
            this.File_Updata_.Size = new System.Drawing.Size(184, 38);
            this.File_Updata_.Text = "刷新";
            this.File_Updata_.Click += new System.EventHandler(this.File_Updata__Click);
            // 
            // FileContral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 798);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FileContral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileContral";
            this.Load += new System.EventHandler(this.FileContral_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader File_Name;
        private System.Windows.Forms.ColumnHeader File_Size;
        private System.Windows.Forms.ColumnHeader File_CreateTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File_ReName;
        private System.Windows.Forms.ToolStripMenuItem File_Delete;
        private System.Windows.Forms.ToolStripMenuItem File_Download;
        private System.Windows.Forms.ToolStripMenuItem File_Upload;
        private System.Windows.Forms.ToolStripMenuItem File_Update;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem File_Upload_;
        private System.Windows.Forms.ToolStripMenuItem File_Updata_;
    }
}