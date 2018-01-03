using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLXeMay.Control;

namespace QLXeMay.View
{
    public partial class ucTimKiemNhanVien : UserControl
    {
        public ucTimKiemNhanVien()
        {
            InitializeComponent();
        }

        NhanVienControl nvControl = new NhanVienControl();

        private void ucTimKiemNhanVien_Load(object sender, EventArgs e)
        {
            cboTimKiem.Properties.AppearanceDropDown.Font = new Font("Time New Roman", 12, FontStyle.Bold);
            cboTimKiem.Properties.Items.Clear();
            cboTimKiem.Properties.Items.Add("Mã nhân viên");
            cboTimKiem.Properties.Items.Add("Tên nhân viên");
            cboTimKiem.Properties.Items.Add("Giới tính");
            cboTimKiem.Properties.Items.Add("Chức vụ");
            cboTimKiem.Text = "Mã nhân viên";

            cboTimKiem.TabIndex = 1;
            txtTimKiem.TabIndex = 2;
            btnTimKiem.TabIndex = 3;

            DataTable dtDanhSachNhanVien = new DataTable();
            dtDanhSachNhanVien = nvControl.getAllData();
            gcTimKiemNhanVien.DataSource = dtDanhSachNhanVien;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            DataTable dtTimKiemNhanVien = new DataTable();
            if (cboTimKiem.EditValue as string == "Mã nhân viên")
            {
                string timkiem = string.Format("(MANV LIKE '%{0}%')", txtTimKiem.EditValue);
                dtTimKiemNhanVien = nvControl.getDataSearch(timkiem);
                gcTimKiemNhanVien.DataSource = dtTimKiemNhanVien;
            }
            else if (cboTimKiem.EditValue as string == "Tên nhân viên")
            {
                string timkiem = string.Format("(TENNV LIKE N'%{0}%')", txtTimKiem.EditValue);
                dtTimKiemNhanVien = nvControl.getDataSearch(timkiem);
                gcTimKiemNhanVien.DataSource = dtTimKiemNhanVien;
            }
            else if (cboTimKiem.EditValue as string == "Giới tính")
            {
                string timkiem = string.Format("(GIOITINH LIKE N'%{0}%')", txtTimKiem.EditValue);
                dtTimKiemNhanVien = nvControl.getDataSearch(timkiem);
                gcTimKiemNhanVien.DataSource = dtTimKiemNhanVien;
            }
            else if (cboTimKiem.EditValue as string == "Chức vụ")
            {
                MessageBox.Show(txtTimKiem.EditValue as string);
                string timkiem = string.Format("(CHUCVU LIKE N'%{0}%')", txtTimKiem.EditValue);
                dtTimKiemNhanVien = nvControl.getDataSearch(timkiem);
                gcTimKiemNhanVien.DataSource = dtTimKiemNhanVien;
            }
        }
    }
}
