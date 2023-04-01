using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using TripleXManagement.Properties;
using TripleXManagement.StaticClass;

namespace TripleXManagement.ChildForm.Bill
{
    public partial class AddMoreFood : Form
    {
        private String BillID = "";
        private String BillDate = "";
        private String StaffID = "";
        private String CustomerID = "";
        private String IsBank = "";
        public AddMoreFood()
        {
            InitializeComponent();
            this.dgvBill.Columns[2].DefaultCellStyle.Format = "c";
            dgvBill.Columns[2].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vn-VN");
        }
        #region Even
        private void AddMoreFood_Load(object sender, EventArgs e)
        {
            SqlClass.Connect();
            GetData();
        }

        private void AddMoreFood_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedForm(this, 20, e.Graphics, Color.FromArgb(98, 102, 244), 2);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(panel2, 20, e.Graphics, 0);
        }

        private void dgvBill_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(dgvBill, 20, e.Graphics, 0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var mainForm = Application.OpenForms.OfType<Bill>().Single();
            if (BillID == "")
                SharedClass.Alert("Chưa Chọn Hóa Đơn!", Form_Alert.enmType.Warning);
            else
            {
                mainForm.addMoreFood(BillID, BillDate, StaffID, CustomerID, IsBank);
                this.Close();
            }
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Resources.save_20px1, true);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Resources.save_20px, false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Resources.reply_arrow_20px1, true);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Resources.reply_arrow_20px, false);
        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvBill.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t       = dgvBill.CurrentCell.RowIndex;
                BillID      = dgvBill.Rows[t].Cells[0].Value.ToString();
                BillDate    = dgvBill.Rows[t].Cells[1].Value.ToString();
                IsBank      = dgvBill.Rows[t].Cells[5].Value.ToString();
            }
            string sql = "select StaffID,CustomerID from TBill where BillID like '" + BillID + "' group by StaffID,CustomerID";
            SqlDataReader reader = SqlClass.Reader(sql);
            while (reader.Read())
            {
                StaffID = reader["StaffID"].ToString();
                CustomerID  = reader["CustomerID"].ToString();
            }
            reader.Close();
        }
        #endregion

        private void GetData()
        {
            String sql = "exec PBillShow";
            SharedClass.FillDGV(dgvBill, sql);
        }
    }
}
