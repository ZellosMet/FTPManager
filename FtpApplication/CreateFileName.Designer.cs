namespace FtpApplication
{
    partial class CreateFileName
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
            l_EnterFileName = new Label();
            tb_FileName = new TextBox();
            b_OK = new Button();
            b_Cancel = new Button();
            SuspendLayout();
            // 
            // l_EnterFileName
            // 
            l_EnterFileName.AutoSize = true;
            l_EnterFileName.Location = new Point(16, 18);
            l_EnterFileName.Name = "l_EnterFileName";
            l_EnterFileName.Size = new Size(114, 20);
            l_EnterFileName.TabIndex = 0;
            l_EnterFileName.Text = "Enter File Name";
            // 
            // tb_FileName
            // 
            tb_FileName.Location = new Point(19, 50);
            tb_FileName.Name = "tb_FileName";
            tb_FileName.Size = new Size(269, 27);
            tb_FileName.TabIndex = 1;
            // 
            // b_OK
            // 
            b_OK.DialogResult = DialogResult.OK;
            b_OK.Location = new Point(94, 97);
            b_OK.Name = "b_OK";
            b_OK.Size = new Size(94, 29);
            b_OK.TabIndex = 2;
            b_OK.Text = "OK";
            b_OK.UseVisualStyleBackColor = true;
            b_OK.Click += b_OK_Click;
            // 
            // b_Cancel
            // 
            b_Cancel.Location = new Point(194, 97);
            b_Cancel.Name = "b_Cancel";
            b_Cancel.Size = new Size(94, 29);
            b_Cancel.TabIndex = 3;
            b_Cancel.Text = "Cancel";
            b_Cancel.UseVisualStyleBackColor = true;
            b_Cancel.Click += b_Cancel_Click;
            // 
            // CreateFileName
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 145);
            Controls.Add(b_Cancel);
            Controls.Add(b_OK);
            Controls.Add(tb_FileName);
            Controls.Add(l_EnterFileName);
            Name = "CreateFileName";
            Text = "Create File Name";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label l_EnterFileName;
        private TextBox tb_FileName;
        private Button b_OK;
        private Button b_Cancel;
    }
}