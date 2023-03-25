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
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace TripleXManagement.ChildForm.Food
{
    public partial class EditFood : Form
    {
        public static string Id = "";
        SqlConnection conn;
        SqlCommand? cmd;
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
                String sql = "exec editFoodbyId " + Id + ", '" + txtName.Text + "', '" + txtPrice.Text + "'";
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
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
            GetData();
        }

        private void GetData()
        {
            Id = FoodManagement.foodID;
            txtName.Text = FoodManagement.name;
            txtPrice.Text = FoodManagement.price;
        }
    }
}
