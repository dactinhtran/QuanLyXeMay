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
    public partial class frmThongTinPhuTung : XtraForm
    {
        public frmThongTinPhuTung()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        ThongTinPhuTungControl ttPTControl = new ThongTinPhuTungControl();
        frmMain frm = new frmMain();
        ThongTinPhuTungObj TTPTObj = new ThongTinPhuTungObj();

        private void frmThongTinPhuTung_Load(object sender, EventArgs e)
        {
            enable(false);
            deleteText();

            gcThongTinPhuTung.DataSource = ttPTControl.getAllData();
            frmMain.DatLaiTenCotCuaGridView(gvThongTinPhuTung);

        }

        private void enable(bool k)
        {
            layoutControl1.Enabled = btnLuu.Enabled = btnHuy.Enabled = k;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = !k;
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

        private void deleteText()
        {
            txtDonViTinh.Text = txtLoaiPhuTung.Text = txtMaTTPhuTung.Text = txtTenPhuTung.Text = string.Empty;
        }

        bool flag = true;
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = true;
            deleteText();
            enable(true);
            txtMaTTPhuTung.Text = frm.MaSoTuTang("TTPT", ttPTControl.getAllData());

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = false;
            enable(true);
            txtMaTTPhuTung.Enabled = false;
            int HangDangChon = gvThongTinPhuTung.FocusedRowHandle;
            object value1 = gvThongTinPhuTung.GetRowCellValue(HangDangChon, "MATTPT");
            if (value1 != null)
            {
                object value2 = gvThongTinPhuTung.GetRowCellValue(HangDangChon, "LOAIPT");
                object value3 = gvThongTinPhuTung.GetRowCellValue(HangDangChon, "TENPT");
                object value4 = gvThongTinPhuTung.GetRowCellValue(HangDangChon, "DONVITINH");
                txtMaTTPhuTung.Text = value1.ToString();
                txtLoaiPhuTung.Text = value2.ToString();
                txtTenPhuTung.Text = value3.ToString();
                txtDonViTinh.Text = value4.ToString();
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmThongTinPhuTung_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int HangDangChon = gvThongTinPhuTung.FocusedRowHandle;
                object value = gvThongTinPhuTung.GetRowCellValue(HangDangChon, "MATTPT");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (ttPTControl.deleteData(ma)) XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else XtraMessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa chọn đối tượng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                frmThongTinPhuTung_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaTTPhuTung.Text != "") TTPTObj.MaTTPT = txtMaTTPhuTung.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã thông tin phụ tùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TTPTObj.MaTTPT = string.Empty;
                txtMaTTPhuTung.Focus();
            }

            if (txtLoaiPhuTung.Text != "") TTPTObj.LoaiPT = txtLoaiPhuTung.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Loại phụ tùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TTPTObj.LoaiPT = string.Empty;
                txtLoaiPhuTung.Focus();
            }

            if (txtTenPhuTung.Text != "") TTPTObj.TenPT = txtTenPhuTung.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Tên phụ tùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TTPTObj.TenPT = string.Empty;
                txtTenPhuTung.Focus();
            }


            if (txtDonViTinh.Text != "") TTPTObj.DonViTinh = txtDonViTinh.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Đơn vị tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TTPTObj.DonViTinh = string.Empty;
                txtDonViTinh.Focus();
            }

            try
            {
                if (flag)
                {
                    if (txtMaTTPhuTung.Text != string.Empty && txtTenPhuTung.Text != string.Empty &&
                       txtDonViTinh.Text != string.Empty && txtLoaiPhuTung.Text != string.Empty)
                    {
                        if (ttPTControl.addData(TTPTObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmThongTinPhuTung_Load(sender, e);
                        }
                    }
                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtMaTTPhuTung.Text != string.Empty && txtTenPhuTung.Text != string.Empty &&
                       txtDonViTinh.Text != string.Empty && txtLoaiPhuTung.Text != string.Empty)
                    {
                        if (ttPTControl.updateData(TTPTObj))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmThongTinPhuTung_Load(sender, e);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmThongTinPhuTung_Load(sender, e);
        }

        private void gcThongTinPhuTung_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvThongTinPhuTung.FocusedRowHandle;
            object value1 = gvThongTinPhuTung.GetRowCellValue(HangDangChon, "MATTPT");
            if (value1 != null)
            {
                object value2 = gvThongTinPhuTung.GetRowCellValue(HangDangChon, "LOAIPT");
                object value3 = gvThongTinPhuTung.GetRowCellValue(HangDangChon, "TENPT");
                object value4 = gvThongTinPhuTung.GetRowCellValue(HangDangChon, "DONVITINH");
                txtMaTTPhuTung.Text = value1.ToString();
                txtLoaiPhuTung.Text = value2.ToString();
                txtTenPhuTung.Text = value3.ToString();
                txtDonViTinh.Text = value4.ToString();
            }
        }
    }
}
