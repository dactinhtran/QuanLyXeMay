using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLXeMay.Control;
using QLXeMay.Object;
using DevExpress.XtraEditors;

namespace QLXeMay.View
{
    public partial class frmCapNhatHoaDonBanPhuTung : XtraForm
    {
        public frmCapNhatHoaDonBanPhuTung()
        {
            InitializeComponent();
        }

        HoaDonBanPhuTungControl hdbptControl = new HoaDonBanPhuTungControl();
        HoaDonBanPhuTungObj hdbptObj = new HoaDonBanPhuTungObj();
        KhachHangControl khControl = new KhachHangControl();

        private void btnLuu_Click(object sender, EventArgs e)
        {
            hdbptObj.MaHoaDonBanPhuTung = txtMaHD.Text;
            hdbptObj.MaNV = frmDangNhap.MaNhanVien;
           
            if (lueMaKH.Text != "") hdbptObj.MaKH = lueMaKH.Text;
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                hdbptObj.MaKH = string.Empty;
                lueMaKH.Focus();
            }

            if (dateNgayBan.Text != "") hdbptObj.NgayBan = dateNgayBan.EditValue.ToString().Trim().Split(' ')[0];
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Ngày bán phụ tùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateNgayBan.Focus();
            }

            try
            {
                MessageBox.Show(hdbptObj.MaHoaDonBanPhuTung + hdbptObj.MaNV + hdbptObj.NgayBan + hdbptObj.MaKH);
                if (lueMaKH.Text != string.Empty && dateNgayBan.Text != string.Empty)
                    {
                        if (hdbptControl.updateData(hdbptObj))
                        {
                            XtraMessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                    }
            }
            catch (Exception)
            {
                
            }
        }

        private void frmCapNhatHoaDonBanPhuTung_Load(object sender, EventArgs e)
        {
            txtMaHD.Text = frmDanhSachHoaDonBanPhuTung.mahd;
            lueMaKH.EditValue = string.Empty;
            lueMaKH.Properties.DataSource = khControl.getAllDataMaTenCMND();
            lueMaKH.Properties.DisplayMember = "MAKH";
            lueMaKH.Text = frmDanhSachHoaDonBanPhuTung.makh;
            txtTenKH.Text = frmDanhSachHoaDonBanPhuTung.tenkh;
            dateNgayBan.Text = frmDanhSachHoaDonBanPhuTung.ngayban;
        }

        private void lueMaKH_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMaKH.Text != string.Empty) txtTenKH.Text = khControl.getTenKhachHang(lueMaKH.Text.Trim());
        }
    }
}
