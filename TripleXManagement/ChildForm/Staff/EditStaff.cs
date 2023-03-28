using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace TripleXManagement.ChildForm.Staff
{
    public partial class EditStaff : Form
    {
        public static string ID = "";
        private SqlDataReader reader;
        SqlConnection conn;
        SqlCommand? cmd;
        public EditStaff()
        {
            InitializeComponent();
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-J6D7SL6\SQLEXPRESS;Initial Catalog=TripleX;Integrated Security=True";
        }

        private void EditStaff_Load(object sender, EventArgs e)
        {
            GetData();
            
        }
        private void GetData()
        {
            ID = StaffManagement.ID;
            StaticClass.SharedClass.FillCBB("select * from Regency", cbRegency, "Name");
            StaticClass.SharedClass.FillCBB("select * from Account", cbAccount, "Username");
            string sql = "exec getStaffbyID " + ID;
            reader = StaticClass.SqlClass.Reader(sql);
            
            while (reader.Read())
            {
                long len = reader.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[Convert.ToInt32(len) + 1];
                reader.GetBytes(0, 0, array, 0, Convert.ToInt32(len));

                txtName.Texts = reader["Name"].ToString();
                txtCCCD.Texts = reader["CCCD"].ToString();
                txtPhone.Texts = reader["Phone"].ToString();
                cbRegency.Text = reader["Regency"].ToString();
                cbAccount.Text = reader["Account"].ToString();

                MemoryStream ms = new(array);
                Bitmap bitmap = new(ms);
                pbPic.BackgroundImage = bitmap;
            }
            reader.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pbPic.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                byte[] array = ms.GetBuffer();

                conn.Open();
                cmd = new SqlCommand("exec editStaffbyID @ID, @Name, @CCCD, @Phone, @Regency, @Account, @Image", conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", txtName.Texts);
                cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Texts);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Texts);
                cmd.Parameters.AddWithValue("@Regency", cbRegency.Texts);
                cmd.Parameters.AddWithValue("@Account", cbAccount.Texts);
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
        private void btnDenied_Click(object sender, EventArgs e)
        {
            if (cbAccount.DataSource != null)
                cbAccount.DataSource = null;
            else
                StaticClass.SharedClass.FillCBB("select * from Account", cbAccount, "Username");
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnSave, Properties.Resources.denied_20px, true);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnSave, Properties.Resources.denied_20px, false);
        }

        private void btnDenied_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnDenied, Properties.Resources.denied_20px1, true);
        }

        private void btnDenied_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnDenied, Properties.Resources.denied_20px, false);
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
