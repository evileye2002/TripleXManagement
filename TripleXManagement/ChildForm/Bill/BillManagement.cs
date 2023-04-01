using System.Globalization;
using TripleXManagement.StaticClass;
using TripleXManagement.Properties;

namespace TripleXManagement.ChildForm.Bill
{
    public partial class BillManagement : Form
    {
        private Form activateForm;
        public static String BillID = "";
        public static String StaffName = "";
        public static String CustomerName = "";
        public static String BillDate = "";
        public static String regency = "";
        public static double FinaTotal = 0;
        public static int IsBank = 0;
        public BillManagement()
        {
            InitializeComponent();
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
            regency = MainForm.regency;
            String sql = "exec PBillShow";
            SharedClass.FillDGV(dgvBill, sql);
        }

        private void BillManagement_Load(object sender, EventArgs e)
        {
            SqlClass.Connect();
            GetData();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Form f = new BillDetail();
            if (BillID != "")
            {
                f.Show();
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
                BillDate = dgvBill.Rows[t].Cells[1].Value.ToString();
                FinaTotal = double.Parse(dgvBill.Rows[t].Cells[2].Value.ToString());
                StaffName = dgvBill.Rows[t].Cells[3].Value.ToString();
                CustomerName = dgvBill.Rows[t].Cells[4].Value.ToString();
                IsBank = int.Parse(dgvBill.Rows[t].Cells[5].Value.ToString());
            }
        }

        private void dgvBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                String sql = "exec PBillDel " + BillID;
                if(regency == "admin")
                {
                    if (BillID != "")
                    {
                        SqlClass.RunSqlDel(sql);
                        BillID = "";
                    }
                    else
                        SharedClass.Alert("Chưa Chọn Hóa Đơn!", Form_Alert.enmType.Warning);

                    GetData();
                }
                else
                    SharedClass.Alert("Bạn Không Có\nQuyền Hạn Này!", Form_Alert.enmType.Warning);
            }
        }

        private void btnDetail_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnDetail, Resources.view_20px1, true);
        }

        private void btnDetail_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnDetail, Resources.view_20px, false);
        }
    }
}
