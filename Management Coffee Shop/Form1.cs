using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Coffee_Shop
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None; // Xóa viền
            this.BackColor = Color.Magenta; // Chọn màu nền đặc biệt
            this.TransparencyKey = Color.Magenta;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister formregister=new FormRegister();
            formregister.ShowDialog();
        }

        private void btnForgetpassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormForgetPassword formforget=new FormForgetPassword();
            formforget.ShowDialog();
        }
    }
}
