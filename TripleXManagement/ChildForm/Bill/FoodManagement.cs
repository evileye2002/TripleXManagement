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
using static System.Net.Mime.MediaTypeNames;

namespace TripleXManagement
{
    public partial class FoodManagement : Form
    {
        private Form activateForm;
        SqlConnection conn;
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
            //btnCloseChildForm.Visible = true;
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
    }
}
