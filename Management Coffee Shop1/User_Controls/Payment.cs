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
    public partial class Payment : UserControl
    {
        public event EventHandler btnRemove_clicked,btnChoose_clicked;
        public event EventHandler<int> btnUp_clicked, btnDown_clicked;
        private string id, image_choose = @"images\check.png", image_PTB_image;
        public int value;
        public Payment()
        {
            InitializeComponent();
            btnChoose.Image = Image.FromFile(image_choose);
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            btnRemove_clicked?.Invoke(this, EventArgs.Empty);
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            btnChoose_clicked?.Invoke(this, EventArgs.Empty);
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (value<999) value++;
            btnUp_clicked?.Invoke(this, value);
        }
        private void btnDown_Click_1(object sender, EventArgs e)
        {
            if (value>1) value--;
            btnDown_clicked?.Invoke (this, value);
        }
        public string BTNChoose
        {
            get { return image_choose; }
            set 
            {
                image_choose = value;
                if (image_choose == null) btnChoose.Image = null;
                else btnChoose.Image=Image.FromFile(image_choose); 
            }
        }
        public int LBLQTV
        {
            get { return int.Parse(lblQTV.Text); }
            set {
                this.value = value;
                lblQTV.Text=this.value.ToString(); 
            }
        }
        public string ID
        {
            get { return id; }
            set { this.id = value; }
        }
        public string TXTNote
        {
            get { return txtNote.Text; }
        }
 

        public string PTBImage_Drinks
        {
            get { return image_PTB_image; }
            set
            {
                image_PTB_image = value;
                if (image_PTB_image == null) ptbImage_Drinks.Image = null;
                else ptbImage_Drinks.Image = Image.FromFile(image_PTB_image);
            }
        }
        public string BTNCategories
        {
            set { btnCategories.Text = value; }
        }
        public string BTNName
        {
            set { btnName.Text = value; }
        }
        public string LBLPrice
        {
            set { lblPrice.Text = value; }
        }
        public string LBLSUM
        {
            get { return lblSum.Text; }
            set { lblSum.Text = value; }
        }
    }
}
