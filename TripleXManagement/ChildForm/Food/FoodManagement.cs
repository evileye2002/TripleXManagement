using CustomAlertBox;
using System.Data;
using System.Data.SqlClient;
using TripleXManagement.ChildForm.Food;
using TripleXManagement.StaticClass;

namespace TripleXManagement
{
    public partial class FoodManagement : Form
    {
        public static string foodID = "";
        public static string name = "" ;
        public static string price = "";
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
        private void GetData()
        {
            String sql = "exec getMonAn2";
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
                String sql = "exec delFoodbyId " + foodID;
                if (foodID != "")
                {
                    SqlClass.RunSqlDel(sql);
                }
                else
                    SharedClass.Alert("Chưa Chọn Món!", Form_Alert.enmType.Warning);

                GetData();
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
            SharedClass.HoverBtnState(btnAddFood, Properties.Resources.database_administrator_20px, true);
        }

        private void btnAddFood_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAddFood, Properties.Resources.database_administrator_20px1, false);
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
    }
}
