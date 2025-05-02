using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Management_Coffee_Shop
{
    public class ucIncomeLogic : Connection
    {
        public struct RevenueByDate
        {
            public string Date { get; set; }
            public decimal TotalAmount { get; set; }
        }

        public struct UnderStockItem
        {
            public string Name { get; set; }
            public int Stock { get; set; }
        }

        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumCustomers { get; private set; }
        public int NumSuppliers { get; private set; }
        public int NumProducts { get; private set; }
        public List<KeyValuePair<string, int>> TopProductsList { get; private set; }
        public List<UnderStockItem> UnderStockList { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public int NumOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }

        public ucIncomeLogic()
        {
            TopProductsList = new List<KeyValuePair<string, int>>();
            UnderStockList = new List<UnderStockItem>();
            GrossRevenueList = new List<RevenueByDate>();
            NumOrders = 0;
            TotalRevenue = 0;
            TotalProfit = 0;
            NumCustomers = 0;
            NumSuppliers = 0;
            NumProducts = 0;
        }

        private void GetNumberItems()
        {
            string path = "history_Shopping.txt";
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                Console.WriteLine($"Read {lines.Length} lines from history_Shopping.txt");
                var userIds = new HashSet<string>();
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    try
                    {
                        var order = JsonSerializer.Deserialize<Management_Coffee_Shop.FormCustomer.History_Shopping>(line);
                        userIds.Add(order.UserId);
                        Console.WriteLine($"Order: {order.OrderId}, User: {order.UserId}, Date: {order.OrderDate}, Sum: {order.Sum}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deserializing order in GetNumberItems: {ex.Message}");
                    }
                }
                NumCustomers = userIds.Count;
                NumOrders = lines.Count(line => !string.IsNullOrWhiteSpace(line));
                Console.WriteLine($"NumCustomers: {NumCustomers}, NumOrders: {NumOrders}");
            }
            else
            {
                NumCustomers = 0;
                NumOrders = 0;
                Console.WriteLine("history_Shopping.txt does not exist.");
            }

            using (var conn = GetSqlConnection())
            {
                conn.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conn;
                    NumSuppliers = 0; // Giả sử không có nhà cung cấp
                    command.CommandText = "SELECT COUNT(*) FROM [Management Coffee Shop].[dbo].[sourceDrinks]";
                    NumProducts = (int)command.ExecuteScalar();
                    Console.WriteLine($"NumProducts: {NumProducts}");
                }
            }
        }

        private void GetProductAnalysis()
        {
            TopProductsList = new List<KeyValuePair<string, int>>();
            UnderStockList = new List<UnderStockItem>();

            using (var connection = GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    // Lấy danh sách sản phẩm dưới mức tồn kho từ bảng sourceDrinks
                    command.CommandText = "SELECT Name, Sales AS Stock FROM [Management Coffee Shop].[dbo].[sourceDrinks] WHERE Sales <= 10";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        int stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0;
                        UnderStockList.Add(new UnderStockItem
                        {
                            Name = name,
                            Stock = stock
                        });
                        Console.WriteLine($"UnderStock: {name}, Stock: {stock}");
                    }
                    reader.Close();

                    // Lấy danh sách tên sản phẩm từ sourceDrinks
                    var productNames = new Dictionary<string, string>();
                    command.CommandText = "SELECT ID, Name FROM [Management Coffee Shop].[dbo].[sourceDrinks]";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string id = reader["ID"].ToString();
                        string name = reader["Name"].ToString();
                        productNames[id] = name;
                        Console.WriteLine($"Product ID: {id}, Name: {name}");
                    }
                    reader.Close();

                    // Đọc dữ liệu từ history_Shopping.txt để tính top sản phẩm bán chạy
                    string path = "history_Shopping.txt";
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("history_Shopping.txt does not exist for product analysis.");
                        return;
                    }

                    var productSales = new Dictionary<string, int>();
                    var filteredOrders = new List<(string productId, int quantity)>();

                    // Lọc đơn hàng trong khoảng thời gian
                    foreach (var line in File.ReadAllLines(path))
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        try
                        {
                            var order = JsonSerializer.Deserialize<Management_Coffee_Shop.FormCustomer.History_Shopping>(line);
                            // Chuyển thời gian về UTC để so sánh
                            DateTime orderDate = order.OrderDate.ToUniversalTime();
                            DateTime start = startDate.ToUniversalTime();
                            DateTime end = endDate.ToUniversalTime();
                            Console.WriteLine($"Checking order: {order.OrderId}, Date: {orderDate}, Start: {start}, End: {end}");
                            if (orderDate >= start && orderDate <= end)
                            {
                                foreach (var item in order.list_shopping)
                                {
                                    filteredOrders.Add((item.Key, item.Value.Quantity));
                                    Console.WriteLine($"Filtered Order - Product ID: {item.Key}, Quantity: {item.Value.Quantity}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error deserializing order for product analysis: {ex.Message}");
                        }
                    }

                    // Nếu không có đơn hàng trong khoảng thời gian, lấy toàn bộ đơn hàng
                    if (!filteredOrders.Any())
                    {
                        Console.WriteLine("No orders in selected time range, falling back to all orders.");
                        foreach (var line in File.ReadAllLines(path))
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;
                            try
                            {
                                var order = JsonSerializer.Deserialize<Management_Coffee_Shop.FormCustomer.History_Shopping>(line);
                                foreach (var item in order.list_shopping)
                                {
                                    filteredOrders.Add((item.Key, item.Value.Quantity));
                                    Console.WriteLine($"Fallback Order - Product ID: {item.Key}, Quantity: {item.Value.Quantity}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error deserializing order for product analysis (fallback): {ex.Message}");
                            }
                        }
                    }

                    // Tính tổng số lượng bán của từng sản phẩm
                    foreach (var orderItem in filteredOrders)
                    {
                        string productId = orderItem.productId;
                        int quantity = orderItem.quantity;
                        if (productSales.ContainsKey(productId))
                        {
                            productSales[productId] += quantity;
                        }
                        else
                        {
                            productSales[productId] = quantity;
                        }
                        Console.WriteLine($"Product Sales - ID: {productId}, Total Quantity: {productSales[productId]}");
                    }

                    // Chuyển productSales thành TopProductsList (Top 5 sản phẩm)
                    TopProductsList = productSales
                        .Where(x => productNames.ContainsKey(x.Key))
                        .OrderByDescending(x => x.Value)
                        .Take(5)
                        .Select(x => new KeyValuePair<string, int>(productNames[x.Key], x.Value))
                        .ToList();

                    Console.WriteLine($"TopProductsList: {TopProductsList.Count} items");
                    foreach (var product in TopProductsList)
                    {
                        Console.WriteLine($"Product: {product.Key}, Quantity: {product.Value}");
                    }
                }
            }
        }

        private void GetOrderAnalysis(string filterType)
        {
            GrossRevenueList = new List<RevenueByDate>();
            TotalRevenue = 0;
            TotalProfit = 0;

            string path = "history_Shopping.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("history_Shopping.txt does not exist for order analysis.");
                return;
            }

            var lines = File.ReadAllLines(path);
            var orders = new List<KeyValuePair<DateTime, decimal>>();
            var allOrders = new List<KeyValuePair<DateTime, decimal>>();
            int orderIndex = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                try
                {
                    var order = JsonSerializer.Deserialize<Management_Coffee_Shop.FormCustomer.History_Shopping>(line);
                    DateTime orderDate = order.OrderDate != default ? order.OrderDate.ToUniversalTime() : DateTime.Now.AddDays(-orderIndex).ToUniversalTime();
                    orderIndex++;
                    decimal totalAmount = order.Sum;
                    allOrders.Add(new KeyValuePair<DateTime, decimal>(orderDate, totalAmount));
                    DateTime start = startDate.ToUniversalTime();
                    DateTime end = endDate.ToUniversalTime();
                    Console.WriteLine($"Order Date: {orderDate}, Total Amount: {totalAmount}, Start: {start}, End: {end}");
                    if (orderDate >= start && orderDate <= end)
                    {
                        orders.Add(new KeyValuePair<DateTime, decimal>(orderDate, totalAmount));
                        TotalRevenue += totalAmount;
                        Console.WriteLine($"Order included: {order.OrderId}, Date: {orderDate}, Amount: {totalAmount}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deserializing order for order analysis: {ex.Message}");
                }
            }

            if (!orders.Any())
            {
                Console.WriteLine("No orders in selected time range, falling back to all orders.");
                orders = allOrders;
                TotalRevenue = orders.Sum(o => o.Value);
            }

            TotalProfit = TotalRevenue * 0.2m;
            Console.WriteLine($"TotalRevenue: {TotalRevenue}, TotalProfit: {TotalProfit}");

            // Nhóm dữ liệu theo thời gian
            if (filterType == "Today")
            {
                GrossRevenueList = orders
                    .GroupBy(o => o.Key.ToString("dd/MM/yyyy"))
                    .Select(g => new RevenueByDate
                    {
                        Date = g.Key,
                        TotalAmount = g.Sum(x => x.Value)
                    })
                    .OrderBy(r => r.Date)
                    .ToList();
            }
            else if (filterType == "ThisMonth")
            {
                GrossRevenueList = orders
                    .GroupBy(o => o.Key.ToString("dd/MM/yyyy"))
                    .Select(g => new RevenueByDate
                    {
                        Date = g.Key,
                        TotalAmount = g.Sum(x => x.Value)
                    })
                    .OrderBy(r => r.Date)
                    .ToList();
            }
            else
            {
                GrossRevenueList = (from orderList in orders
                                    group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                        orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                    into order
                                    select new RevenueByDate
                                    {
                                        Date = "Week " + order.Key.ToString(),
                                        TotalAmount = order.Sum(amount => amount.Value)
                                    })
                                    .OrderBy(r => r.Date)
                                    .ToList();
            }

            if (!GrossRevenueList.Any() && orders.Any())
            {
                GrossRevenueList.Add(new RevenueByDate
                {
                    Date = "Available Data",
                    TotalAmount = TotalRevenue
                });
            }

            Console.WriteLine($"GrossRevenueList: {GrossRevenueList.Count} items");
            foreach (var revenue in GrossRevenueList)
            {
                Console.WriteLine($"Date: {revenue.Date}, TotalAmount: {revenue.TotalAmount}");
            }
        }

        public bool LoadData(DateTime startDate, DateTime endDate, string filterType = "Custom")
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
            this.startDate = startDate;
            this.endDate = endDate;
            this.numberDays = (endDate - startDate).Days + 1;

            GetNumberItems();
            GetProductAnalysis();
            GetOrderAnalysis(filterType);
            Console.WriteLine("Refreshed data: {0} - {1}", startDate.ToString(), endDate.ToString());
            return true;
        }
    }
}