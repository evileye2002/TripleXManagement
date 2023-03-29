using CustomAlertBox;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using TripleXManagement.ChildForm.Staff;
using TripleXManagement.StaticClass;

namespace TripleXManagement
{
    public partial class AddFood : Form
    {
        SqlConnection conn;
        SqlCommand cmd; 
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        public AddFood()
        {
            InitializeComponent();
            conn = SqlClass.Connection;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderRadius);
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

        private void clear()
        {
            txtName.Texts = "";
            txtPrice.Texts = "";
            pbPic.BackgroundImage = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Texts != "" && txtPrice.Texts != "")
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pbPic.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                    byte[] array = ms.GetBuffer();
                    cmd = new SqlCommand("exec addmMonAn @Name, @Price, @Image", conn);
                    cmd.Parameters.AddWithValue("@Name", txtName.Texts);
                    cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Texts));
                    cmd.Parameters.AddWithValue("@Image", array);
                    cmd.ExecuteNonQuery();

                    clear();
                    var mainForm = Application.OpenForms.OfType<FoodManagement>().Single();
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
        #region Hover State
        private void btnBrowse_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnBrowse, Properties.Resources.database_administrator_20px, true);
        }

        private void btnBrowse_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnBrowse, Properties.Resources.database_administrator_20px1, false);
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnSave, Properties.Resources.database_administrator_20px, true);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnSave, Properties.Resources.database_administrator_20px1, false);
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
        #region Rounded
        private void AddFood_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedForm(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(panel2, borderRadius, e.Graphics, borderSize);
        }
        #endregion
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddFood_Load(object sender, EventArgs e)
        {
            SqlClass.Connect();
        }
    }
}
