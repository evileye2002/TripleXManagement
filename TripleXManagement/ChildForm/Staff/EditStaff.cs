using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace TripleXManagement.ChildForm.Staff
{
    public partial class EditStaff : Form
    {
        public static string ID = "";
        public EditStaff()
        {
            InitializeComponent();
        }

        private void EditStaff_Load(object sender, EventArgs e)
        {
            GetData();
            StaticClass.SqlClass.Connect();
        }
        private void GetData()
        {
            ID = StaffManagement.ID;
            StaticClass.SharedClass.FillCBB("select * from Regency", cbRegency, "Name");
            StaticClass.SharedClass.FillCBB("select * from Account", cbAccount, "Username");
            string sql = "exec getStaffbyID " + ID;
            SqlDataReader reader = StaticClass.SqlClass.Reader(sql);
            while (reader.Read())
            {
               /* long len = reader.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[Convert.ToInt32(len) + 1];
                reader.GetBytes(0, 0, array, 0, Convert.ToInt32(len));
                MemoryStream ms = new(array);
                Bitmap bitmap = new(ms);
                pbPic.BackgroundImage = bitmap;*/


                txtName.Texts = reader.GetValue(1).ToString();
                txtCCCD.Texts = reader.GetValue(2).ToString();
                txtPhone.Texts = reader.GetValue(3).ToString();
                cbRegency.Text = reader.GetValue(4).ToString();
                cbAccount.Text = reader.GetValue(5).ToString();
            }
            reader.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = @"exec editStaffbyID '" + ID + "', '" + txtName.Texts + "', '" + txtCCCD.Texts + "', '" + txtPhone.Texts
                + "', N'%" + cbRegency.Text + "%', '" + cbAccount.Text + "'";
            StaticClass.SqlClass.RunSql(sql);
        }
        private void btnDenied_Click(object sender, EventArgs e)
        {
            if (cbAccount.DataSource != null)
                cbAccount.DataSource = null;
            else
                StaticClass.SharedClass.FillCBB("select * from Account", cbAccount, "Username");
        }
    }
}
