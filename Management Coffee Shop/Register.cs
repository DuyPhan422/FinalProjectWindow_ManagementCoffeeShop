using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Management_Coffee_Shop
{
    internal class Register: Login
    {
        public bool checkNumber(string input)
        {
            return Regex.IsMatch(input, "[0-9]");
        }
        public bool checkUpperChar(string input)
        {
            return Regex.IsMatch(input, "[A-Z]");
        }
        public bool checkSpecialChar(string input)
        {
            return Regex.IsMatch(input, @"[^a-zA-Z0-9]");
        }
        public override async Task<string> send_OTP(string toEmail, string context="Bạn đang đăng ký tài khoản", string subject="Register")
        {
            return await base.send_OTP(toEmail, context, subject);
        }
    }
}
