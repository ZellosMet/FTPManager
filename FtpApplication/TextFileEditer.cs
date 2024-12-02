using System.Text.Json;
using System;
using System.Windows.Forms;
using FluentFTP.Helpers;
using FtpApplication.Classes;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace FtpApplication
{
    //Главноя форма редактора текста
    public partial class TextFileEditer : Form
    {
        FileManager FileManager;
        ConnectionDetails current_connection;
        //Создание списка подключений
        List<ConnectionDetails> connection_details_list = new List<ConnectionDetails>();
        //Путь для сожранения файла
        string file_path_save = string.Empty;
        //Путь открытия вайла
        string file_path_open = string.Empty;
        //Выбранное соеденение на удаления
        string current_connection_for_delete = string.Empty;
        public TextFileEditer()
        {
            InitializeComponent();
            //Фильтр файлов для для сожраненеия
            sfd_Save.Filter = "Text files(*.txt)|*.txt";
            ofd_Open.Filter = "Text files(*.txt)|*.txt";
        }
        //Событие создание нового подключения
        private void tsmi_CreateConnection_Click(object sender, EventArgs e)
        {
            //Создание формы для создания нового подключения
            CreateConnectionForm CCF = new CreateConnectionForm(connection_details_list);
            CCF.ShowDialog(this);
            //Обновление списка подключений
            ReloadeConnectionList();
        }
        //Событие подключение к FTP-серверу
        private void Connection_Click(object sender, EventArgs e)
        {
            //Получение объекта подключения
            ConnectionDetails connection = connection_details_list.First(conn => conn.ConnectionName == sender.ToString());
            //Запоминаем параметры текущего подключения
            current_connection = connection;
            //Создаём форму файлового менеджера
            FileManager = new FileManager(connection, rtb_Text);
            FileManager.Show();
        }
        //Сохранение списка подключений при закрытии формы
        private void TextFileEditer_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FileStream fs = new FileStream("connection_list.connect", FileMode.Create))
            {
                JsonSerializer.Serialize<List<ConnectionDetails>>(fs, connection_details_list);
            }
        }
        //Закгрузка списка подключений при открытии формы
        private void TextFileEditer_Load(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("connection_list.connect", FileMode.Open))
            {
                connection_details_list = JsonSerializer.Deserialize<List<ConnectionDetails>>(fs);
                ReloadeConnectionList();
            }
        }
        //Событие вызова контекстного меню для подключения
        private void ContextMenuDelete_RightClick(object sender, MouseEventArgs e)
        {
            //Проверка нажатия правой кнопкой
            if (e.Button == MouseButtons.Right)
            {
                //Принудительное отображение главного меню
                tsmi_Cloud.DropDown.AutoClose = false;
                tsmi_ConnectionToCloud.DropDown.AutoClose = false;
                //Отображение пункта контекстного меню
                cms_DeleteConnection.Show(Cursor.Position);
                //Получение имени подключения для удаления
                current_connection_for_delete = sender.ToString();
            }
        }
        //Событие удаления подключения из списка
        private void cms_DeleteConnection_Click(object sender, EventArgs e)
        {
            //Принудительное закрытие главного меню
            tsmi_Cloud.DropDown.AutoClose = true;
            tsmi_Cloud.DropDown.Close();
            tsmi_ConnectionToCloud.DropDown.AutoClose = true;
            tsmi_ConnectionToCloud.DropDown.Close();
            //Получение подключения из списка
            ConnectionDetails connection = connection_details_list.First(conn => conn.ConnectionName == current_connection_for_delete);
            //Удаление подключения из списка
            if (connection != null)
                connection_details_list.Remove(connection);
            //Обновление списка подключений
            ReloadeConnectionList();
        }
        //Метод обновления списка подключения
        private void ReloadeConnectionList()
        {
            //Очистка списка
            tsmi_ConnectionToCloud.DropDownItems.Clear();
            //Добавление базового элемента создания подключения
            ToolStripMenuItem item = new ToolStripMenuItem("Create Connect");
            item.Click += tsmi_CreateConnection_Click;
            tsmi_ConnectionToCloud.DropDownItems.Add(item);
            tsmi_ConnectionToCloud.DropDownItems.Add(new ToolStripSeparator());
            //Загрузка списка подключений в главное меню
            foreach (ConnectionDetails connection in connection_details_list)
            {
                ToolStripMenuItem menu_item = new ToolStripMenuItem(connection.ConnectionName);
                menu_item.Click += Connection_Click;
                menu_item.MouseUp += ContextMenuDelete_RightClick;
                tsmi_ConnectionToCloud.DropDownItems.Add(menu_item);
            }
        }
        //Событие локального сохранения файла
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
        //Событие сохранения файла на FTP сервере
        private void tsmi_CloudSave_Click(object sender, EventArgs e)
        {   
            //Проверяем открыт ли Менеджер Файлов(проверка подключения к FTP серверу)
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
            //Создаём форму для получения имени файла от пользователя
            CreateFileName CFN = new CreateFileName();
            string file_name = "";
            //Получаем имя файла из формы
            if (CFN.ShowDialog(this) == DialogResult.OK)
            { 
                file_name = CFN.FileName + ".txt";
                CFN.Close();
            }
            //Временно сохраняем файл
            using (StreamWriter writer = new StreamWriter(file_name, false))
            {
                writer.Write(rtb_Text.Text);
            }
            //Создаём подключение к FTP серверу
            FtpManager FM = new FtpManager(current_connection);
            //Отправляем файл на FTP сервер
            FM.SendFileToCloud(file_name, FileManager.CurrenCloudPath);            
        }
    }
}
