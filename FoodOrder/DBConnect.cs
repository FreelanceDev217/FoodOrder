using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//Add MySql Library
using MySql.Data.MySqlClient;
using FoodOrder;
using System.Security.Cryptography;
namespace DBConnectNS
{
    public class DBConnect
    {
        public MySqlConnection connection;
        public string server;
        public string database;
        public string uid;
        public string password;
        public int chk_interval;
        public SimpleAES aes_crypter = new SimpleAES();
        //Constructor
        public DBConnect()
        {
        }

        public void LoadSetting(UserSetting userSetting)
        {
            server = userSetting.server_address;
            database = userSetting.db_name;
            uid = userSetting.user_id;
            chk_interval = userSetting.check_interval;
            password = aes_crypter.Decrypt(userSetting.user_pw);
        }

        public void SaveSetting(UserSetting userSetting)
        {
            userSetting.server_address = server;
            userSetting.db_name = database;
            userSetting.user_id = uid;
            userSetting.user_pw = aes_crypter.Encrypt(password) ;
            userSetting.check_interval = chk_interval;
        }

        public void CreateConnection()
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public static int GetExceptionNumber(MySqlException my)
        {
            if (my != null)
            {
                int number = my.Number;
                //if the number is zero, try to get the number of the inner exception
                if (number == 0 && (my = my.InnerException as MySqlException) != null)
                {
                    number = my.Number;
                }
                return number;
            }
            return -1;
        }
        //open connection to database
        public bool OpenConnection(bool p_sil = false)
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                if (p_sil == true)
                    return false;
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (GetExceptionNumber(ex))
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;

                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
