
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;

namespace Management_Coffee_Shop
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            UC_Home uc = new UC_Home();
            addUserControl(uc);
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            UC_History uc = new UC_History();
            addUserControl(uc);
        }
    }
}
