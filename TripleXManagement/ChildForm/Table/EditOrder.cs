using CustomAlertBox;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using TripleXManagement.StaticClass;

namespace TripleXManagement.ChildForm.Table
{
    public partial class EditOrder : Form
    {
        public static string TableID = "";
        public static string OrderID = "";
        public static string empty = "";
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        public EditOrder()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderRadius);
        }
        private void GetData()
        {
            OrderID = TableManagement.OrderID;
            TableID = TableManagement.TableID;
            lbTableName.Text = TableManagement.TableName;

            string sql = "select * from VOrderedTable where OrderID = " + OrderID;
            SqlDataReader reader = SqlClass.Reader(sql);
            if (reader.HasRows)
            {
                rbOrdered.Checked = true;
                while (reader.Read())
                {
                    txtName.Texts = reader["CustomerName"].ToString();
                    txtOrderDate.Texts = DateToString(reader["OBook"].ToString());
                    txtGetDate.Texts = reader["OTake"].ToString();
                }
            }
            reader.Close();
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {
            SqlClass.Connect();
            GetData();
        }
        #region Round
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
        private void FormRegionAndBorder2(Panel panel2, int borderRadius, Graphics graphics, int borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(panel2.ClientRectangle, borderRadius))
                using (Matrix transform = new Matrix())
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    panel2.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = panel2.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);

                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);

                        graphics.Transform = transform;
                    }

                }
            }
        }
        #endregion

        #region HoverState
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Properties.Resources.denied_20px, true);
        }
        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Properties.Resources.denied_20px, false);
        }
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Properties.Resources.denied_20px, true);
        }
        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Properties.Resources.denied_20px, false);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbEmpty.Checked)
            {
                empty = "exec PEmptyAOrderedTable " + TableID + "," + OrderID;
                SqlClass.RunSql(empty);
                SharedClass.Alert("Sửa Thành Công!", Form_Alert.enmType.Success);
                var mainForm = Application.OpenForms.OfType<TableManagement>().Single();
                mainForm.GetData();
            }

        }
        private string DateToString(string dtpDate)
        {
            DateTime dtOrederDate = DateTime.ParseExact(dtpDate, "dd/MM/yyyy HH:mm:ss", SharedClass.cultureVN);
            string date = dtOrederDate.ToString("dd/MM/yyyy HH:mm:ss", SharedClass.cultureVN);
            return date;
        }

    }
}
