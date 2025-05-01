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
    public partial class ucComment : UserControl
    {
        public ucComment()
        {
            InitializeComponent();

        }
        public string PTBImage
        {
            set { 
                if (value != null && value.Trim()!="") ptbImage_User.Image = Image.FromFile(value); 
                else ptbImage_User.Image = Image.FromFile(@"..\..\Management coffee shop_image\edited_image-removebg-preview.png");
            }
        }
        public string LBLName
        {
            set { lblName_User.Text = value; }
        }
        public string TXTComment
        {
            set { txtComment.Text = value; }
        }
        public string LBLTime
        {
            set { lblTime.Text = value; }
        }
        public void set_Rate(byte rate)
        {
            string source_Image = @"..\..\Management coffee shop_image\hinh-nen-ngoi-sao-1024x1024-removebg-preview.png";
            if (rate >= 1)ptbFirstStars.Image=Image.FromFile(source_Image);   
            if (rate >= 2) ptbSecondStars.Image = Image.FromFile(source_Image);
            if (rate >= 3) ptbThirdStars.Image=Image.FromFile (source_Image);
            if (rate >= 4) ptbFourthStars.Image=Image.FromFile(source_Image);
            if (rate == 5) ptbFifthStars.Image = Image.FromFile(source_Image);
        }
    }
}
