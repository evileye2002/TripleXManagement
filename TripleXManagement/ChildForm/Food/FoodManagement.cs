using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TripleXManagement.ChildForm.Bill;
using TripleXManagement.ChildForm.Food;
using static System.Net.Mime.MediaTypeNames;

namespace TripleXManagement
{
    public partial class FoodManagement : Form
    {
        public static string foodID = "";
        //public static string image = "";
        private Form activateForm;
        SqlConnection conn;
        SqlCommand cmd;
        public FoodManagement()
        {
            InitializeComponent();
            conn = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-J6D7SL6\SQLEXPRESS;Initial Catalog=TripleX;Integrated Security=True"
            };
            this.dgvFood.Columns[2].DefaultCellStyle.Format = "c";
            dgvFood.Columns[2].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vn-VN");
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
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddFood(), sender);
            pnFooter.Visible = false;
        }
        private void GetData()
        {
            conn.Open();
            String sql = "exec getMonAn2";
            DataTable table = new DataTable();
            SqlDataAdapter sda = new(sql, conn);
            sda.Fill(table);
            dgvFood.DataSource = table;
            conn.Close();
        }

        private void FoodManagement_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvFood.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvFood.CurrentCell.RowIndex;
                foodID = dgvFood.Rows[t].Cells[0].Value.ToString();
            }
        }

        private void dgvFood_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                String sql = "exec delFoodbyId " + foodID;
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                GetData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            /* String sql = "exec editFoodbyId " + foodID + ", " + name + ", " + price;
             conn.Open();
             cmd = new SqlCommand(sql, conn);
             cmd.ExecuteNonQuery();
             conn.Close();

             GetData();*/

            if(foodID != "")
            {
                OpenChildForm(new EditFood(), sender);
            }
        }

        private void btnAddFood_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnAddFood, Properties.Resources.database_administrator_20px, true);
        }

        private void btnAddFood_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnAddFood, Properties.Resources.database_administrator_20px1, false);
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnEdit, Properties.Resources.database_administrator_20px, true);
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnEdit, Properties.Resources.database_administrator_20px1, false);
        }
    }
}
