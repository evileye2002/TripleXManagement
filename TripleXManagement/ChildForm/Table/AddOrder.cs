using CustomAlertBox;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using TripleXManagement.CustomControl;
using TripleXManagement.StaticClass;

namespace TripleXManagement.ChildForm.Table
{
    public partial class AddOrder : Form
    {
        public static string ID = "";
        public static string CustomerID = "";
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        SqlDataReader reader;
        public AddOrder()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderRadius);
        }

        #region Rounded
        private void AddTable_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedForm(this, borderRadius, e.Graphics, borderColor, borderSize);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(panel2, borderRadius, e.Graphics, borderSize);
        }
        #endregion

        private void dgvCustomer_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(dgvCustomer, 15, e.Graphics, borderSize);
        }

        #region HoverState
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Properties.Resources.denied_20px, true);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Properties.Resources.denied_20px, false);
        }
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Properties.Resources.denied_20px, true);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Properties.Resources.denied_20px, false);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "exec addOrderTable " + ID + "," + CustomerID + ",N'" 
                + DateToString(dtpOrderDate) + " " + TimeToString(dtpOrderTime) + "',N'" 
                + DateToString(dtpGetDate) + " " + TimeToString(dtpGetTime) + "'";

            if (ID != "")
            {
                SqlClass.RunSql(sql);
                SharedClass.Alert("Lưu thành công!", Form_Alert.enmType.Success);
            }
            else
                SharedClass.Alert("Chưa Chọn Khách Hàng!", Form_Alert.enmType.Warning);

        }
        private string DateToString(RJDatePicker dtpDate)
        {
            DateTime dtOrederDate = DateTime.ParseExact(dtpDate.Value.ToString(), "dd/MM/yyyy HH:mm:ss", SharedClass.cultureVN);
            string date = dtOrederDate.ToString("dd/MM/yyyy", SharedClass.cultureVN);
            return date;
        }
        private string TimeToString(RJDatePicker dtpTime)
        {
            DateTime dtOrderTime = DateTime.ParseExact(dtpTime.Value.ToString(), "dd/MM/yyyy HH:mm:ss", SharedClass.cultureVN);
            string time = dtOrderTime.ToString("HH:mm:ss", SharedClass.cultureVN);
            return time;
        }
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvCustomer.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvCustomer.CurrentCell.RowIndex;
                CustomerID = dgvCustomer.Rows[t].Cells[0].Value.ToString();
                txtName.Texts = dgvCustomer.Rows[t].Cells[1].Value.ToString();
            }
        }
        private void GetData()
        {
            ID = TableManagement.tag;
            string sql = "exec getCustomer";
            StaticClass.SharedClass.FillDGV(dgvCustomer, sql);
            string sql2 = "exec getTablebyID " + ID;
            reader = SqlClass.Reader(sql2);
            while (reader.Read())
            {
                lbTableName.Text = reader.GetValue(1).ToString();
            }
            reader.Close();
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void AddOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                String? sql = "exec delTable " + ID;
                if (ID != "")
                {
                    SqlClass.RunSqlDel(sql);
                }
            }
        }
    }
}
