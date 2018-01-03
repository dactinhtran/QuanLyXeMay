using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLXeMay.Control;
using QLXeMay.Object;
using DevExpress.XtraEditors;

namespace QLXeMay.View
{
    public partial class ucBaoHanhXeMay : UserControl
    {
        public ucBaoHanhXeMay()
        {
            InitializeComponent();
        }

        //NhanVienControl nvControl = new NhanVienControl();
        KhachHangControl khControl = new KhachHangControl();
        XeControl xControl = new XeControl();
        frmMain frm = new frmMain();
        BaoHanhControl bhControl = new BaoHanhControl();
        BaoHanhObj bhObj = new BaoHanhObj();

        ChiTietBaoHanhControl ctbhControl = new ChiTietBaoHanhControl();
        ChiTietBaoHanhObj ctbhObj = new ChiTietBaoHanhObj();
        NhanVienControl nvControl = new NhanVienControl();

        private void ucBaoHanhXeMay_Load(object sender, EventArgs e)
        {
            enableBaoHanh(false);
            enableSplitPannel(0);
            DeleteTextBaoHanh();
            DeleteTextChiTiet();
            enableChiTiet(false);
            lueMaXe.EditValue = string.Empty;

            splitContainerControl1.FixedPanel = SplitFixedPanel.None;

            gcDanhSachBaoHanh.DataSource = bhControl.getAllDataChoGridControl();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachBaoHanh);
            
            lueMaKhachHang.Properties.DataSource = khControl.getAllDataMaTen();
            lueMaKhachHang.Properties.DisplayMember = "MAKH";

            lueMaXe.Properties.DataSource = xControl.getMaXeCholueMaXeUCBaoHanh();
            lueMaXe.Properties.DisplayMember = "MAXE";

            lueMaBH.Properties.DataSource = bhControl.getAllData();
            lueMaBH.Properties.DisplayMember = "MABH";
        }

        private void enableBaoHanh(bool k)
        {
            layoutControlGroup1.Enabled = btnLuu.Enabled = btnHuy.Enabled = k;
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

        private  void DeleteTextBaoHanh()
        {
            txtMaBaoHanh.Text = txtThoiGian.Text = lueMaKhachHang.Text = lueMaXe.Text = txtTenXe.Text = txtTenKH.Text = string.Empty;
        }

        private void enableSplitPannel(int kt)
        {
            if (kt == 0)
            {
                splitContainerControl1.Panel1.Enabled = true;
                splitContainerControl1.Panel2.Enabled = true;
            }
            else if (kt == 1) splitContainerControl1.Panel1.Enabled = false;
            else if (kt == 2) splitContainerControl1.Panel2.Enabled = false;
        }

        int flag = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            enableSplitPannel(2);
            enableBaoHanh(true);
            DeleteTextBaoHanh();
            txtMaBaoHanh.Text = frm.MaSoTuTang("BH", bhControl.getAllData());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            enableBaoHanh(true);
            enableSplitPannel(2);
            txtMaBaoHanh.Enabled = false;

            int HangDangChon = gvDanhSachBaoHanh.FocusedRowHandle;
            var value1 = gvDanhSachBaoHanh.GetRowCellValue(HangDangChon, "MABH");

            if (value1 != null)
            {
                var value2 = gvDanhSachBaoHanh.GetRowCellValue(HangDangChon, "MAKH");
                var value3 = gvDanhSachBaoHanh.GetRowCellValue(HangDangChon, "THOIGIANBH");
                var value4 = gvDanhSachBaoHanh.GetRowCellValue(HangDangChon, "MAXE");

                txtMaBaoHanh.Text = value1.ToString();
                lueMaKhachHang.Text = value2.ToString();
                txtThoiGian.Text = value3.ToString();
                lueMaXe.Text = value4.ToString();
                
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        bool kt = true;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaBaoHanh.Text != "") bhObj.MaBaoHanh = txtMaBaoHanh.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã bảo hành", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bhObj.MaBaoHanh = string.Empty;
                txtMaBaoHanh.Focus();
            }

            if (lueMaKhachHang.Text != "") bhObj.MaKH = lueMaKhachHang.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bhObj.MaKH = string.Empty;
                lueMaKhachHang.Focus();
            }

            if (txtThoiGian.Text != "")
            {
                try
                {
                    bhObj.ThoiGianBaoHanh = Convert.ToInt32(txtThoiGian.EditValue.ToString().Trim());
                    kt = true;
                }
                catch (Exception)
                {
                    kt = false;
                    XtraMessageBox.Show("Thời gian nhập không đúng định dạng,\nNhập lại với kiểu số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtThoiGian.Text = string.Empty;
                    txtThoiGian.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Thời gian bảo hành", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bhObj.ThoiGianBaoHanh = 0;
                txtThoiGian.Focus();
            }

            if (lueMaXe.Text != "") bhObj.MaXe = lueMaXe.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã xe", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bhObj.MaXe = string.Empty;
                lueMaXe.Focus();
            }

            try
            {
                if(flag == 1)
                {
                    if(txtMaBaoHanh.Text != "" && lueMaKhachHang.Text != "" && txtThoiGian.Text != "" && lueMaXe.Text != "" && kt)
                    {
                        if (bhControl.addData(bhObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucBaoHanhXeMay_Load(sender, e);
                        }
                    }
                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                else if (flag == 2)
                {
                    if (txtMaBaoHanh.Text != "" && lueMaKhachHang.Text != "" && txtThoiGian.Text != "" && lueMaXe.Text != "" && kt)
                    {
                        if (bhControl.updateData(bhObj))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucBaoHanhXeMay_Load(sender, e);
                        }
                    }
                    else MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lueMaKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            txtTenKH.Text = khControl.getTenKhachHang(lueMaKhachHang.Text.Trim());
        }

        private void lueMaXe_EditValueChanged(object sender, EventArgs e)
        {
            txtTenXe.Text = xControl.getTenXe(lueMaXe.Text.Trim());
        }

        private void gcDanhSachBaoHanh_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvDanhSachBaoHanh.FocusedRowHandle;
            var value1 = gvDanhSachBaoHanh.GetRowCellValue(HangDangChon, "MABH");

            if (value1 != null)
            {
                var value2 = gvDanhSachBaoHanh.GetRowCellValue(HangDangChon, "MAKH");
                var value3 = gvDanhSachBaoHanh.GetRowCellValue(HangDangChon, "THOIGIANBH");
                var value4 = gvDanhSachBaoHanh.GetRowCellValue(HangDangChon, "MAXE");
                txtMaBaoHanh.Text = value1.ToString();
                lueMaKhachHang.Text = value2.ToString();
                txtThoiGian.Text = value3.ToString();
                lueMaXe.Text = value4.ToString();
                lueMaBH.Text = value1.ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ucBaoHanhXeMay_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int HangDangChon = gvDanhSachBaoHanh.FocusedRowHandle;
                object value = gvDanhSachBaoHanh.GetRowCellValue(HangDangChon, "MABH");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (bhControl.deleteData(ma))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                gcDanhSachBaoHanh.DataSource = bhControl.getAllDataChoGridControl();
                frmMain.DatLaiTenCotCuaGridView(gvDanhSachBaoHanh);
            }
        }


        // ChiTiet

        private void DeleteTextChiTiet()
        {
            txtMaChiTietBH.Text = lueMaBH.Text = txtCongViec.Text = txtSoKM.Text = string.Empty;
        }

        private void enableChiTiet(bool k)
        {
            layoutControl2.Enabled = btnLuuChiTiet.Enabled = btnHuyChiTiet.Enabled = k;
            btnThemChiTiet.Enabled = btnSuaChiTiet.Enabled = btnXoaChiTiet.Enabled = !k;
            if (k)
            {
                btnThemChiTiet.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btnSuaChiTiet.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btnXoaChiTiet.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btnLuuChiTiet.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnHuyChiTiet.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                btnThemChiTiet.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnSuaChiTiet.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnXoaChiTiet.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnLuuChiTiet.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                btnHuyChiTiet.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            flag = 3;
            enableSplitPannel(1);
            enableChiTiet(true);
            DeleteTextChiTiet();
            txtMaChiTietBH.Text = frm.MaSoTuTang("CTBH", ctbhControl.getAllData());
        }

        private void btnSuaChiTiet_Click(object sender, EventArgs e)
        {
            flag = 4;
            enableChiTiet(true);
            enableSplitPannel(1);
            txtMaChiTietBH.Enabled = false;

            int HangDangChon = gvChiTietBaoHanh.FocusedRowHandle;
            object value1 = gvChiTietBaoHanh.GetRowCellValue(HangDangChon, "MACTBH");

            if (value1 != null)
            {
                object value2 = gvChiTietBaoHanh.GetRowCellValue(HangDangChon, "MABH");
                object value3 = gvChiTietBaoHanh.GetRowCellValue(HangDangChon, "MANV");
                object value4 = gvChiTietBaoHanh.GetRowCellValue(HangDangChon, "CONGVIEC");
                object value5 = gvChiTietBaoHanh.GetRowCellValue(HangDangChon, "SOKM");

                txtMaChiTietBH.Text = value1.ToString();
                lueMaBH.Text = value2.ToString();
                txtCongViec.Text = value4.ToString();
                txtSoKM.Text = value5.ToString();
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucBaoHanhXeMay_Load(sender, e);
            }
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int row_index = gvChiTietBaoHanh.FocusedRowHandle;
                object value = gvChiTietBaoHanh.GetRowCellValue(row_index, "MACTBH");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (ctbhControl.deleteData(ma))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lueMaBH_EditValueChanged(sender, e);
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


        bool kiemTra = true;
        private void btnLuuChiTiet_Click(object sender, EventArgs e)
        {
            ctbhObj.MaNV = frmDangNhap.MaNhanVien;
            if (txtMaChiTietBH.Text != "") ctbhObj.MaChiTietBaoHanh = txtMaChiTietBH.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã chi tiết bảo hành", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctbhObj.MaChiTietBaoHanh = string.Empty;
                txtMaChiTietBH.Focus();
            }

            if (lueMaBH.Text != "") ctbhObj.MaBaoHanh = lueMaBH.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã bảo hành", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctbhObj.MaBaoHanh = string.Empty;
                lueMaBH.Focus();
            } 

            if (txtCongViec.Text != "") ctbhObj.CongViec = txtCongViec.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Công việc bảo hành", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctbhObj.CongViec = string.Empty;
                txtCongViec.Focus();
            }

            if (txtSoKM.Text != "")
            {
                try
                {
                    kiemTra = true;
                    ctbhObj.SoKM = Convert.ToInt32(txtSoKM.Text.Trim());
                }
                catch (Exception)
                {
                    kiemTra = false;
                    XtraMessageBox.Show("Đơn giá nhập không đúng định dạng,\nNhập lại với kiểu số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoKM.Text = string.Empty;
                    txtSoKM.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Số KM hiện tại của xe", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctbhObj.SoKM = 0;
                txtSoKM.Focus();
            }

            try
            {
                if (flag == 3)
                {
                    if (txtMaChiTietBH.Text != string.Empty && lueMaBH.Text != string.Empty && txtCongViec.Text != string.Empty &&
                        txtSoKM.Text != string.Empty && kiemTra && Convert.ToInt32(txtSoKM.Text) != 0)
                    {
                        if (ctbhControl.addData(ctbhObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lueMaBH_EditValueChanged(sender, e);
                            enableChiTiet(false);
                            enableSplitPannel(0);
                            DeleteTextChiTiet();
                        }
                    }
                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                else if (flag == 4)
                {
                    if (txtMaChiTietBH.Text != string.Empty && lueMaBH.Text != string.Empty && txtCongViec.Text != string.Empty &&
                        txtSoKM.Text != string.Empty && kiemTra && Convert.ToInt32(txtSoKM.Text) != 0)
                    {
                        if (ctbhControl.updateData(ctbhObj))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lueMaBH_EditValueChanged(sender, e);
                            enableChiTiet(false);
                            enableSplitPannel(0);
                        }
                    }
                    else MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lueMaBH_EditValueChanged(object sender, EventArgs e)
        {
            gcChiTietBaoHanh.DataSource = ctbhControl.getDataMalueMaBHThayDoi(lueMaBH.Text.Trim());
            frmMain.DatLaiTenCotCuaGridView(gvChiTietBaoHanh);
        }

        private void btnHuyChiTiet_Click(object sender, EventArgs e)
        {
            ucBaoHanhXeMay_Load(sender, e);
        }


    }
}
