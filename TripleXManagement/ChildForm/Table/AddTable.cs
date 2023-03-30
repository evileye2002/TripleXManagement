using TripleXManagement.StaticClass;
using TripleXManagement.Properties;

namespace TripleXManagement.ChildForm.Table
{
    public partial class AddTable : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        public AddTable()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderRadius);
        }
        private void AddTable_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedForm(this, borderRadius, e.Graphics, borderColor, borderSize);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(panel2, borderRadius, e.Graphics, borderSize);
        }
        #region Hover State
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Resources.reply_arrow_20px1, true);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Resources.reply_arrow_20px, false);
        }
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Resources.save_20px1, true);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Resources.save_20px, false);
        }
        #endregion
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "exec PTableAdd N'" + txtName.Texts + "', N'" + txtKind.Texts +"'," +txtChair.Texts;
            if (txtName.Texts != "" && txtKind.Texts != "" && txtChair.Texts != "")
            {
                SqlClass.RunSql(sql);
                SharedClass.Alert("Lưu Thành Công!", Form_Alert.enmType.Success);
                var mainForm = Application.OpenForms.OfType<TableManagement>().Single();
                mainForm.GetData();
            }
            else
                SharedClass.Alert("Chưa Nhập Dữ Liệu!", Form_Alert.enmType.Warning);
        }
    }
}
