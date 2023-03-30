namespace TripleXManagement.ChildForm.Table
{
    partial class TableManagement
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
            this.pnFooter = new System.Windows.Forms.Panel();
            this.btnManagement = new TripleXManagement.CustomControl.RJButton();
            this.pnMain = new System.Windows.Forms.Panel();
            this.flpBookTable = new System.Windows.Forms.FlowLayoutPanel();
            this.pnFilter = new System.Windows.Forms.Panel();
            this.txtSearch = new TripleXManagement.CustomControl.Textbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbAllKind = new TripleXManagement.CustomControl.CRadioButton();
            this.rbNormal = new TripleXManagement.CustomControl.CRadioButton();
            this.rbMid = new TripleXManagement.CustomControl.CRadioButton();
            this.rbBig = new TripleXManagement.CustomControl.CRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbNullTable = new TripleXManagement.CustomControl.CRadioButton();
            this.rbToday = new TripleXManagement.CustomControl.CRadioButton();
            this.rbOrderTable = new TripleXManagement.CustomControl.CRadioButton();
            this.btnFilter = new TripleXManagement.CustomControl.RJButton();
            this.pnFooter.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.pnFilter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.pnFooter.Controls.Add(this.btnManagement);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 505);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(921, 50);
            this.pnFooter.TabIndex = 0;
            // 
            // btnManagement
            // 
            this.btnManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnManagement.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnManagement.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnManagement.BorderRadius = 20;
            this.btnManagement.BorderSize = 2;
            this.btnManagement.FlatAppearance.BorderSize = 0;
            this.btnManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnManagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnManagement.Image = global::TripleXManagement.Properties.Resources.Add_properties_20px;
            this.btnManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagement.Location = new System.Drawing.Point(770, 5);
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnManagement.Size = new System.Drawing.Size(134, 40);
            this.btnManagement.TabIndex = 0;
            this.btnManagement.Text = "Thêm Bàn";
            this.btnManagement.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManagement.UseVisualStyleBackColor = false;
            this.btnManagement.Click += new System.EventHandler(this.btnManagement_Click);
            this.btnManagement.MouseEnter += new System.EventHandler(this.btnManagement_MouseEnter);
            this.btnManagement.MouseLeave += new System.EventHandler(this.btnManagement_MouseLeave);
            // 
            // pnMain
            // 
            this.pnMain.AutoScroll = true;
            this.pnMain.Controls.Add(this.flpBookTable);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(687, 505);
            this.pnMain.TabIndex = 6;
            // 
            // flpBookTable
            // 
            this.flpBookTable.AutoScroll = true;
            this.flpBookTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.flpBookTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBookTable.Location = new System.Drawing.Point(0, 0);
            this.flpBookTable.Name = "flpBookTable";
            this.flpBookTable.Size = new System.Drawing.Size(687, 505);
            this.flpBookTable.TabIndex = 0;
            // 
            // pnFilter
            // 
            this.pnFilter.Controls.Add(this.txtSearch);
            this.pnFilter.Controls.Add(this.panel1);
            this.pnFilter.Controls.Add(this.label2);
            this.pnFilter.Controls.Add(this.label1);
            this.pnFilter.Controls.Add(this.rbNullTable);
            this.pnFilter.Controls.Add(this.rbToday);
            this.pnFilter.Controls.Add(this.rbOrderTable);
            this.pnFilter.Controls.Add(this.btnFilter);
            this.pnFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnFilter.Location = new System.Drawing.Point(687, 0);
            this.pnFilter.Name = "pnFilter";
            this.pnFilter.Size = new System.Drawing.Size(234, 505);
            this.pnFilter.TabIndex = 7;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.txtSearch.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.txtSearch.BorderRadius = 0;
            this.txtSearch.BorderSize = 2;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.txtSearch.Location = new System.Drawing.Point(17, 39);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSearch.PasswordChar = false;
            this.txtSearch.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txtSearch.PlaceholderText = "Tìm kiếm...";
            this.txtSearch.Size = new System.Drawing.Size(202, 35);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.Texts = "";
            this.txtSearch.UnderlinedStyle = true;
            this.txtSearch._TextChanged += new System.EventHandler(this.txtSearch__TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.rbAllKind);
            this.panel1.Controls.Add(this.rbNormal);
            this.panel1.Controls.Add(this.rbMid);
            this.panel1.Controls.Add(this.rbBig);
            this.panel1.Location = new System.Drawing.Point(20, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 152);
            this.panel1.TabIndex = 4;
            // 
            // rbAllKind
            // 
            this.rbAllKind.AutoSize = true;
            this.rbAllKind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbAllKind.Checked = true;
            this.rbAllKind.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.rbAllKind.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbAllKind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbAllKind.Location = new System.Drawing.Point(15, 3);
            this.rbAllKind.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbAllKind.Name = "rbAllKind";
            this.rbAllKind.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbAllKind.Size = new System.Drawing.Size(77, 23);
            this.rbAllKind.TabIndex = 0;
            this.rbAllKind.TabStop = true;
            this.rbAllKind.Text = "Tất cả";
            this.rbAllKind.UnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbAllKind.UseVisualStyleBackColor = false;
            this.rbAllKind.CheckedChanged += new System.EventHandler(this.rbAllKind_CheckedChanged);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbNormal.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.rbNormal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbNormal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbNormal.Location = new System.Drawing.Point(14, 39);
            this.rbNormal.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbNormal.Size = new System.Drawing.Size(88, 23);
            this.rbNormal.TabIndex = 1;
            this.rbNormal.Text = "Thường";
            this.rbNormal.UnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbNormal.UseVisualStyleBackColor = false;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.rbNormal_CheckedChanged);
            // 
            // rbMid
            // 
            this.rbMid.AutoSize = true;
            this.rbMid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbMid.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.rbMid.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbMid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbMid.Location = new System.Drawing.Point(14, 78);
            this.rbMid.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbMid.Name = "rbMid";
            this.rbMid.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbMid.Size = new System.Drawing.Size(63, 23);
            this.rbMid.TabIndex = 2;
            this.rbMid.Text = "Vừa";
            this.rbMid.UnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbMid.UseVisualStyleBackColor = false;
            this.rbMid.CheckedChanged += new System.EventHandler(this.rbMid_CheckedChanged);
            // 
            // rbBig
            // 
            this.rbBig.AutoSize = true;
            this.rbBig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbBig.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.rbBig.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbBig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbBig.Location = new System.Drawing.Point(14, 116);
            this.rbBig.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbBig.Name = "rbBig";
            this.rbBig.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbBig.Size = new System.Drawing.Size(53, 23);
            this.rbBig.TabIndex = 3;
            this.rbBig.Text = "To";
            this.rbBig.UnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbBig.UseVisualStyleBackColor = false;
            this.rbBig.CheckedChanged += new System.EventHandler(this.rbBig_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.label2.Location = new System.Drawing.Point(20, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại bàn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.label1.Location = new System.Drawing.Point(20, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trạng Thái";
            // 
            // rbNullTable
            // 
            this.rbNullTable.AutoSize = true;
            this.rbNullTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbNullTable.Checked = true;
            this.rbNullTable.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.rbNullTable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbNullTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbNullTable.Location = new System.Drawing.Point(35, 146);
            this.rbNullTable.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbNullTable.Name = "rbNullTable";
            this.rbNullTable.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbNullTable.Size = new System.Drawing.Size(107, 23);
            this.rbNullTable.TabIndex = 1;
            this.rbNullTable.TabStop = true;
            this.rbNullTable.Text = "Bàn  trống";
            this.rbNullTable.UnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbNullTable.UseVisualStyleBackColor = false;
            this.rbNullTable.CheckedChanged += new System.EventHandler(this.rbNullTable_CheckedChanged);
            // 
            // rbToday
            // 
            this.rbToday.AutoSize = true;
            this.rbToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbToday.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.rbToday.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbToday.Location = new System.Drawing.Point(34, 218);
            this.rbToday.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbToday.Name = "rbToday";
            this.rbToday.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbToday.Size = new System.Drawing.Size(163, 23);
            this.rbToday.TabIndex = 3;
            this.rbToday.Text = "Hôm nay nhận bàn";
            this.rbToday.UnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbToday.UseVisualStyleBackColor = false;
            this.rbToday.CheckedChanged += new System.EventHandler(this.rbToday_CheckedChanged);
            // 
            // rbOrderTable
            // 
            this.rbOrderTable.AutoSize = true;
            this.rbOrderTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbOrderTable.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.rbOrderTable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbOrderTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbOrderTable.Location = new System.Drawing.Point(35, 182);
            this.rbOrderTable.MinimumSize = new System.Drawing.Size(0, 21);
            this.rbOrderTable.Name = "rbOrderTable";
            this.rbOrderTable.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rbOrderTable.Size = new System.Drawing.Size(109, 23);
            this.rbOrderTable.TabIndex = 2;
            this.rbOrderTable.Text = "Bàn đã đặt";
            this.rbOrderTable.UnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.rbOrderTable.UseVisualStyleBackColor = false;
            this.rbOrderTable.CheckedChanged += new System.EventHandler(this.rbOrderTable_CheckedChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFilter.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFilter.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnFilter.BorderRadius = 15;
            this.btnFilter.BorderSize = 0;
            this.btnFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFilter.Enabled = false;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.ForeColor = System.Drawing.Color.Turquoise;
            this.btnFilter.Location = new System.Drawing.Point(0, 0);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(234, 505);
            this.btnFilter.TabIndex = 0;
            this.btnFilter.TextColor = System.Drawing.Color.Turquoise;
            this.btnFilter.UseVisualStyleBackColor = false;
            // 
            // TableManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(921, 555);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnFilter);
            this.Controls.Add(this.pnFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TableManagement";
            this.Text = "TableManagement";
            this.Load += new System.EventHandler(this.TableManagement_Load);
            this.pnFooter.ResumeLayout(false);
            this.pnMain.ResumeLayout(false);
            this.pnFilter.ResumeLayout(false);
            this.pnFilter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnFooter;
        private CustomControl.RJButton btnManagement;
        private CustomControl.CRadioButton rdTable;
        private Panel pnMain;
        private FlowLayoutPanel flpBookTable;
        private Panel pnFilter;
        private Label label1;
        private CustomControl.CRadioButton rbNullTable;
        private CustomControl.CRadioButton rbOrderTable;
        private Label label2;
        private CustomControl.CRadioButton rbAllKind;
        private CustomControl.CRadioButton rbBig;
        private CustomControl.CRadioButton rbMid;
        private CustomControl.CRadioButton rbNormal;
        private CustomControl.RJButton btnFilter;
        private Panel panel1;
        private CustomControl.CRadioButton rbToday;
        private CustomControl.Textbox txtSearch;
    }
}