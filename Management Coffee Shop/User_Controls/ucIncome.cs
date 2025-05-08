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
            if (filterType == "Custom" && dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var refreshData = model.LoadData(dtpStartDate.Value, dtpEndDate.Value, filterType);
            if (refreshData)
            {
                lblNumberOfOrders.Text = model.NumOrders.ToString("N0");
                lblTotalRevenue.Text = (model.TotalRevenue).ToString("#,##0") + "₫";
                lblTotalProfit.Text = (model.TotalProfit).ToString("#,##0") + "₫";
                lblNumberOfCustomers.Text = model.NumCustomers.ToString("N0");
                lblNumberOfSuppliers.Text = model.NumSuppliers.ToString("N0");
                lblNumberOfProducts.Text = model.NumProducts.ToString("N0");

                // Biểu đồ Gross Revenue
                chartGrossRevenue.Series[0].Points.Clear();
                if (model.GrossRevenueList.Any())
                {
                    foreach (var revenue in model.GrossRevenueList)
                    {
                        chartGrossRevenue.Series[0].Points.AddXY(revenue.Date, revenue.TotalAmount);
                    }
                }
                else
                {
                    chartGrossRevenue.Series[0].Points.AddXY("No Data", 0);
                }
                chartGrossRevenue.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                chartGrossRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "{0}K ₫";
                chartGrossRevenue.ChartAreas[0].AxisY.Minimum = 0;
                chartGrossRevenue.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

                // Biểu đồ Top 5 Products
                chartTopProducts.Series[0].Points.Clear();
                if (model.TopProductsList.Any())
                {
                    foreach (var product in model.TopProductsList)
                    {
                        chartTopProducts.Series[0].Points.AddXY(product.Key, product.Value);
                    }
                }
                else
                {
                    chartTopProducts.Series[0].Points.AddXY("No Data", 1);
                }
                chartTopProducts.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chartTopProducts.Series[0].Label = "#VALX (#VAL)";
                chartTopProducts.Series[0].IsValueShownAsLabel = true;
                chartTopProducts.Series[0]["PieLabelStyle"] = "Outside";

                dgvUnderStock.Columns.Clear();
                dgvUnderStock.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                dgvUnderStock.Columns.Add("Name", "Item");
                dgvUnderStock.Columns.Add("Stock", "Stock");
                dgvUnderStock.AutoGenerateColumns = false;
                dgvUnderStock.DataSource = model.UnderStockList;
                dgvUnderStock.Columns["Name"].DataPropertyName = "Name";
                dgvUnderStock.Columns["Stock"].DataPropertyName = "Stock";
                dgvUnderStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvUnderStock.Columns["Name"].FillWeight = 50;
                dgvUnderStock.Columns["Stock"].FillWeight = 50;

            }
            else
            {
                MessageBox.Show("View not loaded, same query");
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
                currentButton.FillColor = Color.FromArgb(141, 161, 246);
                currentButton.ForeColor = Color.Black;
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
