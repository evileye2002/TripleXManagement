using System.Data.SqlClient;
using TripleXManagement.StaticClass;
using TripleXManagement.Properties;

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

            Color bodyFC = Color.FromArgb(245, 255, 255);
            Color bodyBC = Color.Gray;
            Color footerBC = Color.LightGray;
            Color footerFC = Color.FromArgb(39, 39, 58);

            while (reader.Read())
            {
                pnTable = new Panel
                {
                    Size = new Size(250,150),
                    Cursor = Cursors.Hand,
                    Tag = reader["OrderID"].ToString()
                };

                body = new Panel
                {
                    BackColor = bodyBC,
                    ForeColor = bodyFC,
                    Font = new("Arial", 12, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                };

                header = new Panel
                {
                    Size = new Size(250, 30),
                    BackColor = bodyBC,
                    ForeColor = bodyFC,
                    Font = new("Arial", 10, FontStyle.Bold),
                    Dock = DockStyle.Top,
                };

                footer = new Panel
                {
                    Size = new Size(250, 30),
                    BackColor = footerBC,
                    ForeColor = footerFC,
                    Font = new("Arial", 10, FontStyle.Bold),
                    Dock = DockStyle.Bottom,
                };

                pic = new Panel
                {
                    Dock = DockStyle.Fill,
                };
                picT = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 64,
                };
                picB = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 26,
                };
                picL = new Panel
                {
                    Dock = DockStyle.Left,
                    Width = 34,
                };

                Tname = new Label
                {
                    Padding = new Padding(10,6, 0, 0),
                    Text = reader["TName"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.None,
                    Tag = reader["OrderID"].ToString()
                };

                Tstatus = new Label
                {
                    Padding = new Padding(2, 6, 0, 0),
                    Text = "Hôm nay nhận bàn",
                    Size = new Size(155, 30),
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Right,
                    RightToLeft = RightToLeft.Yes,
                    Tag = reader["OrderID"].ToString(),
                };

                img = new CustomControl.CButton
                {
                    Dock = DockStyle.Fill,
                    BackColor = bodyBC, 
                    Tag = reader["OrderID"].ToString(),
                    Enabled = false,
                };
                if(reader["CustomerName"].ToString().Length >= 50)
                {

                }
                Tcustomer = new Label
                {
                    Padding = new Padding(0, 40, 0, 0),
                    Text = reader["CustomerName"].ToString(),
                    Size = new Size(185,30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Right,
                    Tag = reader["OrderID"].ToString()
                };

                TGetDate = new Label
                {
                    Padding = new Padding(10, 6, 0, 5),
                    Text = "Ngày: " + reader["OTake"].ToString(),
                    Size = new Size(180, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Left,
                    Tag = reader["OrderID"].ToString(),
                };

                Tchair = new Label
                {
                    Padding = new Padding(0, 6, 10, 5),
                    Text = "Ghế: " + reader["TChair"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Right,
                    Tag = reader["OrderID"].ToString(),
                };
                img.BackgroundImage = Resources.customer_32px;

                header.Controls.Add(Tname);
                header.Controls.Add(Tstatus);
                pnTable.Controls.Add(header);

                pic.Controls.Add(picT);
                pic.Controls.Add(picB);
                pic.Controls.Add(picL);
                pic.Controls.Add(img);
                body.Controls.Add(pic);
                body.Controls.Add(Tcustomer);
                pnTable.Controls.Add(body);

                footer.Controls.Add(TGetDate);
                footer.Controls.Add(Tchair);
                pnTable.Controls.Add(footer);

                flpBookTable.Controls.Add(pnTable);
                Tcustomer.Click += new EventHandler(editOrder);
                Tname.Click += new EventHandler(editOrder);
                TGetDate.Click += new EventHandler(editOrder);
                Tstatus.Click += new EventHandler(editOrder);
                Tchair.Click += new EventHandler(editOrder);
            }
            reader.Close();
        }
        private void GetEmptyTable(string sql)
        {
            reader = SqlClass.Reader(sql);

            Color bodyFC = Color.FromArgb(245, 255, 255);
            Color bodyBC = Color.FromArgb(98, 102, 244);
            Color footerBC = Color.LightGray;
            Color footerFC = Color.FromArgb(39, 39, 58);


            while (reader.Read())
            {
                pnTable = new Panel
                {
                    Size = new Size(250, 150),
                    Cursor = Cursors.Hand,
                    Tag = reader["ID"].ToString()
                };

                body = new Panel
                {
                    BackColor = bodyBC,
                    ForeColor = bodyFC,
                    Font = new("Arial", 12, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                };

                header = new Panel
                {
                    Size = new Size(250, 30),
                    BackColor = bodyBC,
                    ForeColor = bodyFC,
                    Font = new("Arial", 10, FontStyle.Bold),
                    Dock = DockStyle.Top,
                };

                footer = new Panel
                {
                    Size = new Size(250, 30),
                    BackColor = footerBC,
                    ForeColor = footerFC,
                    Font = new("Arial", 10, FontStyle.Bold),
                    Dock = DockStyle.Bottom,
                };

                pic = new Panel
                {
                    Dock = DockStyle.Fill,
                };
                picT = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 64,
                };
                picB = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 26,
                };
                picL = new Panel
                {
                    Dock = DockStyle.Left,
                    Width = 34,
                };

                Tname = new Label
                {
                    Padding = new Padding(10, 6, 0, 0),
                    Text = reader["TName"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.None,
                    Tag = reader["ID"].ToString()
                };

                Tstatus = new Label
                {
                    Padding = new Padding(0, 6, 10, 0),
                    Text = reader["TStatus"].ToString(),
                    Size = new Size(95, 30),
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Right,
                    RightToLeft = RightToLeft.Yes,
                    Tag = reader["ID"].ToString(),
                };

                img = new CustomControl.CButton
                {
                    Dock = DockStyle.Fill,
                    BackColor = bodyBC,
                    Tag = reader["ID"].ToString(),
                    Enabled = false,
                };

                Tcustomer = new Label
                {
                    Padding = new Padding(0, 40, 0, 0),
                    Text = reader["TStatus"].ToString(),
                    Size = new Size(185, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Right,
                    Tag = reader["ID"].ToString()
                };

                TGetDate = new Label
                {
                    Padding = new Padding(10, 6, 0, 5),
                    Text = "Ngày: 0",
                    Size = new Size(180, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Left,
                    Tag = reader["ID"].ToString(),
                };

                Tchair = new Label
                {
                    Padding = new Padding(0, 6, 10, 5),
                    Text = "Ghế: " + reader["TChair"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Right,
                    Tag = reader["ID"].ToString(),
                };
                img.BackgroundImage = Resources.coffee_table_32px;

                header.Controls.Add(Tname);
                header.Controls.Add(Tstatus);
                pnTable.Controls.Add(header);

                pic.Controls.Add(picT);
                pic.Controls.Add(picB);
                pic.Controls.Add(picL);
                pic.Controls.Add(img);
                body.Controls.Add(pic);
                body.Controls.Add(Tcustomer);
                pnTable.Controls.Add(body);

                footer.Controls.Add(TGetDate);
                footer.Controls.Add(Tchair);
                pnTable.Controls.Add(footer);

                flpBookTable.Controls.Add(pnTable);
                Tcustomer.Click += new EventHandler(addOrder);
                Tname.Click += new EventHandler(addOrder);
                TGetDate.Click += new EventHandler(addOrder);
                Tstatus.Click += new EventHandler(addOrder);
                Tchair.Click += new EventHandler(addOrder);
            }
            reader.Close();
        }
        private void GetOrderedTable(string sql)
        {
            reader = SqlClass.Reader(sql);

            Color bodyFC = Color.FromArgb(245, 255, 255);
            Color bodyBC = Color.Gray;
            Color footerBC = Color.LightGray;
            Color footerFC = Color.FromArgb(39, 39, 58);


            while (reader.Read())
            {
                pnTable = new Panel
                {
                    Size = new Size(250, 150),
                    Cursor = Cursors.Hand,
                    Tag = reader["OrderID"].ToString()
                };

                body = new Panel
                {
                    BackColor = bodyBC,
                    ForeColor = bodyFC,
                    Font = new("Arial", 12, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                };

                header = new Panel
                {
                    Size = new Size(250, 30),
                    BackColor = bodyBC,
                    ForeColor = bodyFC,
                    Font = new("Arial", 10, FontStyle.Bold),
                    Dock = DockStyle.Top,
                };

                footer = new Panel
                {
                    Size = new Size(250, 30),
                    BackColor = footerBC,
                    ForeColor = footerFC,
                    Font = new("Arial", 10, FontStyle.Bold),
                    Dock = DockStyle.Bottom,
                };

                pic = new Panel
                {
                    Dock = DockStyle.Fill,
                };
                picT = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 64,
                };
                picB = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 26,
                };
                picL = new Panel
                {
                    Dock = DockStyle.Left,
                    Width = 34,
                };

                Tname = new Label
                {
                    Padding = new Padding(10, 6, 0, 0),
                    Text = reader["TName"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.None,
                    Tag = reader["OrderID"].ToString()
                };

                Tstatus = new Label
                {
                    Padding = new Padding(0, 6, 10, 0),
                    Text = reader["TStatus"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Right,
                    RightToLeft = RightToLeft.Yes,
                    Tag = reader["OrderID"].ToString(),
                };

                img = new CustomControl.CButton
                {
                    Dock = DockStyle.Fill,
                    BackColor = bodyBC,
                    Tag = reader["ID"].ToString(),
                    Enabled = false,
                };

                Tcustomer = new Label
                {
                    Padding = new Padding(0, 40, 0, 0),
                    Text = reader["CustomerName"].ToString(),
                    Size = new Size(185, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Right,
                    Tag = reader["OrderID"].ToString()
                };

                TGetDate = new Label
                {
                    Padding = new Padding(10, 6, 0, 5),
                    Text = "Ngày: " + reader["OTake"].ToString(),
                    Size = new Size(180, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Left,
                    Tag = reader["OrderID"].ToString(),
                };

                Tchair = new Label
                {
                    Padding = new Padding(0, 6, 10, 5),
                    Text = "Ghế: " + reader["TChair"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Right,
                    Tag = reader["OrderID"].ToString(),
                };
                img.BackgroundImage = Resources.customer_32px;

                header.Controls.Add(Tname);
                header.Controls.Add(Tstatus);
                pnTable.Controls.Add(header);

                pic.Controls.Add(picT);
                pic.Controls.Add(picB);
                pic.Controls.Add(picL);
                pic.Controls.Add(img);
                body.Controls.Add(pic);
                body.Controls.Add(Tcustomer);
                pnTable.Controls.Add(body);

                footer.Controls.Add(TGetDate);
                footer.Controls.Add(Tchair);
                pnTable.Controls.Add(footer);

                flpBookTable.Controls.Add(pnTable);
                Tcustomer.Click += new EventHandler(editOrder);
                Tname.Click += new EventHandler(editOrder);
                TGetDate.Click += new EventHandler(editOrder);
                Tstatus.Click += new EventHandler(editOrder);
                Tchair.Click += new EventHandler(editOrder);
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

