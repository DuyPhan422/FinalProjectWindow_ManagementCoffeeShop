using Guna.UI2.WinForms;
using Management_Coffee_Shop.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static Management_Coffee_Shop.FormCustomer.History_Shopping;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;
using System.IO.Pipelines;
using Twilio.TwiML.Voice;

namespace Management_Coffee_Shop
{
    public partial class FormCustomer : Form
    {
        public class History_Shopping
        {
            public string OrderId { get; set; }
            public string UserId { get; set; }
            public Dictionary<string, ShoppingItem> list_shopping { get; set; }
            public int Sum { get; set; }
            public DateTime OrderDate { get; set; }
            public string Status { get; set; }
            public class ShoppingItem
            {
                public byte Quantity { get; set; }
                public int Price { get; set; }
            }
        }
        private Customer customer;
        private bool check,flag_order;
        private static Dictionary<string, (int, int, Boolean)> list_products = new Dictionary<string, (int, int, Boolean)>();
        private int minute, hour, currentPage = 1, count = 0;
        private byte indexPage = 1, lengthPage = 2,homePage=1;
        private double distance, duration;
        private string tt,categories,new_image;
        private static int current_ID = 0;
        private FormLogin FormLogin;
        private List<Product> list_uCProdcuts;
        private List<string> list_bestSeller=new List<string>();
        private System.Windows.Forms.Timer timer_pnlAddShoppingCart = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timer_homePage  = new System.Windows.Forms.Timer();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        public FormCustomer(string id,string name,string address,string email,string date,string image,FormLogin formLogin, bool check = false)
        {
            InitializeComponent();
            customer=new Customer(id,name,address,email,date,image);
            this.FormLogin = formLogin;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 65,65));
            customer_load(check);
        }
        private void customer_load(bool check)
        {
            txtName_profile.Text =customer.Name;
            txtAddress_profile.Text = WrapTextEvery66Chars(customer.ID);
            txtEmail_profile.Text =customer.Email;
            txtDate_profile.Text = customer.Date;
            ptbImage_Profile.Image = Image.FromFile(customer.Image);
            btnAccount.Image = Image.FromFile(customer.Image);
            ptbImage_Account.Image = Image.FromFile(customer.Image);
            lblName_Account.Text = "Hello "+customer.Name;
            lblName_Account.Location = new Point((199 - lblName_Account.Width) / 2, lblName_Account.Location.Y);
            list_uCProdcuts = new List<Product> { uC_product1, uC_product2, uC_product3, uC_product4, uC_product5, uC_product6, uC_product7, uC_product8, uC_product9, uC_product10, uC_product11, uC_product12, uC_product13, uC_product14, uC_product15, uC_product16 };
            (distance, duration) = (Drinks.distance_time(customer.Address));
            pnlBill.Hide();
            pnlPayment.Hide();
            pnlInformation.Hide();
            btnConfirm_Order.Hide();
            pnlAddShoppingCart.Hide();
            pnlAccount.Hide();
            if (check) pnlSaveLogin.Hide();
            else pnlSaveLogin.Location = new Point(964, 35);
            create_Page_Navigation();
            start_timer();
            load_Account();
            get_CurrentID();
            check_order();
            load_bestseller();
            load_ShoppingCart();
        }
        private void get_CurrentID()
        {
            string path = @"..\..\history_Shopping.txt";
            string lastline = File.ReadLines(path).Last();
            History_Shopping history_Shopping = System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(lastline);
            current_ID = int.Parse(history_Shopping.OrderId) + 1;
        }
        private void load_ShoppingCart()
        {
            DataTable dt = Drinks.Get_ShoppingCart(customer.ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                byte quantity = byte.Parse(dt.Rows[i]["Quantity"].ToString());
                int sum = int.Parse(new string(dt.Rows[i]["Price"].ToString().Where(char.IsDigit).ToArray()))*quantity;
                create_Payment(dt.Rows[i]["ID"].ToString(), dt.Rows[i]["Source_Image"].ToString(), dt.Rows[i]["Categories"].ToString(), dt.Rows[i]["Name"].ToString(), string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", sum), quantity,false);
                list_products[dt.Rows[i]["ID"].ToString()] = (quantity, sum, false);
            }
            update_Payment();
        }
        private void check_order()
        {
            string path = @"..\..\EmployeeToCustomer.txt";
            string[] lines = File.ReadAllLines(path);
            if (lines == null || lines.Length == 0) return;
            foreach (var line in lines)
            {
                History_Shopping history = System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(line);
                if (history.UserId == customer.ID)
                {
                    count=history.list_shopping.Count;
                    List<(string, int)> number_shopping = new List<(string, int)>();
                    foreach (var kvp in history.list_shopping)
                    {
                        DataTable dt=Drinks.get_history(kvp.Key);
                        string Name = StaffDb.TakeNameDrinks(kvp.Key);
                        Transport transport = new Transport(kvp.Key, customer.ID);
                        transport.Name = Name;
                        transport.LBLPrice = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", (kvp.Value.Price/kvp.Value.Quantity));
                        transport.LBLQTV = kvp.Value.Quantity.ToString();
                        transport.LBLAmount = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", (kvp.Value.Price));
                        transport.PTBImage = dt.Rows[0]["Source_Image"].ToString();
                        flpShoppingCart.Controls.Add(transport);
                        count--;
                        number_shopping.Add((transport.ID, Convert.ToInt16(transport.LBLQTV)));
                    }
                    if (count == 0)
                    {
                        pnlBill.Hide();
                        pnlPayment.Hide();
                        pnlInformation.Hide();
                        pnlEmpty.Show();
                    }
                    else
                    {
                        pnlBill.Show();
                        pnlPayment.Show();
                        pnlInformation.Show();
                        pnlEmpty.Hide();
                        lblMoney_payment.Text = "0đ";
                        lblMoney_SubTotal.Text = "0đ";
                        lblMoney_Sum.Text = "0đ";
                    }
                    current_ID = int.Parse(history.OrderId);
                    Drinks.update_Drinks(number_shopping);
                    tabControl1.SelectedTab = tabPage6;
                    lblOrderCode.Text = "Order #" + current_ID.ToString().PadLeft(7, '0');
                    lblStatus.Text = "Status: Shipping";
                    btnOrderNow.Click -= btnOrderNow_Click;
                    btnOrderNow.Click += announcement;
                    btnOrderNow_Bill.Click -= btnOrderNow_Click;
                    btnOrderNow_Bill.Click += announcement;
                    lblDistance.Text = $"Distance: {string.Format("{0:0.00}", distance)}KM";
                    lblTime.Text = $"Time: {TimeSpan.FromMinutes(duration).Minutes} Minutes";
                    lblExpected.Text = $"Expected: {(DateTime.Now + TimeSpan.FromMinutes(duration)).ToString("hh:mm tt")}";
                    lblSum_Transport.Text = $"Sum: {lblMoney_Sum.Text}";
                    tabControl1.SelectedTab = tabPage6;
                    timer2.Start();
                    pnlhomePage.Hide();
                    current_ID++;
                    break;
                }
            }
            var lineslist=lines.ToList();
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                History_Shopping history = System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(lines[i]);
                if (history.UserId == customer.ID)
                {
                    lineslist.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines(path, lineslist);  
        }
        private void load_bestseller()
        {
            DataTable dt= Drinks.get_Top3_BestSeller();
            for (int i = 0; i < dt.Rows.Count; i++)list_bestSeller.Add(dt.Rows[i]["ID"].ToString());
            ptbImage_BestSeller_Top1.Image = Image.FromFile(dt.Rows[0]["Source_Image"].ToString());
            lblName_BestSeller_Top1.Text=dt.Rows[0]["Name"].ToString();
            lblDescribe_BestSeller_Top1.Text= dt.Rows[0]["Describe"].ToString();
            lblRate_BestSeller_Top1.Text = dt.Rows[0]["Rate"].ToString();
            lblReviews_BestSeller_Top1.Text = dt.Rows[0]["Review"].ToString() + " Reviews";
            ptbImage_BestSeller_Top2.Image = Image.FromFile(dt.Rows[1]["Source_Image"].ToString());
            lblName_BestSeller_Top2.Text = dt.Rows[1]["Name"].ToString();
            lblDescribe_BestSeller_Top2.Text = dt.Rows[1]["Describe"].ToString();
            lblRate_BestSeller_Top2.Text = dt.Rows[1]["Rate"].ToString();
            lblReviews_BestSeller_Top2.Text = dt.Rows[1]["Review"].ToString() + " Reviews";
            ptbImage_BestSeller_Top3.Image = Image.FromFile(dt.Rows[2]["Source_Image"].ToString());
            lblName_BestSeller_Top3.Text = dt.Rows[2]["Name"].ToString();
            lblDescribe_BestSeller_Top3.Text = dt.Rows[2]["Describe"].ToString();
            lblRate_BestSeller_Top3.Text = dt.Rows[2]["Rate"].ToString();
            lblReviews_BestSeller_Top3.Text = dt.Rows[2]["Review"].ToString()+ " Reviews";
        }
        private string WrapTextEvery66Chars(string input)
        {
            int maxCharsPerLine = 66;
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i += maxCharsPerLine)
            {
                if (i + maxCharsPerLine < input.Length)
                    result.AppendLine(input.Substring(i, maxCharsPerLine));
                else
                    result.Append(input.Substring(i));
            }

            return result.ToString();
        }
        private void tabPage1_MouseWheel(object sender, MouseEventArgs e)
        {
            int currentY = -tabPage1.AutoScrollPosition.Y;
            if (e.Delta < 0)
            {
                tabPage1.MouseWheel -= tabPage1_MouseWheel;
                if (homePage == 1)
                {
                    homePage1.FillColor = Color.Gainsboro;
                    homePage2.FillColor = Color.FromArgb(211, 155, 81);
                    tabPage1.AutoScrollPosition = new Point(0, 600);
                }
                else if (homePage == 2)
                {
                    homePage2.FillColor = Color.Gainsboro;
                    homePage3.FillColor = Color.FromArgb(211, 155, 81);
                    tabPage1.AutoScrollPosition = new Point(0, 1285);
                }
                else if (homePage == 3)
                {
                    homePage3.FillColor = Color.Gainsboro;
                    homePage4.FillColor = Color.FromArgb(211, 155, 81);
                    tabPage1.AutoScrollPosition = new Point(0, 2070);
                }
                else if (homePage == 4)
                {
                    homePage4.FillColor = Color.Gainsboro;
                    homePage5.FillColor = Color.FromArgb(211, 155, 81);
                    tabPage1.AutoScrollPosition = new Point(0, 2463);
                }
                homePage++;
                tabPage1.CustomMouseWheel -= tabPage1_MouseWheel;
                timer_homePage.Start();
            }
            else if (e.Delta > 0)
            {
                tabPage1.MouseWheel -= tabPage1_MouseWheel;
                if (homePage == 5)
                {
                    homePage5.FillColor = Color.Gainsboro;
                    homePage4.FillColor = Color.FromArgb(211, 155, 81);
                    tabPage1.AutoScrollPosition = new Point(0, 2070);
                }
                else if (homePage == 4)
                {
                    homePage4.FillColor = Color.Gainsboro;
                    homePage3.FillColor = Color.FromArgb(211, 155, 81);
                    tabPage1.AutoScrollPosition = new Point(0, 1285);
                }
                else if (homePage == 3)
                {
                    homePage3.FillColor = Color.Gainsboro;
                    homePage2.FillColor = Color.FromArgb(211, 155, 81);
                    tabPage1.AutoScrollPosition = new Point(0, 600);
                }
                else
                {
                    homePage2.FillColor = Color.Gainsboro;
                    homePage1.FillColor = Color.FromArgb(211, 155, 81);
                    tabPage1.AutoScrollPosition = new Point(0, 0);
                }
                homePage--;
                tabPage1.CustomMouseWheel -= tabPage1_MouseWheel;
                timer_homePage.Start();
            }
        }
        private void homePage1_Timer(object sender, EventArgs e)
        {
            tabPage1.CustomMouseWheel += tabPage1_MouseWheel;
            timer_homePage.Stop();
        }

        // khởi tạo bộ chạy thời gian
        private void start_timer() 
        {
            timer_homePage.Interval = 500;
            timer_homePage.Tick += homePage1_Timer;
            tabPage1.CustomMouseWheel += tabPage1_MouseWheel;
            timer1.Interval = (60000 - DateTime.Now.Second * 1000);
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            string format;
            if (minute < 10) format = $"0{minute}";
            else format = minute.ToString();
            tt = DateTime.Now.ToString("tt");
            lblTimer.Text = $"{hour}:{format} {tt}";
            lblDate.Text = $"{DateTime.Now.DayOfWeek}, {DateTime.Now.ToString("MMMM")} {DateTime.Now.Day}, {DateTime.Now.Year}";
            timer1.Start();
        }
        // xử lý các dữ kiện của bộ đếm thời gian thcực
        private void timer1_Tick(object sender, EventArgs e)
        {
            string format;
            if (minute == 60)
            {
                if (hour == 24)
                {
                    lblDate.Text = $"{DateTime.Now.DayOfWeek}, {DateTime.Now.ToString("MMMM")} {DateTime.Now.Day}, {DateTime.Now.Year}";
                    hour = 0;
                }
                else
                {
                    minute = 0;
                    if (hour == 12) tt = DateTime.Now.ToString("tt");
                }
            }
            if (minute < 10) format = $"0{++minute}";
            else format = minute.ToString();
            lblTimer.Text = $"{hour}:{format} {tt}";
            timer1.Interval = (60000);
        }

        

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel17_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            set_Color_button(1);
            tabControl1.SelectedTab = tabPage1;
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void set_Color_button(int number)
        {
            btnShopping.CustomBorderThickness = new Padding(0,0,0,0);
            btnShopping.CustomBorderColor = Color.FromArgb(211, 155, 81);
            btnHome.CustomBorderThickness = new Padding(0, 0, 0, 0);
            btnHome.CustomBorderColor= Color.FromArgb(211, 155, 81);
            btnHistory.CustomBorderColor=Color.FromArgb(211, 155, 81);
            btnHistory.CustomBorderThickness = new Padding(0,0,0, 0);
            btnProfile.CustomBorderThickness = new Padding(0, 0, 0, 0); 
            btnProfile.CustomBorderColor= Color.FromArgb(211, 155, 81);
            if (number==1) btnHome.CustomBorderThickness = new Padding(2, 0, 0, 0);
            else if(number==2) btnShopping.CustomBorderThickness = new Padding(2, 0, 0, 0);
            else if(number==3) btnHistory.CustomBorderThickness = new Padding(2,0, 0, 0);
            else btnProfile.CustomBorderThickness = new Padding(2,0,0,0);
        }
        private void btnShopping_Click(object sender, EventArgs e)
        {
            set_Color_button(2);
            if (flpCategories.Controls.Count==1)loading_Shopping();
            tabControl1.SelectedTab = tabPage2;
        }
        private void loading_Shopping()
        {
            DataTable showUp_Categories = Drinks.loading_Categories();
            for (int i = 0; i < showUp_Categories.Rows.Count; i++)
            {
                Guna2Button button = new Guna2Button();
                button.Size = new Size(180, 45);
                button.FillColor = Color.Transparent;
                button.BackColor = Color.FromArgb(243, 243, 243);
                button.BorderRadius = 20;
                button.BorderColor = Color.FromArgb(211, 155, 81);
                button.BorderThickness = 1;
                button.ForeColor = Color.FromArgb(211, 155, 81);
                button.Font = new Font("Segoe UI", 24f);
                button.Margin = new Padding(left: 8, top: 3, right: 8, bottom: 3);
                button.Text = showUp_Categories.Rows[i]["Categories"].ToString();
                button.Click += button_Categories_click;
                flpCategories.Controls.Add(button);
            }
            btnAll.Click += button_Categories_click;
            categories = "ALL";
            btnAll.PerformClick();
        }
        private void reloading_Shopping(DataTable showUp_Drinks)
        {
            int len = showUp_Drinks.Rows.Count;
            for (int i = 0; i < len; i++)
            {
                list_uCProdcuts[i].Show();
                list_uCProdcuts[i].TurnOff_BestSeller();
                list_uCProdcuts[i].ID = showUp_Drinks.Rows[i]["ID"].ToString();
                for(int j = 0; j < list_bestSeller.Count; j++)
                {
                    if (list_uCProdcuts[i].ID == list_bestSeller[j])
                    {
                        list_uCProdcuts[i].TurnOn_BestSeller();
                        break;
                    }
                }
                list_uCProdcuts[i].Categories = showUp_Drinks.Rows[i]["Categories"].ToString();
                list_uCProdcuts[i].PTBImage_Drinks = showUp_Drinks.Rows[i]["Source_Image"].ToString();
                list_uCProdcuts[i].LBLName_Drinks = showUp_Drinks.Rows[i]["Name"].ToString();
                list_uCProdcuts[i].LBLDescribe_Drinks = showUp_Drinks.Rows[i]["Describe"].ToString();
                list_uCProdcuts[i].LBLRate_Drinks = showUp_Drinks.Rows[i]["Rate"].ToString();
                list_uCProdcuts[i].BTNReviews_Drinks = showUp_Drinks.Rows[i]["Review"].ToString();
                list_uCProdcuts[i].BTNPrice = showUp_Drinks.Rows[i]["Price"].ToString();
                list_uCProdcuts[i].btnPice_clicked += BTNPrice_Click_Ucprodcut;
                list_uCProdcuts[i].ptbImage_Drinks_clicked += ptbImageDrinks_Click_Ucproduct;

            }
            if (len < 16) for (int i = len; i < 16; i++) list_uCProdcuts[i].Hide();
        }
        private void ptbImageDrinks_Click_Ucproduct(object sender, EventArgs e)
        {
            if (sender is Product clickedButton)
            {
                bool flag = false;
                flpProduct.Controls.Clear();
                ptbImage_Product.Image = Image.FromFile(clickedButton.PTBImage_Drinks);
                lblName_Product.Text = clickedButton.LBLName_Drinks;
                lblDescribe_Product.Text = clickedButton.LBLDescribe_Drinks;
                lblReviews_Product.Text = clickedButton.BTNReviews_Drinks;
                lblRate_Product.Text = clickedButton.LBLRate_Drinks;
                string path = @"..\..\history_Rate.txt";
                string[] lines=File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    Rate.History history = System.Text.Json.JsonSerializer.Deserialize<Rate.History>(lines[i]);
                    if (history.ProductId == clickedButton.ID)
                    {
                        ucComment ucComment = new ucComment();
                        ucComment.PTBImage = customer.Image;
                        if (customer.ID != history.UserId) ucComment.LBLName = Drinks.Get_Name(history.UserId);
                        else ucComment.LBLName = "Bạn";
                        ucComment.set_Rate(history.Rank);
                        ucComment.TXTComment=history.Comment;
                        ucComment.LBLTime = $"{history.Time:dd/MM/yyyy HH:mm}";
                        flpProduct.Controls.Add(ucComment);
                        flag = true;
                    }
                    
                }
                tabControl1.SelectedTab = tabPage7;
                if (!flag)
                {
                    Panel panel = new Panel();
                    panel.Size = new Size(622, 721);
                    Label label = new Label();
                    label.Text = "NO COMMENT";
                    label.Location = new Point(311, 360);
                    label.ForeColor = Color.FromArgb(211, 155, 81);
                    panel.Controls.Add(label);
                    flpProduct.Controls.Add(panel);
                }
            }
            
        }
        private void btnShoppingCart_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }
        private void btnOrderNow_Click(object sender, EventArgs e)
        {
            if (int.Parse(new string(lblMoney_Sum.Text.Where(char.IsDigit).ToArray())) != 0)
            {
                string path = @"..\..\EmployeeToCustomer.txt";
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    History_Shopping history = System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(line);
                    if (history.UserId == customer.ID)
                    {
                        MessageBox.Show("Bạn hiện đã có đơn hàng đang tới rồi nè");
                        return;
                    }
                }
                path = @"..\..\CustomerToEmployee.txt";
                lines = new string[0];
                lines =File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    History_Shopping history = System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(line);
                    if (history.UserId == customer.ID)
                    {
                        MessageBox.Show("Bạn hiện đã đặt đơn hàng rồi nè");
                        return;
                    }
                }
                List<Payment> paymentsToRemove = flpPayment.Controls.OfType<Payment>().ToList();
                foreach (Payment p in paymentsToRemove)
                {
                    if (list_products[p.ID].Item3 == true)
                    {
                        Transport transport = new Transport(p.ID,customer.ID);
                        transport.Name = p.Name;
                        transport.LBLNote = p.TXTNote;
                        transport.LBLPrice = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", list_products[p.ID].Item2);
                        transport.LBLQTV =list_products[p.ID].Item1.ToString();
                        transport.LBLAmount = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", (list_products[p.ID].Item1 * list_products[p.ID].Item2));
                        transport.PTBImage = p.PTBImage_Drinks;
                        flpShoppingCart.Controls.Add(transport);
                        list_products.Remove(p.ID);
                        Drinks.Delete_ShoppingCart(customer.ID, p.ID);
                        flpPayment.Controls.Remove(p);
                        count--;
                    }
                }
                Dictionary<string, ShoppingItem> list_shopping = new Dictionary<string, ShoppingItem>();
                foreach (Transport transport in flpShoppingCart.Controls)
                {
                    int number = int.Parse(Regex.Replace(transport.LBLAmount, @"\D", ""));
                    list_shopping[transport.ID] = new ShoppingItem
                    {
                        Quantity = Convert.ToByte(transport.LBLQTV),
                        Price = number
                    };
                }
                customer.Order(current_ID, list_shopping, lblMoney_Sum.Text);
                current_ID += 1;
                if (count == 0)
                {
                    pnlBill.Hide();
                    pnlPayment.Hide();
                    pnlInformation.Hide();
                    pnlEmpty.Show();
                    lblMoney_payment.Text = "0đ";
                    lblMoney_SubTotal.Text = "0đ";
                    lblMoney_Sum.Text = "0đ";
                }
                else
                {
                    pnlBill.Show();
                    pnlPayment.Show();
                    pnlInformation.Show();
                    pnlEmpty.Hide();
                    lblMoney_payment.Text = "0đ";
                    lblMoney_SubTotal.Text = "0đ";
                    lblMoney_Sum.Text = "0đ";
                }
                MessageBox.Show("đơn hàng của bạn đang được xử lý");
            } else
            {
                MessageBox.Show("Bạn chưa chọn món nào để thực hiện thanh toán", "Thông báo");
            }
        }
        private void announcement(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang có đơn hàng đang được giao tới bạn\nVui lòng chờ hoàn thành và tiếp tục sử dụng dịch vụ của chúng tôi", "Thông báo");
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (guna2ProgressBar1.Value < 100)
            {
                if (guna2ProgressBar1.Value == 10)
                {
                    timer2.Interval = 1000;
                }
                guna2ProgressBar1.Value += 10;
                pnlShipper.Left += 10;
            }
            else
            {
                timer2.Stop();
                lblStatus.Hide();
                btnConfirm_Order.Show();
                // hiện đánh giá 

            }
        }
        private void btnConfirm_Order_Click(object sender, EventArgs e)
        {
            btnConfirm_Order.Hide();
            flag_order = true;
            lblStatus.Text = "Status: Success";
            lblStatus.Show();
            List<Transport> transports = flpShoppingCart.Controls.OfType<Transport>().ToList();
            foreach (Transport t in transports) t.Show_btnRate();
        }

        // khởi tạo và chạy loading thông tin cho các món nước
        private void ShowUp_Drinks()
        {
            if (categories == "ALL")
            {
                DataTable showUp_Drinks = Drinks.Loading_Drinks(indexPage);
                reloading_Shopping(showUp_Drinks);
            } else
            {
                DataTable dt = Drinks.loading_Drinks_Categories(indexPage, categories);
                reloading_Shopping(dt);
            }
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
            Guna2Button clickedbutton=sender as Guna2Button;
            if (clickedbutton != null)
            {
                indexPage = 1;
                change_Color_page(1);
                currentPage = 1;
                clickedbutton.FillColor= Color.FromArgb(211, 155, 81);
                clickedbutton.BorderThickness = 0;
                clickedbutton.ForeColor = Color.White;
                categories = clickedbutton.Text;
                if (categories == "ALL") lengthPage = (byte)Math.Ceiling((float)Drinks.number_Drinks() / 16);
                else lengthPage = (byte)Math.Ceiling((float)Drinks.number_Drinks_categories(categories)/16);
                create_Page_Navigation();
                ShowUp_Drinks();
            }
        }

        private void BTNPrice_Click_Ucprodcut(object sender, EventArgs e)
        {
            pnlAddShoppingCart.Show();
            pnlAddShoppingCart.Location = new System.Drawing.Point(590, 365);
            if (sender is Product clickedButton)
            {
                Boolean check = true;
                foreach (string Id in list_products.Keys.ToList())
                {
                    if (Id == clickedButton.ID)
                    {
                        
                        list_products[Id] = (list_products[Id].Item1+1, list_products[Id].Item2, list_products[Id].Item3);
                        check = false;
                        foreach (Payment p in flpPayment.Controls.OfType<Payment>())
                        {
                            if (p.ID==clickedButton.ID)
                            {
                                p.LBLQTV= list_products[Id].Item1;
                                int sum = (list_products[Id].Item1 * list_products[p.ID].Item2);
                                p.LBLSUM= string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", sum);
                                break;
                            }    
                        }
                    }
                }
                if (check)
                {
                    Drinks.Add_ShoppingCart(customer.ID, clickedButton.ID);
                    create_Payment(clickedButton.ID, clickedButton.PTBImage_Drinks, clickedButton.Categories, clickedButton.LBLName_Drinks, clickedButton.BTNPrice,1);
                }
                update_Payment();
            }
            timer_pnlAddShoppingCart.Interval = 500;
            timer_pnlAddShoppingCart.Tick += Timer_pnlAddShoppingCart;
            timer_pnlAddShoppingCart.Start();
        }
        private void create_Payment(string ID,string Image,string Categories,string Name,string Price,byte Amount,bool flag_BTNChoose=true)
        {
            count++;
            if (count > 0)
            {
                pnlBill.Show();
                pnlPayment.Show();
                pnlInformation.Show();
                pnlEmpty.Hide();
            }
            Payment payment = new Payment();
            payment.ID = ID;
            payment.PTBImage_Drinks = Image;
            payment.BTNCategories = Categories;
            payment.BTNName = Name;
            payment.LBLPrice = Price;
            payment.LBLSUM = Price; 
            payment.LBLQTV = Amount;
            payment.btnDown_clicked += BTNUpDown;
            payment.btnUp_clicked += BTNUpDown;
            payment.btnChoose_clicked += BTNChoose_clicked;
            payment.btnRemove_clicked += Remove_product;
            list_products[ID] = (Amount, int.Parse(new string(Price.Where(char.IsDigit).ToArray())), true);
            if (!flag_BTNChoose) payment.BTNChoose = null;
            flpPayment.Controls.Add(payment);
            flpPayment.Controls.SetChildIndex(payment, 0);
        }
        private void Timer_pnlAddShoppingCart(object sender, EventArgs e)
        {
            pnlAddShoppingCart.Hide();
            timer_pnlAddShoppingCart.Stop();
        }
        private void Remove_product(object sender, EventArgs e)
        {
            if (sender is Payment payment)
            {
                foreach (Payment p in flpPayment.Controls.OfType<Payment>())
                {
                    if (p.ID == payment.ID)
                    {
                        flpPayment.Controls.Remove(p);
                        list_products.Remove(p.ID);
                        count--;
                        if (count == 0)
                        {
                            pnlBill.Hide();
                            pnlPayment.Hide();
                            pnlInformation.Hide();
                            pnlEmpty.Show();
                        }
                        Drinks.Delete_ShoppingCart(customer.ID, payment.ID);
                        update_Payment();
                    }
                }
            }
        }
        private void update_Payment()
        {
            int subtotal = 0;
            int fee_ship = Drinks.fee_ship(distance);
            foreach (string ID in list_products.Keys.ToList())
            {
                if (list_products[ID].Item3 == true)
                {
                    subtotal += list_products[ID].Item2 * list_products[ID].Item1;
                }
            }
            lblMoney_SubTotal.Text = string.Format(new CultureInfo("vi-VN"),"{0:N0}đ", subtotal);
            if (subtotal != 0)
            {
                lblMoney_payment.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", subtotal + fee_ship);
                lblShip.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", fee_ship);
                lblMoney_Sum.Text= string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", subtotal+fee_ship);
            }
            else
            {
                lblMoney_payment.Text = "0đ";
                lblShip.Text = "0đ";
                lblMoney_Sum.Text = "0đ";
            }
        }
        private void BTNChoose_clicked(object sender, EventArgs e)
        {
            if (sender is Payment payment)
            {
                if (payment.BTNChoose == null) 
                {
                    payment.BTNChoose = @"..\..\Management coffee shop_image\check.png";
                    list_products[payment.ID] = (list_products[payment.ID].Item1 , list_products[payment.ID].Item2, true);
                    update_Payment();

                } else
                {
                    payment.BTNChoose = null;
                    list_products[payment.ID] = (list_products[payment.ID].Item1 , list_products[payment.ID].Item2, false);
                    update_Payment();
                }
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Login.create_NewToken(customer.ID);
            pnlSaveLogin.Hide();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            pnlSaveLogin.Hide();
        }
        private void BTNUpDown(object sender, int newValue)
        {
            if (sender is Payment payment)
            {
                 payment.LBLQTV = newValue;
                 payment.LBLSUM = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", newValue * list_products[payment.ID].Item2);
                 list_products[payment.ID] = ((int)newValue, list_products[payment.ID].Item2, list_products[payment.ID].Item3);
                 update_Payment();
            }
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            set_Color_button(3);
            if (flpHistory.Controls.Count==0) load_history();
            tabControl1.SelectedTab = tabPage3;
        }
        private void load_history()
        {
            bool show_pnlEmpty_History = true;
            string[] lines= customer.Get_History();
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    History_Shopping history_Shopping =System.Text.Json.JsonSerializer.Deserialize<History_Shopping>(line);
                    if (history_Shopping.UserId == customer.ID)
                    {
                        ucHistory_Shopping ucHistory_Shopping = new ucHistory_Shopping();
                        ucHistory_Shopping.load_history(history_Shopping);
                        ucHistory_Shopping.btnRepurchase_clicked += btnRepurchase_clicked;
                        flpHistory.Controls.Add(ucHistory_Shopping);
                        show_pnlEmpty_History=false;
                    }
                }
            }
            if (!show_pnlEmpty_History) pnlEmpty_History.Hide();
            else pnlEmpty_History.Show();
        }
        private void homePage1_Click(object sender, EventArgs e)
        {
            if (homePage != 1)
            {
                change_color_button_homePage();
                homePage = 1;
                homePage1.FillColor = Color.FromArgb(211, 155, 81);
                tabPage1.AutoScrollPosition = new Point(0, 0);
            }
        }
        private void homePage2_Click(object sender, EventArgs e)
        {
            if (homePage != 2)
            {
                change_color_button_homePage();
                homePage = 2;
                homePage2.FillColor = Color.FromArgb(211, 155, 81);
                tabPage1.AutoScrollPosition = new Point(0, 600);
            }
        }
        private void homePage3_Click(object sender, EventArgs e)
        {
            if (homePage != 3)
            {
                change_color_button_homePage();
                homePage = 3;
                homePage3.FillColor = Color.FromArgb(211, 155, 81);
                tabPage1.AutoScrollPosition = new Point(0, 1285);
            }
        }
        private void homePage4_Click(object sender, EventArgs e)
        {
            if (homePage != 4)
            {
                change_color_button_homePage();
                homePage = 4;
                homePage4.FillColor = Color.FromArgb(211, 155, 81);
                tabPage1.AutoScrollPosition = new Point(0, 2070);
            }
        }
        private void homePage5_Click(object sender, EventArgs e)
        {
            if (homePage != 5)
            {
                change_color_button_homePage();
                homePage = 5;
                homePage5.FillColor = Color.FromArgb(211, 155, 81);
                tabPage1.AutoScrollPosition = new Point(0, 2463);
            }
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            foreach (string Id in list_products.Keys.ToList()) Drinks.Update_ShoppingCart(customer.ID, Id, (byte)list_products[Id].Item1);
            Login.delete_Token(customer.ID);
            FormLogin.change_tabPage();
            FormLogin.Show();
            this.Close();
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            FormLogin.change_tabPage();
            FormLogin.Show();
            this.Close();
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FormForgetPassword formForgetPassword = new FormForgetPassword(FormLogin);
            formForgetPassword.change_TabPage();
            formForgetPassword.Show();
            this.Hide();
        }
        private void load_Account()
        {
            List<string> userName_List = FormLogin.UserName_List;
            List<string> userId_List= FormLogin.UserId_List;
            for (int i = 0; i < userId_List.Count; i++)
            {
                if (userId_List[i] != customer.ID)
                {
                    Guna2Button button = new Guna2Button();
                    button.Size = new Size(197, 34);
                    button.FillColor = Color.Transparent;
                    button.BackColor= Color.Transparent;
                    button.ForeColor = Color.Black;
                    button.Font= new Font("Segoe UI", 12f);
                    //button.Text = userName_List[i];
                    button.Image = Image.FromFile(@"..\..\Management coffee shop_image\black-and-white-stockportable-network-account-icon-11553436383dwuayhjyvo-removebg-preview.png");
                    button.ImageSize = new Size(25, 25); 
                    button.ImageAlign = HorizontalAlignment.Left; 
                    button.TextAlign = HorizontalAlignment.Left;
                    button.Tag =userId_List[i];
                    button.Click += btnChooseAccount_click;
                    flpAnotherAccount.Controls.Add(button);
                }
            }
        }
        private void btnChooseAccount_click(object sender, EventArgs e)
        {
            Guna2Button btn_clicked=sender as Guna2Button;
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT Name,Address,Email,Date,Image FROM customerInformation JOIN account ON account.ID=customerInformation.ID WHERE customerInformation.ID=@ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", btn_clicked.Tag.ToString());
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FormCustomer formCustomer = new FormCustomer(btn_clicked.Tag.ToString(), reader["Name"].ToString(), reader["Address"].ToString(), reader["Email"].ToString(), reader["Date"].ToString(), reader["Image"].ToString(), this.FormLogin, true);
                            formCustomer.Show();
                            this.Close();
                        }
                    }
                }
            }
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            if(pnlAccount.Visible==false)pnlAccount.Show();
            else pnlAccount.Hide();
        }
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            lblMode_Profile.Text = "EDIT PROFILE";
            txtName_profile.Text =lblName_profile.Text.Trim();
            txtDate_profile.Text = lblDate_profile.Text.Trim();
            txtAddress_profile.Text = lblAddress_profile.Text.Trim();
            txtEmail_profile.Text = lblEmail_profile.Text.Trim();
            btnSave.Show();
            btnCancel.Show();
            btnUpload_Profile.Show();
            txtAddress_profile.Show();
            txtEmail_profile.Show();
            txtName_profile.Show();
            txtDate_profile.Show();
            btnEditProfile.Hide();
            lblName_profile.Hide();
            lblDate_profile.Hide();
            lblAddress_profile.Hide();
            lblEmail_profile.Hide();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblMode_Profile.Text = "PROFILE";
            lblName_profile.Text = txtName_profile.Text.Trim();
            lblDate_profile.Text = txtDate_profile.Text.Trim();
            lblAddress_profile.Text = txtAddress_profile.Text.Trim();
            lblEmail_profile.Text = txtEmail_profile.Text.Trim();
            ptbImage_Profile.Image.Dispose();
            ptbImage_Profile.Image = Image.FromFile(customer.Image);
            if (!string.IsNullOrEmpty(new_image))File.Delete(new_image);
            new_image = null;
            btnSave.Hide();
            btnCancel.Hide();
            btnUpload_Profile.Hide();
            txtAddress_profile.Hide();
            txtEmail_profile.Hide();
            txtName_profile.Hide();
            txtDate_profile.Hide();
            lblName_profile.Show();
            lblDate_profile.Show();
            lblAddress_profile.Show();
            lblEmail_profile.Show();
            btnEditProfile.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName_profile.Text) || string.IsNullOrEmpty(txtAddress_profile.Text) || string.IsNullOrEmpty(txtDate_profile.Text) || string.IsNullOrEmpty(txtEmail_profile.Text))
            {
                MessageBox.Show("không được để trống");
                return;
            }else if (txtName_profile.Text.Length > 20)
            {
                MessageBox.Show("Lỗi độ dài tên quá dài");
                return;
            } else if (txtDate_profile.Text.Length > 10)
            {
                MessageBox.Show("Lỗi độ dài");
                return;
            } 
            DialogResult result=MessageBox.Show("bạn có chắc muốn lưu không","Lưu",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if(new_image!=null) customer.Image=new_image;
                Drinks.update_User(customer.ID,txtName_profile.Text,txtDate_profile.Text,txtAddress_profile.Text,txtEmail_profile.Text,customer.Image);
                customer.Name = txtName_profile.Text;
                customer.Date = txtDate_profile.Text;
                customer.Address = txtAddress_profile.Text;
                customer.Email = txtEmail_profile.Text;
                btnAccount.Image.Dispose();
                btnAccount.Image=Image.FromFile(customer.Image);
                ptbImage_Account.Image = Image.FromFile(customer.Image);
                lblName_Account.Text = customer.Name;
                lblName_Account.Location = new Point((199 - lblName_Account.Location.X) / 2, lblName_Account.Location.Y);
                new_image = null;
                btnCancel.PerformClick();
            }else btnCancel.PerformClick();
        }

        private void btnOur_Location_HomePage_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/le312113";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName= url,
                    UseShellExecute = true
                });
            }
            catch
            {

            }
        }
        private void btnLocation_HomePage_Click(object sender, EventArgs e)
        {

        }

        private void btnAttendant_HomePage_Click(object sender, EventArgs e)
        {

        }

        private void btnUpload_Profile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn Hình Ảnh";
            openFileDialog.Filter = "File hình ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                string file=Path.GetFileName(selectedFilePath);
                string target_Folder = @"..\..\Management coffee shop_image\Image_User";
                new_image= Path.Combine(target_Folder, file);
                if (new_image.Length>100)
                {
                    MessageBox.Show("Hình ảnh không hợp lệ");
                    new_image = null;
                    return;
                }
                File.Copy(selectedFilePath, new_image, true);
                ptbImage_Profile.Image=Image.FromFile(new_image);
            }
        }
        private void btnRepurchase_clicked(object sender, EventArgs e)
        {
            if (sender is ucHistory_Shopping clicked)
            {
                History_Shopping history_Shopping = customer.Repurchase(clicked.Code);
                foreach (var kvp in history_Shopping.list_shopping)
                {
                    bool check = false;
                    // xử lý khi đã có sản phẩm
                    foreach (Payment p in flpPayment.Controls.OfType<Payment>())
                    {
                        if (p.ID == kvp.Key)
                        {
                            p.LBLQTV=p.LBLQTV+(int)kvp.Value.Quantity;
                            p.LBLSUM = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", (int.Parse(new string(p.LBLPrice.Where(char.IsDigit).ToArray())) * p.LBLQTV)); 
                            list_products[p.ID]= ((int)p.LBLQTV, list_products[p.ID].Item2, list_products[p.ID].Item3);
                            check = true;
                            break;
                        }
                    }
                    if (!check)
                    {
                        DataTable dt = Drinks.get_history(kvp.Key);
                        create_Payment(kvp.Key, dt.Rows[0]["Source_Image"].ToString(), dt.Rows[0]["Categories"].ToString(), dt.Rows[0]["Name"].ToString(), string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", (int)(kvp.Value.Price / kvp.Value.Quantity)), kvp.Value.Quantity);
                        Drinks.Add_ShoppingCart(customer.ID, kvp.Key);
                    }
                    update_Payment();
                }
            }
        }
        private void btnProfile_Click(object sender, EventArgs e)
        {
            set_Color_button(4);
            pnlAccount.Hide();
            btnCancel.PerformClick();
            tabControl1.SelectedTab = tabPage4;
        }

        private void btnOrder_Account_Click(object sender, EventArgs e)
        {
            pnlAccount.Hide();
            tabControl1.SelectedTab = tabPage6;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag_order && tabControl1.SelectedTab != tabPage6)
            {
                flag_order=false;
                try
                {
                    Dictionary<string, ShoppingItem> list_shopping = new Dictionary<string, ShoppingItem>();
                    List<(string, int)> number_shopping = new List<(string, int)>();
                    foreach (Transport transport in flpShoppingCart.Controls)
                    {
                        int number = int.Parse(Regex.Replace(transport.LBLAmount, @"\D", ""));
                        list_shopping[transport.ID] = new ShoppingItem
                        {
                            Quantity = Convert.ToByte(transport.LBLQTV),
                            Price = number
                        };
                        number_shopping.Add((transport.ID, Convert.ToInt16(transport.LBLQTV)));
                    }
                    Drinks.update_Drinks(number_shopping);
                    customer.Set_History(list_shopping, lblOrderCode.Text, lblSum_Transport.Text);
                    MessageBox.Show("Cảm ơn bạn đã mua hàng");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu đơn hàng: {ex.Message}", "Lỗi");
                    Console.WriteLine($"Error saving order: {ex.Message}");
                }
            } 
            if (tabControl1.SelectedTab==tabPage1)pnlhomePage.Show();
            else pnlhomePage.Hide();
        }

        private void change_color_button_homePage()
        {
            if (homePage == 1) homePage1.FillColor=Color.Gainsboro;
            else if (homePage == 2) homePage2.FillColor = Color.Gainsboro;
            else if (homePage == 3) homePage3.FillColor = Color.Gainsboro;
            else if (homePage == 4) homePage4.FillColor = Color.Gainsboro;
            else homePage5.FillColor = Color.Gainsboro;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            foreach (string Id in list_products.Keys.ToList()) Drinks.Update_ShoppingCart(customer.ID, Id, (byte)list_products[Id].Item1);
            FormLogin.Close();
        }

        // xử lý các sự kiện của các nút điều hướng trang
        private void change_Color_page(int turn)
        {
            btnFirst_page.FillColor=Color.Transparent;
            btnFirst_page.ForeColor = Color.FromArgb(211, 155, 81);
            btnSecond_page.FillColor=Color.Transparent;
            btnSecond_page.ForeColor = Color.FromArgb(211, 155, 81);
            btnThird_page.FillColor=Color.Transparent;
            btnThird_page.ForeColor= Color.FromArgb(211, 155, 81);
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
        }
        private void update_page(int indexPage)
        {
            btnFirst_page.Text = (indexPage - 1).ToString();
            btnSecond_page.Text = (indexPage).ToString();
            btnThird_page.Text = (indexPage + 1).ToString();
        }
        private void flpPageNavigation_Position(byte amount)
        {
            Point flpPageNavigation_location= flpPageNavigation.Location;
            int x = 375;
            flpPageNavigation.Location = new Point(x+amount*39, flpPageNavigation_location.Y);
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
        // nút mũi tên bên phải của xử lý trang
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
                    }else
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
                        }else
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
                else if (currentPage==3) indexPage--;
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
                        if (indexPage == 1 && lengthPage==3)
                        {   
                            indexPage = byte.Parse(btnThird_page.Text);
                            change_Color_page(3);
                            currentPage = 3;
                            
                        }else
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
