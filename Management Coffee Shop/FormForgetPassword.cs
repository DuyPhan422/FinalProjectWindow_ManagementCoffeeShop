using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public FormForgetPassword()
        {
            InitializeComponent();
        }
        Random random=new Random();
        string toEmail_temp;
        string otp;
        private void btnTurnBack_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        private void send_OTP(string toEmail)
        {
            otp = random.Next(1000000, 9999999).ToString();
            string context = $"Mã OTP của bạn là {otp} vui lòng không để lộ mật khẩu của bạn cho bất kì ai";
            MailAddress fromaddress = new MailAddress("lmht312113@gmail.com");
            MailAddress toAddress = new MailAddress(toEmail);
            const string frompass = "klpy aojn tkpv bgsh";
            const string subject = "OTP code";
            var smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromaddress.Address, frompass),
                Timeout = 200000
            };
            using (var message = new MailMessage(fromaddress, toAddress)
            {
                Subject = subject,
                Body = context,
            })
            {
                smtp.Send(message);
            }
        }
        private void btnRequest_Click_2(object sender, EventArgs e)
        {
            toEmail_temp = txtEmail.Text;
            txtEmail.Clear();
            txtUserName.Clear();
            send_OTP(toEmail_temp);
            MessageBox.Show("OTP đã được gửi thành công");
            TabControl.SelectedTab = tabPage4;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnSendanother_Click(object sender, EventArgs e)
        {
            send_OTP(toEmail_temp);
            MessageBox.Show("OTP đã được gửi thành công \nVui lòng vào email của bạn để kiểm tra");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string random_password = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string new_password="";
            if (txtOTP.Text == otp)
            {
                for (int i = 0; i < 7; i++)
                {
                    new_password += random_password[random.Next(0, random_password.Length)].ToString();
                }
                MessageBox.Show($"Vui lòng không tiết lộ mật khẩu cho bất kì ai \nMật khẩu mới của bạn là {new_password}");
            } else
            {
                MessageBox.Show($"Mã OTP của bạn không chính xác");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void btnChangePassWord_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab=tabPage1;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword_Change.Text != txtNewPassword_Change.Text)
            {
                MessageBox.Show("Mật khẩu không khớp");
            } else
            {

            }
        }
    }
}
