using FluentFTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.ListViewItem;

namespace FtpApplication.Classes
{
    //Класс работы с FTP-сервером
    internal class FtpManager
    {
        //Создаём обект создания подключения
        AsyncFtpClient client;
        //ConnectionDetails connection;
        //Создаём токен отмены
        CancellationToken token = new CancellationToken();
        //Хранение имени подключения
        string host_name = string.Empty;

        public FtpManager(ConnectionDetails connection) //connection - объект подключения
        {
            //Инициальзаия подключения
            client = new AsyncFtpClient();
            //Задание хоста подключения
            client.Host = connection.HostName;
            //Задание данных авторизации
            client.Credentials = new NetworkCredential(connection.UserName, connection.Password);
            //Сохраняем имя подключения
            host_name = connection.ConnectionName;
            //Загружаем картинки для отображения в списке файлов и папок
            
        }
        //Событие получение данных с FTP сервера
        //form - вызывающая форма. необходима для закрытия если подключение не удалось
        //list - ListView вызывающей формы, необходим для загрузки файлов из FTP сервера
        public async Task GetLocalAndCloudListing(Form form, ListView cloud_list, ListView local_list, string local_path, string cloud_path, bool load_cloud)
        {  
            if (load_cloud)
                await LoadCloudDirectoryToList(form, cloud_list, cloud_path);
            LoadLocalDirectoryList(local_list, local_path);
        }
        //Метод отправки файла на FTP-сервер
        public async Task SendFileToCloud(string name_file, string to_path) 
        {
            //Попытка отправки
            try
            {                
                //Создаём подключение
                await client.Connect(token);
                //Отравляем файл
                await client.UploadFile(name_file, to_path == @"\"? to_path + name_file : to_path + @"\" + name_file);
                //Закрываем подключение
                await client.Disconnect();
                //Освобождение ресурсов
                client.Dispose();
                //Удаляем временный файл
                File.Delete(name_file);
            }
            catch (Exception ex)
            {
                //Вывод сообщение об ощибке при, если не удалось подключиться к FTP-серверу
                MessageBox.Show
                    (
                        $"Сonnection to host \"{host_name}\" not established. Try creating a new connection.",
                        "Connection Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            }
        }
        //Метод получения файла из FTP-сервера
        public async Task DownloadFromCloud()
        {
            //Попытка скачивания
            try
            {
                //Создаём подключение
                await client.Connect();
                //Закгрузка файла
                await client.DownloadFile("download.txt", "htdocs/storage/test.txt");
                //Закрытие подключения
                await client.Disconnect();
                //Освобождение ресурсов
                client.Dispose();
            }
            catch (Exception ex)
            {
                //Вывод сообщение об ощибке при, если не удалось подключиться к FTP-серверу
                MessageBox.Show
                    (
                        $"Сonnection to host \"{host_name}\" not established. Try creating a new connection.",
                        "Connection Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            }
        }

        private async Task LoadCloudDirectoryToList(Form form, ListView cloud_list,  string path)
        {
            cloud_list.Items.Clear();
            cloud_list.Items.Add(new ListViewItem() { Text = "..." }).SubItems.Add("");
            try
            {
                //Подключение к FTP серверу
                await client.Connect(token);
                //Получение списка файлов и каталогов согласно выбранного пути и помещаем их в ListView
                foreach (var item in await client.GetListing(path, token)) //FtpListOption.Recursive - рекурсивное получение файлов
                                                                           //IncludeSelfAndParent - добавляет . для текущего каталога
                                                                           //и .. для родительского каталога
                {
                    ListViewItem lvi = new ListViewItem();
                    switch (item.Type)
                    {
                        case FtpObjectType.Directory:
                            {                                                             
                                lvi.Text = item.Name;
                                lvi.ImageIndex = 1;
                                cloud_list.Items.Add(lvi).SubItems.Add("Dir");
                            }
                        break;
                        case FtpObjectType.File:
                            {                                                              
                                lvi.Text = item.Name;
                                lvi.ImageIndex = 0;
                                cloud_list.Items.Add(lvi).SubItems.Add(item.Name.Split('.')[item.Name.Split('.').Length-1]);
                            }
                        break;
                        case FtpObjectType.Link:
                        break;
                    }
                }
            }
            //Выводим сообщение об ошибки если не удалось получить данные с FTP сервера
            catch (Exception ex)
            {
                MessageBox.Show
                        (
                            $"Сonnection to host \"{host_name}\" not established. Try creating a new connection.",
                            "Connection Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                form.Close();
            }
        }
        private void LoadLocalDirectoryList(ListView local_list, string path)
        {
            //Создаём объект информации каталога
            DirectoryInfo directoryInfo = new DirectoryInfo(path);  
            //Очищаем ListView
            local_list.Items.Clear();     
            //Добавляем переход в родительский каталог
            local_list.Items.Add(new ListViewItem() {Text = "..."}).SubItems.Add("");
            //Добавляем в ListView файлы и папки
            foreach (var item in directoryInfo.GetFiles())
            {                
                ListViewItem lvi = new ListViewItem();               
                lvi.Text = item.Name;                
                lvi.ImageIndex = 0;
                local_list.Items.Add(lvi).SubItems.Add(item.Extension.Remove(0,1));
            }
            foreach (var item in directoryInfo.GetDirectories())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.Name;                
                lvi.ImageIndex = 1;
                local_list.Items.Add(lvi).SubItems.Add("Dir");                
            }            
        }
    }
}
