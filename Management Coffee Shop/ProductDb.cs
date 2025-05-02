using Management_Coffee_Shop;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Management_Coffee_Shop
{
    public class ProductDb : Connection
    {
        // Lấy tất cả sản phẩm từ bảng dbo.sourceDrinks
        public DataTable GetAllProducts()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT ID, Name, Describe AS Ingredient, Categories AS Category, Price, Sales AS Stock, Rate AS CustomerRating, Source_Image AS ImagePath " +
                                   "FROM [Management Coffee Shop].[dbo].[sourceDrinks]";
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

        // Thêm sản phẩm mới vào bảng dbo.sourceDrinks
        public void AddProduct(string name, string category, decimal price, int stock, string ingredient, string customerRating, string imagePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category))
                {
                    throw new ArgumentException("Tên và danh mục không được để trống.");
                }

                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO [Management Coffee Shop].[dbo].[sourceDrinks] (Name, Describe, Categories, Price, Sales, Rate, Source_Image) " +
                                   "VALUES (@Name, @Ingredient, @Category, @Price, @Stock, @CustomerRating, @ImagePath)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                        command.Parameters.Add("@Ingredient", SqlDbType.NVarChar).Value = (object)ingredient ?? DBNull.Value;
                        command.Parameters.Add("@Category", SqlDbType.NVarChar).Value = category;
                        command.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;
                        command.Parameters.Add("@Stock", SqlDbType.Int).Value = stock;
                        command.Parameters.Add("@CustomerRating", SqlDbType.NVarChar).Value = (object)customerRating ?? DBNull.Value;
                        command.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value = (object)imagePath ?? DBNull.Value;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm: " + ex.Message, ex);
            }
        }

        public bool CheckProductExists(string name, string category, decimal price, int stock, string ingredient, string customerRating, string imagePath)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM [Management Coffee Shop].[dbo].[sourceDrinks] " +
                                   "WHERE Name = @Name AND Categories = @Category AND Price = @Price AND Sales = @Stock " +
                                   "AND ISNULL(Describe, '') = ISNULL(@Ingredient, '') AND ISNULL(Rate, '') = ISNULL(@CustomerRating, '') " +
                                   "AND ISNULL(Source_Image, '') = ISNULL(@ImagePath, '')";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Stock", stock);
                        command.Parameters.AddWithValue("@Ingredient", (object)ingredient ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CustomerRating", (object)customerRating ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ImagePath", (object)imagePath ?? DBNull.Value);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Cập nhật thông tin sản phẩm trong bảng dbo.sourceDrinks
        public void UpdateProduct(int id, string name, string category, decimal price, int stock, string ingredient, string customerRating, string imagePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category))
                {
                    throw new ArgumentException("Tên và danh mục không được để trống.");
                }

                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE [Management Coffee Shop].[dbo].[sourceDrinks] SET Name = @Name, Describe = @Ingredient, Categories = @Category, " +
                                   "Price = @Price, Sales = @Stock, Rate = @CustomerRating, Source_Image = @ImagePath WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                        command.Parameters.Add("@Ingredient", SqlDbType.NVarChar).Value = (object)ingredient ?? DBNull.Value;
                        command.Parameters.Add("@Category", SqlDbType.NVarChar).Value = category;
                        command.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;
                        command.Parameters.Add("@Stock", SqlDbType.Int).Value = stock;
                        command.Parameters.Add("@CustomerRating", SqlDbType.NVarChar).Value = (object)customerRating ?? DBNull.Value;
                        command.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value = (object)imagePath ?? DBNull.Value;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật sản phẩm: " + ex.Message, ex);
            }
        }

        // Xóa sản phẩm từ bảng dbo.sourceDrinks
        public void DeleteProduct(int id)
        {
            try
            {
                // Lấy đường dẫn ảnh trước khi xóa
                string imagePath = null;
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT Source_Image FROM [Management Coffee Shop].[dbo].[sourceDrinks] WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                        imagePath = command.ExecuteScalar()?.ToString();
                    }
                }

                // Xóa bản ghi trong cơ sở dữ liệu
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM [Management Coffee Shop].[dbo].[sourceDrinks] WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                        command.ExecuteNonQuery();
                    }
                }

                // Xóa file ảnh nếu tồn tại
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    try
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    catch (Exception ex)
                    {
                        // Ghi log nếu không xóa được file ảnh, nhưng không làm gián đoạn quá trình xóa sản phẩm
                        System.Diagnostics.Debug.WriteLine($"Lỗi khi xóa file ảnh: {ex.Message}");
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