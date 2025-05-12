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
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Guna.UI2.AnimatorNS;
using static System.Windows.Forms.LinkLabel;
using System.Threading.Tasks;




namespace Management_Coffee_Shop
{
    internal class Login
    {
        private class TokenInfo
        {
            public string UserId { get; set; }
            public string Token { get; set; }
            public string LastLogin { get; set; }
        }
        public static void delete_Token(string user_Id) 
        {
            var machineName=Environment.MachineName;
            string path = "system_Token.txt";
            string json = File.ReadAllText(path);
            (string[] lines, bool success) = take_UserToken();
            if (!success) return;
            Dictionary<string, List<TokenInfo>> token_Infor = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<TokenInfo>>>(json);
            if (token_Infor != null && token_Infor.ContainsKey(machineName))
            {
                List<string> newLines = new List<string>(lines);
                foreach (var token in token_Infor[machineName])
                {
                    if (token.UserId == user_Id)
                    {
                        for (int i = newLines.Count - 1; i >= 0; i--)
                        {
                            if (newLines[i] == token.Token)
                            {
                                newLines.RemoveAt(i);
                            }
                        }
                    }
                }
                token_Infor[machineName].RemoveAll(token => token.UserId == user_Id);
                if (token_Infor[machineName].Count == 0)
                {
                    token_Infor.Remove(machineName);
                }
                string updatedJson = System.Text.Json.JsonSerializer.Serialize(token_Infor, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, updatedJson);
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string tokenFilePath = Path.Combine(appDataPath, "Token_Management_Coffee_Shop", "user_Token.txt");
                File.WriteAllLines(tokenFilePath, newLines);
            }
        }
        private static (string[] line,bool success) take_UserToken()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string FolderPath = Path.Combine(appDataPath, "Token_Management_Coffee_Shop");
            string[] lines=new string[0];
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
                return (lines, false);
            }
            string tokenFilePath = Path.Combine(FolderPath, "user_Token.txt");
            if (!File.Exists(tokenFilePath))
            {
                File.WriteAllText(tokenFilePath, ""); 
                return (lines, false);
            }
            lines=File.ReadAllLines(tokenFilePath);
            if (lines.Length==0)return (lines, false);
            return (lines, true);            
        }
        public static bool check_Token(string user_Id)
        {
            var machineName = Environment.MachineName;
            if (!File.Exists("system_Token.txt")) return false;
            (string[] lines,bool success) = take_UserToken();
            if (!success) return false;
            string json=File.ReadAllText("system_Token.txt");
            Dictionary<string, List<TokenInfo>> token_Infor= System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<TokenInfo>>>(json);
            bool flag=false;
            foreach(var token in token_Infor[machineName])
            {
                if (token.UserId == user_Id)
                {
                    foreach(string line in lines)
                    {
                        if (token.Token == line)
                        {
                            flag = true;
                            break;
                        }
                    }
                    break;
                }
            }
            if (flag)
            {
                create_NewToken(user_Id);
                return true;
            }
            return false;
        }
        public static void create_NewToken(string user_Id)
        {
            bool check = true;
            string path = "system_Token.txt";
            var machineName= Environment.MachineName;
            if (!File.Exists("system_Token.txt")) return ;
            string json = File.ReadAllText(path);
            Dictionary<string, List<TokenInfo>> token_Infor;
            if (string.IsNullOrEmpty(json)) token_Infor=new Dictionary<string, List<TokenInfo>>();
            else token_Infor = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<TokenInfo>>>(json);
            string new_Token = create_Token();
            if (!token_Infor.ContainsKey(machineName))token_Infor[machineName] = new List<TokenInfo>();
            foreach (var token in token_Infor[machineName])
            {
                if (user_Id==token.UserId)
                {
                    token.Token = new_Token;
                    token.LastLogin = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    check=false;
                    break;
                }
            }
            if (check)
            {
                TokenInfo tokenInfo = new TokenInfo { UserId = user_Id, Token = new_Token, LastLogin = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}" };
                token_Infor[machineName].Add(tokenInfo);
            }
            string read = System.Text.Json.JsonSerializer.Serialize(token_Infor, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, read);
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string tokenFilePath = Path.Combine(appDataPath, "Token_Management_Coffee_Shop", "user_Token.txt");
            File.WriteAllText(tokenFilePath, "");
            foreach (var token in token_Infor[machineName]) File.AppendAllText(tokenFilePath, token.Token+Environment.NewLine);
        }
        public static (bool success,List<string> userId_List) check_machineName()
        {
            string json = File.ReadAllText("system_Token.txt");
            List<string> userId_List = new List<string>();
            if (string.IsNullOrEmpty(json)) return(false,userId_List);
            Dictionary<string, List<TokenInfo>> token_Infor;
            token_Infor = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, List<TokenInfo>>>(json);
            if (!token_Infor.ContainsKey(Environment.MachineName)) return (false,userId_List);
            foreach (var token in token_Infor[Environment.MachineName])userId_List.Add(token.UserId);
            int len=userId_List.Count;
            (string[] lines, bool success) = take_UserToken();
            for (int i = 0; i < len; i++)
            {
                bool flag = false;
                foreach (var token in token_Infor[Environment.MachineName])
                {
                    if (userId_List[i] == token.UserId)
                    {
                        foreach (string line in lines)
                        {
                            if (token.Token == line)
                            {
                                flag = true;
                                break;
                            }
                        }
                        break;
                    }
                }
                if (!flag) return (false, userId_List);
            }
            return (true,userId_List);
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
        public virtual async Task<string> send_OTP(string toEmail, string context, string subject)
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
                await smtp.SendMailAsync(message);
            }
            return otp;
        }
        public void SendSms()
        {
            //fire Base Cloud Messaging
        }
    }
}

