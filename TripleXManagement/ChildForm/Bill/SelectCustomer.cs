using TripleXManagement.StaticClass;
using TripleXManagement.Properties;

namespace TripleXManagement.ChildForm.Bill
{
    public partial class SelectCustomer : Form
    {
        public static string CustomerID = "";
        public static bool isBank = false;
        public static bool isHasCustomer = false;
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
            var mainForm = Application.OpenForms.OfType<Bill>().Single();
            if (rbHasCustomerNO.Checked)
            {
                mainForm.AddBill(isBank, isHasCustomer, CustomerID);
                this.Close();
            }
            else if (rbHasCustomerYes.Checked)
            {
                if (CustomerID == "")
                    SharedClass.Alert("Chưa Chọn Khách Hàng!", Form_Alert.enmType.Warning);
                else
                {
                    mainForm.AddBill(isBank, isHasCustomer, CustomerID);
                    this.Close();
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
    }
}
