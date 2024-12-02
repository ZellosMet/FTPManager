using FtpApplication.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace FtpApplication
{
    //Форма создания подключения
    public partial class CreateConnectionForm : Form
    {
        //Создание списка подключений
        List<ConnectionDetails> connection_details_list = new List<ConnectionDetails>();
        public CreateConnectionForm(List<ConnectionDetails> list)
        {
            InitializeComponent();
            //Получение списк подключений из главной формы
            connection_details_list = list;
            //Установка фильта открываемых файлов
            ofd_LoadFromFile.Filter = "Connect Data(*.connect)|*.connect";
        }
        //Событие добавление подключения в список подключений
        private void b_Create_Click(object sender, EventArgs e)
        {
            //Проверка заполнения всех полей
            if (tb_Name.Text != "" && tb_HostName.Text != "" && tb_UserName.Text != "" && tb_Password.Text != "")
            {
                //Создание объекта подключения
                ConnectionDetails connection = new ConnectionDetails(tb_Name.Text, tb_HostName.Text, tb_UserName.Text, tb_Password.Text);
                //Добавление подключения в список
                connection_details_list.Add(connection);
                //Устанавливаем статус формы
                this.DialogResult = DialogResult.OK;
                //Закрываем форму
                this.Close();
            }
            //Сообщение об ошибки, если не все поля заполнены
            l_ErrorMessage.Text = "Not All Fields are Filled";            
        }
        //Событие закрытие формы
        private void b_Cancel_Click(object sender, EventArgs e)
        {
            //Установка статуса формы
            this.DialogResult = DialogResult.Cancel;
            //Закрытие формы
            this.Close();
        }
        //Событие закгрузки параметров подключения из файла
        private void b_LoadConnectionDetails_Click(object sender, EventArgs e)
        {
            if (ofd_LoadFromFile.ShowDialog() == DialogResult.Cancel)
                return;
            //Загрузка из файла и заполнение полей данными подключения
            using (FileStream fs = new FileStream(ofd_LoadFromFile.FileName, FileMode.OpenOrCreate))
            {
                ConnectionDetails? connect_data = JsonSerializer.Deserialize<ConnectionDetails>(fs);
                tb_Name.Text = connect_data.ConnectionName;
                tb_HostName.Text = connect_data.HostName;
                tb_UserName.Text = connect_data.UserName;
                tb_Password.Text = connect_data.Password;
            }
        }
    }
}
