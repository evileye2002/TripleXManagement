using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripleXManagement.ChildForm.Account
{
    public partial class AccountManagement : Form
    {
        public static string ID = "";
        private Form activateForm;
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
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddAccount(), sender);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(ID != "")
                OpenChildForm(new Form(), sender);
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
    }
}
