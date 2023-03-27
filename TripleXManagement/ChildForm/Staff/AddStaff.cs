﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripleXManagement.ChildForm.Staff
{
    public partial class AddStaff : Form
    {
        public AddStaff()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            StaticClass.SharedClass.FillCBB("select * from Regency", cbRegency,"Name");
            StaticClass.SharedClass.FillCBB("select * from Account", cbAccount,"Username");
            
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            GetData();
            StaticClass.SqlClass.Connect();
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
            MemoryStream ms = new MemoryStream();
            pbPic.BackgroundImage.Save(ms, ImageFormat.Jpeg);
            byte[] array = ms.GetBuffer();

            string sql = @"exec addStaff '" + txtName.Texts + "', '" + txtCCCD.Texts + "', '" + txtPhone.Texts + "', '"
                + array + "', N'%" + cbRegency.Text + "%', '" + cbAccount.Text + "'";
            StaticClass.SqlClass.RunSql(sql);

            clear();
        }
        private void clear()
        {
            txtName.Texts = "";
            txtCCCD.Texts = "";
            txtPhone.Texts = "";
            pbPic.BackgroundImage = null;
        }

        private void btnDenied_Click(object sender, EventArgs e)
        {
            if(cbAccount.DataSource != null)
                cbAccount.DataSource = null;
            else
                StaticClass.SharedClass.FillCBB("select * from Account", cbAccount, "Username");
        }

        private void btnDenied_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnDenied, Properties.Resources.denied_20px1, true);
        }

        private void btnDenied_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnDenied, Properties.Resources.denied_20px, false);
        }

        private void btnBrowse_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnBrowse, Properties.Resources.denied_20px, true);
        }

        private void btnBrowse_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnBrowse, Properties.Resources.denied_20px, false);
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnSave, Properties.Resources.denied_20px, true);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            StaticClass.SharedClass.HoverBtnState(btnSave, Properties.Resources.denied_20px, false);
        }
    }
}