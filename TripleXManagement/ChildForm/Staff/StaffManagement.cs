using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripleXManagement.ChildForm.Staff
{
    public partial class StaffManagement : Form
    {
        public static string ID = "";
        private Form activateForm;
        public StaffManagement()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            StaticClass.SharedClass.FillDGV(dgvStaff, "exec getStaff");
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
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddStaff(),sender);
        }

        private void StaffManagement_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(ID != "")
                OpenChildForm(new EditStaff(), sender);
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvStaff.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvStaff.CurrentCell.RowIndex;
                ID = dgvStaff.Rows[t].Cells[0].Value.ToString();
            }
        }

        private void btnAddStaff_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnAddStaff, Properties.Resources.database_administrator_20px, true);
        }

        private void btnAddStaff_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnAddStaff, Properties.Resources.database_administrator_20px1, false);
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnEdit, Properties.Resources.database_administrator_20px, true);
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnEdit, Properties.Resources.database_administrator_20px1, false);
        }
    }
}
