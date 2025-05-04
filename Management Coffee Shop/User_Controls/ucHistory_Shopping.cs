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
    public partial class ucHistory_Shopping : UserControl
    {
        public ucHistory_Shopping()
        {
            InitializeComponent();
        }
        public void load_history(FormCustomer.History_Shopping order)
        {
            lblCode.Text = $"# {order.OrderId}";
            lblDate.Text = $"{order.OrderDate:dd/MM/yyyy HH:mm}";
            foreach (var kvp in order.list_shopping)
            {
                FormCustomer.History_Shopping.ShoppingItem value = kvp.Value;
                ucProduct_Shopping ucProduct_Shopping = new ucProduct_Shopping();
                ucProduct_Shopping.load(kvp.Key, value.Quantity, value.Price);
                flpProduct.Controls.Add(ucProduct_Shopping);
                flpProduct.Controls.SetChildIndex(ucProduct_Shopping,0);
                
            }
        }
    }
}
