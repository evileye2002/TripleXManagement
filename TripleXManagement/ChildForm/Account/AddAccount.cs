﻿using TripleXManagement.StaticClass;
using TripleXManagement.Properties;

namespace TripleXManagement.ChildForm.Account
{
    public partial class AddAccount : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        public AddAccount()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderRadius);
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
            if(txtUserName.Texts != "" && txtPassword.Texts != "")
            {
                string sql = "exec PAccountAdd '" + txtUserName.Texts + "','" + txtPassword.Texts + "'";
                try
                {
                    SqlClass.RunSql(sql);
                    SharedClass.Alert("Lưu Thành Công!", Form_Alert.enmType.Success);
                    var mainForm = Application.OpenForms.OfType<AccountManagement>().Single();
                    mainForm.GetData();
                }
                catch
                {
                    SharedClass.Alert("Tài Khoản Đã Tồn Tại!", Form_Alert.enmType.Error);
                }
            }
            else
                SharedClass.Alert("Dữ Liệu Trống!", Form_Alert.enmType.Warning);
        }
    }
}
