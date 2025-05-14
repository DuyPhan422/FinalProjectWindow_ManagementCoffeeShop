
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
using Twilio.Rest.Messaging.V1.Service;
using static Management_Coffee_Shop.FormCustomer;
using static Management_Coffee_Shop.FormCustomer.History_Shopping;  
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Management_Coffee_Shop
{
    public partial class FormEmployee : Form
    {
        private int length_Order = 0;
        private System.Windows.Forms.Timer Timer_Order = new System.Windows.Forms.Timer();
        private int currentPage = 1, sum = 0,Order_Code_Online=0;
        private byte indexPage = 1, lengthPage = 2, homePage = 1, number = 1;
        private string categories;
        private List<Product> list_uCProdcuts;
        private List<Guna2Button> List_buttonPage;
        private Employee employee;
        private FormLogin formLogin;
        public FormEmployee(string id,string LastName,string Address,string Email,string BirthDate,string Source_Image,FormLogin formLogin)
        {
            employee = new Employee(id, LastName, Address, Email, BirthDate, Source_Image);
            this.formLogin = formLogin;
            InitializeComponent();
            List_buttonPage = new List<Guna2Button> { btnFirst_page, btnSecond_page, btnThird_page };
            list_uCProdcuts = new List<Product> { uC_product1, uC_product2, uC_product3, uC_product4, uC_product5, uC_product6, uC_product7, uC_product8, uC_product9, uC_product10, uC_product11, uC_product12, uC_product13, uC_product14, uC_product15, uC_product16 };
            ptbImage_User.Image = Image.FromFile(employee.Image);
            ptbImage_Account.Image= Image.FromFile(employee.Image);
            lblName_homePage.Text = employee.Name;
            lblName_homePage.Location = new Point(1331 - lblName_homePage.Width, lblName_homePage.Location.Y);
            lblName_Account.Text ="Hello"+ employee.Name;
            lblName_Account.Location = new Point((199 - lblName_Account.Width) / 2, lblName_Account.Location.Y);
            loading_Shopping();
            pnlAccount.Hide();
            load_history();
            pnlBill.Hide();
            pnlBill_Online.Hide();
            pnlProduct.Hide();
            Timer_Order.Interval = 2000;
            Timer_Order.Tick += Timer_Order_Tick;
            Timer_Order.Start();
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedTab = tabPage3;
            flpBill.Controls.Clear();
            load_history();
        }
        private void Timer_Order_Tick(object sender, EventArgs e)
        {
            string path= @"..\..\CustomerToEmployee.txt";
            int current_Length= File.ReadLines(path).Count();
            if (current_Length != 0 && length_Order==0)
            {
                var lines = File.ReadAllLines(path);
                length_Order = current_Length;
                foreach (var line in lines)
                {
                    show_Order(line);
                }
            }

        }
        private void show_Order(string line)
        {
            History_Shopping history_Shopping = System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(line);
            Bill bill = new Bill(history_Shopping.list_shopping);
            bill.LBLCode = history_Shopping.OrderId;
            bill.LBLTime = $"{history_Shopping.OrderDate:dd/MM/yyyy HH:mm}";
            bill.LBLStatus = history_Shopping.Status;
            int ItemCount = 0, Amount = 0;
            foreach (var kvp in history_Shopping.list_shopping)
            {
                ItemCount++;
                Amount += kvp.Value.Quantity;
            }
            bill.LBLSum = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", history_Shopping.Sum);
            bill.LBLItemCount = ItemCount.ToString();
            bill.LBLAmount = Amount.ToString();
            bill.Clicked += Bill_Online_Clicked;
            flpBill_Online.Controls.Add(bill);
        }
        private void Bill_Online_Clicked(object sender, EventArgs e)
        {
            if (sender is Bill clicked)
            {
                if (lblCode_Online.Text == clicked.LBLCode) return;
                Dictionary<string, ShoppingItem> list_shopping = clicked.List_shopping;
                int subtotal = 0;
                int sum = int.Parse(Regex.Replace(clicked.LBLSum, @"[^\d]", ""));
                pnlBill_Online.Show();
                lblCode_Online.Text = clicked.LBLCode;
                lblOrder_Online.Text = "Online";
                lblTime_Online.Text=clicked.LBLTime;
                lblSum_Online.Text = clicked.LBLSum;
                foreach (var kvp in list_shopping)
                {
                    subtotal += kvp.Value.Price;
                    string Name = StaffDb.TakeNameDrinks(kvp.Key);
                    Guna2Panel panel = new Guna2Panel();
                    panel.Size = new Size(405, 49);
                    panel.BackColor= Color.White;
                    Label label1=new Label();
                    label1.BackColor = Color.Transparent;
                    label1.Text = Name;
                    label1.Font = new Font("Segoe UI", 12f);
                    label1.Location = new Point(3, 3);
                    panel.Controls.Add(label1);
                    Label label2=new Label();
                    label2.BackColor = Color.Transparent;
                    label2.Font = new Font("Segoe UI", 8f);
                    label2.Location = new Point(3, 24);
                    panel.Controls.Add(label2);
                    Label label3=new Label();
                    label3.BackColor = Color.Transparent;
                    label3.Font = new Font("Segoe UI", 12f);
                    label3.Location = new Point(193, 3);
                    label3.Text = kvp.Value.Quantity.ToString();
                    panel.Controls.Add(label3);
                    Label label4 = new Label();
                    label4.BackColor = Color.Transparent;
                    label4.Font = new Font("Segoe UI", 12f);
                    label4.Location = new Point(340, 3);
                    label4.Text= string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", kvp.Value.Price); 
                    panel.Controls.Add(label4);
                    Guna2Panel panel1 = new Guna2Panel();
                    panel1.BackColor = Color.Transparent;
                    panel1.FillColor = Color.FromArgb(211, 155, 81);
                    panel1.Size = new Size(405, 3);
                    panel1.Location= new Point(0, 47); 
                    panel.Controls.Add(panel1);
                    flpProduct_Online.Controls.Add(panel);
                }
                lblShip_Online.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", sum - subtotal);
                lblSubToTal_Online.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", subtotal);
            }
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
                    item.SubItems.Add(string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", kvp.Value.Price));
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
                if (listView2.Items.Count == 0) pnlProduct.Show();
                bool check=false;
                foreach(ListViewItem items in listView2.Items)
                {
                    if (items.SubItems[1].Text==clicked.LBLName_Drinks)
                    {
                        int amount = int.Parse(items.SubItems[2].Text)+1;
                        items.SubItems[2].Text= amount.ToString();
                        int price = int.Parse(Regex.Replace(clicked.BTNPrice, @"[^\d]", ""));
                        items.SubItems[3].Text= string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", amount * price);
                        sum += (price);
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
                    for(int j=0;j< listView2.Items.Count; j++)listView2.Items[j].SubItems[0].Text=(j+1).ToString();
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
            if (listView2.Items.Count == 0) return;
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
            pnlProduct.Hide();
            MessageBox.Show("Bạn có muốn in bill không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            sum = 0;
            lblTotal.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", sum);
            pnlProduct.Hide();
            number = 1;
        }

        private void btnDone_Online_Click(object sender, EventArgs e)
        {
            string path = @"..\..\CustomerToEmployee.txt";
            var lines = File.ReadAllLines(path).ToList();
            string orderId = Regex.Replace(lblCode_Online.Text, @"[^\d]", "");
            History_Shopping history_Shop = new History_Shopping();
            for (int i=lines.Count-1; i>=0; i--)
            {
                History_Shopping history_Shopping = System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(lines[i]);
                if (history_Shopping.OrderId == orderId)
                {
                    history_Shop=history_Shopping;
                    lines.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines(path, lines);
            pnlBill_Online.Hide();
            path= @"..\..\EmployeeToCustomer.txt";
            string jsonLine = System.Text.Json.JsonSerializer.Serialize(history_Shop);
            File.AppendAllText(path, jsonLine + Environment.NewLine);
        }
        private void btnCancel_Online_Click(object sender, EventArgs e)
        {
            string path = @"..\..\CustomerToEmployee.txt";
            var lines = File.ReadAllLines(path).ToList();
            string orderId = Regex.Replace(lblCode_Online.Text, @"[^\d]", "");
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                History_Shopping history_Shopping = System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(lines[i]);
                if (history_Shopping.OrderId == orderId)
                {
                    lines.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines(path, lines);
            pnlBill_Online.Hide();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem listViewItem = listView2.SelectedItems[0];
                LBLName_Product.Text = listViewItem.SubItems[1].Text;
                lblQTV.Text=listViewItem.SubItems[2].Text;
                pnlProduct.Show();
            }
        }

        private void ptbImage_User_Click(object sender, EventArgs e)
        {
            if (pnlAccount.Visible==false) pnlAccount.Show();
            else pnlAccount.Hide();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FormForgetPassword formForgetPassword = new FormForgetPassword(formLogin);
            formForgetPassword.change_TabPage();
            formForgetPassword.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            formLogin.change_tabPage();
            formLogin.Show();
            this.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2) tabControl1.SelectedTab = tabPage1;
            else tabControl1.SelectedTab = tabPage2;

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
