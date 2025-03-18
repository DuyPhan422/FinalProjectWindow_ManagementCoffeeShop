using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Coffee_Shop.User_Controls
{
    public partial class UC_product : UserControl
    {
        public event EventHandler btnPice_clicked;
        private string _image, categories, id;
        public UC_product()
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
            get { return  categories; } set { categories = value; }
        }
        public string BTNPrice
        {
            get { return btnPrice.Text; }
            set { btnPrice.Text = value+"đ"; }
        }
        public string LBLName_Drinks
        {
            get { return lblName_Drinks.Text; }
            set { lblName_Drinks.Text = value; }
        }
        public string LBLDescribe_Drinks
        {
            set { lblDescribe_Drinks.Text= value; }
        }
        public string LBLRate_Drinks
        {
            set { lblRate_Drinks.Text = value; }
        }
        public string BTNReviews_Drinks
        {
            set { btnReviews_Drinks.Text = value +" Reviews"; }
        }
        public string PTBImage_Drinks
        {
            get { return _image; }
            set {
                _image = value;
                if (_image == null) ptbImage_Drinks.Image = null;
                else ptbImage_Drinks.Image = Image.FromFile(_image); 
            }
        }
    }
}
