using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Management_Coffee_Shop
{
    internal class ForgetPasswordDB
    {
        public static ForgetPassWord send_Request(ForgetPassWord infor, string txtUserName)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT UserName,PassWord,Email,Phone FROM account WHERE UserName=@UserName ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", txtUserName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())// nếu có tài khoản
                        {
                            infor = new ForgetPassWord(reader["UserName"].ToString(), reader["PassWord"].ToString(), reader["Email"].ToString(), reader["Phone"].ToString());
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return infor;
        }
        public static void update_password(ForgetPassWord infor, string new_password)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "UPDATE account SET PassWord=@PassWord where UserName=@UserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", infor.Get_UserName);
                    command.Parameters.AddWithValue("@PassWord", new_password);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
