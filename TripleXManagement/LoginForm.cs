using TripleXManagement.StaticClass;
using TripleXManagement.Properties;
using TripleXManagement.CustomControl;
using CustomAlertBox;
using System.Data.SqlClient;
using System.Data;

namespace TripleXManagement
{
    public partial class LoginForm : Form
    {
        public static string u = "";
        public LoginForm()
        {
            InitializeComponent();
            SqlClass.Connect();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Texts != "" && txtPassword.Texts != "")
            {
                string sql = "exec LoginP '" + txtUserName.Texts + "','" + txtPassword.Texts + "'";
                DataTable table = SqlClass.FillTable(sql);
                if(table.Rows.Count > 0)
                {
                    string username = table.Rows[0][0].ToString();
                    string password = table.Rows[0][1].ToString();
                    if (username == txtUserName.Texts && password == txtPassword.Texts)
                    {
                        u = txtUserName.Text;
                        Form f = new MainForm();
                        f.Show();
                        this.Hide();
                    }
                    else
                        CMessageBox.Show("Tài Khoản hoặc Mật Khẩu Chưa Chính Xác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                SharedClass.Alert("Chưa Nhập Đủ Dữ Liệu!", Form_Alert.enmType.Warning);
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(this,15,e.Graphics,0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar)
            {
                txtPassword.PasswordChar = false;
                pictureBox3.Image = Resources.eye_32px;
            }
            else
            {
                txtPassword.PasswordChar = true;
                pictureBox3.Image = Resources.blind_32px;
            }
        }
    }
}
