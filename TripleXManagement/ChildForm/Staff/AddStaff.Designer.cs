namespace TripleXManagement.ChildForm.Staff
{
    partial class AddStaff
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
            this.pbPic = new System.Windows.Forms.PictureBox();
            this.txtCCCD = new TripleXManagement.CustomControl.Textbox();
            this.txtName = new TripleXManagement.CustomControl.Textbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDenied = new TripleXManagement.CustomControl.RJButton();
            this.btnSave = new TripleXManagement.CustomControl.RJButton();
            this.btnBrowse = new TripleXManagement.CustomControl.RJButton();
            this.txtPhone = new TripleXManagement.CustomControl.Textbox();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.cbRegency = new TripleXManagement.CustomControl.CComboBox();
            this.cbAccount = new TripleXManagement.CustomControl.CComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPic
            // 
            this.pbPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPic.Location = new System.Drawing.Point(12, 12);
            this.pbPic.Name = "pbPic";
            this.pbPic.Size = new System.Drawing.Size(320, 320);
            this.pbPic.TabIndex = 1;
            this.pbPic.TabStop = false;
            // 
            // txtCCCD
            // 
            this.txtCCCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtCCCD.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.txtCCCD.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.txtCCCD.BorderRadius = 0;
            this.txtCCCD.BorderSize = 2;
            this.txtCCCD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCCCD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.txtCCCD.Location = new System.Drawing.Point(351, 70);
            this.txtCCCD.Multiline = true;
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCCCD.PasswordChar = false;
            this.txtCCCD.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txtCCCD.PlaceholderText = "CCCD...";
            this.txtCCCD.Size = new System.Drawing.Size(437, 42);
            this.txtCCCD.TabIndex = 4;
            this.txtCCCD.Texts = "";
            this.txtCCCD.UnderlinedStyle = false;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.txtName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.txtName.BorderRadius = 0;
            this.txtName.BorderSize = 2;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.txtName.Location = new System.Drawing.Point(351, 12);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtName.PasswordChar = false;
            this.txtName.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txtName.PlaceholderText = "Họ và Tên...";
            this.txtName.Size = new System.Drawing.Size(437, 42);
            this.txtName.TabIndex = 5;
            this.txtName.Texts = "";
            this.txtName.UnderlinedStyle = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.btnDenied);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 505);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 50);
            this.panel1.TabIndex = 6;
            // 
            // btnDenied
            // 
            this.btnDenied.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDenied.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDenied.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnDenied.BorderRadius = 20;
            this.btnDenied.BorderSize = 2;
            this.btnDenied.FlatAppearance.BorderSize = 0;
            this.btnDenied.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDenied.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDenied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnDenied.Image = global::TripleXManagement.Properties.Resources.denied_20px;
            this.btnDenied.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDenied.Location = new System.Drawing.Point(285, 5);
            this.btnDenied.Name = "btnDenied";
            this.btnDenied.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnDenied.Size = new System.Drawing.Size(40, 40);
            this.btnDenied.TabIndex = 13;
            this.btnDenied.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnDenied.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDenied.UseVisualStyleBackColor = false;
            this.btnDenied.Click += new System.EventHandler(this.btnDenied_Click);
            this.btnDenied.MouseEnter += new System.EventHandler(this.btnDenied_MouseEnter);
            this.btnDenied.MouseLeave += new System.EventHandler(this.btnDenied_MouseLeave);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnSave.BorderRadius = 20;
            this.btnSave.BorderSize = 2;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnSave.Image = global::TripleXManagement.Properties.Resources.database_administrator_20px1;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(170, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Lưu";
            this.btnSave.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrowse.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrowse.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnBrowse.BorderRadius = 20;
            this.btnBrowse.BorderSize = 2;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnBrowse.Image = global::TripleXManagement.Properties.Resources.database_administrator_20px1;
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.Location = new System.Drawing.Point(20, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBrowse.Size = new System.Drawing.Size(135, 40);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "Chọn Ảnh";
            this.btnBrowse.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            this.btnBrowse.MouseEnter += new System.EventHandler(this.btnBrowse_MouseEnter);
            this.btnBrowse.MouseLeave += new System.EventHandler(this.btnBrowse_MouseLeave);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtPhone.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.txtPhone.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.txtPhone.BorderRadius = 0;
            this.txtPhone.BorderSize = 2;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.txtPhone.Location = new System.Drawing.Point(351, 136);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPhone.PasswordChar = false;
            this.txtPhone.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txtPhone.PlaceholderText = "Số điện thoại...";
            this.txtPhone.Size = new System.Drawing.Size(437, 42);
            this.txtPhone.TabIndex = 5;
            this.txtPhone.Texts = "";
            this.txtPhone.UnderlinedStyle = false;
            // 
            // ofdBrowse
            // 
            this.ofdBrowse.FileName = "openFileDialog1";
            // 
            // cbRegency
            // 
            this.cbRegency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbRegency.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.cbRegency.BorderSize = 2;
            this.cbRegency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbRegency.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbRegency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.cbRegency.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.cbRegency.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.cbRegency.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbRegency.Location = new System.Drawing.Point(351, 203);
            this.cbRegency.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbRegency.Name = "cbRegency";
            this.cbRegency.Padding = new System.Windows.Forms.Padding(2);
            this.cbRegency.Size = new System.Drawing.Size(200, 39);
            this.cbRegency.TabIndex = 8;
            this.cbRegency.Texts = "";
            // 
            // cbAccount
            // 
            this.cbAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbAccount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.cbAccount.BorderSize = 2;
            this.cbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.cbAccount.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.cbAccount.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.cbAccount.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbAccount.Location = new System.Drawing.Point(588, 203);
            this.cbAccount.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbAccount.Name = "cbAccount";
            this.cbAccount.Padding = new System.Windows.Forms.Padding(2);
            this.cbAccount.Size = new System.Drawing.Size(200, 39);
            this.cbAccount.TabIndex = 8;
            this.cbAccount.Texts = "";
            // 
            // AddStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(921, 555);
            this.Controls.Add(this.cbAccount);
            this.Controls.Add(this.cbRegency);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.pbPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddStaff";
            this.Text = "AddStaff";
            this.Load += new System.EventHandler(this.AddStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pbPic;
        private CustomControl.Textbox txtCCCD;
        private CustomControl.Textbox txtName;
        private Panel panel1;
        private CustomControl.RJButton btnSave;
        private CustomControl.RJButton btnBrowse;
        private CustomControl.Textbox txtPhone;
        private OpenFileDialog ofdBrowse;
        private CustomControl.RJButton btnDenied;
        private CustomControl.CComboBox cbRegency;
        private CustomControl.CComboBox cbAccount;
    }
}