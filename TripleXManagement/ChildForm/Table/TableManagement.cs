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
using static System.Net.Mime.MediaTypeNames;

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
        private PictureBox Timage;
        private Label Tcustomer;

        private Panel footer;
        private Label Tchair;
        private Label TbookDate;
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

        private void GetData()
        {
            string sql = "exec getTable";
            reader = StaticClass.SqlClass.Reader(sql);
            while (reader.Read())
            {
                pnTable = new Panel
                {
                    Size = new Size(250,150),
                    BackColor = Color.Red,
                };

                header = new Panel
                {
                    Size = new Size(250, 30),
                    BackColor = Color.Yellow,
                };

                footer = new Panel
                {
                    Size = new Size(250, 30),
                    BackColor = Color.Yellow,
                };

                Tname = new Label
                {
                    Text = reader["TableName"].ToString(),
                    BackColor = Color.Yellow,
                    Width = 50,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Bottom,
                    Tag = reader["ID"].ToString()
                };

                /*string status = reader["Status"].ToString();
                string statusT = "";
                if (status == "1")
                {
                    statusT = "Đã đặt";
                    //Timage.BackgroundImage = Properties.Resources.bill_32;
                }
                else
                {
                    statusT = "Trống";
                    //Timage.BackgroundImage = Properties.Resources.Male_user_32;
                }*/
                Tstatus = new Label
                {
                    Text = reader["Status"].ToString(),
                    BackColor = Color.Yellow,
                    Width = 50,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.None,
                    Tag = reader["ID"].ToString()
                };

                Timage = new PictureBox
                {
                    Width = 32,
                    Height = 32,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BorderStyle = BorderStyle.None,
                    Tag = reader["ID"].ToString()
                };

                Tcustomer = new Label
                {
                    Text = reader["CustomerName"].ToString(),
                    BackColor = Color.Yellow,
                    Width = 50,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.None,
                    Tag = reader["ID"].ToString()
                };

                TbookDate = new Label
                {
                    Text = reader["BookDate"].ToString(),
                    BackColor = Color.Yellow,
                    Width = 50,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.None,
                    Tag = reader["ID"].ToString()
                };

                Tchair = new Label
                {
                    Text = reader["Chair"].ToString(),
                    BackColor = Color.Yellow,
                    Width = 50,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.None,
                    Tag = reader["ID"].ToString()
                };

                header.Controls.Add(Tname);
                header.Controls.Add(Tstatus);
                pnTable.Controls.Add(header);

                body.Controls.Add(Timage);
                body.Controls.Add(Tcustomer);
                pnTable.Controls.Add(body);

                footer.Controls.Add(TbookDate);
                footer.Controls.Add(Tchair);
                pnTable.Controls.Add(footer);

                flowLayoutPanel1.Controls.Add(pnTable);
                //image.Click += new EventHandler(OnClick);
            }
            reader.Close();
        }
    }
}
