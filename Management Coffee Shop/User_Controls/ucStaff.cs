using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Management_Coffee_Shop
{
    public partial class ucStaff : UserControl
    {

        private StaffDb staffDb;
        private string selectedStaffId = null;
        private string selectedImagePath;

        public ucStaff()
        {
            InitializeComponent();
            staffDb = new StaffDb();
            this.Load += new EventHandler(ucStaff_Load);
            dgvStaff.DoubleClick += new EventHandler(dgvStaff_DoubleClick);

        }
        private void LoadStaff()
        {
            try
            {
                DataTable dt = staffDb.GetAllStaff();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bảng StaffManager hiện không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgvStaff.DataSource = dt;

                // Debug: In danh sách cột trong DataTable
                string columns = "Cột trong DataTable: ";
                foreach (DataColumn column in dt.Columns)
                {
                    columns += column.ColumnName + ", ";
                }
                System.Diagnostics.Debug.WriteLine(columns);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowStaffDetails()
        {
            if (dgvStaff.SelectedRows.Count > 0 && dgvStaff.DataSource != null)
            {
                try
                {
                    DataTable dt = (DataTable)dgvStaff.DataSource;
                    int selectedIndex = dgvStaff.SelectedRows[0].Index;
                    DataRow selectedRow = dt.Rows[selectedIndex];

                    // Debug: In dữ liệu của hàng được chọn
                    string rowData = "Dữ liệu hàng: ";
                    foreach (DataColumn column in dt.Columns)
                    {
                        rowData += $"{column.ColumnName} = '{selectedRow[column.ColumnName]?.ToString() ?? "NULL"}', ";
                    }
                    System.Diagnostics.Debug.WriteLine(rowData);

                    // Lấy ID và hiển thị lên lblID với định dạng "ID:E00xxxx"
                    selectedStaffId = selectedRow["ID"]?.ToString()?.Trim() ?? "";
                    lblID.Text = $"ID:{selectedStaffId}"; // Hiển thị ID với định dạng "ID:E00xxxx"
                    System.Diagnostics.Debug.WriteLine($"selectedStaffId: '{selectedStaffId}'");

                    txtFirstName.Text = selectedRow["FirstName"]?.ToString()?.Trim() ?? "";
                    txtLastName.Text = selectedRow["LastName"]?.ToString()?.Trim() ?? "";
                    txtEmail.Text = selectedRow["Email"]?.ToString()?.Trim() ?? "";
                    string gender = selectedRow["Gender"]?.ToString()?.Trim() ?? "";
                    rdbMale.Checked = gender == "Male";
                    rdbFemale.Checked = gender == "Female";

                    // Kiểm tra và chuyển đổi BirthDate an toàn
                    if (selectedRow["BirthDate"] != DBNull.Value && selectedRow["BirthDate"] != null)
                    {
                        string birthDateStr = selectedRow["BirthDate"].ToString().Trim();
                        System.Diagnostics.Debug.WriteLine($"BirthDate raw: '{birthDateStr}'");
                        if (DateTime.TryParse(birthDateStr, out DateTime birthDate))
                        {
                            dtpBirthDay.Value = birthDate;
                        }
                        else
                        {
                            dtpBirthDay.Value = DateTime.Now;
                            MessageBox.Show($"Ngày sinh không hợp lệ ('{birthDateStr}'), sử dụng ngày hiện tại làm mặc định.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        dtpBirthDay.Value = DateTime.Now;
                        System.Diagnostics.Debug.WriteLine("BirthDate is NULL or DBNull");
                    }

                    txtPhone.Text = selectedRow["Phone"]?.ToString()?.Trim() ?? "";
                    txtAddress.Text = selectedRow["Address"]?.ToString()?.Trim() ?? "";

                    // Kiểm tra và chuyển đổi Salary an toàn
                    if (selectedRow["Salary"] != DBNull.Value && selectedRow["Salary"] != null)
                    {
                        string salaryStr = selectedRow["Salary"].ToString().Trim();
                        System.Diagnostics.Debug.WriteLine($"Salary raw: '{salaryStr}'");
                        if (decimal.TryParse(salaryStr, out decimal salary))
                        {
                            txtSalary.Text = salary.ToString();
                        }
                        else
                        {
                            txtSalary.Text = "";
                            MessageBox.Show($"Lương không hợp lệ ('{salaryStr}'), để trống trường lương.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        txtSalary.Text = "";
                        System.Diagnostics.Debug.WriteLine("Salary is NULL or DBNull");
                    }

                    txtDescription.Text = selectedRow["Description"]?.ToString()?.Trim() ?? "";

                    if (!string.IsNullOrEmpty(selectedRow["Source_Image"]?.ToString()))
                    {
                        selectedImagePath = selectedRow["Source_Image"].ToString().Trim();
                        try
                        {
                            pbAvatar.Image = Image.FromFile(selectedImagePath);
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi hiển thị thông tin: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearForm();
                }
            }
            else
            {
                ClearForm();
            }
        }

        private void ClearForm()
        {
            selectedStaffId = null;
            lblID.Text = "ID:"; // Đặt lại lblID khi không có hàng nào được chọn
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            dtpBirthDay.Value = DateTime.Now;
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtSalary.Text = "";
            txtDescription.Text = "";
            pbAvatar.Image = null;
            selectedImagePath = null;
        }
        private void dgvStaff_DoubleClick(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count > 0 && dgvStaff.DataSource != null)
            {
                try
                {
                    DataTable dt = (DataTable)dgvStaff.DataSource;
                    int selectedIndex = dgvStaff.SelectedRows[0].Index;
                    DataRow selectedRow = dt.Rows[selectedIndex];

                    // Lấy ID dưới dạng string, không chuyển đổi sang int
                    selectedStaffId = selectedRow["ID"]?.ToString()?.Trim() ?? "";
                    System.Diagnostics.Debug.WriteLine($"Double-click - selectedStaffId: '{selectedStaffId}'");

                    // Debug: In tất cả giá trị của hàng để kiểm tra
                    string rowData = "Dữ liệu hàng: ";
                    foreach (DataColumn column in dt.Columns)
                    {
                        rowData += $"{column.ColumnName} = '{selectedRow[column.ColumnName]?.ToString() ?? "NULL"}', ";
                    }
                    System.Diagnostics.Debug.WriteLine(rowData);

                    ShowStaffDetails();

                    timer.Start();
                    tbpnlTop.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi double-click: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        void SelectTxt(Guna2TextBox txt)
        {
            txt.BackColor = Color.FromArgb(213, 216, 219);
        }
        void LeaveTxt(Guna2TextBox txt)
        {
            txt.BackColor = Color.FromArgb(213, 216, 219);
        }
        private void txtFirstName_MouseClick(object sender, MouseEventArgs e)
        {
            SelectTxt(txtFirstName);
        }
        private void txtLastName_MouseClick(object sender, MouseEventArgs e)
        {
            SelectTxt(txtLastName);
        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            SelectTxt(txtEmail);
        }
        private void txtPhone_MouseClick(object sender, MouseEventArgs e)
        {
            SelectTxt(txtPhone);
        }

        private void txtAddress_MouseClick(object sender, MouseEventArgs e)
        {
            SelectTxt(txtAddress);
        }

        private void txtSalary_MouseClick(object sender, MouseEventArgs e)
        {
            SelectTxt(txtSalary);
        }

        private void txtDescription_MouseClick(object sender, MouseEventArgs e)
        {
            SelectTxt(txtDescription);
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            LeaveTxt(txtFirstName);
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            LeaveTxt(txtLastName);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            LeaveTxt(txtEmail);
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            LeaveTxt(txtPhone);
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            LeaveTxt(txtAddress);
        }

        private void txtSalary_Leave(object sender, EventArgs e)
        {
            LeaveTxt(txtSalary);
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            LeaveTxt(txtDescription);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            timer.Start();
            tbpnlTop.Enabled = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            timer.Start();
            tbpnlTop.Enabled = true;
            pbAvatar.Image = null;
            selectedImagePath = null;
        }
        private void timer_Tick_1(object sender, EventArgs e)
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

        private void ucStaff_Load(object sender, EventArgs e)
        {
            pnlEditProduct.Width = 0;
            dgvStaff.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvStaff.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            dgvStaff.AutoGenerateColumns = false;
            // Trì hoãn tải dữ liệu sau khi form load hoàn tất
            LoadStaff();
            if (dgvStaff.Rows.Count > 0)
            {
                dgvStaff.Rows[0].Selected = false; // Không tự động chọn hàng ngay lập tức
            }

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count > 0 && dgvStaff.DataSource != null)
            {
                ShowStaffDetails();
                timer.Start();
                tbpnlTop.Enabled = false;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedStaffId) || dgvStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string staffName = $"{txtFirstName.Text} {txtLastName.Text}".Trim();
            if (string.IsNullOrEmpty(staffName))
            {
                staffName = "Nhân viên không xác định";
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {staffName}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    staffDb.DeleteStaff(selectedStaffId);
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStaff();
                    if (dgvStaff.Rows.Count > 0)
                    {
                        dgvStaff.Rows[0].Selected = true;
                        ShowStaffDetails();
                    }
                    else
                    {
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa nhân viên: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường bắt buộc
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtSalary.Text))
                {
                    throw new ArgumentException("Vui lòng điền đầy đủ thông tin nhân viên!");
                }

                if (!rdbMale.Checked && !rdbFemale.Checked)
                {
                    throw new ArgumentException("Vui lòng chọn giới tính!");
                }

                if (!decimal.TryParse(txtSalary.Text, out decimal salary) || salary < 0)
                {
                    throw new FormatException("Lương phải là một số hợp lệ và không âm!");
                }

                if (!IsValidEmail(txtEmail.Text))
                {
                    throw new FormatException("Email không hợp lệ!");
                }

                if (!IsValidPhone(txtPhone.Text))
                {
                    throw new FormatException("Số điện thoại không hợp lệ (phải có ít nhất 10 chữ số)!");
                }

                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string gender = rdbMale.Checked ? "Male" : "Female";
                DateTime birthDate = dtpBirthDay.Value;
                string phone = txtPhone.Text.Trim();
                string address = txtAddress.Text.Trim();
                string description = txtDescription.Text.Trim();

                // Kiểm tra độ dài các trường
                if (firstName.Length > 15)
                    throw new ArgumentException("Tên không được dài quá 15 ký tự!");
                if (lastName.Length > 15)
                    throw new ArgumentException("Họ không được dài quá 15 ký tự!");
                if (email.Length > 30)
                    throw new ArgumentException("Email không được dài quá 30 ký tự!");
                if (phone.Length > 15)
                    throw new ArgumentException("Số điện thoại không được dài quá 15 ký tự!");
                if (address.Length > 50)
                    throw new ArgumentException("Địa chỉ không được dài quá 50 ký tự!");
                if (description.Length > 50)
                    throw new ArgumentException("Mô tả không được dài quá 50 ký tự!");
                if (salary > 99999999.99m)
                    throw new ArgumentException("Lương không được vượt quá 99999999.99!");

                // Kiểm tra trùng email và phone
                if (string.IsNullOrEmpty(selectedStaffId)) // Thêm mới
                {
                    if (staffDb.CheckStaffExists(email, phone))
                    {
                        MessageBox.Show("Nhân viên với email hoặc số điện thoại này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else // Cập nhật
                {
                    if (staffDb.CheckStaffExists(email, phone, selectedStaffId))
                    {
                        MessageBox.Show("Email hoặc số điện thoại đã được sử dụng bởi nhân viên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (string.IsNullOrEmpty(selectedStaffId)) // Thêm mới
                {
                    staffDb.AddStaff(firstName, lastName, email, gender, birthDate, phone, address, salary, description, selectedImagePath);
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Cập nhật
                {
                    staffDb.UpdateStaff(selectedStaffId, firstName, lastName, email, gender, birthDate, phone, address, salary, description, selectedImagePath);
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadStaff();
                if (dgvStaff.Rows.Count > 0)
                {
                    dgvStaff.Rows[0].Selected = true;
                    ShowStaffDetails();
                }
                else
                {
                    ClearForm();
                }

                timer.Start();
                tbpnlTop.Enabled = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsCurrentStaff(string email, string phone)
        {
            DataTable dt = staffDb.GetAllStaff();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Id"].ToString() == selectedStaffId) // Convert 'Id' to string for comparison
                {
                    return row["Email"].ToString() == email && row["Phone"].ToString() == phone;
                }
            }
            return false;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            return phone.Length >= 10 && phone.All(char.IsDigit);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStaff();
            if (dgvStaff.Rows.Count > 0)
            {
                dgvStaff.Rows[0].Selected = true;
                ShowStaffDetails();
            }
            else
            {
                ClearForm();
            }
        }

        private void dgvStaff_SelectionChanged(object sender, EventArgs e)
        {
            ShowStaffDetails();
        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable staffData = staffDb.GetAllStaff();
                if (staffData == null || staffData.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu nhân viên để xuất.", "Không Có Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Tệp CSV (*.csv)|*.csv";
                    saveFileDialog.Title = "Lưu Báo Cáo Nhân Viên";
                    saveFileDialog.FileName = $"Bao_Cao_Nhan_Vien_{DateTime.Now:yyyyMMddHHmmss}.csv";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        ExportToCsv(staffData, filePath);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlEditProduct_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlEditProductTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {
        
        }

        private void pnlEditProductFill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tblEditProduct_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbAvatar_Click(object sender, EventArgs e)
        {
            btnImageChange_Click(sender, e);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

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
                    selectedImagePath = openFileDialog.FileName;
                    pbAvatar.Image = Image.FromFile(selectedImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblFirstName_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblLastName_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblGender_Click(object sender, EventArgs e)
        {

        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblBirthday_Click(object sender, EventArgs e)
        {

        }

        private void dtpBirthDay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblPhone_Click(object sender, EventArgs e)
        {

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void lblSalary_Click(object sender, EventArgs e)
        {

        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void tbpnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlGrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnImageCancel_Click(object sender, EventArgs e)
        {
            pbAvatar.Image = null;
            selectedImagePath = null;
        }
    }
}
