using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Coffee_Shop
{
    internal class Customer:People
    {
        private static Dictionary<string, (int, int, Boolean)> list_products = new Dictionary<string, (int, int, Boolean)>();
        public Customer(string id, string name, string address, string email, string date,string image) :base (id, name, address, email, date,image) 
        {
            
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
