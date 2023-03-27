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
        SqlConnection conn;
        SqlCommand ?cmd;
        SqlDataReader ?reader;

        private PictureBox ?image;
        private Label ?price;
        public Bill()
        {
            InitializeComponent();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            StaticClass.SqlClass.Connect();
            GetData();
        }

        private void GetData()
        {
            string sql = "exec getMonAn";
            reader = StaticClass.SqlClass.Reader(sql);
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
                    BackColor = Color.LightGray,
                    Font = new("Arial", 10, FontStyle.Regular),
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
        }
        public void OnClick(object sender, EventArgs e)
        {
            string ?tag = ((PictureBox)sender).Tag.ToString();
            string sql = "select * from MonAn where ID = '" + tag + "'";
            reader = StaticClass.SqlClass.Reader(sql);
            reader.Read();
            if (reader.HasRows)
            {
                _total += double.Parse(reader["Price"].ToString());
                dgvDetail.Rows.Add(reader["ID"].ToString(), reader["Name"].ToString(), double.Parse(reader["Price"].ToString()).ToString("#,##"));

            }
            reader.Close();
            lbTotal.Text = _total.ToString("#,##");
        }

        private void btnBillManagement_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BillManagement(), sender);
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
                StaticClass.SqlClass.RunSql(sql);
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
