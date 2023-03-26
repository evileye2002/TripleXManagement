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
using TripleXManagement.ChildForm.Bill;

namespace TripleXManagement
{
    public partial class Bill : Form
    {
        private Form activateForm;
        double _total;
        double _price = 0;
        int isBank = 0;
        String ?dash = "------------------------------------------------------------------------------------------------";
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

        private void btnBillManagement_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BillManagement(), sender);
        }

        /*public void sizePrintPage()
        {
            int a;
            if (dgvDetail.Rows.Count <= 10) { a = 0; }
            else { a = dgvDetail.Rows.Count * 40 - 400; }
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("size", 500, a + 710);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            int gap = 10;
            int gapDetail = 15;
            int startY = 20;
            int mn1 = 0;
            int mn2 = 0;
            int mn3 = 0;
            Graphics ?graphics = e.Graphics;
            Font font = new("Arial", 10, FontStyle.Regular);
            Font fontDetail = new("Arial", 8, FontStyle.Regular);
            Font fontTitle = new("Arial", 10, FontStyle.Bold);
            Brush brush = Brushes.Black;
            StringFormat formatLeft = new(StringFormatFlags.NoClip);
            StringFormat formatCenter = new(formatLeft);
            StringFormat formatRight = new(formatLeft);
            formatCenter.Alignment = StringAlignment.Center;
            formatRight.Alignment = StringAlignment.Far;
            formatLeft.Alignment = StringAlignment.Near;
            
            graphics.DrawString("NHÀ HÀNG TRIPLEX", new("Arial", 8, FontStyle.Bold), brush, new Point(25, startY));
            graphics.DrawString("Z115 - Tân Thịnh - Thái Nguyên", fontDetail, brush, new Point(25, startY += gapDetail));
            graphics.DrawString("0123456789", fontDetail, brush, new Point(25, startY += gapDetail));

            graphics.DrawString("HÓA ĐƠN", new Font("Arial", 16, FontStyle.Bold), brush, new Point(250, startY += gapDetail), formatCenter);

            graphics.DrawString("Số Hóa đơn:" , font, brush, new Point(25, startY += gapDetail));
            graphics.DrawString("Ngày:", font, brush, new Point(25, startY += gapDetail));
            graphics.DrawString("Thu ngân:", font, brush, new Point(25, startY += gapDetail));
            graphics.DrawString("Quầy:", font, brush, new Point(25, startY += gapDetail));
            graphics.DrawString("Khách hàng:", font, brush, new Point(25, startY += gapDetail));

            graphics.DrawString(dash, font, brush, new Point(25, startY += gap));

            graphics.DrawString("Mã món", fontTitle, brush, new Point(25, startY += gap));
            graphics.DrawString("Đơn giá", fontTitle, brush, new Point(220, startY ), formatRight);
            graphics.DrawString("Số lượng", fontTitle, brush, new Point(320, startY ), formatRight);
            graphics.DrawString("Thành tiền" , fontTitle, brush, new Point(470, startY ), formatRight);

            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                graphics.DrawString(dash , font, brush, new Point(25, i * gap + (startY += gap) ));

                graphics.DrawString(dgvDetail.Rows[i].Cells[1].Value.ToString(),
                    new("Arial", 10, FontStyle.Bold), brush, new Point(25, i * gap + (startY += gap)));

                graphics.DrawString(dash, font, brush, new Point(25, i * gap + (startY += gap)));

                int Y = startY;
                graphics.DrawString(dgvDetail.Rows[i].Cells[2].Value.ToString(),
                    font, brush, new Point(25, i * gap + (Y += gap)) );
                graphics.DrawString(dgvDetail.Rows[i].Cells[2].Value.ToString(),
                    font, brush, new Point(220, i * gap + Y), formatRight);
                graphics.DrawString(dgvDetail.Rows[i].Cells[2].Value.ToString(),
                    font, brush, new Point(320, i * gap + Y), formatRight);
                graphics.DrawString(dgvDetail.Rows[i].Cells[2].Value.ToString(),
                    font, brush, new Point(430, i * gap + Y), formatRight);
                graphics.DrawString("VNĐ", font,brush,new Point(470, i * gap + Y), formatRight);

            }
            graphics.DrawString(dash, font,brush, new Point(25, dgvDetail.Rows.Count * gap + (startY += gap)));

            graphics.DrawString("Bằng chữ: " , font,brush, new Point(25, dgvDetail.Rows.Count * gap + (startY += gapDetail)));
            graphics.DrawString("Tổng: ", font,brush, new Point(25, dgvDetail.Rows.Count * gap + (mn1 += (startY += gapDetail))));
            graphics.DrawString("Tiền mặt: ", font,brush, new Point(25, dgvDetail.Rows.Count * gap + (mn2 += (startY += gapDetail))));
            graphics.DrawString("Thẻ ngân hàng: ", font,brush, new Point(25, dgvDetail.Rows.Count * gap + (mn3 += (startY += gapDetail))));

            graphics.DrawString(lbTotal.Text, font,brush, new Point(430, dgvDetail.Rows.Count * gap + mn1), formatRight);
            graphics.DrawString("1000", font,brush, new Point(430, dgvDetail.Rows.Count * gap + mn2), formatRight);
            graphics.DrawString("1000", font,brush, new Point(430, dgvDetail.Rows.Count * gap + mn3), formatRight);

            graphics.DrawString("VNĐ", font,brush, new Point(470, dgvDetail.Rows.Count * gap + mn1), formatRight);
            graphics.DrawString("VNĐ", font,brush, new Point(470, dgvDetail.Rows.Count * gap + mn2), formatRight);
            graphics.DrawString("VNĐ", font,brush, new Point(470, dgvDetail.Rows.Count * gap + mn3), formatRight);

            graphics.DrawString(dash, font,brush, new Point(25, dgvDetail.Rows.Count * gap + (startY += gap)));

            graphics.DrawString("QUÝ KHÁCH VUI LÒNG KIỂM TRA HÓA ĐƠN",
                new Font("Arial", 8, FontStyle.Regular), brush, new Point(250, dgvDetail.Rows.Count * gap + (startY += gapDetail)), formatCenter);
            graphics.DrawString("TRƯỚC KHI RA KHỎI QUẦY",
                new Font("Arial", 8, FontStyle.Regular), brush, new Point(250, dgvDetail.Rows.Count * gap + (startY += gapDetail)), formatCenter);
            graphics.DrawString("Xin chân thành cảm ơn quý khách và hẹn gặp lại",
                new Font("Arial", 8, FontStyle.Bold), brush, new Point(250, dgvDetail.Rows.Count * gap + (startY += gapDetail)) , formatCenter);

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
            sizePrintPage();
            printDocument1.Print();
        }*/

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

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            int rowCount = dgvDetail.Rows.Count;
            if (rowCount > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Thanh toán bằng thẻ ngân hàng?", "Loại thanh toán", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    isBank = 1;
                }
                else if (dialogResult == DialogResult.No)
                {
                    isBank = 0;
                }

                String sql = "";
                for (int i = 0; i < rowCount; i++)
                {
                    sql += @"exec addBill " + dgvDetail.Rows[i].Cells[0].Value.ToString() + ", " + isBank.ToString() + " \n";
                }
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Chưa chọn Món!", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void OpenChildForm(Form childForm, object btnSender)
        {
            if (activateForm != null)
            {
                activateForm.Close();
            }
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(childForm);
            this.pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //btnCloseChildForm.Visible = true;
            pnFooter.Visible = false;
            pnDGV.Visible = false;
        }
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activateForm != null)
            {
                //BillID = "";
                activateForm.Close();
                //btnCloseChildForm.Visible = false;
                pnFooter.Visible = true;

                GetData();
            }
        }

        private void btnBillManagement_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnBillManagement, Properties.Resources.database_administrator_20px, true);
        }

        private void btnBillManagement_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnBillManagement, Properties.Resources.database_administrator_20px1, false);
        }

        private void btnAddBill_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnAddBill, Properties.Resources.database_administrator_20px, true);
        }

        private void btnAddBill_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnAddBill, Properties.Resources.database_administrator_20px1, false);
        }
    }
}
