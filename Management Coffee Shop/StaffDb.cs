using System;
using System.Data;
using System.Data.SqlClient;

namespace Management_Coffee_Shop
{
    // Custom exception for database connection issues
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string message) : base(message) { }
        public DatabaseConnectionException(string message, Exception inner) : base(message, inner) { }
    }

    public class StaffDb : Connection
    {
        public DataTable GetAllStaff()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT Id, FirstName, LastName, Email, Gender, BirthDate, Phone, Address, Salary, Description FROM dbo.StaffManager";
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
                throw new DatabaseConnectionException("Không thể kết nối hoặc truy vấn cơ sở dữ liệu.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi lấy dữ liệu nhân viên.", ex);
            }
        }

        public void AddStaff(string firstName, string lastName, string email, string gender, DateTime birthDate, string phone, string address, decimal salary, string description)
        {
            try
            {
                ValidateInput(firstName, lastName, email, gender, phone, address);

                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO dbo.StaffManager (FirstName, LastName, Email, Gender, BirthDate, Phone, Address, Salary, Description) " +
                                   "VALUES (@FirstName, @LastName, @Email, @Gender, @BirthDate, @Phone, @Address, @Salary, @Description)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                        command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                        command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                        command.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = gender;
                        command.Parameters.Add("@BirthDate", SqlDbType.Date).Value = birthDate;
                        command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = phone;
                        command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = address;
                        command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = salary;
                        command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = (object)description ?? DBNull.Value;

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            throw new DataException("Không có bản ghi nào được thêm vào cơ sở dữ liệu.");
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Duplicate key violation
                    throw new InvalidOperationException("Email hoặc số điện thoại đã tồn tại trong hệ thống.");
                throw new DatabaseConnectionException("Lỗi khi thêm nhân viên vào cơ sở dữ liệu.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi thêm nhân viên.", ex);
            }
        }

        public void UpdateStaff(int id, string firstName, string lastName, string email, string gender, DateTime birthDate, string phone, string address, decimal salary, string description)
        {
            try
            {
                ValidateInput(firstName, lastName, email, gender, phone, address);

                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE dbo.StaffManager SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Gender = @Gender, " +
                                   "BirthDate = @BirthDate, Phone = @Phone, Address = @Address, Salary = @Salary, Description = @Description WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                        command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                        command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                        command.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = gender;
                        command.Parameters.Add("@BirthDate", SqlDbType.Date).Value = birthDate;
                        command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = phone;
                        command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = address;
                        command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = salary;
                        command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = (object)description ?? DBNull.Value;

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            throw new DataException("Không tìm thấy nhân viên để cập nhật hoặc không có thay đổi nào được thực hiện.");
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Duplicate key violation
                    throw new InvalidOperationException("Email hoặc số điện thoại đã tồn tại trong hệ thống.");
                throw new DatabaseConnectionException("Lỗi khi cập nhật nhân viên trong cơ sở dữ liệu.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi cập nhật nhân viên.", ex);
            }
        }

        public void DeleteStaff(int id)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM dbo.StaffManager WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            throw new DataException("Không tìm thấy nhân viên để xóa.");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Lỗi khi xóa nhân viên khỏi cơ sở dữ liệu.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi xóa nhân viên.", ex);
            }
        }

        private void ValidateInput(string firstName, string lastName, string email, string gender, string phone, string address)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Tên không được để trống.");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Họ không được để trống.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email không được để trống.");
            if (string.IsNullOrWhiteSpace(gender) || (gender != "Male" && gender != "Female"))
                throw new ArgumentException("Giới tính không hợp lệ.");
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("Số điện thoại không được để trống.");
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Địa chỉ không được để trống.");
        }
    }
}