using TripleXManagement.CustomControl;
using TripleXManagement.StaticClass;
using TripleXManagement.Properties;

namespace TripleXManagement.ChildForm.Table
{
    public partial class AddOrder : Form
    {
        public static string TableID = "";
        public static string OrderID = "";
        public static string CustomerID = "";
        public static string regency = "";
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
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
        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnDelete, Resources.waste_20px1, true);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnDelete, Resources.waste_20px, false);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "exec POrederTableAdd " + TableID + "," + CustomerID + ",N'" 
                + DateToString(dtpOrderDate) + " " + TimeToString(dtpOrderTime) + "',N'" 
                + DateToString(dtpGetDate) + " " + TimeToString(dtpGetTime) + "'";

            if (CustomerID != "")
            {
                SqlClass.RunSql(sql);
                SharedClass.Alert("Lưu Thành Công!", Form_Alert.enmType.Success);
                var mainForm = Application.OpenForms.OfType<TableManagement>().Single();
                mainForm.GetData();
                this.Close();
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
            regency = MainForm.regency;
            TableID = TableManagement.TableID;
            lbTableName.Text = TableManagement.TableName;
            if (regency != "admin")
                btnDelete.Visible = false;
            string sql = "select * from TCustomer";
            SharedClass.FillDGV(dgvCustomer, sql);
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String? sql = "exec PTableDel " + TableID;
            if (regency == "admin")
            {
                if (TableID != "")
                {
                    var mainForm = Application.OpenForms.OfType<TableManagement>().Single();
                    SqlClass.RunSqlDel(sql);
                        
                    mainForm.GetData();
                    this.Close();
                }
            }
        }
    }
}
