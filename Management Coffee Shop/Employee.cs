
using Management_Coffee_Shop.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using static Management_Coffee_Shop.FormCustomer;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Management_Coffee_Shop
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = tabPage3;
            load_history();
        }
        private void load_history()
        {
            string path = @"..\..\history_Shopping.txt";
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    History_Shopping history_Shopping = System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(line);
                    Bill bill = new Bill();
                    bill.LBLCode= history_Shopping.OrderId;
                    bill.LBLTime = $"{history_Shopping.OrderDate:dd/MM/yyyy HH:mm}";
                    int ItemCount = 0, Amount = 0;
                    foreach (var kvp in history_Shopping.list_shopping)
                    {
                        ItemCount++;
                        Amount += kvp.Value.Quantity;
                    }
                    bill.LBLSum= string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", history_Shopping.Sum);
                    bill.LBLItemCount=ItemCount.ToString();
                    bill.LBLAmount=Amount.ToString();
                    flpBill.Controls.Add(bill);
                }
            }
        }
        private void btnOnlineOrders_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = tabPage4;
        }
    }
}
