using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Management_Coffee_Shop.FormCustomer.History_Shopping;

namespace Management_Coffee_Shop.User_Controls
{
    public partial class Bill : UserControl
    {
        public event EventHandler Clicked;
        private Dictionary<string, ShoppingItem> list_shopping = new Dictionary<string, ShoppingItem>();
        public Bill(Dictionary<string, ShoppingItem> list_shopping)
        {
            InitializeComponent();
            this.list_shopping = list_shopping;
        }
        private void clicked(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }
        public Dictionary<string, ShoppingItem> List_shopping 
        {
            get { return this.list_shopping; }
        }
        public string LBLCode
        {
            get { return lblCode.Text; }
            set { lblCode.Text = "#"+value; }
        }
        public string LBLTime
        {
            get {return lblTime.Text; }
            set { lblTime.Text = value; }
        }
        public string LBLItemCount
        {
            set { lblItemCount.Text = value; }
        }
        public string LBLStatus
        {
            get { return lblStatus.Text; }
            set { lblStatus.Text = value; }
        }
        public string LBLAmount
        {
            set { lblAmount.Text = value; }
        }
        public string LBLSum
        {
            get { return lblSum.Text; }
            set { lblSum.Text = value; }
        }
    }
}
