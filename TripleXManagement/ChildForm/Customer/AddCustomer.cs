﻿using System.Drawing.Drawing2D;
using TripleXManagement.StaticClass;
using TripleXManagement.Properties;

namespace TripleXManagement.ChildForm.Customer
{
    public partial class AddCustomer : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(98, 102, 244);
        public AddCustomer()
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
            SharedClass.HoverSubBtnState(btnClose, Resources.reply_arrow_20px1, true);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnClose, Resources.reply_arrow_20px, false);
        }
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Resources.save_20px1, true);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverSubBtnState(btnSave, Resources.save_20px, false);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "exec PCustomerAdd N'" + txtName.Texts + "','" + txtCCCD.Texts + "',N'" + 
                            txtAddress.Texts + "','" + txtPhone.Texts + "'";

            if (txtCCCD.Texts != "" && txtCCCD.Texts != "" && txtName.Texts != "" && txtPhone.Texts != "")
            {
                if (txtCCCD.Texts.Length > 12 || txtCCCD.Texts.Length < 12)
                    SharedClass.Alert("CCCD Không Đúng\n12 Kí Tự!", Form_Alert.enmType.Error);
                else if (txtPhone.Texts.Length > 10 || txtPhone.Texts.Length < 10)
                    SharedClass.Alert("Số Điện Thoại Không Đúng\n10 Kí Tự!", Form_Alert.enmType.Error);
                else if (long.TryParse(txtCCCD.Texts, out long a) != true)
                    SharedClass.Alert("CCCD Không Đúng\nĐịnh Dạng!", Form_Alert.enmType.Error);
                else if (long.TryParse(txtPhone.Texts, out long b) != true)
                    SharedClass.Alert("Số Điện Thoại Không Đúng\nĐịnh Dạng!", Form_Alert.enmType.Error);
                else
                {
                    var mainForm = Application.OpenForms.OfType<CustomerManagement>().Single();
                    try
                    {
                        SqlClass.RunSql(sql);
                        SharedClass.Alert("Lưu Thành Công!", Form_Alert.enmType.Success);
                        mainForm.GetData();
                    }
                    catch (Exception ex)
                    {
                        CMessageBox.Show(ex.ToString(), "Có gì đó không đúng!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                SharedClass.Alert("Chưa Nhập Đủ Dữ Liệu!", Form_Alert.enmType.Warning);
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            SqlClass.Connect();
        }
    }
}
