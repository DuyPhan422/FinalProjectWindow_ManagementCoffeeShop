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
            string path = @"..\..\history_Shopping.txt";
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                Console.WriteLine($"Read {lines.Length} lines from history_Shopping.txt");
                var userIds = new HashSet<string>();
                var validOrders = new List<FormCustomer.History_Shopping>();

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    try
                    {
                        var order = JsonSerializer.Deserialize<Management_Coffee_Shop.FormCustomer.History_Shopping>(line);
                        if (order.list_shopping.Any(item => item.Value.Quantity > 0 && item.Value.Price > 0))
                        {
                            userIds.Add(order.UserId);
                            validOrders.Add(order);
                            Console.WriteLine($"Valid Order: {order.OrderId}, User: {order.UserId}, Date: {order.OrderDate}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deserializing order in GetNumberItems: {ex.Message}, Line: {line}");
                    }
                }
                NumCustomers = userIds.Count;
                NumOrders = validOrders.Count;
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
                    NumSuppliers = 0;
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

                    command.CommandText = "SELECT Name, Sales AS Stock FROM [Management Coffee Shop].[dbo].[sourceDrinks] WHERE Sales <= 10";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        int stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0;
                        UnderStockList.Add(new UnderStockItem { Name = name, Stock = stock });
                        Console.WriteLine($"UnderStock: {name}, Stock: {stock}");
                    }
                    reader.Close();

                    var productNames = new Dictionary<string, string>();
                    command.CommandText = "SELECT ID, Name FROM [Management Coffee Shop].[dbo].[sourceDrinks]";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string id = reader["ID"].ToString();
                        string name = reader["Name"].ToString();
                        productNames[id] = string.IsNullOrEmpty(name) ? $"Product_{id}" : name;
                        Console.WriteLine($"Product ID: {id}, Name: {productNames[id]}");
                    }
                    reader.Close();

                    string path = @"..\..\history_Shopping.txt";
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("history_Shopping.txt does not exist for product analysis.");
                        return;
                    }

                    var productSales = new Dictionary<string, int>();
                    var lines = File.ReadAllLines(path);
                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        try
                        {
                            var order = JsonSerializer.Deserialize<Management_Coffee_Shop.FormCustomer.History_Shopping>(line);
                            DateTime orderDate = order.OrderDate.Date; // Chỉ lấy ngày để so sánh
                            if (orderDate >= startDate.Date && orderDate <= endDate.Date)
                            {
                                foreach (var item in order.list_shopping)
                                {
                                    if (item.Value.Quantity > 0 && item.Value.Price > 0)
                                    {
                                        string productId = item.Key;
                                        int quantity = item.Value.Quantity;
                                        if (productSales.ContainsKey(productId))
                                            productSales[productId] += quantity;
                                        else
                                            productSales[productId] = quantity;
                                        Console.WriteLine($"Product Sale: {productId}, Quantity: {quantity}, Date: {orderDate}");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Order date {orderDate} is outside range {startDate.Date} - {endDate.Date}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error deserializing order for product analysis: {ex.Message}, Line: {line}");
                        }
                    }

                    TopProductsList = productSales
                        .Select(x => new KeyValuePair<string, int>(
                            productNames.ContainsKey(x.Key) ? productNames[x.Key] : $"Product_{x.Key}",
                            x.Value))
                        .OrderByDescending(x => x.Value)
                        .Take(5)
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

            string path = @"..\..\history_Shopping.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("history_Shopping.txt does not exist for order analysis.");
                return;
            }

            var lines = File.ReadAllLines(path);
            var orders = new Dictionary<DateTime, decimal>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                try
                {
                    var order = JsonSerializer.Deserialize<Management_Coffee_Shop.FormCustomer.History_Shopping>(line);
                    DateTime orderDate = order.OrderDate.Date; // Chỉ lấy ngày để so sánh
                    if (orderDate >= startDate.Date && orderDate <= endDate.Date)
                    {
                        foreach (var item in order.list_shopping)
                        {
                            decimal itemRevenue = item.Value.Quantity * item.Value.Price;
                            if (item.Value.Quantity > 0 && item.Value.Price > 0)
                            {
                                DateTime dateKey = orderDate;
                                if (orders.ContainsKey(dateKey))
                                    orders[dateKey] += itemRevenue;
                                else
                                    orders[dateKey] = itemRevenue;
                                TotalRevenue += itemRevenue;
                                Console.WriteLine($"Order: {order.OrderId}, Date: {orderDate}, Item: {item.Key}, Revenue: {itemRevenue}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Order date {orderDate} is outside range {startDate.Date} - {endDate.Date}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deserializing order for order analysis: {ex.Message}, Line: {line}");
                }
            }

            TotalProfit = TotalRevenue * 0.2m;
            Console.WriteLine($"TotalRevenue: {TotalRevenue}, TotalProfit: {TotalProfit}");

            var dateRange = Enumerable.Range(0, numberDays)
                .Select(d => startDate.Date.AddDays(d))
                .ToList();

            GrossRevenueList = dateRange
                .Select(date => new RevenueByDate
                {
                    Date = date.ToString("dd/MM"),
                    TotalAmount = orders.ContainsKey(date) ? orders[date] / 1000 : 0
                })
                .ToList();

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
            this.numberDays = (endDate.Date - startDate.Date).Days + 1;
            Console.WriteLine($"LoadData: StartDate={startDate}, EndDate={endDate}, NumberDays={numberDays}");

            GetNumberItems();
            GetProductAnalysis();
            GetOrderAnalysis(filterType);
            Console.WriteLine($"Refreshed data: {startDate.ToString()} - {endDate.ToString()}");
            return true;
        }
    }
}