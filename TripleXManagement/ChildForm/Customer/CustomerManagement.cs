using CustomAlertBox;
using TripleXManagement.StaticClass;

namespace TripleXManagement.ChildForm.Customer
{
    public partial class CustomerManagement : Form
    {
        public static string ID = "";
        public static string name = "";
        public static string CCCD = "";
        public static string birthday = "";
        public static string address = "";
        public static string phone = "";
        public CustomerManagement()
        {
            InitializeComponent();
        }

        private void CustomerManagement_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            string sql = "exec getCustomer";
            SharedClass.FillDGV(dgvCustomer, sql);
        }

        #region Hover State
        private void btnManagement_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAddCustomer, Properties.Resources.denied_20px, true);
        }
        private void btnManagement_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAddCustomer, Properties.Resources.denied_20px, false);
        }
        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnEdit, Properties.Resources.denied_20px, true);
        }
        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnEdit, Properties.Resources.denied_20px, false);
        }
        #endregion

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Form f = new AddCustomer();
            f.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form f = new EditCustomer();
            if(ID != "")
                f.ShowDialog();
            else
                SharedClass.Alert("Chưa Chọn Khách Hàng!", Form_Alert.enmType.Warning);
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvCustomer.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvCustomer.CurrentCell.RowIndex;
                ID = dgvCustomer.Rows[t].Cells[0].Value.ToString();
                name = dgvCustomer.Rows[t].Cells[1].Value.ToString();
                CCCD = dgvCustomer.Rows[t].Cells[2].Value.ToString();
                birthday = dgvCustomer.Rows[t].Cells[3].Value.ToString();
                address = dgvCustomer.Rows[t].Cells[4].Value.ToString();
                phone = dgvCustomer.Rows[t].Cells[5].Value.ToString();
            }
        }

        private void dgvCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                String? sql = "exec delCustomer " + ID;
                if(ID != "")
                {
                    SqlClass.RunSqlDel(sql);
                }
                else
                    SharedClass.Alert("Chưa Chọn Khách Hàng!", Form_Alert.enmType.Warning);

                GetData();
            }
        }
    }
}
