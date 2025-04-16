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
    public partial class ucIncome : UserControl
    {
        private ucIncomeLogic model;
        private Guna.UI2.WinForms.Guna2Button currentButton;
        public ucIncome()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            btnLast7Days.Select();
            SetDateMenuButtonsUI(btnLast7Days);
            model = new ucIncomeLogic();
            LoadData();
        }
        private void LoadData()
        {
            var refreshData = model.LoadData(dtpStartDate.Value, dtpEndDate.Value);
            if (refreshData == true)
            {
                lblNumberOfOrders.Text = model.NumOrders.ToString();
                lblTotalRevenue.Text = "$" + model.TotalRevenue.ToString();
                lblTotalProfit.Text = "$" + model.TotalProfit.ToString();
                lblNumberOfCustomers.Text = model.NumCustomers.ToString();
                lblNumberOfSuppliers.Text = model.NumSuppliers.ToString();
                lblNumberOfProducts.Text = model.NumProducts.ToString();
                chartGrossRevenue.DataSource = model.GrossRevenueList;
                chartGrossRevenue.Series[0].XValueMember = "Date";
                chartGrossRevenue.Series[0].YValueMembers = "TotalAmount";
                chartGrossRevenue.DataBind();
                chartTopProducts.DataSource = model.TopProductsList;
                chartTopProducts.Series[0].XValueMember = "Key";
                chartTopProducts.Series[0].YValueMembers = "Value";
                chartTopProducts.DataBind();
                dgvUnderStock.DataSource = model.UnderStockList;
                dgvUnderStock.Columns[0].HeaderText = "Item";
                dgvUnderStock.Columns[1].HeaderText = "Units";
                Console.WriteLine("Loaded view :)");
            }
            else Console.WriteLine("View not loaded, same query");
        }

        private void lblTotalProfit_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void SetDateMenuButtonsUI(object button)
        {
            var btn = (Guna.UI2.WinForms.Guna2Button)button;
            //Highlight button
            btn.FillColor = btnToday.BorderColor;
            btn.ForeColor = Color.White;
            //dtpStartDate.Enabled = false;
            //dtpEndDate.Enabled = false;
            //btnOkModifyDays.Visible = false;

            //Unhighlight button
            if (currentButton != null && currentButton != btn)
            {
                currentButton.FillColor = Color.FromArgb(42, 45, 86);
                currentButton.ForeColor = Color.FromArgb(169, 169, 169);
            }
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            btnOkModifyDays.Visible = false;
            currentButton = btn;
        }
        private void btnModifyDays_Click_1(object sender, EventArgs e)
        {
            SetDateMenuButtonsUI(sender);
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            btnOkModifyDays.Visible = true;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            SetDateMenuButtonsUI(sender);
        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            SetDateMenuButtonsUI(sender);
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            SetDateMenuButtonsUI(sender);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            SetDateMenuButtonsUI(sender);
        }

        private void btnOkModifyDays_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlbFill_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
