namespace TripleXManagement.ChildForm.Table
{
    partial class CTable
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.lbChair = new System.Windows.Forms.Label();
            this.lbCustomer = new System.Windows.Forms.Label();
            this.cButton1 = new TripleXManagement.CustomControl.CButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 30);
            this.panel1.TabIndex = 0;
            // 
            // lbStatus
            // 
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbStatus.Location = new System.Drawing.Point(70, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lbStatus.Size = new System.Drawing.Size(180, 30);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "Table Status";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbName
            // 
            this.lbName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbName.Location = new System.Drawing.Point(0, 0);
            this.lbName.Name = "lbName";
            this.lbName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbName.Size = new System.Drawing.Size(70, 30);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "B000";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbOrderDate);
            this.panel2.Controls.Add(this.lbChair);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 30);
            this.panel2.TabIndex = 1;
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.BackColor = System.Drawing.Color.LightGray;
            this.lbOrderDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOrderDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbOrderDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbOrderDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.lbOrderDate.Location = new System.Drawing.Point(0, 0);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbOrderDate.Size = new System.Drawing.Size(180, 30);
            this.lbOrderDate.TabIndex = 0;
            this.lbOrderDate.Text = "Ngày 13/4/2023";
            this.lbOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbChair
            // 
            this.lbChair.BackColor = System.Drawing.Color.LightGray;
            this.lbChair.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbChair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbChair.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbChair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.lbChair.Location = new System.Drawing.Point(180, 0);
            this.lbChair.Name = "lbChair";
            this.lbChair.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lbChair.Size = new System.Drawing.Size(70, 30);
            this.lbChair.TabIndex = 1;
            this.lbChair.Text = "Chair";
            this.lbChair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCustomer
            // 
            this.lbCustomer.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCustomer.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbCustomer.Location = new System.Drawing.Point(65, 30);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(185, 90);
            this.lbCustomer.TabIndex = 2;
            this.lbCustomer.Text = "Customer";
            this.lbCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbCustomer.Click += new System.EventHandler(this.lbCustomer_Click);
            // 
            // cButton1
            // 
            this.cButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.cButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.cButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cButton1.BorderRadius = 0;
            this.cButton1.BorderSize = 0;
            this.cButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cButton1.Enabled = false;
            this.cButton1.FlatAppearance.BorderSize = 0;
            this.cButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cButton1.ForeColor = System.Drawing.Color.White;
            this.cButton1.Image = global::TripleXManagement.Properties.Resources.coffee_table_32px;
            this.cButton1.Location = new System.Drawing.Point(0, 30);
            this.cButton1.Name = "cButton1";
            this.cButton1.Size = new System.Drawing.Size(65, 90);
            this.cButton1.TabIndex = 3;
            this.cButton1.TextColor = System.Drawing.Color.White;
            this.cButton1.UseVisualStyleBackColor = false;
            // 
            // CTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.Controls.Add(this.cButton1);
            this.Controls.Add(this.lbCustomer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Name = "CTable";
            this.Size = new System.Drawing.Size(250, 150);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lbStatus;
        private Label lbName;
        private Label lbChair;
        private Label lbOrderDate;
        private Label lbCustomer;
        private CustomControl.CButton cButton1;
    }
}
