namespace TripleXManagement.ChildForm.Table
{
    partial class Form1
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnBody = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbCustomer = new System.Windows.Forms.Label();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lbChair = new System.Windows.Forms.Label();
            this.lbBookDate = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnHeader.SuspendLayout();
            this.pnFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnBody);
            this.panel1.Controls.Add(this.pnHeader);
            this.panel1.Controls.Add(this.pnFooter);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 150);
            this.panel1.TabIndex = 0;
            // 
            // pnBody
            // 
            this.pnBody.BackColor = System.Drawing.Color.Gray;
            this.pnBody.Controls.Add(this.pictureBox1);
            this.pnBody.Controls.Add(this.lbCustomer);
            this.pnBody.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBody.Location = new System.Drawing.Point(0, 30);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(250, 90);
            this.pnBody.TabIndex = 2;
            this.pnBody.Click += new System.EventHandler(this.pnBody_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(33, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbCustomer
            // 
            this.lbCustomer.AutoSize = true;
            this.lbCustomer.Location = new System.Drawing.Point(203, 98);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(38, 15);
            this.lbCustomer.TabIndex = 0;
            this.lbCustomer.Text = "label1";
            this.lbCustomer.Click += new System.EventHandler(this.lbCustomer_Click);
            // 
            // pnHeader
            // 
            this.pnHeader.Controls.Add(this.lbStatus);
            this.pnHeader.Controls.Add(this.lbName);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(250, 30);
            this.pnHeader.TabIndex = 1;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(294, 32);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(38, 15);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "label1";
            this.lbStatus.Click += new System.EventHandler(this.lbCustomer_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(33, 32);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(38, 15);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "label1";
            this.lbName.Click += new System.EventHandler(this.lbCustomer_Click);
            // 
            // pnFooter
            // 
            this.pnFooter.Controls.Add(this.lbChair);
            this.pnFooter.Controls.Add(this.lbBookDate);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 120);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(250, 30);
            this.pnFooter.TabIndex = 0;
            // 
            // lbChair
            // 
            this.lbChair.AutoSize = true;
            this.lbChair.Location = new System.Drawing.Point(303, 30);
            this.lbChair.Name = "lbChair";
            this.lbChair.Size = new System.Drawing.Size(38, 15);
            this.lbChair.TabIndex = 0;
            this.lbChair.Text = "label1";
            // 
            // lbBookDate
            // 
            this.lbBookDate.AutoSize = true;
            this.lbBookDate.Location = new System.Drawing.Point(49, 30);
            this.lbBookDate.Name = "lbBookDate";
            this.lbBookDate.Size = new System.Drawing.Size(38, 15);
            this.lbBookDate.TabIndex = 0;
            this.lbBookDate.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnBody.ResumeLayout(false);
            this.pnBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Panel pnBody;
        private PictureBox pictureBox1;
        private Label lbCustomer;
        private Panel pnHeader;
        private Panel pnFooter;
        private Label lbChair;
        private Label lbBookDate;
        private Label lbStatus;
        private Label lbName;
    }
}