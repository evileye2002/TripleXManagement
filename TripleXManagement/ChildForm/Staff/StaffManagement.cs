using TripleXManagement.StaticClass;
namespace TripleXManagement.ChildForm.Staff
{
    public partial class StaffManagement : Form
    {
        public static string? ID = "";
        public StaffManagement()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            SharedClass.FillDGV(dgvStaff, "exec getStaff");
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
            SharedClass.HoverBtnState(btnAddStaff, Properties.Resources.database_administrator_20px, true);
        }

        private void btnAddStaff_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAddStaff, Properties.Resources.database_administrator_20px1, false);
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnEdit, Properties.Resources.database_administrator_20px, true);
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnEdit, Properties.Resources.database_administrator_20px1, false);
        }
        #endregion
        private void dgvStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                String? sql = "exec delStaffbyID " + ID;
                SqlClass.RunSql(sql);

                GetData();
            }
        }
    }
}
