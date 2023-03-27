using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using SqlDataReader = System.Data.SqlClient.SqlDataReader;

namespace TripleXManagement.ChildForm.Account
{
    public partial class AccountManagement : Form
    {
        private string username = "";
        public AccountManagement()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            string sql = "exec getAccount";
            StaticClass.SharedClass.FillDGV(dgvAccount, sql);
        }
        private void AccountManagement_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if(pnTextBox.Visible != true)
            {
                pnTextBox.Visible = true;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
            }
            else
            {
                pnTextBox.Visible = false;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (username != "" && pnTextBox.Visible != true)
            {
                pnTextBox.Visible = true;
                btnSave.Enabled = true;
                btnAddAccount.Enabled = false;
            }
            else
            {
                pnTextBox.Visible = false;
                btnSave.Enabled = false;
                btnAddAccount.Enabled = true;
            }
        }

        private void btnAddAccount_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnAddAccount, Properties.Resources.database_administrator_20px, true);
        }

        private void btnAddAccount_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnAddAccount, Properties.Resources.database_administrator_20px, false);
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnEdit, Properties.Resources.database_administrator_20px, true);
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnEdit, Properties.Resources.database_administrator_20px, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "exec addAccount '" + txtName.Texts + "','" + txtPassword.Texts + "'";
            StaticClass.SqlClass.RunSql(sql);
            GetData();
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? selectedRow = dgvAccount.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvAccount.CurrentCell.RowIndex;
                username = dgvAccount.Rows[t].Cells[0].Value.ToString();
                txtName.Texts = dgvAccount.Rows[t].Cells[0].Value.ToString();
                txtPassword.Texts = dgvAccount.Rows[t].Cells[1].Value.ToString();
            }
        }
    }
}
