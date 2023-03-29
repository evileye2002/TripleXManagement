using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using TripleXManagement.StaticClass;

namespace TripleXManagement.ChildForm.Staff
{
    public partial class AddStaff : Form
    {
        SqlCommand cmd;
        SqlConnection conn;
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        public AddStaff()
        {
            InitializeComponent();
            conn = SqlClass.Connection;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderRadius);
        }
        private void GetData()
        {
            SharedClass.FillCBB("select * from Regency", cbRegency,"Name");
            SharedClass.FillCBB("select * from Account", cbAccount,"Username");
            
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            GetData();
            SqlClass.Connect();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pbPic.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                byte[] array = ms.GetBuffer();

                
                cmd = new SqlCommand("exec addStaff @Name, @CCCD, @Phone, @Image, @Regency, @Account", conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Texts);
                cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Texts);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Texts);
                cmd.Parameters.AddWithValue("@Regency", cbRegency.Texts);
                cmd.Parameters.AddWithValue("@Account", cbAccount.Texts);
                cmd.Parameters.AddWithValue("@Image", array);
                cmd.ExecuteNonQuery();

                clear();
                MessageBox.Show("Đã lưu!", "THÔNG BÁO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CẢNH BÁO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void clear()
        {
            txtName.Texts = "";
            txtCCCD.Texts = "";
            txtPhone.Texts = "";
            pbPic.BackgroundImage = null;
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
