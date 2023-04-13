using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripleXManagement.ChildForm.Table
{
    public partial class CTable : UserControl
    {

        #region Fields
        private string id = "";
        private string name = "B000";
        private string status = "Bàn Trống";
        private string customer = "Customer";
        private string orderDate = "Ngày: 0";
        private string chair = "0";
        private Image image = Properties.Resources.coffee_table_32px;
        #endregion

        #region Events
        public event EventHandler _CClick;
        #endregion

        #region Properties
        [Category("CTable Setting")]
        public string TableID
        {
            get { return id; }
            set
            {
                id = value;
                lbCustomer.Tag = id;
                Invalidate();
            }
        }

        [Category("CTable Setting")]
        public string TableName
        {
            get { return name; }
            set
            {
                name = value;
                lbName.Text = name;
                Invalidate();
            }
        }

        [Category("CTable Setting")]
        public string TableStatus
        {
            get { return status; }
            set
            {
                status = value;
                lbStatus.Text = status;
                Invalidate();
            }
        }

        [Category("CTable Setting")]
        public string Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                lbCustomer.Text = customer;
                Invalidate();
            }
        }

        [Category("CTable Setting")]
        public string OrderDate
        {
            get { return orderDate; }
            set
            {
                orderDate = value;
                lbOrderDate.Text = orderDate;
                Invalidate();
            }
        }

        [Category("CTable Setting")]
        public string Chair
        {
            get { return chair; }
            set
            {
                chair = value;
                lbChair.Text = chair;
                Invalidate();
            }
        }

        [Category("CTable Setting")]
        public Image TableImage
        {
            get { return image; }
            set
            {
                image = value;
                cButton1.Image = image;
                Invalidate();
            }
        }
        #endregion

        //Constructor
        public CTable()
        {
            InitializeComponent();
            Font font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lbStatus.Font = font;
            lbOrderDate.Font = font;
            lbName.Font = font;
            lbCustomer.Font = new Font("Arial", 13F, FontStyle.Bold, GraphicsUnit.Point); ;
            lbChair.Font = font;
            lbOrderDate.TextAlign = ContentAlignment.MiddleLeft;
        }

        #region Methods
        private void lbCustomer_Click(object sender, EventArgs e)
        {
            if (_CClick != null)
                _CClick.Invoke(sender, e);
        }
        #endregion

    }
}
