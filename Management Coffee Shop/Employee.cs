using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Coffee_Shop
{
    internal class Employee: People
    {
        public Employee(string id, string name, string address, string email, string date, string image) : base(id, name, address, email, date, image)
        {

        }
        public void Order()
        {

        }
        public string[] Check_History()
        {
            string path = @"..\..\history_Shopping.txt";
            string[] lines = File.ReadAllLines(path);
            return lines;
        }
        public int Online_Order()
        {
            string path = @"..\..\CustomerToEmployee.txt";
            int current_Length = File.ReadLines(path).Count();
            return current_Length;
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
