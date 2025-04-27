using Guna.UI2.WinForms;
using Management_Coffee_Shop.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Management_Coffee_Shop.FormCustomer.History_Shopping;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

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
            public class ShoppingItem
            {
                public byte Quantity { get; set; }
                public int Price { get; set; }
            }
        }
        const int SB_HORZ = 0;
        const int SB_VERT = 1;
        private bool check,flag_order;
        private static Dictionary<string, (int, int, Boolean)> list_products = new Dictionary<string, (int, int, Boolean)>();
        private int minute, hour, currentPage = 1, count = 0;
        private byte indexPage = 1, lengthPage = 2,homePage=1;
        private double distance, duration;
        private string tt,ID,Address,Name,categories;
        private static int current_ID = 0;
        private FormLogin FormLogin;
        private List<Guna2Button> List_buttonPage;
        private List<Product> list_uCProdcuts;
        private System.Windows.Forms.Timer timer_pnlAddShoppingCart = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timer_homePage  = new System.Windows.Forms.Timer();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        public FormCustomer(string id,string name,string address,FormLogin formLogin, bool check = false)
        {
            InitializeComponent();
            this.ID = id;
            this.Name = name;
            this.Address = address;
            this.check = check;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 80,80));
            this.FormLogin = formLogin;
            list_uCProdcuts = new List<Product> { uC_product1, uC_product2, uC_product3, uC_product4, uC_product5, uC_product6, uC_product7, uC_product8, uC_product9, uC_product10, uC_product11, uC_product12, uC_product13, uC_product14, uC_product15, uC_product16 };
            List_buttonPage = new List<Guna2Button> { btnFirst_page, btnSecond_page, btnThird_page };
            (distance, duration) = (Drinks.distance_time(address));
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

        private void FormCustomer_Load(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel17_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlhomePage.Show();
            tabControl1.SelectedTab = tabPage1;
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnShopping_Click(object sender, EventArgs e)
        {
            loading_Shopping();
            tabControl1.SelectedTab = tabPage2;
            pnlhomePage.Hide();
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
                list_uCProdcuts[i].ID = showUp_Drinks.Rows[i]["ID"].ToString();
                list_uCProdcuts[i].Categories = showUp_Drinks.Rows[i]["Categories"].ToString();
                list_uCProdcuts[i].PTBImage_Drinks = showUp_Drinks.Rows[i]["Source_Image"].ToString();
                list_uCProdcuts[i].LBLName_Drinks = showUp_Drinks.Rows[i]["Name"].ToString();
                list_uCProdcuts[i].LBLDescribe_Drinks = showUp_Drinks.Rows[i]["Describe"].ToString();
                list_uCProdcuts[i].LBLRate_Drinks = showUp_Drinks.Rows[i]["Rate"].ToString();
                list_uCProdcuts[i].BTNReviews_Drinks = showUp_Drinks.Rows[i]["Review"].ToString();
                list_uCProdcuts[i].BTNPrice = showUp_Drinks.Rows[i]["Price"].ToString();
                list_uCProdcuts[i].btnPice_clicked += BTNPrice_Click_Ucprodcut;
            }
            if (len < 16) for (int i = len; i < 16; i++) list_uCProdcuts[i].Hide();
        }
        private void btnShoppingCart_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }
        private void btnOrderNow_Click(object sender, EventArgs e)
        {
            if (int.Parse(new string(lblMoney_Sum.Text.Where(char.IsDigit).ToArray())) != 0)
            {
                List<Payment> paymentsToRemove = flpPayment.Controls.OfType<Payment>().ToList();
                foreach (Payment p in paymentsToRemove)
                {
                    if (list_products[p.ID].Item3 == true)
                    {
                        Transport transport = new Transport(p.ID);
                        transport.Name = p.Name;
                        transport.LBLNote = p.TXTNote;
                        transport.LBLPrice = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", list_products[p.ID].Item2);
                        transport.LBLQTV =list_products[p.ID].Item1.ToString();
                        transport.LBLAmount = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", (list_products[p.ID].Item1 * list_products[p.ID].Item2));
                        transport.PTBImage = p.PTBImage_Drinks;
                        flpShoppingCart.Controls.Add(transport);
                        list_products.Remove(p.ID);
                        flpPayment.Controls.Remove(p);
                        count--;
                    }
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
                lblOrderCode.Text = "Order #" + (++current_ID).ToString().PadLeft(7, '0');
                lblStatus.Text = "Status: Shipping";
                btnOrderNow.Click -= btnOrderNow_Click;
                btnOrderNow.Click += announcement;
                btnOrderNow_Bill.Click -= btnOrderNow_Click;
                btnOrderNow_Bill.Click += announcement;
                lblDistance.Text = $"Distance: {string.Format("{0:0.00}", distance)}KM";
                lblTime.Text = $"Time: {TimeSpan.FromMinutes(duration).Minutes} Minutes";
                lblExpected.Text = $"Expected: {(DateTime.Now + TimeSpan.FromMinutes(duration)).ToString("hh:mm tt")}";
                lblSum_Transport.Text =$"Sum: {lblMoney_Sum.Text}";
                tabControl1.SelectedTab = tabPage6;
                timer2.Start();
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
                                string sum = (list_products[Id].Item1 * list_products[p.ID].Item2).ToString();
                                p.LBLSUM= string.Format("{0:N0}đ", sum);
                                break;
                            }    
                        }
                    }
                }
                if (check)
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
                    payment.ID = clickedButton.ID;
                    payment.PTBImage_Drinks = clickedButton.PTBImage_Drinks;
                    payment.BTNCategories = clickedButton.Categories;
                    payment.BTNName = clickedButton.LBLName_Drinks;
                    payment.LBLPrice = clickedButton.BTNPrice;
                    payment.LBLSUM = clickedButton.BTNPrice;
                    payment.value = 1;
                    payment.btnDown_clicked += BTNUpDown;
                    payment.btnUp_clicked += BTNUpDown;
                    payment.btnChoose_clicked += BTNChoose_clicked;
                    payment.btnRemove_clicked += Remove_product;
                    list_products[clickedButton.ID] = (1, int.Parse(new string(clickedButton.BTNPrice.Where(char.IsDigit).ToArray())),true);
                    flpPayment.Controls.Add(payment);
                    flpPayment.Controls.SetChildIndex(payment, 0);
                }
                update_Payment();
            }
            timer_pnlAddShoppingCart.Interval = 500;
            timer_pnlAddShoppingCart.Tick += Timer_pnlAddShoppingCart;
            timer_pnlAddShoppingCart.Start();
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
                    payment.BTNChoose = @"images\check.png";
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
            Login.create_NewToken(ID);
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
            tabControl1.SelectedTab = tabPage3;
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
            FormLogin.change_tabPage();
            FormLogin.Show();
            this.Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FormForgetPassword formForgetPassword = new FormForgetPassword();
            formForgetPassword.change_TabPage();
            formForgetPassword.Show();
            this.Hide();
        }
        private void load_Account()
        {
            for (int i = 0; i < FormLogin.userId_List.Count; i++)
            {
                if (FormLogin.userId_List[i] != this.ID)
                {
                    Guna2Button button = new Guna2Button();
                    button.Size = new Size(203, 34);
                    button.FillColor = Color.Transparent;
                    button.BackColor= Color.Transparent;
                    button.ForeColor = Color.Black;
                    button.Font= new Font("Segoe UI", 12f);
                    button.Text = FormLogin.userName_List[i];
                    button.Image = Image.FromFile(@"..\..\Management coffee shop_image\edited_image-removebg-preview.png");
                    button.ImageSize = new Size(25, 25); 
                    button.ImageAlign = HorizontalAlignment.Left; 
                    button.TextAlign = HorizontalAlignment.Left; 
                    flpAnotherAccount.Controls.Add(button);
                }
            }
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            load_Account();
            pnlAccount.Show();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag_order && tabControl1.SelectedTab != tabPage6)
            {
                try
                {
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

                    string path = "history_Shopping.txt";
                    History_Shopping history_Shopping = new History_Shopping()
                    {
                        OrderId = lblOrderCode.Text,
                        UserId = this.ID,
                        list_shopping = list_shopping,
                        Sum = int.Parse(Regex.Replace(lblSum_Transport.Text, @"\D", "")),
                        OrderDate = DateTime.Now
                    };

                    MessageBox.Show("Cảm ơn bạn đã mua hàng");
                    string jsonLine = System.Text.Json.JsonSerializer.Serialize(history_Shopping);
                    File.AppendAllText(path, jsonLine + Environment.NewLine);
                    Console.WriteLine($"Saved to history_Shopping.txt: {jsonLine}"); // Thêm log để kiểm tra
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu đơn hàng: {ex.Message}", "Lỗi");
                    Console.WriteLine($"Error saving order: {ex.Message}");
                }
            }
        }

        private void change_color_button_homePage()
        {
            if (homePage == 1) homePage1.FillColor=Color.Gainsboro;
            else if (homePage == 2) homePage2.FillColor = Color.Gainsboro;
            else if (homePage == 3) homePage3.FillColor = Color.Gainsboro;
            else if (homePage == 4) homePage4.FillColor = Color.Gainsboro;
            else homePage5.FillColor = Color.Gainsboro;
        }

        // xử lý các sự kiện của các nút điều hướng trang
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
