using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using UserControl = System.Windows.Forms.UserControl;

namespace Management_Coffee_Shop.User_Controls
{
    public partial class Product : UserControl
    {
        public event EventHandler btnPice_clicked,ptbImage_Drinks_clicked;
        private string _image, categories, id;
        public Product()
        {
            InitializeComponent();
            lblStatus.Hide();
        }
        private void btnPrice_Click(object sender, EventArgs e)
        {
            btnPice_clicked?.Invoke(this, EventArgs.Empty);
        }
        public string ID
        {
            get { return id; }
            set { this.id = value; }
        }
        public string Categories
        {
            get { return categories; }
            set { categories = value; }
        }
        public string BTNPrice
        {
            get { return btnPrice.Text; }
            set { btnPrice.Text = value + "đ"; }
        }
        public string LBLName_Drinks
        {
            get { return lblName_Drinks.Text; }
            set { lblName_Drinks.Text = value; }
        }
        public string LBLDescribe_Drinks
        {
            get { return lblDescribe_Drinks.Text;}
            set { lblDescribe_Drinks.Text = value; }
        }
        public string LBLRate_Drinks
        {
            get { return lblRate_Drinks.Text;}
            set { lblRate_Drinks.Text = value; }
        }

        private void UC_product_MouseEnter(object sender, EventArgs e)
        {
            lblName_Drinks.Text = "Hello";
        }

        private void UC_product_MouseLeave(object sender, EventArgs e)
        {
            lblName_Drinks.Text = "Hi";
        }

        private void ptbImage_Drinks_Click(object sender, EventArgs e)
        {
            ptbImage_Drinks_clicked?.Invoke(this, EventArgs.Empty);
        }

        public string BTNReviews_Drinks
        {
            get { return btnReviews_Drinks.Text; }
            set { btnReviews_Drinks.Text = value + " Reviews"; }
        }
        public string PTBImage_Drinks
        {
            get { return _image; }
            set
            {
                _image = value;
                if (_image == null) ptbImage_Drinks.Image = null;
                else ptbImage_Drinks.Image = Image.FromFile(_image);
            }
        }
    }
}
