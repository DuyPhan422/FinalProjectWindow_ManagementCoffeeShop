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
            public string Unit { get; set; }
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
                        var order = JsonSerializer.Deserialize<FormCustomer.History_Shopping>(line);
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
                    command.CommandText = "SELECT COUNT(*) FROM sourceDrinks";
                    NumProducts = (int)command.ExecuteScalar();
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

                    command.CommandText = "SELECT Name, Unit, Stock FROM ProductManager";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        string unit = reader["Unit"].ToString();
                        int stock = (int)reader["Stock"];
                        UnderStockList.Add(new UnderStockItem
                        {
                            Name = name,
                            Unit = unit,
                            Stock = stock
                        });
                    }
                    reader.Close();

                    var productNames = new Dictionary<string, string>();
                    command.CommandText = "SELECT ID, Name FROM sourceDrinks";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productNames[reader["ID"].ToString()] = reader["Name"].ToString();
                    }
                    reader.Close();

                    string path = "history_Shopping.txt";
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("history_Shopping.txt does not exist for product analysis.");
                        return;
                    }

                    var productSales = new Dictionary<string, int>();
                    var lines = File.ReadAllLines(path);
                    var filteredOrders = new List<(string productId, int quantity)>();

                    // Lọc đơn hàng trong khoảng thời gian
                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        try
                        {
                            var order = JsonSerializer.Deserialize<FormCustomer.History_Shopping>(line);
                            if (order.OrderDate >= startDate && order.OrderDate <= endDate)
                            {
                                foreach (var item in order.list_shopping)
                                {
                                    filteredOrders.Add((item.Key, item.Value.Quantity));
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
                        foreach (var line in lines)
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;
                            try
                            {
                                var order = JsonSerializer.Deserialize<FormCustomer.History_Shopping>(line);
                                foreach (var item in order.list_shopping)
                                {
                                    filteredOrders.Add((item.Key, item.Value.Quantity));
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
                    var order = JsonSerializer.Deserialize<FormCustomer.History_Shopping>(line);
                    DateTime orderDate = order.OrderDate != default ? order.OrderDate : DateTime.Now.AddDays(-orderIndex);
                    orderIndex++;
                    decimal totalAmount = order.Sum;
                    allOrders.Add(new KeyValuePair<DateTime, decimal>(orderDate, totalAmount));
                    if (orderDate >= startDate && orderDate <= endDate)
                    {
                        orders.Add(new KeyValuePair<DateTime, decimal>(orderDate, totalAmount));
                        TotalRevenue += totalAmount;
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