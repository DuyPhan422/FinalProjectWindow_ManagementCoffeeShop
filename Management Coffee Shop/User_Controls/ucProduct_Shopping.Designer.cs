namespace Management_Coffee_Shop.User_Controls
{
    partial class ucProduct_Shopping
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptbImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblName_Product = new System.Windows.Forms.Label();
            this.lblDescribe = new System.Windows.Forms.Label();
            this.lblQTV = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbImage
            // 
            this.ptbImage.BackColor = System.Drawing.Color.Transparent;
            this.ptbImage.FillColor = System.Drawing.Color.Transparent;
            this.ptbImage.ImageRotate = 0F;
            this.ptbImage.Location = new System.Drawing.Point(0, 0);
            this.ptbImage.Name = "ptbImage";
            this.ptbImage.Size = new System.Drawing.Size(155, 155);
            this.ptbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbImage.TabIndex = 0;
            this.ptbImage.TabStop = false;
            // 
            // lblName_Product
            // 
            this.lblName_Product.AutoSize = true;
            this.lblName_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName_Product.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblName_Product.Location = new System.Drawing.Point(166, 0);
            this.lblName_Product.Name = "lblName_Product";
            this.lblName_Product.Size = new System.Drawing.Size(139, 37);
            this.lblName_Product.TabIndex = 1;
            this.lblName_Product.Text = "Trà Sữa";
            // 
            // lblDescribe
            // 
            this.lblDescribe.AutoSize = true;
            this.lblDescribe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescribe.Location = new System.Drawing.Point(171, 40);
            this.lblDescribe.Name = "lblDescribe";
            this.lblDescribe.Size = new System.Drawing.Size(88, 25);
            this.lblDescribe.TabIndex = 1;
            this.lblDescribe.Text = "Trà Sữa";
            // 
            // lblQTV
            // 
            this.lblQTV.AutoSize = true;
            this.lblQTV.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblQTV.Location = new System.Drawing.Point(682, 74);
            this.lblQTV.Name = "lblQTV";
            this.lblQTV.Size = new System.Drawing.Size(70, 25);
            this.lblQTV.TabIndex = 2;
            this.lblQTV.Text = "label1";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblPrice.Location = new System.Drawing.Point(857, 74);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(90, 25);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "15.000đ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label3.Location = new System.Drawing.Point(790, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "X";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 158);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(950, 3);
            this.guna2Panel1.TabIndex = 4;
            // 
            // ucProduct_Shopping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.ptbImage);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblQTV);
            this.Controls.Add(this.lblDescribe);
            this.Controls.Add(this.lblName_Product);
            this.Name = "ucProduct_Shopping";
            this.Size = new System.Drawing.Size(950, 160);
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox ptbImage;
        private System.Windows.Forms.Label lblName_Product;
        private System.Windows.Forms.Label lblDescribe;
        private System.Windows.Forms.Label lblQTV;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
