using System.Data.SqlClient;
using System.Drawing.Imaging;
using TripleXManagement.StaticClass;
using TripleXManagement.Properties;
using Image = System.Drawing.Image;

namespace TripleXManagement.ChildForm.Food
{
    public partial class EditFood : Form
    {
        public static string ID = "";
        private string name = "";
        public static string price = "";
        SqlConnection conn;
        SqlCommand? cmd;
        SqlDataReader reader;
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        public EditFood()
        {
            InitializeComponent();
            conn = SqlClass.Connection;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderRadius);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Texts != "" && txtPrice.Texts != "")
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
                        cmd = new SqlCommand("exec PFoodEditByID @ID, @Name, @Price, @Image", conn);
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@Name", txtName.Texts);
                        cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Texts));
                        cmd.Parameters.AddWithValue("@Image", array);
                        cmd.ExecuteNonQuery();

                        GetData();
                        var mainForm = Application.OpenForms.OfType<FoodManagement>().Single();
                        mainForm.GetData();
                        SharedClass.Alert("Sửa Thành Công!", Form_Alert.enmType.Success);
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

        private void EditFood_Load(object sender, EventArgs e)
        {
            SqlClass.Connect();
            GetData();
        }

        private void GetData()
        {
            ID = FoodManagement.foodID;
            string sql = "exec PFoodFineByID " + ID;
            reader = SqlClass.Reader(sql);
            while (reader.Read())
            {
                long len = reader.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[Convert.ToInt32(len) + 1];
                reader.GetBytes(0, 0, array, 0, Convert.ToInt32(len));
                MemoryStream ms = new(array);
                Bitmap bitmap = new(ms);
                pbPic.BackgroundImage = bitmap;

                txtName.Texts = reader["FName"].ToString();
                name = reader["FName"].ToString();
                txtPrice.Texts = reader["FPrice"].ToString();
                price = reader["FPrice"].ToString();
            }
            reader.Close();
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
            SharedClass.RoundedControl(panel2, borderRadius, e.Graphics, borderSize);
        }
        #endregion
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            txtName.Texts = name;
        }

        private void txtPrice_Click(object sender, EventArgs e)
        {
            txtPrice.Texts = price;
        }
    }
}
