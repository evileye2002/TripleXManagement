using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;

namespace TripleXManagement
{
    public partial class Bill : Form
    {
        double _total;
        double _price = 0;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        private PictureBox image;
        private Label price;
        //private Button button;
        public Bill()
        {
            InitializeComponent();
            conn = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-J6D7SL6\SQLEXPRESS;Initial Catalog=AnhChoosen;Integrated Security=True"
            };
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            GetData();
            //flowLayoutPanel1.Hide();
        }

        private void GetData()
        {
            conn.Open();
            cmd = new SqlCommand("select Image, Name, Price, ID from MonAn", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                long len = reader.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[Convert.ToInt32(len) + 1];
                reader.GetBytes(0, 0, array, 0, Convert.ToInt32(len));
                image = new PictureBox
                {
                    Width = 150,
                    Height = 150,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BorderStyle = BorderStyle.None,
                    Tag = reader["ID"].ToString()
                };

                price = new Label
                {
                    Text = reader["Price"].ToString() + " VNĐ",
                    BackColor = Color.Yellow,
                    Width = 50,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Bottom,
                    Tag = reader["ID"].ToString()
                };

                MemoryStream ms = new(array);
                Bitmap bitmap = new(ms);
                image.BackgroundImage = bitmap;

                image.Controls.Add(price);

                flowLayoutPanel1.Controls.Add(image);
                image.Click += new EventHandler(OnClick);
            }
            reader.Close();
            conn.Close();
        }
        public void OnClick(object sender, EventArgs e)
        {
            string tag = ((PictureBox)sender).Tag.ToString();
            //MessageBox.Show(tag);
            conn.Open();
            cmd = new SqlCommand("select * from MonAn where ID = '" + tag + "'", conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                _total += double.Parse(reader["Price"].ToString());
                dgvDetail.Rows.Add(reader["ID"].ToString(), reader["Name"].ToString(), double.Parse(reader["Price"].ToString()).ToString("#,##0.00"));

            }
            reader.Close();
            conn.Close();
            lbTotal.Text = _total.ToString("#,##0.00");
        }
    }
}
