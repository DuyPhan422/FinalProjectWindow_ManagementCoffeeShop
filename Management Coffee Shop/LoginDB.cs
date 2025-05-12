using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Management_Coffee_Shop
{
    internal class LoginDB
    {
        public static (string ,string,string,string,byte,string,bool ) get_Infor(string username)
        {
            string ID = "";
            string Email = "";
            string Password = "";
            string Lock = "";
            byte PassWordFail=0;
            string LastLogin = "";
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT ID,Email,PassWord,Lock,PassWordFail,LastLogin FROM account WHERE UserName=@UserName ";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ID = reader["ID"].ToString();
                            Email = reader["Email"].ToString();
                            Password = reader["Password"].ToString();
                            Lock = reader["Lock"].ToString();
                            PassWordFail =byte.Parse( reader["PassWordFail"].ToString());
                            LastLogin = reader["LastLogin"].ToString();
                            return (ID, Email,Password,Lock,PassWordFail,LastLogin,true);
                        }
                    }
                }
            }
            return (ID, Email, Password, Lock, PassWordFail,LastLogin, false);
        }
        public static void update_PassWordFail(string username)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "UPDATE account SET PassWordFail=PassWordFail+1 WHERE UserName=@UserName ";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Locking(string username, string formatted_unLockTime)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "UPDATE account SET Lock=@Lock WHERE UserName=@UserName ";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@Lock",formatted_unLockTime);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable get_InforCustomer(string Id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT Name, Address, Email, Date, Image, Lock FROM customerInformation JOIN account ON account.ID = customerInformation.ID WHERE customerInformation.ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", Id);
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public static List<string> get_UserName(List<string> userId_List)
        {
            List<string> userName_List = new List<string>();
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT UserName FROM account WHERE ID=@ID";
                foreach (string Id in userId_List)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) userName_List.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return userName_List;
        }
        public static DataTable get_InforEmployee(string Id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT LastName,Address,Email,BirthDate,Source_Image FROM StaffManager WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", Id);
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
