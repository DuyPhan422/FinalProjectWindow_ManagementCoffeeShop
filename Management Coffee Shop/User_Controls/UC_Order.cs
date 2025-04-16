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
    public partial class UC_Order : UserControl
    {
        public UC_Order()
        {
            InitializeComponent();
        }

        private void btnExprotbill_Click(object sender, EventArgs e)
        {
            FormBillThanhToan billForm = new FormBillThanhToan();
            billForm.Show(); // Mở form mới không ẩn form hiện tại
        }
    }
}
