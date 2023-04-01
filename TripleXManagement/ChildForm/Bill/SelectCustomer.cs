using TripleXManagement.StaticClass;
using TripleXManagement.Properties;
using System.Data.SqlClient;

namespace TripleXManagement.ChildForm.Bill
{
    public partial class SelectCustomer : Form
    {
        public static string BillIDForEdit = "";
        public static string CustomerIDForEdit = "";
        public static string IsBankForEdit = "";
        public static string CustomerID = "";
        public static bool isBank = false;
        public static bool isHasCustomer = false;
        public static bool isEdit = false;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        public SelectCustomer()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(20);
        }

        private void SelectCustomer_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedForm(this, 20, e.Graphics, borderColor, 2);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(panel2, 20, e.Graphics, 0);
        }

        #region HoverState
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Resources.reply_arrow_20px1, true);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Resources.reply_arrow_20px, false);
        }
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Resources.save_20px1, true);
        }
        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Resources.save_20px, false);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                var mainForm = Application.OpenForms.OfType<BillManagement>().Single();
                string sql = "exec PBillShowIDDetail '" + BillIDForEdit + "'";
                string sql1 = "";
                string sql2 = "";

                string bank = "1";
                if (isBank)
                    bank = "2";
                else
                    bank = "1";
                string cID = "";
                if (isHasCustomer)
                    cID = CustomerID;
                else
                    cID = "1";

                SqlDataReader reader = SqlClass.Reader(sql);
                while (reader.Read())
                {
                    if (CustomerIDForEdit != reader["CustomerID"].ToString())
                    {
                        sql1 = "update TBill set CustomerID = " + CustomerID + " where BillID like '" + BillIDForEdit + "'";
                    }
                    if (IsBankForEdit != reader["BIsBank"].ToString())
                    {
                        sql2 = "update TBill set BIsBank = " + isBank + " where BillID like '" + BillIDForEdit + "'";
                    }
                }
                reader.Close();
                SqlClass.RunSql(sql1 + " " + sql2);
                
            }
            else
            {
                var billForm = Application.OpenForms.OfType<Bill>().Single();
                if (rbHasCustomerNO.Checked)
                {
                    billForm.AddBill(isBank, isHasCustomer, CustomerID);
                    this.Close();
                }
                else if (rbHasCustomerYes.Checked)
                {
                    if (CustomerID == "")
                        SharedClass.Alert("Chưa Chọn Khách Hàng!", Form_Alert.enmType.Warning);
                    else
                    {
                        billForm.AddBill(isBank, isHasCustomer, CustomerID);
                        this.Close();
                    }
                }
            }
        }

        private void SelectCustomer_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            CustomerID = "";
            isBank = false;
            isHasCustomer = false;
            BillIDForEdit = BillManagement.BillID;
            isEdit = BillManagement.isEdit;
            string sql = "exec PCustomerShow";
            SharedClass.FillDGV(dgvCustomer, sql);
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvCustomer.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvCustomer.CurrentCell.RowIndex;
                CustomerID = dgvCustomer.Rows[t].Cells[0].Value.ToString();
                txtName.Texts = dgvCustomer.Rows[t].Cells[1].Value.ToString();
                rbHasCustomerYes.Checked = true;
            }
        }

        private void rbHasCustomerYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHasCustomerYes.Checked)
                isHasCustomer = true;
        }

        private void rbHasCustomerNO_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHasCustomerNO.Checked)
            {
                txtName.Texts = "";
                isHasCustomer = false;
            }
        }

        private void rbBankNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBankNo.Checked)
            {
                isBank= false;
            }
        }

        private void rbBankYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBankYes.Checked)
            {
                isBank = true;
            }
        }

        private void dgvCustomer_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(dgvCustomer, 20, e.Graphics, 0);
        }
    }
}
