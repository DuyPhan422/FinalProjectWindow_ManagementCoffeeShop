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
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Management_Coffee_Shop
{
    public partial class FormCustomer : Form
    {
        private int minute, hour, currentPage = 1, indexPage = 1, lengthPage = 7, count = 0;
        private double distance, duration;
        private string tt,ID,Address,Name;
        private static int current_ID = 0;
        private List<Guna2Button> List_buttonPage;
        private List<UC_product> list_uCProdcuts;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        public FormCustomer(string id,string name,string address)
        {
            InitializeComponent();
            this.ID = id;
            this.Name = name;
            this.Address = address;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 80,80));
            list_uCProdcuts = new List<UC_product> { uC_product1, uC_product2, uC_product3, uC_product4, uC_product5, uC_product6, uC_product7, uC_product8, uC_product9, uC_product10, uC_product11, uC_product12, uC_product13, uC_product14, uC_product15, uC_product16 };
            List_buttonPage = new List<Guna2Button> { btnFirst_page, btnSecond_page, btnThird_page };
            (distance, duration) = (Drinks.distance_time(address));
            pnlBill.Hide();
            pnlPayment.Hide();
            pnlInformation.Hide();
            btnConfirm_Order.Hide();
            start_timer();
        }
        // khởi tạo bộ chạy thời gian
        private void start_timer() 
        {
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
            tabControl1.SelectedTab = tabPage1;
        }
        private void btnShopNow_Click(object sender, EventArgs e)
        {
            ShowUp_Drinks();
            tabControl1.SelectedTab = tabPage2;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnShopNow_Cart_Click(object sender, EventArgs e)
        {
            ShowUp_Drinks();
            tabControl1.SelectedTab = tabPage2;
        }

        private void btnShopping_Click(object sender, EventArgs e)
        {
            ShowUp_Drinks();
            tabControl1.SelectedTab = tabPage2;

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
                    if (Drinks.list_products[p.ID].Item3 == true)
                    {
                        Transport transport = new Transport();
                        transport.ID = transport.Create_ID();
                        transport.Name = p.Name;
                        transport.LBLNote = p.TXTNote;
                        transport.LBLPrice = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", Drinks.list_products[p.ID].Item2);
                        transport.LBLQTV = Drinks.list_products[p.ID].Item1.ToString();
                        transport.LBLAmount = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", (Drinks.list_products[p.ID].Item1 * Drinks.list_products[p.ID].Item2));
                        transport.PTBImage = p.PTBImage_Drinks;
                        flpShoppingCart.Controls.Add(transport);
                        lblOrderCode.Text = "Order #" + (++current_ID).ToString().PadLeft(7, '0');
                        lblStatus.Text = "Status: Shipping";
                        Drinks.list_products.Remove(p.ID);
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
            lblStatus.Text = "Status: Success";
            lblStatus.Show();
            List<Transport> transports = flpShoppingCart.Controls.OfType<Transport>().ToList();
            foreach (Transport t in transports) t.Show_btnRate();
        }
        // khởi tạo và chạy loading thông tin cho các món nước
        private void ShowUp_Drinks()
        {
            DataTable showUp_Drinks = Drinks.Loading_Drinks(indexPage);
            int len = showUp_Drinks.Rows.Count;
            for (int i = 0; i < len; i++)
            {
                list_uCProdcuts[i].Show();
                list_uCProdcuts[i].ID = showUp_Drinks.Rows[i]["ID"].ToString();
                list_uCProdcuts[i].Categories = showUp_Drinks.Rows[i]["Categories"].ToString();
                list_uCProdcuts[i].PTBImage_Drinks=showUp_Drinks.Rows[i]["Source_Image"].ToString();
                list_uCProdcuts[i].LBLName_Drinks=showUp_Drinks.Rows[i]["Name"].ToString();
                list_uCProdcuts[i].LBLDescribe_Drinks = showUp_Drinks.Rows[i]["Describe"].ToString();
                list_uCProdcuts[i].LBLRate_Drinks = showUp_Drinks.Rows[i]["Rate"].ToString();
                list_uCProdcuts[i].BTNReviews_Drinks = showUp_Drinks.Rows[i]["Review"].ToString();
                list_uCProdcuts[i].BTNPrice = showUp_Drinks.Rows[i]["Price"].ToString();
                list_uCProdcuts[i].btnPice_clicked += BTNPrice_Click_Ucprodcut;
            }
            if (len < 16) for (int i = len; i < 16; i++) list_uCProdcuts[i].Hide(); 
        }
        private void BTNPrice_Click_Ucprodcut(object sender, EventArgs e)
        {
            if (sender is UC_product clickedButton)
            {
                Boolean check = true;
                if (Drinks.list_products.ContainsKey(clickedButton.ID))
                {
                   MessageBox.Show("Key tồn tại!");
                }
                foreach (string Id in Drinks.list_products.Keys.ToList())
                {
                    if (Id == clickedButton.ID)
                    {
                        
                        Drinks.list_products[Id] = (Drinks.list_products[Id].Item1+1, Drinks.list_products[Id].Item2, Drinks.list_products[Id].Item3);
                        check = false;
                        foreach (Payment p in flpPayment.Controls.OfType<Payment>())
                        {
                            if (p.ID==clickedButton.ID)
                            {
                                p.LBLQTV= Drinks.list_products[Id].Item1;
                                string sum = (Drinks.list_products[Id].Item1 * Drinks.list_products[p.ID].Item2).ToString();
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
                    Drinks.list_products[clickedButton.ID] = (1, int.Parse(new string(clickedButton.BTNPrice.Where(char.IsDigit).ToArray())),true);
                    flpPayment.Controls.Add(payment);
                    flpPayment.Controls.SetChildIndex(payment, 0);
                }
                update_Payment();
            }
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
                        Drinks.list_products.Remove(p.ID);
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
            foreach (string ID in Drinks.list_products.Keys.ToList())
            {
                if (Drinks.list_products[ID].Item3 == true)
                {
                    subtotal += Drinks.list_products[ID].Item2 * Drinks.list_products[ID].Item1;
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
                    Drinks.list_products[payment.ID] = (Drinks.list_products[payment.ID].Item1 , Drinks.list_products[payment.ID].Item2, true);
                    update_Payment();

                } else
                {
                    payment.BTNChoose = null;
                    Drinks.list_products[payment.ID] = (Drinks.list_products[payment.ID].Item1 , Drinks.list_products[payment.ID].Item2, false);
                    update_Payment();
                }
            }
        }
        private void BTNUpDown(object sender, int newValue)
        {
            if (sender is Payment payment)
            {
                 payment.LBLQTV = newValue;
                 payment.LBLSUM = string.Format(new CultureInfo("vi-VN"), "{0:N0}đ", newValue * Drinks.list_products[payment.ID].Item2);
                 Drinks.list_products[payment.ID] = ((int)newValue, Drinks.list_products[payment.ID].Item2, Drinks.list_products[payment.ID].Item3);
                 update_Payment();
            }
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
            } else
            {
                btnThird_page.FillColor = Color.FromArgb(211, 155, 81);
                btnThird_page.ForeColor = Color.White;
            }
            List_buttonPage[currentPage - 1].FillColor = Color.Transparent;
            List_buttonPage[currentPage - 1].ForeColor = Color.FromArgb(211, 155, 81);
        }
        private void update_page(int indexPage)
        {
            btnFirst_page.Text = (indexPage - 1).ToString();
            btnSecond_page.Text = (indexPage).ToString();
            btnThird_page.Text = (indexPage + 1).ToString();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
        }

        

        // nút mũi tên bên phải của xử lý trang
        private void btnPage_Next_Click(object sender, EventArgs e)
        {
            if (indexPage < lengthPage)
            {
                if (indexPage == lengthPage - 1)
                {
                    change_Color_page(3);
                    currentPage = 3;
                    indexPage += 1;
                }
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
                    indexPage = int.Parse(btnFirst_page.Text);
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
                            indexPage = int.Parse(btnFirst_page.Text);
                            update_page(indexPage);
                        }else
                        {
                            indexPage = int.Parse(btnFirst_page.Text);
                            change_Color_page(1);
                            currentPage = 1;
                        }
                    }
                    else if (currentPage == 2)
                    {
                        indexPage = int.Parse(btnFirst_page.Text);
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
                    indexPage = int.Parse(btnThird_page.Text);
                    change_Color_page(3);
                    currentPage = 3;
                }
                else
                {
                    if (currentPage == 1)
                    {
                        if (indexPage == 1 && lengthPage==3)
                        {   
                            indexPage = int.Parse(btnThird_page.Text);
                            change_Color_page(3);
                            currentPage = 3;
                            
                        }else
                        {
                            change_Color_page(2);
                            currentPage = 2;
                            indexPage = int.Parse(btnThird_page.Text);
                            update_page(indexPage);
                        }
                    }
                    else if (currentPage == 2)
                    {
                        indexPage = int.Parse(btnThird_page.Text);
                        update_page(indexPage);
                    }
                }
                ShowUp_Drinks();
            }
        }
    }
}
