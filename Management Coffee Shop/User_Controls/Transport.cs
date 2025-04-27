using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.TwiML.Voice;

namespace Management_Coffee_Shop.User_Controls
{
    public partial class Transport : UserControl
    {
        private static int current_ID = 1;
        private string Id,UserId,_image;
        public Transport(string Id)
        {
            InitializeComponent();
            btnRate.Hide();
            this.Id = Id;
        }
        private void btnRate_Click(object sender, EventArgs e)
        {
            Rate rate =new Rate(btnName.Text,Id,UserId,Convert.ToByte(lblQTV.Text));
            rate.Show();
        }
        public void Show_btnRate()
        {
            btnRate.Show();
        }
        public string ID
        {
            get { return this.Id; }
        }
        public string PTBImage
        {
            get { return _image; }
            set
            {
                _image = value;
                if (_image == null) ptbImage.Image = null;
                else ptbImage.Image = Image.FromFile(_image);
            }
        }
        public string BTNName
        {
            get { return btnName.Text; }
            set { btnName.Text = value; }
        }
        public string LBLSizeTopping
        {
            get { return lblSizeTopping.Text; }
            set { lblSizeTopping.Text = value; }
        }
        public string LBLNote
        {
            get { return lblNote.Text; }
            set { lblNote.Text = value; }
        }
        public string LBLPrice
        {
            get { return lblPrice.Text; }
            set
            {
                lblPrice.Text = value;
            }
        }
        public string LBLQTV
        {
            get { return lblQTV.Text; }
            set
            {
                lblQTV.Text = value;
            }
        }
        public string LBLAmount
        {
            get { return lblAmount.Text; }
            set { lblAmount.Text = value; }
        }
    }
}
