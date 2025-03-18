using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Coffee_Shop
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None; // Xóa viền
            this.BackColor = Color.Magenta; // Chọn màu nền đặc biệt
            this.TransparencyKey = Color.Magenta;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister formregister = new FormRegister();
            formregister.ShowDialog();
        }

        private void btnForgetpassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormForgetPassword formforget = new FormForgetPassword();
            formforget.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassWord.Text;
            using (SqlConnection connection = Connection.StringConnection())
            {
                connection.Open();
                string query = "SELECT Id FROM account WHERE UserName=@UserName AND PassWord=@PassWord";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        if (result.ToString()[0] == 'M')
                        {
                            MessageBox.Show("Kết nối với quản lý thành công");
                            // quản lý
                        } else {
                            if (result.ToString()[0] == 'C')
                            {
                                query = "SELECT Name,Address FROM customerInformation WHERE Id=@Id";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@Id", result.ToString());
                                    using(SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            FormCustomer formCustomer = new FormCustomer(result.ToString(),reader.GetString(0),reader.GetString(1));
                                            formCustomer.Show();
                                            this.Hide();
                                        }
                                    }
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Kết nối với attendant thành công");
                            }
                        }
                    } else
                    {
                        lblOutput.Text = "Sai thông tin tài khoản hoặc mật khẩu";
                    }
                }
            }
        }
        public string UserName
        {
            get { return txtUserName.Text; }
            set { txtUserName.Text = value; }
        }
        public string PassWord {
            get { return txtPassWord.Text; }
            set { txtPassWord.Text = value; }
        }

        private void txtPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender,e);
            }
        }
    }
}
