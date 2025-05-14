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
    public partial class formManager : Form
    {
        public formManager()
        {
            InitializeComponent();
        }
        void Select_btn(Button btn)
        {
            switch (btn.Name)
            {
                case "btnProduct": btn.ImageIndex = 1; pbSlide.Visible = true; pbSlide.SendToBack(); break;
                case "btnIncome": btn.ImageIndex = 3; pbSlide2.Visible = true; pbSlide2.SendToBack(); break;
                case "btnStaff": btn.ImageIndex = 7; pbSlide3.Visible = true; pbSlide3.SendToBack(); break;
                default: break;
            }
            btn.BackColor = Color.White;
        }
        void Reset_btn()
        {
            foreach (var ctl in pnl_test.Controls.OfType<Button>())
            {
                ctl.BackColor = Color.FromArgb(249, 240, 197);
                //ctl.Refresh();
                foreach (var pb in pnl_test.Controls.OfType<PictureBox>())
                {
                    pb.Visible = false;
                }

            }
            btnProduct.ImageIndex = 0;
            btnIncome.ImageIndex = 2;
            btnStaff.ImageIndex = 6;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Reset_btn();
            Select_btn(btnProduct);
            ucProduct uc_pro = new ucProduct();
            uc_pro.Dock = DockStyle.Fill;
            pnlPage2.Controls.Clear();
            pnlPage2.Controls.Add(uc_pro);
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            Reset_btn();
            Select_btn(btnIncome);
            ucIncome uc_ic = new ucIncome();
            uc_ic.Dock = DockStyle.Fill;
            pnlPage2.Controls.Clear();
            pnlPage2.Controls.Add(uc_ic);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            Reset_btn();
            Select_btn(btnStaff);
            ucStaff uc_s = new ucStaff();
            uc_s.Dock = DockStyle.Fill;
            pnlPage2.Controls.Clear();
            pnlPage2.Controls.Add(uc_s);
        }

        private void btnFacility_Click(object sender, EventArgs e)
        {
            Reset_btn();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
       
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void formManager_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in pnl_test.Controls)
            {
                if (ctl is Button b)
                {
                    b.FlatStyle = FlatStyle.Flat;
                    b.UseVisualStyleBackColor = false;
                    b.BackColor = Color.FromArgb(249, 240, 197);
                }
            }
            Reset_btn();
            Select_btn(btnProduct);
            ucProduct uc_pro = new ucProduct();
            uc_pro.Dock = DockStyle.Fill;
            pnlPage2.Controls.Clear();
            pnlPage2.Controls.Add(uc_pro);
        }
    }
}
