﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCH_UI
{
    public partial class MainSaleForm : Form
    {
        public MainSaleForm()
        {
            InitializeComponent();
        }

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            childForm.FormBorderStyle = FormBorderStyle.None;
            panelChildForm.Controls.Add(childForm);
            // panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            openChildForm(new fReviewSale());
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            SellForm f = new SellForm();
            f.ShowDialog();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new ViewProduct());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new fViewCustomer());
        }
    }
}
