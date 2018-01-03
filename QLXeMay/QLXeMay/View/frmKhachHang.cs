using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLXeMay.Object;
using QLXeMay.Control;
using DevExpress.XtraEditors;

namespace QLXeMay.View
{
    public partial class frmKhachHang : XtraForm
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        KhachHangObj khObj = new KhachHangObj();
        KhachHangControl khControl = new KhachHangControl();
        public bool flag = true;

        public string maKH = string.Empty;
        public string tenKH = string.Empty;
        public string gioiTinh = string.Empty;
        public string soCMND = string.Empty;
        public string diaChi = string.Empty;
        public string sdt = string.Empty;
        public DateTime ngaySinh = new DateTime(1, 1, 1);


        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            DeleteText();
            if (!flag) GanDuLieu();
            cboGioiTinh.Properties.Items.Clear();
            cboGioiTinh.Properties.Items.Add("Nam");
            cboGioiTinh.Properties.Items.Add("Nữ");
            cboGioiTinh.Text = "Nam";
            cboGioiTinh.Properties.AppearanceDropDown.Font = new Font("Time New Roman", 12, FontStyle.Bold);
            if (flag)
            {
                frmMain frm = new frmMain();
                txtMaKH.Text = frm.MaSoTuTang("KH", khControl.getAllData());
            }
        }

        private void GanDuLieu()
        {
            txtMaKH.EditValue = maKH;
            txtMaKH.Enabled = false;
            txtTenKH.EditValue = tenKH;
            dateNgaySinh.EditValue = ngaySinh;
            cboGioiTinh.EditValue = gioiTinh;
            txtSoCMND.EditValue = soCMND;
            txtDiaChi.EditValue = diaChi;
            txtSDT.EditValue = sdt;
        }

        private void DeleteText()
        {
            txtMaKH.Text = txtTenKH.Text = dateNgaySinh.Text = cboGioiTinh.Text = txtSoCMND.Text = txtDiaChi.Text = txtSDT.Text = string.Empty;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != string.Empty) khObj.MaKH = txtMaKH.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKH.Focus();
            }

            if (txtTenKH.Text != string.Empty) khObj.TenKH = txtTenKH.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Tên khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKH.Focus();
            }

            if (dateNgaySinh.Text != string.Empty) { khObj.NgaySinh = dateNgaySinh.EditValue.ToString().Trim().Split(' ')[0]; }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Ngày sinh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateNgaySinh.Focus();
            }

            if (cboGioiTinh.Text != string.Empty) khObj.GioiTinh = cboGioiTinh.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Giới tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboGioiTinh.Focus();
            }

            if (txtSoCMND.Text != string.Empty) khObj.SoCMND = txtSoCMND.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Số chứng minh nhân dân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoCMND.Focus();
            }

            if (txtDiaChi.Text != string.Empty) khObj.DiaChi = txtDiaChi.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Địa chỉ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
            }

            if (txtSDT.Text != string.Empty) khObj.Sdt = txtSDT.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
            }

            try
            {
                if (flag)
                {
                    if (txtMaKH.Text != string.Empty && txtTenKH.Text != string.Empty &&
                        dateNgaySinh.Text != string.Empty && cboGioiTinh.Text != string.Empty &&
                        txtSoCMND.Text != string.Empty && txtDiaChi.Text != string.Empty)
                    {
                        if (khControl.addData(khObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmKhachHang_Load(sender, e);
                        }
                    }

                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtMaKH.Text != string.Empty && txtTenKH.Text != string.Empty &&
                        dateNgaySinh.Text != string.Empty && cboGioiTinh.Text != string.Empty &&
                        txtSoCMND.Text != string.Empty && txtDiaChi.Text != string.Empty)
                    {
                        if (khControl.updateData(khObj))
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
