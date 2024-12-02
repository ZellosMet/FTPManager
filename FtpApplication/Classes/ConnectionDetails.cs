using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FtpApplication.Classes
{
    //Класс создания подключения
    public class ConnectionDetails
    {
        //Имя подключения
        public string ConnectionName { get; set; }
        //Хост
        public string HostName { get; set; }
        //Имя пользователя
        public string UserName { get; set; }
        //Пароль
        public string Password { get; set; }        
        public ConnectionDetails() { }
        public ConnectionDetails(string connection_name, string host_name, string user_name, string password)
        { 
            ConnectionName = connection_name;
            HostName = host_name;
            UserName = user_name;
            Password = password;
        }
    }
}
