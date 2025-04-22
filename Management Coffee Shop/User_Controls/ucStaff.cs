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
        private int selectedStaffId = -1;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    txtFirstName.Text = selectedRow["FirstName"]?.ToString();
                    txtLastName.Text = selectedRow["LastName"]?.ToString();
                    txtEmail.Text = selectedRow["Email"]?.ToString() ?? "N/A";
                    string gender = selectedRow["Gender"]?.ToString();
                    rdbMale.Checked = gender == "Male";
                    rdbFemale.Checked = gender == "Female";
                    dtpBirthDay.Value = Convert.ToDateTime(selectedRow["BirthDate"]);
                    txtPhone.Text = selectedRow["Phone"]?.ToString();
                    txtAddress.Text = selectedRow["Address"]?.ToString();
                    txtSalary.Text = selectedRow["Salary"]?.ToString();
                    txtDescription.Text = selectedRow["Description"]?.ToString() ?? "Chưa có mô tả";

                    // Hiển thị ảnh nếu có
                    if (!string.IsNullOrEmpty(selectedRow["ImagePath"]?.ToString()))
                    {
                        selectedImagePath = selectedRow["ImagePath"].ToString();
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
                    MessageBox.Show($"Lỗi khi hiển thị thông tin: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            selectedStaffId = -1;
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
                DataTable dt = (DataTable)dgvStaff.DataSource;
                int selectedIndex = dgvStaff.SelectedRows[0].Index;
                DataRow selectedRow = dt.Rows[selectedIndex];

                selectedStaffId = Convert.ToInt32(selectedRow["Id"]);
                txtFirstName.Text = selectedRow["FirstName"]?.ToString();
                txtLastName.Text = selectedRow["LastName"]?.ToString();
                txtEmail.Text = selectedRow["Email"]?.ToString() ?? "N/A";
                string gender = selectedRow["Gender"]?.ToString();
                rdbMale.Checked = gender == "Male";
                rdbFemale.Checked = gender == "Female";
                dtpBirthDay.Value = Convert.ToDateTime(selectedRow["BirthDate"]);
                txtPhone.Text = selectedRow["Phone"]?.ToString();
                txtAddress.Text = selectedRow["Address"]?.ToString();
                txtSalary.Text = selectedRow["Salary"]?.ToString();
                txtDescription.Text = selectedRow["Description"]?.ToString() ?? "Chưa có mô tả";

                // Hiển thị ảnh nếu có
                if (!string.IsNullOrEmpty(selectedRow["ImagePath"]?.ToString()))
                {
                    selectedImagePath = selectedRow["ImagePath"].ToString();
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

                // Kích hoạt chế độ chỉnh sửa
                timer.Start();
                tbpnlTop.Enabled = false;
            }
        }

        void SelectTxt(Guna2TextBox txt)
        {
            txt.BackColor = Color.FromArgb(139, 199, 255);
        }
        void LeaveTxt(Guna2TextBox txt)
        {
            txt.BackColor = Color.White;
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


            // Đảm bảo không tự động tạo cột
            dgvStaff.AutoGenerateColumns = false;

            // Thiết lập cột cho dgvStaff
            

            // Tải dữ liệu nhân viên
            LoadStaff();


            // Thêm sự kiện SelectionChanged cho dgvStaff
            dgvStaff.SelectionChanged += new EventHandler(dgvStaff_SelectionChanged);

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count > 0 && dgvStaff.DataSource != null)
            {
                DataTable dt = (DataTable)dgvStaff.DataSource;
                int selectedIndex = dgvStaff.SelectedRows[0].Index;
                DataRow selectedRow = dt.Rows[selectedIndex];

                selectedStaffId = Convert.ToInt32(selectedRow["Id"]);
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
            if (dgvStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvStaff.SelectedRows[0];
            int staffId = Convert.ToInt32(row.Cells["colId"].Value);
            string staffName = $"{row.Cells["colFirstName"].Value} {row.Cells["colLastName"].Value}";
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {staffName}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    staffDb.DeleteStaff(staffId);
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
                    MessageBox.Show($"Lỗi khi xóa nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                // Input validation
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

                if (!decimal.TryParse(txtSalary.Text, out decimal salary))
                {
                    throw new FormatException("Lương phải là một số hợp lệ!");
                }

                if (!IsValidEmail(txtEmail.Text))
                {
                    throw new FormatException("Email không hợp lệ!");
                }

                if (!IsValidPhone(txtPhone.Text))
                {
                    throw new FormatException("Số điện thoại không hợp lệ!");
                }

                // Prepare data
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string gender = rdbMale.Checked ? "Male" : "Female";
                DateTime birthDate = dtpBirthDay.Value;
                string phone = txtPhone.Text.Trim();
                string address = txtAddress.Text.Trim();
                string description = txtDescription.Text.Trim();

                // Kiểm tra trùng lặp
                if (staffDb.CheckStaffExists(email, phone))
                {
                    if (selectedStaffId == -1 || !IsCurrentStaff(email, phone))
                    {
                        MessageBox.Show("Nhân viên với email hoặc số điện thoại này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (selectedStaffId == -1) // Add new staff
                {
                    staffDb.AddStaff(firstName, lastName, email, gender, birthDate, phone, address, salary, description, selectedImagePath);
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Update staff
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
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsCurrentStaff(string email, string phone)
        {
            DataTable dt = staffDb.GetAllStaff();
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == selectedStaffId)
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
                    string sourceImagePath = openFileDialog.FileName;
                    string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }

                    string fileName = Path.GetFileNameWithoutExtension(sourceImagePath) + "_" + DateTime.Now.Ticks + Path.GetExtension(sourceImagePath);
                    string destinationImagePath = Path.Combine(imagesFolder, fileName);

                    File.Copy(sourceImagePath, destinationImagePath, true);
                    selectedImagePath = destinationImagePath;

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
