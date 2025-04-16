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
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.Json;




namespace Management_Coffee_Shop
{
    public class TokenInfo
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string LastLogin { get; set; }
    }
    internal class Login
    {
        private class TokenInfo
        {
            public string UserId { get; set; }
            public string Token { get; set; }
            public string LastLogin { get; set; }
        }
        private static (string userToken,bool success) take_UserToken()
        {
            string userToken = File.ReadAllText(@"..\..\user_Token.txt");
            // nếu không có token
            if (userToken.Length == 0)return (userToken,false); 
            return (userToken,true);            
        }
        public static (bool success,string user_Id) check_Token()
        {
            string path = "system_Token.txt";
            if (!File.Exists("system_Token.txt")) return (false,"");
            (string user_Token,bool success) = take_UserToken();
            if (!success) return (false, "");
            string json=File.ReadAllText(path);
            Dictionary<string, TokenInfo> token_Infor= System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, TokenInfo>>(json);
            if (!token_Infor.ContainsKey(Environment.MachineName)) return (false, "");
            if (token_Infor[Environment.MachineName].Token == user_Token)
            {
                create_NewToken(token_Infor[Environment.MachineName].UserId);
                return (true,token_Infor[Environment.MachineName].UserId);
            }
            create_NewToken(token_Infor[Environment.MachineName].UserId);
            return (false, "");
        }
        public static void create_NewToken(string user_Id)
        {
            string path = "system_Token.txt";
            if (!File.Exists("system_Token.txt")) return ;
            if (!File.Exists(@"..\..\user_Token.txt")) return;
            string json = File.ReadAllText(path);
            Dictionary<string, TokenInfo> token_Infor;
            if (string.IsNullOrEmpty(json)) token_Infor=new Dictionary<string,TokenInfo>();
            else token_Infor = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, TokenInfo>>(json);
            string new_Token = create_Token();
            token_Infor[Environment.MachineName] = new TokenInfo { UserId = user_Id, Token = new_Token, LastLogin = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}" };
            string read = System.Text.Json.JsonSerializer.Serialize(token_Infor, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, read);
            File.WriteAllText(@"..\..\user_Token.txt", new_Token);
        }
        private static string create_Token()
        {
            byte length = 64;
            long ticks=DateTime.Now.Ticks;
            string mac= "000000000000";
            int pid = System.Diagnostics.Process.GetCurrentProcess().Id;
            foreach(NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                    mac= nic.GetPhysicalAddress().ToString();
            }
            byte[] seedBytes = Encoding.UTF8.GetBytes($"{ticks}-{pid}-{mac}-{Guid.NewGuid()}");
            Random rand = new Random();
            int number1 = rand.Next(1,255);
            int number2 = rand.Next(1,255);
            for (int i = 0; i < seedBytes.Length; i++)
            {
                seedBytes[i] = (byte)((seedBytes[i] ^ (i * number1)) + (i * number2) % 256);
            }
            // Chuyển thành token string base36 (0-9A-Z)
            StringBuilder token = new StringBuilder();
            foreach (byte b in seedBytes)
            {
                token.Append(ToBase36(b));
            }
            if (token.Length < 32)
            {
                Guid guid  = Guid.NewGuid();
                byte[] addBytes=Encoding.UTF8.GetBytes(guid.ToString());
                byte i = 0;
                while (token.Length < length)
                {
                    token.Append(ToBase36(addBytes[i]));
                    i++;
                }
            }
            return token.ToString();
        }
        private static string ToBase36(int value)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return chars[value % chars.Length].ToString();
        }
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

