using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Management_Coffee_Shop
{
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string message) : base(message) { }
        public DatabaseConnectionException(string message, Exception inner) : base(message, inner) { }
    }

    public class StaffDb : Connection
    {
        private string GenerateNewStaffId()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT MAX(ID) FROM [Management Coffee Shop].[dbo].[StaffManager]";
                    using (var command = new SqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result == null || result == DBNull.Value || !result.ToString().StartsWith("E"))
                        {
                            return "E00001"; // Bắt đầu từ E00001 nếu không có dữ liệu
                        }

                        string lastId = result.ToString().Trim();
                        int number = int.Parse(lastId.Replace("E00", ""));
                        number++;
                        return $"E00{number:D4}"; // Đảm bảo định dạng E00xxxx
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo ID nhân viên: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
            }
        }

        public DataTable GetAllStaff()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT ID, FirstName, LastName, Email, Gender, BirthDate, Phone, Address, Salary, Description, Source_Image FROM [Management Coffee Shop].[dbo].[StaffManager]";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException($"Không thể kết nối hoặc truy vấn cơ sở dữ liệu: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi không xác định khi lấy dữ liệu nhân viên: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
            }
        }

        public bool CheckStaffExists(string email, string phone, string excludeId = null)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM [Management Coffee Shop].[dbo].[StaffManager] WHERE (Email = @Email OR Phone = @Phone)";
                    if (!string.IsNullOrEmpty(excludeId))
                    {
                        query += " AND ID != @ExcludeId";
                    }
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email?.Trim() ?? "");
                        command.Parameters.AddWithValue("@Phone", phone?.Trim() ?? "");
                        if (!string.IsNullOrEmpty(excludeId))
                        {
                            command.Parameters.AddWithValue("@ExcludeId", excludeId.Trim());
                        }
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException($"Lỗi khi kiểm tra nhân viên: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi không xác định khi kiểm tra nhân viên: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
            }
        }

        public void AddStaff(string firstName, string lastName, string email, string gender, DateTime birthDate, string phone, string address, decimal salary, string description, string sourceImagePath)
        {
            try
            {
                ValidateInput(firstName, lastName, email, gender, phone, address, description, salary, sourceImagePath);

                using (var connection = GetConnection())
                {
                    connection.Open();
                    string newId = GenerateNewStaffId();

                    // Kiểm tra trùng lặp ID (dù rất khó xảy ra)
                    string checkIdQuery = "SELECT COUNT(*) FROM [Management Coffee Shop].[dbo].[StaffManager] WHERE ID = @ID";
                    using (var checkCommand = new SqlCommand(checkIdQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@ID", newId);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            throw new InvalidOperationException($"ID nhân viên đã tồn tại: {newId}");
                        }
                    }

                    string newImagePath = null;
                    if (!string.IsNullOrEmpty(sourceImagePath))
                    {
                        string targetFolder = @"..\..\Management coffee shop_image";
                        if (!Directory.Exists(targetFolder))
                        {
                            Directory.CreateDirectory(targetFolder);
                        }

                        // Kiểm tra quyền ghi
                        try
                        {
                            string testPath = Path.Combine(targetFolder, "test.txt");
                            using (FileStream fs = File.Create(testPath))
                            {
                                fs.Close();
                            }
                            File.Delete(testPath);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            throw new UnauthorizedAccessException($"Không có quyền ghi vào thư mục: {targetFolder}");
                        }

                        newImagePath = Path.Combine(targetFolder, $"{newId}.jpg");
                        File.Copy(sourceImagePath, newImagePath, true);
                    }

                    string query = "INSERT INTO [Management Coffee Shop].[dbo].[StaffManager] (ID, FirstName, LastName, Gender, BirthDate, Email, Phone, Address, Salary, Description, Source_Image) " +
                                   "VALUES (@ID, @FirstName, @LastName, @Gender, @BirthDate, @Email, @Phone, @Address, @Salary, @Description, @SourceImage)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", newId.PadRight(7));
                        command.Parameters.AddWithValue("@FirstName", firstName.PadRight(15));
                        command.Parameters.AddWithValue("@LastName", lastName.PadRight(15));
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@BirthDate", birthDate);
                        command.Parameters.AddWithValue("@Email", email.PadRight(30));
                        command.Parameters.AddWithValue("@Phone", phone.PadRight(15));
                        command.Parameters.AddWithValue("@Address", address.PadRight(50));
                        command.Parameters.AddWithValue("@Salary", salary);
                        command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description.PadRight(50));
                        command.Parameters.AddWithValue("@SourceImage", (object)newImagePath ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new InvalidOperationException("Email hoặc số điện thoại đã tồn tại trong hệ thống.");
                throw new DatabaseConnectionException($"Lỗi khi thêm nhân viên vào cơ sở dữ liệu: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi không xác định khi thêm nhân viên: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
            }
        }

        public void UpdateStaff(string id, string firstName, string lastName, string email, string gender, DateTime birthDate, string phone, string address, decimal salary, string description, string sourceImagePath)
        {
            try
            {
                ValidateInput(firstName, lastName, email, gender, phone, address, description, salary, sourceImagePath);

                using (var connection = GetConnection())
                {
                    connection.Open();
                    string oldImagePath = null;
                    string getOldImageQuery = "SELECT Source_Image FROM [Management Coffee Shop].[dbo].[StaffManager] WHERE ID = @ID";
                    using (var command = new SqlCommand(getOldImageQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id.PadRight(7));
                        oldImagePath = command.ExecuteScalar()?.ToString();
                    }

                    string newImagePath = oldImagePath;
                    if (!string.IsNullOrEmpty(sourceImagePath) && sourceImagePath != oldImagePath)
                    {
                        string targetFolder = @"..\..\Management coffee shop_image";
                        if (!Directory.Exists(targetFolder))
                        {
                            Directory.CreateDirectory(targetFolder);
                        }

                        try
                        {
                            string testPath = Path.Combine(targetFolder, "test.txt");
                            using (FileStream fs = File.Create(testPath))
                            {
                                fs.Close();
                            }
                            File.Delete(testPath);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            throw new UnauthorizedAccessException($"Không có quyền ghi vào thư mục: {targetFolder}");
                        }

                        newImagePath = Path.Combine(targetFolder, $"{id}.jpg");
                        File.Copy(sourceImagePath, newImagePath, true);

                        if (!string.IsNullOrEmpty(oldImagePath) && File.Exists(oldImagePath) && oldImagePath != newImagePath)
                        {
                            try
                            {
                                File.Delete(oldImagePath);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine($"Lỗi khi xóa file ảnh cũ: {ex.Message}");
                            }
                        }
                    }

                    string query = "UPDATE [Management Coffee Shop].[dbo].[StaffManager] SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Gender = @Gender, " +
                                   "BirthDate = @BirthDate, Phone = @Phone, Address = @Address, Salary = @Salary, Description = @Description, Source_Image = @SourceImage WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id.PadRight(7));
                        command.Parameters.AddWithValue("@FirstName", firstName.PadRight(15));
                        command.Parameters.AddWithValue("@LastName", lastName.PadRight(15));
                        command.Parameters.AddWithValue("@Email", email.PadRight(30));
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@BirthDate", birthDate);
                        command.Parameters.AddWithValue("@Phone", phone.PadRight(15));
                        command.Parameters.AddWithValue("@Address", address.PadRight(50));
                        command.Parameters.AddWithValue("@Salary", salary);
                        command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description.PadRight(50));
                        command.Parameters.AddWithValue("@SourceImage", (object)newImagePath ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new InvalidOperationException("Email hoặc số điện thoại đã tồn tại trong hệ thống.");
                throw new DatabaseConnectionException($"Lỗi khi cập nhật nhân viên trong cơ sở dữ liệu: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi không xác định khi cập nhật nhân viên: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
            }
        }

        public void DeleteStaff(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id) || !id.StartsWith("E00") || id.Length != 7)
                {
                    throw new ArgumentException("ID nhân viên không hợp lệ! Phải có định dạng E00xxxx (7 ký tự).");
                }

                string imagePath = null;
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT Source_Image FROM [Management Coffee Shop].[dbo].[StaffManager] WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id.PadRight(7));
                        imagePath = command.ExecuteScalar()?.ToString();
                    }

                    query = "DELETE FROM [Management Coffee Shop].[dbo].[StaffManager] WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id.PadRight(7));
                        command.ExecuteNonQuery();
                    }
                }

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    try
                    {
                        File.Delete(imagePath);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Lỗi khi xóa file ảnh: {ex.Message}");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException($"Lỗi khi xóa nhân viên khỏi cơ sở dữ liệu: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi không xác định khi xóa nhân viên: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
            }
        }

        public static string TakeNameDrinks(string id)
        {
            string name = "";
            try
            {
                using (SqlConnection conn = Connection.GetSqlConnection())
                {
                    string query = "SELECT Name FROM sourceDrinks WHERE ID = @ID";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@ID", id.PadRight(7));
                        object result = command.ExecuteScalar();
                        name = result?.ToString()?.Trim() ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi lấy tên đồ uống: {ex.Message}");
            }
            return name;
        }

        private void ValidateInput(string firstName, string lastName, string email, string gender, string phone, string address, string description, decimal salary, string sourceImagePath)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Tên không được để trống.");
            if (firstName.Length > 15)
                throw new ArgumentException("Tên không được dài quá 15 ký tự.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Họ không được để trống.");
            if (lastName.Length > 15)
                throw new ArgumentException("Họ không được dài quá 15 ký tự.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email không được để trống.");
            if (email.Length > 30)
                throw new ArgumentException("Email không được dài quá 30 ký tự.");

            if (string.IsNullOrWhiteSpace(gender) || (gender != "Male" && gender != "Female"))
                throw new ArgumentException("Giới tính không hợp lệ.");

            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("Số điện thoại không được để trống.");
            if (phone.Length > 15)
                throw new ArgumentException("Số điện thoại không được dài quá 15 ký tự.");
            if (phone.Length < 10 || !phone.All(char.IsDigit))
                throw new ArgumentException("Số điện thoại không hợp lệ (phải có ít nhất 10 chữ số).");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Địa chỉ không được để trống.");
            if (address.Length > 50)
                throw new ArgumentException("Địa chỉ không được dài quá 50 ký tự.");

            if (salary < 0)
                throw new ArgumentException("Lương không được âm.");
            if (salary > 99999999.99m)
                throw new ArgumentException("Lương không được vượt quá 99999999.99.");

            if (!string.IsNullOrEmpty(description) && description.Length > 50)
                throw new ArgumentException("Mô tả không được dài quá 50 ký tự.");

            if (!string.IsNullOrEmpty(sourceImagePath) && sourceImagePath.Length > 60)
                throw new ArgumentException("Đường dẫn ảnh không được dài quá 60 ký tự.");
        }
    }
}