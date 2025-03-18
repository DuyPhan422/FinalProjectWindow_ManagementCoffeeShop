using System;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text;




namespace Management_Coffee_Shop
{
    internal class Login
    {
        public virtual string send_OTP(string toEmail, string context, string subject)
        {
            Random random = new Random();
            string otp = random.Next(1000000, 9999999).ToString();
            context += $"\nMã OTP của bạn là {otp} vui lòng không để lộ mã này cho bất kì ai";
            MailAddress fromaddress = new MailAddress("lmht312113@gmail.com");
            MailAddress toAddress = new MailAddress(toEmail);
            const string frompass = "vnpk wtrg auzf zthz";
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
            return otp;
        }

        public void SendSms()
        {
            
        }
    }
}

