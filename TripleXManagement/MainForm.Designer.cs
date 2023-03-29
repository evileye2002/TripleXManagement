namespace TripleXManagement
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnMenu = new System.Windows.Forms.Panel();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.bntTable = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnFoodDrink = new System.Windows.Forms.Button();
            this.btnBill = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.lbLogo2 = new System.Windows.Forms.Label();
            this.lbLogo1 = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnMain = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnTitle.SuspendLayout();
            this.pnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnMenu.Controls.Add(this.btnCustomer);
            this.pnMenu.Controls.Add(this.bntTable);
            this.pnMenu.Controls.Add(this.btnLogout);
            this.pnMenu.Controls.Add(this.btnAccount);
            this.pnMenu.Controls.Add(this.btnStaff);
            this.pnMenu.Controls.Add(this.btnFoodDrink);
            this.pnMenu.Controls.Add(this.btnBill);
            this.pnMenu.Controls.Add(this.panel2);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.Location = new System.Drawing.Point(0, 0);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(205, 516);
            this.pnMenu.TabIndex = 0;
            // 
            // btnCustomer
            // 
            this.btnCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCustomer.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCustomer.Image = global::TripleXManagement.Properties.Resources.coffee_table_32px;
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.Location = new System.Drawing.Point(0, 296);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCustomer.Size = new System.Drawing.Size(205, 50);
            this.btnCustomer.TabIndex = 7;
            this.btnCustomer.Tag = "Khách hàng";
            this.btnCustomer.Text = "Khách hàng";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // bntTable
            // 
            this.bntTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.bntTable.FlatAppearance.BorderSize = 0;
            this.bntTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntTable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bntTable.ForeColor = System.Drawing.SystemColors.Control;
            this.bntTable.Image = global::TripleXManagement.Properties.Resources.coffee_table_32px;
            this.bntTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntTable.Location = new System.Drawing.Point(0, 246);
            this.bntTable.Name = "bntTable";
            this.bntTable.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.bntTable.Size = new System.Drawing.Size(205, 50);
            this.bntTable.TabIndex = 6;
            this.bntTable.Tag = "Bàn ăn";
            this.bntTable.Text = "Bàn ăn";
            this.bntTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bntTable.UseVisualStyleBackColor = true;
            this.bntTable.Click += new System.EventHandler(this.bntTable_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLogout.Image = global::TripleXManagement.Properties.Resources.Logout_32;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 466);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 15);
            this.btnLogout.Size = new System.Drawing.Size(205, 50);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Tag = "Đăng xuất";
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAccount.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAccount.Image = global::TripleXManagement.Properties.Resources.Male_user_32;
            this.btnAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.Location = new System.Drawing.Point(0, 196);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAccount.Size = new System.Drawing.Size(205, 50);
            this.btnAccount.TabIndex = 4;
            this.btnAccount.Tag = "Tài khoản";
            this.btnAccount.Text = "Tài khoản";
            this.btnAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStaff.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStaff.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStaff.Image = global::TripleXManagement.Properties.Resources.staff_32;
            this.btnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.Location = new System.Drawing.Point(0, 146);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStaff.Size = new System.Drawing.Size(205, 50);
            this.btnStaff.TabIndex = 3;
            this.btnStaff.Tag = "Nhân viên";
            this.btnStaff.Text = "Nhân viên";
            this.btnStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnFoodDrink
            // 
            this.btnFoodDrink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoodDrink.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFoodDrink.FlatAppearance.BorderSize = 0;
            this.btnFoodDrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFoodDrink.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFoodDrink.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFoodDrink.Image = global::TripleXManagement.Properties.Resources.Cutlery_32;
            this.btnFoodDrink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFoodDrink.Location = new System.Drawing.Point(0, 96);
            this.btnFoodDrink.Name = "btnFoodDrink";
            this.btnFoodDrink.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFoodDrink.Size = new System.Drawing.Size(205, 50);
            this.btnFoodDrink.TabIndex = 2;
            this.btnFoodDrink.Tag = "Đồ ăn && uống";
            this.btnFoodDrink.Text = "Đồ ăn && uống";
            this.btnFoodDrink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFoodDrink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFoodDrink.UseVisualStyleBackColor = true;
            this.btnFoodDrink.Click += new System.EventHandler(this.btnFoodDrink_Click);
            // 
            // btnBill
            // 
            this.btnBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBill.FlatAppearance.BorderSize = 0;
            this.btnBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBill.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBill.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBill.Image = global::TripleXManagement.Properties.Resources.bill_32;
            this.btnBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBill.Location = new System.Drawing.Point(0, 46);
            this.btnBill.Name = "btnBill";
            this.btnBill.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBill.Size = new System.Drawing.Size(205, 50);
            this.btnBill.TabIndex = 1;
            this.btnBill.Tag = "Thanh toán";
            this.btnBill.Text = "Thanh toán";
            this.btnBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel2.Controls.Add(this.btnMenu);
            this.panel2.Controls.Add(this.lbLogo2);
            this.panel2.Controls.Add(this.lbLogo1);
            this.panel2.Controls.Add(this.pbLogo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 46);
            this.panel2.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Image = global::TripleXManagement.Properties.Resources.menu_32;
            this.btnMenu.Location = new System.Drawing.Point(168, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(32, 46);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // lbLogo2
            // 
            this.lbLogo2.AutoSize = true;
            this.lbLogo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbLogo2.ForeColor = System.Drawing.SystemColors.Control;
            this.lbLogo2.Location = new System.Drawing.Point(74, 26);
            this.lbLogo2.Name = "lbLogo2";
            this.lbLogo2.Size = new System.Drawing.Size(63, 15);
            this.lbLogo2.TabIndex = 1;
            this.lbLogo2.Text = "Restaurant";
            // 
            // lbLogo1
            // 
            this.lbLogo1.AutoSize = true;
            this.lbLogo1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbLogo1.ForeColor = System.Drawing.SystemColors.Control;
            this.lbLogo1.Location = new System.Drawing.Point(74, 6);
            this.lbLogo1.Name = "lbLogo1";
            this.lbLogo1.Size = new System.Drawing.Size(88, 25);
            this.lbLogo1.TabIndex = 1;
            this.lbLogo1.Text = "TRIPLE X";
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::TripleXManagement.Properties.Resources.logo4;
            this.pbLogo.Location = new System.Drawing.Point(5, 5);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(60, 44);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // pnTitle
            // 
            this.pnTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.pnTitle.Controls.Add(this.lbTitle);
            this.pnTitle.Controls.Add(this.btnMinimize);
            this.pnTitle.Controls.Add(this.btnMaximize);
            this.pnTitle.Controls.Add(this.btnCloseChildForm);
            this.pnTitle.Controls.Add(this.btnClose);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(205, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(700, 46);
            this.pnTitle.TabIndex = 2;
            this.pnTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTitle_MouseDown);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.lbTitle.Location = new System.Drawing.Point(77, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(0, 25);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::TripleXManagement.Properties.Resources.icons8_subtract_261;
            this.btnMinimize.Location = new System.Drawing.Point(604, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnMinimize.Size = new System.Drawing.Size(32, 46);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Image = global::TripleXManagement.Properties.Resources.icons8_maximize_button_26__1_;
            this.btnMaximize.Location = new System.Drawing.Point(636, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(32, 46);
            this.btnMaximize.TabIndex = 2;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.btnCloseChildForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseChildForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.Image = global::TripleXManagement.Properties.Resources.Close_26;
            this.btnCloseChildForm.Location = new System.Drawing.Point(0, 0);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(32, 46);
            this.btnCloseChildForm.TabIndex = 0;
            this.btnCloseChildForm.UseVisualStyleBackColor = false;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::TripleXManagement.Properties.Resources.Close_26;
            this.btnClose.Location = new System.Drawing.Point(668, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 46);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnMain.Controls.Add(this.pictureBox1);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(205, 46);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(700, 470);
            this.pnMain.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::TripleXManagement.Properties.Resources.LogoMid;
            this.pictureBox1.Location = new System.Drawing.Point(161, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(383, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 516);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.pnMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(920, 555);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.pnMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            this.pnMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnMenu;
        private Button btnBill;
        private Panel panel2;
        private PictureBox pbLogo;
        private Label lbLogo1;
        private Label lbLogo2;
        private Button btnMenu;
        private Button btnLogout;
        private Button btnAccount;
        private Button btnStaff;
        private Button btnFoodDrink;
        private Panel pnTitle;
        private Button btnMinimize;
        private Button btnMaximize;
        private Button btnClose;
        private Panel pnMain;
        private Label lbTitle;
        private Button btnCloseChildForm;
        private PictureBox pictureBox1;
        private Button bntTable;
        private Button btnCustomer;
    }
}