using TripleXManagement.StaticClass;
using TripleXManagement.Properties;

namespace TripleXManagement.ChildForm.Food
{
    public partial class FoodManagement : Form
    {
        public static string foodID = "";
        public static string name = "" ;
        public static string price = "";
        public static string regency = "";
        private Form activateForm;
        public FoodManagement()
        {
            InitializeComponent();
            this.dgvFood.Columns[2].DefaultCellStyle.Format = "c";
            dgvFood.Columns[2].DefaultCellStyle.FormatProvider = SharedClass.cultureVN;
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Form f = new AddFood();
            f.ShowDialog();
        }
        public void GetData()
        {
            foodID = "";
            regency = MainForm.regency;
            if (regency != "admin")
                btnEdit.Visible = false;
            String sql = "select * from TFood";
            SharedClass.FillDGV(dgvFood, sql);
        }

        private void FoodManagement_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvFood.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvFood.CurrentCell.RowIndex;
                foodID = dgvFood.Rows[t].Cells[0].Value.ToString();
                name = dgvFood.Rows[t].Cells[1].Value.ToString();
                price = dgvFood.Rows[t].Cells[2].Value.ToString();
            }
        }

        private void dgvFood_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if(regency == "admin")
                {
                    String sql = "exec PFoodDelByID " + foodID;
                    if (foodID != "")
                    {
                        SqlClass.RunSqlDel(sql);
                        foodID = "";
                    }
                    else
                        SharedClass.Alert("Chưa Chọn Món!", Form_Alert.enmType.Warning);

                    GetData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form f = new EditFood();
            if (foodID != "")
                f.ShowDialog();
            else
                SharedClass.Alert("Chưa Chọn Món!", Form_Alert.enmType.Warning);
        }
        #region Hover State
        private void btnAddFood_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAddFood, Resources.Add_properties_20px1, true);
        }

        private void btnAddFood_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAddFood, Resources.Add_properties_20px, false);
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
    }
}
