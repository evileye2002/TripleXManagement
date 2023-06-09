﻿using TripleXManagement.StaticClass;
using TripleXManagement.Properties;
namespace TripleXManagement.ChildForm.Staff
{
    public partial class StaffManagement : Form
    {
        public static string ID = "";
        public StaffManagement()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            //ID = "";
            SharedClass.FillDGV(dgvStaff, "exec PStaffShow");
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            Form f = new AddStaff();
            f.ShowDialog();
        }

        private void StaffManagement_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form f = new EditStaff();
            if (ID != "")
                f.ShowDialog();
            else
                SharedClass.Alert("Chưa Chọn Nhân Viên!", Form_Alert.enmType.Warning);
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? selectedRow = dgvStaff.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvStaff.CurrentCell.RowIndex;
                ID = dgvStaff.Rows[t].Cells[0].Value.ToString();
            }
        }
        #region Hover State
        private void btnAddStaff_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAddStaff, Resources.Add_properties_20px1, true);
        }

        private void btnAddStaff_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAddStaff, Resources.Add_properties_20px, false);
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
        private void dgvStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                String? sql = "exec PStaffDel " + ID;
                if (ID != "")
                {
                    SqlClass.RunSqlDel(sql);
                    ID = "";
                }
                else
                    SharedClass.Alert("Chưa Chọn Nhân Viên!", Form_Alert.enmType.Warning);

                GetData();
            }
        }
    }
}
