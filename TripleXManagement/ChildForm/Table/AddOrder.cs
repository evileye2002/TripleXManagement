using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using TripleXManagement.CustomControl;

namespace TripleXManagement.ChildForm.Table
{
    public partial class AddOrder : Form
    {
        public static string ID = "";
        public static string CustomerID = "";
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        SqlDataReader reader;
        public AddOrder()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderRadius);
        }
        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);

                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);

                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }

        private void AddTable_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder2(panel2, borderRadius, e.Graphics, borderSize);
        }
        private void FormRegionAndBorder2(Control c, int borderRadius, Graphics graphics, int borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(c.ClientRectangle, borderRadius))
                using (Matrix transform = new Matrix())
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    c.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = c.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);

                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);

                        graphics.Transform = transform;
                    }

                }
            }
        }

        private void dgvCustomer_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder2(dgvCustomer, 15, e.Graphics, borderSize);
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnClose, Properties.Resources.denied_20px, true);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnClose, Properties.Resources.denied_20px, false);
        }
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnSave, Properties.Resources.denied_20px, true);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnSave, Properties.Resources.denied_20px, false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "exec addOrderTable " + ID + "," + CustomerID + ",N'" 
                + DateToString(dtpOrderDate) + " " + TimeToString(dtpOrderTime) + "',N'" 
                + DateToString(dtpGetDate) + " " + TimeToString(dtpGetTime) + "'";
            StaticClass.SqlClass.RunSql(sql);
            
        }
        private string DateToString(RJDatePicker dtpDate)
        {
            DateTime dtOrederDate = DateTime.ParseExact(dtpDate.Value.ToString(), "dd/MM/yyyy HH:mm:ss", StaticClass.SharedClass.cultureVN);
            string date = dtOrederDate.ToString("dd/MM/yyyy", StaticClass.SharedClass.cultureVN);
            return date;
        }
        private string TimeToString(RJDatePicker dtpTime)
        {
            DateTime dtOrderTime = DateTime.ParseExact(dtpTime.Value.ToString(), "dd/MM/yyyy HH:mm:ss", StaticClass.SharedClass.cultureVN);
            string time = dtOrderTime.ToString("HH:mm:ss", StaticClass.SharedClass.cultureVN);
            return time;
        }
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvCustomer.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvCustomer.CurrentCell.RowIndex;
                CustomerID = dgvCustomer.Rows[t].Cells[0].Value.ToString();
                txtName.Texts = dgvCustomer.Rows[t].Cells[1].Value.ToString();
            }
        }
        private void GetData()
        {
            ID = TableManagement.tag;
            string sql = "exec getCustomer";
            StaticClass.SharedClass.FillDGV(dgvCustomer, sql);
            string sql2 = "exec getTablebyID " + ID;
            reader = StaticClass.SqlClass.Reader(sql2);
            while (reader.Read())
            {
                lbTableName.Text = reader.GetValue(1).ToString();
            }
            reader.Close();
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
