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
    public partial class frmThongTinXe : XtraForm
    {
        public frmThongTinXe()
        {
            InitializeComponent();
        }

        ThongTinXeControl TTXeControl = new ThongTinXeControl();
        ThongTinXeObj TTXeObj = new ThongTinXeObj();
        frmMain frm = new frmMain();

        private void frmThongTinXe_Load(object sender, EventArgs e)
        {
            deleteText();
            enable(false);

            gcDanhSachThongTinXe.DataSource = TTXeControl.getAllData();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongTinXe);
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
            txtMaTTXeMay.Text = txtHangXe.Text = txtMauXe.Text = txtTenXe.Text = txtDungTich.Text = string.Empty;
        }

        bool flag = true;
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = true;
            deleteText();
            enable(true);
            txtMaTTXeMay.Text = frm.MaSoTuTang("TTX", TTXeControl.getAllData());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = false;
            enable(true);
            txtMaTTXeMay.Enabled = false;
            int HangDangChon = gvDanhSachThongTinXe.FocusedRowHandle;
            object value1 = gvDanhSachThongTinXe.GetRowCellValue(HangDangChon, "MATTXE");
            if (value1 != null)
            {
                object value2 = gvDanhSachThongTinXe.GetRowCellValue(HangDangChon, "HANGXE");
                object value3 = gvDanhSachThongTinXe.GetRowCellValue(HangDangChon, "TENXE");
                object value4 = gvDanhSachThongTinXe.GetRowCellValue(HangDangChon, "MAUXE");
                object value5 = gvDanhSachThongTinXe.GetRowCellValue(HangDangChon, "DUNGTICH");
                txtMaTTXeMay.Text = value1.ToString();
                txtHangXe.Text = value2.ToString();
                txtTenXe.Text = value3.ToString();
                txtMauXe.Text = value4.ToString();
                txtDungTich.Text = value5.ToString();
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmThongTinXe_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int HangDangChon = gvDanhSachThongTinXe.FocusedRowHandle;
                object value = gvDanhSachThongTinXe.GetRowCellValue(HangDangChon, "MATTXE");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (TTXeControl.deleteData(ma)) XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else XtraMessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa chọn đối tượng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                frmThongTinXe_Load(sender, e);
            }
        }

        bool kiemTra = true;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaTTXeMay.Text != "") TTXeObj.MaThongTinXe = txtMaTTXeMay.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã thông tin xe máy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TTXeObj.MaThongTinXe = string.Empty;
                txtMaTTXeMay.Focus();
            }

            if (txtHangXe.Text != "") TTXeObj.HangXe = txtHangXe.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Hãng xe", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TTXeObj.HangXe = string.Empty;
                txtHangXe.Focus();
            }

            if (txtTenXe.Text != "") TTXeObj.TenXe = txtTenXe.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Tên xe máy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TTXeObj.TenXe = string.Empty;
                txtTenXe.Focus();
            }


            if (txtMauXe.Text != "") TTXeObj.MauXe = txtMauXe.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Đơn vị tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TTXeObj.MauXe = string.Empty;
                txtMauXe.Focus();
            }


             if (txtDungTich.Text != "") 
             {
                try 
	            {	        
		                TTXeObj.DungTich = Convert.ToInt32(txtDungTich.Text.Trim());
                    kiemTra = true;
	            }
	            catch (Exception ex)
	            {
                    MessageBox.Show(ex.Message);
		            kiemTra = false;
                    txtDungTich.Focus();
	            }
             }

            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Dung tích", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TTXeObj.DungTich = 0;
                txtDungTich.Focus();
            }

            try
            {
                if (flag)
                {
                    if (txtMaTTXeMay.Text != string.Empty && txtMauXe.Text != string.Empty &&
                       txtHangXe.Text != string.Empty && txtTenXe.Text != string.Empty && 
                       txtDungTich.Text != string.Empty && kiemTra)
                    {
                        if (TTXeControl.addData(TTXeObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmThongTinXe_Load(sender, e);
                        }
                    }
                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtMaTTXeMay.Text != string.Empty && txtMauXe.Text != string.Empty &&
                       txtHangXe.Text != string.Empty && txtTenXe.Text != string.Empty && 
                       txtDungTich.Text != string.Empty && kiemTra)
                    {
                        if (TTXeControl.updateData(TTXeObj))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmThongTinXe_Load(sender, e);
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
        frmThongTinXe_Load(sender, e);
        }

        private void gcDanhSachThongTinXe_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvDanhSachThongTinXe.FocusedRowHandle;
            object value1 = gvDanhSachThongTinXe.GetRowCellValue(HangDangChon, "MATTXE");
            if (value1 != null)
            {
                object value2 = gvDanhSachThongTinXe.GetRowCellValue(HangDangChon, "HANGXE");
                object value3 = gvDanhSachThongTinXe.GetRowCellValue(HangDangChon, "TENXE");
                object value4 = gvDanhSachThongTinXe.GetRowCellValue(HangDangChon, "MAUXE");
                object value5 = gvDanhSachThongTinXe.GetRowCellValue(HangDangChon, "DUNGTICH");
                txtMaTTXeMay.Text = value1.ToString();
                txtHangXe.Text = value2.ToString();
                txtTenXe.Text = value3.ToString();
                txtMauXe.Text = value4.ToString();
                txtDungTich.Text = value5.ToString();
            }

        }
    }
}
