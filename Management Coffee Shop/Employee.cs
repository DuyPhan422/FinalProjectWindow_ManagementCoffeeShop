
using Guna.UI2.WinForms;
using Management_Coffee_Shop.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using static Management_Coffee_Shop.FormCustomer;
using static Management_Coffee_Shop.FormCustomer.History_Shopping;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Management_Coffee_Shop
{
    public partial class Employee : Form
    {
        private int currentPage = 1, sum = 0;
        private byte indexPage = 1, lengthPage = 2, homePage = 1, number = 1;
        private string categories;
        private List<Product> list_uCProdcuts;
        private List<Guna2Button> List_buttonPage;
        public Employee()
        {
            InitializeComponent();
            List_buttonPage = new List<Guna2Button> { btnFirst_page, btnSecond_page, btnThird_page };
            list_uCProdcuts = new List<Product> { uC_product1, uC_product2, uC_product3, uC_product4, uC_product5, uC_product6, uC_product7, uC_product8, uC_product9, uC_product10, uC_product11, uC_product12, uC_product13, uC_product14, uC_product15, uC_product16 };
            load_history();
            loading_Shopping();
            pnlBill.Hide();
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = tabPage3;
        }
        private void load_history()
        {
            string path = @"..\..\history_Shopping.txt";
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    History_Shopping history_Shopping = System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(line);
                    Bill bill = new Bill(history_Shopping.list_shopping);
                    bill.LBLCode= history_Shopping.OrderId;
                    bill.LBLTime = $"{history_Shopping.OrderDate:dd/MM/yyyy HH:mm}";
                    bill.LBLStatus = history_Shopping.Status;
                    int ItemCount = 0, Amount = 0;
                    foreach (var kvp in history_Shopping.list_shopping)
                    {
                        ItemCount++;
                        Amount += kvp.Value.Quantity;
                    }
                    bill.LBLSum= string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", history_Shopping.Sum);
                    bill.LBLItemCount=ItemCount.ToString();
                    bill.LBLAmount=Amount.ToString();
                    bill.Clicked += Bill_clicked;
                    flpBill.Controls.Add(bill);
                }
            }
        }
        private void Bill_clicked(object sender, EventArgs e)
        {
            if (sender is Bill clicked)
            {
                pnlBill.Show();
                byte number = 1;
                listView1.Items.Clear();
                lblStatus_Bill.Text = clicked.LBLStatus;
                lblCode_Bill.Text = clicked.LBLCode;
                lblTime_Bill.Text = clicked.LBLTime; 
                string Sum_str=clicked.LBLSum;
                int sum =int.Parse(Regex.Replace(Sum_str, @"[^\d]", ""));
                int subtotal = 0;
                Dictionary<string, ShoppingItem> list_shopping = clicked.List_shopping;
                foreach (var kvp in list_shopping)
                {
                    ListViewItem item = new ListViewItem(number.ToString());
                    string Name = StaffDb.TakeNameDrinks(kvp.Key);
                    item.SubItems.Add(Name);
                    item.SubItems.Add(kvp.Value.Quantity.ToString());
                    item.SubItems.Add(kvp.Value.Price.ToString());
                    subtotal += kvp.Value.Price;
                    listView1.Items.Add(item);
                    number++;
                }
                lblFeeShip_Bill.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", sum-subtotal); 
                lblSubtotal_Bill.Text= string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", subtotal);
                lblSum_Bill.Text= Sum_str.ToString();
            }
        }
        private void ptbImage_Drinks_Click(object sender, EventArgs e)
        {
            if (sender is Product clicked)
            {
                bool check=false;
                foreach(ListViewItem items in listView2.Items)
                {
                    if (items.SubItems[1].Text==clicked.LBLName_Drinks)
                    {
                        int amount = int.Parse(items.SubItems[2].Text)+1;
                        items.SubItems[2].Text= amount.ToString();
                        int price = int.Parse(Regex.Replace(clicked.BTNPrice, @"[^\d]", ""));
                        items.SubItems[3].Text= string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", amount * price);
                        sum += (amount * price);
                        check = true;
                        lblTotal.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", sum);
                        LBLName_Product.Text = clicked.LBLName_Drinks;
                        lblQTV.Text=amount.ToString();
                        break;
                    }
                }
                if (!check)
                {
                    lblQTV.Text = "1";
                    ListViewItem item = new ListViewItem(number.ToString());
                    item.SubItems.Add(clicked.LBLName_Drinks);
                    item.SubItems.Add("1");
                    item.SubItems.Add(clicked.BTNPrice);
                    item.SubItems.Add(clicked.ID);
                    listView2.Items.Add(item);
                    number++;
                    sum+= int.Parse(Regex.Replace(clicked.BTNPrice, @"[^\d]", ""));
                    lblTotal.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ",sum);
                    LBLName_Product.Text = clicked.LBLName_Drinks;
                }
                pnlProduct.Show();
            }
        }
        private void update_page(int indexPage)
        {
            btnFirst_page.Text = (indexPage - 1).ToString();
            btnSecond_page.Text = (indexPage).ToString();
            btnThird_page.Text = (indexPage + 1).ToString();
        }
        private void loading_Shopping()
        {
            DataTable showUp_Categories = Drinks.loading_Categories();
            for (int i = 0; i < showUp_Categories.Rows.Count; i++)
            {
                Guna2Button button = new Guna2Button();
                button.Size = new Size(120, 34);
                button.FillColor = Color.Transparent;
                button.BackColor = Color.FromArgb(243, 243, 243);
                button.BorderRadius = 20;
                button.BorderColor = Color.FromArgb(211, 155, 81);
                button.BorderThickness = 1;
                button.ForeColor = Color.FromArgb(211, 155, 81);
                button.Font = new Font("Segoe UI", 12f);
                button.Margin = new Padding(left: 8, top: 3, right: 8, bottom: 3);
                button.Text = showUp_Categories.Rows[i]["Categories"].ToString();
                button.Click += button_Categories_click;
                flpCategories.Controls.Add(button);
            }
            btnAll.Click += button_Categories_click;
            categories = "ALL";
            btnAll.PerformClick();
        }
        private void button_Categories_click(object sender, EventArgs e)
        {
            foreach (Guna2Button button in flpCategories.Controls)
            {
                button.FillColor = Color.Transparent;
                button.ForeColor = Color.FromArgb(211, 155, 81);
                button.BorderThickness = 1;
                button.BorderColor = Color.FromArgb(211, 155, 81);
            }
            Guna2Button clickedbutton = sender as Guna2Button;
            if (clickedbutton != null)
            {
                indexPage = 1;
                change_Color_page(1);
                currentPage = 1;
                clickedbutton.FillColor = Color.FromArgb(211, 155, 81);
                clickedbutton.BorderThickness = 0;
                clickedbutton.ForeColor = Color.White;
                categories = clickedbutton.Text;
                if (categories == "ALL") lengthPage = (byte)Math.Ceiling((float)Drinks.number_Drinks() / 16);
                else lengthPage = (byte)Math.Ceiling((float)Drinks.number_Drinks_categories(categories) / 16);
                create_Page_Navigation();
                ShowUp_Drinks();
            }
        }
        private void change_Color_page(int turn)
        {
            if (turn == 1)
            {
                btnFirst_page.FillColor = Color.FromArgb(211, 155, 81);
                btnFirst_page.ForeColor = Color.White;
            }
            else if (turn == 2)
            {
                btnSecond_page.FillColor = Color.FromArgb(211, 155, 81);
                btnSecond_page.ForeColor = Color.White;
            }
            else
            {
                btnThird_page.FillColor = Color.FromArgb(211, 155, 81);
                btnThird_page.ForeColor = Color.White;
            }
            if (turn != currentPage)
            {
                List_buttonPage[currentPage - 1].FillColor = Color.Transparent;
                List_buttonPage[currentPage - 1].ForeColor = Color.FromArgb(211, 155, 81);
            }
        }
        private void create_Page_Navigation()
        {
            if (lengthPage == 1)
            {
                btnFirst_page.Show();
                btnFirst_page.Click += btnFirst_Page_Click_1;
                btnSecond_page.Hide();
                btnSecond_page.Click -= btnSecond_page_Click;
                btnThird_page.Hide();
                btnThird_page.Click -= btnThird_page_Click;
                flpPageNavigation_Position(2);
            }
            else if (lengthPage == 2)
            {
                btnFirst_page.Show();
                btnFirst_page.Click += btnFirst_Page_Click_1;
                btnSecond_page.Show();
                btnSecond_page.Click += btnSecond_page_Click;
                btnThird_page.Hide();
                btnThird_page.Click -= btnThird_page_Click;
                flpPageNavigation_Position(1);
            }
        }
        private void flpPageNavigation_Position(byte amount)
        {
            Point flpPageNavigation_location = flpPageNavigation.Location;
            int x = 375;
            flpPageNavigation.Location = new Point(x + amount * 39, flpPageNavigation_location.Y);
        }
        private void btnOnlineOrders_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = tabPage4;
        }
        private void reloading_Shopping(DataTable showUp_Drinks)
        {
            int len = showUp_Drinks.Rows.Count;
            for (int i = 0; i < len; i++)
            {
                list_uCProdcuts[i].Show();
                list_uCProdcuts[i].ID = showUp_Drinks.Rows[i]["ID"].ToString();
                list_uCProdcuts[i].Categories = showUp_Drinks.Rows[i]["Categories"].ToString();
                list_uCProdcuts[i].PTBImage_Drinks = showUp_Drinks.Rows[i]["Source_Image"].ToString();
                list_uCProdcuts[i].LBLName_Drinks = showUp_Drinks.Rows[i]["Name"].ToString();
                list_uCProdcuts[i].LBLDescribe_Drinks = showUp_Drinks.Rows[i]["Describe"].ToString();
                list_uCProdcuts[i].LBLRate_Drinks = showUp_Drinks.Rows[i]["Rate"].ToString();
                list_uCProdcuts[i].BTNReviews_Drinks = showUp_Drinks.Rows[i]["Review"].ToString();
                list_uCProdcuts[i].BTNPrice = showUp_Drinks.Rows[i]["Price"].ToString();
                list_uCProdcuts[i].btnPice_clicked += ptbImage_Drinks_Click;
                list_uCProdcuts[i].ptbImage_Drinks_clicked += ptbImage_Drinks_Click;
            }
            if (len < 16) for (int i = len; i < 16; i++) list_uCProdcuts[i].Hide();
        }
        
        private void ShowUp_Drinks()
        {
            if (categories == "ALL")
            {
                DataTable showUp_Drinks = Drinks.Loading_Drinks(indexPage);
                reloading_Shopping(showUp_Drinks);
            }
            else
            {
                DataTable dt = Drinks.loading_Drinks_Categories(indexPage, categories);
                reloading_Shopping(dt);
            }
        }
        private void btnPage_Next_Click(object sender, EventArgs e)
        {
            if (indexPage < lengthPage)
            {
                if (indexPage == lengthPage - 1)
                {
                    if (lengthPage == 3)
                    {
                        change_Color_page(3);
                        currentPage = 3;
                    }
                    else
                    {
                        change_Color_page(2);
                        currentPage = 2;
                    }
                    indexPage++;
                }
                else
                {
                    if (currentPage == 1)
                    {
                        change_Color_page(2);
                        currentPage = 2;
                        indexPage++;
                    }
                    else if (currentPage == 2)
                    {
                        indexPage++;
                        update_page(indexPage);
                    }
                }
                ShowUp_Drinks();
            }
        }

        private void btnUp_Product_Click(object sender, EventArgs e)
        {
            int amount=int.Parse(lblQTV.Text)+1;
            lblQTV.Text = amount.ToString();
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems[1].Text == LBLName_Product.Text)
                {
                    int price = int.Parse(Regex.Replace(item.SubItems[3].Text, @"[^\d]", "")) / (int.Parse(item.SubItems[2].Text));
                    item.SubItems[3].Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", amount * price);
                    sum += price;
                    item.SubItems[2].Text = amount.ToString();
                    lblTotal.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", sum);
                    break;
                }
            }
        }

        private void btnDown_Product_Click(object sender, EventArgs e)
        {
            int amount = int.Parse(lblQTV.Text);
            if (amount== 1) return;
            amount -= 1;
            lblQTV.Text = amount.ToString();
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems[1].Text == LBLName_Product.Text)
                {
                    int price = int.Parse(Regex.Replace(item.SubItems[3].Text, @"[^\d]", ""))/(int.Parse(item.SubItems[2].Text));
                    item.SubItems[3].Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", amount * price);
                    sum -=  price;
                    item.SubItems[2].Text = amount.ToString();
                    lblTotal.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", sum);
                    break;
                }
            }
        }

        private void btnDelete_Product_Click(object sender, EventArgs e)
        {
            for (int i = listView2.Items.Count - 1; i >= 0; i--)
            {
                var item = listView2.Items[i];
                if (item.SubItems[1].Text == LBLName_Product.Text)
                {
                    sum -= int.Parse(Regex.Replace(item.SubItems[3].Text, @"[^\d]", ""));
                    listView2.Items.RemoveAt(i);
                    number -= 1;
                    lblTotal.Text= string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", sum);
                    pnlProduct.Hide();
                    break;
                }
            }
        }
        private string take_code()
        {
            string path = @"..\..\history_Shopping.txt";
            string lastline = null;
            if (File.Exists(path))
            {
                lastline = File.ReadLines(path).LastOrDefault();
            }
            int current_ID = 0;
            if (!string.IsNullOrWhiteSpace(lastline))
            {
                History_Shopping history_Shopping = System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(lastline);
                current_ID = int.Parse(history_Shopping.OrderId);
            }

            return "Order #" + (++current_ID).ToString().PadLeft(7, '0');

        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            string current_Code= take_code();
            Dictionary<string, ShoppingItem> list_shopping = new Dictionary<string, ShoppingItem>();
            List<(string, int)> number_shopping = new List<(string, int)>();
            foreach (ListViewItem item in listView2.Items)
            {
                int number = int.Parse(Regex.Replace(item.SubItems[3].Text, @"\D", ""));
                list_shopping[item.SubItems[4].Text] = new ShoppingItem
                {
                    Quantity = Convert.ToByte(item.SubItems[2].Text),
                    Price = number
                };
                number_shopping.Add((item.SubItems[4].Text, Convert.ToInt16(item.SubItems[2].Text)));
            }
            Drinks.update_Drinks(number_shopping);
            string path = @"..\..\history_Shopping.txt";
            History_Shopping history_Shopping = new History_Shopping()
            {
                OrderId = Regex.Replace(current_Code, @"[^\d]", ""),
                UserId = "123",
                list_shopping = list_shopping,
                Status = "Offline",
                Sum = int.Parse(Regex.Replace(lblTotal.Text, @"\D", "")),
                OrderDate = DateTime.Now
            };
            string jsonLine = System.Text.Json.JsonSerializer.Serialize(history_Shopping);
            File.AppendAllText(path, jsonLine + Environment.NewLine);
            listView2.Items.Clear();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        // nút mũi tên bên trái của xử lý trang
        private void btnPage_Back_Click(object sender, EventArgs e)
        {
            if (indexPage > 1)
            {
                if (indexPage == 2)
                {
                    change_Color_page(1);
                    currentPage = 1;
                    indexPage--;
                }
                else
                {
                    if (currentPage == 3)
                    {
                        change_Color_page(2);
                        currentPage = 2;
                        indexPage--;
                    }
                    else if (currentPage == 2)
                    {
                        indexPage--;
                        update_page(indexPage);
                    }
                }
                ShowUp_Drinks();
            }
        }
        // nút được biểu thị là số 1 trong xử lý trang
        private void btnFirst_Page_Click_1(object sender, EventArgs e)
        {
            if (currentPage != 1)// tránh nhấn lại nút 
            {
                if (indexPage == 2)
                {
                    indexPage = byte.Parse(btnFirst_page.Text);
                    change_Color_page(1);
                    currentPage = 1;
                }
                else
                {
                    if (currentPage == 3)
                    {
                        if (indexPage != 3)
                        {
                            change_Color_page(2);
                            currentPage = 2;
                            indexPage = byte.Parse(btnFirst_page.Text);
                            update_page(indexPage);
                        }
                        else
                        {
                            indexPage = byte.Parse(btnFirst_page.Text);
                            change_Color_page(1);
                            currentPage = 1;
                        }
                    }
                    else if (currentPage == 2)
                    {
                        indexPage = byte.Parse(btnFirst_page.Text);
                        update_page(indexPage);
                    }
                }
                ShowUp_Drinks();
            }
        }
        // nút được biểu thị là số 2 trong xử lý trang
        private void btnSecond_page_Click(object sender, EventArgs e)
        {
            if (currentPage != 2)// tránh nhấn lại nút 
            {
                if (currentPage == 1) indexPage++;
                else if (currentPage == 3) indexPage--;
                change_Color_page(2);
                currentPage = 2;
                ShowUp_Drinks();
            }
        }
        // nút được biểu thị là số 3 trong xử lý trang
        private void btnThird_page_Click(object sender, EventArgs e)
        {
            if (currentPage != 3)// tránh nhấn lại nút 
            {
                if (indexPage == lengthPage - 1)
                {
                    indexPage = byte.Parse(btnThird_page.Text);
                    change_Color_page(3);
                    currentPage = 3;
                }
                else
                {
                    if (currentPage == 1)
                    {
                        if (indexPage == 1 && lengthPage == 3)
                        {
                            indexPage = byte.Parse(btnThird_page.Text);
                            change_Color_page(3);
                            currentPage = 3;

                        }
                        else
                        {
                            change_Color_page(2);
                            currentPage = 2;
                            indexPage = byte.Parse(btnThird_page.Text);
                            update_page(indexPage);
                        }
                    }
                    else if (currentPage == 2)
                    {
                        indexPage = byte.Parse(btnThird_page.Text);
                        update_page(indexPage);
                    }
                }
                ShowUp_Drinks();
            }
        }
    }
}
