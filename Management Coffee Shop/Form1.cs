using Guna.UI2.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Management_Coffee_Shop
{
    public partial class FormLogin : Form
    {
        public List<string> userName_List=new List<string>();
        public List<string> userId_List=new List<string>();
        public FormLogin()
        {
            InitializeComponent();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None; // Xóa viền
            this.BackColor = Color.Magenta; // Chọn màu nền đặc biệt
            this.TransparencyKey = Color.Magenta;
            this.BeginInvoke((MethodInvoker)delegate {
                check_Access_Token();
            });
            guna2TabControl1.SelectedTab = tabPage1;
        }
        public void change_tabPage()
        {
            guna2TabControl1.SelectedTab = tabPage1;
        }
        private void check_Access_Token()
        {
            (bool success, List<string> userId_List) = Login.check_machineName();
            this.userId_List = userId_List;
            if (success)
            {
                userName_List=get_UserName(userId_List);
                for (int i = 0; i < userId_List.Count; i++)
                {
                    Guna2Button button = new Guna2Button();
                    button.Size = new Size(230, 45);
                    button.FillColor = Color.WhiteSmoke;
                    button.BackColor = Color.Transparent;
                    button.BorderRadius = 20;
                    button.BorderThickness = 1;
                    button.HoverState.FillColor= Color.FromArgb(211, 155, 81);
                    button.HoverState.ForeColor= Color.WhiteSmoke;
                    button.BorderColor = Color.FromArgb(211, 155, 81);
                    button.ForeColor = Color.FromArgb(211, 155, 81);
                    button.Font = new Font("Segoe UI", 9f);
                    button.Margin = new Padding(left: 8, top: 3, right: 8, bottom: 3);
                    button.Text = "Đăng nhập với tài khoản "+userName_List[i];
                    button.Click+=account_clicked;
                    button.Tag=userId_List[i];
                    flpChooseAccount.Controls.Add(button);
                }
                guna2TabControl1.SelectedTab = tabPage2;
            }
        }
        private void account_clicked(object sender, EventArgs e)
        {
            if (sender is Guna2Button clicked_Button)
            {
                bool success=Login.check_Token(clicked_Button.Tag.ToString());
                if (success)
                {
                    get_inforID(clicked_Button.Tag.ToString(), true);
                }
            }
        }
        private List<string> get_UserName(List<string> userId_List)
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
        private void get_inforID(string Id,bool check)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT Name,Address,Email,Date FROM customerInformation JOIN account ON account.ID=customerInformation.ID WHERE customerInformation.ID=@ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", Id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FormCustomer formCustomer = new FormCustomer(Id, reader["Name"].ToString(), reader["Address"].ToString(), reader["Email"].ToString(), reader["Date"].ToString(),this ,check);
                            formCustomer.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
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
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT ID FROM account WHERE UserName=@UserName AND PassWord=@PassWord";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@PassWord", password);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        if (result.ToString()[0] == 'M')
                        {
                            MessageBox.Show("Kết nối với quản lý thành công");
                            // quản lý
                        }
                        else
                        {
                            if (result.ToString()[0] == 'C')
                            {
                                bool check = false;
                                if (userName_List.Count > 0)
                                {
                                    foreach (string us in userName_List)
                                    {
                                        if (us.Trim() == username.Trim())
                                        {
                                            check = true;
                                            break;
                                        }
                                    }
                                }
                                if (check) get_inforID(result.ToString(), true);
                                else get_inforID(result.ToString(), false);
                            }
                            else
                            {
                                MessageBox.Show("Kết nối với attendant thành công");
                            }
                        }
                    }
                    else
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

        private void btnLoginWithAnotherAccount_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = tabPage1;
        }
    }
}
