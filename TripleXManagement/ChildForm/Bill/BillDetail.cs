using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripleXManagement.ChildForm.Bill
{
    public partial class BillDetail : Form
    {
        SqlConnection conn;
        public static String BillID = ""; 
        public BillDetail()
        {
            InitializeComponent();
            conn = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-J6D7SL6\SQLEXPRESS;Initial Catalog=TripleX;Integrated Security=True"
            };
        }

        public static void  getBillID()
        {
            BillID = BillManagement.BillID;
        }

        private void GetData()
        {
            conn.Open();
            String sql = "exec getbillbyId " + BillID;
            DataTable table = new DataTable();
            SqlDataAdapter sda = new(sql, conn);
            sda.Fill(table);
            dgvBillDetail.DataSource = table;
            conn.Close();
        }

        private void BillDetail_Load(object sender, EventArgs e)
        {
            getBillID();
            GetData();
        }
    }
}
