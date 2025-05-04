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
    public partial class Bill : UserControl
    {
        public event EventHandler Clicked;
        public Bill()
        {
            InitializeComponent();
        }
        public string LBLCode
        {
            set { lblCode.Text = "#"+value; }
        }
        public string LBLTime
        {
            set { lblTime.Text = value; }
        }
        public string LBLItemCount
        {
            set { lblItemCount.Text = value; }
        }
        public string LBLAmount
        {
            set { lblAmount.Text = value; }
        }
        public string LBLSum
        {
            set { lblSum.Text = value; }
        }
    }
}
