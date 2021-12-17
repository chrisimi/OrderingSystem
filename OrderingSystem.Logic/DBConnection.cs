using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace OrderingSystem.Logic
{
    public class DBConnection
    {
        private DBConnection()
        {
        }
        
        public MySqlConnection Connection { get; set; }

        private static DBConnection _instance;

        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnected()
        {
            if (Connection == null)
            {
                string connectionString = "SERVER=localhost;DATABASE=ordering_system;USERNAME=root;PASSWORD=";
                Connection = new MySqlConnection(connectionString);
                Connection.Open();
            }
            return true;
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}