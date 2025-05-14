using Guna.UI2.WinForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Windows.Forms;
using Guna.UI2.AnimatorNS;
using System.Xml.Linq;

namespace Management_Coffee_Shop
{
    internal class RegisterDB
    {
        public RegisterDB() 
        {

        } 
        public static bool Check(string UserName,string Email)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT Count(*) FROM account WHERE UserName=@UserName OR Email=@Email ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("email", Email);
                    int result = Convert.ToInt32(command.ExecuteScalar());
                    if (result == 0)
                    {
                        return true;
                    }
                }
                
            }
            return false;
        }
        public static void Create_Account(string UserName,string PassWord,string Email,string Phone,string Name,string Address)
        {
            string new_Id=Create_ID();
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "INSERT INTO account (Id,UserName,PassWord,Email,Phone,PassWordFail) VALUES (@Id,@UserName,@PassWord,@Email,@Phone,@PassWordFail)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", new_Id);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@PassWord", PassWord);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@PassWordFail", 0);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            Create_Infor(new_Id,Name,Address);
        }
        private static void Create_Infor(string new_Id,string Name,string Address)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "INSERT INTO customerInformation (Id,Name,Address) VALUES (@Id,@Name,@Address)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", new_Id);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Address", Address);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }
        private static string Create_ID()
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string new_Id = "C";
                Random random = new Random();
                int result = 1;
                connection.Open();
                string query = "SELECT Count(*) FROM account WHERE Id=@Id ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    while (result != 0)
                    {
                        new_Id += random.Next(100000, 1000000).ToString();
                        command.Parameters.AddWithValue("@Id", new_Id);
                        result = Convert.ToInt32(command.ExecuteScalar());
                        if (result != 0) new_Id = "C";
                    }
                }
                return new_Id;
            }
        }
    }
}
