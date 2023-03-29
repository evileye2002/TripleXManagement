using CustomAlertBox;
using System.Data.SqlClient;
using TripleXManagement.ChildForm.Table;
using TripleXManagement.CustomControl;
using TripleXManagement.StaticClass;
using TripleXManagement.ChildForm;

namespace TripleXManagement.ChildForm.Bill
{
    public partial class SelectCustomer : Form
    {
        public static string StaffID = "";
        public static bool isBank = false;
        public static bool isHasCustomer = false;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        public SelectCustomer()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(20);
        }

        private void SelectCustomer_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedForm(this, 20, e.Graphics, borderColor, 2);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(panel2, 20, e.Graphics, 0);
        }

        #region HoverState
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Properties.Resources.denied_20px, true);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Properties.Resources.denied_20px, false);
        }
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Properties.Resources.denied_20px, true);
        }
        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Properties.Resources.denied_20px, false);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            var mainForm = Application.OpenForms.OfType<Bill>().Single();
            mainForm.AddBill();
            this.Close();
        }

        private void SelectCustomer_Load(object sender, EventArgs e)
        {

        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvCustomer.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvCustomer.CurrentCell.RowIndex;
                StaffID = dgvCustomer.Rows[t].Cells[2].Value.ToString();
            }
        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            if(rbYes.Checked)
                isHasCustomer = false;
            else
                isHasCustomer = true;
        }

        private void rbYes2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYes2.Checked)
                isBank = false;
            else
                isBank = true;
        }
    }
}
