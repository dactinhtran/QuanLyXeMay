using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLXeMay.Control;
using QLXeMay.Object;

namespace QLXeMay.View
{
    public partial class frmThayDoiThongTinDangNhap : XtraForm
    {
        public frmThayDoiThongTinDangNhap()
        {
            InitializeComponent();
        }

        NhanVienControl nvControl = new NhanVienControl();
        DangNhapControl dnControl = new DangNhapControl();
        DangNhapObj dnObj = new DangNhapObj();

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmThayDoiThongTinDangNhap_Load(sender, e);
            this.Hide();
        }

        private void frmThayDoiThongTinDangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhauMoi.Text = txtNhapLaiMK.Text = string.Empty;
            lblMaNV.Text = frmDangNhap.MaNhanVien;
            lblTenNV.Text = nvControl.getTenNV(frmDangNhap.MaNhanVien);
            txtMaDN.Text = frmDangNhap.MaDangNhap;
            txtTenDN.Text = frmDangNhap.TenDangNhap;
            txtQuyenTC.Text = frmDangNhap.QuyenTruyCap;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            dnObj.MaDN = frmDangNhap.MaDangNhap;
            dnObj.TenDN = frmDangNhap.TenDangNhap;
            dnObj.MaNV = frmDangNhap.MaNhanVien;
            dnObj.QuyenTC = frmDangNhap.QuyenTruyCap;
            if (txtMatKhauMoi.Text != "" && txtNhapLaiMK.Text != "")
            {
                if (String.Compare(txtNhapLaiMK.Text.Trim(), txtMatKhauMoi.Text.Trim()) == 0)
                {
                    if (frmMain.KiemTraTen_MatKhau(txtMatKhauMoi.Text.Trim()))
                    {
                        dnObj.MatKhau = txtMatKhauMoi.Text.Trim();
                        if (dnControl.updateData(dnObj))
                        {
                            MessageBox.Show("Thay đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmThayDoiThongTinDangNhap_Load(sender, e);
                        }
                    }
                    else XtraMessageBox.Show("Mật khẩu chỉ được nhập chữ cái và số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else XtraMessageBox.Show("Mật khẩu mới nhập không trùng khớp.\nVui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else XtraMessageBox.Show("Bạn chưa nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
