using System.Data.SqlClient;
using System.Drawing.Imaging;
using TripleXManagement.StaticClass;

namespace TripleXManagement
{
    public partial class AddFood : Form
    {
        SqlConnection conn;
        SqlCommand ?cmd;
        public AddFood()
        {
            InitializeComponent();
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-J6D7SL6\SQLEXPRESS;Initial Catalog=TripleX;Integrated Security=True";
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
            try
            {
                MemoryStream ms = new MemoryStream();
                pbPic.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                byte[] array = ms.GetBuffer();

                conn.Open();
                cmd = new SqlCommand("exec addmMonAn @Name, @Price, @Image", conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Texts);
                cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Texts));
                cmd.Parameters.AddWithValue("@Image", array);
                cmd.ExecuteNonQuery();
                conn.Close();

                clear();
                MessageBox.Show("Đã lưu!", "THÔNG BÁO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CẢNH BÁO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
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
        #endregion
    }
}
