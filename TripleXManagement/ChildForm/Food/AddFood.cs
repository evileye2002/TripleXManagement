using System.Data.SqlClient;
using System.Drawing.Imaging;
using TripleXManagement.StaticClass;
using TripleXManagement.Properties;

namespace TripleXManagement.ChildForm.Food
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Texts != "" && txtPrice.Texts != "")
            {
                if (int.TryParse(txtPrice.Texts, out int a) != true)
                    SharedClass.Alert("Giá Không Đúng\nĐịnh Dạng!", Form_Alert.enmType.Error);
                else if (pbPic.BackgroundImage == null)
                    SharedClass.Alert("Chưa Chọn Ảnh!", Form_Alert.enmType.Error);
                else
                {
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pbPic.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                        byte[] array = ms.GetBuffer();
                        cmd = new SqlCommand("exec PFoodAdd @Name, @Price, @Image", conn);
                        cmd.Parameters.AddWithValue("@Name", txtName.Texts);
                        cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Texts));
                        cmd.Parameters.AddWithValue("@Image", array);
                        cmd.ExecuteNonQuery();

                        var mainForm = Application.OpenForms.OfType<FoodManagement>().Single();
                        mainForm.GetData();
                        SharedClass.Alert("Lưu Thành Công!", Form_Alert.enmType.Success);
                    }
                    catch (Exception ex)
                    {
                        CMessageBox.Show(ex.ToString(), "Có gì đó không đúng!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                SharedClass.Alert("Chưa Nhập Dữ Liệu!", Form_Alert.enmType.Warning);
        }
        #region Hover State
        private void btnBrowse_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnBrowse, Resources.image_file_20px1, true);
        }

        private void btnBrowse_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnBrowse, Resources.image_file_20px, false);
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Resources.save_20px1, true);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Resources.save_20px, false);
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Resources.reply_arrow_20px1, true);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Resources.reply_arrow_20px, false);
        }
        #endregion
        #region Rounded
        private void AddFood_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedForm(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(panel2, borderRadius, e.Graphics, 0);
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
