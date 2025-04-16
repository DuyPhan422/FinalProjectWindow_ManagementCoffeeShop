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
    public partial class Rate : Form
    {
        private string Enter_image= @"images\full_star.png", Leave_image= @"images\outline_star.png";
        private int indexStar = 1;
        private bool flag=true;
        public Rate(string lBLNAME)
        {
            InitializeComponent();
            lblName.Text = lBLNAME;
        }
        private void MouseEnter()
        {
            if (indexStar >4 ) btnFiveStar.Image = Image.FromFile(@"images\full_star.png");
            if (indexStar>3) btnFourStar.Image = Image.FromFile(@"images\full_star.png");
            if (indexStar>2) btnThreeStar.Image = Image.FromFile(@"images\full_star.png");
            if (indexStar>1) btnTwoStar.Image = Image.FromFile(@"images\full_star.png");
            if (indexStar>0) btnOneStar.Image = Image.FromFile(@"images\full_star.png");
        }
        private void MouseLeave(object sender, EventArgs e)
        {
            if (flag)
            {
                btnFiveStar.Image = Image.FromFile(@"images\outline_star.png");
                btnFourStar.Image = Image.FromFile(@"images\outline_star.png");
                btnThreeStar.Image = Image.FromFile(@"images\outline_star.png");
                btnTwoStar.Image = Image.FromFile(@"images\outline_star.png");
                btnOneStar.Image = Image.FromFile(@"images\outline_star.png");
            }
        }
        private void btnFiveStar_MouseEnter(object sender, EventArgs e)
        {
            indexStar = 5;
            MouseEnter();
        }
        private void btnFourStar_MouseEnter(object sender, EventArgs e)
        {
            indexStar = 4;
            MouseEnter();
        }
        private void btnThreeStar_MouseEnter(object sender, EventArgs e)
        {
            indexStar = 3;
            MouseEnter();
        }
        private void btnTwoStar_MouseEnter(object sender, EventArgs e)
        {
            indexStar = 2;
            MouseEnter();
        }
        private void btnOneStar_MouseEnter(object sender, EventArgs e)
        {
            indexStar = 1;
            MouseEnter();
        }
        private void btnFiveStar_Click(object sender, EventArgs e)
        {
            indexStar = 5;
            flag = false;
        }

        private void btnFourStar_Click(object sender, EventArgs e)
        {
            indexStar = 4;
            flag = false;
        }

        private void btnThreeStar_Click(object sender, EventArgs e)
        {
            indexStar = 3;
            flag = false;
        }

        private void btnTwoStar_Click(object sender, EventArgs e)
        {
            indexStar = 2;
            flag = false;
        }
        private void btnOneStar_Click(object sender, EventArgs e)
        {
            indexStar = 1;
            flag = false;
        }


        private void btnSender_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Cảm ơn bạn đã đánh giá ", "THANK YOU");
            this.Close();
        }
    }
}
