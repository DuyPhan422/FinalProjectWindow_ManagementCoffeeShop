using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Google.Apis.Services;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Windows.Forms;
using System.Web;
using System.Net.Http;


namespace Management_Coffee_Shop
{
    internal class Drinks
    {
        
        public static DataTable Loading_Drinks(int pageNumber)
        {
            DataTable dt;
            using (SqlConnection connection = Connection.StringConnection())
            {
                string query = $"SELECT ID,Name,Describe,Price,Rate,Review,Source_Image,Categories FROM sourceDrinks ORDER BY ID ASC OFFSET {(pageNumber - 1) * 16} ROWS FETCH NEXT 16 ROW ONLY";
                connection.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                {
                    dt = new DataTable();
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
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
