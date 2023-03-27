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
        double _total;
        double _price = 0;
        int isBank = 0;
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
        private Panel picR;
        private PictureBox Timage;
        private CustomControl.RJButton img;
        private CustomControl.RJRadioButton rb;
        private Label Tcustomer;

        private Panel footer;
        private Label Tchair;
        private Label TGetDate;
        //private Button button;
        public TableManagement()
        {
            InitializeComponent();
        }

        private void TableManagement_Load(object sender, EventArgs e)
        {
            StaticClass.SqlClass.Connect();
            GetData();
        }

        private void GetOrderTableInToday()
        {
            string sql = "exec getOrderTableInToday";
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
                picR = new Panel
                {
                    Dock = DockStyle.Right,
                    Width = 39,
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

                Timage = new PictureBox
                {
                    
                    Padding = new Padding(10),
                    Size = new Size(32,32),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BorderStyle = BorderStyle.None,
                    Dock = DockStyle.None,
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
                //image.Click += new EventHandler(OnClick);
            }
            reader.Close();
        }
        private void GetEmptyTable()
        {
            string sql = "exec getEmptyTable";
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
                picR = new Panel
                {
                    Dock = DockStyle.Right,
                    Width = 39,
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
                //image.Click += new EventHandler(OnClick);
            }
            reader.Close();
        }
        private void GetOrderedTable()
        {
            string sql = "exec getOrderedTable";
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
                picR = new Panel
                {
                    Dock = DockStyle.Right,
                    Width = 39,
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

                Timage = new PictureBox
                {

                    Padding = new Padding(10),
                    Size = new Size(32, 32),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BorderStyle = BorderStyle.None,
                    Dock = DockStyle.None,
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
                //image.Click += new EventHandler(OnClick);
            }
            reader.Close();
        }
        private void GetData()
        {
            flpBookTable.Controls.Clear();
            if (rbNullTable.Checked == true)
            {
                GetEmptyTable();
            }
            if (rbToday.Checked == true)
            {
                GetOrderTableInToday();
            }
            if (rbOrderTable.Checked == true)
            {
                GetOrderedTable();
            }
        }
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
    }
}
