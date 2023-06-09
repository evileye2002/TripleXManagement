﻿using TripleXManagement.StaticClass;
using TripleXManagement.Properties;
namespace TripleXManagement.ChildForm.Account
{
    public partial class AccountManagement : Form
    {
        public static string username = "";
        public static string pass = "";
        public AccountManagement()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            username = "";
            string sql = "exec PAccountShow";
            SharedClass.FillDGV(dgvAccount, sql);
        }
        private void AccountManagement_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            Form f = new AddAccount();
            f.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form f = new EditAccount();
            if (username != "")
                f.ShowDialog();
            else
                SharedClass.Alert("Chưa Chọn Tài Khoản!", Form_Alert.enmType.Warning);
        }
        #region Hover State
        private void btnAddAccount_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAddAccount, Resources.Add_properties_20px1, true);
        }

        private void btnAddAccount_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAddAccount, Resources.Add_properties_20px, false);
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnEdit, Resources.edit_property_20px1, true);
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnEdit, Resources.edit_property_20px, false);
        }
        #endregion

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? selectedRow = dgvAccount.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvAccount.CurrentCell.RowIndex;
                username = dgvAccount.Rows[t].Cells[0].Value.ToString();
                pass = dgvAccount.Rows[t].Cells[1].Value.ToString();
            }
        }

        private void dgvAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                String? sql = "exec PAccountDel '" + username + "'";
                if(username != "")
                {
                    SqlClass.RunSqlDel(sql);
                    username = "";
                }
                else
                    SharedClass.Alert("Chưa Chọn Tài Khoản!", Form_Alert.enmType.Warning);

                GetData();
            }
        }

        private void dgvAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }
    }
}
