using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Management_Coffee_Shop
{
    public partial class ucIncome : UserControl
    {
        private ucIncomeLogic model;
        private Guna2Button currentButton;
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
        private void LoadData(string filterType = "Custom")
        {
            var refreshData = model.LoadData(dtpStartDate.Value, dtpEndDate.Value, filterType);
            if (refreshData)
            {
                // Cập nhật các nhãn
                lblNumberOfOrders.Text = model.NumOrders.ToString("N0");
                lblTotalRevenue.Text = "$" + model.TotalRevenue.ToString("N2");
                lblTotalProfit.Text = "$" + model.TotalProfit.ToString("N2");
                lblNumberOfCustomers.Text = model.NumCustomers.ToString("N0");
                lblNumberOfSuppliers.Text = model.NumSuppliers.ToString("N0");
                lblNumberOfProducts.Text = model.NumProducts.ToString("N0");

                // Biểu đồ Gross Revenue (bên trái) - Dạng khu vực
                chartGrossRevenue.DataSource = model.GrossRevenueList;
                chartGrossRevenue.Series[0].XValueMember = "Date";
                chartGrossRevenue.Series[0].YValueMembers = "TotalAmount";
                chartGrossRevenue.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                chartGrossRevenue.DataBind();

                // Biểu đồ Top 5 Products (bên phải) - Dạng vòng tròn
                chartTopProducts.DataSource = model.TopProductsList;
                chartTopProducts.Series[0].XValueMember = "Key";
                chartTopProducts.Series[0].YValueMembers = "Value";
                chartTopProducts.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chartTopProducts.Series[0].Label = "#VALX (#VAL)";
                chartTopProducts.Series[0].IsValueShownAsLabel = true;
                chartTopProducts.Series[0]["PieLabelStyle"] = "Outside";
                chartTopProducts.DataBind();

                // Cập nhật DataGridView cho danh sách sản phẩm dưới mức tồn kho
                dgvUnderStock.Columns.Clear();
                dgvUnderStock.Columns.Add("Name", "Item");
                dgvUnderStock.Columns.Add("Unit", "Units");
                dgvUnderStock.Columns.Add("Stock", "Stock");
                dgvUnderStock.AutoGenerateColumns = false;
                dgvUnderStock.DataSource = model.UnderStockList;
                dgvUnderStock.Columns["Name"].DataPropertyName = "Name";
                dgvUnderStock.Columns["Unit"].DataPropertyName = "Unit";
                dgvUnderStock.Columns["Stock"].DataPropertyName = "Stock";

                dgvUnderStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvUnderStock.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvUnderStock.Columns["Unit"].Width = 80;
                dgvUnderStock.Columns["Stock"].Width = 80;

                Console.WriteLine("Loaded view :)");
            }
            else
            {
                Console.WriteLine("View not loaded, same query");
            }
        }

        private void lblTotalProfit_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void SetDateMenuButtonsUI(object button)
        {
            var btn = (Guna2Button)button;
            btn.FillColor = btnToday.BorderColor;
            btn.ForeColor = Color.White;

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
            LoadData("Custom");
        }

        private void tlbFill_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
