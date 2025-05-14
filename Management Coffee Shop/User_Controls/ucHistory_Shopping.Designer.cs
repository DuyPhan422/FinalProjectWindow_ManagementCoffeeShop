namespace Management_Coffee_Shop.User_Controls
{
    partial class ucHistory_Shopping
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
            this.lblCode = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.flpProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRepurchase = new Guna.UI2.WinForms.Guna2Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSum = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            this.flpProduct.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(15, 4);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(71, 25);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "COde";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.AutoSize = true;
            this.guna2Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.guna2Panel1.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.guna2Panel4);
            this.guna2Panel1.Controls.Add(this.flpProduct);
            this.guna2Panel1.Controls.Add(this.lblDate);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.lblCode);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1015, 209);
            this.guna2Panel1.TabIndex = 1;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Location = new System.Drawing.Point(997, 39);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(15, 100);
            this.guna2Panel4.TabIndex = 6;
            // 
            // flpProduct
            // 
            this.flpProduct.AutoSize = true;
            this.flpProduct.Controls.Add(this.guna2Panel3);
            this.flpProduct.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpProduct.Location = new System.Drawing.Point(17, 71);
            this.flpProduct.Name = "flpProduct";
            this.flpProduct.Size = new System.Drawing.Size(971, 135);
            this.flpProduct.TabIndex = 5;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.btnRepurchase);
            this.guna2Panel3.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(965, 32);
            this.guna2Panel3.TabIndex = 7;
            // 
            // btnRepurchase
            // 
            this.btnRepurchase.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnRepurchase.BorderRadius = 8;
            this.btnRepurchase.BorderThickness = 1;
            this.btnRepurchase.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRepurchase.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRepurchase.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRepurchase.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRepurchase.FillColor = System.Drawing.Color.Transparent;
            this.btnRepurchase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRepurchase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.btnRepurchase.Location = new System.Drawing.Point(844, 3);
            this.btnRepurchase.Name = "btnRepurchase";
            this.btnRepurchase.Size = new System.Drawing.Size(108, 27);
            this.btnRepurchase.TabIndex = 4;
            this.btnRepurchase.Text = "Repurchase";
            this.btnRepurchase.Click += new System.EventHandler(this.btnRepurchase_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(824, 4);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(70, 25);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "label2";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2Panel2.BorderRadius = 7;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.lblSum);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel2.Controls.Add(this.lblStatus);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(17, 32);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(971, 32);
            this.guna2Panel2.TabIndex = 1;
            // 
            // lblSum
            // 
            this.lblSum.BackColor = System.Drawing.Color.Transparent;
            this.lblSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblSum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblSum.Location = new System.Drawing.Point(797, 3);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(171, 27);
            this.lblSum.TabIndex = 2;
            this.lblSum.Text = "guna2HtmlLabel2";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(739, 3);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(52, 27);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Sum: ";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.lblStatus.Location = new System.Drawing.Point(3, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(158, 27);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status: Success";
            // 
            // ucHistory_Shopping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ucHistory_Shopping";
            this.Size = new System.Drawing.Size(1018, 212);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.flpProduct.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCode;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSum;
        private System.Windows.Forms.FlowLayoutPanel flpProduct;
        private Guna.UI2.WinForms.Guna2Button btnRepurchase;
        private System.Windows.Forms.Label lblDate;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
    }
}
