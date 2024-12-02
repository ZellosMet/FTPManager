namespace FtpApplication
{
    partial class FileManager
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
            lv_LocalList = new ListView();
            lv_CloudList = new ListView();
            tb_LocalCurrenPath = new TextBox();
            l_LocalPath = new Label();
            l_CloudPath = new Label();
            l_CloudCurrentPath = new Label();
            b_CurrentPath = new Button();
            b_Refrash = new Button();
            SuspendLayout();
            // 
            // lv_LocalList
            // 
            lv_LocalList.FullRowSelect = true;
            lv_LocalList.GridLines = true;
            lv_LocalList.Location = new Point(15, 79);
            lv_LocalList.Name = "lv_LocalList";
            lv_LocalList.Size = new Size(273, 359);
            lv_LocalList.TabIndex = 0;
            lv_LocalList.UseCompatibleStateImageBehavior = false;
            lv_LocalList.View = View.Details;
            lv_LocalList.DoubleClick += lv_LocalList_DoubleClick;
            // 
            // lv_CloudList
            // 
            lv_CloudList.FullRowSelect = true;
            lv_CloudList.GridLines = true;
            lv_CloudList.Location = new Point(384, 79);
            lv_CloudList.Name = "lv_CloudList";
            lv_CloudList.Size = new Size(273, 359);
            lv_CloudList.TabIndex = 1;
            lv_CloudList.UseCompatibleStateImageBehavior = false;
            lv_CloudList.View = View.Details;
            lv_CloudList.DoubleClick += lv_CloudList_DoubleClick;
            // 
            // tb_LocalCurrenPath
            // 
            tb_LocalCurrenPath.Location = new Point(15, 46);
            tb_LocalCurrenPath.Name = "tb_LocalCurrenPath";
            tb_LocalCurrenPath.Size = new Size(238, 27);
            tb_LocalCurrenPath.TabIndex = 2;
            // 
            // l_LocalPath
            // 
            l_LocalPath.AutoSize = true;
            l_LocalPath.Location = new Point(15, 19);
            l_LocalPath.Name = "l_LocalPath";
            l_LocalPath.Size = new Size(76, 20);
            l_LocalPath.TabIndex = 3;
            l_LocalPath.Text = "Local Path";
            // 
            // l_CloudPath
            // 
            l_CloudPath.AutoSize = true;
            l_CloudPath.Location = new Point(382, 19);
            l_CloudPath.Name = "l_CloudPath";
            l_CloudPath.Size = new Size(80, 20);
            l_CloudPath.TabIndex = 4;
            l_CloudPath.Text = "Cloud Path";
            // 
            // l_CloudCurrentPath
            // 
            l_CloudCurrentPath.AutoSize = true;
            l_CloudCurrentPath.Location = new Point(382, 53);
            l_CloudCurrentPath.Name = "l_CloudCurrentPath";
            l_CloudCurrentPath.Size = new Size(0, 20);
            l_CloudCurrentPath.TabIndex = 5;
            // 
            // b_CurrentPath
            // 
            b_CurrentPath.Location = new Point(259, 46);
            b_CurrentPath.Name = "b_CurrentPath";
            b_CurrentPath.Size = new Size(29, 27);
            b_CurrentPath.TabIndex = 6;
            b_CurrentPath.Text = "...";
            b_CurrentPath.UseVisualStyleBackColor = true;
            // 
            // b_Refrash
            // 
            b_Refrash.Location = new Point(566, 15);
            b_Refrash.Name = "b_Refrash";
            b_Refrash.Size = new Size(94, 29);
            b_Refrash.TabIndex = 9;
            b_Refrash.Text = "Refrash";
            b_Refrash.UseVisualStyleBackColor = true;
            b_Refrash.Click += b_Refrash_Click;
            // 
            // FileManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 450);
            Controls.Add(b_Refrash);
            Controls.Add(b_CurrentPath);
            Controls.Add(l_CloudCurrentPath);
            Controls.Add(l_CloudPath);
            Controls.Add(l_LocalPath);
            Controls.Add(tb_LocalCurrenPath);
            Controls.Add(lv_CloudList);
            Controls.Add(lv_LocalList);
            Name = "FileManager";
            Text = "FileManager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lv_LocalList;
        private ListView lv_CloudList;
        private TextBox tb_LocalCurrenPath;
        private Label l_LocalPath;
        private Label l_CloudPath;
        private Label l_CloudCurrentPath;
        private Button b_CurrentPath;
        private Button b_Refrash;
    }
}