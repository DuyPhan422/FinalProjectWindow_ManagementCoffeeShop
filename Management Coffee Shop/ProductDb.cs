using Management_Coffee_Shop;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Management_Coffee_Shope
{
    public class ProductDb : DbConnection
    {
        // Lấy tất cả sản phẩm từ bảng dbo.ProductManager
        public DataTable GetAllProducts()
{
    try
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            string query = "SELECT ID, Name, Category, Price, Unit, Stock, Ingredient, Supplier, CustomerRating FROM dbo.ProductManager";
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
    catch (Exception ex)
    {
        throw new Exception("Lỗi khi lấy dữ liệu sản phẩm: " + ex.Message, ex);
    }
}

        // Thêm sản phẩm mới vào bảng dbo.ProductManager
        public void AddProduct(string name, string category, decimal price, string unit, int stock, string ingredient, string supplier, string customerRating)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(unit))
                {
                    throw new ArgumentException("Tên, danh mục và đơn vị không được để trống.");
                }

                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO dbo.ProductManager (Name, Category, Price, Unit, Stock, Ingredient, Supplier, CustomerRating) " +
                                   "VALUES (@Name, @Category, @Price, @Unit, @Stock, @Ingredient, @Supplier, @CustomerRating)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                        command.Parameters.Add("@Category", SqlDbType.NVarChar).Value = category;
                        command.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;
                        command.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = unit;
                        command.Parameters.Add("@Stock", SqlDbType.Int).Value = stock;
                        command.Parameters.Add("@Ingredient", SqlDbType.NVarChar).Value = (object)ingredient ?? DBNull.Value;
                        command.Parameters.Add("@Supplier", SqlDbType.NVarChar).Value = (object)supplier ?? DBNull.Value;
                        command.Parameters.Add("@CustomerRating", SqlDbType.VarChar).Value = customerRating;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm: " + ex.Message, ex);
            }
        }
        public bool CheckProductExists(string name, string category, decimal price, string unit, int stock, string ingredient, string supplier, string customerRating)
        {
            try
            {
                using (var connection = GetConnection()) // Sử dụng GetConnection() như các phương thức khác
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM dbo.ProductManager " +
                                   "WHERE Name = @Name AND Category = @Category AND Price = @Price AND Unit = @Unit " +
                                   "AND Stock = @Stock AND ISNULL(Ingredient, '') = ISNULL(@Ingredient, '') " +
                                   "AND ISNULL(Supplier, '') = ISNULL(@Supplier, '') AND CustomerRating = @CustomerRating";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Unit", unit);
                        command.Parameters.AddWithValue("@Stock", stock);
                        command.Parameters.AddWithValue("@Ingredient", (object)ingredient ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Supplier", (object)supplier ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CustomerRating", customerRating);
                        int count = (int)command.ExecuteScalar();
                        return count > 0; // Trả về true nếu đã có sản phẩm với tất cả thông tin giống hệt
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        // Cập nhật thông tin sản phẩm trong bảng dbo.ProductManager
        public void UpdateProduct(int id, string name, string category, decimal price, string unit, int stock, string ingredient, string supplier, string customerRating)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(unit))
                {
                    throw new ArgumentException("Tên, danh mục và đơn vị không được để trống.");
                }

                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE dbo.ProductManager SET Name = @Name, Category = @Category, Price = @Price, Unit = @Unit, Stock = @Stock, " +
                                   "Ingredient = @Ingredient, Supplier = @Supplier, CustomerRating = @CustomerRating WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                        command.Parameters.Add("@Category", SqlDbType.NVarChar).Value = category;
                        command.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;
                        command.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = unit;
                        command.Parameters.Add("@Stock", SqlDbType.Int).Value = stock;
                        command.Parameters.Add("@Ingredient", SqlDbType.NVarChar).Value = (object)ingredient ?? DBNull.Value;
                        command.Parameters.Add("@Supplier", SqlDbType.NVarChar).Value = (object)supplier ?? DBNull.Value;
                        command.Parameters.Add("@CustomerRating", SqlDbType.VarChar).Value = customerRating;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật sản phẩm: " + ex.Message, ex);
            }
        }

        // Xóa sản phẩm từ bảng dbo.ProductManager
        public void DeleteProduct(int id)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM dbo.ProductManager WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa sản phẩm: " + ex.Message, ex);
            }
        }
    }
}