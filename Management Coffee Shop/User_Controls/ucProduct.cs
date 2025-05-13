using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Guna.UI2.WinForms;
using Management_Coffee_Shop;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Management_Coffee_Shop
{
    public partial class ucProduct : UserControl
    {
        private ProductDb productDb;
        private int selectedProductId = -1;
        private string selectedImagePath;


        public ucProduct()
        {
            InitializeComponent();
            productDb = new ProductDb();
            this.Load += new System.EventHandler(this.ucProduct_Load);
            dgvProduct.DoubleClick += new EventHandler(dgvProduct_DoubleClick);
            txtPrice.KeyPress += new KeyPressEventHandler(txtPrice_KeyPress); // Thêm sự kiện KeyPress
        }
        private void dgvProduct_DoubleClick(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0 && dgvProduct.DataSource != null)
            {
                DataTable dt = (DataTable)dgvProduct.DataSource;
                int selectedIndex = dgvProduct.SelectedRows[0].Index;
                DataRow selectedRow = dt.Rows[selectedIndex];

                selectedProductId = Convert.ToInt32(selectedRow["ID"]);

                txtName.Text = selectedRow["Name"]?.ToString();
                cbbCategory.SelectedItem = selectedRow["Category"]?.ToString();
                txtPrice.Text = selectedRow["Price"]?.ToString();

                // Hiển thị dữ liệu cho dgvRecipe
                DataTable dtRecipe = new DataTable();
                dtRecipe.Columns.Add("Ingredient", typeof(string));
                dtRecipe.Columns.Add("Stock", typeof(int));

                DataRow recipeRow = dtRecipe.NewRow();
                recipeRow["Ingredient"] = selectedRow["Ingredient"]?.ToString() ?? "Chưa có";
                recipeRow["Stock"] = selectedRow["Stock"]?.ToString() ?? "0";
                dtRecipe.Rows.Add(recipeRow);

                dgvRecipe.DataSource = dtRecipe;

                // Hiển thị dữ liệu cho dgvDescription
                DataTable dtDescription = new DataTable();
                dtDescription.Columns.Add("CustomerRating", typeof(string));

                DataRow descriptionRow = dtDescription.NewRow();
                descriptionRow["CustomerRating"] = selectedRow["CustomerRating"]?.ToString() ?? "Chưa có đánh giá";
                dtDescription.Rows.Add(descriptionRow);

                dgvDescription.DataSource = dtDescription;

                // Hiển thị ảnh nếu có
                if (!string.IsNullOrEmpty(selectedRow["ImagePath"]?.ToString()))
                {
                    selectedImagePath = selectedRow["ImagePath"].ToString();
                    try
                    {
                        pbAvatar.Image = System.Drawing.Image.FromFile(selectedImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pbAvatar.Image = null;
                        selectedImagePath = null;
                    }
                }
                else
                {
                    pbAvatar.Image = null;
                    selectedImagePath = null;
                }

                timer.Start();
                tbpnlTop.Enabled = false;
            }
        }

        private void LoadProducts()
        {
            try
            {
                DataTable dt = productDb.GetAllProducts();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bảng ProductManager hiện không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvProduct.DataSource = dt; // Gán dữ liệu vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowProductDetails()
        {
            if (dgvProduct.SelectedRows.Count > 0 && dgvProduct.DataSource != null)
            {
                DataTable dt = (DataTable)dgvProduct.DataSource;
                int selectedIndex = dgvProduct.SelectedRows[0].Index;
                DataRow selectedRow = dt.Rows[selectedIndex];

                // Lấy ID sản phẩm
                string idStr = selectedRow["ID"].ToString().Trim();
                selectedProductId = int.Parse(idStr.Substring(3));

                // Tải dữ liệu vào các control
                txtName.Text = selectedRow["Name"]?.ToString().Trim() ?? "";
                txtPrice.Text = selectedRow["Price"]?.ToString() ?? "0";
                cbbCategory.SelectedItem = selectedRow["Category"]?.ToString().Trim() ?? cbbCategory.Items[0]?.ToString() ?? "";

                // Hiển thị Ingredient và Stock trong dgvRecipe
                DataTable dtRecipe = new DataTable();
                dtRecipe.Columns.Add("Ingredient", typeof(string));
                dtRecipe.Columns.Add("Stock", typeof(int));

                DataRow recipeRow = dtRecipe.NewRow();
                recipeRow["Ingredient"] = selectedRow["Ingredient"]?.ToString() ?? "Chưa có";
                recipeRow["Stock"] = selectedRow["Stock"]?.ToString() ?? "0";
                dtRecipe.Rows.Add(recipeRow);

                dgvRecipe.DataSource = dtRecipe;

                // Hiển thị CustomerRating trong dgvDescription
                DataTable dtDescription = new DataTable();
                dtDescription.Columns.Add("CustomerRating", typeof(string));

                DataRow descriptionRow = dtDescription.NewRow();
                string customerRating = selectedRow["CustomerRating"]?.ToString() ?? "Chưa có đánh giá";
                descriptionRow["CustomerRating"] = customerRating;
                dtDescription.Rows.Add(descriptionRow);

                dgvDescription.DataSource = dtDescription;

                // Hiển thị ảnh nếu có
                string imageRelativePath = selectedRow["ImagePath"]?.ToString();
                if (!string.IsNullOrEmpty(imageRelativePath))
                {
                    selectedImagePath = imageRelativePath;
                    try
                    {
                        string currentPath = Application.StartupPath;
                        string fullImagePath = Path.GetFullPath(Path.Combine(currentPath, imageRelativePath));
                        if (!File.Exists(fullImagePath))
                        {
                            pbAvatar.Image = null;
                            selectedImagePath = null;
                        }
                        else
                        {
                            pbAvatar.Image = System.Drawing.Image.FromFile(fullImagePath);
                        }
                    }
                    catch (Exception)
                    {
                        pbAvatar.Image = null;
                        selectedImagePath = null;
                    }
                }
                else
                {
                    pbAvatar.Image = null;
                    selectedImagePath = null;
                }

                // Làm mới giao diện
                if (tblEditProduct != null)
                {
                    tblEditProduct.Refresh();
                }
            }
            else
            {
                // Xóa dữ liệu nếu không có sản phẩm được chọn
                txtName.Text = "";
                txtPrice.Text = "";
                cbbCategory.SelectedIndex = -1;
                dgvRecipe.DataSource = null;
                dgvDescription.DataSource = null;
                pbAvatar.Image = null;
                selectedImagePath = null;
            }
        }

        void SelectTxt(Guna2TextBox txt)
        {
            txt.BackColor = Color.FromArgb(213, 216, 219);
        }
        void SelectTxt(Guna2ComboBox txt)
        {
            txt.BackColor = Color.FromArgb(213, 216, 219);
        }
        void LeaveTxt(Guna2TextBox txt)
        {
            txt.BackColor = Color.FromArgb(213, 216, 219);
        }
        void LeaveTxt(Guna2ComboBox txt)
        {
            txt.BackColor = Color.FromArgb(213, 216, 219);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            selectedProductId = -1; // Đặt lại để thêm sản phẩm mới
            txtName.Text = "";
            cbbCategory.SelectedIndex = -1;
            txtPrice.Text = "";

            // Đặt lại dữ liệu trong dgvRecipe
            DataTable dtRecipe = new DataTable();
            dtRecipe.Columns.Add("Ingredient", typeof(string));
            dtRecipe.Columns.Add("Stock", typeof(int));

            DataRow recipeRow = dtRecipe.NewRow();
            recipeRow["Ingredient"] = "Chưa có";
            recipeRow["Stock"] = 0;
            dtRecipe.Rows.Add(recipeRow);

            dgvRecipe.DataSource = dtRecipe;

            // Đặt lại dữ liệu trong dgvDescription
            DataTable dtDescription = new DataTable();
            dtDescription.Columns.Add("CustomerRating", typeof(string));

            DataRow descriptionRow = dtDescription.NewRow();
            descriptionRow["CustomerRating"] = "Chưa có đánh giá";
            dtDescription.Rows.Add(descriptionRow);

            dgvDescription.DataSource = dtDescription;

            // Đặt lại ảnh
            pbAvatar.Image = null;
            selectedImagePath = null;

            timer.Start();
            tbpnlTop.Enabled = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            SelectTxt(txtName);
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTxt(cbbCategory);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
      {
            SelectTxt(txtPrice);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            LeaveTxt(txtName);
        }

        private void cbbCategory_Leave(object sender, EventArgs e)
        {
            LeaveTxt(cbbCategory);
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            LeaveTxt(txtPrice);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0 && dgvProduct.DataSource != null)
            {
                DataTable dt = (DataTable)dgvProduct.DataSource;
                int selectedIndex = dgvProduct.SelectedRows[0].Index;
                DataRow selectedRow = dt.Rows[selectedIndex];

                selectedProductId = Convert.ToInt32(selectedRow["ID"]);
                txtName.Text = selectedRow["Name"]?.ToString();
                cbbCategory.SelectedItem = selectedRow["Category"]?.ToString();
                txtPrice.Text = selectedRow["Price"]?.ToString();

                timer.Start();
                tbpnlTop.Enabled = false;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

        private void timer_Tick(object sender, EventArgs e)
        {
            if (pnlEditProduct.Width == 470)
            {
                tblEditProduct.Visible = false;
                for (int i = 0; i < 10; i++)
                {
                    pnlEditProduct.Width = pnlEditProduct.Width - 47;
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    pnlEditProduct.Width = pnlEditProduct.Width + 47;
                }
                tblEditProduct.Visible = true;
            }
            timer.Stop();
        }

        private void ucProduct_Load(object sender, EventArgs e)
        {
            pnlEditProduct.Width = 0;
            dgvProduct.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            dgvRecipe.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvRecipe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            dgvDescription.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvDescription.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            lblTitle.ForeColor = Color.Coral;
            lblTitle.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);

            // Đảm bảo không tự động tạo cột
            dgvProduct.AutoGenerateColumns = false;
            dgvRecipe.AutoGenerateColumns = false;
            dgvDescription.AutoGenerateColumns = false;

            // Thiết lập cột cho dgvProduct
            if (dgvProduct.Columns.Count == 0)
            {
                // Cột ID
                DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
                colID.Name = "colID";
                colID.HeaderText = "ID";
                colID.DataPropertyName = "ID";
                colID.Width = 80; // Tăng độ rộng cột ID từ 50 lên 80
                colID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colID.ReadOnly = true;
                dgvProduct.Columns.Add(colID);

                // Cột Name
                DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
                colName.Name = "colName";
                colName.HeaderText = "Name";
                colName.DataPropertyName = "Name";
                colName.Width = 150;
                colName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colName.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvProduct.Columns.Add(colName);

                // Cột Category
                DataGridViewTextBoxColumn colCategory = new DataGridViewTextBoxColumn();
                colCategory.Name = "colCategory";
                colCategory.HeaderText = "Category";
                colCategory.DataPropertyName = "Category";
                colCategory.Width = 120;
                colCategory.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCategory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvProduct.Columns.Add(colCategory);

                // Cột Price
                DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
                colPrice.Name = "colPrice";
                colPrice.HeaderText = "Price";
                colPrice.DataPropertyName = "Price";
                colPrice.Width = 100;
                colPrice.DefaultCellStyle.Format = "N2";
                colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvProduct.Columns.Add(colPrice);

                // Cột Describe (ánh xạ thành Ingredient)
                DataGridViewTextBoxColumn colDescribe = new DataGridViewTextBoxColumn();
                colDescribe.Name = "colDescribe";
                colDescribe.HeaderText = "Describe";
                colDescribe.DataPropertyName = "Ingredient"; // Ánh xạ từ cột Ingredient (tương ứng với Describe trong DB)
                colDescribe.Width = 150;
                colDescribe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescribe.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvProduct.Columns.Add(colDescribe);

                // Cột Sales (ánh xạ thành Stock)
                DataGridViewTextBoxColumn colSales = new DataGridViewTextBoxColumn();
                colSales.Name = "colSales";
                colSales.HeaderText = "Sales";
                colSales.DataPropertyName = "Stock"; // Ánh xạ từ cột Stock (tương ứng với Sales trong DB)
                colSales.Width = 100;
                colSales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProduct.Columns.Add(colSales);
            }

            // Thiết lập cột cho dgvRecipe
            if (dgvRecipe.Columns.Count == 0)
            {
                dgvRecipe.Columns.Add("colIngredient", "Ingredient");
                dgvRecipe.Columns["colIngredient"].DataPropertyName = "Ingredient";
                dgvRecipe.Columns.Add("colStock", "Stock");
                dgvRecipe.Columns["colStock"].DataPropertyName = "Stock";
            }

            // Thiết lập cột cho dgvDescription
            if (dgvDescription.Columns.Count == 0)
            {
                dgvDescription.Columns.Add("colCustomerRating", "Customer Rating");
                dgvDescription.Columns["colCustomerRating"].DataPropertyName = "CustomerRating";
            }

            dgvRecipe.ReadOnly = false;
            dgvDescription.ReadOnly = true;

            // Tải dữ liệu sản phẩm
            LoadProducts();

            // Tự động chọn hàng đầu tiên nếu có dữ liệu
            if (dgvProduct.Rows.Count > 0)
            {
                dgvProduct.Rows[0].Selected = true;
                ShowProductDetails();
            }

            // Thiết lập các giá trị cho ComboBox Category
            if (cbbCategory.Items.Count == 0)
            {
                cbbCategory.Items.AddRange(new string[] { "Milk Tea", "Tea" });
            }

            // Thêm sự kiện SelectionChanged cho dgvProduct
            dgvProduct.SelectionChanged += new EventHandler(dgvProduct_SelectionChanged);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            timer.Start();
            tbpnlTop.Enabled = true;
            pbAvatar.Image = null; // Đặt lại ảnh
            selectedImagePath = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvProduct.SelectedRows[0];
            string productIdStr = row.Cells["colID"].Value?.ToString().Trim();
            if (string.IsNullOrEmpty(productIdStr) || !productIdStr.StartsWith("000") || productIdStr.Length != 7)
            {
                MessageBox.Show("ID sản phẩm không hợp lệ! ID phải có định dạng 000xxxx (7 ký tự).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy tên sản phẩm và loại bỏ khoảng trắng thừa
            string productName = row.Cells["colName"].Value?.ToString().Trim() ?? "Sản phẩm không xác định";
            if (string.IsNullOrEmpty(productName))
            {
                productName = "Sản phẩm không xác định";
            }

            // Hiển thị thông báo xác nhận với tên đã được xử lý
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm {productName} ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int productId;
                    try
                    {
                        productId = int.Parse(productIdStr.Substring(3)); // Lấy 4 chữ số cuối
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi phân tích ID sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    productDb.DeleteProduct(productId);
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts(); // Tải lại dữ liệu
                    if (dgvProduct.Rows.Count > 0)
                    {
                        dgvProduct.Rows[0].Selected = true;
                        ShowProductDetails();
                    }
                    else
                    {
                        dgvRecipe.DataSource = null;
                        dgvDescription.DataSource = null;
                        pbAvatar.Image = null;
                        selectedImagePath = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
            if (dgvProduct.Rows.Count > 0)
            {
                dgvProduct.Rows[0].Selected = true;
                ShowProductDetails();
            }
            else
            {
                dgvRecipe.DataSource = null;
                dgvDescription.DataSource = null;
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable productData = productDb.GetAllProducts();
                if (productData == null || productData.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để xuất.", "Không Có Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Tệp Excel (*.xlsx)|*.xlsx|Tệp CSV (*.csv)|*.csv";
                    saveFileDialog.Title = "Lưu Báo Cáo Sản Phẩm";
                    saveFileDialog.FileName = $"Bao_Cao_San_Pham_{DateTime.Now:yyyyMMddHHmmss}.csv"; 

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        ExportToCsv(productData, filePath);
                        MessageBox.Show($"Báo cáo đã được lưu thành công tại {filePath}", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất báo cáo: {ex.Message}", "Lỗi Xuất Báo Cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportToCsv(DataTable dataTable, string filePath)
        {
            try
            {
                var encoding = new UTF8Encoding(true);
                using (StreamWriter writer = new StreamWriter(filePath, false, encoding))
                {
                    var columnNames = dataTable.Columns.Cast<DataColumn>()
                        .Select(column => $"\"{column.ColumnName.Replace("\"", "\"\"")}\"");
                    writer.WriteLine(string.Join(",", columnNames));

                    foreach (DataRow row in dataTable.Rows)
                    {
                        var fields = row.ItemArray.Select(field =>
                            $"\"{(field?.ToString() ?? "").Replace("\"", "\"\"")}\"");
                        writer.WriteLine(string.Join(",", fields));
                    }
                }
            }
            catch (IOException ex)
            {
                throw new Exception($"Lỗi khi ghi tệp: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi không xác định khi xuất CSV: {ex.Message}", ex);
            }
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
           

        }

        private void btnEditRecipe_Click(object sender, EventArgs e)
        {
            

        }

        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {
            if (dgvRecipe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một công thức để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtRecipe = (DataTable)dgvRecipe.DataSource;
            if (dtRecipe != null && dtRecipe.Rows.Count > 0)
            {
                dtRecipe.Rows.RemoveAt(dgvRecipe.SelectedRows[0].Index);
                dgvRecipe.DataSource = dtRecipe;
            }
        }

        private void btnBookRecipe_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtName.Text) || cbbCategory.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ giao diện
            string name = txtName.Text.Trim();
            if (name.Length > 25)
            {
                MessageBox.Show("Tên sản phẩm không được dài quá 25 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string category = cbbCategory.SelectedItem.ToString();
            if (category.Length > 30)
            {
                MessageBox.Show("Danh mục không được dài quá 30 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra và chuyển đổi giá
            string priceText = txtPrice.Text.Replace(",", ".").Trim();
            if (!decimal.TryParse(priceText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal price))
            {
                MessageBox.Show("Giá phải là một số hợp lệ (ví dụ: 1234.567)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] priceParts = price.ToString(System.Globalization.CultureInfo.InvariantCulture).Split('.');
            if (priceParts[0].Length > 4 || (priceParts.Length > 1 && priceParts[1].Length > 3) || price < 0)
            {
                MessageBox.Show("Giá phải nằm trong phạm vi 0 đến 9999.999 (tối đa 4 chữ số nguyên và 3 chữ số thập phân)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ dgvRecipe (Ingredient, Stock)
            string ingredient = "Chưa có";  
            int stock = 0;
            if (dgvRecipe.Rows.Count > 0 && dgvRecipe.DataSource != null)
            {
                DataGridViewRow recipeRow = dgvRecipe.Rows[0];
                if (dgvRecipe.Columns.Contains("colIngredient"))
                {
                    ingredient = recipeRow.Cells["colIngredient"].Value?.ToString() ?? "Chưa có";
                    if (ingredient.Length > 25)
                    {
                        MessageBox.Show("Mô tả (Ingredient) không được dài quá 25 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (dgvRecipe.Columns.Contains("colStock"))
                {
                    string stockText = recipeRow.Cells["colStock"].Value?.ToString();
                    if (!int.TryParse(stockText, out stock) || stock < 0)
                    {
                        MessageBox.Show("Số lượng tồn kho phải là một số nguyên không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // Lấy dữ liệu từ dgvDescription (CustomerRating) mà không kiểm tra phạm vi
            string customerRating = "Chưa có đánh giá";
            if (dgvDescription.Rows.Count > 0 && dgvDescription.DataSource != null)
            {
                DataGridViewRow descriptionRow = dgvDescription.Rows[0];
                if (dgvDescription.Columns.Contains("colCustomerRating"))
                {
                    customerRating = descriptionRow.Cells["colCustomerRating"].Value?.ToString() ?? "Chưa có đánh giá";
                }
            }

            // Kiểm tra và xử lý selectedImagePath
            string imagePath = selectedImagePath ?? string.Empty;
            if (imagePath.Length > 60)
            {
                MessageBox.Show("Đường dẫn ảnh vượt quá 60 ký tự! Đường dẫn sẽ bị cắt ngắn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                imagePath = imagePath.Substring(0, 60);
            }

            // Kiểm tra sản phẩm trùng
            if (selectedProductId == -1) // Thêm mới
            {
                if (productDb.CheckProductExists(name, category, price, stock, ingredient, customerRating, imagePath))
                {
                    MessageBox.Show("Sản phẩm với thông tin này đã tồn tại! Vui lòng thay đổi ít nhất một thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else // Đang chỉnh sửa
            {
                DataTable dt = productDb.GetAllProducts();
                foreach (DataRow row in dt.Rows)
                {
                    string rowId = row["ID"].ToString().Trim();
                    if (rowId == $"000{selectedProductId:D4}") continue;
                    string rowName = row["Name"].ToString().Trim();
                    string rowCategory = row["Category"].ToString().Trim();
                    decimal rowPrice = Convert.ToDecimal(row["Price"]);
                    int rowStock = Convert.ToInt32(row["Stock"]);
                    string rowIngredient = row["Ingredient"]?.ToString() ?? "Chưa có";
                    string rowCustomerRating = row["CustomerRating"]?.ToString() ?? "Chưa có đánh giá";
                    string rowImagePath = row["ImagePath"]?.ToString() ?? string.Empty;

                    if (name == rowName && category == rowCategory && price == rowPrice && stock == rowStock &&
                        ingredient == rowIngredient && customerRating == rowCustomerRating && imagePath == rowImagePath)
                    {
                        MessageBox.Show("Sản phẩm với thông tin này đã tồn tại! Vui lòng thay đổi ít nhất một thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            try
            {
                if (selectedProductId == -1) // Thêm sản phẩm mới
                {
                    productDb.AddProduct(name, category, price, stock, ingredient, customerRating, imagePath);
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Cập nhật sản phẩm
                {
                    productDb.UpdateProduct(selectedProductId, name, category, price, stock, ingredient, customerRating, imagePath);
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Tải lại danh sách sản phẩm
                LoadProducts();

                // Đặt lại giao diện
                timer.Start();
                tbpnlTop.Enabled = true;
                tblEditProduct.Visible = false; // Ẩn panel sau khi lưu

                // Xóa dữ liệu trong các control
                txtName.Text = "";
                txtPrice.Text = "";
                cbbCategory.SelectedIndex = -1;
                dgvRecipe.DataSource = null;
                dgvDescription.DataSource = null;
                pbAvatar.Image = null;
                selectedImagePath = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu sản phẩm: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số, dấu chấm và phím Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Chỉ cho phép một dấu chấm duy nhất
            if (e.KeyChar == '.' && (sender as Guna2TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            ShowProductDetails();

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private string GetProjectRootPath()
        {
            string currentPath = Application.StartupPath;
            DirectoryInfo directory = new DirectoryInfo(currentPath);

            // Đi ngược lên cho đến khi tìm thấy thư mục gốc của dự án
            while (directory != null)
            {
                // Kiểm tra xem thư mục hiện tại có phải là thư mục gốc không
                if (directory.GetFiles("*.sln").Length > 0 || directory.Name == "Management Coffee Shop")
                {
                    return directory.FullName;
                }
                directory = directory.Parent;
            }

            throw new Exception("Không thể xác định thư mục gốc của dự án!");
        }

        private string GetImagesFolderPath()
        {
            string projectRoot = GetProjectRootPath();
            string imagesFolder = Path.Combine(projectRoot, "drinks_images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }
            return imagesFolder;
        }

        private string GenerateShortFileName(string originalFileName)
        {
            string extension = Path.GetExtension(originalFileName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);

            // Nếu tên file quá dài, cắt ngắn và thêm mã ngẫu nhiên
            if (fileNameWithoutExtension.Length > 50)
            {
                fileNameWithoutExtension = fileNameWithoutExtension.Substring(0, 45);
                fileNameWithoutExtension += Guid.NewGuid().ToString("N").Substring(0, 5);
            }

            string newFileName = fileNameWithoutExtension + extension;
            if (newFileName.Length > 60)
            {
                throw new Exception("Tên file ảnh sau khi xử lý vẫn vượt quá 60 ký tự!");
            }

            return newFileName;
        }

        private void btnImageChange_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tệp Ảnh|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Chọn một ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Đường dẫn ảnh gốc
                    string sourceImagePath = openFileDialog.FileName;

                    // Tạo thư mục drinks_images trong thư mục gốc của dự án
                    string imagesFolder = GetImagesFolderPath();

                    // Tạo tên file ngắn hơn nếu cần
                    string fileName = GenerateShortFileName(Path.GetFileName(sourceImagePath));
                    string destinationImagePath = Path.Combine(imagesFolder, fileName);

                    // Sao chép ảnh đến thư mục drinks_images
                    File.Copy(sourceImagePath, destinationImagePath, true);

                    // Kiểm tra xem tệp đã được sao chép thành công chưa
                    if (!File.Exists(destinationImagePath))
                    {
                        throw new Exception("Không thể sao chép tệp ảnh vào thư mục drinks_images!");
                    }

                    // Lưu đường dẫn tương đối với dấu \: ..\..\drinks_images\fileName
                    selectedImagePath = $@"..\..\drinks_images\{fileName}"; // Sử dụng dấu \ thay vì /

                    // Hiển thị ảnh trong PictureBox
                    pbAvatar.Image = System.Drawing.Image.FromFile(destinationImagePath);

                    // Debug: Hiển thị đường dẫn để kiểm tra
                    MessageBox.Show($"Đã lưu ảnh tại: {destinationImagePath}\nĐường dẫn tương đối: {selectedImagePath}", "Debug");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    selectedImagePath = null;
                    pbAvatar.Image = null;
                }
            }
        }

        private void pbAvatar_Click(object sender, EventArgs e)
        {
            btnImageChange_Click(sender, e);
        }

        private void btnImageCancel_Click(object sender, EventArgs e)
        {
            pbAvatar.Image = null;
            selectedImagePath = null;

        }
    }
}
