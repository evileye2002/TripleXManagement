using System.Drawing.Printing;
using System.Globalization;
using TripleXManagement.StaticClass;
using TripleXManagement.Properties;
using TripleXManagement.ChildForm.Table;
using System.Diagnostics;

namespace TripleXManagement.ChildForm.Bill
{
    public partial class BillDetail : Form
    {
        string price = "";
        string total = "";
        string finalTotalText = "";
        string finalTotalM = "";
        string finalTotalB = "";
        string path = @"E:\DAI_HOC\NAM_3\Ky 2\Thuc tap co so\TripleXManagement\Print\";
        public static double finalTotal = 0;
        public static string StaffName = "";
        public static string isBank = "";
        public static String BillID = "";
        public static String foodID = "";
        public static String BillDate = "";
        public static String CustomerName = "";
        

        public BillDetail()
        {
            InitializeComponent();
            dgvBillDetail.Columns[2].DefaultCellStyle.Format = "c";
            dgvBillDetail.Columns[4].DefaultCellStyle.Format = "c";
            dgvBillDetail.Columns[2].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vn-VN");
            dgvBillDetail.Columns[4].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vn-VN");
        }

        public static void  getBillDetail()
        {
            BillID = BillManagement.BillID;
            BillDate = BillManagement.BillDate;
            finalTotal = BillManagement.FinaTotal;
            isBank = BillManagement.IsBank;
            CustomerName = BillManagement.CustomerName;
            StaffName = BillManagement.StaffName;
        }

        private void GetData()
        {
            String sql = "exec PBillDetailFindByID N'" + BillID + "'";
            SharedClass.FillDGV(dgvBillDetail, sql);
        }

        private void BillDetail_Load(object sender, EventArgs e)
        {
            getBillDetail();
            finalTotalText = NumberToText(finalTotal);
            GetData();
        }
        public void sizePrintPage()
        {
            int a;
            if (dgvBillDetail.Rows.Count <= 8) { a = 0; }
            else { a = dgvBillDetail.Rows.Count * 46 - 400; }
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("size", 500, a + 710);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            int gap = 11;
            int gapDetail = 15;
            int startY = 20;
            int mn1 = 0;
            int mn2 = 0;
            int mn3 = 0;
            int rowCount = dgvBillDetail.Rows.Count;
            String? dash = "------------------------------------------------------------------------------------------------";
            Graphics? graphics = e.Graphics;
            Font font = new("Arial", 10, FontStyle.Regular);
            Font fontDetail = new("Arial", 8, FontStyle.Regular);
            Font fontTitle = new("Arial", 10, FontStyle.Bold);
            Brush brush = Brushes.Black;
            StringFormat formatLeft = new(StringFormatFlags.NoClip);
            StringFormat formatCenter = new(formatLeft);
            StringFormat formatRight = new(formatLeft);
            formatCenter.Alignment = StringAlignment.Center;
            formatRight.Alignment = StringAlignment.Far;
            formatLeft.Alignment = StringAlignment.Near;

            graphics.DrawString("NHÀ HÀNG TRIPLEX", new("Arial", 8, FontStyle.Bold), brush, new Point(25, startY));
            graphics.DrawString("Z115 - Tân Thịnh - Thái Nguyên", fontDetail, brush, new Point(25, startY += gapDetail));
            graphics.DrawString("0123456789", fontDetail, brush, new Point(25, startY += gapDetail));

            graphics.DrawString("HÓA ĐƠN", new Font("Arial", 16, FontStyle.Bold), brush, new Point(250, startY += gapDetail), formatCenter);

            int a1 = startY += 30;
            int a2 = startY += gapDetail;
            int a3 = startY += gapDetail;
            int a4 = startY += gapDetail;
            int a5 = startY += gapDetail;
            graphics.DrawString("Số Hóa đơn: ", font, brush, new Point(25, a1));
            graphics.DrawString("Ngày: ", font, brush, new Point(25, a2));
            graphics.DrawString("Thu ngân: ", font, brush, new Point(25, a3));
            graphics.DrawString("Quầy: ", font, brush, new Point(25, a4));
            graphics.DrawString("Khách hàng: ", font, brush, new Point(25, a5));

            graphics.DrawString(BillID, font, brush, new Point(125, a1));
            graphics.DrawString(BillDate, font, brush, new Point(125, a2));
            graphics.DrawString(StaffName, font, brush, new Point(125, a3));
            graphics.DrawString("Quầy 01", font, brush, new Point(125, a4));
            graphics.DrawString(CustomerName, font, brush, new Point(125, a5));

            graphics.DrawString(dash, font, brush, new Point(25, startY += gap));

            graphics.DrawString("Mã món", fontTitle, brush, new Point(25, startY += gap));
            graphics.DrawString("Đơn giá", fontTitle, brush, new Point(220, startY), formatRight);
            graphics.DrawString("Số lượng", fontTitle, brush, new Point(320, startY), formatRight);
            graphics.DrawString("Thành tiền", fontTitle, brush, new Point(470, startY), formatRight);

            for (int i = 0; i < rowCount; i++)
            {
                graphics.DrawString(dash, font, brush, new Point(25, i * gap + (startY += gap)));

                graphics.DrawString((i + 1) + "." + dgvBillDetail.Rows[i].Cells[1].Value.ToString(),
                    new("Arial", 10, FontStyle.Bold), brush, new Point(25, i * gap + (startY += gap)));

                graphics.DrawString(dash, font, brush, new Point(25, i * gap + (startY += gap)));

                int Y = startY;
                price = (String.Format(CultureInfo.InvariantCulture,"{0:0,0}", dgvBillDetail.Rows[i].Cells[2].Value));
                total = (String.Format(CultureInfo.InvariantCulture,"{0:0,0}", dgvBillDetail.Rows[i].Cells[4].Value));
                graphics.DrawString(dgvBillDetail.Rows[i].Cells[0].Value.ToString(),
                    font, brush, new Point(25, i * gap + (Y += gap)));
                graphics.DrawString(price,
                    font, brush, new Point(220, i * gap + Y), formatRight);
                graphics.DrawString(dgvBillDetail.Rows[i].Cells[3].Value.ToString(),
                    font, brush, new Point(320, i * gap + Y), formatRight);
                graphics.DrawString(total,
                    font, brush, new Point(430, i * gap + Y), formatRight);
                graphics.DrawString("VNĐ", font, brush, new Point(470, i * gap + Y), formatRight);

            }
            graphics.DrawString(dash, font, brush, new Point(25, rowCount * gap + (startY += gap)));

            graphics.DrawString("Bằng chữ: " + finalTotalText, font, brush, new Point(25, rowCount * gap + (startY += gapDetail)));
            graphics.DrawString("Tổng: ", font, brush, new Point(25, rowCount * gap + (mn1 += (startY += gapDetail))));
            graphics.DrawString("Tiền mặt: ", font, brush, new Point(25, rowCount * gap + (mn2 += (startY += gapDetail))));
            graphics.DrawString("Thẻ ngân hàng: ", font, brush, new Point(25, rowCount * gap + (mn3 += (startY += gapDetail))));

            string ft = String.Format(CultureInfo.InvariantCulture,"{0:0,0}", finalTotal);
            if (isBank == "2")
            {
                finalTotalM = "0";
                finalTotalB = ft;
            }

            else if (isBank == "1") 
            {
                finalTotalM = ft;
                finalTotalB = "0";
            }

            graphics.DrawString(ft, font, brush, new Point(430, rowCount * gap + mn1), formatRight);
            graphics.DrawString(finalTotalM, font, brush, new Point(430, rowCount * gap + mn2), formatRight);
            graphics.DrawString(finalTotalB, font, brush, new Point(430, rowCount * gap + mn3), formatRight);

            graphics.DrawString("VNĐ", font, brush, new Point(470, rowCount * gap + mn1), formatRight);
            graphics.DrawString("VNĐ", font, brush, new Point(470, rowCount * gap + mn2), formatRight);
            graphics.DrawString("VNĐ", font, brush, new Point(470, rowCount * gap + mn3), formatRight);

            graphics.DrawString(dash, font, brush, new Point(25, rowCount * gap + (startY += gap)));

            graphics.DrawString("QUÝ KHÁCH VUI LÒNG KIỂM TRA HÓA ĐƠN",
                new Font("Arial", 8, FontStyle.Regular), brush, new Point(250, rowCount * gap + (startY += gapDetail)), formatCenter);
            graphics.DrawString("TRƯỚC KHI RA KHỎI QUẦY",
                new Font("Arial", 8, FontStyle.Regular), brush, new Point(250, rowCount * gap + (startY += gapDetail)), formatCenter);
            graphics.DrawString("Xin chân thành cảm ơn quý khách và hẹn gặp lại",
                new Font("Arial", 8, FontStyle.Bold), brush, new Point(250, rowCount * gap + (startY += gapDetail)), formatCenter);

            e.HasMorePages = false;
        }

        private void btnPrintPriview_Click(object sender, EventArgs e)
        {
            sizePrintPage();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void print()
        {
            sizePrintPage();
            string filName = path + BillID + ".pdf";

            /*if (Directory.Exists(path) && !File.Exists(filName))
            {*/
                PrintDocument pdoc = new PrintDocument();
                pdoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                pdoc.PrinterSettings.PrintFileName = filName;
                pdoc.PrinterSettings.PrintToFile = true;
                pdoc.PrintPage += printDocument1_PrintPage;
                pdoc.Print();
                SharedClass.Alert("In Thành Công!", Form_Alert.enmType.Success);
            /*}
            else
                SharedClass.Alert("Hóa Đơn Đã Tồn Tại!", Form_Alert.enmType.Error);*/
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            print();
        }
        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng chẵn" : "");
        }

        private void BillDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                sizePrintPage();
                print();
                SharedClass.Alert("In Thành Công!", Form_Alert.enmType.Success);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                String sql = "exec PBillDetailDel " + foodID + ", '" + BillID + "'";
                var mainForm = Application.OpenForms.OfType<BillManagement>().Single();
                if (foodID != "")
                {
                    SqlClass.RunSqlDel(sql);

                    mainForm.GetData();
                }
                else
                    SharedClass.Alert("Chưa Chọn Món!", Form_Alert.enmType.Warning);
            }
        }

        private void dgvBillDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dgvBillDetail.SelectedRows.Count;
            if (selectedRow == 1)
            {
                int t = dgvBillDetail.CurrentCell.RowIndex;
                foodID = dgvBillDetail.Rows[t].Cells[0].Value.ToString();
            }
        }

        #region Hover State
        private void btnPrint_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnPrint, Resources.print_20px1, true);
        }

        private void btnPrint_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnPrint, Resources.print_20px, false);
        }

        private void btnPrintPreview_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnPrintPreview, Resources.detective_20px1, true);
        }

        private void btnPrintPreview_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnPrintPreview, Resources.detective_20px, false);
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnClose, Resources.reply_arrow_20px1, true);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnClose, Resources.reply_arrow_20px, false);
        }
        private void btnOpenFolder_MouseEnter(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnOpenFolder, Resources.opened_folder_20px1, true);
        }

        private void btnOpenFolder_MouseLeave(object sender, EventArgs e)
        {
            SharedClass.HoverBtnState(btnOpenFolder, Resources.opened_folder_20px, false);
        }
        #endregion

        private void BillDetail_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedForm(this, 20, e.Graphics, Color.FromArgb(98, 102, 244), 2);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            SharedClass.RoundedControl(panel2, 15, e.Graphics, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(@"explorer.exe",path);
        }
    }
}
