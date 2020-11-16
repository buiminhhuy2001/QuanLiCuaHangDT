﻿using QLCH_UI.BUS;
using QLCH_UI.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCH_UI
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
            load_product();
        }


        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        public void load_product()
        {
            dgvProducts.DataSource = ProductDAO.Instance.Productlist();
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct f = new AddProduct();
            f.ShowDialog();
            load_product();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count>0)
            {
                DataGridViewRow row = dgvProducts.SelectedRows[0];
                String ID = row.Cells[0].Value.ToString();
                string masp = "";
                string ten_sp = "";
                string loai_sp = "";
                double gia_nhap = 0;
                double gia_ban = 0;
                string img = "";
                DataTable a = ProductDAO.Instance.viewinfo(ID);
                masp = a.Rows[0]["masp"].ToString();
                ten_sp = a.Rows[0]["ten_sp"].ToString();
                loai_sp = a.Rows[0]["loai_sp"].ToString();
                gia_nhap = (double)a.Rows[0]["gia_nhap"];
                gia_ban = (double)a.Rows[0]["gia_ban"];
                img = a.Rows[0]["img"].ToString();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvProducts.SelectedRows[0];
                string ID = row.Cells[0].Value.ToString();
                if (ProductBUS.Instance.delete_product(ID))
                {
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
                load_product();
            }
        }

        private void dgvProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {  
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvProducts.SelectedRows[0];
                string masp = row.Cells[0].Value.ToString();
                DataTable a = ProductDAO.Instance.viewinfo(masp);
                string ma_sp = a.Rows[0]["masp"].ToString();
                string ten_sp = a.Rows[0]["ten_sp"].ToString();
                string loai_sp = a.Rows[0]["loai_sp"].ToString();
                string gia = a.Rows[0]["gia_ban"].ToString();
                Image anh = ByteToImg(a.Rows[0]["img"].ToString());
                InfoProduct f = new InfoProduct(ma_sp, ten_sp, loai_sp, gia, anh);
                f.ShowDialog();

            }
        }
    }
}
