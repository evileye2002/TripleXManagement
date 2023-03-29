using System.Data.SqlClient;
using System.Drawing.Imaging;
using TripleXManagement.StaticClass;
using Image = System.Drawing.Image;

namespace TripleXManagement.ChildForm.Food
{
    public partial class EditFood : Form
    {
        public static string ID = "";
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
            try
            {
                MemoryStream ms = new MemoryStream();
                pbPic.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                byte[] array = ms.GetBuffer();
                cmd = new SqlCommand("exec editFoodbyID @ID, @Name, @Price, @Image", conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", txtName.Texts);
                cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Texts));
                cmd.Parameters.AddWithValue("@Image", array);
                cmd.ExecuteNonQuery();

                GetData();
                MessageBox.Show("Đã lưu!", "THÔNG BÁO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CẢNH BÁO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditFood_Load(object sender, EventArgs e)
        {
            SqlClass.Connect();
            GetData();
        }

        private void GetData()
        {
            ID = FoodManagement.foodID;
            string sql = "exec getFoodbyID " + ID;
            reader = SqlClass.Reader(sql);
            while (reader.Read())
            {
                long len = reader.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[Convert.ToInt32(len) + 1];
                reader.GetBytes(0, 0, array, 0, Convert.ToInt32(len));
                MemoryStream ms = new(array);
                Bitmap bitmap = new(ms);
                pbPic.BackgroundImage = bitmap;

                txtName.Texts = reader["Name"].ToString();
                txtPrice.Texts = reader["Price"].ToString();
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
    }
}
