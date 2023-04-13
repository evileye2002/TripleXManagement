using System.Data.SqlClient;
using TripleXManagement.StaticClass;
using TripleXManagement.Properties;
using Microsoft.VisualBasic;

namespace TripleXManagement.ChildForm.Table
{
    public partial class TableManagement : Form
    {
        public static string OrderID = "";
        public static string TableID = "";
        public static string TableName = "";
        SqlDataReader? reader;

        private Panel pnTable;
        private Panel header;
        private Label Tname;
        private Label Tstatus;

        private Panel body;
        private Panel pic;
        private Panel picT;
        private Panel picB;
        private Panel picL;
        private CustomControl.CButton img;
        private Label Tcustomer;

        private Panel footer;
        private Label Tchair;
        private Label TGetDate;
        public TableManagement()
        {
            InitializeComponent();
        }

        private void TableManagement_Load(object sender, EventArgs e)
        {
            SqlClass.Connect();
            string sql = "exec POrderedTableTodayShow";
            reader = SqlClass.Reader(sql);
            if (reader.HasRows)
            {
                reader.Close();
                rbToday.Checked = true;
            }
            reader.Close();
            GetData();
        }

        private void GetOrderTableInToday(string sql)
        {
            reader = SqlClass.Reader(sql);
            while (reader.Read())
            {
                DateTime dtOrederDate = DateTime.ParseExact(reader["OTake"].ToString(), "dd/MM/yyyy HH:mm:ss", SharedClass.cultureVN);
                string date = dtOrederDate.ToString("dd/MM/yyyy", SharedClass.cultureVN);

                CTable cTable = new CTable
                {
                    TableID = reader["ID"].ToString(),
                    TableName = reader["TName"].ToString(),
                    TableStatus = "Hôm Nay Nhận",
                    Customer = reader["CustomerName"].ToString(),
                    OrderDate = "Ngày: " + date,
                    Chair = "Ghế: " + reader["TChair"].ToString(),
                    TableImage = Resources.customer_32px
                };
                cTable._CClick += new EventHandler(editOrder);

                flpBookTable.Controls.Add(cTable);
            }
            reader.Close();
        }
        private void GetEmptyTable(string sql)
        {
            reader = SqlClass.Reader(sql);
            while (reader.Read())
            {
                CTable cTable = new CTable
                {
                    TableID = reader["ID"].ToString(),
                    TableName = reader["TName"].ToString(),
                    TableStatus = reader["TStatus"].ToString(),
                    Customer = reader["TStatus"].ToString(),
                    OrderDate = "Ngày: 0",
                    Chair = "Ghế: " + reader["TChair"].ToString(),
                    TableImage = Resources.coffee_table_32px
                };
                cTable._CClick += new EventHandler(addOrder);

                flpBookTable.Controls.Add(cTable);
            }
            reader.Close();
        }
        private void GetOrderedTable(string sql)
        {
            reader = SqlClass.Reader(sql);
            while (reader.Read())
            {
                DateTime dtOrederDate = DateTime.ParseExact(reader["OTake"].ToString(), "dd/MM/yyyy HH:mm:ss", SharedClass.cultureVN);
                string date = dtOrederDate.ToString("dd/MM/yyyy", SharedClass.cultureVN);

                CTable cTable = new CTable
                {
                    TableID = reader["ID"].ToString(),
                    TableName = reader["TName"].ToString(),
                    TableStatus = reader["TStatus"].ToString(),
                    Customer = reader["CustomerName"].ToString(),
                    OrderDate = "Ngày: " + date,
                    Chair = "Ghế: " + reader["TChair"].ToString(),
                    TableImage = Resources.customer_32px
                };
                cTable._CClick += new EventHandler(editOrder);

                flpBookTable.Controls.Add(cTable);
            }
            reader.Close();
        }
        public void GetData()
        {
            flpBookTable.Controls.Clear();
            string sql = "";
            if (rbAllKind.Checked)
            {
                if (rbNullTable.Checked)
                {
                    sql = "exec PEmptyTableShow";
                    GetEmptyTable(sql);
                }
                if (rbToday.Checked)
                {
                    sql = "exec POrderedTableTodayShow";
                    GetOrderTableInToday(sql);
                }
                if (rbOrderTable.Checked)
                {
                    sql = "exec POrderedTableShow";
                    GetOrderedTable(sql);
                }
            }

            if (rbNullTable.Checked)
            {
                sql = "exec PEmptyTableFindByKind N'";
                if (rbNormal.Checked)
                {
                    GetEmptyTable(sql + rbNormal.Text + "'");
                }
                if (rbMid.Checked)
                {
                    GetEmptyTable(sql + rbMid.Text + "'");
                }
                if (rbBig.Checked)
                {
                    GetEmptyTable(sql + rbBig.Text + "'");
                }
            }
            if (rbToday.Checked)
            {
                sql = "exec POrderedTableTodayFindByKind N'";
                if (rbNormal.Checked)
                {
                    GetOrderTableInToday(sql + rbNormal.Text + "'");
                }
                if (rbMid.Checked)
                {
                    GetOrderTableInToday(sql + rbMid.Text + "'");
                }
                if (rbBig.Checked)
                {
                    GetOrderTableInToday(sql + rbBig.Text + "'");
                }
            }
            if (rbOrderTable.Checked)
            {
                sql = "exec POrderedTableFindByKind N'";
                if (rbNormal.Checked)
                {
                    GetOrderedTable(sql + rbNormal.Text + "'");
                }
                if (rbMid.Checked)
                {
                    GetOrderedTable(sql + rbMid.Text + "'");
                }
                if (rbBig.Checked)
                {
                    GetOrderedTable(sql + rbBig.Text + "'");
                }
            }

        }
        #region Checked Changed
        private void rbNullTable_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void rbOrderTable_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void rbToday_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void rbAllKind_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void rbMid_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void rbBig_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
        }
        #endregion

        public void editOrder(object sender, EventArgs e)
        {
            OrderID = ((Label)sender).Tag.ToString();
            string sql = "select * from VOrderedTable where OrderID  = " + OrderID;
            reader = SqlClass.Reader(sql);
            while (reader.Read())
            {
                TableID = reader["ID"].ToString();
                TableName = reader["TName"].ToString();
            }
            reader.Close();

            Form f = new EditOrder();
            if(OrderID != "")
                f.ShowDialog();
        }
        public void addOrder(object sender, EventArgs e)
        {
            TableID = ((Label)sender).Tag.ToString();
            TableName =  SqlClass.GetOneValue("select TName from VEmptyTable where ID = " + TableID);

            Form f = new AddOrder();
            f.ShowDialog();
        }
        private void btnManagement_Click(object sender, EventArgs e)
        {
            Form f = new AddTable();
            f.ShowDialog();
        }

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            string sql = "";
            flpBookTable.Controls.Clear();
            if (txtSearch.Texts != "")
            {
                if (rbNullTable.Checked)
                {
                    sql = "exec PEmptyTableSearch N'%";
                    GetEmptyTable(sql + txtSearch.Texts + "%'");
                }
                if (rbToday.Checked)
                {
                    sql = "exec POrderedTableTodaySearch N'%";
                    GetOrderTableInToday(sql + txtSearch.Texts + "%'");
                }
                if (rbOrderTable.Checked)
                {
                    sql = "exec POrderedTableSearch N'%";
                    GetOrderedTable(sql + txtSearch.Texts + "%'");
                }
            }
        }

        private void btnManagement_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnManagement, Resources.Add_properties_20px1, true);
        }

        private void btnManagement_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnManagement, Resources.Add_properties_20px, false);
        }
    }
}

