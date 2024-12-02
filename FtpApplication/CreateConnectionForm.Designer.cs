namespace FtpApplication
{
    partial class CreateConnectionForm
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
            l_Name = new Label();
            l_HostName = new Label();
            l_UserName = new Label();
            l_Password = new Label();
            tb_Name = new TextBox();
            tb_HostName = new TextBox();
            tb_UserName = new TextBox();
            tb_Password = new TextBox();
            b_Create = new Button();
            b_Cancel = new Button();
            b_LoadConnectionDetails = new Button();
            l_ErrorMessage = new Label();
            ofd_LoadFromFile = new OpenFileDialog();
            SuspendLayout();
            // 
            // l_Name
            // 
            l_Name.AutoSize = true;
            l_Name.Location = new Point(21, 17);
            l_Name.Name = "l_Name";
            l_Name.Size = new Size(49, 20);
            l_Name.TabIndex = 0;
            l_Name.Text = "Name";
            // 
            // l_HostName
            // 
            l_HostName.AutoSize = true;
            l_HostName.Location = new Point(21, 70);
            l_HostName.Name = "l_HostName";
            l_HostName.Size = new Size(84, 20);
            l_HostName.TabIndex = 1;
            l_HostName.Text = "Host Name";
            // 
            // l_UserName
            // 
            l_UserName.AutoSize = true;
            l_UserName.Location = new Point(21, 123);
            l_UserName.Name = "l_UserName";
            l_UserName.Size = new Size(82, 20);
            l_UserName.TabIndex = 2;
            l_UserName.Text = "User Name";
            // 
            // l_Password
            // 
            l_Password.AutoSize = true;
            l_Password.Location = new Point(21, 176);
            l_Password.Name = "l_Password";
            l_Password.Size = new Size(70, 20);
            l_Password.TabIndex = 3;
            l_Password.Text = "Password";
            // 
            // tb_Name
            // 
            tb_Name.Location = new Point(118, 14);
            tb_Name.Name = "tb_Name";
            tb_Name.Size = new Size(145, 27);
            tb_Name.TabIndex = 4;
            // 
            // tb_HostName
            // 
            tb_HostName.Location = new Point(118, 67);
            tb_HostName.Name = "tb_HostName";
            tb_HostName.Size = new Size(145, 27);
            tb_HostName.TabIndex = 5;
            // 
            // tb_UserName
            // 
            tb_UserName.Location = new Point(118, 120);
            tb_UserName.Name = "tb_UserName";
            tb_UserName.Size = new Size(145, 27);
            tb_UserName.TabIndex = 6;
            // 
            // tb_Password
            // 
            tb_Password.Location = new Point(118, 173);
            tb_Password.Name = "tb_Password";
            tb_Password.Size = new Size(145, 27);
            tb_Password.TabIndex = 7;
            // 
            // b_Create
            // 
            b_Create.Location = new Point(21, 294);
            b_Create.Name = "b_Create";
            b_Create.Size = new Size(94, 29);
            b_Create.TabIndex = 8;
            b_Create.Text = "Create";
            b_Create.UseVisualStyleBackColor = true;
            b_Create.Click += b_Create_Click;
            // 
            // b_Cancel
            // 
            b_Cancel.DialogResult = DialogResult.Cancel;
            b_Cancel.Location = new Point(169, 294);
            b_Cancel.Name = "b_Cancel";
            b_Cancel.Size = new Size(94, 29);
            b_Cancel.TabIndex = 9;
            b_Cancel.Text = "Cancel";
            b_Cancel.UseVisualStyleBackColor = true;
            b_Cancel.Click += b_Cancel_Click;
            // 
            // b_LoadConnectionDetails
            // 
            b_LoadConnectionDetails.Location = new Point(21, 215);
            b_LoadConnectionDetails.Name = "b_LoadConnectionDetails";
            b_LoadConnectionDetails.Size = new Size(242, 29);
            b_LoadConnectionDetails.TabIndex = 10;
            b_LoadConnectionDetails.Text = "Load From File";
            b_LoadConnectionDetails.UseVisualStyleBackColor = true;
            b_LoadConnectionDetails.Click += b_LoadConnectionDetails_Click;
            // 
            // l_ErrorMessage
            // 
            l_ErrorMessage.AutoSize = true;
            l_ErrorMessage.Location = new Point(25, 259);
            l_ErrorMessage.Name = "l_ErrorMessage";
            l_ErrorMessage.Size = new Size(0, 20);
            l_ErrorMessage.TabIndex = 11;
            // 
            // CreateConnectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 340);
            Controls.Add(l_ErrorMessage);
            Controls.Add(b_LoadConnectionDetails);
            Controls.Add(b_Cancel);
            Controls.Add(b_Create);
            Controls.Add(tb_Password);
            Controls.Add(tb_UserName);
            Controls.Add(tb_HostName);
            Controls.Add(tb_Name);
            Controls.Add(l_Password);
            Controls.Add(l_UserName);
            Controls.Add(l_HostName);
            Controls.Add(l_Name);
            Name = "CreateConnectionForm";
            Text = "CreateConnectionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label l_Name;
        private Label l_HostName;
        private Label l_UserName;
        private Label l_Password;
        private TextBox tb_Name;
        private TextBox tb_HostName;
        private TextBox tb_UserName;
        private TextBox tb_Password;
        private Button b_Create;
        private Button b_Cancel;
        private Button b_LoadConnectionDetails;
        private Label l_ErrorMessage;
        private OpenFileDialog ofd_LoadFromFile;
    }
}