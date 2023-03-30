using CustomAlertBox;
using System.Drawing.Drawing2D;
using TripleXManagement.ChildForm.Staff;
using TripleXManagement.StaticClass;

namespace TripleXManagement.ChildForm.Customer
{
    public partial class EditCustomer : Form
    {
        public static string ID = "";
        public static string name = "";
        public static string CCCD = "";
        public static string address = "";
        public static string phone = "";
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        public EditCustomer()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderRadius);
        }

        #region Rounded
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
            string sql = "exec PCustomerEdit " + ID + ",N'" + txtName.Texts + "','" + txtCCCD.Texts + "',N'" + 
                txtAddress.Texts + "','" + txtPhone.Texts + "'";

            if (txtCCCD.Texts != "" && txtCCCD.Texts != "" && txtName.Texts != "" && txtPhone.Texts != "")
            {
                SqlClass.RunSql(sql);
                SharedClass.Alert("Sửa Thành Công!", Form_Alert.enmType.Success);
                var mainForm = Application.OpenForms.OfType<CustomerManagement>().Single();
                mainForm.GetData();
            }
            else
                SharedClass.Alert("Chưa Nhập Dữ Liệu!", Form_Alert.enmType.Warning);
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            SqlClass.Connect();
            GetData();
        }
        private void GetData()
        {
            ID = CustomerManagement.ID;
            txtName.Texts = CustomerManagement.name;
            txtCCCD.Texts = CustomerManagement.CCCD;
            txtAddress.Texts = CustomerManagement.address;
            txtPhone.Texts = CustomerManagement.phone;
        }
    }
}
