using System;
using System.Windows.Forms;

namespace TripleXManagement.StaticClass
{
    internal static class SharedClass
    {
        #region NotFix

        #region Biến toàn cục
        private static string _globalVar = "";
        private static string _globalVar1 = "";
        private static string _globalVar2 = "";

        public static string TenTK
        {
            get { return _globalVar1; }
            set { _globalVar1 = value; }
        }
        public static string LoginTime
        {
            get { return _globalVar2; }
            set { _globalVar2 = value; }
        }

        // Biến lưu quyền truy cập toàn cục
        public static string GlobalVar
        {
            get { return _globalVar; }
            set { _globalVar = value; }
        }
        #endregion

        #region Controls

        #region Bật, tắt
        //Bật
        public static void Disable_Controls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                Disable_Controls(c);
            }
            if (con is TextBox || con is ComboBox)
                con.Enabled = false;
            if (con.Name == "Title" || Convert.ToString(con.Tag) == "OnlyTrue")
                con.Enabled = true;
            if (Convert.ToString(con.Tag) == "OnlyFalse")
                con.Enabled = false;
        }

        //Tắt
        public static void Enable_Controls(Control con)
        {
            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    Enable_Controls(c);
                }
                if (con is TextBox || con is ComboBox)
                    con.Enabled = true;
            }
        }
        #endregion

        #region Mouse Enter & Leave
        public static void HoverBtnState(CustomControl.RJButton btn,Image img, bool status)
        {

            Color white = Color.FromArgb(245, 255, 255);
            Color black = Color.FromArgb(39, 39, 58);
            //MouseEnter
            if (status == true)
            {
                btn.Image = img;
                btn.BackColor = black;
                btn.BorderColor = white;
                btn.ForeColor = white;
            }
            //MouseLeave
            else
            {
                btn.Image = img;
                btn.BackColor = white;
                btn.BorderColor = black;
                btn.ForeColor = black;
            }
            
        }
        #endregion

        #region MessageBox
        //Show
        public static void MBShow(string text, string type)
        {
            if (type == "Info") MessageBox.Show("" + text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (type == "Stop") MessageBox.Show("" + text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            if (type == "Warning") MessageBox.Show("" + text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (type == "Question") MessageBox.Show("" + text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (type == "Error") MessageBox.Show("" + text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //YesNo
        public static bool MBYesNo(string text) => MessageBox.Show("" + text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        #endregion

        // Xóa chữ trong các TextBox
        public static void Clear_TextBox(Control con)
        {
            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    Clear_TextBox(c);
                }
                if (con is TextBox && Convert.ToString(con.Tag) != "OnlyTrue" && con.Name != "txtMaNVuuu" && con.Name != "txtCountt")
                    (con as TextBox).Clear();
            }
        }
        #endregion

        #region Other
        //Đổ dữ liệu vào DataGridView
        public static void FillDGV(DataGridView dgv, string sql)
        {
            SqlClass.Connect();
            dgv.DataSource = SqlClass.FillTable(sql);
        }

        //Đổ dữ liệu vào ComboBox
        public static void FillCBB(string sql, ComboBox cbo/*, string ma*/, string ten)
        {
            cbo.DataSource = SqlClass.FillTable(sql);
            //cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }

        // Load form Buttons
        /*public static void Load_Form(Control con)
        {
            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    Load_Form(c);
                }
                if (con.Name == "btnSua" || con.Name == "btnXoa" || con.Name == "btnLuu")
                {
                    con.Enabled = false;
                    if (con.Name == "btnSua")
                        (con as Button).Image = DuyShopApp.Properties.Resources.Update_file_Black_32;
                    if (con.Name == "btnXoa")
                        (con as Button).Image = DuyShopApp.Properties.Resources.Delete_trash_Black_32;
                    if (con.Name == "btnLuu")
                        (con as Button).Image = DuyShopApp.Properties.Resources.Save_Black_32;
                }
                else if (con.Name == "btnThem")
                    con.Enabled = true;
            }
        }*/

        // Kiểm tra quyền truy cập
        public static void FormNhanVien(string quyen, Control con)
        {
            if (quyen != "admin")
            {
                if (con != null)
                {
                    foreach (Control c in con.Controls)
                    {
                        FormNhanVien(quyen, c);
                    }
                    if (con.Name == "btnXoa" || con.Name == "btnSua")
                        con.Visible = false;
                }
            }
        }

        //Dùng ENTER thay TAB
        public static void EnterToTab(KeyEventArgs eventArgs)
        {
            if (eventArgs.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        //DGV Click
        /*public static void DGV_Click(Control Form,Control them,Control luu, Control sua,Control xoa)
        {
            if (them.Enabled == true || luu.Enabled == true)
            {
                ChangeImg_Back(Form, them.Name, true);
                ChangeImg_Back(Form, luu.Name, false);
                Disable_Controls(Form);
            }
            else
            {
                ChangeImg_Back(Form, them.Name, false);
            }
            ChangeImg_Back(Form, xoa.Name, true);
            ChangeImg_Back(Form, sua.Name, true);
        }*/
        

        //btnThem_Click
        /*public static void btnThem_Click(Control Form,Control sua,Control luu,Control xoa)
        {
            ChangeImg_Back(Form, luu.Name, true);
            if ((sua.Enabled = true) || (xoa.Enabled = true))
            {
                ChangeImg_Back(Form, sua.Name, false);
                ChangeImg_Back(Form, xoa.Name, false);
            }
            Enable_Controls(Form);
            Show_SubMenu(Form);
        }*/

        //btnMenu_Click
        /*public static void btnMenu_Click(Control Form,Control subMenu)
        {
            if (subMenu.Visible == false)
                Show_SubMenu(Form);
            else
                Hide_SubMenu(Form);
        }*/

        //btnSua_Click
        /*public static void btnSua_Click(Control Form,Control luu,Control them,Control xoa)
        {
            ChangeImg_Back(Form, luu.Name, true);
            if ((them.Enabled = true) || (xoa.Enabled = true))
            {
                ChangeImg_Back(Form, them.Name, false);
                ChangeImg_Back(Form, xoa.Name, false);
            }
            Enable_Controls(Form);
            Show_SubMenu(Form);
        }*/
        #endregion

        #endregion


        //====================================================================================================


        #region FIX
        //Kiểm tra textbox
        public static void CheckTextbox(Control control, string controlName)
        {
            if (control != null)
            {
                foreach (Control c in control.Controls)
                {
                    if (controlName == "txt??" && control.Text == "") //nếu chưa chọn bản ghi nào
                    {
                        MBShow("Bạn chưa chọn bản ghi nào", "Info");
                        return;
                    }
                    if (controlName == "txt??" && control.Text == "") //nếu chưa nhập tên chất liệu
                    {
                        MBShow("Bạn chưa nhập tên chất liệu", "Info");
                        return;
                    }
                }
            }
        }

        

        //Kiểm tra có phải dạng dũ liệu ngày tháng hay không
        public static bool IsDate(string date)
        {
            string[] elements = date.Split('/');
            if ((Convert.ToInt32(elements[0]) >= 1) && (Convert.ToInt32(elements[0]) <= 31) && (Convert.ToInt32(elements[1]) >= 1) && (Convert.ToInt32(elements[1]) <= 12) && (Convert.ToInt32(elements[2]) >= 1900))
                return true;
            else return false;
        }

        //Đổi định dang ngày tháng
        public static string ConvertDateTime(string date)
        {
            string[] elements = date.Split('/');
            string dt = string.Format("{0}/{1}/{2}", elements[0], elements[1], elements[2]);
            return dt;
        }
        #endregion
    }
}
