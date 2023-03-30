using CustomAlertBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TripleXManagement.ChildForm.Staff;
using TripleXManagement.StaticClass;

namespace TripleXManagement.ChildForm.Account
{
    public partial class EditAccount : Form
    {
        public static string ID = "";
        public static string pass = "";
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        public EditAccount()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderRadius);
        }
        private void GetData()
        {
            ID = AccountManagement.username;
            pass = AccountManagement.pass;
            txtUserName.Texts = ID;
            txtPassword.Texts = pass;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(panel2, borderRadius, e.Graphics, borderSize);
        }

        private void AddAccount_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedForm(this, borderRadius, e.Graphics, borderColor, borderSize);
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
            if(txtPassword.Texts != "")
            {
                string sql = "exec PAccountEdit '" + ID + "','" + txtPassword.Texts + "'";
                SqlClass.RunSql(sql);
                SharedClass.Alert("Sửa Thành Công!", Form_Alert.enmType.Success);
                var mainForm = Application.OpenForms.OfType<AccountManagement>().Single();
                mainForm.GetData();
            }
            else
                SharedClass.Alert("Mật Khẩu Trống!", Form_Alert.enmType.Warning);

        }

        private void EditAccount_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
