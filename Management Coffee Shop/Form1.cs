using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Management_Coffee_Shop.Rate;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Management_Coffee_Shop
{
    public partial class FormLogin : Form
    { 
        private List<string> userName_List=new List<string>();
        private List<string> userId_List=new List<string>();
        private System.Windows.Forms.Timer Lock_Tick = new Timer();
        private byte second,level;
        private string otp,ID;
        private bool flag;
        private TimeSpan timeLeft,OTP_time;
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
                userName_List=LoginDB.get_UserName(userId_List);
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
                    login_Customer(clicked_Button.Tag.ToString(), true);
                }
            }
        }
        
        private void login_Customer(string Id, bool check)
        {
            DataTable dt=LoginDB.get_InforCustomer(Id);
            FormCustomer formCustomer = new FormCustomer(Id, dt.Rows[0]["Name"].ToString(), dt.Rows[0]["Address"].ToString(), dt.Rows[0]["Email"].ToString(), dt.Rows[0]["Date"].ToString(), dt.Rows[0]["Image"].ToString(), this, check);
            formCustomer.Show();
            this.Hide();
        }
        private void Check_Lock(byte passwordFail,string username)
        {
            if (passwordFail%4 == 3)
            {
                //DateTime parsedTime = DateTime.ParseExact(Lock, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                //DateTime now = DateTime.Now;
                //TimeSpan diff = now - parsedTime;
                Level_Lock(passwordFail,username);
                
            }
            
        }
        private void Level_Lock(byte passwordFail,string username)
        {
            level = (byte)(passwordFail / 4);
            int lockTimeSeconds=0;
            if (level == 0)
            {
                // khóa 1 phút
                DateTime unLockTime = DateTime.Now.AddMinutes(1);
                string formatted_unLockTime = unLockTime.ToString("dd/MM/yyyy HH:mm:ss");
                LoginDB.Locking(username, formatted_unLockTime);
                lockTimeSeconds = 60;
            }
            else if (level == 1)
            {
                DateTime unLockTime = DateTime.Now.AddMinutes(5);
                string formatted_unLockTime = unLockTime.ToString("dd/MM/yyyy HH:mm:ss");
                LoginDB.Locking(username, formatted_unLockTime);
                lockTimeSeconds = 300;
            }
            else if (level == 2)
            {
                DateTime unLockTime = DateTime.Now.AddMinutes(30);
                string formatted_unLockTime = unLockTime.ToString("dd/MM/yyyy HH:mm:ss");
                LoginDB.Locking(username, formatted_unLockTime);
                lockTimeSeconds = 1800;
            }
            else if (level == 3)
            {
                DateTime unLockTime = DateTime.Now.AddHours(1);
                string formatted_unLockTime = unLockTime.ToString("dd/MM/yyyy HH:mm:ss");
                LoginDB.Locking(username, formatted_unLockTime);
                lockTimeSeconds = 60*60;
            }
            else
            {
                DateTime unLockTime = DateTime.Now.AddHours(8);
                string formatted_unLockTime = unLockTime.ToString("dd/MM/yyyy HH:mm:ss");
                LoginDB.Locking(username, formatted_unLockTime);
                lockTimeSeconds = 60 * 60*8;
            }
            timeLeft = TimeSpan.FromSeconds(lockTimeSeconds);
            Lock_Tick.Tick -= Lock_Ticked;
            Lock_Tick.Tick += Lock_Ticked;
            Lock_Tick.Interval = 1000;
            Lock_Tick.Start();
        }
        private void Lock_Ticked(object sender, EventArgs e)
        {
            //DateTime parsedTime = DateTime.ParseExact(timeLeft, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            if (timeLeft.TotalSeconds > 0)
            {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                lblOutput.Text = $"Thời gian còn lại {timeLeft.ToString(@"hh\:mm\:ss")}";
            }
            else
            {
                Lock_Tick.Stop();
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
            FormForgetPassword formforget = new FormForgetPassword(this);
            formforget.ShowDialog();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            (string ID,string Email,string Password,string Lock,byte PasswordFail,bool success)=LoginDB.get_Infor(txtUserName.Text);
            this.ID = ID;
            if (success)
            {
                bool flag_lock = false;
                if (!string.IsNullOrEmpty(Lock))
                {
                    DateTime lockingTime = DateTime.ParseExact(Lock, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    if (DateTime.Now <= lockingTime)
                    {
                        lblOutput.Text = "Tài khoản đang bị khóa";
                        timeLeft = lockingTime - DateTime.Now;
                        Lock_Tick.Tick -= Lock_Ticked;
                        Lock_Tick.Tick += Lock_Ticked;
                        Lock_Tick.Interval = 1000;
                        flag_lock = true;
                        flag = true;
                        Lock_Tick.Start();
                    }
                }
                if (!flag_lock)
                {
                    if (txtPassWord.Text.Trim() != Password.Trim())
                    {
                        lblOutput.Text = "Sai thông tin đăng nhập hoặc mật khẩu";
                        txtPassWord.Clear();
                        flag = true;
                        PasswordFail += 1;
                        LoginDB.update_PassWordFail(txtUserName.Text);
                        Check_Lock(PasswordFail, txtUserName.Text);
                    }
                    else if (ID[0] == 'C')
                    {
                        bool check = false;
                        if (userName_List.Count > 0)
                        {
                            foreach (string us in userName_List)
                            {
                                if (us.Trim() == txtUserName.Text.Trim())
                                {
                                    check = true;
                                    break;
                                }
                            }
                        }
                        if (check) login_Customer(ID, true);
                        else login_Customer(ID, false);
                    }
                    else if (ID[0] == 'E')
                    {
                        guna2TabControl1.SelectedTab = tabPage3;
                        Login login = new Login();
                        OTP_time = TimeSpan.FromSeconds(180);
                        timer1.Start();
                        otp = await login.send_OTP(Email, "Mã OTP của bạn là: ", "Đăng Nhập");
                    }
                    else
                    {
                        guna2TabControl1.SelectedTab = tabPage3;
                        Login login = new Login();
                        OTP_time = TimeSpan.FromSeconds(180);
                        timer1.Start();
                        otp = await login.send_OTP(Email, "Mã OTP của bạn là: ", "Đăng Nhập");
                    }
                } 
            }else
            {
                lblOutput.Text = "Sai thông tin đăng nhập hoặc mật khẩu";
                txtPassWord.Clear();
                flag = true;
            }
        
        }
        private void btnLogin_OTP_Click(object sender, EventArgs e)
        {
            if (otp == txtOtp.Text.Trim())
            {
                if (this.ID[0] == 'E')
                {
                    DataTable dt = LoginDB.get_InforEmployee(this.ID);
                    FormEmployee employee = new FormEmployee(this.ID,dt.Rows[0]["LastName"].ToString(), dt.Rows[0]["Address"].ToString(), dt.Rows[0]["Email"].ToString(), dt.Rows[0]["BirthDate"].ToString(), dt.Rows[0]["Source_Image"].ToString(),this);
                    employee.Show();
                    timer1.Stop();
                    Lock_Tick.Stop();
                    txtUserName.Clear();
                    txtPassWord.Clear();
                    txtOtp.Clear();
                }
                else
                {
                    formManager formManager=new formManager();
                    formManager.Show();
                }
            }else
            {
                guna2TabControl1.SelectedTab = tabPage1;
                otp = "";
                ID = "";
                txtUserName.Clear();
                txtPassWord.Clear();
                txtOtp.Clear();
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (OTP_time.TotalSeconds > 0)
            {
                OTP_time = OTP_time.Subtract(TimeSpan.FromSeconds(1));
                lblAnnoucement_OTP.Text = $"Thời gian còn lại {OTP_time.ToString(@"mm\:ss")}";
            }else
            {
                lblAnnoucement_OTP.Text = "Mã OTP của bạn đã hết hạn";
                timer1.Stop();
                otp = null;
            }
        }
        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                Lock_Tick.Stop();
                flag = false;
                lblOutput.Text = "";
            }
        }
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                Lock_Tick.Stop();
                flag = false;
                lblOutput.Text = "";
            }
        }
        private void btnLoginWithAnotherAccount_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = tabPage1;
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
        public List<string> UserName_List
        {
            get { return userName_List; }
            set { userName_List = value; }
        }
        public List<string> UserId_List
        {
            get { return userId_List; }
            set { userId_List = value; }
        }
    }
}
