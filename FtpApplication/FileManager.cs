using FluentFTP;
using FluentFTP.Helpers;
using FtpApplication.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace FtpApplication
{
    //Форма файлового менеджера
    public partial class FileManager : Form
    {
        FtpManager ftp;
        //Объект данных подключения
        ConnectionDetails connect;
        RichTextBox rich_text_box;
        //Текущий докальный путь        
        public string CurrenLocalPath { get; private set; } = Environment.CurrentDirectory;
        //Текущий путь облака       
        public string CurrenCloudPath { get; private set; } = "/";
        public FileManager(ConnectionDetails connection, RichTextBox text_box)
        {
            InitializeComponent();
            //Инициализвация объекта данных подключения
            connect = connection;
            //Создаём объект FTP менеджера 
            ftp = new FtpManager(connection);
            //Настройка ListView
            lv_LocalList.Columns.Add("Name");
            lv_LocalList.Columns.Add("Extension");

            lv_CloudList.Columns.Add("Name");
            lv_CloudList.Columns.Add("Extension");

            ImageList imageList = new ImageList();
            imageList.Images.Add(Bitmap.FromFile(Environment.CurrentDirectory + "\\image\\icon-file.png")); //Файл
            lv_CloudList.SmallImageList = imageList;
            imageList.Images.Add(Bitmap.FromFile(Environment.CurrentDirectory + "\\image\\icon-folder.png")); //Папка
            lv_LocalList.SmallImageList = imageList;

            //Заполняем пути
            tb_LocalCurrenPath.Text = CurrenLocalPath;
            l_CloudCurrentPath.Text = CurrenCloudPath;
            //Получаем содержимое каталога FTP сервера            
            ftp.GetLocalAndCloudListing(this, lv_CloudList, lv_LocalList, CurrenLocalPath, CurrenCloudPath, true);
            rich_text_box = text_box;
        }
        //событие перехода по локальным коталагам
        private void lv_LocalList_DoubleClick(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            string type = lv.SelectedItems[0].SubItems[1].Text;
            switch (type)
            {
                case "":
                    {
                        tb_LocalCurrenPath.Text = CurrenLocalPath = CurrenLocalPath.Remove(CurrenLocalPath.LastIndexOf("\\"));
                        if (CurrenLocalPath.Split('\\').Length <= 1)
                            tb_LocalCurrenPath.Text = CurrenLocalPath = CurrenLocalPath + @"\";
                        ftp.GetLocalAndCloudListing(this, lv_CloudList, lv_LocalList, CurrenLocalPath, CurrenCloudPath, false);
                    }
                    break;
                case "Dir":
                    {
                        tb_LocalCurrenPath.Text = CurrenLocalPath = CurrenLocalPath + @"\" + lv.FocusedItem.Text;
                        ftp.GetLocalAndCloudListing(this, lv_CloudList, lv_LocalList, CurrenLocalPath, CurrenCloudPath, false);
                    }
                    break;
                case "txt":
                    {
                        string path = CurrenLocalPath + "\\" + lv.FocusedItem.Text;
                        using (StreamReader stream = new StreamReader(path))
                        {
                            rich_text_box.Text = stream.ReadToEnd();
                        }
                    }
                    break;
            }
        }
        //Событие перехода по каталогам FTP сервера
        private void lv_CloudList_DoubleClick(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            string type = lv.SelectedItems[0].SubItems[1].Text;
            switch (type)
            {
                case "":
                    {
                        l_CloudCurrentPath.Text = CurrenCloudPath = CurrenCloudPath.Remove(CurrenCloudPath.LastIndexOf("/"));
                        if (CurrenCloudPath == "")
                            CurrenCloudPath = "/";
                        ftp.GetLocalAndCloudListing(this, lv_CloudList, lv_LocalList, CurrenLocalPath, CurrenCloudPath, true);
                    }
                    break;
                case "Dir":
                    {
                        if (CurrenCloudPath == "/")
                            CurrenCloudPath = "";
                        l_CloudCurrentPath.Text = CurrenCloudPath = CurrenCloudPath + "/" + lv.FocusedItem.Text;
                        ftp.GetLocalAndCloudListing(this, lv_CloudList, lv_LocalList, CurrenLocalPath, CurrenCloudPath, true);
                    }
                    break;
                case "txt":
                    {
                        string path = CurrenLocalPath + "\\" + lv.FocusedItem.Text;
                        using (StreamReader stream = new StreamReader(path))
                        {
                            rich_text_box.Text = stream.ReadToEnd();
                        }
                    }
                    break;
            }
        }
        //Событие обновление списков файлов
        private void b_Refrash_Click(object sender, EventArgs e)
        {
            ftp = new FtpManager(connect);
            ftp.GetLocalAndCloudListing(this, lv_CloudList, lv_LocalList, CurrenLocalPath, CurrenCloudPath, true);
        }
    }
}
