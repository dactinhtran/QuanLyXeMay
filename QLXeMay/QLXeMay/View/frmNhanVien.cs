using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLXeMay.Object;
using QLXeMay.Control;
using DevExpress.XtraEditors;

namespace QLXeMay.View
{
    public partial class frmNhanVien : XtraForm
    {
        public frmNhanVien()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        NhanVienObj nvObj = new NhanVienObj();
        NhanVienControl nvControl = new NhanVienControl();

        public bool flag = true;
        public string maNV = "";
        public string tenNV = "";
        public DateTime ngaySinh = new DateTime(1, 1, 1, 1, 1, 1);
        public string gioiTinh = "";
        public string soCMND = "";
        public int luongcoban = 0;
        public string chucVu = "";
        public string diaChi = "";
        public string sdt = "";

        private void GanDuLieu()
        {
            txtMaNV.EditValue = maNV;
            txtMaNV.Enabled = false;
            txtTenNV.EditValue = tenNV;
            dateNgaySinh.EditValue = Convert.ToDateTime(ngaySinh);
            cboGioiTinh.EditValue = gioiTinh;
            txtSoCMND.EditValue = soCMND;
            txtLuongCoBan.EditValue = luongcoban;
            txtChucVu.EditValue = chucVu;
            txtDiaChi.EditValue = diaChi;
            txtSDT.EditValue = sdt;
        }

        
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            DeleteText();
            cboGioiTinh.Properties.Items.Clear();
            cboGioiTinh.Properties.Items.Add("Nam");
            cboGioiTinh.Properties.Items.Add("Nữ");
            cboGioiTinh.Text = "Nam";
            cboGioiTinh.Properties.AppearanceDropDown.Font = new Font("Time New Roman", 12, FontStyle.Bold);
            if (flag)
            {
                frmMain frm = new frmMain();
                txtMaNV.Text = frm.MaSoTuTang("NV", nvControl.getAllData());
            }
            else GanDuLieu();
        }

        private void DeleteText()
        {
            txtMaNV.Text = txtTenNV.Text = dateNgaySinh.Text = cboGioiTinh.Text = txtSoCMND.Text = txtLuongCoBan.Text = txtChucVu.Text = txtDiaChi.Text = txtSDT.Text = string.Empty;
        }

        bool kiemtradinhdang = true;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != string.Empty) nvObj.Manv = txtMaNV.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
            }

            if (txtTenNV.Text != string.Empty) nvObj.Tennv = txtTenNV.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Tên nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNV.Focus();
            }

            if (dateNgaySinh.Text != string.Empty) nvObj.NgaySinh = dateNgaySinh.EditValue.ToString().Trim().Split(' ')[0];
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Ngày sinh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateNgaySinh.Focus();
            }

            if (cboGioiTinh.Text != string.Empty) nvObj.GioiTinh = cboGioiTinh.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Giới tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboGioiTinh.Focus();
            }

            if (txtSoCMND.Text != string.Empty) nvObj.SoCMND = txtSoCMND.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Số chứng minh nhân dân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoCMND.Focus();
            }

            if (txtLuongCoBan.Text != string.Empty)
            {
                try
                {
                    kiemtradinhdang = true;
                    nvObj.LuongCoBan = Convert.ToInt32(txtLuongCoBan.EditValue.ToString().Trim());
                }
                catch (Exception)
                {
                    kiemtradinhdang = false;
                    XtraMessageBox.Show("Lương cơ bản nhập không đúng định dạng,\nNhập lại với kiểu số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLuongCoBan.Text = string.Empty;
                    txtLuongCoBan.Focus();
                }

            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Lương cơ bản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLuongCoBan.Focus();
            }

            if (txtChucVu.Text != string.Empty) nvObj.ChucVu = txtChucVu.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Chức vụ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChucVu.Focus();
            }

            if (txtDiaChi.Text != string.Empty) nvObj.DiaChi = txtDiaChi.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Địa chỉ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
            }

            if (txtSDT.Text != string.Empty) nvObj.Sdt = txtSDT.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
            }

            try
            {
                if (flag)
                {
                    if (txtMaNV.Text != string.Empty && txtTenNV.Text != string.Empty &&
                        dateNgaySinh.Text != string.Empty && cboGioiTinh.Text != string.Empty &&
                        txtSoCMND.Text != string.Empty && txtLuongCoBan.Text != string.Empty &&
                        txtChucVu.Text != string.Empty && txtDiaChi.Text != string.Empty &&
                        txtSDT.Text != string.Empty && kiemtradinhdang)
                    {
                        if (nvControl.addData(nvObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmNhanVien_Load(sender, e);
                        }
                    }

                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtMaNV.Text != string.Empty && txtTenNV.Text != string.Empty &&
                        dateNgaySinh.Text != string.Empty && cboGioiTinh.Text != string.Empty &&
                        txtSoCMND.Text != string.Empty && txtLuongCoBan.Text != string.Empty &&
                        txtChucVu.Text != string.Empty && txtDiaChi.Text != string.Empty &&
                        txtSDT.Text != string.Empty && kiemtradinhdang)
                    {
                        if (nvControl.updateData(nvObj))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

    }
}
