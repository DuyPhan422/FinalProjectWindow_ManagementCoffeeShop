using Management_Coffee_Shop.User_Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Management_Coffee_Shop.FormCustomer;
using static Management_Coffee_Shop.FormCustomer.History_Shopping;

namespace Management_Coffee_Shop
{
    internal class Customer:People
    {
        private static Dictionary<string, (int, int, Boolean)> list_products = new Dictionary<string, (int, int, Boolean)>();
        public Customer(string id, string name, string address, string email, string date,string image) :base (id, name, address, email, date,image) 
        {
            
        }
        public string [] Get_History()
        {
            string path = @"..\..\history_Shopping.txt";
            string[] lines = File.ReadAllLines(path);
            return lines;
        }
        public void Set_History(Dictionary<string, ShoppingItem> list_shopping,string OrderId,string Sum)
        {
            string path = @"..\..\history_Shopping.txt";
            History_Shopping history_Shopping = new History_Shopping()
            {
                OrderId = Regex.Replace(OrderId, @"[^\d]", ""),
                UserId = base.ID,
                list_shopping = list_shopping,
                Status = "Online",
                Sum = int.Parse(Regex.Replace(Sum, @"\D", "")),
                OrderDate = DateTime.Now
            };
            string jsonLine = System.Text.Json.JsonSerializer.Serialize(history_Shopping);
            File.AppendAllText(path, jsonLine + Environment.NewLine);
        }
        public void Order(int current_ID, Dictionary<string, ShoppingItem> list_shopping,string Sum)
        {
            string path = @"..\..\CustomerToEmployee.txt";
            History_Shopping history_Shop = new History_Shopping()
            {
                OrderId = current_ID.ToString("D7"),
                UserId = base.ID,
                list_shopping = list_shopping,
                Status = "Online",
                Sum = int.Parse(Regex.Replace(Sum, @"\D", "")),
                OrderDate = DateTime.Now
            };
            string jsonLine = System.Text.Json.JsonSerializer.Serialize(history_Shop);
            File.AppendAllText(path, jsonLine + Environment.NewLine);
        }
        public History_Shopping Repurchase(string orderId)
        {
            string path = @"..\..\history_Shopping.txt";
            string[] lines=File.ReadAllLines(path);
            foreach (string line in lines)
            {
                History_Shopping history_Shopping = System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(line);
                if (history_Shopping.OrderId.Trim() == orderId)
                {
                    return history_Shopping;
                }
            }
            return new History_Shopping();
        }
        public Dictionary<string, (int, int, Boolean)> List_Products
        {
            get { return list_products; }
            set { list_products = value; }
        }
        public new string ID
        {
            get { return base.ID; }
            set { base.ID = value; }
        }
        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }
        public new string Address
        {
            get { return base.Address; }
            set { base.Address = value; }
        }
        public new string Email
        {
            get { return base.Email; }
            set { base.Email = value; }
        }
        public new string Date
        {
            get { return base.Date; }
            set { base.Date = value; }
        }
        public new string Image
        {
            get { return base.Image; }
            set { base.Image = value; }
        }
    }
}
