using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Coffee_Shop
{
    public partial class Rate : Form
    {
        private byte indexStar = 1,Sales;
        private bool flag=true;
        private string ProductId, UserId;
        public Rate(string lBLNAME,string ProductId,string UserId,byte Sales)
        {
            InitializeComponent();
            lblName.Text = lBLNAME;
            this.ProductId = ProductId;
            this.UserId = UserId;
            this.Sales = Sales;
        }
        public class History
        {
            public string ProductId { get; set; }
            public string UserId { get; set; }
            public string Comment { get; set; }
            public byte Rank { get; set; }
            public string Time { get; set; }
        }
        private void MouseEnter()
        {
            if (indexStar >4 ) btnFiveStar.Image = Image.FromFile(@"..\..\Management coffee shop_image\full_star.png");
            if (indexStar>3) btnFourStar.Image = Image.FromFile(@"..\..\Management coffee shop_image\full_star.png");
            if (indexStar>2) btnThreeStar.Image = Image.FromFile(@"..\..\Management coffee shop_image\full_star.png");
            if (indexStar>1) btnTwoStar.Image = Image.FromFile(@"..\..\Management coffee shop_image\full_star.png");
            if (indexStar>0) btnOneStar.Image = Image.FromFile(@"..\..\Management coffee shop_image\full_star.png");
        }
        private void MouseLeave(object sender, EventArgs e)
        {
            if (flag)
            {
                btnFiveStar.Image = Image.FromFile(@"..\..\Management coffee shop_image\outline_star.png");
                btnFourStar.Image = Image.FromFile(@"..\..\Management coffee shop_image\outline_star.png");
                btnThreeStar.Image = Image.FromFile(@"..\..\Management coffee shop_image\outline_star.png");
                btnTwoStar.Image = Image.FromFile(@"..\..\Management coffee shop_image\outline_star.png");
                btnOneStar.Image = Image.FromFile(@"..\..\Management coffee shop_image\outline_star.png");
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
            MessageBox.Show(indexStar.ToString());
            string path = @"..\..\history_Rate.txt";
            History newRating = new History
            {
                ProductId=this.ProductId,
                UserId=this.UserId,
                Comment=txtComment.Text,
                Rank=this.indexStar,
                Time = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}"
            };
            Drinks.set_Rate(this.ProductId, this.indexStar,(int)this.Sales);
            MessageBox.Show("Cảm ơn bạn đã đánh giá");
            string jsonLine = System.Text.Json.JsonSerializer.Serialize(newRating);
            File.AppendAllText(path, jsonLine + Environment.NewLine);
            this.Close();
        }
    }
}
