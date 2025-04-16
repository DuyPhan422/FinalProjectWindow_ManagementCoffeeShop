using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Windows.Forms;

namespace Management_Coffee_Shop
{
    public partial class FormRegister : Form
    {
        private int seconds, minute;
        private string otp;
        private Register register=new Register();
        private bool flag = true;
        public FormRegister()
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }
        private void FormRegister_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None; // Xóa viền
            this.BackColor = Color.Magenta; // Chọn màu nền đặc biệt
            this.TransparencyKey = Color.Magenta;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTurnBack_MouseClick(object sender, MouseEventArgs e)
        {
            FormLogin formlogin=new FormLogin();
            this.Hide();
            formlogin.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (txtPassWord.Text == "")
            {
                errorProvider1.SetError(txtPassWord, "Phần này không được để trống");
                flag= false;
            }
            if (txtUserName.Text == "")
            {
                errorProvider1.SetError(txtUserName, "Phần này không được để trống");
                flag = false;
            }
            if (txtPassWordConfirm.Text == "")
            {
                errorProvider1.SetError(txtPassWordConfirm, "Phần này không được để trống");
                flag = false;
            }
            if (txtPassWordConfirm.Text != txtPassWord.Text && flag)
            {
                lblError.Text = "Mật khẩu không khớp";
            }else
            {
                if (txtPassWord.Text.Length > 7 && register.checkNumber(txtPassWord.Text) && register.checkUpperChar(txtPassWord.Text) && register.checkSpecialChar(txtPassWord.Text)) // pass phải có độ dài là 8 kí tự
                {
                    using (SqlConnection connection = Connection.StringConnection())
                    {
                        connection.Open();
                        string query = "SELECT Count(*) FROM account WHERE UserName=@UserName ";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserName", txtUserName.Text);
                            int result = Convert.ToInt32(command.ExecuteScalar());
                            if (result == 0)
                            {
                                guna2TabControl1.SelectedTab = tabPage2;
                                otp=register.send_OTP(txtEmail.Text);
                                seconds = 0;
                                minute = 3;
                                timer1.Start();
                            }
                            else lblError.Text= "Tài khoản này đã tồn tại";
                        }
                        connection.Close();
                    }
                }
                else
                {
                    errorProvider1.SetError(txtPassWord, "Mật khẩu phải chữ số, chữ in hoa, ký tự đặc biệt và độ dài tối thiểu là 8 kí tự");
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnSendAnother_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {

            if (txtOtp.Text.Length > 0)
            {
                if (int.Parse(txtOtp.Text) == int.Parse(otp))
                {
                    using (SqlConnection connection = Connection.StringConnection())
                    {
                        string new_Id = "C";
                        Random random = new Random();
                        flag = true;
                        int result = 1;
                        connection.Open();
                        string query = "SELECT Count(*) FROM account WHERE Id=@Id ";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            while (result!=0) {
                                new_Id += random.Next(100000, 1000000).ToString();
                                command.Parameters.AddWithValue("@Id", new_Id);
                                result = Convert.ToInt32(command.ExecuteScalar());
                                if (result != 0) new_Id = "C";
                            }
                        }
                        query = "INSERT INTO account (Id,UserName,PassWord,Email,Phone) VALUES (@Id,@UserName,@PassWord,@Email,@Phone)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id",new_Id);
                            command.Parameters.AddWithValue("@UserName",txtUserName.Text);
                            command.Parameters.AddWithValue("@PassWord",txtPassWord.Text);
                            command.Parameters.AddWithValue("@Email",txtEmail.Text);
                            command.Parameters.AddWithValue("@Phone",txtPhone.Text);
                            int rowsAffected = command.ExecuteNonQuery();
                        }
                        query = "INSERT INTO customerInformation (Id,Name,Address) VALUES (@Id,@Name,@Address)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", new_Id);
                            command.Parameters.AddWithValue("@Name", txtName.Text);
                            command.Parameters.AddWithValue("@Address", txtAddress.Text);
                            int rowsAffected = command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                    this.Hide();
                    FormLogin formLogin = new FormLogin();
                    formLogin.UserName = txtUserName.Text;
                    formLogin.PassWord = txtPassWord.Text;
                    formLogin.ShowDialog();
                }else
                {
                    lblThongBao.Text = "OTP bạn nhập không đúng";
                }
            } else
            {
                errorProvider1.SetError(txtOtp, "Phần này không được để trống");
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            flag = true;
            
            if (txtName.Text == "")
            {
                errorProvider1.SetError(txtName, "Phần này không được để trống");
                flag= false;
            }
            if (txtEmail.Text == "")
            {
                errorProvider1.SetError(txtEmail, "Phần này không được để trống");
                flag= false;
            }
            if (txtPhone.Text == " ")
            {
                errorProvider1.SetError(txtPhone, "Phần này không được để trống");
                flag= false;
            }
            if (flag) guna2TabControl1.SelectedTab = tabPage3;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = tabPage1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds == 0)
            {
                if (minute == 0)
                {
                    lblTimer.Text = "Mã OTP của bạn đã hết hạn";
                    timer1.Stop();
                    otp = null; // khóa otp
                }
                else
                {
                    seconds=59;
                    minute--;
                }
            } 
            lblTimer.Text =$"Mã OTP của bạn có hiệu lực trong {minute}:{seconds--.ToString()}";
        }
    }
}
