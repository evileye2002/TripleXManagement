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
        String ?dash = "--------------------------------------------------------------------------------";
        SqlConnection conn;
        SqlCommand ?cmd;
        SqlDataReader ?reader;

        private PictureBox ?image;
        private Label ?price;
        //private Button button;
        public Bill()
        {
            InitializeComponent();
            conn = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-J6D7SL6\SQLEXPRESS;Initial Catalog=TripleX;Integrated Security=True"
            };
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            GetData();
            sizePrintPage();
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
                    Text = int.Parse(reader["Price"].ToString()).ToString("#,##") + " VNĐ",
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
            string ?tag = ((PictureBox)sender).Tag.ToString();
            //MessageBox.Show(tag);
            conn.Open();
            cmd = new SqlCommand("select * from MonAn where ID = '" + tag + "'", conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                _total += double.Parse(reader["Price"].ToString());
                dgvDetail.Rows.Add(reader["ID"].ToString(), reader["Name"].ToString(), double.Parse(reader["Price"].ToString()).ToString("#,##"));

            }
            reader.Close();
            conn.Close();
            lbTotal.Text = _total.ToString("#,##");
        }

        private void btnFoodManagement_Click(object sender, EventArgs e)
        {
            Form form = new FoodManagement();
            form.ShowDialog();
        }

        public void sizePrintPage()
        {
            int a;
            if (dgvDetail.Rows.Count <= 11) { a = 0; }
            else { a = dgvDetail.Rows.Count * 20 - 220; }
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("size", 500, a + 700);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            Graphics ?graphics = e.Graphics;
            Font font = new("Arial", 12, FontStyle.Regular);
            Font fontDetail = new("Arial", 10, FontStyle.Regular);
            Brush brush = Brushes.Black;
            StringFormat formatLeft = new(StringFormatFlags.NoClip);
            StringFormat formatCenter = new(formatLeft);
            StringFormat formatRight = new(formatLeft);
            formatCenter.Alignment = StringAlignment.Center;
            formatRight.Alignment = StringAlignment.Far;
            formatLeft.Alignment = StringAlignment.Near;

            graphics.DrawString("Nhà hàng TripleX", new Font("Arial", 10, FontStyle.Bold), brush, new Point(250, 40), formatCenter);
            graphics.DrawString("Z115 - Tân Thịnh - Thái Nguyên", fontDetail, brush, new Point(250, 60), formatCenter);
            graphics.DrawString("0123456789", fontDetail, brush, new Point(250, 80), formatCenter);

            graphics.DrawString("HÓA ĐƠN", new Font("Arial", 16, FontStyle.Bold), brush, new Point(250, 100), formatCenter);

            graphics.DrawString("Số Hóa đơn:", fontDetail, brush, new Point(25, 120));
            graphics.DrawString("Ngày:", fontDetail, brush, new Point(25, 140));
            graphics.DrawString("Thu ngân:", fontDetail, brush, new Point(25, 160));
            graphics.DrawString("Quầy:", fontDetail, brush, new Point(25, 180));
            graphics.DrawString("Khách hàng:", fontDetail, brush, new Point(25, 200));

            graphics.DrawString(dash, font, brush, new Point(25, 220));

            graphics.DrawString("Tên món", font,brush, new Point(25, 240));
            graphics.DrawString("Giá", font,brush, new Point(420, 240), formatRight);

            graphics.DrawString(dash, font,brush, new Point(25, 260));

            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                graphics.DrawString(dgvDetail.Rows[i].Cells[1].Value.ToString(),
                    font, brush, new Point(25, i * 20 + 280));
                graphics.DrawString(dgvDetail.Rows[i].Cells[2].Value.ToString(),
                    font, brush, new Point(420, i * 20 + 280), formatRight);
                graphics.DrawString("VNĐ", font,brush,new Point(425, i * 20 + 280), formatLeft);

            }
            graphics.DrawString(dash, font,brush, new Point(25, dgvDetail.Rows.Count * 20 + 280));

            graphics.DrawString("Bằng chữ: ", font,brush, new Point(25, dgvDetail.Rows.Count * 20 + 300));
            graphics.DrawString("Tổng: ", font,brush, new Point(25, dgvDetail.Rows.Count * 20 + 320));
            graphics.DrawString("Tiền mặt: ", font,brush, new Point(25, dgvDetail.Rows.Count * 20 + 340));
            graphics.DrawString("Thẻ ngân hàng: ", font,brush, new Point(25, dgvDetail.Rows.Count * 20 + 360));

            graphics.DrawString(lbTotal.Text, font,brush, new Point(420, dgvDetail.Rows.Count * 20 + 320), formatRight);
            graphics.DrawString("1000", font,brush, new Point(420, dgvDetail.Rows.Count * 20 + 340), formatRight);
            graphics.DrawString("1000", font,brush, new Point(420, dgvDetail.Rows.Count * 20 + 360), formatRight);

            graphics.DrawString("VNĐ", font,brush, new Point(425, dgvDetail.Rows.Count * 20 + 320), formatLeft);
            graphics.DrawString("VNĐ", font,brush, new Point(425, dgvDetail.Rows.Count * 20 + 340), formatLeft);
            graphics.DrawString("VNĐ", font,brush, new Point(425, dgvDetail.Rows.Count * 20 + 360), formatLeft);

            graphics.DrawString(dash, font,brush, new Point(25, dgvDetail.Rows.Count * 20 + 380));

            graphics.DrawString("QUÝ KHÁCH VUI LÒNG KIỂM TRA HÓA ĐƠN",
                new Font("Arial", 10, FontStyle.Regular), brush, new Point(250, dgvDetail.Rows.Count * 20 + 400), formatCenter);
            graphics.DrawString("TRƯỚC KHI RA KHỎI QUẦY",
                new Font("Arial", 10, FontStyle.Regular), brush, new Point(250, dgvDetail.Rows.Count * 20 + 420), formatCenter);
            graphics.DrawString("Xin chân thành cảm ơn quý khách và hẹn gặp lại",
                new Font("Arial", 10, FontStyle.Bold), brush, new Point(250, dgvDetail.Rows.Count * 20 + 440), formatCenter);

            e.HasMorePages = false;
        }

        private void btnPrintPriview_Click(object sender, EventArgs e)
        {
            sizePrintPage();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void deleteDetail()
        {
            if (_price == 0)
            {
                MessageBox.Show("Chưa chọn món ăn cần xóa!", "CẢNH BÁO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (DataGridViewRow row in dgvDetail.SelectedRows)
                {
                    if (row.Selected)
                    {
                        dgvDetail.Rows.Remove(row);
                        _total -= _price;
                        lbTotal.Text = _total.ToString("#,##");
                        _price = 0;
                        if (lbTotal.Text == "")
                            lbTotal.Text = "0";
                    }
                }
            }
        }
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvDetail.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvDetail.CurrentCell.RowIndex;
                _price = double.Parse(dgvDetail.Rows[t].Cells[2].Value.ToString());
            }
        }

        private void dgvDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                deleteDetail();
        }

        private void dgvDetail_SelectionChanged(object sender, EventArgs e)
        {
            /*if(dgvDetail.SelectedRows.Count > 0)
            {
                _price = 0;
                foreach (DataGridViewRow row in dgvDetail.SelectedRows)
                {
                    _price += double.Parse(row.Cells[2].Value.ToString());
                }
            }*/
        }
    }
}
