using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TripleXManagement.ChildForm.Staff;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace TripleXManagement.ChildForm.Food
{
    public partial class EditFood : Form
    {
        public static string ID = "";
        SqlConnection conn;
        SqlCommand? cmd;
        SqlDataReader reader;
        public EditFood()
        {
            InitializeComponent();
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-J6D7SL6\SQLEXPRESS;Initial Catalog=TripleX;Integrated Security=True";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pbPic.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                byte[] array = ms.GetBuffer();

                conn.Open();
                cmd = new SqlCommand("exec editFoodbyId @ID, @Name, @Price, @Image", conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", txtName.Texts);
                cmd.Parameters.AddWithValue("@Price", int.Parse(txtPrice.Texts));
                cmd.Parameters.AddWithValue("@Image", array);
                cmd.ExecuteNonQuery();
                conn.Close();

                GetData();
                MessageBox.Show("Đã lưu!", "THÔNG BÁO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CẢNH BÁO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
            }
        }

        private void EditFood_Load(object sender, EventArgs e)
        {
            StaticClass.SqlClass.Connect();
            GetData();
        }

        private void GetData()
        {
            ID = FoodManagement.foodID;
            string sql = "exec getFoodbyID " + ID;
            reader = StaticClass.SqlClass.Reader(sql);
            
            while (reader.Read())
            {
                long len = reader.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[Convert.ToInt32(len) + 1];
                reader.GetBytes(0, 0, array, 0, Convert.ToInt32(len));
                txtName.Texts = reader.GetValue(1).ToString();
                txtPrice.Texts = reader.GetValue(2).ToString();

                MemoryStream ms = new(array);
                Bitmap bitmap = new(ms);
                pbPic.BackgroundImage = bitmap;
            }
            reader.Close();
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnSave, Properties.Resources.database_administrator_20px, true);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnSave, Properties.Resources.database_administrator_20px1, false);
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
    }
}
