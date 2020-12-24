﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCH_UI.DAO;
using QLCH_UI.BUS;

namespace QLCH_UI
{
    public partial class fImportManage : Form
    {
        public fImportManage()
        {
            InitializeComponent();
            loadImportManagement();
            //this.flowLayoutPanel1.Controls.Add(new UC_ItemImport());
            //this.flowLayoutPanel1.Controls.Add(new UC_ItemImport());
            //this.flowLayoutPanel1.Controls.Add(new UC_ItemImport());
        }
        public void loadImportManagement()
        {
            flowLayoutPanel1.Controls.Clear();
            DataTable a = WarehouseDAO.Instance.list_nhap_kho();
            for (int i = 0; i < a.Rows.Count; i++)
            {
                UC_ItemImport item = new UC_ItemImport(this);
                item.ngaynhap = DateTime.Parse(a.Rows[i]["ngay_nhap"].ToString()).ToString("dd - MM - yyyy");
                item.mahd = a.Rows[i]["manhaphang"].ToString();
                item.manv = a.Rows[i]["manguoinhap"].ToString();
                item.tongtien = decimal.Parse(a.Rows[i]["tong_tien"].ToString());
                item.set_UC();
                flowLayoutPanel1.Controls.Add(item);
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle = 0x02000000;
                return handleParam;
            }
        }

    }
}
