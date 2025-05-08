using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Coffee_Shop
{
    internal class People
    {
        private string id, name, address, email, date, image;
        public People(string id, string name, string address, string email, string date, string image)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.email = email;
            this.date = Date;
            this.image = Image;
        }
        public string ID
        {
            get { return id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }
        public string Address
        {
            get { return address; }
            set { this.address = value; }
        }
        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Image
        {
            get { return image; }
            set { image = value; }
        } 
    }
}
