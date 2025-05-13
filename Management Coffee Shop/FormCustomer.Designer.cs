using System.Windows.Forms;

namespace Management_Coffee_Shop
{
    // bill 

    class CustomTabPage : TabPage
    {
        public event MouseEventHandler CustomMouseWheel;

        public CustomTabPage()
        {
            this.AutoScroll = true;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_MOUSEWHEEL = 0x020A;
            const int WM_VSCROLL = 0x0115;
            const int WM_HSCROLL = 0x0114;

            if (m.Msg == WM_MOUSEWHEEL)
            {
                // Lấy delta từ thông điệp
                int delta = (short)((m.WParam.ToInt32() >> 16) & 0xffff);
                CustomMouseWheel?.Invoke(this, new MouseEventArgs(MouseButtons.None, 0, 0, 0, delta));
                return;
            }

            if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL)
            {
                return;
            }

            base.WndProc(ref m);
        }
    }
    partial class FormCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomer));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAccount = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnShoppingCart = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnProfile = new Guna.UI2.WinForms.Guna2Button();
            this.btnHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnShopping = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button36 = new Guna.UI2.WinForms.Guna2Button();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel22 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel21 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel20 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnlAddShoppingCart = new Guna.UI2.WinForms.Guna2Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.pnlSaveLogin = new Guna.UI2.WinForms.Guna2Panel();
            this.btnNo = new Guna.UI2.WinForms.Guna2Button();
            this.btnYes = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel43 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.homePage2 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.homePage4 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.homePage1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.homePage3 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.homePage5 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pnlhomePage = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlAccount = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel50 = new Guna.UI2.WinForms.Guna2Panel();
            this.flpAnotherAccount = new System.Windows.Forms.FlowLayoutPanel();
            this.label26 = new System.Windows.Forms.Label();
            this.btnAddAccount = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditAccount_Account = new Guna.UI2.WinForms.Guna2Button();
            this.btnChangePassword = new Guna.UI2.WinForms.Guna2Button();
            this.btnOrder_Account = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel55 = new Guna.UI2.WinForms.Guna2Panel();
            this.ptbImage_Account = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblName_Account = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new Management_Coffee_Shop.CustomTabPage();
            this.guna2PictureBox6 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnShopNow = new Guna.UI2.WinForms.Guna2Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel14 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel13 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel11 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel20 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button23 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button7 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button22 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button18 = new Guna.UI2.WinForms.Guna2Button();
            this.btnAttendant_HomePage = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button21 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button17 = new Guna.UI2.WinForms.Guna2Button();
            this.btnLocation_HomePage = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button20 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button16 = new Guna.UI2.WinForms.Guna2Button();
            this.btnBestSeller_HomePage = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button19 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button15 = new Guna.UI2.WinForms.Guna2Button();
            this.btnAbout_Us_HomePage = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel23 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel22 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel21 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel34 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel33 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel32 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel16 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel12 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel11 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel17 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel19 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel18 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox13 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox12 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox14 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnFeed_Back_HomePage = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel31 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel27 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel30 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel26 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel28 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel23 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel29 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel24 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel25 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel13 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox11 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnOur_Location_HomePage = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox10 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel19 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel18 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.ptbImage_BestSeller_Top1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel14 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblReviews_BestSeller_Top1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRate_BestSeller_Top1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox8 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblName_BestSeller_Top1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDescribe_BestSeller_Top1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel8 = new Guna.UI2.WinForms.Guna2Panel();
            this.ptbImage_BestSeller_Top3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel54 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblName_BestSeller_Top3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox24 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblRate_BestSeller_Top3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblReviews_BestSeller_Top3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDescribe_BestSeller_Top3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel7 = new Guna.UI2.WinForms.Guna2Panel();
            this.ptbImage_BestSeller_Top2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel15 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblName_BestSeller_Top2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblReviews_BestSeller_Top2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDescribe_BestSeller_Top2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRate_BestSeller_Top2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox23 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel16 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel17 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel15 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel12 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel10 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel9 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.guna2Panel44 = new Guna.UI2.WinForms.Guna2Panel();
            this.flpCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAll = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox15 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel27 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product1 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel28 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product2 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel29 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product3 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel30 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product4 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel31 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product5 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel32 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product6 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel33 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product7 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel34 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product8 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel35 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product9 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel36 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product10 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel37 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product11 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel38 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product12 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel39 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product13 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel40 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product14 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel41 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product15 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel42 = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_product16 = new Management_Coffee_Shop.User_Controls.Product();
            this.guna2Panel43 = new Guna.UI2.WinForms.Guna2Panel();
            this.flpPageNavigation = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPage_Back = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnFirst_page = new Guna.UI2.WinForms.Guna2Button();
            this.btnSecond_page = new Guna.UI2.WinForms.Guna2Button();
            this.btnThird_page = new Guna.UI2.WinForms.Guna2Button();
            this.btnPage_Next = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2PictureBox16 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel26 = new Guna.UI2.WinForms.Guna2Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2Panel25 = new Guna.UI2.WinForms.Guna2Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2Panel24 = new Guna.UI2.WinForms.Guna2Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pnlEmpty_History = new Guna.UI2.WinForms.Guna2Panel();
            this.label29 = new System.Windows.Forms.Label();
            this.guna2PictureBox20 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnShopNow_History = new Guna.UI2.WinForms.Guna2Button();
            this.flpHistory = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel49 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel51 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.label27 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnEditProfile = new Guna.UI2.WinForms.Guna2Button();
            this.txtAddress_profile = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail_profile = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDate_profile = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtName_profile = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAddress_profile = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel47 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEmail_profile = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel46 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel45 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMode_Profile = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDate_profile = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblName_profile = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel44 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpload_Profile = new Guna.UI2.WinForms.Guna2Button();
            this.ptbImage_Profile = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pnlInformation = new Guna.UI2.WinForms.Guna2Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.guna2Panel48 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBill = new Guna.UI2.WinForms.Guna2Panel();
            this.btnOrderNow_Bill = new Guna.UI2.WinForms.Guna2Button();
            this.label10 = new System.Windows.Forms.Label();
            this.guna2HtmlLabel36 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel39 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel38 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel45 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel42 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblShip = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMoney_Sum = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel41 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel37 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMoney_SubTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flpPayment = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPayment = new Guna.UI2.WinForms.Guna2Panel();
            this.btnOrderNow = new Guna.UI2.WinForms.Guna2Button();
            this.lblMoney_payment = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel35 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel40 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel47 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlEmpty = new Guna.UI2.WinForms.Guna2Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.guna2PictureBox17 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnShopNow_Cart = new Guna.UI2.WinForms.Guna2Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.lblExpected = new System.Windows.Forms.Label();
            this.guna2Panel46 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnConfirm_Order = new Guna.UI2.WinForms.Guna2Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblOrderCode = new System.Windows.Forms.Label();
            this.lblSum_Transport = new System.Windows.Forms.Label();
            this.flpShoppingCart = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTime = new System.Windows.Forms.Label();
            this.pnlShipper = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox19 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.guna2ProgressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.guna2PictureBox18 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.guna2Panel53 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel52 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox22 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblReviews_Product = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRate_Product = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDescribe_Product = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblName_Product = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flpProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.ptbImage_Product = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccount)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.pnlAddShoppingCart.SuspendLayout();
            this.pnlSaveLogin.SuspendLayout();
            this.pnlhomePage.SuspendLayout();
            this.pnlAccount.SuspendLayout();
            this.guna2Panel50.SuspendLayout();
            this.guna2Panel55.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage_Account)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            this.guna2Panel5.SuspendLayout();
            this.guna2Panel20.SuspendLayout();
            this.guna2Panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox14)).BeginInit();
            this.guna2Panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).BeginInit();
            this.guna2Panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage_BestSeller_Top1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).BeginInit();
            this.guna2Panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage_BestSeller_Top3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox24)).BeginInit();
            this.guna2Panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage_BestSeller_Top2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel9.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.guna2Panel44.SuspendLayout();
            this.flpCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox15)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.guna2Panel27.SuspendLayout();
            this.guna2Panel28.SuspendLayout();
            this.guna2Panel29.SuspendLayout();
            this.guna2Panel30.SuspendLayout();
            this.guna2Panel31.SuspendLayout();
            this.guna2Panel32.SuspendLayout();
            this.guna2Panel33.SuspendLayout();
            this.guna2Panel34.SuspendLayout();
            this.guna2Panel35.SuspendLayout();
            this.guna2Panel36.SuspendLayout();
            this.guna2Panel37.SuspendLayout();
            this.guna2Panel38.SuspendLayout();
            this.guna2Panel39.SuspendLayout();
            this.guna2Panel40.SuspendLayout();
            this.guna2Panel41.SuspendLayout();
            this.guna2Panel42.SuspendLayout();
            this.guna2Panel43.SuspendLayout();
            this.flpPageNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox16)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.pnlEmpty_History.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox20)).BeginInit();
            this.guna2Panel49.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage_Profile)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.pnlInformation.SuspendLayout();
            this.pnlBill.SuspendLayout();
            this.flpPayment.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            this.pnlEmpty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox17)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.guna2Panel46.SuspendLayout();
            this.pnlShipper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox18)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage_Product)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.guna2Panel1.Controls.Add(this.btnAccount);
            this.guna2Panel1.Controls.Add(this.lblDate);
            this.guna2Panel1.Controls.Add(this.btnShoppingCart);
            this.guna2Panel1.Controls.Add(this.guna2TextBox1);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.lblTimer);
            this.guna2Panel1.Location = new System.Drawing.Point(-7, -8);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1387, 49);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // btnAccount
            // 
            this.btnAccount.BorderRadius = 17;
            this.btnAccount.ImageRotate = 0F;
            this.btnAccount.Location = new System.Drawing.Point(1207, 10);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(34, 34);
            this.btnAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAccount.TabIndex = 6;
            this.btnAccount.TabStop = false;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(37, 7);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(113, 20);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "guna2HtmlLabel35";
            // 
            // btnShoppingCart
            // 
            this.btnShoppingCart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShoppingCart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShoppingCart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShoppingCart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShoppingCart.FillColor = System.Drawing.Color.Transparent;
            this.btnShoppingCart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShoppingCart.ForeColor = System.Drawing.Color.White;
            this.btnShoppingCart.Image = ((System.Drawing.Image)(resources.GetObject("btnShoppingCart.Image")));
            this.btnShoppingCart.ImageSize = new System.Drawing.Size(32, 32);
            this.btnShoppingCart.Location = new System.Drawing.Point(1244, 10);
            this.btnShoppingCart.Name = "btnShoppingCart";
            this.btnShoppingCart.Size = new System.Drawing.Size(31, 34);
            this.btnShoppingCart.TabIndex = 2;
            this.btnShoppingCart.Click += new System.EventHandler(this.btnShoppingCart_Click);
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2TextBox1.BorderRadius = 10;
            this.guna2TextBox1.BorderThickness = 2;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(971, 17);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(230, 25);
            this.guna2TextBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Viner Hand ITC", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.label1.Location = new System.Drawing.Point(555, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "WESTERN";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(10, 17);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(67, 39);
            this.lblTimer.TabIndex = 4;
            this.lblTimer.Text = "8:36";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.guna2Panel2.Controls.Add(this.btnProfile);
            this.guna2Panel2.Controls.Add(this.btnHistory);
            this.guna2Panel2.Controls.Add(this.btnShopping);
            this.guna2Panel2.Controls.Add(this.guna2Button36);
            this.guna2Panel2.Controls.Add(this.btnHome);
            this.guna2Panel2.Location = new System.Drawing.Point(-7, 48);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(210, 722);
            this.guna2Panel2.TabIndex = 2;
            // 
            // btnProfile
            // 
            this.btnProfile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProfile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProfile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProfile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProfile.FillColor = System.Drawing.Color.Transparent;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.Black;
            this.btnProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnProfile.Image")));
            this.btnProfile.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProfile.ImageSize = new System.Drawing.Size(27, 27);
            this.btnProfile.Location = new System.Drawing.Point(3, 232);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(207, 45);
            this.btnProfile.TabIndex = 0;
            this.btnProfile.Text = "PROFILE";
            this.btnProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHistory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHistory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHistory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHistory.FillColor = System.Drawing.Color.Transparent;
            this.btnHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.Black;
            this.btnHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnHistory.Image")));
            this.btnHistory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHistory.ImageSize = new System.Drawing.Size(17, 17);
            this.btnHistory.Location = new System.Drawing.Point(3, 162);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(207, 55);
            this.btnHistory.TabIndex = 0;
            this.btnHistory.Text = "HISTORY";
            this.btnHistory.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnShopping
            // 
            this.btnShopping.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShopping.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShopping.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShopping.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShopping.FillColor = System.Drawing.Color.Transparent;
            this.btnShopping.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShopping.ForeColor = System.Drawing.Color.Black;
            this.btnShopping.Image = ((System.Drawing.Image)(resources.GetObject("btnShopping.Image")));
            this.btnShopping.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShopping.Location = new System.Drawing.Point(0, 111);
            this.btnShopping.Name = "btnShopping";
            this.btnShopping.Size = new System.Drawing.Size(210, 45);
            this.btnShopping.TabIndex = 0;
            this.btnShopping.Text = "SHOPPING";
            this.btnShopping.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShopping.Click += new System.EventHandler(this.btnShopping_Click);
            // 
            // guna2Button36
            // 
            this.guna2Button36.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button36.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button36.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button36.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button36.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button36.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button36.ForeColor = System.Drawing.Color.Black;
            this.guna2Button36.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button36.Image")));
            this.guna2Button36.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button36.ImageSize = new System.Drawing.Size(50, 50);
            this.guna2Button36.Location = new System.Drawing.Point(3, 9);
            this.guna2Button36.Name = "guna2Button36";
            this.guna2Button36.Size = new System.Drawing.Size(74, 45);
            this.guna2Button36.TabIndex = 0;
            this.guna2Button36.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button36.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHome.FillColor = System.Drawing.Color.Transparent;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Black;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHome.Location = new System.Drawing.Point(3, 60);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(207, 45);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "HOME";
            this.btnHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // guna2HtmlLabel22
            // 
            this.guna2HtmlLabel22.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel22.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel22.Location = new System.Drawing.Point(655, 141);
            this.guna2HtmlLabel22.Name = "guna2HtmlLabel22";
            this.guna2HtmlLabel22.Size = new System.Drawing.Size(227, 75);
            this.guna2HtmlLabel22.TabIndex = 2;
            this.guna2HtmlLabel22.Text = "Visit Us";
            // 
            // guna2HtmlLabel21
            // 
            this.guna2HtmlLabel21.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel21.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel21.Location = new System.Drawing.Point(655, 205);
            this.guna2HtmlLabel21.Name = "guna2HtmlLabel21";
            this.guna2HtmlLabel21.Size = new System.Drawing.Size(445, 27);
            this.guna2HtmlLabel21.TabIndex = 3;
            this.guna2HtmlLabel21.Text = "We have hundreds of stores around the world. ";
            // 
            // guna2HtmlLabel20
            // 
            this.guna2HtmlLabel20.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel20.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel20.Location = new System.Drawing.Point(655, 237);
            this.guna2HtmlLabel20.Name = "guna2HtmlLabel20";
            this.guna2HtmlLabel20.Size = new System.Drawing.Size(300, 27);
            this.guna2HtmlLabel20.TabIndex = 3;
            this.guna2HtmlLabel20.Text = "Ready to serve you at any time";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pnlAddShoppingCart
            // 
            this.pnlAddShoppingCart.BackColor = System.Drawing.Color.Black;
            this.pnlAddShoppingCart.Controls.Add(this.label25);
            this.pnlAddShoppingCart.Controls.Add(this.label24);
            this.pnlAddShoppingCart.Location = new System.Drawing.Point(2000, 2000);
            this.pnlAddShoppingCart.Name = "pnlAddShoppingCart";
            this.pnlAddShoppingCart.Size = new System.Drawing.Size(351, 77);
            this.pnlAddShoppingCart.TabIndex = 3;
            this.pnlAddShoppingCart.Visible = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.label25.Location = new System.Drawing.Point(123, 13);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(103, 24);
            this.label25.TabIndex = 0;
            this.label25.Text = "GIỎ HÀNG";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.label24.Location = new System.Drawing.Point(17, 42);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(323, 24);
            this.label24.TabIndex = 0;
            this.label24.Text = "Đã Thêm Vào Giỏ Hàng Thành Công";
            // 
            // pnlSaveLogin
            // 
            this.pnlSaveLogin.BackColor = System.Drawing.Color.Transparent;
            this.pnlSaveLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.pnlSaveLogin.BorderRadius = 15;
            this.pnlSaveLogin.BorderThickness = 2;
            this.pnlSaveLogin.Controls.Add(this.btnNo);
            this.pnlSaveLogin.Controls.Add(this.btnYes);
            this.pnlSaveLogin.Controls.Add(this.guna2HtmlLabel43);
            this.pnlSaveLogin.FillColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSaveLogin.Location = new System.Drawing.Point(2000, 2000);
            this.pnlSaveLogin.Name = "pnlSaveLogin";
            this.pnlSaveLogin.Size = new System.Drawing.Size(268, 67);
            this.pnlSaveLogin.TabIndex = 4;
            // 
            // btnNo
            // 
            this.btnNo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.Location = new System.Drawing.Point(147, 35);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(71, 25);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "No";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnYes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnYes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnYes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnYes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnYes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Location = new System.Drawing.Point(67, 35);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(74, 26);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "Yes";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // guna2HtmlLabel43
            // 
            this.guna2HtmlLabel43.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel43.Location = new System.Drawing.Point(3, 17);
            this.guna2HtmlLabel43.Name = "guna2HtmlLabel43";
            this.guna2HtmlLabel43.Size = new System.Drawing.Size(263, 15);
            this.guna2HtmlLabel43.TabIndex = 0;
            this.guna2HtmlLabel43.Text = "Bạn có muốn lưu thông tin đăng nhập không?";
            // 
            // homePage2
            // 
            this.homePage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.homePage2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.homePage2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.homePage2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.homePage2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.homePage2.FillColor = System.Drawing.Color.Gainsboro;
            this.homePage2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.homePage2.ForeColor = System.Drawing.Color.White;
            this.homePage2.Location = new System.Drawing.Point(1, 321);
            this.homePage2.Name = "homePage2";
            this.homePage2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.homePage2.Size = new System.Drawing.Size(15, 15);
            this.homePage2.TabIndex = 5;
            this.homePage2.Click += new System.EventHandler(this.homePage2_Click);
            // 
            // homePage4
            // 
            this.homePage4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.homePage4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.homePage4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.homePage4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.homePage4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.homePage4.FillColor = System.Drawing.Color.Gainsboro;
            this.homePage4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.homePage4.ForeColor = System.Drawing.Color.White;
            this.homePage4.Location = new System.Drawing.Point(1, 387);
            this.homePage4.Name = "homePage4";
            this.homePage4.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.homePage4.Size = new System.Drawing.Size(15, 15);
            this.homePage4.TabIndex = 6;
            this.homePage4.Text = "guna2CircleButton2";
            this.homePage4.Click += new System.EventHandler(this.homePage4_Click);
            // 
            // homePage1
            // 
            this.homePage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.homePage1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.homePage1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.homePage1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.homePage1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.homePage1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.homePage1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.homePage1.ForeColor = System.Drawing.Color.White;
            this.homePage1.Location = new System.Drawing.Point(1, 288);
            this.homePage1.Name = "homePage1";
            this.homePage1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.homePage1.Size = new System.Drawing.Size(15, 15);
            this.homePage1.TabIndex = 6;
            this.homePage1.Text = "guna2CircleButton2";
            this.homePage1.Click += new System.EventHandler(this.homePage1_Click);
            // 
            // homePage3
            // 
            this.homePage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.homePage3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.homePage3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.homePage3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.homePage3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.homePage3.FillColor = System.Drawing.Color.Gainsboro;
            this.homePage3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.homePage3.ForeColor = System.Drawing.Color.White;
            this.homePage3.Location = new System.Drawing.Point(1, 354);
            this.homePage3.Name = "homePage3";
            this.homePage3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.homePage3.Size = new System.Drawing.Size(15, 15);
            this.homePage3.TabIndex = 6;
            this.homePage3.Text = "guna2CircleButton2";
            this.homePage3.Click += new System.EventHandler(this.homePage3_Click);
            // 
            // homePage5
            // 
            this.homePage5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.homePage5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.homePage5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.homePage5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.homePage5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.homePage5.FillColor = System.Drawing.Color.Gainsboro;
            this.homePage5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.homePage5.ForeColor = System.Drawing.Color.White;
            this.homePage5.Location = new System.Drawing.Point(1, 420);
            this.homePage5.Name = "homePage5";
            this.homePage5.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.homePage5.Size = new System.Drawing.Size(15, 15);
            this.homePage5.TabIndex = 7;
            this.homePage5.Text = "guna2CircleButton6";
            this.homePage5.Click += new System.EventHandler(this.homePage5_Click);
            // 
            // pnlhomePage
            // 
            this.pnlhomePage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlhomePage.Controls.Add(this.homePage5);
            this.pnlhomePage.Controls.Add(this.homePage2);
            this.pnlhomePage.Controls.Add(this.homePage4);
            this.pnlhomePage.Controls.Add(this.homePage1);
            this.pnlhomePage.Controls.Add(this.homePage3);
            this.pnlhomePage.Location = new System.Drawing.Point(1357, 48);
            this.pnlhomePage.Name = "pnlhomePage";
            this.pnlhomePage.Size = new System.Drawing.Size(21, 722);
            this.pnlhomePage.TabIndex = 5;
            // 
            // pnlAccount
            // 
            this.pnlAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.pnlAccount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.pnlAccount.BorderRadius = 15;
            this.pnlAccount.BorderThickness = 2;
            this.pnlAccount.Controls.Add(this.guna2Panel55);
            this.pnlAccount.Controls.Add(this.guna2Panel50);
            this.pnlAccount.Controls.Add(this.btnAddAccount);
            this.pnlAccount.Controls.Add(this.btnLogOut);
            this.pnlAccount.Controls.Add(this.btnEditAccount_Account);
            this.pnlAccount.Controls.Add(this.btnChangePassword);
            this.pnlAccount.Controls.Add(this.btnOrder_Account);
            this.pnlAccount.Location = new System.Drawing.Point(1023, 35);
            this.pnlAccount.Name = "pnlAccount";
            this.pnlAccount.Size = new System.Drawing.Size(209, 456);
            this.pnlAccount.TabIndex = 6;
            // 
            // guna2Panel50
            // 
            this.guna2Panel50.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel50.BorderThickness = 1;
            this.guna2Panel50.Controls.Add(this.flpAnotherAccount);
            this.guna2Panel50.Controls.Add(this.label26);
            this.guna2Panel50.Location = new System.Drawing.Point(3, 144);
            this.guna2Panel50.Name = "guna2Panel50";
            this.guna2Panel50.Size = new System.Drawing.Size(203, 137);
            this.guna2Panel50.TabIndex = 1;
            // 
            // flpAnotherAccount
            // 
            this.flpAnotherAccount.AutoScroll = true;
            this.flpAnotherAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpAnotherAccount.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAnotherAccount.Location = new System.Drawing.Point(0, 28);
            this.flpAnotherAccount.Name = "flpAnotherAccount";
            this.flpAnotherAccount.Size = new System.Drawing.Size(203, 106);
            this.flpAnotherAccount.TabIndex = 1;
            this.flpAnotherAccount.WrapContents = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(3, 7);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(152, 24);
            this.label26.TabIndex = 0;
            this.label26.Text = "Another Account";
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddAccount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddAccount.FillColor = System.Drawing.Color.Transparent;
            this.btnAddAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAccount.ForeColor = System.Drawing.Color.Black;
            this.btnAddAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAccount.Image")));
            this.btnAddAccount.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddAccount.ImageOffset = new System.Drawing.Point(-5, 0);
            this.btnAddAccount.ImageSize = new System.Drawing.Size(26, 26);
            this.btnAddAccount.Location = new System.Drawing.Point(3, 372);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(203, 34);
            this.btnAddAccount.TabIndex = 0;
            this.btnAddAccount.Text = "Add Account";
            this.btnAddAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddAccount.TextOffset = new System.Drawing.Point(-4, 0);
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogOut.FillColor = System.Drawing.Color.Transparent;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.Black;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogOut.ImageOffset = new System.Drawing.Point(4, 0);
            this.btnLogOut.ImageSize = new System.Drawing.Size(17, 17);
            this.btnLogOut.Location = new System.Drawing.Point(3, 412);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(203, 34);
            this.btnLogOut.TabIndex = 0;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogOut.TextOffset = new System.Drawing.Point(5, 0);
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnEditAccount_Account
            // 
            this.btnEditAccount_Account.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditAccount_Account.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditAccount_Account.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditAccount_Account.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditAccount_Account.FillColor = System.Drawing.Color.Transparent;
            this.btnEditAccount_Account.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditAccount_Account.ForeColor = System.Drawing.Color.Black;
            this.btnEditAccount_Account.Image = ((System.Drawing.Image)(resources.GetObject("btnEditAccount_Account.Image")));
            this.btnEditAccount_Account.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEditAccount_Account.Location = new System.Drawing.Point(3, 287);
            this.btnEditAccount_Account.Name = "btnEditAccount_Account";
            this.btnEditAccount_Account.Size = new System.Drawing.Size(203, 34);
            this.btnEditAccount_Account.TabIndex = 0;
            this.btnEditAccount_Account.Text = "Account";
            this.btnEditAccount_Account.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEditAccount_Account.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangePassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangePassword.FillColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.Black;
            this.btnChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.Image")));
            this.btnChangePassword.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnChangePassword.Location = new System.Drawing.Point(3, 327);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(203, 34);
            this.btnChangePassword.TabIndex = 0;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnOrder_Account
            // 
            this.btnOrder_Account.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOrder_Account.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOrder_Account.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOrder_Account.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOrder_Account.FillColor = System.Drawing.Color.Transparent;
            this.btnOrder_Account.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnOrder_Account.ForeColor = System.Drawing.Color.Black;
            this.btnOrder_Account.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder_Account.Image")));
            this.btnOrder_Account.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnOrder_Account.Location = new System.Drawing.Point(3, 111);
            this.btnOrder_Account.Name = "btnOrder_Account";
            this.btnOrder_Account.Size = new System.Drawing.Size(203, 34);
            this.btnOrder_Account.TabIndex = 0;
            this.btnOrder_Account.Text = "Order";
            this.btnOrder_Account.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnOrder_Account.Click += new System.EventHandler(this.btnOrder_Account_Click);
            // 
            // guna2Panel55
            // 
            this.guna2Panel55.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel55.BorderRadius = 15;
            this.guna2Panel55.Controls.Add(this.lblName_Account);
            this.guna2Panel55.Controls.Add(this.ptbImage_Account);
            this.guna2Panel55.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.guna2Panel55.Location = new System.Drawing.Point(4, 12);
            this.guna2Panel55.Name = "guna2Panel55";
            this.guna2Panel55.Size = new System.Drawing.Size(199, 96);
            this.guna2Panel55.TabIndex = 2;
            // 
            // ptbImage_Account
            // 
            this.ptbImage_Account.BorderRadius = 31;
            this.ptbImage_Account.ImageRotate = 0F;
            this.ptbImage_Account.Location = new System.Drawing.Point(68, 1);
            this.ptbImage_Account.Name = "ptbImage_Account";
            this.ptbImage_Account.Size = new System.Drawing.Size(62, 62);
            this.ptbImage_Account.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbImage_Account.TabIndex = 0;
            this.ptbImage_Account.TabStop = false;
            // 
            // lblName_Account
            // 
            this.lblName_Account.BackColor = System.Drawing.Color.Transparent;
            this.lblName_Account.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName_Account.Location = new System.Drawing.Point(63, 68);
            this.lblName_Account.Name = "lblName_Account";
            this.lblName_Account.Size = new System.Drawing.Size(72, 28);
            this.lblName_Account.TabIndex = 1;
            this.lblName_Account.Text = "Hello Lê";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(209, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1171, 747);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.guna2PictureBox6);
            this.tabPage1.Controls.Add(this.btnShopNow);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.guna2PictureBox5);
            this.tabPage1.Controls.Add(this.guna2PictureBox4);
            this.tabPage1.Controls.Add(this.guna2HtmlLabel14);
            this.tabPage1.Controls.Add(this.guna2HtmlLabel13);
            this.tabPage1.Controls.Add(this.guna2Panel11);
            this.tabPage1.Controls.Add(this.guna2HtmlLabel5);
            this.tabPage1.Controls.Add(this.guna2Panel5);
            this.tabPage1.Controls.Add(this.guna2HtmlLabel16);
            this.tabPage1.Controls.Add(this.guna2HtmlLabel17);
            this.tabPage1.Controls.Add(this.guna2HtmlLabel15);
            this.tabPage1.Controls.Add(this.guna2HtmlLabel1);
            this.tabPage1.Controls.Add(this.guna2PictureBox3);
            this.tabPage1.Controls.Add(this.guna2Panel12);
            this.tabPage1.Controls.Add(this.guna2Panel10);
            this.tabPage1.Controls.Add(this.guna2Panel4);
            this.tabPage1.Controls.Add(this.guna2PictureBox2);
            this.tabPage1.Controls.Add(this.guna2PictureBox1);
            this.tabPage1.Controls.Add(this.guna2Panel9);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1163, 721);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // guna2PictureBox6
            // 
            this.guna2PictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox6.Image")));
            this.guna2PictureBox6.ImageRotate = 0F;
            this.guna2PictureBox6.Location = new System.Drawing.Point(1051, 280);
            this.guna2PictureBox6.Name = "guna2PictureBox6";
            this.guna2PictureBox6.Size = new System.Drawing.Size(80, 68);
            this.guna2PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox6.TabIndex = 1;
            this.guna2PictureBox6.TabStop = false;
            this.guna2PictureBox6.UseTransparentBackground = true;
            // 
            // btnShopNow
            // 
            this.btnShopNow.BorderRadius = 20;
            this.btnShopNow.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShopNow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShopNow.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShopNow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShopNow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnShopNow.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShopNow.ForeColor = System.Drawing.Color.White;
            this.btnShopNow.Location = new System.Drawing.Point(207, 662);
            this.btnShopNow.Name = "btnShopNow";
            this.btnShopNow.Size = new System.Drawing.Size(172, 45);
            this.btnShopNow.TabIndex = 8;
            this.btnShopNow.Text = "SHOP NOW";
            this.btnShopNow.Click += new System.EventHandler(this.btnShopping_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(905, 641);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Juice";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1048, 532);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tea";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1064, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Milk Tea";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1008, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Coffee";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(881, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Latte";
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox5.Image")));
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(885, 567);
            this.guna2PictureBox5.Name = "guna2PictureBox5";
            this.guna2PictureBox5.Size = new System.Drawing.Size(87, 68);
            this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox5.TabIndex = 1;
            this.guna2PictureBox5.TabStop = false;
            this.guna2PictureBox5.UseTransparentBackground = true;
            // 
            // guna2PictureBox4
            // 
            this.guna2PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox4.Image")));
            this.guna2PictureBox4.ImageRotate = 0F;
            this.guna2PictureBox4.Location = new System.Drawing.Point(1021, 459);
            this.guna2PictureBox4.Name = "guna2PictureBox4";
            this.guna2PictureBox4.Size = new System.Drawing.Size(81, 61);
            this.guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox4.TabIndex = 1;
            this.guna2PictureBox4.TabStop = false;
            this.guna2PictureBox4.UseTransparentBackground = true;
            // 
            // guna2HtmlLabel14
            // 
            this.guna2HtmlLabel14.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel14.Location = new System.Drawing.Point(19, 397);
            this.guna2HtmlLabel14.Name = "guna2HtmlLabel14";
            this.guna2HtmlLabel14.Size = new System.Drawing.Size(233, 18);
            this.guna2HtmlLabel14.TabIndex = 6;
            this.guna2HtmlLabel14.Text = "will be a hot cup of coffee for you.";
            // 
            // guna2HtmlLabel13
            // 
            this.guna2HtmlLabel13.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel13.Location = new System.Drawing.Point(20, 379);
            this.guna2HtmlLabel13.Name = "guna2HtmlLabel13";
            this.guna2HtmlLabel13.Size = new System.Drawing.Size(485, 18);
            this.guna2HtmlLabel13.TabIndex = 6;
            this.guna2HtmlLabel13.Text = "and conveniently without having to go out. Pick up the phone  and there";
            // 
            // guna2Panel11
            // 
            this.guna2Panel11.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel11.BorderRadius = 25;
            this.guna2Panel11.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2Panel11.Location = new System.Drawing.Point(1041, 479);
            this.guna2Panel11.Name = "guna2Panel11";
            this.guna2Panel11.Size = new System.Drawing.Size(42, 50);
            this.guna2Panel11.TabIndex = 2;
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(19, 360);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(473, 18);
            this.guna2HtmlLabel5.TabIndex = 6;
            this.guna2HtmlLabel5.Text = "We provide smart customer solutions.  Helps customers shop quickly";
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.BackColor = System.Drawing.Color.White;
            this.guna2Panel5.Controls.Add(this.guna2Panel20);
            this.guna2Panel5.Controls.Add(this.guna2Panel16);
            this.guna2Panel5.Controls.Add(this.guna2HtmlLabel12);
            this.guna2Panel5.Controls.Add(this.guna2HtmlLabel11);
            this.guna2Panel5.Controls.Add(this.guna2HtmlLabel9);
            this.guna2Panel5.Controls.Add(this.guna2HtmlLabel8);
            this.guna2Panel5.Controls.Add(this.guna2Panel17);
            this.guna2Panel5.Controls.Add(this.guna2Panel13);
            this.guna2Panel5.Controls.Add(this.guna2Panel6);
            this.guna2Panel5.Controls.Add(this.guna2Panel8);
            this.guna2Panel5.Controls.Add(this.guna2Panel7);
            this.guna2Panel5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(220)))), ((int)(((byte)(195)))));
            this.guna2Panel5.Location = new System.Drawing.Point(0, 805);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(1145, 2376);
            this.guna2Panel5.TabIndex = 4;
            // 
            // guna2Panel20
            // 
            this.guna2Panel20.BackColor = System.Drawing.Color.Black;
            this.guna2Panel20.Controls.Add(this.guna2Button23);
            this.guna2Panel20.Controls.Add(this.guna2Button7);
            this.guna2Panel20.Controls.Add(this.guna2Button6);
            this.guna2Panel20.Controls.Add(this.guna2Button22);
            this.guna2Panel20.Controls.Add(this.guna2Button18);
            this.guna2Panel20.Controls.Add(this.btnAttendant_HomePage);
            this.guna2Panel20.Controls.Add(this.guna2Button21);
            this.guna2Panel20.Controls.Add(this.guna2Button17);
            this.guna2Panel20.Controls.Add(this.btnLocation_HomePage);
            this.guna2Panel20.Controls.Add(this.guna2Button20);
            this.guna2Panel20.Controls.Add(this.guna2Button16);
            this.guna2Panel20.Controls.Add(this.btnBestSeller_HomePage);
            this.guna2Panel20.Controls.Add(this.guna2Button19);
            this.guna2Panel20.Controls.Add(this.guna2Button15);
            this.guna2Panel20.Controls.Add(this.btnAbout_Us_HomePage);
            this.guna2Panel20.Controls.Add(this.guna2Panel23);
            this.guna2Panel20.Controls.Add(this.guna2Panel22);
            this.guna2Panel20.Controls.Add(this.guna2Panel21);
            this.guna2Panel20.Controls.Add(this.guna2HtmlLabel34);
            this.guna2Panel20.Controls.Add(this.guna2HtmlLabel33);
            this.guna2Panel20.Controls.Add(this.guna2HtmlLabel32);
            this.guna2Panel20.Location = new System.Drawing.Point(0, 1999);
            this.guna2Panel20.Name = "guna2Panel20";
            this.guna2Panel20.Size = new System.Drawing.Size(1145, 376);
            this.guna2Panel20.TabIndex = 4;
            // 
            // guna2Button23
            // 
            this.guna2Button23.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button23.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button23.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button23.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button23.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button23.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button23.ForeColor = System.Drawing.Color.White;
            this.guna2Button23.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button23.Image")));
            this.guna2Button23.ImageSize = new System.Drawing.Size(32, 32);
            this.guna2Button23.Location = new System.Drawing.Point(1022, 321);
            this.guna2Button23.Name = "guna2Button23";
            this.guna2Button23.Size = new System.Drawing.Size(55, 45);
            this.guna2Button23.TabIndex = 8;
            // 
            // guna2Button7
            // 
            this.guna2Button7.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button7.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button7.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button7.ForeColor = System.Drawing.Color.White;
            this.guna2Button7.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button7.Image")));
            this.guna2Button7.ImageSize = new System.Drawing.Size(32, 32);
            this.guna2Button7.Location = new System.Drawing.Point(976, 321);
            this.guna2Button7.Name = "guna2Button7";
            this.guna2Button7.Size = new System.Drawing.Size(55, 45);
            this.guna2Button7.TabIndex = 8;
            // 
            // guna2Button6
            // 
            this.guna2Button6.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button6.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button6.ForeColor = System.Drawing.Color.White;
            this.guna2Button6.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button6.Image")));
            this.guna2Button6.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2Button6.Location = new System.Drawing.Point(929, 321);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.Size = new System.Drawing.Size(55, 45);
            this.guna2Button6.TabIndex = 8;
            // 
            // guna2Button22
            // 
            this.guna2Button22.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button22.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button22.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button22.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button22.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button22.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Button22.Location = new System.Drawing.Point(764, 229);
            this.guna2Button22.Name = "guna2Button22";
            this.guna2Button22.Size = new System.Drawing.Size(180, 45);
            this.guna2Button22.TabIndex = 7;
            this.guna2Button22.Text = "Attendant";
            this.guna2Button22.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2Button18
            // 
            this.guna2Button18.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button18.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button18.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button18.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button18.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button18.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Button18.Location = new System.Drawing.Point(398, 229);
            this.guna2Button18.Name = "guna2Button18";
            this.guna2Button18.Size = new System.Drawing.Size(180, 45);
            this.guna2Button18.TabIndex = 7;
            this.guna2Button18.Text = "Attendant";
            this.guna2Button18.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnAttendant_HomePage
            // 
            this.btnAttendant_HomePage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAttendant_HomePage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAttendant_HomePage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAttendant_HomePage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAttendant_HomePage.FillColor = System.Drawing.Color.Transparent;
            this.btnAttendant_HomePage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendant_HomePage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnAttendant_HomePage.Location = new System.Drawing.Point(91, 229);
            this.btnAttendant_HomePage.Name = "btnAttendant_HomePage";
            this.btnAttendant_HomePage.Size = new System.Drawing.Size(180, 45);
            this.btnAttendant_HomePage.TabIndex = 7;
            this.btnAttendant_HomePage.Text = "Attendant";
            this.btnAttendant_HomePage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAttendant_HomePage.Click += new System.EventHandler(this.homePage4_Click);
            // 
            // guna2Button21
            // 
            this.guna2Button21.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button21.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button21.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button21.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button21.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button21.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Button21.Location = new System.Drawing.Point(764, 178);
            this.guna2Button21.Name = "guna2Button21";
            this.guna2Button21.Size = new System.Drawing.Size(180, 45);
            this.guna2Button21.TabIndex = 7;
            this.guna2Button21.Text = "Location";
            this.guna2Button21.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2Button17
            // 
            this.guna2Button17.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button17.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button17.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button17.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button17.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button17.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Button17.Location = new System.Drawing.Point(398, 178);
            this.guna2Button17.Name = "guna2Button17";
            this.guna2Button17.Size = new System.Drawing.Size(180, 45);
            this.guna2Button17.TabIndex = 7;
            this.guna2Button17.Text = "Location";
            this.guna2Button17.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnLocation_HomePage
            // 
            this.btnLocation_HomePage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLocation_HomePage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLocation_HomePage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLocation_HomePage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLocation_HomePage.FillColor = System.Drawing.Color.Transparent;
            this.btnLocation_HomePage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocation_HomePage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnLocation_HomePage.Location = new System.Drawing.Point(91, 178);
            this.btnLocation_HomePage.Name = "btnLocation_HomePage";
            this.btnLocation_HomePage.Size = new System.Drawing.Size(180, 45);
            this.btnLocation_HomePage.TabIndex = 7;
            this.btnLocation_HomePage.Text = "Location";
            this.btnLocation_HomePage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLocation_HomePage.Click += new System.EventHandler(this.homePage3_Click);
            // 
            // guna2Button20
            // 
            this.guna2Button20.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button20.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button20.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button20.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button20.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button20.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Button20.Location = new System.Drawing.Point(764, 127);
            this.guna2Button20.Name = "guna2Button20";
            this.guna2Button20.Size = new System.Drawing.Size(180, 45);
            this.guna2Button20.TabIndex = 7;
            this.guna2Button20.Text = "Best Seller";
            this.guna2Button20.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2Button16
            // 
            this.guna2Button16.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button16.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button16.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button16.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button16.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button16.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Button16.Location = new System.Drawing.Point(398, 127);
            this.guna2Button16.Name = "guna2Button16";
            this.guna2Button16.Size = new System.Drawing.Size(180, 45);
            this.guna2Button16.TabIndex = 7;
            this.guna2Button16.Text = "Best Seller";
            this.guna2Button16.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnBestSeller_HomePage
            // 
            this.btnBestSeller_HomePage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBestSeller_HomePage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBestSeller_HomePage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBestSeller_HomePage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBestSeller_HomePage.FillColor = System.Drawing.Color.Transparent;
            this.btnBestSeller_HomePage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBestSeller_HomePage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnBestSeller_HomePage.Location = new System.Drawing.Point(91, 127);
            this.btnBestSeller_HomePage.Name = "btnBestSeller_HomePage";
            this.btnBestSeller_HomePage.Size = new System.Drawing.Size(180, 45);
            this.btnBestSeller_HomePage.TabIndex = 7;
            this.btnBestSeller_HomePage.Text = "Best Seller";
            this.btnBestSeller_HomePage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBestSeller_HomePage.Click += new System.EventHandler(this.homePage2_Click);
            // 
            // guna2Button19
            // 
            this.guna2Button19.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button19.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button19.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button19.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button19.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button19.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Button19.Location = new System.Drawing.Point(764, 76);
            this.guna2Button19.Name = "guna2Button19";
            this.guna2Button19.Size = new System.Drawing.Size(180, 45);
            this.guna2Button19.TabIndex = 7;
            this.guna2Button19.Text = "About Us";
            this.guna2Button19.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2Button15
            // 
            this.guna2Button15.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button15.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button15.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button15.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button15.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button15.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Button15.Location = new System.Drawing.Point(398, 76);
            this.guna2Button15.Name = "guna2Button15";
            this.guna2Button15.Size = new System.Drawing.Size(180, 45);
            this.guna2Button15.TabIndex = 7;
            this.guna2Button15.Text = "About Us";
            this.guna2Button15.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnAbout_Us_HomePage
            // 
            this.btnAbout_Us_HomePage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAbout_Us_HomePage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAbout_Us_HomePage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAbout_Us_HomePage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAbout_Us_HomePage.FillColor = System.Drawing.Color.Transparent;
            this.btnAbout_Us_HomePage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout_Us_HomePage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnAbout_Us_HomePage.Location = new System.Drawing.Point(91, 76);
            this.btnAbout_Us_HomePage.Name = "btnAbout_Us_HomePage";
            this.btnAbout_Us_HomePage.Size = new System.Drawing.Size(180, 45);
            this.btnAbout_Us_HomePage.TabIndex = 7;
            this.btnAbout_Us_HomePage.Text = "About Us";
            this.btnAbout_Us_HomePage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAbout_Us_HomePage.Click += new System.EventHandler(this.homePage1_Click);
            // 
            // guna2Panel23
            // 
            this.guna2Panel23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel23.Location = new System.Drawing.Point(764, 67);
            this.guna2Panel23.Name = "guna2Panel23";
            this.guna2Panel23.Size = new System.Drawing.Size(220, 3);
            this.guna2Panel23.TabIndex = 6;
            // 
            // guna2Panel22
            // 
            this.guna2Panel22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel22.Location = new System.Drawing.Point(398, 67);
            this.guna2Panel22.Name = "guna2Panel22";
            this.guna2Panel22.Size = new System.Drawing.Size(220, 3);
            this.guna2Panel22.TabIndex = 6;
            // 
            // guna2Panel21
            // 
            this.guna2Panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel21.Location = new System.Drawing.Point(91, 67);
            this.guna2Panel21.Name = "guna2Panel21";
            this.guna2Panel21.Size = new System.Drawing.Size(220, 3);
            this.guna2Panel21.TabIndex = 6;
            // 
            // guna2HtmlLabel34
            // 
            this.guna2HtmlLabel34.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel34.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel34.Location = new System.Drawing.Point(773, 28);
            this.guna2HtmlLabel34.Name = "guna2HtmlLabel34";
            this.guna2HtmlLabel34.Size = new System.Drawing.Size(195, 33);
            this.guna2HtmlLabel34.TabIndex = 3;
            this.guna2HtmlLabel34.Text = "INFORMATION";
            // 
            // guna2HtmlLabel33
            // 
            this.guna2HtmlLabel33.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel33.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel33.Location = new System.Drawing.Point(400, 28);
            this.guna2HtmlLabel33.Name = "guna2HtmlLabel33";
            this.guna2HtmlLabel33.Size = new System.Drawing.Size(195, 33);
            this.guna2HtmlLabel33.TabIndex = 3;
            this.guna2HtmlLabel33.Text = "INFORMATION";
            // 
            // guna2HtmlLabel32
            // 
            this.guna2HtmlLabel32.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel32.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel32.Location = new System.Drawing.Point(101, 28);
            this.guna2HtmlLabel32.Name = "guna2HtmlLabel32";
            this.guna2HtmlLabel32.Size = new System.Drawing.Size(195, 33);
            this.guna2HtmlLabel32.TabIndex = 3;
            this.guna2HtmlLabel32.Text = "INFORMATION";
            // 
            // guna2Panel16
            // 
            this.guna2Panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel16.Location = new System.Drawing.Point(810, 223);
            this.guna2Panel16.Name = "guna2Panel16";
            this.guna2Panel16.Size = new System.Drawing.Size(200, 3);
            this.guna2Panel16.TabIndex = 2;
            // 
            // guna2HtmlLabel12
            // 
            this.guna2HtmlLabel12.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel12.Location = new System.Drawing.Point(810, 262);
            this.guna2HtmlLabel12.Name = "guna2HtmlLabel12";
            this.guna2HtmlLabel12.Size = new System.Drawing.Size(300, 27);
            this.guna2HtmlLabel12.TabIndex = 3;
            this.guna2HtmlLabel12.Text = "The Modern Coffee experience";
            // 
            // guna2HtmlLabel11
            // 
            this.guna2HtmlLabel11.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel11.Location = new System.Drawing.Point(810, 288);
            this.guna2HtmlLabel11.Name = "guna2HtmlLabel11";
            this.guna2HtmlLabel11.Size = new System.Drawing.Size(315, 27);
            this.guna2HtmlLabel11.TabIndex = 3;
            this.guna2HtmlLabel11.Text = " in the comfort of your own home.";
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(810, 149);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(192, 75);
            this.guna2HtmlLabel9.TabIndex = 2;
            this.guna2HtmlLabel9.Text = "Seller.";
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(810, 59);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(195, 110);
            this.guna2HtmlLabel8.TabIndex = 2;
            this.guna2HtmlLabel8.Text = "Best";
            // 
            // guna2Panel17
            // 
            this.guna2Panel17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel17.Controls.Add(this.guna2Panel19);
            this.guna2Panel17.Controls.Add(this.guna2Panel18);
            this.guna2Panel17.Controls.Add(this.guna2PictureBox13);
            this.guna2Panel17.Controls.Add(this.guna2PictureBox12);
            this.guna2Panel17.Controls.Add(this.guna2PictureBox14);
            this.guna2Panel17.Controls.Add(this.btnFeed_Back_HomePage);
            this.guna2Panel17.Controls.Add(this.guna2HtmlLabel31);
            this.guna2Panel17.Controls.Add(this.guna2HtmlLabel27);
            this.guna2Panel17.Controls.Add(this.guna2HtmlLabel30);
            this.guna2Panel17.Controls.Add(this.guna2HtmlLabel26);
            this.guna2Panel17.Controls.Add(this.guna2HtmlLabel28);
            this.guna2Panel17.Controls.Add(this.guna2HtmlLabel23);
            this.guna2Panel17.Controls.Add(this.guna2HtmlLabel29);
            this.guna2Panel17.Controls.Add(this.guna2HtmlLabel24);
            this.guna2Panel17.Controls.Add(this.guna2HtmlLabel25);
            this.guna2Panel17.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(220)))), ((int)(((byte)(195)))));
            this.guna2Panel17.Location = new System.Drawing.Point(0, 1201);
            this.guna2Panel17.Name = "guna2Panel17";
            this.guna2Panel17.Size = new System.Drawing.Size(1146, 797);
            this.guna2Panel17.TabIndex = 1;
            this.guna2Panel17.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel17_Paint);
            // 
            // guna2Panel19
            // 
            this.guna2Panel19.BackColor = System.Drawing.Color.Black;
            this.guna2Panel19.Location = new System.Drawing.Point(897, 477);
            this.guna2Panel19.Name = "guna2Panel19";
            this.guna2Panel19.Size = new System.Drawing.Size(208, 3);
            this.guna2Panel19.TabIndex = 6;
            // 
            // guna2Panel18
            // 
            this.guna2Panel18.BackColor = System.Drawing.Color.Black;
            this.guna2Panel18.Location = new System.Drawing.Point(669, 141);
            this.guna2Panel18.Name = "guna2Panel18";
            this.guna2Panel18.Size = new System.Drawing.Size(208, 3);
            this.guna2Panel18.TabIndex = 6;
            // 
            // guna2PictureBox13
            // 
            this.guna2PictureBox13.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox13.BorderRadius = 40;
            this.guna2PictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox13.Image")));
            this.guna2PictureBox13.ImageRotate = 0F;
            this.guna2PictureBox13.Location = new System.Drawing.Point(32, 141);
            this.guna2PictureBox13.Name = "guna2PictureBox13";
            this.guna2PictureBox13.Size = new System.Drawing.Size(595, 554);
            this.guna2PictureBox13.TabIndex = 0;
            this.guna2PictureBox13.TabStop = false;
            // 
            // guna2PictureBox12
            // 
            this.guna2PictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox12.BorderRadius = 30;
            this.guna2PictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox12.Image")));
            this.guna2PictureBox12.ImageRotate = 0F;
            this.guna2PictureBox12.Location = new System.Drawing.Point(669, 427);
            this.guna2PictureBox12.Name = "guna2PictureBox12";
            this.guna2PictureBox12.Size = new System.Drawing.Size(213, 268);
            this.guna2PictureBox12.TabIndex = 0;
            this.guna2PictureBox12.TabStop = false;
            // 
            // guna2PictureBox14
            // 
            this.guna2PictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox14.BorderRadius = 30;
            this.guna2PictureBox14.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox14.Image")));
            this.guna2PictureBox14.ImageRotate = 0F;
            this.guna2PictureBox14.Location = new System.Drawing.Point(897, 141);
            this.guna2PictureBox14.Name = "guna2PictureBox14";
            this.guna2PictureBox14.Size = new System.Drawing.Size(213, 268);
            this.guna2PictureBox14.TabIndex = 0;
            this.guna2PictureBox14.TabStop = false;
            // 
            // btnFeed_Back_HomePage
            // 
            this.btnFeed_Back_HomePage.BackColor = System.Drawing.Color.Transparent;
            this.btnFeed_Back_HomePage.BorderRadius = 17;
            this.btnFeed_Back_HomePage.BorderThickness = 2;
            this.btnFeed_Back_HomePage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFeed_Back_HomePage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFeed_Back_HomePage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFeed_Back_HomePage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFeed_Back_HomePage.FillColor = System.Drawing.Color.Transparent;
            this.btnFeed_Back_HomePage.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeed_Back_HomePage.ForeColor = System.Drawing.Color.Black;
            this.btnFeed_Back_HomePage.Location = new System.Drawing.Point(897, 662);
            this.btnFeed_Back_HomePage.Name = "btnFeed_Back_HomePage";
            this.btnFeed_Back_HomePage.Size = new System.Drawing.Size(180, 33);
            this.btnFeed_Back_HomePage.TabIndex = 5;
            this.btnFeed_Back_HomePage.Text = "Feed Back";
            this.btnFeed_Back_HomePage.TextOffset = new System.Drawing.Point(0, -3);
            this.btnFeed_Back_HomePage.Click += new System.EventHandler(this.btnOur_Location_HomePage_Click);
            // 
            // guna2HtmlLabel31
            // 
            this.guna2HtmlLabel31.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel31.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel31.Location = new System.Drawing.Point(897, 561);
            this.guna2HtmlLabel31.Name = "guna2HtmlLabel31";
            this.guna2HtmlLabel31.Size = new System.Drawing.Size(163, 27);
            this.guna2HtmlLabel31.TabIndex = 3;
            this.guna2HtmlLabel31.Text = "around the world";
            // 
            // guna2HtmlLabel27
            // 
            this.guna2HtmlLabel27.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel27.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel27.Location = new System.Drawing.Point(669, 332);
            this.guna2HtmlLabel27.Name = "guna2HtmlLabel27";
            this.guna2HtmlLabel27.Size = new System.Drawing.Size(79, 27);
            this.guna2HtmlLabel27.TabIndex = 3;
            this.guna2HtmlLabel27.Text = " conduct";
            // 
            // guna2HtmlLabel30
            // 
            this.guna2HtmlLabel30.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel30.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel30.Location = new System.Drawing.Point(897, 528);
            this.guna2HtmlLabel30.Name = "guna2HtmlLabel30";
            this.guna2HtmlLabel30.Size = new System.Drawing.Size(229, 27);
            this.guna2HtmlLabel30.TabIndex = 3;
            this.guna2HtmlLabel30.Text = "professional bartenders";
            // 
            // guna2HtmlLabel26
            // 
            this.guna2HtmlLabel26.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel26.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel26.Location = new System.Drawing.Point(669, 299);
            this.guna2HtmlLabel26.Name = "guna2HtmlLabel26";
            this.guna2HtmlLabel26.Size = new System.Drawing.Size(216, 27);
            this.guna2HtmlLabel26.TabIndex = 3;
            this.guna2HtmlLabel26.Text = "according to a code of";
            // 
            // guna2HtmlLabel28
            // 
            this.guna2HtmlLabel28.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel28.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel28.Location = new System.Drawing.Point(897, 427);
            this.guna2HtmlLabel28.Name = "guna2HtmlLabel28";
            this.guna2HtmlLabel28.Size = new System.Drawing.Size(119, 44);
            this.guna2HtmlLabel28.TabIndex = 3;
            this.guna2HtmlLabel28.Text = "Barista";
            // 
            // guna2HtmlLabel23
            // 
            this.guna2HtmlLabel23.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel23.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel23.Location = new System.Drawing.Point(669, 152);
            this.guna2HtmlLabel23.Name = "guna2HtmlLabel23";
            this.guna2HtmlLabel23.Size = new System.Drawing.Size(159, 44);
            this.guna2HtmlLabel23.TabIndex = 3;
            this.guna2HtmlLabel23.Text = "Trainning";
            // 
            // guna2HtmlLabel29
            // 
            this.guna2HtmlLabel29.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel29.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel29.Location = new System.Drawing.Point(897, 495);
            this.guna2HtmlLabel29.Name = "guna2HtmlLabel29";
            this.guna2HtmlLabel29.Size = new System.Drawing.Size(116, 27);
            this.guna2HtmlLabel29.TabIndex = 3;
            this.guna2HtmlLabel29.Text = "They are all ";
            // 
            // guna2HtmlLabel24
            // 
            this.guna2HtmlLabel24.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel24.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel24.Location = new System.Drawing.Point(669, 266);
            this.guna2HtmlLabel24.Name = "guna2HtmlLabel24";
            this.guna2HtmlLabel24.Size = new System.Drawing.Size(222, 27);
            this.guna2HtmlLabel24.TabIndex = 3;
            this.guna2HtmlLabel24.Text = "Our staff are all trained";
            // 
            // guna2HtmlLabel25
            // 
            this.guna2HtmlLabel25.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel25.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel25.Location = new System.Drawing.Point(32, 64);
            this.guna2HtmlLabel25.Name = "guna2HtmlLabel25";
            this.guna2HtmlLabel25.Size = new System.Drawing.Size(289, 75);
            this.guna2HtmlLabel25.TabIndex = 2;
            this.guna2HtmlLabel25.Text = "Attendant";
            // 
            // guna2Panel13
            // 
            this.guna2Panel13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel13.Controls.Add(this.guna2PictureBox11);
            this.guna2Panel13.Controls.Add(this.btnOur_Location_HomePage);
            this.guna2Panel13.Controls.Add(this.guna2PictureBox10);
            this.guna2Panel13.Controls.Add(this.guna2HtmlLabel19);
            this.guna2Panel13.Controls.Add(this.guna2HtmlLabel10);
            this.guna2Panel13.Controls.Add(this.guna2HtmlLabel18);
            this.guna2Panel13.Location = new System.Drawing.Point(0, 418);
            this.guna2Panel13.Name = "guna2Panel13";
            this.guna2Panel13.Size = new System.Drawing.Size(1145, 787);
            this.guna2Panel13.TabIndex = 1;
            // 
            // guna2PictureBox11
            // 
            this.guna2PictureBox11.BorderRadius = 40;
            this.guna2PictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox11.Image")));
            this.guna2PictureBox11.ImageRotate = 0F;
            this.guna2PictureBox11.Location = new System.Drawing.Point(655, 329);
            this.guna2PictureBox11.Name = "guna2PictureBox11";
            this.guna2PictureBox11.Size = new System.Drawing.Size(439, 378);
            this.guna2PictureBox11.TabIndex = 0;
            this.guna2PictureBox11.TabStop = false;
            // 
            // btnOur_Location_HomePage
            // 
            this.btnOur_Location_HomePage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnOur_Location_HomePage.BorderRadius = 17;
            this.btnOur_Location_HomePage.BorderThickness = 1;
            this.btnOur_Location_HomePage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOur_Location_HomePage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOur_Location_HomePage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOur_Location_HomePage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOur_Location_HomePage.FillColor = System.Drawing.Color.Transparent;
            this.btnOur_Location_HomePage.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOur_Location_HomePage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnOur_Location_HomePage.Location = new System.Drawing.Point(655, 279);
            this.btnOur_Location_HomePage.Name = "btnOur_Location_HomePage";
            this.btnOur_Location_HomePage.Size = new System.Drawing.Size(180, 33);
            this.btnOur_Location_HomePage.TabIndex = 5;
            this.btnOur_Location_HomePage.Text = "Our Location";
            this.btnOur_Location_HomePage.TextOffset = new System.Drawing.Point(0, -3);
            this.btnOur_Location_HomePage.Click += new System.EventHandler(this.btnOur_Location_HomePage_Click);
            // 
            // guna2PictureBox10
            // 
            this.guna2PictureBox10.BorderRadius = 40;
            this.guna2PictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox10.Image")));
            this.guna2PictureBox10.ImageRotate = 0F;
            this.guna2PictureBox10.Location = new System.Drawing.Point(40, 138);
            this.guna2PictureBox10.Name = "guna2PictureBox10";
            this.guna2PictureBox10.Size = new System.Drawing.Size(587, 584);
            this.guna2PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox10.TabIndex = 0;
            this.guna2PictureBox10.TabStop = false;
            // 
            // guna2HtmlLabel19
            // 
            this.guna2HtmlLabel19.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel19.Location = new System.Drawing.Point(655, 237);
            this.guna2HtmlLabel19.Name = "guna2HtmlLabel19";
            this.guna2HtmlLabel19.Size = new System.Drawing.Size(300, 27);
            this.guna2HtmlLabel19.TabIndex = 3;
            this.guna2HtmlLabel19.Text = "Ready to serve you at any time";
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(655, 205);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(445, 27);
            this.guna2HtmlLabel10.TabIndex = 3;
            this.guna2HtmlLabel10.Text = "We have hundreds of stores around the world. ";
            // 
            // guna2HtmlLabel18
            // 
            this.guna2HtmlLabel18.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel18.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel18.Location = new System.Drawing.Point(655, 141);
            this.guna2HtmlLabel18.Name = "guna2HtmlLabel18";
            this.guna2HtmlLabel18.Size = new System.Drawing.Size(227, 75);
            this.guna2HtmlLabel18.TabIndex = 2;
            this.guna2HtmlLabel18.Text = "Visit Us";
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel6.BorderRadius = 30;
            this.guna2Panel6.Controls.Add(this.ptbImage_BestSeller_Top1);
            this.guna2Panel6.Controls.Add(this.guna2Panel14);
            this.guna2Panel6.Controls.Add(this.lblReviews_BestSeller_Top1);
            this.guna2Panel6.Controls.Add(this.lblRate_BestSeller_Top1);
            this.guna2Panel6.Controls.Add(this.guna2PictureBox8);
            this.guna2Panel6.Controls.Add(this.lblName_BestSeller_Top1);
            this.guna2Panel6.Controls.Add(this.lblDescribe_BestSeller_Top1);
            this.guna2Panel6.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel6.Location = new System.Drawing.Point(6, 55);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.Size = new System.Drawing.Size(250, 279);
            this.guna2Panel6.TabIndex = 0;
            // 
            // ptbImage_BestSeller_Top1
            // 
            this.ptbImage_BestSeller_Top1.ImageRotate = 0F;
            this.ptbImage_BestSeller_Top1.Location = new System.Drawing.Point(0, 16);
            this.ptbImage_BestSeller_Top1.Name = "ptbImage_BestSeller_Top1";
            this.ptbImage_BestSeller_Top1.Size = new System.Drawing.Size(250, 147);
            this.ptbImage_BestSeller_Top1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbImage_BestSeller_Top1.TabIndex = 6;
            this.ptbImage_BestSeller_Top1.TabStop = false;
            // 
            // guna2Panel14
            // 
            this.guna2Panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel14.Location = new System.Drawing.Point(26, 168);
            this.guna2Panel14.Name = "guna2Panel14";
            this.guna2Panel14.Size = new System.Drawing.Size(200, 3);
            this.guna2Panel14.TabIndex = 2;
            // 
            // lblReviews_BestSeller_Top1
            // 
            this.lblReviews_BestSeller_Top1.BackColor = System.Drawing.Color.Transparent;
            this.lblReviews_BestSeller_Top1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReviews_BestSeller_Top1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblReviews_BestSeller_Top1.Location = new System.Drawing.Point(130, 218);
            this.lblReviews_BestSeller_Top1.Name = "lblReviews_BestSeller_Top1";
            this.lblReviews_BestSeller_Top1.Size = new System.Drawing.Size(90, 18);
            this.lblReviews_BestSeller_Top1.TabIndex = 1;
            this.lblReviews_BestSeller_Top1.Text = "126 Reviews";
            // 
            // lblRate_BestSeller_Top1
            // 
            this.lblRate_BestSeller_Top1.BackColor = System.Drawing.Color.Transparent;
            this.lblRate_BestSeller_Top1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate_BestSeller_Top1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblRate_BestSeller_Top1.Location = new System.Drawing.Point(24, 214);
            this.lblRate_BestSeller_Top1.Name = "lblRate_BestSeller_Top1";
            this.lblRate_BestSeller_Top1.Size = new System.Drawing.Size(28, 22);
            this.lblRate_BestSeller_Top1.TabIndex = 1;
            this.lblRate_BestSeller_Top1.Text = "5.0";
            // 
            // guna2PictureBox8
            // 
            this.guna2PictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox8.Image")));
            this.guna2PictureBox8.ImageRotate = 0F;
            this.guna2PictureBox8.Location = new System.Drawing.Point(48, 216);
            this.guna2PictureBox8.Name = "guna2PictureBox8";
            this.guna2PictureBox8.Size = new System.Drawing.Size(32, 17);
            this.guna2PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox8.TabIndex = 4;
            this.guna2PictureBox8.TabStop = false;
            // 
            // lblName_BestSeller_Top1
            // 
            this.lblName_BestSeller_Top1.BackColor = System.Drawing.Color.Transparent;
            this.lblName_BestSeller_Top1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName_BestSeller_Top1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblName_BestSeller_Top1.Location = new System.Drawing.Point(24, 171);
            this.lblName_BestSeller_Top1.Name = "lblName_BestSeller_Top1";
            this.lblName_BestSeller_Top1.Size = new System.Drawing.Size(146, 26);
            this.lblName_BestSeller_Top1.TabIndex = 1;
            this.lblName_BestSeller_Top1.Text = "Morning Coffee";
            // 
            // lblDescribe_BestSeller_Top1
            // 
            this.lblDescribe_BestSeller_Top1.BackColor = System.Drawing.Color.Transparent;
            this.lblDescribe_BestSeller_Top1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescribe_BestSeller_Top1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblDescribe_BestSeller_Top1.Location = new System.Drawing.Point(24, 196);
            this.lblDescribe_BestSeller_Top1.Name = "lblDescribe_BestSeller_Top1";
            this.lblDescribe_BestSeller_Top1.Size = new System.Drawing.Size(83, 18);
            this.lblDescribe_BestSeller_Top1.TabIndex = 1;
            this.lblDescribe_BestSeller_Top1.Text = "Best Coffee";
            // 
            // guna2Panel8
            // 
            this.guna2Panel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel8.BorderRadius = 30;
            this.guna2Panel8.Controls.Add(this.ptbImage_BestSeller_Top3);
            this.guna2Panel8.Controls.Add(this.guna2Panel54);
            this.guna2Panel8.Controls.Add(this.lblName_BestSeller_Top3);
            this.guna2Panel8.Controls.Add(this.guna2PictureBox24);
            this.guna2Panel8.Controls.Add(this.lblRate_BestSeller_Top3);
            this.guna2Panel8.Controls.Add(this.lblReviews_BestSeller_Top3);
            this.guna2Panel8.Controls.Add(this.lblDescribe_BestSeller_Top3);
            this.guna2Panel8.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel8.Location = new System.Drawing.Point(534, 54);
            this.guna2Panel8.Name = "guna2Panel8";
            this.guna2Panel8.Size = new System.Drawing.Size(250, 280);
            this.guna2Panel8.TabIndex = 0;
            // 
            // ptbImage_BestSeller_Top3
            // 
            this.ptbImage_BestSeller_Top3.ImageRotate = 0F;
            this.ptbImage_BestSeller_Top3.Location = new System.Drawing.Point(3, 17);
            this.ptbImage_BestSeller_Top3.Name = "ptbImage_BestSeller_Top3";
            this.ptbImage_BestSeller_Top3.Size = new System.Drawing.Size(250, 147);
            this.ptbImage_BestSeller_Top3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbImage_BestSeller_Top3.TabIndex = 6;
            this.ptbImage_BestSeller_Top3.TabStop = false;
            // 
            // guna2Panel54
            // 
            this.guna2Panel54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel54.Location = new System.Drawing.Point(28, 169);
            this.guna2Panel54.Name = "guna2Panel54";
            this.guna2Panel54.Size = new System.Drawing.Size(200, 3);
            this.guna2Panel54.TabIndex = 2;
            // 
            // lblName_BestSeller_Top3
            // 
            this.lblName_BestSeller_Top3.BackColor = System.Drawing.Color.Transparent;
            this.lblName_BestSeller_Top3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName_BestSeller_Top3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblName_BestSeller_Top3.Location = new System.Drawing.Point(26, 172);
            this.lblName_BestSeller_Top3.Name = "lblName_BestSeller_Top3";
            this.lblName_BestSeller_Top3.Size = new System.Drawing.Size(146, 26);
            this.lblName_BestSeller_Top3.TabIndex = 1;
            this.lblName_BestSeller_Top3.Text = "Morning Coffee";
            // 
            // guna2PictureBox24
            // 
            this.guna2PictureBox24.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox24.Image")));
            this.guna2PictureBox24.ImageRotate = 0F;
            this.guna2PictureBox24.Location = new System.Drawing.Point(52, 217);
            this.guna2PictureBox24.Name = "guna2PictureBox24";
            this.guna2PictureBox24.Size = new System.Drawing.Size(32, 17);
            this.guna2PictureBox24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox24.TabIndex = 4;
            this.guna2PictureBox24.TabStop = false;
            // 
            // lblRate_BestSeller_Top3
            // 
            this.lblRate_BestSeller_Top3.BackColor = System.Drawing.Color.Transparent;
            this.lblRate_BestSeller_Top3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate_BestSeller_Top3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblRate_BestSeller_Top3.Location = new System.Drawing.Point(26, 215);
            this.lblRate_BestSeller_Top3.Name = "lblRate_BestSeller_Top3";
            this.lblRate_BestSeller_Top3.Size = new System.Drawing.Size(28, 22);
            this.lblRate_BestSeller_Top3.TabIndex = 1;
            this.lblRate_BestSeller_Top3.Text = "5.0";
            // 
            // lblReviews_BestSeller_Top3
            // 
            this.lblReviews_BestSeller_Top3.BackColor = System.Drawing.Color.Transparent;
            this.lblReviews_BestSeller_Top3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReviews_BestSeller_Top3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblReviews_BestSeller_Top3.Location = new System.Drawing.Point(132, 219);
            this.lblReviews_BestSeller_Top3.Name = "lblReviews_BestSeller_Top3";
            this.lblReviews_BestSeller_Top3.Size = new System.Drawing.Size(90, 18);
            this.lblReviews_BestSeller_Top3.TabIndex = 1;
            this.lblReviews_BestSeller_Top3.Text = "126 Reviews";
            // 
            // lblDescribe_BestSeller_Top3
            // 
            this.lblDescribe_BestSeller_Top3.BackColor = System.Drawing.Color.Transparent;
            this.lblDescribe_BestSeller_Top3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescribe_BestSeller_Top3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblDescribe_BestSeller_Top3.Location = new System.Drawing.Point(26, 197);
            this.lblDescribe_BestSeller_Top3.Name = "lblDescribe_BestSeller_Top3";
            this.lblDescribe_BestSeller_Top3.Size = new System.Drawing.Size(83, 18);
            this.lblDescribe_BestSeller_Top3.TabIndex = 1;
            this.lblDescribe_BestSeller_Top3.Text = "Best Coffee";
            // 
            // guna2Panel7
            // 
            this.guna2Panel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel7.BorderRadius = 30;
            this.guna2Panel7.Controls.Add(this.ptbImage_BestSeller_Top2);
            this.guna2Panel7.Controls.Add(this.guna2Panel15);
            this.guna2Panel7.Controls.Add(this.lblName_BestSeller_Top2);
            this.guna2Panel7.Controls.Add(this.lblReviews_BestSeller_Top2);
            this.guna2Panel7.Controls.Add(this.lblDescribe_BestSeller_Top2);
            this.guna2Panel7.Controls.Add(this.lblRate_BestSeller_Top2);
            this.guna2Panel7.Controls.Add(this.guna2PictureBox23);
            this.guna2Panel7.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel7.Location = new System.Drawing.Point(270, 54);
            this.guna2Panel7.Name = "guna2Panel7";
            this.guna2Panel7.Size = new System.Drawing.Size(250, 280);
            this.guna2Panel7.TabIndex = 0;
            // 
            // ptbImage_BestSeller_Top2
            // 
            this.ptbImage_BestSeller_Top2.ImageRotate = 0F;
            this.ptbImage_BestSeller_Top2.Location = new System.Drawing.Point(0, 17);
            this.ptbImage_BestSeller_Top2.Name = "ptbImage_BestSeller_Top2";
            this.ptbImage_BestSeller_Top2.Size = new System.Drawing.Size(250, 147);
            this.ptbImage_BestSeller_Top2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbImage_BestSeller_Top2.TabIndex = 6;
            this.ptbImage_BestSeller_Top2.TabStop = false;
            // 
            // guna2Panel15
            // 
            this.guna2Panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel15.Location = new System.Drawing.Point(26, 169);
            this.guna2Panel15.Name = "guna2Panel15";
            this.guna2Panel15.Size = new System.Drawing.Size(200, 3);
            this.guna2Panel15.TabIndex = 2;
            // 
            // lblName_BestSeller_Top2
            // 
            this.lblName_BestSeller_Top2.BackColor = System.Drawing.Color.Transparent;
            this.lblName_BestSeller_Top2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName_BestSeller_Top2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblName_BestSeller_Top2.Location = new System.Drawing.Point(24, 172);
            this.lblName_BestSeller_Top2.Name = "lblName_BestSeller_Top2";
            this.lblName_BestSeller_Top2.Size = new System.Drawing.Size(146, 26);
            this.lblName_BestSeller_Top2.TabIndex = 1;
            this.lblName_BestSeller_Top2.Text = "Morning Coffee";
            // 
            // lblReviews_BestSeller_Top2
            // 
            this.lblReviews_BestSeller_Top2.BackColor = System.Drawing.Color.Transparent;
            this.lblReviews_BestSeller_Top2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReviews_BestSeller_Top2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblReviews_BestSeller_Top2.Location = new System.Drawing.Point(130, 219);
            this.lblReviews_BestSeller_Top2.Name = "lblReviews_BestSeller_Top2";
            this.lblReviews_BestSeller_Top2.Size = new System.Drawing.Size(90, 18);
            this.lblReviews_BestSeller_Top2.TabIndex = 1;
            this.lblReviews_BestSeller_Top2.Text = "126 Reviews";
            // 
            // lblDescribe_BestSeller_Top2
            // 
            this.lblDescribe_BestSeller_Top2.BackColor = System.Drawing.Color.Transparent;
            this.lblDescribe_BestSeller_Top2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescribe_BestSeller_Top2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblDescribe_BestSeller_Top2.Location = new System.Drawing.Point(24, 197);
            this.lblDescribe_BestSeller_Top2.Name = "lblDescribe_BestSeller_Top2";
            this.lblDescribe_BestSeller_Top2.Size = new System.Drawing.Size(83, 18);
            this.lblDescribe_BestSeller_Top2.TabIndex = 1;
            this.lblDescribe_BestSeller_Top2.Text = "Best Coffee";
            // 
            // lblRate_BestSeller_Top2
            // 
            this.lblRate_BestSeller_Top2.BackColor = System.Drawing.Color.Transparent;
            this.lblRate_BestSeller_Top2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate_BestSeller_Top2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblRate_BestSeller_Top2.Location = new System.Drawing.Point(24, 215);
            this.lblRate_BestSeller_Top2.Name = "lblRate_BestSeller_Top2";
            this.lblRate_BestSeller_Top2.Size = new System.Drawing.Size(28, 22);
            this.lblRate_BestSeller_Top2.TabIndex = 1;
            this.lblRate_BestSeller_Top2.Text = "5.0";
            // 
            // guna2PictureBox23
            // 
            this.guna2PictureBox23.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox23.Image")));
            this.guna2PictureBox23.ImageRotate = 0F;
            this.guna2PictureBox23.Location = new System.Drawing.Point(48, 217);
            this.guna2PictureBox23.Name = "guna2PictureBox23";
            this.guna2PictureBox23.Size = new System.Drawing.Size(32, 17);
            this.guna2PictureBox23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox23.TabIndex = 4;
            this.guna2PictureBox23.TabStop = false;
            // 
            // guna2HtmlLabel16
            // 
            this.guna2HtmlLabel16.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel16.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel16.Location = new System.Drawing.Point(19, 300);
            this.guna2HtmlLabel16.Name = "guna2HtmlLabel16";
            this.guna2HtmlLabel16.Size = new System.Drawing.Size(493, 52);
            this.guna2HtmlLabel16.TabIndex = 3;
            this.guna2HtmlLabel16.Text = "Enjoy your hot coffee now";
            // 
            // guna2HtmlLabel17
            // 
            this.guna2HtmlLabel17.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel17.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel17.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel17.Location = new System.Drawing.Point(20, 665);
            this.guna2HtmlLabel17.Name = "guna2HtmlLabel17";
            this.guna2HtmlLabel17.Size = new System.Drawing.Size(151, 41);
            this.guna2HtmlLabel17.TabIndex = 3;
            this.guna2HtmlLabel17.Text = "Visit Shop";
            // 
            // guna2HtmlLabel15
            // 
            this.guna2HtmlLabel15.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel15.Font = new System.Drawing.Font("Microsoft YaHei UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel15.Location = new System.Drawing.Point(19, 253);
            this.guna2HtmlLabel15.Name = "guna2HtmlLabel15";
            this.guna2HtmlLabel15.Size = new System.Drawing.Size(341, 52);
            this.guna2HtmlLabel15.TabIndex = 3;
            this.guna2HtmlLabel15.Text = "Pick up the phone ";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(19, 155);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(360, 92);
            this.guna2HtmlLabel1.TabIndex = 3;
            this.guna2HtmlLabel1.Text = "ABOUT US";
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox3.Image")));
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(991, 120);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(81, 86);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox3.TabIndex = 1;
            this.guna2PictureBox3.TabStop = false;
            this.guna2PictureBox3.UseTransparentBackground = true;
            this.guna2PictureBox3.Click += new System.EventHandler(this.guna2PictureBox3_Click);
            // 
            // guna2Panel12
            // 
            this.guna2Panel12.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel12.BorderRadius = 25;
            this.guna2Panel12.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2Panel12.Location = new System.Drawing.Point(907, 585);
            this.guna2Panel12.Name = "guna2Panel12";
            this.guna2Panel12.Size = new System.Drawing.Size(42, 50);
            this.guna2Panel12.TabIndex = 2;
            // 
            // guna2Panel10
            // 
            this.guna2Panel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel10.BorderRadius = 25;
            this.guna2Panel10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(230)))), ((int)(((byte)(187)))));
            this.guna2Panel10.Location = new System.Drawing.Point(1066, 298);
            this.guna2Panel10.Name = "guna2Panel10";
            this.guna2Panel10.Size = new System.Drawing.Size(42, 50);
            this.guna2Panel10.TabIndex = 2;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BorderRadius = 25;
            this.guna2Panel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(81)))), ((int)(((byte)(42)))));
            this.guna2Panel4.Location = new System.Drawing.Point(1011, 137);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(42, 50);
            this.guna2Panel4.TabIndex = 2;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(855, 26);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(87, 68);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 1;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(518, 109);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(501, 475);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.BorderRadius = 20;
            this.guna2Panel9.Controls.Add(this.guna2HtmlLabel6);
            this.guna2Panel9.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(220)))), ((int)(((byte)(195)))));
            this.guna2Panel9.Location = new System.Drawing.Point(0, 778);
            this.guna2Panel9.Name = "guna2Panel9";
            this.guna2Panel9.Size = new System.Drawing.Size(208, 61);
            this.guna2Panel9.TabIndex = 5;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(22, 0);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(156, 27);
            this.guna2HtmlLabel6.TabIndex = 1;
            this.guna2HtmlLabel6.Text = "BEST SELLER";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.tabPage2.Controls.Add(this.guna2Panel44);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1163, 721);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // guna2Panel44
            // 
            this.guna2Panel44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.guna2Panel44.Controls.Add(this.flpCategories);
            this.guna2Panel44.Controls.Add(this.guna2PictureBox15);
            this.guna2Panel44.Controls.Add(this.flowLayoutPanel1);
            this.guna2Panel44.Controls.Add(this.guna2PictureBox16);
            this.guna2Panel44.Controls.Add(this.guna2Panel3);
            this.guna2Panel44.Controls.Add(this.guna2Panel26);
            this.guna2Panel44.Controls.Add(this.label7);
            this.guna2Panel44.Controls.Add(this.guna2Panel25);
            this.guna2Panel44.Controls.Add(this.label8);
            this.guna2Panel44.Controls.Add(this.label9);
            this.guna2Panel44.Controls.Add(this.guna2Panel24);
            this.guna2Panel44.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel44.Name = "guna2Panel44";
            this.guna2Panel44.Size = new System.Drawing.Size(1167, 2100);
            this.guna2Panel44.TabIndex = 6;
            // 
            // flpCategories
            // 
            this.flpCategories.Controls.Add(this.btnAll);
            this.flpCategories.Location = new System.Drawing.Point(6, 637);
            this.flpCategories.Name = "flpCategories";
            this.flpCategories.Size = new System.Drawing.Size(1145, 50);
            this.flpCategories.TabIndex = 6;
            // 
            // btnAll
            // 
            this.btnAll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnAll.BorderRadius = 20;
            this.btnAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Location = new System.Drawing.Point(8, 3);
            this.btnAll.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(180, 45);
            this.btnAll.TabIndex = 3;
            this.btnAll.Text = "ALL";
            // 
            // guna2PictureBox15
            // 
            this.guna2PictureBox15.BorderRadius = 45;
            this.guna2PictureBox15.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox15.Image")));
            this.guna2PictureBox15.ImageRotate = 0F;
            this.guna2PictureBox15.Location = new System.Drawing.Point(20, 139);
            this.guna2PictureBox15.Name = "guna2PictureBox15";
            this.guna2PictureBox15.Size = new System.Drawing.Size(771, 306);
            this.guna2PictureBox15.TabIndex = 1;
            this.guna2PictureBox15.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel27);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel28);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel29);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel30);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel31);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel32);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel33);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel34);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel35);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel36);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel37);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel38);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel39);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel40);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel41);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel42);
            this.flowLayoutPanel1.Controls.Add(this.guna2Panel43);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 702);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1140, 1370);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // guna2Panel27
            // 
            this.guna2Panel27.Controls.Add(this.uC_product1);
            this.guna2Panel27.Location = new System.Drawing.Point(17, 17);
            this.guna2Panel27.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel27.Name = "guna2Panel27";
            this.guna2Panel27.Size = new System.Drawing.Size(250, 294);
            this.guna2Panel27.TabIndex = 0;
            // 
            // uC_product1
            // 
            this.uC_product1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product1.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product1.BTNReviews_Drinks = resources.GetString("uC_product1.BTNReviews_Drinks");
            this.uC_product1.Categories = null;
            this.uC_product1.ID = null;
            this.uC_product1.LBLDescribe_Drinks = "";
            this.uC_product1.LBLName_Drinks = null;
            this.uC_product1.LBLRate_Drinks = "";
            this.uC_product1.Location = new System.Drawing.Point(0, 0);
            this.uC_product1.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product1.Name = "uC_product1";
            this.uC_product1.PTBImage_Drinks = null;
            this.uC_product1.Size = new System.Drawing.Size(250, 294);
            this.uC_product1.TabIndex = 0;
            // 
            // guna2Panel28
            // 
            this.guna2Panel28.Controls.Add(this.uC_product2);
            this.guna2Panel28.Location = new System.Drawing.Point(301, 17);
            this.guna2Panel28.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel28.Name = "guna2Panel28";
            this.guna2Panel28.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel28.TabIndex = 0;
            // 
            // uC_product2
            // 
            this.uC_product2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product2.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product2.BTNReviews_Drinks = resources.GetString("uC_product2.BTNReviews_Drinks");
            this.uC_product2.Categories = null;
            this.uC_product2.ID = null;
            this.uC_product2.LBLDescribe_Drinks = "";
            this.uC_product2.LBLName_Drinks = null;
            this.uC_product2.LBLRate_Drinks = "";
            this.uC_product2.Location = new System.Drawing.Point(0, 0);
            this.uC_product2.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product2.Name = "uC_product2";
            this.uC_product2.PTBImage_Drinks = null;
            this.uC_product2.Size = new System.Drawing.Size(250, 294);
            this.uC_product2.TabIndex = 0;
            // 
            // guna2Panel29
            // 
            this.guna2Panel29.Controls.Add(this.uC_product3);
            this.guna2Panel29.Location = new System.Drawing.Point(585, 17);
            this.guna2Panel29.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel29.Name = "guna2Panel29";
            this.guna2Panel29.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel29.TabIndex = 0;
            // 
            // uC_product3
            // 
            this.uC_product3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product3.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product3.BTNReviews_Drinks = resources.GetString("uC_product3.BTNReviews_Drinks");
            this.uC_product3.Categories = null;
            this.uC_product3.ID = null;
            this.uC_product3.LBLDescribe_Drinks = "";
            this.uC_product3.LBLName_Drinks = null;
            this.uC_product3.LBLRate_Drinks = "";
            this.uC_product3.Location = new System.Drawing.Point(0, 0);
            this.uC_product3.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product3.Name = "uC_product3";
            this.uC_product3.PTBImage_Drinks = null;
            this.uC_product3.Size = new System.Drawing.Size(250, 294);
            this.uC_product3.TabIndex = 0;
            // 
            // guna2Panel30
            // 
            this.guna2Panel30.Controls.Add(this.uC_product4);
            this.guna2Panel30.Location = new System.Drawing.Point(869, 17);
            this.guna2Panel30.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel30.Name = "guna2Panel30";
            this.guna2Panel30.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel30.TabIndex = 0;
            // 
            // uC_product4
            // 
            this.uC_product4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product4.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product4.BTNReviews_Drinks = resources.GetString("uC_product4.BTNReviews_Drinks");
            this.uC_product4.Categories = null;
            this.uC_product4.ID = null;
            this.uC_product4.LBLDescribe_Drinks = "";
            this.uC_product4.LBLName_Drinks = null;
            this.uC_product4.LBLRate_Drinks = "";
            this.uC_product4.Location = new System.Drawing.Point(0, 0);
            this.uC_product4.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product4.Name = "uC_product4";
            this.uC_product4.PTBImage_Drinks = null;
            this.uC_product4.Size = new System.Drawing.Size(250, 294);
            this.uC_product4.TabIndex = 0;
            // 
            // guna2Panel31
            // 
            this.guna2Panel31.Controls.Add(this.uC_product5);
            this.guna2Panel31.Location = new System.Drawing.Point(17, 345);
            this.guna2Panel31.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel31.Name = "guna2Panel31";
            this.guna2Panel31.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel31.TabIndex = 0;
            // 
            // uC_product5
            // 
            this.uC_product5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product5.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product5.BTNReviews_Drinks = resources.GetString("uC_product5.BTNReviews_Drinks");
            this.uC_product5.Categories = null;
            this.uC_product5.ID = null;
            this.uC_product5.LBLDescribe_Drinks = "";
            this.uC_product5.LBLName_Drinks = null;
            this.uC_product5.LBLRate_Drinks = "";
            this.uC_product5.Location = new System.Drawing.Point(1, 0);
            this.uC_product5.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product5.Name = "uC_product5";
            this.uC_product5.PTBImage_Drinks = null;
            this.uC_product5.Size = new System.Drawing.Size(250, 294);
            this.uC_product5.TabIndex = 0;
            // 
            // guna2Panel32
            // 
            this.guna2Panel32.Controls.Add(this.uC_product6);
            this.guna2Panel32.Location = new System.Drawing.Point(301, 345);
            this.guna2Panel32.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel32.Name = "guna2Panel32";
            this.guna2Panel32.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel32.TabIndex = 0;
            // 
            // uC_product6
            // 
            this.uC_product6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product6.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product6.BTNReviews_Drinks = resources.GetString("uC_product6.BTNReviews_Drinks");
            this.uC_product6.Categories = null;
            this.uC_product6.ID = null;
            this.uC_product6.LBLDescribe_Drinks = "";
            this.uC_product6.LBLName_Drinks = null;
            this.uC_product6.LBLRate_Drinks = "";
            this.uC_product6.Location = new System.Drawing.Point(-1, 0);
            this.uC_product6.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product6.Name = "uC_product6";
            this.uC_product6.PTBImage_Drinks = null;
            this.uC_product6.Size = new System.Drawing.Size(250, 294);
            this.uC_product6.TabIndex = 0;
            // 
            // guna2Panel33
            // 
            this.guna2Panel33.Controls.Add(this.uC_product7);
            this.guna2Panel33.Location = new System.Drawing.Point(585, 345);
            this.guna2Panel33.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel33.Name = "guna2Panel33";
            this.guna2Panel33.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel33.TabIndex = 0;
            // 
            // uC_product7
            // 
            this.uC_product7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product7.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product7.BTNReviews_Drinks = resources.GetString("uC_product7.BTNReviews_Drinks");
            this.uC_product7.Categories = null;
            this.uC_product7.ID = null;
            this.uC_product7.LBLDescribe_Drinks = "";
            this.uC_product7.LBLName_Drinks = null;
            this.uC_product7.LBLRate_Drinks = "";
            this.uC_product7.Location = new System.Drawing.Point(-1, -4);
            this.uC_product7.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product7.Name = "uC_product7";
            this.uC_product7.PTBImage_Drinks = null;
            this.uC_product7.Size = new System.Drawing.Size(250, 294);
            this.uC_product7.TabIndex = 0;
            // 
            // guna2Panel34
            // 
            this.guna2Panel34.Controls.Add(this.uC_product8);
            this.guna2Panel34.Location = new System.Drawing.Point(869, 345);
            this.guna2Panel34.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel34.Name = "guna2Panel34";
            this.guna2Panel34.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel34.TabIndex = 0;
            // 
            // uC_product8
            // 
            this.uC_product8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product8.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product8.BTNReviews_Drinks = resources.GetString("uC_product8.BTNReviews_Drinks");
            this.uC_product8.Categories = null;
            this.uC_product8.ID = null;
            this.uC_product8.LBLDescribe_Drinks = "";
            this.uC_product8.LBLName_Drinks = null;
            this.uC_product8.LBLRate_Drinks = "";
            this.uC_product8.Location = new System.Drawing.Point(0, -4);
            this.uC_product8.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product8.Name = "uC_product8";
            this.uC_product8.PTBImage_Drinks = null;
            this.uC_product8.Size = new System.Drawing.Size(250, 294);
            this.uC_product8.TabIndex = 0;
            // 
            // guna2Panel35
            // 
            this.guna2Panel35.Controls.Add(this.uC_product9);
            this.guna2Panel35.Location = new System.Drawing.Point(17, 669);
            this.guna2Panel35.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel35.Name = "guna2Panel35";
            this.guna2Panel35.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel35.TabIndex = 1;
            // 
            // uC_product9
            // 
            this.uC_product9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product9.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product9.BTNReviews_Drinks = resources.GetString("uC_product9.BTNReviews_Drinks");
            this.uC_product9.Categories = null;
            this.uC_product9.ID = null;
            this.uC_product9.LBLDescribe_Drinks = "";
            this.uC_product9.LBLName_Drinks = null;
            this.uC_product9.LBLRate_Drinks = "";
            this.uC_product9.Location = new System.Drawing.Point(0, -4);
            this.uC_product9.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product9.Name = "uC_product9";
            this.uC_product9.PTBImage_Drinks = null;
            this.uC_product9.Size = new System.Drawing.Size(250, 294);
            this.uC_product9.TabIndex = 0;
            // 
            // guna2Panel36
            // 
            this.guna2Panel36.Controls.Add(this.uC_product10);
            this.guna2Panel36.Location = new System.Drawing.Point(301, 669);
            this.guna2Panel36.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel36.Name = "guna2Panel36";
            this.guna2Panel36.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel36.TabIndex = 2;
            // 
            // uC_product10
            // 
            this.uC_product10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product10.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product10.BTNReviews_Drinks = resources.GetString("uC_product10.BTNReviews_Drinks");
            this.uC_product10.Categories = null;
            this.uC_product10.ID = null;
            this.uC_product10.LBLDescribe_Drinks = "";
            this.uC_product10.LBLName_Drinks = null;
            this.uC_product10.LBLRate_Drinks = "";
            this.uC_product10.Location = new System.Drawing.Point(1, 0);
            this.uC_product10.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product10.Name = "uC_product10";
            this.uC_product10.PTBImage_Drinks = null;
            this.uC_product10.Size = new System.Drawing.Size(250, 294);
            this.uC_product10.TabIndex = 0;
            // 
            // guna2Panel37
            // 
            this.guna2Panel37.Controls.Add(this.uC_product11);
            this.guna2Panel37.Location = new System.Drawing.Point(585, 669);
            this.guna2Panel37.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel37.Name = "guna2Panel37";
            this.guna2Panel37.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel37.TabIndex = 3;
            // 
            // uC_product11
            // 
            this.uC_product11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product11.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product11.BTNReviews_Drinks = resources.GetString("uC_product11.BTNReviews_Drinks");
            this.uC_product11.Categories = null;
            this.uC_product11.ID = null;
            this.uC_product11.LBLDescribe_Drinks = "";
            this.uC_product11.LBLName_Drinks = null;
            this.uC_product11.LBLRate_Drinks = "";
            this.uC_product11.Location = new System.Drawing.Point(0, 0);
            this.uC_product11.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product11.Name = "uC_product11";
            this.uC_product11.PTBImage_Drinks = null;
            this.uC_product11.Size = new System.Drawing.Size(250, 294);
            this.uC_product11.TabIndex = 0;
            // 
            // guna2Panel38
            // 
            this.guna2Panel38.Controls.Add(this.uC_product12);
            this.guna2Panel38.Location = new System.Drawing.Point(869, 669);
            this.guna2Panel38.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel38.Name = "guna2Panel38";
            this.guna2Panel38.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel38.TabIndex = 4;
            // 
            // uC_product12
            // 
            this.uC_product12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product12.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product12.BTNReviews_Drinks = resources.GetString("uC_product12.BTNReviews_Drinks");
            this.uC_product12.Categories = null;
            this.uC_product12.ID = null;
            this.uC_product12.LBLDescribe_Drinks = "";
            this.uC_product12.LBLName_Drinks = null;
            this.uC_product12.LBLRate_Drinks = "";
            this.uC_product12.Location = new System.Drawing.Point(0, 0);
            this.uC_product12.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product12.Name = "uC_product12";
            this.uC_product12.PTBImage_Drinks = null;
            this.uC_product12.Size = new System.Drawing.Size(250, 294);
            this.uC_product12.TabIndex = 0;
            // 
            // guna2Panel39
            // 
            this.guna2Panel39.Controls.Add(this.uC_product13);
            this.guna2Panel39.Location = new System.Drawing.Point(17, 993);
            this.guna2Panel39.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel39.Name = "guna2Panel39";
            this.guna2Panel39.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel39.TabIndex = 5;
            // 
            // uC_product13
            // 
            this.uC_product13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product13.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product13.BTNReviews_Drinks = resources.GetString("uC_product13.BTNReviews_Drinks");
            this.uC_product13.Categories = null;
            this.uC_product13.ID = null;
            this.uC_product13.LBLDescribe_Drinks = "";
            this.uC_product13.LBLName_Drinks = null;
            this.uC_product13.LBLRate_Drinks = "";
            this.uC_product13.Location = new System.Drawing.Point(0, 0);
            this.uC_product13.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product13.Name = "uC_product13";
            this.uC_product13.PTBImage_Drinks = null;
            this.uC_product13.Size = new System.Drawing.Size(250, 294);
            this.uC_product13.TabIndex = 0;
            // 
            // guna2Panel40
            // 
            this.guna2Panel40.Controls.Add(this.uC_product14);
            this.guna2Panel40.Location = new System.Drawing.Point(301, 993);
            this.guna2Panel40.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel40.Name = "guna2Panel40";
            this.guna2Panel40.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel40.TabIndex = 6;
            // 
            // uC_product14
            // 
            this.uC_product14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product14.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product14.BTNReviews_Drinks = resources.GetString("uC_product14.BTNReviews_Drinks");
            this.uC_product14.Categories = null;
            this.uC_product14.ID = null;
            this.uC_product14.LBLDescribe_Drinks = "";
            this.uC_product14.LBLName_Drinks = null;
            this.uC_product14.LBLRate_Drinks = "";
            this.uC_product14.Location = new System.Drawing.Point(0, 0);
            this.uC_product14.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product14.Name = "uC_product14";
            this.uC_product14.PTBImage_Drinks = null;
            this.uC_product14.Size = new System.Drawing.Size(250, 294);
            this.uC_product14.TabIndex = 0;
            // 
            // guna2Panel41
            // 
            this.guna2Panel41.Controls.Add(this.uC_product15);
            this.guna2Panel41.Location = new System.Drawing.Point(585, 993);
            this.guna2Panel41.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel41.Name = "guna2Panel41";
            this.guna2Panel41.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel41.TabIndex = 7;
            // 
            // uC_product15
            // 
            this.uC_product15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product15.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product15.BTNReviews_Drinks = resources.GetString("uC_product15.BTNReviews_Drinks");
            this.uC_product15.Categories = null;
            this.uC_product15.ID = null;
            this.uC_product15.LBLDescribe_Drinks = "";
            this.uC_product15.LBLName_Drinks = null;
            this.uC_product15.LBLRate_Drinks = "";
            this.uC_product15.Location = new System.Drawing.Point(-1, 0);
            this.uC_product15.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product15.Name = "uC_product15";
            this.uC_product15.PTBImage_Drinks = null;
            this.uC_product15.Size = new System.Drawing.Size(250, 294);
            this.uC_product15.TabIndex = 0;
            // 
            // guna2Panel42
            // 
            this.guna2Panel42.Controls.Add(this.uC_product16);
            this.guna2Panel42.Location = new System.Drawing.Point(869, 993);
            this.guna2Panel42.Margin = new System.Windows.Forms.Padding(17);
            this.guna2Panel42.Name = "guna2Panel42";
            this.guna2Panel42.Size = new System.Drawing.Size(250, 290);
            this.guna2Panel42.TabIndex = 8;
            // 
            // uC_product16
            // 
            this.uC_product16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.uC_product16.BTNPrice = "đđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđđ" +
    "đđđđ";
            this.uC_product16.BTNReviews_Drinks = resources.GetString("uC_product16.BTNReviews_Drinks");
            this.uC_product16.Categories = null;
            this.uC_product16.ID = null;
            this.uC_product16.LBLDescribe_Drinks = "";
            this.uC_product16.LBLName_Drinks = null;
            this.uC_product16.LBLRate_Drinks = "";
            this.uC_product16.Location = new System.Drawing.Point(0, 0);
            this.uC_product16.Margin = new System.Windows.Forms.Padding(17);
            this.uC_product16.Name = "uC_product16";
            this.uC_product16.PTBImage_Drinks = null;
            this.uC_product16.Size = new System.Drawing.Size(250, 294);
            this.uC_product16.TabIndex = 0;
            // 
            // guna2Panel43
            // 
            this.guna2Panel43.Controls.Add(this.flpPageNavigation);
            this.guna2Panel43.Location = new System.Drawing.Point(3, 1303);
            this.guna2Panel43.Name = "guna2Panel43";
            this.guna2Panel43.Size = new System.Drawing.Size(1137, 67);
            this.guna2Panel43.TabIndex = 9;
            // 
            // flpPageNavigation
            // 
            this.flpPageNavigation.Controls.Add(this.btnPage_Back);
            this.flpPageNavigation.Controls.Add(this.btnFirst_page);
            this.flpPageNavigation.Controls.Add(this.btnSecond_page);
            this.flpPageNavigation.Controls.Add(this.btnThird_page);
            this.flpPageNavigation.Controls.Add(this.btnPage_Next);
            this.flpPageNavigation.Location = new System.Drawing.Point(375, 4);
            this.flpPageNavigation.Name = "flpPageNavigation";
            this.flpPageNavigation.Size = new System.Drawing.Size(378, 57);
            this.flpPageNavigation.TabIndex = 7;
            // 
            // btnPage_Back
            // 
            this.btnPage_Back.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPage_Back.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPage_Back.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPage_Back.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPage_Back.FillColor = System.Drawing.Color.Transparent;
            this.btnPage_Back.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPage_Back.ForeColor = System.Drawing.Color.White;
            this.btnPage_Back.Image = ((System.Drawing.Image)(resources.GetObject("btnPage_Back.Image")));
            this.btnPage_Back.ImageSize = new System.Drawing.Size(40, 40);
            this.btnPage_Back.Location = new System.Drawing.Point(8, 8);
            this.btnPage_Back.Margin = new System.Windows.Forms.Padding(8);
            this.btnPage_Back.Name = "btnPage_Back";
            this.btnPage_Back.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnPage_Back.Size = new System.Drawing.Size(44, 44);
            this.btnPage_Back.TabIndex = 4;
            this.btnPage_Back.Click += new System.EventHandler(this.btnPage_Back_Click);
            // 
            // btnFirst_page
            // 
            this.btnFirst_page.BorderRadius = 15;
            this.btnFirst_page.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFirst_page.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFirst_page.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFirst_page.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFirst_page.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnFirst_page.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.btnFirst_page.ForeColor = System.Drawing.Color.White;
            this.btnFirst_page.Location = new System.Drawing.Point(68, 3);
            this.btnFirst_page.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.btnFirst_page.Name = "btnFirst_page";
            this.btnFirst_page.Size = new System.Drawing.Size(70, 50);
            this.btnFirst_page.TabIndex = 6;
            this.btnFirst_page.Text = "1";
            this.btnFirst_page.Click += new System.EventHandler(this.btnFirst_Page_Click_1);
            // 
            // btnSecond_page
            // 
            this.btnSecond_page.BorderRadius = 15;
            this.btnSecond_page.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSecond_page.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSecond_page.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSecond_page.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSecond_page.FillColor = System.Drawing.Color.Transparent;
            this.btnSecond_page.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecond_page.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnSecond_page.Location = new System.Drawing.Point(154, 3);
            this.btnSecond_page.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.btnSecond_page.Name = "btnSecond_page";
            this.btnSecond_page.Size = new System.Drawing.Size(70, 50);
            this.btnSecond_page.TabIndex = 0;
            this.btnSecond_page.Text = "2";
            this.btnSecond_page.TextOffset = new System.Drawing.Point(0, -2);
            this.btnSecond_page.Click += new System.EventHandler(this.btnSecond_page_Click);
            // 
            // btnThird_page
            // 
            this.btnThird_page.BorderRadius = 15;
            this.btnThird_page.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThird_page.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThird_page.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThird_page.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThird_page.FillColor = System.Drawing.Color.Transparent;
            this.btnThird_page.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThird_page.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnThird_page.Location = new System.Drawing.Point(240, 3);
            this.btnThird_page.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.btnThird_page.Name = "btnThird_page";
            this.btnThird_page.Size = new System.Drawing.Size(70, 50);
            this.btnThird_page.TabIndex = 1;
            this.btnThird_page.Text = "3";
            this.btnThird_page.TextOffset = new System.Drawing.Point(0, -2);
            this.btnThird_page.Click += new System.EventHandler(this.btnThird_page_Click);
            // 
            // btnPage_Next
            // 
            this.btnPage_Next.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPage_Next.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPage_Next.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPage_Next.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPage_Next.FillColor = System.Drawing.Color.Transparent;
            this.btnPage_Next.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPage_Next.ForeColor = System.Drawing.Color.White;
            this.btnPage_Next.Image = ((System.Drawing.Image)(resources.GetObject("btnPage_Next.Image")));
            this.btnPage_Next.ImageSize = new System.Drawing.Size(40, 40);
            this.btnPage_Next.Location = new System.Drawing.Point(326, 8);
            this.btnPage_Next.Margin = new System.Windows.Forms.Padding(8);
            this.btnPage_Next.Name = "btnPage_Next";
            this.btnPage_Next.Padding = new System.Windows.Forms.Padding(5);
            this.btnPage_Next.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnPage_Next.Size = new System.Drawing.Size(44, 44);
            this.btnPage_Next.TabIndex = 5;
            this.btnPage_Next.Click += new System.EventHandler(this.btnPage_Next_Click);
            // 
            // guna2PictureBox16
            // 
            this.guna2PictureBox16.BorderRadius = 40;
            this.guna2PictureBox16.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox16.Image")));
            this.guna2PictureBox16.ImageRotate = 0F;
            this.guna2PictureBox16.Location = new System.Drawing.Point(816, 139);
            this.guna2PictureBox16.Name = "guna2PictureBox16";
            this.guna2PictureBox16.Size = new System.Drawing.Size(306, 306);
            this.guna2PictureBox16.TabIndex = 1;
            this.guna2PictureBox16.TabStop = false;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel3.Location = new System.Drawing.Point(14, 693);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(1102, 3);
            this.guna2Panel3.TabIndex = 4;
            // 
            // guna2Panel26
            // 
            this.guna2Panel26.BackColor = System.Drawing.Color.Black;
            this.guna2Panel26.Location = new System.Drawing.Point(601, 470);
            this.guna2Panel26.Name = "guna2Panel26";
            this.guna2Panel26.Size = new System.Drawing.Size(137, 3);
            this.guna2Panel26.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bradley Hand ITC", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.label7.Location = new System.Drawing.Point(19, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(321, 79);
            this.label7.TabIndex = 2;
            this.label7.Text = "Shopping!";
            // 
            // guna2Panel25
            // 
            this.guna2Panel25.BackColor = System.Drawing.Color.Black;
            this.guna2Panel25.Location = new System.Drawing.Point(442, 470);
            this.guna2Panel25.Name = "guna2Panel25";
            this.guna2Panel25.Size = new System.Drawing.Size(137, 3);
            this.guna2Panel25.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bradley Hand ITC", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(25, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(287, 46);
            this.label8.TabIndex = 2;
            this.label8.Text = "Welcome to store";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bradley Hand ITC", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(9, 593);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(186, 46);
            this.label9.TabIndex = 2;
            this.label9.Text = "Categories";
            // 
            // guna2Panel24
            // 
            this.guna2Panel24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel24.Location = new System.Drawing.Point(280, 470);
            this.guna2Panel24.Name = "guna2Panel24";
            this.guna2Panel24.Size = new System.Drawing.Size(137, 3);
            this.guna2Panel24.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.pnlEmpty_History);
            this.tabPage3.Controls.Add(this.flpHistory);
            this.tabPage3.Controls.Add(this.guna2Panel49);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1163, 721);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // pnlEmpty_History
            // 
            this.pnlEmpty_History.Controls.Add(this.label29);
            this.pnlEmpty_History.Controls.Add(this.guna2PictureBox20);
            this.pnlEmpty_History.Controls.Add(this.btnShopNow_History);
            this.pnlEmpty_History.Location = new System.Drawing.Point(0, 0);
            this.pnlEmpty_History.Name = "pnlEmpty_History";
            this.pnlEmpty_History.Size = new System.Drawing.Size(1151, 721);
            this.pnlEmpty_History.TabIndex = 2;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.label29.Location = new System.Drawing.Point(484, 436);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(195, 16);
            this.label29.TabIndex = 5;
            this.label29.Text = "Your History Shopping Is Empty";
            // 
            // guna2PictureBox20
            // 
            this.guna2PictureBox20.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox20.Image")));
            this.guna2PictureBox20.ImageRotate = 0F;
            this.guna2PictureBox20.Location = new System.Drawing.Point(464, 206);
            this.guna2PictureBox20.Name = "guna2PictureBox20";
            this.guna2PictureBox20.Size = new System.Drawing.Size(209, 227);
            this.guna2PictureBox20.TabIndex = 4;
            this.guna2PictureBox20.TabStop = false;
            // 
            // btnShopNow_History
            // 
            this.btnShopNow_History.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnShopNow_History.BorderRadius = 15;
            this.btnShopNow_History.BorderThickness = 2;
            this.btnShopNow_History.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShopNow_History.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShopNow_History.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShopNow_History.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShopNow_History.FillColor = System.Drawing.Color.Transparent;
            this.btnShopNow_History.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShopNow_History.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnShopNow_History.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnShopNow_History.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnShopNow_History.Location = new System.Drawing.Point(464, 469);
            this.btnShopNow_History.Name = "btnShopNow_History";
            this.btnShopNow_History.Size = new System.Drawing.Size(223, 45);
            this.btnShopNow_History.TabIndex = 3;
            this.btnShopNow_History.Text = "Shop Now";
            this.btnShopNow_History.Click += new System.EventHandler(this.btnShopping_Click);
            // 
            // flpHistory
            // 
            this.flpHistory.AutoScroll = true;
            this.flpHistory.Location = new System.Drawing.Point(66, 171);
            this.flpHistory.Name = "flpHistory";
            this.flpHistory.Size = new System.Drawing.Size(1030, 550);
            this.flpHistory.TabIndex = 1;
            // 
            // guna2Panel49
            // 
            this.guna2Panel49.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel49.BorderRadius = 20;
            this.guna2Panel49.BorderThickness = 1;
            this.guna2Panel49.Controls.Add(this.guna2Panel51);
            this.guna2Panel49.Controls.Add(this.guna2Button4);
            this.guna2Panel49.Controls.Add(this.guna2Button2);
            this.guna2Panel49.Controls.Add(this.label27);
            this.guna2Panel49.Location = new System.Drawing.Point(66, 26);
            this.guna2Panel49.Name = "guna2Panel49";
            this.guna2Panel49.Size = new System.Drawing.Size(1015, 129);
            this.guna2Panel49.TabIndex = 0;
            // 
            // guna2Panel51
            // 
            this.guna2Panel51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel51.Location = new System.Drawing.Point(24, 123);
            this.guna2Panel51.Name = "guna2Panel51";
            this.guna2Panel51.Size = new System.Drawing.Size(92, 3);
            this.guna2Panel51.TabIndex = 3;
            // 
            // guna2Button4
            // 
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Button4.Location = new System.Drawing.Point(24, 89);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(92, 34);
            this.guna2Button4.TabIndex = 2;
            this.guna2Button4.Text = "ALL";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 15;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(21, 48);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(180, 35);
            this.guna2Button2.TabIndex = 1;
            this.guna2Button2.Text = "Buy Online";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(17, 3);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(181, 42);
            this.label27.TabIndex = 0;
            this.label27.Text = "My Order";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.tabPage4.Controls.Add(this.btnEditProfile);
            this.tabPage4.Controls.Add(this.txtAddress_profile);
            this.tabPage4.Controls.Add(this.txtEmail_profile);
            this.tabPage4.Controls.Add(this.txtDate_profile);
            this.tabPage4.Controls.Add(this.txtName_profile);
            this.tabPage4.Controls.Add(this.lblAddress_profile);
            this.tabPage4.Controls.Add(this.guna2HtmlLabel47);
            this.tabPage4.Controls.Add(this.lblEmail_profile);
            this.tabPage4.Controls.Add(this.guna2HtmlLabel46);
            this.tabPage4.Controls.Add(this.guna2HtmlLabel45);
            this.tabPage4.Controls.Add(this.lblMode_Profile);
            this.tabPage4.Controls.Add(this.lblDate_profile);
            this.tabPage4.Controls.Add(this.lblName_profile);
            this.tabPage4.Controls.Add(this.guna2HtmlLabel44);
            this.tabPage4.Controls.Add(this.btnSave);
            this.tabPage4.Controls.Add(this.btnCancel);
            this.tabPage4.Controls.Add(this.btnUpload_Profile);
            this.tabPage4.Controls.Add(this.ptbImage_Profile);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1163, 721);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnEditProfile.BorderRadius = 7;
            this.btnEditProfile.BorderThickness = 2;
            this.btnEditProfile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditProfile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditProfile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditProfile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditProfile.FillColor = System.Drawing.Color.Transparent;
            this.btnEditProfile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnEditProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnEditProfile.Image")));
            this.btnEditProfile.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEditProfile.ImageSize = new System.Drawing.Size(15, 15);
            this.btnEditProfile.Location = new System.Drawing.Point(494, 554);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(210, 32);
            this.btnEditProfile.TabIndex = 1;
            this.btnEditProfile.Text = "EDIT PROFILE";
            this.btnEditProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // txtAddress_profile
            // 
            this.txtAddress_profile.BackColor = System.Drawing.Color.Black;
            this.txtAddress_profile.BorderColor = System.Drawing.Color.Transparent;
            this.txtAddress_profile.BorderThickness = 0;
            this.txtAddress_profile.Cursor = System.Windows.Forms.Cursors.No;
            this.txtAddress_profile.DefaultText = "";
            this.txtAddress_profile.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress_profile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress_profile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress_profile.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress_profile.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtAddress_profile.ForeColor = System.Drawing.Color.Black;
            this.txtAddress_profile.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress_profile.Location = new System.Drawing.Point(643, 436);
            this.txtAddress_profile.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtAddress_profile.Multiline = true;
            this.txtAddress_profile.Name = "txtAddress_profile";
            this.txtAddress_profile.PlaceholderText = "";
            this.txtAddress_profile.SelectedText = "";
            this.txtAddress_profile.ShortcutsEnabled = false;
            this.txtAddress_profile.Size = new System.Drawing.Size(506, 63);
            this.txtAddress_profile.TabIndex = 5;
            // 
            // txtEmail_profile
            // 
            this.txtEmail_profile.BackColor = System.Drawing.Color.Black;
            this.txtEmail_profile.BorderColor = System.Drawing.Color.Transparent;
            this.txtEmail_profile.BorderThickness = 0;
            this.txtEmail_profile.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail_profile.DefaultText = "";
            this.txtEmail_profile.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail_profile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail_profile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail_profile.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail_profile.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtEmail_profile.ForeColor = System.Drawing.Color.Black;
            this.txtEmail_profile.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail_profile.Location = new System.Drawing.Point(644, 341);
            this.txtEmail_profile.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtEmail_profile.Name = "txtEmail_profile";
            this.txtEmail_profile.PlaceholderText = "";
            this.txtEmail_profile.SelectedText = "";
            this.txtEmail_profile.Size = new System.Drawing.Size(506, 27);
            this.txtEmail_profile.TabIndex = 5;
            // 
            // txtDate_profile
            // 
            this.txtDate_profile.BackColor = System.Drawing.Color.Black;
            this.txtDate_profile.BorderColor = System.Drawing.Color.Transparent;
            this.txtDate_profile.BorderThickness = 0;
            this.txtDate_profile.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDate_profile.DefaultText = "";
            this.txtDate_profile.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDate_profile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDate_profile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDate_profile.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDate_profile.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDate_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtDate_profile.ForeColor = System.Drawing.Color.Black;
            this.txtDate_profile.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDate_profile.Location = new System.Drawing.Point(644, 231);
            this.txtDate_profile.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtDate_profile.Name = "txtDate_profile";
            this.txtDate_profile.PlaceholderText = "";
            this.txtDate_profile.SelectedText = "";
            this.txtDate_profile.Size = new System.Drawing.Size(506, 27);
            this.txtDate_profile.TabIndex = 5;
            // 
            // txtName_profile
            // 
            this.txtName_profile.BackColor = System.Drawing.Color.Black;
            this.txtName_profile.BorderColor = System.Drawing.Color.Transparent;
            this.txtName_profile.BorderThickness = 0;
            this.txtName_profile.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName_profile.DefaultText = "";
            this.txtName_profile.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtName_profile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtName_profile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName_profile.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName_profile.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtName_profile.ForeColor = System.Drawing.Color.Black;
            this.txtName_profile.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName_profile.Location = new System.Drawing.Point(644, 128);
            this.txtName_profile.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtName_profile.Name = "txtName_profile";
            this.txtName_profile.PlaceholderText = "";
            this.txtName_profile.SelectedText = "";
            this.txtName_profile.Size = new System.Drawing.Size(506, 27);
            this.txtName_profile.TabIndex = 5;
            // 
            // lblAddress_profile
            // 
            this.lblAddress_profile.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress_profile.Location = new System.Drawing.Point(492, 463);
            this.lblAddress_profile.Name = "lblAddress_profile";
            this.lblAddress_profile.Size = new System.Drawing.Size(3, 2);
            this.lblAddress_profile.TabIndex = 3;
            this.lblAddress_profile.Text = null;
            // 
            // guna2HtmlLabel47
            // 
            this.guna2HtmlLabel47.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel47.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel47.Location = new System.Drawing.Point(493, 437);
            this.guna2HtmlLabel47.Name = "guna2HtmlLabel47";
            this.guna2HtmlLabel47.Size = new System.Drawing.Size(106, 31);
            this.guna2HtmlLabel47.TabIndex = 3;
            this.guna2HtmlLabel47.Text = "Address:";
            // 
            // lblEmail_profile
            // 
            this.lblEmail_profile.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail_profile.Location = new System.Drawing.Point(493, 370);
            this.lblEmail_profile.Name = "lblEmail_profile";
            this.lblEmail_profile.Size = new System.Drawing.Size(3, 2);
            this.lblEmail_profile.TabIndex = 3;
            this.lblEmail_profile.Text = null;
            // 
            // guna2HtmlLabel46
            // 
            this.guna2HtmlLabel46.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel46.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel46.Location = new System.Drawing.Point(493, 341);
            this.guna2HtmlLabel46.Name = "guna2HtmlLabel46";
            this.guna2HtmlLabel46.Size = new System.Drawing.Size(76, 31);
            this.guna2HtmlLabel46.TabIndex = 3;
            this.guna2HtmlLabel46.Text = "Email: ";
            // 
            // guna2HtmlLabel45
            // 
            this.guna2HtmlLabel45.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel45.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel45.Location = new System.Drawing.Point(494, 231);
            this.guna2HtmlLabel45.Name = "guna2HtmlLabel45";
            this.guna2HtmlLabel45.Size = new System.Drawing.Size(64, 31);
            this.guna2HtmlLabel45.TabIndex = 3;
            this.guna2HtmlLabel45.Text = "Date: ";
            // 
            // lblMode_Profile
            // 
            this.lblMode_Profile.BackColor = System.Drawing.Color.Transparent;
            this.lblMode_Profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode_Profile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblMode_Profile.Location = new System.Drawing.Point(34, 26);
            this.lblMode_Profile.Name = "lblMode_Profile";
            this.lblMode_Profile.Size = new System.Drawing.Size(92, 27);
            this.lblMode_Profile.TabIndex = 2;
            this.lblMode_Profile.Text = "PROFILE";
            // 
            // lblDate_profile
            // 
            this.lblDate_profile.BackColor = System.Drawing.Color.Transparent;
            this.lblDate_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate_profile.Location = new System.Drawing.Point(494, 256);
            this.lblDate_profile.Name = "lblDate_profile";
            this.lblDate_profile.Size = new System.Drawing.Size(3, 2);
            this.lblDate_profile.TabIndex = 2;
            this.lblDate_profile.Text = null;
            // 
            // lblName_profile
            // 
            this.lblName_profile.BackColor = System.Drawing.Color.Transparent;
            this.lblName_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName_profile.Location = new System.Drawing.Point(494, 154);
            this.lblName_profile.Name = "lblName_profile";
            this.lblName_profile.Size = new System.Drawing.Size(3, 2);
            this.lblName_profile.TabIndex = 2;
            this.lblName_profile.Text = null;
            // 
            // guna2HtmlLabel44
            // 
            this.guna2HtmlLabel44.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel44.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel44.Location = new System.Drawing.Point(494, 128);
            this.guna2HtmlLabel44.Name = "guna2HtmlLabel44";
            this.guna2HtmlLabel44.Size = new System.Drawing.Size(79, 31);
            this.guna2HtmlLabel44.TabIndex = 2;
            this.guna2HtmlLabel44.Text = "Name: ";
            // 
            // btnSave
            // 
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnSave.BorderRadius = 10;
            this.btnSave.BorderThickness = 2;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.ImageSize = new System.Drawing.Size(0, 0);
            this.btnSave.Location = new System.Drawing.Point(494, 538);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(210, 48);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnCancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancel.ImageSize = new System.Drawing.Size(0, 0);
            this.btnCancel.Location = new System.Drawing.Point(739, 538);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(210, 48);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpload_Profile
            // 
            this.btnUpload_Profile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnUpload_Profile.BorderRadius = 7;
            this.btnUpload_Profile.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            this.btnUpload_Profile.BorderThickness = 2;
            this.btnUpload_Profile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpload_Profile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpload_Profile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpload_Profile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpload_Profile.FillColor = System.Drawing.Color.Transparent;
            this.btnUpload_Profile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload_Profile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnUpload_Profile.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload_Profile.Image")));
            this.btnUpload_Profile.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUpload_Profile.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnUpload_Profile.ImageSize = new System.Drawing.Size(80, 80);
            this.btnUpload_Profile.Location = new System.Drawing.Point(182, 505);
            this.btnUpload_Profile.Name = "btnUpload_Profile";
            this.btnUpload_Profile.Size = new System.Drawing.Size(250, 81);
            this.btnUpload_Profile.TabIndex = 1;
            this.btnUpload_Profile.Text = "UPLOAD\nYOUR IMAGE";
            this.btnUpload_Profile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUpload_Profile.TextOffset = new System.Drawing.Point(25, 0);
            this.btnUpload_Profile.Click += new System.EventHandler(this.btnUpload_Profile_Click);
            // 
            // ptbImage_Profile
            // 
            this.ptbImage_Profile.BorderRadius = 190;
            this.ptbImage_Profile.ImageRotate = 0F;
            this.ptbImage_Profile.Location = new System.Drawing.Point(52, 110);
            this.ptbImage_Profile.Name = "ptbImage_Profile";
            this.ptbImage_Profile.Size = new System.Drawing.Size(380, 380);
            this.ptbImage_Profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbImage_Profile.TabIndex = 0;
            this.ptbImage_Profile.TabStop = false;
            // 
            // tabPage5
            // 
            this.tabPage5.AutoScroll = true;
            this.tabPage5.Controls.Add(this.pnlInformation);
            this.tabPage5.Controls.Add(this.pnlBill);
            this.tabPage5.Controls.Add(this.flpPayment);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1163, 721);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pnlInformation
            // 
            this.pnlInformation.Controls.Add(this.label23);
            this.pnlInformation.Controls.Add(this.label22);
            this.pnlInformation.Controls.Add(this.label21);
            this.pnlInformation.Controls.Add(this.label20);
            this.pnlInformation.Controls.Add(this.guna2Panel48);
            this.pnlInformation.Location = new System.Drawing.Point(0, 0);
            this.pnlInformation.Name = "pnlInformation";
            this.pnlInformation.Size = new System.Drawing.Size(862, 44);
            this.pnlInformation.TabIndex = 5;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(502, 5);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 25);
            this.label23.TabIndex = 0;
            this.label23.Text = "Price";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(626, 5);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 25);
            this.label22.TabIndex = 0;
            this.label22.Text = "QTV";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(701, 5);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 25);
            this.label21.TabIndex = 0;
            this.label21.Text = "Amount";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(10, -4);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(174, 42);
            this.label20.TabIndex = 0;
            this.label20.Text = "Products";
            // 
            // guna2Panel48
            // 
            this.guna2Panel48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel48.Location = new System.Drawing.Point(17, 38);
            this.guna2Panel48.Name = "guna2Panel48";
            this.guna2Panel48.Size = new System.Drawing.Size(822, 3);
            this.guna2Panel48.TabIndex = 0;
            // 
            // pnlBill
            // 
            this.pnlBill.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.pnlBill.BorderThickness = 1;
            this.pnlBill.Controls.Add(this.btnOrderNow_Bill);
            this.pnlBill.Controls.Add(this.label10);
            this.pnlBill.Controls.Add(this.guna2HtmlLabel36);
            this.pnlBill.Controls.Add(this.guna2HtmlLabel39);
            this.pnlBill.Controls.Add(this.guna2HtmlLabel38);
            this.pnlBill.Controls.Add(this.guna2Panel45);
            this.pnlBill.Controls.Add(this.guna2HtmlLabel42);
            this.pnlBill.Controls.Add(this.lblShip);
            this.pnlBill.Controls.Add(this.lblMoney_Sum);
            this.pnlBill.Controls.Add(this.guna2HtmlLabel41);
            this.pnlBill.Controls.Add(this.guna2HtmlLabel37);
            this.pnlBill.Controls.Add(this.lblMoney_SubTotal);
            this.pnlBill.Location = new System.Drawing.Point(884, 0);
            this.pnlBill.Name = "pnlBill";
            this.pnlBill.Size = new System.Drawing.Size(258, 343);
            this.pnlBill.TabIndex = 4;
            // 
            // btnOrderNow_Bill
            // 
            this.btnOrderNow_Bill.BorderRadius = 20;
            this.btnOrderNow_Bill.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOrderNow_Bill.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOrderNow_Bill.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOrderNow_Bill.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOrderNow_Bill.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnOrderNow_Bill.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderNow_Bill.ForeColor = System.Drawing.Color.White;
            this.btnOrderNow_Bill.Location = new System.Drawing.Point(7, 285);
            this.btnOrderNow_Bill.Name = "btnOrderNow_Bill";
            this.btnOrderNow_Bill.Size = new System.Drawing.Size(239, 40);
            this.btnOrderNow_Bill.TabIndex = 2;
            this.btnOrderNow_Bill.Text = "Order Now";
            this.btnOrderNow_Bill.Click += new System.EventHandler(this.btnOrderNow_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.label10.Location = new System.Drawing.Point(61, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 55);
            this.label10.TabIndex = 2;
            this.label10.Text = "BILL";
            // 
            // guna2HtmlLabel36
            // 
            this.guna2HtmlLabel36.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel36.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel36.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel36.Location = new System.Drawing.Point(7, 82);
            this.guna2HtmlLabel36.Name = "guna2HtmlLabel36";
            this.guna2HtmlLabel36.Size = new System.Drawing.Size(97, 27);
            this.guna2HtmlLabel36.TabIndex = 1;
            this.guna2HtmlLabel36.Text = "Subtotal:";
            // 
            // guna2HtmlLabel39
            // 
            this.guna2HtmlLabel39.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel39.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel39.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel39.Location = new System.Drawing.Point(7, 242);
            this.guna2HtmlLabel39.Name = "guna2HtmlLabel39";
            this.guna2HtmlLabel39.Size = new System.Drawing.Size(150, 26);
            this.guna2HtmlLabel39.TabIndex = 3;
            this.guna2HtmlLabel39.Text = "(Including VAT)";
            // 
            // guna2HtmlLabel38
            // 
            this.guna2HtmlLabel38.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel38.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel38.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel38.Location = new System.Drawing.Point(7, 209);
            this.guna2HtmlLabel38.Name = "guna2HtmlLabel38";
            this.guna2HtmlLabel38.Size = new System.Drawing.Size(49, 27);
            this.guna2HtmlLabel38.TabIndex = 1;
            this.guna2HtmlLabel38.Text = "Sum";
            // 
            // guna2Panel45
            // 
            this.guna2Panel45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel45.Location = new System.Drawing.Point(24, 66);
            this.guna2Panel45.Name = "guna2Panel45";
            this.guna2Panel45.Size = new System.Drawing.Size(222, 3);
            this.guna2Panel45.TabIndex = 1;
            // 
            // guna2HtmlLabel42
            // 
            this.guna2HtmlLabel42.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel42.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel42.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel42.Location = new System.Drawing.Point(138, 166);
            this.guna2HtmlLabel42.Name = "guna2HtmlLabel42";
            this.guna2HtmlLabel42.Size = new System.Drawing.Size(29, 27);
            this.guna2HtmlLabel42.TabIndex = 1;
            this.guna2HtmlLabel42.Text = "0đ";
            // 
            // lblShip
            // 
            this.lblShip.BackColor = System.Drawing.Color.Transparent;
            this.lblShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShip.ForeColor = System.Drawing.Color.Black;
            this.lblShip.Location = new System.Drawing.Point(138, 122);
            this.lblShip.Name = "lblShip";
            this.lblShip.Size = new System.Drawing.Size(29, 27);
            this.lblShip.TabIndex = 1;
            this.lblShip.Text = "0đ";
            // 
            // lblMoney_Sum
            // 
            this.lblMoney_Sum.BackColor = System.Drawing.Color.Transparent;
            this.lblMoney_Sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney_Sum.ForeColor = System.Drawing.Color.Black;
            this.lblMoney_Sum.Location = new System.Drawing.Point(138, 209);
            this.lblMoney_Sum.Name = "lblMoney_Sum";
            this.lblMoney_Sum.Size = new System.Drawing.Size(29, 27);
            this.lblMoney_Sum.TabIndex = 1;
            this.lblMoney_Sum.Text = "0đ";
            // 
            // guna2HtmlLabel41
            // 
            this.guna2HtmlLabel41.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel41.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel41.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel41.Location = new System.Drawing.Point(7, 122);
            this.guna2HtmlLabel41.Name = "guna2HtmlLabel41";
            this.guna2HtmlLabel41.Size = new System.Drawing.Size(57, 27);
            this.guna2HtmlLabel41.TabIndex = 1;
            this.guna2HtmlLabel41.Text = "Ship:";
            // 
            // guna2HtmlLabel37
            // 
            this.guna2HtmlLabel37.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel37.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel37.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel37.Location = new System.Drawing.Point(7, 166);
            this.guna2HtmlLabel37.Name = "guna2HtmlLabel37";
            this.guna2HtmlLabel37.Size = new System.Drawing.Size(97, 27);
            this.guna2HtmlLabel37.TabIndex = 1;
            this.guna2HtmlLabel37.Text = "Voucher:";
            // 
            // lblMoney_SubTotal
            // 
            this.lblMoney_SubTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblMoney_SubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney_SubTotal.ForeColor = System.Drawing.Color.Black;
            this.lblMoney_SubTotal.Location = new System.Drawing.Point(138, 82);
            this.lblMoney_SubTotal.Name = "lblMoney_SubTotal";
            this.lblMoney_SubTotal.Size = new System.Drawing.Size(29, 27);
            this.lblMoney_SubTotal.TabIndex = 1;
            this.lblMoney_SubTotal.Text = "0đ";
            // 
            // flpPayment
            // 
            this.flpPayment.AutoScroll = true;
            this.flpPayment.Controls.Add(this.pnlPayment);
            this.flpPayment.Controls.Add(this.pnlEmpty);
            this.flpPayment.Location = new System.Drawing.Point(0, 47);
            this.flpPayment.Name = "flpPayment";
            this.flpPayment.Size = new System.Drawing.Size(878, 671);
            this.flpPayment.TabIndex = 0;
            // 
            // pnlPayment
            // 
            this.pnlPayment.Controls.Add(this.btnOrderNow);
            this.pnlPayment.Controls.Add(this.lblMoney_payment);
            this.pnlPayment.Controls.Add(this.guna2HtmlLabel35);
            this.pnlPayment.Controls.Add(this.guna2HtmlLabel40);
            this.pnlPayment.Controls.Add(this.guna2Panel47);
            this.pnlPayment.Location = new System.Drawing.Point(3, 3);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(862, 113);
            this.pnlPayment.TabIndex = 0;
            // 
            // btnOrderNow
            // 
            this.btnOrderNow.BorderRadius = 8;
            this.btnOrderNow.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOrderNow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOrderNow.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOrderNow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOrderNow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnOrderNow.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderNow.ForeColor = System.Drawing.Color.White;
            this.btnOrderNow.Location = new System.Drawing.Point(611, 72);
            this.btnOrderNow.Name = "btnOrderNow";
            this.btnOrderNow.Size = new System.Drawing.Size(204, 36);
            this.btnOrderNow.TabIndex = 2;
            this.btnOrderNow.Text = "Order Now";
            this.btnOrderNow.Click += new System.EventHandler(this.btnOrderNow_Click);
            // 
            // lblMoney_payment
            // 
            this.lblMoney_payment.BackColor = System.Drawing.Color.Transparent;
            this.lblMoney_payment.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney_payment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblMoney_payment.Location = new System.Drawing.Point(723, 16);
            this.lblMoney_payment.Name = "lblMoney_payment";
            this.lblMoney_payment.Size = new System.Drawing.Size(32, 31);
            this.lblMoney_payment.TabIndex = 1;
            this.lblMoney_payment.Text = "0đ";
            // 
            // guna2HtmlLabel35
            // 
            this.guna2HtmlLabel35.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel35.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel35.Location = new System.Drawing.Point(611, 16);
            this.guna2HtmlLabel35.Name = "guna2HtmlLabel35";
            this.guna2HtmlLabel35.Size = new System.Drawing.Size(106, 31);
            this.guna2HtmlLabel35.TabIndex = 1;
            this.guna2HtmlLabel35.Text = "Subtotal:";
            // 
            // guna2HtmlLabel40
            // 
            this.guna2HtmlLabel40.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel40.Location = new System.Drawing.Point(611, 48);
            this.guna2HtmlLabel40.Name = "guna2HtmlLabel40";
            this.guna2HtmlLabel40.Size = new System.Drawing.Size(109, 18);
            this.guna2HtmlLabel40.TabIndex = 3;
            this.guna2HtmlLabel40.Text = "(Including VAT)";
            // 
            // guna2Panel47
            // 
            this.guna2Panel47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel47.Location = new System.Drawing.Point(17, 7);
            this.guna2Panel47.Name = "guna2Panel47";
            this.guna2Panel47.Size = new System.Drawing.Size(822, 3);
            this.guna2Panel47.TabIndex = 0;
            // 
            // pnlEmpty
            // 
            this.pnlEmpty.Controls.Add(this.label11);
            this.pnlEmpty.Controls.Add(this.guna2PictureBox17);
            this.pnlEmpty.Controls.Add(this.btnShopNow_Cart);
            this.pnlEmpty.Location = new System.Drawing.Point(3, 122);
            this.pnlEmpty.Name = "pnlEmpty";
            this.pnlEmpty.Size = new System.Drawing.Size(862, 458);
            this.pnlEmpty.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.label11.Location = new System.Drawing.Point(411, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Your Shopping Cart Is Empty";
            // 
            // guna2PictureBox17
            // 
            this.guna2PictureBox17.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox17.Image")));
            this.guna2PictureBox17.ImageRotate = 0F;
            this.guna2PictureBox17.Location = new System.Drawing.Point(391, 46);
            this.guna2PictureBox17.Name = "guna2PictureBox17";
            this.guna2PictureBox17.Size = new System.Drawing.Size(209, 227);
            this.guna2PictureBox17.TabIndex = 1;
            this.guna2PictureBox17.TabStop = false;
            // 
            // btnShopNow_Cart
            // 
            this.btnShopNow_Cart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnShopNow_Cart.BorderRadius = 15;
            this.btnShopNow_Cart.BorderThickness = 2;
            this.btnShopNow_Cart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShopNow_Cart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShopNow_Cart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShopNow_Cart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShopNow_Cart.FillColor = System.Drawing.Color.Transparent;
            this.btnShopNow_Cart.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShopNow_Cart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnShopNow_Cart.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnShopNow_Cart.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnShopNow_Cart.Location = new System.Drawing.Point(391, 309);
            this.btnShopNow_Cart.Name = "btnShopNow_Cart";
            this.btnShopNow_Cart.Size = new System.Drawing.Size(223, 45);
            this.btnShopNow_Cart.TabIndex = 0;
            this.btnShopNow_Cart.Text = "Shop Now";
            this.btnShopNow_Cart.Click += new System.EventHandler(this.btnShopping_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.lblExpected);
            this.tabPage6.Controls.Add(this.guna2Panel46);
            this.tabPage6.Controls.Add(this.flpShoppingCart);
            this.tabPage6.Controls.Add(this.lblTime);
            this.tabPage6.Controls.Add(this.pnlShipper);
            this.tabPage6.Controls.Add(this.lblDistance);
            this.tabPage6.Controls.Add(this.label19);
            this.tabPage6.Controls.Add(this.label18);
            this.tabPage6.Controls.Add(this.label17);
            this.tabPage6.Controls.Add(this.label16);
            this.tabPage6.Controls.Add(this.label15);
            this.tabPage6.Controls.Add(this.label28);
            this.tabPage6.Controls.Add(this.label14);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Controls.Add(this.guna2ProgressBar1);
            this.tabPage6.Controls.Add(this.guna2PictureBox18);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1163, 721);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // lblExpected
            // 
            this.lblExpected.AutoSize = true;
            this.lblExpected.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblExpected.Location = new System.Drawing.Point(60, 204);
            this.lblExpected.Name = "lblExpected";
            this.lblExpected.Size = new System.Drawing.Size(193, 25);
            this.lblExpected.TabIndex = 0;
            this.lblExpected.Text = "Expected 10:40Am";
            // 
            // guna2Panel46
            // 
            this.guna2Panel46.Controls.Add(this.btnConfirm_Order);
            this.guna2Panel46.Controls.Add(this.lblStatus);
            this.guna2Panel46.Controls.Add(this.lblOrderCode);
            this.guna2Panel46.Controls.Add(this.lblSum_Transport);
            this.guna2Panel46.Location = new System.Drawing.Point(56, 231);
            this.guna2Panel46.Name = "guna2Panel46";
            this.guna2Panel46.Size = new System.Drawing.Size(1082, 23);
            this.guna2Panel46.TabIndex = 5;
            // 
            // btnConfirm_Order
            // 
            this.btnConfirm_Order.BorderRadius = 10;
            this.btnConfirm_Order.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirm_Order.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirm_Order.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConfirm_Order.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConfirm_Order.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnConfirm_Order.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnConfirm_Order.ForeColor = System.Drawing.Color.White;
            this.btnConfirm_Order.Location = new System.Drawing.Point(955, 0);
            this.btnConfirm_Order.Name = "btnConfirm_Order";
            this.btnConfirm_Order.Size = new System.Drawing.Size(80, 23);
            this.btnConfirm_Order.TabIndex = 6;
            this.btnConfirm_Order.Text = "Confirm";
            this.btnConfirm_Order.Click += new System.EventHandler(this.btnConfirm_Order_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblStatus.Location = new System.Drawing.Point(579, -2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 25);
            this.lblStatus.TabIndex = 0;
            // 
            // lblOrderCode
            // 
            this.lblOrderCode.AutoSize = true;
            this.lblOrderCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblOrderCode.Location = new System.Drawing.Point(4, -2);
            this.lblOrderCode.Name = "lblOrderCode";
            this.lblOrderCode.Size = new System.Drawing.Size(156, 25);
            this.lblOrderCode.TabIndex = 0;
            this.lblOrderCode.Text = "Order #000001";
            // 
            // lblSum_Transport
            // 
            this.lblSum_Transport.AutoSize = true;
            this.lblSum_Transport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSum_Transport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblSum_Transport.Location = new System.Drawing.Point(775, -2);
            this.lblSum_Transport.Name = "lblSum_Transport";
            this.lblSum_Transport.Size = new System.Drawing.Size(67, 25);
            this.lblSum_Transport.TabIndex = 0;
            this.lblSum_Transport.Text = "Sum: ";
            // 
            // flpShoppingCart
            // 
            this.flpShoppingCart.AutoScroll = true;
            this.flpShoppingCart.Location = new System.Drawing.Point(57, 251);
            this.flpShoppingCart.Name = "flpShoppingCart";
            this.flpShoppingCart.Size = new System.Drawing.Size(1082, 470);
            this.flpShoppingCart.TabIndex = 4;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblTime.Location = new System.Drawing.Point(285, 178);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(123, 25);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Time: 10km";
            // 
            // pnlShipper
            // 
            this.pnlShipper.Controls.Add(this.guna2PictureBox19);
            this.pnlShipper.Controls.Add(this.label13);
            this.pnlShipper.Location = new System.Drawing.Point(18, 8);
            this.pnlShipper.Name = "pnlShipper";
            this.pnlShipper.Size = new System.Drawing.Size(50, 96);
            this.pnlShipper.TabIndex = 3;
            // 
            // guna2PictureBox19
            // 
            this.guna2PictureBox19.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox19.Image")));
            this.guna2PictureBox19.ImageRotate = 0F;
            this.guna2PictureBox19.Location = new System.Drawing.Point(3, 28);
            this.guna2PictureBox19.Name = "guna2PictureBox19";
            this.guna2PictureBox19.Size = new System.Drawing.Size(44, 64);
            this.guna2PictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox19.TabIndex = 4;
            this.guna2PictureBox19.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(0, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Shipper";
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblDistance.Location = new System.Drawing.Point(60, 178);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(160, 25);
            this.lblDistance.TabIndex = 0;
            this.lblDistance.Text = "Distance: 10km";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(1089, 136);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "10 mins";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(884, 136);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "8 mins";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(682, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "6 mins";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(476, 136);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "4 mins";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(274, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "2 mins";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(33, 122);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(101, 13);
            this.label28.TabIndex = 2;
            this.label28.Text = "Take Your Order";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(120, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Start";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1118, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "YOU";
            // 
            // guna2ProgressBar1
            // 
            this.guna2ProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2ProgressBar1.BorderThickness = 1;
            this.guna2ProgressBar1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ProgressBar1.Location = new System.Drawing.Point(36, 110);
            this.guna2ProgressBar1.Name = "guna2ProgressBar1";
            this.guna2ProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.guna2ProgressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.guna2ProgressBar1.Size = new System.Drawing.Size(1100, 10);
            this.guna2ProgressBar1.TabIndex = 0;
            this.guna2ProgressBar1.Text = "guna2ProgressBar1";
            this.guna2ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // guna2PictureBox18
            // 
            this.guna2PictureBox18.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox18.Image")));
            this.guna2PictureBox18.ImageRotate = 0F;
            this.guna2PictureBox18.Location = new System.Drawing.Point(1116, 52);
            this.guna2PictureBox18.Name = "guna2PictureBox18";
            this.guna2PictureBox18.Size = new System.Drawing.Size(35, 52);
            this.guna2PictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox18.TabIndex = 1;
            this.guna2PictureBox18.TabStop = false;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage7.Controls.Add(this.guna2Panel53);
            this.tabPage7.Controls.Add(this.guna2Panel52);
            this.tabPage7.Controls.Add(this.guna2PictureBox22);
            this.tabPage7.Controls.Add(this.lblReviews_Product);
            this.tabPage7.Controls.Add(this.lblRate_Product);
            this.tabPage7.Controls.Add(this.lblDescribe_Product);
            this.tabPage7.Controls.Add(this.lblName_Product);
            this.tabPage7.Controls.Add(this.flpProduct);
            this.tabPage7.Controls.Add(this.ptbImage_Product);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1163, 721);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "tabPage7";
            // 
            // guna2Panel53
            // 
            this.guna2Panel53.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel53.Location = new System.Drawing.Point(516, 0);
            this.guna2Panel53.Name = "guna2Panel53";
            this.guna2Panel53.Size = new System.Drawing.Size(3, 721);
            this.guna2Panel53.TabIndex = 4;
            // 
            // guna2Panel52
            // 
            this.guna2Panel52.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel52.Location = new System.Drawing.Point(3, 510);
            this.guna2Panel52.Name = "guna2Panel52";
            this.guna2Panel52.Size = new System.Drawing.Size(500, 3);
            this.guna2Panel52.TabIndex = 4;
            // 
            // guna2PictureBox22
            // 
            this.guna2PictureBox22.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox22.Image")));
            this.guna2PictureBox22.ImageRotate = 0F;
            this.guna2PictureBox22.Location = new System.Drawing.Point(39, 630);
            this.guna2PictureBox22.Name = "guna2PictureBox22";
            this.guna2PictureBox22.Size = new System.Drawing.Size(25, 24);
            this.guna2PictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox22.TabIndex = 3;
            this.guna2PictureBox22.TabStop = false;
            // 
            // lblReviews_Product
            // 
            this.lblReviews_Product.BackColor = System.Drawing.Color.Transparent;
            this.lblReviews_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblReviews_Product.Location = new System.Drawing.Point(3, 597);
            this.lblReviews_Product.Name = "lblReviews_Product";
            this.lblReviews_Product.Size = new System.Drawing.Size(183, 27);
            this.lblReviews_Product.TabIndex = 2;
            this.lblReviews_Product.Text = "guna2HtmlLabel48";
            // 
            // lblRate_Product
            // 
            this.lblRate_Product.BackColor = System.Drawing.Color.Transparent;
            this.lblRate_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate_Product.Location = new System.Drawing.Point(3, 628);
            this.lblRate_Product.Name = "lblRate_Product";
            this.lblRate_Product.Size = new System.Drawing.Size(33, 27);
            this.lblRate_Product.TabIndex = 2;
            this.lblRate_Product.Text = "5.0";
            // 
            // lblDescribe_Product
            // 
            this.lblDescribe_Product.BackColor = System.Drawing.Color.Transparent;
            this.lblDescribe_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescribe_Product.Location = new System.Drawing.Point(3, 564);
            this.lblDescribe_Product.Name = "lblDescribe_Product";
            this.lblDescribe_Product.Size = new System.Drawing.Size(199, 27);
            this.lblDescribe_Product.TabIndex = 2;
            this.lblDescribe_Product.Text = "guna2HtmlLabel48";
            // 
            // lblName_Product
            // 
            this.lblName_Product.BackColor = System.Drawing.Color.Transparent;
            this.lblName_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName_Product.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblName_Product.Location = new System.Drawing.Point(3, 519);
            this.lblName_Product.Name = "lblName_Product";
            this.lblName_Product.Size = new System.Drawing.Size(289, 39);
            this.lblName_Product.TabIndex = 2;
            this.lblName_Product.Text = "guna2HtmlLabel48";
            // 
            // flpProduct
            // 
            this.flpProduct.AutoSize = true;
            this.flpProduct.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpProduct.Location = new System.Drawing.Point(519, 0);
            this.flpProduct.Name = "flpProduct";
            this.flpProduct.Size = new System.Drawing.Size(622, 721);
            this.flpProduct.TabIndex = 1;
            // 
            // ptbImage_Product
            // 
            this.ptbImage_Product.ImageRotate = 0F;
            this.ptbImage_Product.Location = new System.Drawing.Point(3, 3);
            this.ptbImage_Product.Name = "ptbImage_Product";
            this.ptbImage_Product.Size = new System.Drawing.Size(500, 500);
            this.ptbImage_Product.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbImage_Product.TabIndex = 0;
            this.ptbImage_Product.TabStop = false;
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1376, 771);
            this.Controls.Add(this.pnlAccount);
            this.Controls.Add(this.pnlhomePage);
            this.Controls.Add(this.pnlSaveLogin);
            this.Controls.Add(this.pnlAddShoppingCart);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCustomer";
            this.Load += new System.EventHandler(this.FormCustomer_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccount)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.pnlAddShoppingCart.ResumeLayout(false);
            this.pnlAddShoppingCart.PerformLayout();
            this.pnlSaveLogin.ResumeLayout(false);
            this.pnlSaveLogin.PerformLayout();
            this.pnlhomePage.ResumeLayout(false);
            this.pnlAccount.ResumeLayout(false);
            this.guna2Panel50.ResumeLayout(false);
            this.guna2Panel50.PerformLayout();
            this.guna2Panel55.ResumeLayout(false);
            this.guna2Panel55.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage_Account)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel5.PerformLayout();
            this.guna2Panel20.ResumeLayout(false);
            this.guna2Panel20.PerformLayout();
            this.guna2Panel17.ResumeLayout(false);
            this.guna2Panel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox14)).EndInit();
            this.guna2Panel13.ResumeLayout(false);
            this.guna2Panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).EndInit();
            this.guna2Panel6.ResumeLayout(false);
            this.guna2Panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage_BestSeller_Top1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).EndInit();
            this.guna2Panel8.ResumeLayout(false);
            this.guna2Panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage_BestSeller_Top3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox24)).EndInit();
            this.guna2Panel7.ResumeLayout(false);
            this.guna2Panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage_BestSeller_Top2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel9.ResumeLayout(false);
            this.guna2Panel9.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.guna2Panel44.ResumeLayout(false);
            this.guna2Panel44.PerformLayout();
            this.flpCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox15)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.guna2Panel27.ResumeLayout(false);
            this.guna2Panel28.ResumeLayout(false);
            this.guna2Panel29.ResumeLayout(false);
            this.guna2Panel30.ResumeLayout(false);
            this.guna2Panel31.ResumeLayout(false);
            this.guna2Panel32.ResumeLayout(false);
            this.guna2Panel33.ResumeLayout(false);
            this.guna2Panel34.ResumeLayout(false);
            this.guna2Panel35.ResumeLayout(false);
            this.guna2Panel36.ResumeLayout(false);
            this.guna2Panel37.ResumeLayout(false);
            this.guna2Panel38.ResumeLayout(false);
            this.guna2Panel39.ResumeLayout(false);
            this.guna2Panel40.ResumeLayout(false);
            this.guna2Panel41.ResumeLayout(false);
            this.guna2Panel42.ResumeLayout(false);
            this.guna2Panel43.ResumeLayout(false);
            this.flpPageNavigation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox16)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.pnlEmpty_History.ResumeLayout(false);
            this.pnlEmpty_History.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox20)).EndInit();
            this.guna2Panel49.ResumeLayout(false);
            this.guna2Panel49.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage_Profile)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.pnlInformation.ResumeLayout(false);
            this.pnlInformation.PerformLayout();
            this.pnlBill.ResumeLayout(false);
            this.pnlBill.PerformLayout();
            this.flpPayment.ResumeLayout(false);
            this.pnlPayment.ResumeLayout(false);
            this.pnlPayment.PerformLayout();
            this.pnlEmpty.ResumeLayout(false);
            this.pnlEmpty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox17)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.guna2Panel46.ResumeLayout(false);
            this.guna2Panel46.PerformLayout();
            this.pnlShipper.ResumeLayout(false);
            this.pnlShipper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox18)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage_Product)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private Management_Coffee_Shop.CustomTabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox6;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel8;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel7;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel6;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox8;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDescribe_BestSeller_Top1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRate_BestSeller_Top1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName_BestSeller_Top1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblReviews_BestSeller_Top1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel10;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel12;
        private Guna.UI2.WinForms.Guna2Button btnProfile;
        private Guna.UI2.WinForms.Guna2Button btnHistory;
        private Guna.UI2.WinForms.Guna2Button btnShopping;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel13;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel14;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel15;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel16;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel12;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel11;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel13;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel14;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel15;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel16;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel17;
        private Guna.UI2.WinForms.Guna2Button btnShopNow;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox11;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox10;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel18;
        private Guna.UI2.WinForms.Guna2Button btnOur_Location_HomePage;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel19;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel22;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel21;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel20;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel17;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox13;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox14;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel24;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel25;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel18;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox12;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel19;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel31;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel27;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel30;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel26;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel28;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel23;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel29;
        private Guna.UI2.WinForms.Guna2Button btnFeed_Back_HomePage;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel20;
        private Guna.UI2.WinForms.Guna2Button btnAbout_Us_HomePage;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel21;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel32;
        private Guna.UI2.WinForms.Guna2Button btnAttendant_HomePage;
        private Guna.UI2.WinForms.Guna2Button btnLocation_HomePage;
        private Guna.UI2.WinForms.Guna2Button btnBestSeller_HomePage;
        private Guna.UI2.WinForms.Guna2Button guna2Button22;
        private Guna.UI2.WinForms.Guna2Button guna2Button18;
        private Guna.UI2.WinForms.Guna2Button guna2Button21;
        private Guna.UI2.WinForms.Guna2Button guna2Button17;
        private Guna.UI2.WinForms.Guna2Button guna2Button20;
        private Guna.UI2.WinForms.Guna2Button guna2Button16;
        private Guna.UI2.WinForms.Guna2Button guna2Button19;
        private Guna.UI2.WinForms.Guna2Button guna2Button15;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel23;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel34;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel33;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel22;
        private Guna.UI2.WinForms.Guna2Button btnShoppingCart;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private Guna.UI2.WinForms.Guna2Button guna2Button7;
        private Guna.UI2.WinForms.Guna2Button guna2Button23;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblTimer;
        private Guna.UI2.WinForms.Guna2Button guna2Button36;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox16;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox15;
        private Guna.UI2.WinForms.Guna2Button btnAll;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel26;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel25;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel24;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel27;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel28;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel29;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel30;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel31;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel32;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel33;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel34;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel35;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel36;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel37;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel38;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel39;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel40;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel41;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel42;
        private User_Controls.Product uC_product1;
        private User_Controls.Product uC_product2;
        private User_Controls.Product uC_product3;
        private User_Controls.Product uC_product4;
        private User_Controls.Product uC_product5;
        private User_Controls.Product uC_product6;
        private User_Controls.Product uC_product7;
        private User_Controls.Product uC_product8;
        private User_Controls.Product uC_product9;
        private User_Controls.Product uC_product10;
        private User_Controls.Product uC_product11;
        private User_Controls.Product uC_product12;
        private User_Controls.Product uC_product13;
        private User_Controls.Product uC_product14;
        private User_Controls.Product uC_product15;
        private User_Controls.Product uC_product16;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel43;
        private Guna.UI2.WinForms.Guna2Button btnSecond_page;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel44;
        private Guna.UI2.WinForms.Guna2Button btnThird_page;
        private Guna.UI2.WinForms.Guna2CircleButton btnPage_Next;
        private Guna.UI2.WinForms.Guna2CircleButton btnPage_Back;
        private Guna.UI2.WinForms.Guna2Button btnFirst_page;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.FlowLayoutPanel flpPayment;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel45;
        private Guna.UI2.WinForms.Guna2Panel pnlPayment;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel47;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMoney_payment;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel35;
        private Guna.UI2.WinForms.Guna2Button btnOrderNow;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMoney_Sum;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMoney_SubTotal;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel37;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel38;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel36;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel39;
        private Guna.UI2.WinForms.Guna2Panel pnlBill;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel40;
        private Guna.UI2.WinForms.Guna2Panel pnlEmpty;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox17;
        private Guna.UI2.WinForms.Guna2Button btnShopNow_Cart;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2Button btnOrderNow_Bill;
        private System.Windows.Forms.TabPage tabPage6;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar1;
        private Guna.UI2.WinForms.Guna2Panel pnlShipper;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox18;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox19;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.FlowLayoutPanel flpShoppingCart;
        private Guna.UI2.WinForms.Guna2Panel pnlInformation;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel48;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel46;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblOrderCode;
        private System.Windows.Forms.Label lblExpected;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label label28;
        private Guna.UI2.WinForms.Guna2Button btnConfirm_Order;
        private System.Windows.Forms.Label lblTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblShip;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel41;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel42;
        private System.Windows.Forms.Label lblSum_Transport;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel pnlAddShoppingCart;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private Guna.UI2.WinForms.Guna2Panel pnlSaveLogin;
        private Guna.UI2.WinForms.Guna2Button btnNo;
        private Guna.UI2.WinForms.Guna2Button btnYes;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel43;
        private System.Windows.Forms.FlowLayoutPanel flpPageNavigation;
        private Guna.UI2.WinForms.Guna2CircleButton homePage2;
        private Guna.UI2.WinForms.Guna2CircleButton homePage4;
        private Guna.UI2.WinForms.Guna2CircleButton homePage1;
        private Guna.UI2.WinForms.Guna2CircleButton homePage3;
        private Guna.UI2.WinForms.Guna2CircleButton homePage5;
        private Guna.UI2.WinForms.Guna2Panel pnlhomePage;
        private FlowLayoutPanel flpCategories;
        private TabPage tabPage7;
        private Guna.UI2.WinForms.Guna2Panel pnlAccount;
        private Guna.UI2.WinForms.Guna2Button btnLogOut;
        private Guna.UI2.WinForms.Guna2Button btnChangePassword;
        private Guna.UI2.WinForms.Guna2Button btnOrder_Account;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel50;
        private Label label26;
        private FlowLayoutPanel flpAnotherAccount;
        private Guna.UI2.WinForms.Guna2Button btnAddAccount;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel49;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Label label27;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel51;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private FlowLayoutPanel flpHistory;
        private Guna.UI2.WinForms.Guna2Panel pnlEmpty_History;
        private Label label29;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox20;
        private Guna.UI2.WinForms.Guna2Button btnShopNow_History;
        private Guna.UI2.WinForms.Guna2Button btnUpload_Profile;
        private Guna.UI2.WinForms.Guna2PictureBox ptbImage_Profile;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel44;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel47;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel46;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel45;
        private Guna.UI2.WinForms.Guna2Button btnEditProfile;
        private Guna.UI2.WinForms.Guna2TextBox txtName_profile;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail_profile;
        private Guna.UI2.WinForms.Guna2TextBox txtDate_profile;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress_profile;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMode_Profile;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName_profile;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate_profile;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEmail_profile;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAddress_profile;
        private FlowLayoutPanel flpProduct;
        private Guna.UI2.WinForms.Guna2PictureBox ptbImage_Product;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox22;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRate_Product;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDescribe_Product;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName_Product;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblReviews_Product;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel52;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel53;
        private Guna.UI2.WinForms.Guna2PictureBox btnAccount;
        private Guna.UI2.WinForms.Guna2PictureBox ptbImage_BestSeller_Top1;
        private Guna.UI2.WinForms.Guna2PictureBox ptbImage_BestSeller_Top3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName_BestSeller_Top3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox24;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRate_BestSeller_Top3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblReviews_BestSeller_Top3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDescribe_BestSeller_Top3;
        private Guna.UI2.WinForms.Guna2PictureBox ptbImage_BestSeller_Top2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName_BestSeller_Top2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblReviews_BestSeller_Top2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDescribe_BestSeller_Top2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRate_BestSeller_Top2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox23;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel54;
        private Guna.UI2.WinForms.Guna2Button btnEditAccount_Account;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel55;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblName_Account;
        private Guna.UI2.WinForms.Guna2PictureBox ptbImage_Account;
    }
}