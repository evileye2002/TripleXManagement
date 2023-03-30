using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using TripleXManagement.StaticClass;
using CustomAlertBox;

namespace TripleXManagement.ChildForm.Staff
{
    public partial class AddStaff : Form
    {
        SqlCommand cmd;
        SqlConnection conn;
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        public AddStaff()
        {
            InitializeComponent();
            conn = SqlClass.Connection;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderRadius);
        }
        private void GetData()
        {
            SharedClass.FillCBB("select * from TRegency", cbRegency,"RName");
            SharedClass.FillCBB("exec PAccountShow", cbAccount,"AUsername");
            
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            GetData();
            SqlClass.Connect();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdBrowse.Filter = "Image files (*.jpeg)|*.jpeg|(*.png)|*.png|(*.jpg)|*.jpg|(*.gif)|*.gif";
            ofdBrowse.ShowDialog();

            if (ofdBrowse.FileName != "openFileDialog1")
            {
                pbPic.BackgroundImage = Image.FromFile(ofdBrowse.FileName);
                pbPic.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCCCD.Texts != "" && txtName.Texts != "" && txtPhone.Texts != "")
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pbPic.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                    byte[] array = ms.GetBuffer();

                    cmd = new SqlCommand("exec PStaffAdd @Name, @CCCD, @Phone, @Image,@Regency, @Account", conn);
                    cmd.Parameters.AddWithValue("@Name", txtName.Texts);
                    cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Texts);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Texts);
                    cmd.Parameters.AddWithValue("@Regency", cbRegency.Texts);
                    cmd.Parameters.AddWithValue("@Account", cbAccount.Texts);
                    cmd.Parameters.AddWithValue("@Image", array);
                    cmd.ExecuteNonQuery();

                    clear();
                    var mainForm = Application.OpenForms.OfType<StaffManagement>().Single();
                    mainForm.GetData();
                    SharedClass.Alert("Lưu Thành Công!", Form_Alert.enmType.Success);
                }
                catch
                {
                    SharedClass.Alert("Chưa Chọn Ảnh!", Form_Alert.enmType.Error);
                }
            }
            else
                SharedClass.Alert("Chưa Nhập Dữ Liệu!", Form_Alert.enmType.Warning);
        }
        private void clear()
        {
            txtName.Texts = "";
            txtCCCD.Texts = "";
            txtPhone.Texts = "";
            pbPic.BackgroundImage = null;
        }

        #region HoverState

        private void btnBrowse_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnBrowse, Properties.Resources.denied_20px, true);
        }

        private void btnBrowse_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnBrowse, Properties.Resources.denied_20px, false);
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Properties.Resources.denied_20px, true);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Properties.Resources.denied_20px, false);
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Properties.Resources.denied_20px, true);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Properties.Resources.denied_20px, false);
        }
        #endregion
        #region Round
        private void AddTable_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedForm(this, borderRadius, e.Graphics, borderColor, borderSize);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(panel2, borderRadius, e.Graphics, borderSize);
        }
        #endregion

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYes.Checked) 
                SharedClass.FillCBB("exec PAccountShow", cbAccount, "AUsername");
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNo.Checked)
                if (cbAccount.DataSource != null)
                    cbAccount.DataSource = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
