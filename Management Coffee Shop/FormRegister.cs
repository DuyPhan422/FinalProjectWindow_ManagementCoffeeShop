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
        private FormLogin formLogin;
        public FormRegister(FormLogin login)
        {
            InitializeComponent();
            timer1.Interval = 1000;
            this.formLogin = login;
        }
        private void FormRegister_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None; // Xóa viền
            this.BackColor = Color.Magenta; // Chọn màu nền đặc biệt
            this.TransparencyKey = Color.Magenta;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void btnTurnBack_MouseClick(object sender, MouseEventArgs e)
        {
            FormLogin formlogin=new FormLogin();
            this.Hide();
            formlogin.ShowDialog();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
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
                    bool check=RegisterDB.Check(txtUserName.Text.Trim(),txtEmail.Text.Trim());
                    if (check)
                    {
                        guna2TabControl1.SelectedTab = tabPage2;
                        seconds = 0;
                        minute = 3;
                        timer1.Start();
                        otp = await register.send_OTP(txtEmail.Text);
                    }
                    else lblError.Text = "Tài khoản hoặc Email đã tồn tại";
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
                    RegisterDB.Create_Account(txtUserName.Text,txtPassWord.Text,txtEmail.Text,txtPhone.Text,txtName.Text,txtAddress.Text);
                    formLogin.UserName = txtUserName.Text;
                    formLogin.PassWord = txtPassWord.Text;
                    formLogin.Show();
                    this.Close();
                }
                else
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
