using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripleXManagement.ChildForm.Bill
{
    public partial class CFoodImage : UserControl
    {
        #region Fields
        private string id = "";
        private string name = "Food Name";
        private string price = "Food Price";
        private Image image;
        #endregion

        #region Events
        public event EventHandler _CClick;
        #endregion

        #region Properties
        [Category("CFoodImage Setting")]
        public string FoodID
        {
            get { return id; }
            set
            {
                id = value;
                pictureBox1.Tag = id;
                Invalidate();
            }
        }

        [Category("CFoodImage Setting")]
        public string FoodName
        {
            get { return name; }
            set
            {
                name = value;
                label2.Text = name;
                Invalidate();
            }
        }

        [Category("CFoodImage Setting")]
        public string FoodPrice
        {
            get { return price; }
            set
            {
                price = value;
                label1.Text = price;
                Invalidate();
            }
        }

        [Category("CFoodImage Setting")]
        public Image FoodImage
        {
            get { return image; }
            set
            {
                image = value;
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox1.BackgroundImage = image;
                Invalidate();
            }
        }
        #endregion

        //Constructor
        public CFoodImage()
        {
            InitializeComponent();
            label1.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
        }

        #region Methods
        private void HoverStatus()
        {
            if(label2.Visible != true)
            {
                label2.Visible = true;
                label2.Cursor = Cursors.Hand;
            }
            else
                label2.Visible = false;
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            HoverStatus();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            HoverStatus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_CClick != null)
                _CClick.Invoke(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (_CClick != null)
                _CClick.Invoke(sender, e);
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            if (label2.Text.Length > 17)
                label2.Text = name.Substring(0, 15) + "...";
        }
        #endregion

    }
}
