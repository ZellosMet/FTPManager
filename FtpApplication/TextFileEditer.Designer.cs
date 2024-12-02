namespace FtpApplication
{
    partial class TextFileEditer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            rtb_Text = new RichTextBox();
            ofd_Open = new OpenFileDialog();
            fbd_Save = new FolderBrowserDialog();
            sfd_Save = new SaveFileDialog();
            ms_MainMenu = new MenuStrip();
            tsmi_File = new ToolStripMenuItem();
            tsmi_LocalSave = new ToolStripMenuItem();
            tsmi_CloudSave = new ToolStripMenuItem();
            tsmi_Cloud = new ToolStripMenuItem();
            tsmi_ConnectionToCloud = new ToolStripMenuItem();
            tsmi_CreateConnection = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            cms_DeleteConnection = new ContextMenuStrip(components);
            tsmi_Delete = new ToolStripMenuItem();
            ms_MainMenu.SuspendLayout();
            cms_DeleteConnection.SuspendLayout();
            SuspendLayout();
            // 
            // rtb_Text
            // 
            rtb_Text.Location = new Point(12, 31);
            rtb_Text.Name = "rtb_Text";
            rtb_Text.Size = new Size(653, 407);
            rtb_Text.TabIndex = 0;
            rtb_Text.Text = "";
            // 
            // ofd_Open
            // 
            ofd_Open.FileName = "openFileDialog2";
            // 
            // ms_MainMenu
            // 
            ms_MainMenu.ImageScalingSize = new Size(20, 20);
            ms_MainMenu.Items.AddRange(new ToolStripItem[] { tsmi_File, tsmi_Cloud });
            ms_MainMenu.Location = new Point(0, 0);
            ms_MainMenu.Name = "ms_MainMenu";
            ms_MainMenu.Size = new Size(678, 28);
            ms_MainMenu.TabIndex = 5;
            ms_MainMenu.Text = "menuStrip1";
            // 
            // tsmi_File
            // 
            tsmi_File.DropDownItems.AddRange(new ToolStripItem[] { tsmi_LocalSave, tsmi_CloudSave });
            tsmi_File.Name = "tsmi_File";
            tsmi_File.Size = new Size(46, 24);
            tsmi_File.Text = "File";
            // 
            // tsmi_LocalSave
            // 
            tsmi_LocalSave.Name = "tsmi_LocalSave";
            tsmi_LocalSave.Size = new Size(166, 26);
            tsmi_LocalSave.Text = "Local Save";
            tsmi_LocalSave.Click += tsmi_LocalSave_Click;
            // 
            // tsmi_CloudSave
            // 
            tsmi_CloudSave.Name = "tsmi_CloudSave";
            tsmi_CloudSave.Size = new Size(166, 26);
            tsmi_CloudSave.Text = "Cloud Save";
            tsmi_CloudSave.Click += tsmi_CloudSave_Click;
            // 
            // tsmi_Cloud
            // 
            tsmi_Cloud.DropDownItems.AddRange(new ToolStripItem[] { tsmi_ConnectionToCloud });
            tsmi_Cloud.Name = "tsmi_Cloud";
            tsmi_Cloud.Size = new Size(62, 24);
            tsmi_Cloud.Text = "Cloud";
            // 
            // tsmi_ConnectionToCloud
            // 
            tsmi_ConnectionToCloud.DropDownItems.AddRange(new ToolStripItem[] { tsmi_CreateConnection, toolStripSeparator1 });
            tsmi_ConnectionToCloud.Name = "tsmi_ConnectionToCloud";
            tsmi_ConnectionToCloud.Size = new Size(224, 26);
            tsmi_ConnectionToCloud.Text = "Connect to Cloud";
            // 
            // tsmi_CreateConnection
            // 
            tsmi_CreateConnection.Name = "tsmi_CreateConnection";
            tsmi_CreateConnection.Size = new Size(224, 26);
            tsmi_CreateConnection.Text = "Create Connect";
            tsmi_CreateConnection.Click += tsmi_CreateConnection_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // cms_DeleteConnection
            // 
            cms_DeleteConnection.ImageScalingSize = new Size(20, 20);
            cms_DeleteConnection.Items.AddRange(new ToolStripItem[] { tsmi_Delete });
            cms_DeleteConnection.Name = "cms_DeleteConnection";
            cms_DeleteConnection.Size = new Size(123, 28);
            cms_DeleteConnection.Click += cms_DeleteConnection_Click;
            // 
            // tsmi_Delete
            // 
            tsmi_Delete.Name = "tsmi_Delete";
            tsmi_Delete.Size = new Size(122, 24);
            tsmi_Delete.Text = "Delete";
            // 
            // TextFileEditer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 454);
            Controls.Add(rtb_Text);
            Controls.Add(ms_MainMenu);
            MainMenuStrip = ms_MainMenu;
            Name = "TextFileEditer";
            Text = "TextFileEditer";
            FormClosing += TextFileEditer_FormClosing;
            Load += TextFileEditer_Load;
            ms_MainMenu.ResumeLayout(false);
            ms_MainMenu.PerformLayout();
            cms_DeleteConnection.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtb_Text;
        private OpenFileDialog ofd_Open;
        private FolderBrowserDialog fbd_Save;
        private SaveFileDialog sfd_Save;
        private MenuStrip ms_MainMenu;
        private ToolStripMenuItem tsmi_File;
        private ToolStripMenuItem tsmi_LocalSave;
        private ToolStripMenuItem tsmi_CloudSave;
        private ToolStripMenuItem tsmi_Cloud;
        private ToolStripMenuItem tsmi_ConnectionToCloud;
        private ToolStripMenuItem tsmi_CreateConnection;
        private ToolStripSeparator toolStripSeparator1;
        private ContextMenuStrip cms_DeleteConnection;
        private ToolStripMenuItem tsmi_Delete;
    }
}
