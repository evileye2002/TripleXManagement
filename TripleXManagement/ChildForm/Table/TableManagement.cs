using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripleXManagement.ChildForm.Table
{
    public partial class TableManagement : Form
    {
        private Form activateForm;
        public static string tag = "";
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
        private CustomControl.RJButton img;
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
            StaticClass.SqlClass.Connect();
            string sql = "exec getOrderTableInToday";
            reader = StaticClass.SqlClass.Reader(sql);
            if (reader.HasRows)
            {
                reader.Close();
                rbToday.Checked = true;
            }
            GetData();
        }

        private void GetOrderTableInToday(string sql)
        {
            reader = StaticClass.SqlClass.Reader(sql);

            Color bodyFC = Color.FromArgb(245,255,255);
            Color bodyBC = Color.LimeGreen;
            Color footerBC = Color.LightGray;
            Color footerFC = Color.FromArgb(39, 39, 58);


            while (reader.Read())
            {
                pnTable = new Panel
                {
                    Size = new Size(250,150),
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
                    Padding = new Padding(10,6, 0, 0),
                    Text = reader["Name"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.None,
                    Tag = reader["ID"].ToString()
                };

                Tstatus = new Label
                {
                    Padding = new Padding(0, 6, 10, 0),
                    Text = reader["StatusName"].ToString(),
                    Size = new Size(155, 30),
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Right,
                    RightToLeft = RightToLeft.Yes,
                    Tag = reader["ID"].ToString(),
                };

                img = new CustomControl.RJButton
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
                    Size = new Size(180,30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Right,
                    Tag = reader["ID"].ToString()
                };

                TGetDate = new Label
                {
                    Padding = new Padding(10, 6, 0, 5),
                    Text = "Ngày: " + reader["StatusName"].ToString(),
                    Size = new Size(130, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Left,
                    Tag = reader["ID"].ToString(),
                };

                Tchair = new Label
                {
                    Padding = new Padding(0, 6, 10, 5),
                    Text = "Ghế: " + reader["Chair"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Right,
                    Tag = reader["ID"].ToString(),
                };
                img.BackgroundImage = Properties.Resources.bill_32;

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
                Tcustomer.Click += new EventHandler(OnClick);
                Tname.Click += new EventHandler(OnClick);
                TGetDate.Click += new EventHandler(OnClick);
                Tstatus.Click += new EventHandler(OnClick);
                Tchair.Click += new EventHandler(OnClick);
            }
            reader.Close();
        }
        private void GetEmptyTable(string sql)
        {
            reader = StaticClass.SqlClass.Reader(sql);

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
                    Text = reader["Name"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.None,
                    Tag = reader["ID"].ToString()
                };

                Tstatus = new Label
                {
                    Padding = new Padding(0, 6, 10, 0),
                    Text = reader["StatusName"].ToString(),
                    Size = new Size(95, 30),
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Right,
                    RightToLeft = RightToLeft.Yes,
                    Tag = reader["ID"].ToString(),
                };

                img = new CustomControl.RJButton
                {
                    Dock = DockStyle.Fill,
                    BackColor = bodyBC,
                    Tag = reader["ID"].ToString(),
                    Enabled = false,
                };

                Tcustomer = new Label
                {
                    Padding = new Padding(0, 40, 0, 0),
                    Text = reader["StatusName"].ToString(),
                    Size = new Size(180, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Right,
                    Tag = reader["ID"].ToString()
                };

                TGetDate = new Label
                {
                    Padding = new Padding(10, 6, 0, 5),
                    Text = "Ngày: " + reader["Date"].ToString(),
                    Size = new Size(180, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Left,
                    Tag = reader["ID"].ToString(),
                };

                Tchair = new Label
                {
                    Padding = new Padding(0, 6, 10, 5),
                    Text = "Ghế: " + reader["Chair"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Right,
                    Tag = reader["ID"].ToString(),
                };
                img.BackgroundImage = Properties.Resources.bill_32;

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
                Tcustomer.Click += new EventHandler(OnClick);
                Tname.Click += new EventHandler(OnClick);
                TGetDate.Click += new EventHandler(OnClick);
                Tstatus.Click += new EventHandler(OnClick);
                Tchair.Click += new EventHandler(OnClick);
            }
            reader.Close();
        }
        private void GetOrderedTable(string sql)
        {
            reader = StaticClass.SqlClass.Reader(sql);

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
                    Text = reader["Name"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.None,
                    Tag = reader["ID"].ToString()
                };

                Tstatus = new Label
                {
                    Padding = new Padding(0, 6, 10, 0),
                    Text = reader["StatusName"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Right,
                    RightToLeft = RightToLeft.Yes,
                    Tag = reader["ID"].ToString(),
                };

                img = new CustomControl.RJButton
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
                    Size = new Size(180, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Right,
                    Tag = reader["ID"].ToString()
                };

                TGetDate = new Label
                {
                    Padding = new Padding(10, 6, 0, 5),
                    Text = "Ngày: " + reader["Get"].ToString(),
                    Size = new Size(180, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Left,
                    Tag = reader["ID"].ToString(),
                };

                Tchair = new Label
                {
                    Padding = new Padding(0, 6, 10, 5),
                    Text = "Ghế: " + reader["Chair"].ToString(),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Right,
                    Tag = reader["ID"].ToString(),
                };
                img.BackgroundImage = Properties.Resources.bill_32;

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
                Tcustomer.Click += new EventHandler(OnClick);
                Tname.Click += new EventHandler(OnClick);
                TGetDate.Click += new EventHandler(OnClick);
                Tstatus.Click += new EventHandler(OnClick);
                Tchair.Click += new EventHandler(OnClick);
            }
            reader.Close();
        }
        private void GetData()
        {
            flpBookTable.Controls.Clear();
            string sql = "";
            if (rbAllKind.Checked)
            {
                if (rbNullTable.Checked)
                {
                    sql = "exec getEmptyTable";
                    GetEmptyTable(sql);
                }
                if (rbToday.Checked)
                {
                    sql = "exec getOrderTableInToday";
                    GetOrderTableInToday(sql);
                }
                if (rbOrderTable.Checked)
                {
                    sql = "exec getOrderedTable";
                    GetOrderedTable(sql);
                }
            }

            if (rbNullTable.Checked)
            {
                sql = "exec getEmptyTablebyKind N'";
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
                sql = "exec getOrderTableInTodaybyKind N'";
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
                sql = "exec getOrderedTablebyKind N'";
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

        public void OnClick(object sender, EventArgs e)
        {
            tag = ((Label)sender).Tag.ToString();
            MessageBox.Show(tag);
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
        private void btnManagement_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form, sender);
        }

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            string sql = "";
            flpBookTable.Controls.Clear();
            if (txtSearch.Texts != "")
            {
                if (rbNullTable.Checked)
                {
                    sql = "exec getEmptyTableSearch N'%";
                    GetEmptyTable(sql + txtSearch.Texts + "%'");
                }
                if (rbToday.Checked)
                {
                    sql = "exec getOrderTableInTodaySearch N'%";
                    GetOrderTableInToday(sql + txtSearch.Texts + "%'");
                }
                if (rbOrderTable.Checked)
                {
                    sql = "exec getOrderedTableSearch N'%";
                    GetOrderedTable(sql + txtSearch.Texts + "%'");
                }
            }
        }
    }
}

