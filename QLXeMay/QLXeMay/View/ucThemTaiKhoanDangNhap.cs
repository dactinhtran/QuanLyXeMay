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
using QLXeMay.Object;

namespace QLXeMay.View
{
    public partial class ucThemTaiKhoanDangNhap : UserControl
    {
        public ucThemTaiKhoanDangNhap()
        {
            InitializeComponent();
        }

        NhanVienControl nvControl = new NhanVienControl();
        DangNhapControl dnControl = new DangNhapControl();
        DangNhapObj dnObj = new DangNhapObj();
        frmMain frm = new frmMain();

        private void ucThemTaiKhoanDangNhap_Load(object sender, EventArgs e)
        {
            deleteText();
            enable(false);
            lueMaNV.EditValue = string.Empty;
            lueMaNV.Properties.DataSource = nvControl.getDataMaTen();
            lueMaNV.Properties.DisplayMember = "MANV";
            txtQuyenTC.Enabled = false;
            gcThemDangNhap.DataSource = dnControl.getFullData();
            frmMain.DatLaiTenCotCuaGridView(gvThemDangNhap); 
        }

        void enable(bool k)
        {
            lueMaNV.Enabled = txtTenNV.Enabled = txtChucVu.Enabled = txtTenDangNhap.Enabled = txtMatKhau.Enabled = btnHuy.Enabled = btnLuu.Enabled = k;
            btnThem.Enabled =   btnSua.Enabled =   btnXoa.Enabled = !k;
            if (k)
            {
                btnThem.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btnSua.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btnXoa.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btnLuu.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnHuy.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                btnThem.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnSua.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnXoa.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnLuu.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btnHuy.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
        }

        void deleteText()
        {
            txtChucVu.Text = txtMatKhau.Text = txtQuyenTC.Text = txtTenDangNhap.Text = txtTenNV.Text = lueMaNV.Text = lblMaDN.Text = string.Empty;
        }

        private void lueMaNV_EditValueChanged(object sender, EventArgs e)
        {
            txtTenNV.Text = nvControl.getTenNV(lueMaNV.Text.Trim());
            txtChucVu.Text = nvControl.getChucVuNV(lueMaNV.Text.Trim());
        }

        bool flag = true;
        private void btnThem_Click(object sender, EventArgs e)
        {
            enable(true);
            deleteText();
            flag = true;
            lueMaNV.Properties.DataSource = nvControl.getMaTenChucVuUCThemDangNhap();
            lueMaNV.Properties.DisplayMember = "MANV";
            lblMaDN.Text = frm.MaSoTuTang("ND", dnControl.getFullData());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            enable(true);
            flag = false;
            int HangDangChon = gvThemDangNhap.FocusedRowHandle;
            object value1 = gvThemDangNhap.GetRowCellValue(HangDangChon, "MADN");
            if (value1 != null)
            {
                object value2 = gvThemDangNhap.GetRowCellValue(HangDangChon, "MANV");
                object value3 = gvThemDangNhap.GetRowCellValue(HangDangChon, "TENDN");
                object value4 = gvThemDangNhap.GetRowCellValue(HangDangChon, "MATKHAU");
                object value5 = gvThemDangNhap.GetRowCellValue(HangDangChon, "QUYENTC");

                lblMaDN.Text = value1.ToString();
                lueMaNV.EditValue = value2.ToString();
                lueMaNV.Text = value2.ToString();
                txtTenDangNhap.Text = value3.ToString();
                txtMatKhau.Text = value4.ToString();
                txtQuyenTC.Text = value5.ToString();
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool kiemTra = true;
            dnObj.MaDN = lblMaDN.Text.Trim();

            if (lueMaNV.Text != string.Empty) dnObj.MaNV = lueMaNV.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lueMaNV.Focus();
            }

            if (txtTenDangNhap.Text != string.Empty)
            {
                if (frmMain.KiemTraTen_MatKhau(txtTenDangNhap.Text.Trim())) dnObj.TenDN = txtTenDangNhap.EditValue.ToString().Trim();
                else
                {
                    XtraMessageBox.Show("Tên đăng nhập chỉ nhập kiểu chữ và số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    kiemTra = false;
                    txtTenDangNhap.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dnObj.TenDN = string.Empty;
                txtTenDangNhap.Focus();
            }

            if (txtMatKhau.Text != string.Empty)
            {
                if (frmMain.KiemTraTen_MatKhau(txtMatKhau.Text.Trim())) dnObj.MatKhau = txtMatKhau.EditValue.ToString().Trim();
                else
                {
                    kiemTra = false;
                    XtraMessageBox.Show("Mật khẩu chỉ nhập kiểu chữ và số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dnObj.MatKhau = string.Empty;
                    txtMatKhau.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
            }

            if (txtQuyenTC.Text != string.Empty) dnObj.QuyenTC = txtQuyenTC.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Quyền truy cập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuyenTC.Focus();
            }

            if (flag)
            {
                if (lueMaNV.Text != string.Empty && txtTenDangNhap.Text != string.Empty && txtMatKhau.Text != string.Empty &&
                    txtQuyenTC.Text != string.Empty && kiemTra)
                {
                    if (dnControl.addData(dnObj))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ucThemTaiKhoanDangNhap_Load(sender, e);
                    }
                }
                else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            else
            {
                if (lueMaNV.Text != string.Empty && txtTenDangNhap.Text != string.Empty && txtMatKhau.Text != string.Empty &&
                    txtQuyenTC.Text != string.Empty && kiemTra)
                {
                    if (dnControl.updateData(dnObj))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ucThemTaiKhoanDangNhap_Load(sender, e);
                    }
                }
                else MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void gcThemDangNhap_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvThemDangNhap.FocusedRowHandle;
            object value1 = gvThemDangNhap.GetRowCellValue(HangDangChon, "MADN");
            if (value1 != null)
            {
                object value2 = gvThemDangNhap.GetRowCellValue(HangDangChon, "MANV");
                object value3 = gvThemDangNhap.GetRowCellValue(HangDangChon, "TENDN");
                object value4 = gvThemDangNhap.GetRowCellValue(HangDangChon, "MATKHAU");
                object value5 = gvThemDangNhap.GetRowCellValue(HangDangChon, "QUYENTC");

                lblMaDN.Text = value1.ToString();
                lueMaNV.Text = value2.ToString();
                txtTenDangNhap.Text = value3.ToString();
                txtMatKhau.Text = value4.ToString();
                txtQuyenTC.Text = value5.ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ucThemTaiKhoanDangNhap_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int HangDangChon = gvThemDangNhap.FocusedRowHandle;
                object value = gvThemDangNhap.GetRowCellValue(HangDangChon, "MADN");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (dnControl.deleteData(ma))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ucThemTaiKhoanDangNhap_Load(sender, e);
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa chọn đối tượng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static string quyen;
        private void btnChonQuyen_Click(object sender, EventArgs e)
        {
            quyen = txtQuyenTC.Text.Trim();
            frmChonQuyenTruyCap f = new frmChonQuyenTruyCap();
            f.ShowDialog();
            txtQuyenTC.Text = frmChonQuyenTruyCap.traVe;
        }


    }
}
