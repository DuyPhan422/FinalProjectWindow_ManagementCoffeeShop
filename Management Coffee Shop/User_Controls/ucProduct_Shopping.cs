using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.TwiML.Voice;

namespace Management_Coffee_Shop.User_Controls
{
    public partial class ucProduct_Shopping : UserControl
    {
        public ucProduct_Shopping()
        {
            InitializeComponent();
        }
        public void load(string id, int quantity, int price)
        {
            lblQTV.Text = quantity.ToString();
            lblPrice.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", price);
            DataTable dt = Drinks.get_history(id);
            lblDescribe.Text = dt.Rows[0]["Describe"].ToString();
            lblName_Product.Text = dt.Rows[0]["Name"].ToString();
            ptbImage.Image = Image.FromFile(dt.Rows[0]["Source_Image"].ToString());
        }
    }
}
