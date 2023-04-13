namespace TripleXManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cFoodImage1 = new TripleXManagement.ChildForm.Bill.CFoodImage();
            this.cTable1 = new TripleXManagement.ChildForm.Table.CTable();
            this.SuspendLayout();
            // 
            // cFoodImage1
            // 
            this.cFoodImage1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cFoodImage1.FoodID = "1";
            this.cFoodImage1.FoodImage = ((System.Drawing.Image)(resources.GetObject("cFoodImage1.FoodImage")));
            this.cFoodImage1.FoodName = "Food Name222222223";
            this.cFoodImage1.FoodPrice = "Price";
            this.cFoodImage1.Location = new System.Drawing.Point(391, 121);
            this.cFoodImage1.Name = "cFoodImage1";
            this.cFoodImage1.Size = new System.Drawing.Size(150, 150);
            this.cFoodImage1.TabIndex = 0;
            // 
            // cTable1
            // 
            this.cTable1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(102)))), ((int)(((byte)(244)))));
            this.cTable1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cTable1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cTable1.Location = new System.Drawing.Point(73, 59);
            this.cTable1.Name = "cTable1";
            this.cTable1.Size = new System.Drawing.Size(250, 150);
            this.cTable1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cTable1);
            this.Controls.Add(this.cFoodImage1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ChildForm.Bill.CFoodImage cFoodImage1;
        private ChildForm.Table.CTable cTable1;
    }
}