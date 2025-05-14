using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Coffee_Shop
{
    public partial class FormForgetPassword : Form
    {
        private int seconds, minute;
        private ForgetPassWord infor= new ForgetPassWord();
        private string otp;
        private FormLogin formLogin;
        public FormForgetPassword(FormLogin formLogin)
        {
            InitializeComponent();
            this.formLogin = formLogin;
            this.FormBorderStyle = FormBorderStyle.None; // Xóa viền
            this.BackColor = Color.Magenta; // Chọn màu nền đặc biệt
            this.TransparencyKey = Color.Magenta;
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        private void btnRequest_Click_2(object sender, EventArgs e)
        {
            if (txtUserName.Text == "") errorProvider1.SetError(txtUserName, "Phần này không được để trống");
            else
            {
                infor = ForgetPasswordDB.send_Request(infor, txtUserName.Text);
                if (infor != null)
                {
                    lblshowAccount.Text = $"Your Account: {txtUserName.Text}";
                    TabControl.SelectedTab = tabPage5;
                }
                else
                {
                    MessageBox.Show("Username không tồn tại");
                }
            }
        }
        public void change_TabPage()
        {
            TabControl.SelectedTab = tabPage1;
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private async void  btnSendanother_Click(object sender, EventArgs e)
        {
            otp= await infor.send_OTP(infor.Get_Email);
            MessageBox.Show("OTP đã được gửi thành công \nVui lòng vào email của bạn để kiểm tra");
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {

        }
        private void btnConfirm_OTP_Click(object sender, EventArgs e)
        {
            if (txtOTP.Text == otp)
            {
                string new_password = infor.Create_PassWord();
                MessageBox.Show($"Vui lòng không tiết lộ mật khẩu cho bất kì ai \nMật khẩu mới của bạn là {new_password}");
                ForgetPasswordDB.update_password(infor, new_password);
                formLogin.UserName = infor.Get_UserName ;
                formLogin.PassWord = new_password;
                this.Close();
                formLogin.ShowDialog();
            }
            else
            {
                txtOTP.Clear();
                MessageBox.Show($"Mã OTP của bạn không chính xác");
            }
        }

        private void btnSendSMS_Click_1(object sender, EventArgs e)
        {
            infor.sms();
            TabControl.SelectedTab = tabPage2;
        }

        private void btnConfirm_SMS_Click(object sender, EventArgs e)
        {
            infor.sms();
        }
        private async void btnSendanother_Click_1(object sender, EventArgs e)
        {
            otp = await infor.send_OTP(infor.Get_Email);
            TabControl.SelectedTab = tabPage4;
            seconds = 0;
            minute = 3;
            timer1.Start();
        }

        private async void btnSendOTP_Click(object sender, EventArgs e)
        {
            otp = await infor.send_OTP(infor.Get_Email);
            TabControl.SelectedTab = tabPage4;
            seconds = 0;
            minute = 3;
            timer1.Start();
        }

        private void btnChange_Click_1(object sender, EventArgs e)
        {
            lblAnnouncement_ChangePW.Text = "";
            if (string.IsNullOrWhiteSpace(txtUserName_Change.Text))
            {
                errorProvider1.SetError(txtUserName_Change, "Phần này không được để trống");
                return;
            }else if(string.IsNullOrWhiteSpace(txtCurrentPassword_Change.Text))
            {
                errorProvider1.SetError(txtCurrentPassword_Change, "Phần này không được để trống");
                return;
            } else if (string.IsNullOrWhiteSpace(txtNewPassword_Change.Text))
            {
                errorProvider1.SetError(txtNewPassword_Change, "Phần này không được để trống");
                return;
            }else if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "Phần này không được để trống");
                return;
            }
            if (txtConfirmPassword.Text != txtNewPassword_Change.Text)lblAnnouncement_ChangePW.Text = "Mật khẩu không khớp";
            else
            {
                if (txtCurrentPassword_Change.Text == txtNewPassword_Change.Text)lblAnnouncement_ChangePW.Text = "Mật khẩu mới trùng với mật khẩu cũ";
                else
                {

                }
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            formLogin.Close();
        }

        // bộ đếm thời gian
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
                    seconds = 59;
                    minute--;
                }
            }
            lblTimer.Text = $"Mã OTP của bạn có hiệu lực trong {minute}:{seconds--.ToString()}";
        }
    }
}
