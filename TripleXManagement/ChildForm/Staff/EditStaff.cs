using CustomAlertBox;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using TripleXManagement.ChildForm.Table;
using TripleXManagement.StaticClass;
using Image = System.Drawing.Image;

namespace TripleXManagement.ChildForm.Staff
{
    public partial class EditStaff : Form
    {
        public static string ID = "";
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        private SqlDataReader reader;
        private SqlConnection conn;
        private SqlCommand cmd;

        public EditStaff()
        {
            InitializeComponent();
            conn = SqlClass.Connection;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderRadius);
        }

        private void EditStaff_Load(object sender, EventArgs e)
        {
            GetData();
            SqlClass.Connect();
        }
        private void GetData()
        {
            ID = StaffManagement.ID;
            SharedClass.FillCBB("select * from Regency", cbRegency, "Name");
            SharedClass.FillCBB("select * from Account", cbAccount, "Username");
            string sql = "exec getStaffbyID " + ID;
            reader = SqlClass.Reader(sql);
            while (reader.Read())
            {
                long len = reader.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[Convert.ToInt32(len) + 1];
                reader.GetBytes(0, 0, array, 0, Convert.ToInt32(len));
                MemoryStream ms = new(array);
                Bitmap bitmap = new(ms);
                pbPic.BackgroundImage = bitmap;

                txtName.Texts = reader["Name"].ToString();
                txtCCCD.Texts = reader["CCCD"].ToString();
                txtPhone.Texts = reader["Phone"].ToString();
                cbRegency.Texts = reader["Regency"].ToString();
                cbAccount.Texts = reader["Account"].ToString();
            }
            reader.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCCCD.Texts != "" && txtName.Texts != "" && txtPhone.Texts != "")
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pbPic.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                    byte[] array = ms.GetBuffer();

                    cmd = new SqlCommand("exec editStaffbyID @ID, @Name, @CCCS, @Phone,@Regency,@Account,@Image", conn);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Name", txtName.Texts);
                    cmd.Parameters.AddWithValue("@CCCS", txtCCCD.Texts);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Texts);
                    cmd.Parameters.AddWithValue("@Regency", cbRegency.Texts);
                    cmd.Parameters.AddWithValue("@Account", cbAccount.Texts);
                    cmd.Parameters.AddWithValue("@Image", array);
                    cmd.ExecuteNonQuery();

                    GetData();
                    var mainForm = Application.OpenForms.OfType<StaffManagement>().Single();
                    mainForm.GetData();
                    SharedClass.Alert("Sửa Thành Công!", Form_Alert.enmType.Success);
                }
                catch
                {
                    SharedClass.Alert("Chưa Chọn Ảnh!", Form_Alert.enmType.Error);
                }
            }
            else
                SharedClass.Alert("Chưa Nhập Dữ Liệu!", Form_Alert.enmType.Warning);
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdBrowse.Filter = "Image files (*.jpeg)|*.jpeg|(*.png)|*.png|(*.jpg)|*.jpg|(*.gif)|*.gif";
            ofdBrowse.ShowDialog();

            if (ofdBrowse.FileName != "openFileDialog1")
            {
                pbPic.BackgroundImage = Image.FromFile(ofdBrowse.FileName);
                pbPic.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        #region HoverState
        private void btnBrowse_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnBrowse, Properties.Resources.denied_20px, true);
        }

        private void btnBrowse_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnBrowse, Properties.Resources.denied_20px, false);
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Properties.Resources.denied_20px, true);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Properties.Resources.denied_20px, false);
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Properties.Resources.denied_20px, true);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Properties.Resources.denied_20px, false);
        }
        #endregion
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
        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYes.Checked)
                SharedClass.FillCBB("select * from Account", cbAccount, "Username");
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNo.Checked)
                if (cbAccount.DataSource != null)
                    cbAccount.DataSource = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
