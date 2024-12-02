using System.Text.Json;
using System;
using System.Windows.Forms;
using FluentFTP.Helpers;
using FtpApplication.Classes;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace FtpApplication
{
    //������� ����� ��������� ������
    public partial class TextFileEditer : Form
    {
        FileManager FileManager;
        ConnectionDetails current_connection;
        //�������� ������ �����������
        List<ConnectionDetails> connection_details_list = new List<ConnectionDetails>();
        //���� ��� ���������� �����
        string file_path_save = string.Empty;
        //���� �������� �����
        string file_path_open = string.Empty;
        //��������� ���������� �� ��������
        string current_connection_for_delete = string.Empty;
        public TextFileEditer()
        {
            InitializeComponent();
            //������ ������ ��� ��� �����������
            sfd_Save.Filter = "Text files(*.txt)|*.txt";
            ofd_Open.Filter = "Text files(*.txt)|*.txt";
        }
        //������� �������� ������ �����������
        private void tsmi_CreateConnection_Click(object sender, EventArgs e)
        {
            //�������� ����� ��� �������� ������ �����������
            CreateConnectionForm CCF = new CreateConnectionForm(connection_details_list);
            CCF.ShowDialog(this);
            //���������� ������ �����������
            ReloadeConnectionList();
        }
        //������� ����������� � FTP-�������
        private void Connection_Click(object sender, EventArgs e)
        {
            //��������� ������� �����������
            ConnectionDetails connection = connection_details_list.First(conn => conn.ConnectionName == sender.ToString());
            //���������� ��������� �������� �����������
            current_connection = connection;
            //������ ����� ��������� ���������
            FileManager = new FileManager(connection, rtb_Text);
            FileManager.Show();
        }
        //���������� ������ ����������� ��� �������� �����
        private void TextFileEditer_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FileStream fs = new FileStream("connection_list.connect", FileMode.Create))
            {
                JsonSerializer.Serialize<List<ConnectionDetails>>(fs, connection_details_list);
            }
        }
        //��������� ������ ����������� ��� �������� �����
        private void TextFileEditer_Load(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("connection_list.connect", FileMode.Open))
            {
                connection_details_list = JsonSerializer.Deserialize<List<ConnectionDetails>>(fs);
                ReloadeConnectionList();
            }
        }
        //������� ������ ������������ ���� ��� �����������
        private void ContextMenuDelete_RightClick(object sender, MouseEventArgs e)
        {
            //�������� ������� ������ �������
            if (e.Button == MouseButtons.Right)
            {
                //�������������� ����������� �������� ����
                tsmi_Cloud.DropDown.AutoClose = false;
                tsmi_ConnectionToCloud.DropDown.AutoClose = false;
                //����������� ������ ������������ ����
                cms_DeleteConnection.Show(Cursor.Position);
                //��������� ����� ����������� ��� ��������
                current_connection_for_delete = sender.ToString();
            }
        }
        //������� �������� ����������� �� ������
        private void cms_DeleteConnection_Click(object sender, EventArgs e)
        {
            //�������������� �������� �������� ����
            tsmi_Cloud.DropDown.AutoClose = true;
            tsmi_Cloud.DropDown.Close();
            tsmi_ConnectionToCloud.DropDown.AutoClose = true;
            tsmi_ConnectionToCloud.DropDown.Close();
            //��������� ����������� �� ������
            ConnectionDetails connection = connection_details_list.First(conn => conn.ConnectionName == current_connection_for_delete);
            //�������� ����������� �� ������
            if (connection != null)
                connection_details_list.Remove(connection);
            //���������� ������ �����������
            ReloadeConnectionList();
        }
        //����� ���������� ������ �����������
        private void ReloadeConnectionList()
        {
            //������� ������
            tsmi_ConnectionToCloud.DropDownItems.Clear();
            //���������� �������� �������� �������� �����������
            ToolStripMenuItem item = new ToolStripMenuItem("Create Connect");
            item.Click += tsmi_CreateConnection_Click;
            tsmi_ConnectionToCloud.DropDownItems.Add(item);
            tsmi_ConnectionToCloud.DropDownItems.Add(new ToolStripSeparator());
            //�������� ������ ����������� � ������� ����
            foreach (ConnectionDetails connection in connection_details_list)
            {
                ToolStripMenuItem menu_item = new ToolStripMenuItem(connection.ConnectionName);
                menu_item.Click += Connection_Click;
                menu_item.MouseUp += ContextMenuDelete_RightClick;
                tsmi_ConnectionToCloud.DropDownItems.Add(menu_item);
            }
        }
        //������� ���������� ���������� �����
        private void tsmi_LocalSave_Click(object sender, EventArgs e)
        {
            if (sfd_Save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(sfd_Save.FileName, false))
                {
                    writer.Write(rtb_Text.Text);
                }
            }
        }
        //������� ���������� ����� �� FTP �������
        private void tsmi_CloudSave_Click(object sender, EventArgs e)
        {   
            //��������� ������ �� �������� ������(�������� ����������� � FTP �������)
            if (FileManager == null || FileManager.Created == false)
            {
                MessageBox.Show 
                    (
                        $"No active connection",
                        "Save Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                current_connection = null;
                return;
            }
            //������ ����� ��� ��������� ����� ����� �� ������������
            CreateFileName CFN = new CreateFileName();
            string file_name = "";
            //�������� ��� ����� �� �����
            if (CFN.ShowDialog(this) == DialogResult.OK)
            { 
                file_name = CFN.FileName + ".txt";
                CFN.Close();
            }
            //�������� ��������� ����
            using (StreamWriter writer = new StreamWriter(file_name, false))
            {
                writer.Write(rtb_Text.Text);
            }
            //������ ����������� � FTP �������
            FtpManager FM = new FtpManager(current_connection);
            //���������� ���� �� FTP ������
            FM.SendFileToCloud(file_name, FileManager.CurrenCloudPath);            
        }
    }
}
