using CustomAlertBox;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using TripleXManagement.StaticClass;

namespace TripleXManagement.ChildForm.Bill
{
    public partial class BillManagement : Form
    {
        private Form activateForm;
        public static String BillID = "";
        public static double FinaTotal = 0;
        public static int IsBank = 0;
        SqlConnection conn;
        SqlCommand cmd;
        public BillManagement()
        {
            InitializeComponent();
            conn = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-J6D7SL6\SQLEXPRESS;Initial Catalog=TripleX;Integrated Security=True"
            };
            this.dgvBill.Columns[2].DefaultCellStyle.Format = "c";
            dgvBill.Columns[2].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vn-VN");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            pnFooter.Visible = false;
        }
        public void GetData()
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
            if (BillID != "")
            {
                OpenChildForm(new BillDetail(), sender);
            }
            else
                SharedClass.Alert("Chưa Chọn Hóa Đơn!", Form_Alert.enmType.Warning);
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

        private void dgvBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                String sql = "exec delBillbyId " + BillID;
                if(BillID != "")
                {
                    SqlClass.RunSqlDel(sql);
                }
                else
                    SharedClass.Alert("Chưa Chọn Hóa Đơn!", Form_Alert.enmType.Warning);

                GetData();
            }
        }

        private void btnDetail_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnDetail, Properties.Resources.database_administrator_20px, true);
        }

        private void btnDetail_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnDetail, Properties.Resources.database_administrator_20px1, false);
        }
    }
}
