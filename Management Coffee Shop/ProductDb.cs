using Management_Coffee_Shop;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Twilio.TwiML.Voice;
using Application = System.Windows.Forms.Application;
namespace Management_Coffee_Shop
{
    public class ProductDb : Connection
    {
        // Tạo ID tự động cho sản phẩm mới
        private string GenerateNewProductId()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT MAX(ID) FROM [Management Coffee Shop].[dbo].[sourceDrinks]";
                    using (var command = new SqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                        {
                            return "0000001"; // Giá trị ID đầu tiên nếu bảng rỗng
                        }

                        string lastId = result.ToString().Trim();
                        int number = int.Parse(lastId.Replace("000", ""));
                        number++;
                        return $"000{number:D4}"; 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo ID sản phẩm: " + ex.Message, ex);
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

                // Tạo ID mới
                string newId = GenerateNewProductId();

                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO [Management Coffee Shop].[dbo].[sourceDrinks] (ID, Name, Describe, Categories, Price, Sales, Rate, Source_Image) " +
                                   "VALUES (@ID, @Name, @Ingredient, @Category, @Price, @Stock, @CustomerRating, @ImagePath)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@ID", SqlDbType.NChar).Value = newId.PadRight(7);
                        command.Parameters.Add("@Name", SqlDbType.NChar).Value = name.PadRight(25);
                        command.Parameters.Add("@Ingredient", SqlDbType.NChar).Value = (object)ingredient?.PadRight(25) ?? DBNull.Value;
                        command.Parameters.Add("@Category", SqlDbType.NChar).Value = category.PadRight(30);
                        command.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;
                        command.Parameters.Add("@Stock", SqlDbType.Int).Value = stock;

                        // Sửa lỗi CS8597: Sử dụng if-else thay vì toán tử ?:
                        if (string.IsNullOrEmpty(customerRating) || customerRating == "Chưa có đánh giá")
                        {
                            command.Parameters.Add("@CustomerRating", SqlDbType.Decimal).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@CustomerRating", SqlDbType.Decimal).Value = Convert.ToDecimal(customerRating);
                        }

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
                    // Lấy ID dưới dạng chuỗi từ cơ sở dữ liệu
                    string queryId = "SELECT ID FROM [Management Coffee Shop].[dbo].[sourceDrinks] WHERE ID = @ID";
                    string stringId;
                    using (var commandId = new SqlCommand(queryId, connection))
                    {
                        commandId.Parameters.Add("@ID", SqlDbType.NChar).Value = id.ToString("D7").PadRight(7);
                        stringId = commandId.ExecuteScalar()?.ToString();
                        if (string.IsNullOrEmpty(stringId))
                        {
                            throw new Exception("Không tìm thấy sản phẩm với ID này.");
                        }
                    }

                    string query = "UPDATE [Management Coffee Shop].[dbo].[sourceDrinks] SET Name = @Name, Describe = @Ingredient, Categories = @Category, " +
                                   "Price = @Price, Sales = @Stock, Rate = @CustomerRating, Source_Image = @ImagePath WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@ID", SqlDbType.NChar).Value = stringId.PadRight(7);
                        command.Parameters.Add("@Name", SqlDbType.NChar).Value = name.PadRight(25);
                        command.Parameters.Add("@Ingredient", SqlDbType.NChar).Value = (object)ingredient?.PadRight(25) ?? DBNull.Value;
                        command.Parameters.Add("@Category", SqlDbType.NChar).Value = category.PadRight(30);
                        command.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;
                        command.Parameters.Add("@Stock", SqlDbType.Int).Value = stock;

                        // Xử lý tham số @CustomerRating
                        if (string.IsNullOrEmpty(customerRating) || customerRating == "Chưa có đánh giá")
                        {
                            command.Parameters.Add("@CustomerRating", SqlDbType.Decimal).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@CustomerRating", SqlDbType.Decimal).Value = Convert.ToDecimal(customerRating);
                        }

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

        // Kiểm tra sản phẩm đã tồn tại chưa
        public bool CheckProductExists(string name, string category, decimal price, int stock, string ingredient, string customerRating, string imagePath)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM [Management Coffee Shop].[dbo].[sourceDrinks] " +
                                   "WHERE Name = @Name AND Categories = @Category AND Price = @Price AND Sales = @Stock " +
                                   "AND ISNULL(Describe, '') = ISNULL(@Ingredient, '') AND ISNULL(CAST(Rate AS NVARCHAR), '') = ISNULL(@CustomerRating, '') " +
                                   "AND ISNULL(Source_Image, '') = ISNULL(@ImagePath, '')";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name.PadRight(25));
                        command.Parameters.AddWithValue("@Category", category.PadRight(30));
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Stock", stock);
                        command.Parameters.AddWithValue("@Ingredient", (object)ingredient?.PadRight(25) ?? DBNull.Value);

                        // Sửa lỗi CS8597: Sử dụng if-else thay vì toán tử ?:
                        if (string.IsNullOrEmpty(customerRating) || customerRating == "Chưa có đánh giá")
                        {
                            command.Parameters.AddWithValue("@CustomerRating", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@CustomerRating", customerRating);
                        }

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

        // Các phương thức khác giữ nguyên
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

        public void DeleteProduct(int id)
        {
            try
            {
                // Tạo ID với định dạng 000xxxx
                string formattedId = $"000{id:D4}";
                if (formattedId.Length != 7)
                {
                    throw new ArgumentException("ID không hợp lệ, phải có đúng 7 ký tự theo định dạng 000xxxx.");
                }

                // Lấy đường dẫn ảnh trước khi xóa
                string imageRelativePath = null;
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT Source_Image FROM [Management Coffee Shop].[dbo].[sourceDrinks] WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@ID", SqlDbType.NChar).Value = formattedId;
                        imageRelativePath = command.ExecuteScalar()?.ToString();
                    }
                }

                // Xóa bản ghi trong cơ sở dữ liệu
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM [Management Coffee Shop].[dbo].[sourceDrinks] WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@ID", SqlDbType.NChar).Value = formattedId;
                        command.ExecuteNonQuery();
                    }
                }

                // Xóa file ảnh nếu tồn tại
                if (!string.IsNullOrEmpty(imageRelativePath))
                {
                    string currentPath = Application.StartupPath;
                    // Đường dẫn đã sử dụng dấu \, không cần thay thế thêm
                    string fullImagePath = Path.GetFullPath(Path.Combine(currentPath, imageRelativePath));
                    if (File.Exists(fullImagePath))
                    {
                        try
                        {
                            File.Delete(fullImagePath);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Lỗi khi xóa file ảnh: {ex.Message}");
                        }
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