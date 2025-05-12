using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Coffee_Shop
{
    internal class ForgetPassWord: Login
    {
        private string Account, Password, Email, Phone;
        Random random = new Random();
        public ForgetPassWord() {
        }
        public ForgetPassWord(string Account,string Password,string Email,string Phone)
        {
            this.Account = Account;
            this.Password = Password;
            this.Email = Email;
            this.Phone = Phone;
        }
        public override async Task<string> send_OTP(string toEmail, string context = "Bạn đang đăng lấy lại mật khẩu", string subject = "Take Password")
        {
            return await base.send_OTP(toEmail, context, subject);
        }
        public string Create_PassWord()
        {
            string random_password = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string new_password = "";
            for (int i = 0; i < 7; i++)
            {
                new_password += random_password[random.Next(0, random_password.Length)].ToString();
            }
            return new_password;
        }
        public void sms()
        {
            base.SendSms();
        }
        public string Get_Email
        {
            get { return this.Email; }
        }
        public string Get_Phone
        {
            get { return this.Email; }
        }
        public string Get_UserName
        {
            get { return this.Account; }
        }
    }
}
