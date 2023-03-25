using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripleXManagement.ChildForm.Bill
{
    public partial class BillManagement : Form
    {
        private Form activateForm;
        private int borderSize = 2;
        public static String BillID = "";
        public static double FinaTotal = 0;
        public static int IsBank = 0;
        SqlConnection conn;
        public BillManagement()
        {
            InitializeComponent();
            conn = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-J6D7SL6\SQLEXPRESS;Initial Catalog=TripleX;Integrated Security=True"
            };
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(39, 39, 58);
            this.dgvBill.Columns[2].DefaultCellStyle.Format = "c";
            dgvBill.Columns[2].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vn-VN");
            btnCloseChildForm.Visible = false;
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void pnTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0X0083;
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1) { return; }
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Image = Properties.Resources.icons8_restore_down_261;
                this.Padding = new Padding(0);

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
        public void OpenChildForm(Form childForm, object btnSender)
        {
            if (activateForm != null)
            {
                activateForm.Close();
            }
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(childForm);
            this.pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            btnCloseChildForm.Visible = true;
            pnFooter.Visible = false;
        }
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activateForm != null)
            {
                BillID = "";
                activateForm.Close();
                btnCloseChildForm.Visible = false;
                pnFooter.Visible = true;
            }
        }
        private void GetData()
        {
            conn.Open();
            String sql = "exec getbill";
            DataTable table = new DataTable();
            SqlDataAdapter sda = new(sql, conn);
            sda.Fill(table);
            dgvBill.DataSource = table;
            conn.Close();
        }

        private void BillManagement_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (BillID == "")
            {
                MessageBox.Show("Chưa chọn Hóa đơn", "CẢNH BÁO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                OpenChildForm(new BillDetail(), sender);
            }
        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvBill.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvBill.CurrentCell.RowIndex;
                BillID = dgvBill.Rows[t].Cells[0].Value.ToString();
                FinaTotal = double.Parse(dgvBill.Rows[t].Cells[2].Value.ToString());
                IsBank = int.Parse(dgvBill.Rows[t].Cells[3].Value.ToString());
            }
        }
    }
}
