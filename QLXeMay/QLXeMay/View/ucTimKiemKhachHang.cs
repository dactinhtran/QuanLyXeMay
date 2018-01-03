using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLXeMay.Control;

namespace QLXeMay.View
{
    public partial class ucTimKiemKhachHang : UserControl
    {
        public ucTimKiemKhachHang()
        {
            InitializeComponent();
        }

        KhachHangControl khControl = new KhachHangControl();
        private void ucTimKiemKhachHang_Load(object sender, EventArgs e)
        {
            cboTimKiem.Properties.AppearanceDropDown.Font = new Font("Time New Roman", 12, FontStyle.Bold);
            cboTimKiem.Properties.Items.Clear();
            cboTimKiem.Properties.Items.Add("Mã khách hàng");
            cboTimKiem.Properties.Items.Add("Tên khách hàng");

            cboTimKiem.Text = "Mã khách hàng";
            cboTimKiem.TabIndex = 1;
            txtTimKiem.TabIndex = 2;
            btnTimKiem.TabIndex = 3;

            DataTable dtDanhSachKhachHang = new DataTable();
            dtDanhSachKhachHang = khControl.getAllData();
            gcTimKiemKhachHang.DataSource = dtDanhSachKhachHang;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dtTimKiemKhachHang = new DataTable();

            if (cboTimKiem.EditValue as string == "Mã khách hàng")
            {
                string timkiem = string.Format("MAKH LIKE N'%{0}%'", txtTimKiem.EditValue);
                dtTimKiemKhachHang = khControl.getAllDataSeach(timkiem);
                gcTimKiemKhachHang.DataSource = dtTimKiemKhachHang;
            }
            else if (cboTimKiem.EditValue as string == "Tên khách hàng")
            {
                string timkiem = string.Format("TENKH LIKE N'%{0}%'", txtTimKiem.EditValue);
                dtTimKiemKhachHang = khControl.getAllDataSeach(timkiem);
                gcTimKiemKhachHang.DataSource = dtTimKiemKhachHang;
            }
           
        }


    }
}
