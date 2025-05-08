
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Windows.Forms;
using System.Web;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using static Management_Coffee_Shop.FormCustomer.History_Shopping;
using System.Data.Common;


namespace Management_Coffee_Shop
{
    internal class Drinks
    {
        public static DataTable Loading_Drinks(int pageNumber)
        {
            DataTable dt;
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = $"SELECT ID,Name,Describe,Price,Rate,Review,Source_Image,Categories FROM sourceDrinks ORDER BY ID ASC OFFSET {(pageNumber - 1) * 16} ROWS FETCH NEXT 16 ROWS ONLY";
                connection.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                {
                    dt = new DataTable();
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
        }
        public static DataTable get_history(string id)
        {
            DataTable dt;
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = $"SELECT Name,Describe,Source_Image FROM sourceDrinks WHERE ID=@ID";
                connection.Open();
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            dt=new DataTable();
                            dataAdapter.Fill(dt);
                        }
                    }
                }
            }
            return dt;
        }
        public static byte number_Drinks()
        {
            byte count = 0;
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = $"SELECT COUNT(*) FROM sourceDrinks";
                connection.Open();
                using (SqlCommand commnad = new SqlCommand(query, connection))
                {
                    object result = commnad.ExecuteScalar();
                    count = Convert.ToByte(result);
                }
            }
            return count;
        }
        public static void update_Drinks(List<(string, int)> number_shopping)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = $"UPDATE sourceDrinks SET Sales=@Sales WHERE ID=@ID";
                connection.Open();
                foreach ((string id, int number) in number_shopping)
                {
                    using (SqlCommand commnad = new SqlCommand(query, connection))
                    {
                        commnad.Parameters.AddWithValue("@ID", id);
                        commnad.Parameters.AddWithValue("@Sales",number);
                        commnad.ExecuteNonQuery();
                    }
                }
            }
        }
        public static DataTable get_Image_User(string id)
        {
            DataTable dt;
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                string query = $"SELECT Image,Name FROM customerInformation WHERE ID=@ID";
                conn.Open();
                using (SqlCommand commnad = new SqlCommand(query, conn))
                {
                    commnad.Parameters.AddWithValue("@ID", id);
                    using (SqlDataAdapter commnadAdapter = new SqlDataAdapter(commnad))
                    {
                        dt = new DataTable();
                        commnadAdapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public static void update_User(string id,string name,string date,string address,string Email,string image)
        {
            using (SqlConnection conn = Connection.GetSqlConnection())
            {
                string query = "UPDATE customerInformation SET Name = @Name, Date = @Date, Address = @Address, Image = @Image WHERE ID = @ID";
                conn.Open();
                using(SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue ("@Address", address);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Image", image);
                    command.ExecuteNonQuery();
                }
                query = "UPDATE account SET Email=@Email WHERE ID=@ID";
                using(SqlCommand command=new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Email",Email);
                    command.ExecuteNonQuery ();
                }
            }
        }
        public static void set_Rate(string id,byte Rank,int Sales)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = "SELECT Rate, Review, Sales FROM sourceDrinks WHERE ID = @ID";
                double currentRate = 0;
                int currentReviews = 0, currentSales = 0;
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            currentRate = Convert.ToDouble(reader["Rate"]);
                            currentReviews = Convert.ToInt32(reader["Review"]);
                            currentSales = Convert.ToInt32(reader["Sales"]);
                        }
                    }
                }
                int newReviews = currentReviews + 1;
                double newRate = ((currentRate * currentReviews) + Rank) / newReviews;
                int newSales = currentSales +Sales;
                newRate = Math.Min(newRate, 999.99); 
                query = "UPDATE sourceDrinks SET Rate = @Rate, Review = @Review, Sales = @Sales WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Rate", newRate);
                    command.Parameters.AddWithValue("@Review", newReviews);
                    command.Parameters.AddWithValue("@Sales", newSales);
                    command.ExecuteNonQuery();
                }
            }
        }
        public static DataTable loading_Categories()
        {
            DataTable dt;
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = $"SELECT DISTINCT Categories FROM sourceDrinks ";
                connection.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                {
                    dt = new DataTable();
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
        }
        public static DataTable loading_Drinks_Categories(int pageNumber,string categories)
        {
            DataTable dt;
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = $"SELECT ID,Name,Describe,Price,Rate,Review,Source_Image,Categories FROM sourceDrinks WHERE Categories=@categories ORDER BY ID ASC OFFSET {(pageNumber - 1) * 16} ROWS FETCH NEXT 16 ROWS ONLY";
                connection.Open();
                using (SqlCommand commnad = new SqlCommand(query, connection))
                {
                    commnad.Parameters.AddWithValue("@categories", categories);
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(commnad))
                    {
                        dt = new DataTable();
                        dataAdapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public static DataTable get_Top3_BestSeller()
        {
            DataTable dt;
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = $"SELECT TOP 3 Name, [Describe], Rate, Review, Source_Image FROM sourceDrinks ORDER BY Sales DESC";
                connection.Open() ;
                using(SqlDataAdapter dataAdapter=new SqlDataAdapter(query, connection))
                {
                    dt = new DataTable();
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
        }
        public static byte number_Drinks_categories(string categories)
        {
            byte count = 0;
            using(SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = $"SELECT COUNT(*) FROM sourceDrinks WHERE Categories=@categories";
                connection.Open();
                using (SqlCommand commnad = new SqlCommand(query, connection))
                {
                    commnad.Parameters.AddWithValue("@categories", categories);
                    object result = commnad.ExecuteScalar();
                    count = Convert.ToByte(result);
                }
            }
            return count;
        }
        public static string change_Coordinates(string address)
        {
            string apiKey = "WxT7Wuy87UD0l388s99ils0VIinvE9R07DaRZE694b4"; // Thay bằng API Key của bạn

            string url = $"https://geocode.search.hereapi.com/v1/geocode?q={Uri.EscapeDataString(address)}&apiKey={apiKey}";

            using (WebClient client = new WebClient())
            {
                try
                {
                    string json = client.DownloadString(url);
                    JObject data = JObject.Parse(json);

                    if (data["items"] != null && data["items"].HasValues)
                    {
                        var position = data["items"][0]["position"];
                        string lat = position["lat"].ToString();
                        string lon = position["lng"].ToString();
                        string pos = $"{lat},{lon}";
                        return pos;
                        
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tọa độ.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
            return "0";
        }
        public static (double,double) distance_time(string address)
        {
            string apiKey = "WxT7Wuy87UD0l388s99ils0VIinvE9R07DaRZE694b4"; // Thay bằng API Key của bạn
            string origin = change_Coordinates("01 Đ. Võ Văn Ngân, Linh Chiểu, Thủ Đức, Hồ Chí Minh, Việt Nam");  // Tọa độ điểm xuất phát (TPHCM)
            string destination = change_Coordinates(address); // Tọa độ điểm đến (Hà Nội)

            string url = $"https://router.hereapi.com/v8/routes?transportMode=car&origin={origin}&destination={destination}&return=summary&apikey={apiKey}";

            using (WebClient client = new WebClient())
            {
                try
                {
                    string json = client.DownloadString(url);
                    JObject data = JObject.Parse(json);

                    if (data["routes"] != null && data["routes"].HasValues)
                    {
                        var summary = data["routes"][0]["sections"][0]["summary"];
                        double distance = summary["length"].ToObject<double>() / 1000; // Đổi từ mét sang km
                        double duration = summary["duration"].ToObject<double>() / 60; // Đổi từ giây sang phút

                        return (distance,duration);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tuyến đường.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
            return (0.0,0.0);
        }
        public static int fee_ship(double distance)
        {
            int fee = 10000;
            if ((int)distance > 3) fee += ((int)Math.Ceiling(distance)-3) * 3500;
            return fee;
        }
    }
}
