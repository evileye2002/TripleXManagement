﻿using System.Runtime.InteropServices;
using TripleXManagement.ChildForm.Account;
using TripleXManagement.ChildForm.Customer;
using TripleXManagement.ChildForm.Staff;
using TripleXManagement.ChildForm.Table;
using TripleXManagement.ChildForm.Food;
using TripleXManagement.ChildForm.Bill;
using TripleXManagement.StaticClass;

namespace TripleXManagement
{
    public partial class MainForm : Form
    {
        public static string u = "";
        public static string StaffID = "";
        public static string regency = "";
        private int borderSize = 2;
        private Button ?currencyButton;
        private Form ?activateForm;
        public MainForm()
        {
            InitializeComponent();
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(98, 102, 244);
            btnCloseChildForm.Visible = false;
            CollapseMenu();
            btnClose.Click += new EventHandler(btnLogout_Click);
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam );

        private void pnTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0X0083;
            if(m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1) { return; }
            base.WndProc(ref m);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(0, 8, 8, 8);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize) { this.Padding = new Padding(borderSize); }
                    break;
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if(this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Image = Properties.Resources.icons8_restore_down_261;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Image = Properties.Resources.icons8_maximize_button_26__1_;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void CollapseMenu()
        {
            if(this.pnMenu.Width > 200)
            {
                pnMenu.Width = 100;
                pbLogo.Visible = false;
                lbLogo1.Visible = false;
                lbLogo2.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach(Button menuButton in pnMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);

                    
                }
            }
            else
            {
                pnMenu.Width = 205;
                pbLogo.Visible = true;
                lbLogo1.Visible = true;
                lbLogo2.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in pnMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10,0,0,0);

                }
            }
        }

        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currencyButton != (Button)btnSender)
                {
                    DisableButton();
                    currencyButton = (Button)btnSender;
                    currencyButton.BackColor = Color.FromArgb(98, 102, 244);
                    currencyButton.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point); 
                    pnTitle.BackColor = Color.FromArgb(98, 102, 244);
                    lbTitle.ForeColor = Color.White;
                    lbTitle.Text = currencyButton.Tag.ToString();

                }
            }
        }

        private void DisableButton()
        {
            foreach(Control previousBtn in pnMenu.Controls)
            {
                if(previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(39, 39, 58);
                    previousBtn.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
                }
            }
        }

        public void OpenChildForm(Form childForm, object btnSender)
        {
            if (activateForm != null)
            {
                activateForm.Close();
            }

            if (btnSender == btnBill || btnSender == btnTable)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Image = Properties.Resources.icons8_restore_down_261;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Image = Properties.Resources.icons8_maximize_button_26__1_;
            }

            ActivateButton(btnSender);
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(childForm);
            this.pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            btnCloseChildForm.Visible = true;
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Bill(), sender);
        }

        private void btnFoodDrink_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FoodManagement(), sender);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StaffManagement(), sender);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AccountManagement(), sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SqlClass.Disconnect();
            this.Close();
            Form f = new LoginForm();
            f.Show();
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if(activateForm != null)
                activateForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lbTitle.Text = "";
            currencyButton = null;
            btnCloseChildForm.Visible=false;
        }

        private void bntTable_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableManagement(), sender);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CustomerManagement(), sender);
        }

        private void GetData()
        {
            u = LoginForm.u;
            if(u != "admin")
                regency = "thungan";
            else
                regency = "admin";
            Regency();
            string sql = "exec PStaffFindByUsername '" + u + "'";
            StaffID = SqlClass.GetOneValue(sql);
        }
        private void Regency()
        {
            if(regency != "admin")
            {
                btnAccount.Visible=false;
                btnStaff.Visible=false;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}