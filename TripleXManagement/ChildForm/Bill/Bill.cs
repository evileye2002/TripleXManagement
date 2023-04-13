using System.Data.SqlClient;
using TripleXManagement.StaticClass;
using TripleXManagement.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace TripleXManagement.ChildForm.Bill
{
    public partial class Bill : Form
    {
        public static string StaffID = "";
        public static bool IsEdit = false;
        private Form activateForm;
        double _total;
        double _price = 0;
        SqlDataReader ?reader;

        private PictureBox ?image;
        private Label ?price;
        public Bill()
        {
            InitializeComponent();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            SqlClass.Connect();
            GetData();
        }

        private void GetData()
        {
            StaffID = MainForm.StaffID;
            string sql = "exec PFoodShowWithImage";
            reader = SqlClass.Reader(sql);
            while (reader.Read())
            {
                long len = reader.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[Convert.ToInt32(len) + 1];
                reader.GetBytes(0, 0, array, 0, Convert.ToInt32(len));
                /*
                                image = new PictureBox
                                {
                                    Width = 150,
                                    Height = 150,
                                    BackgroundImageLayout = ImageLayout.Stretch,
                                    BorderStyle = BorderStyle.None,
                                    Cursor = Cursors.Hand,
                                    Tag = reader["ID"].ToString()
                                };

                                price = new Label
                                {
                                    Text = int.Parse(reader["FPrice"].ToString()).ToString("#,##") + " VNĐ",
                                    BackColor = Color.LightGray,
                                    Font = new("Arial", 10, FontStyle.Bold),
                                    ForeColor = Color.FromArgb(39, 39, 58),
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
                                image.Click += new EventHandler(OnClick);*/

                CFoodImage foodImage = new CFoodImage
                {
                    FoodID = reader["ID"].ToString(),
                    FoodName = reader["FName"].ToString(),
                    FoodPrice = int.Parse(reader["FPrice"].ToString()).ToString("#,##") + " VNĐ",
                };

                MemoryStream ms = new(array);
                Bitmap bitmap = new(ms);
                foodImage.FoodImage = bitmap;
                flowLayoutPanel1.Controls.Add(foodImage);
                foodImage._CClick += new EventHandler(OnClick);
            }
            reader.Close();
        }
        public void OnClick(object sender, EventArgs e)
        {
            string id = ((PictureBox)sender).Tag.ToString();
            string sql = "exec PFoodFineByID '" + id + "'";
            reader = SqlClass.Reader(sql);
            reader.Read();
            if (reader.HasRows)
            {
                _total += double.Parse(reader["FPrice"].ToString());
                dgvDetail.Rows.Add(reader["ID"].ToString(), reader["FName"].ToString(), double.Parse(reader["FPrice"].ToString()).ToString("#,##"));

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
                SharedClass.Alert("Chưa chọn món ăn cần xóa", Form_Alert.enmType.Warning);
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
        public void AddBill(bool isBank, bool isHasCustomer,string CustumerID)
        {
            int rowCount = dgvDetail.Rows.Count;
            string bank = "1";
            if (isBank)
                bank = "2";
            else
                bank = "1";
            string cID = "";
            if (isHasCustomer)
                cID = CustumerID;
            else
                cID = "1";

            String sql = "";
            for (int i = 0; i < rowCount; i++)
            {
                sql += @"exec PBillAdd " + dgvDetail.Rows[i].Cells[0].Value.ToString() + ", " + bank + "," + StaffID + "," + cID + " \n";
            }
            SqlClass.RunSql(sql);
            dgvDetail.Rows.Clear();
        }
        public void addMoreFood(string bID, string bDate, string bStaff, string bCustomer, string bIsbank)
        {
            string sql = "";
            int rowCount = dgvDetail.Rows.Count;

            DateTime dtOrederDate = DateTime.ParseExact(bDate, "dd/MM/yyyy HH:mm:ss", SharedClass.cultureVN);
            string date = dtOrederDate.ToString("MM/dd/yyyy HH:mm:ss", SharedClass.cultureVN);

            for (int i = 0; i < rowCount; i++)
            {
                sql += @"exec PBillAddMoreFood '" + bID + "','" + date + "'," + dgvDetail.Rows[i].Cells[0].Value.ToString() + "," + bStaff + "," + bCustomer + "," + bIsbank + " \n";
            }
            SqlClass.RunSql(sql);
            dgvDetail.Rows.Clear();
        }
        private void btnAddBill_Click(object sender, EventArgs e)
        {
            IsEdit = false;
            int rowCount = dgvDetail.Rows.Count;
            if (rowCount > 0)
            {
                Form f = new SelectCustomer();
                f.ShowDialog();
            }
            else
                SharedClass.Alert("Chưa Chọn Món!", Form_Alert.enmType.Warning);
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
            pnFooter.Visible = false;
            pnDGV.Visible = false;
        }
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activateForm != null)
            {
                activateForm.Close();
                pnFooter.Visible = true;

                GetData();
            }
        }
        #region Hover State
        private void btnBillManagement_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnBillManagement, Resources.bonds_20px1, true);
        }

        private void btnBillManagement_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnBillManagement, Resources.bonds_20px, false);
        }

        private void btnAddBill_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAdd, Resources.Add_properties_20px1, true);
        }

        private void btnAddBill_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAdd, Resources.Add_properties_20px, false);
        }
        private void btnAddMoreFood_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAddMoreFood, Resources.Add_properties_20px1, true);
        }

        private void btnAddMoreFood_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnAddMoreFood, Resources.Add_properties_20px, false);
        }
        #endregion

        private void btnAddMoreFood_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count > 0)
            {
                Form f = new AddMoreFood();
                f.ShowDialog();
            }
            else
                SharedClass.Alert("Chưa Chọn Món!", Form_Alert.enmType.Warning);
        }
    }
}
