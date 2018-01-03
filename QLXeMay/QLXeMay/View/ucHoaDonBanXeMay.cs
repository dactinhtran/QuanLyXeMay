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
using DevExpress.XtraReports.UI;

namespace QLXeMay.View
{
    public partial class ucHoaDonBanXeMay : UserControl
    {
        public ucHoaDonBanXeMay()
        {
            InitializeComponent();
        }

        HoaDonBanXeControl hdBanXeControl = new HoaDonBanXeControl();
        HoaDonBanXeObj hdBanXeObj = new HoaDonBanXeObj();
        KhachHangControl khControl = new KhachHangControl();
        NhanVienControl nvCOntrol = new NhanVienControl();
        XeControl xControl = new XeControl();
        frmMain frm = new frmMain();

        private void ucHoaDonBanXeMay_Load(object sender, EventArgs e)
        {
            txtThueVAT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            enable(false);
            deleteText();

            lueMaKhachHang.EditValue = string.Empty;
            lueMaXe.EditValue = string.Empty;

            lueMaKhachHang.Properties.DataSource = khControl.getAllDataMaTenCMND();
            lueMaKhachHang.Properties.DisplayMember = "MAKH";

            lueMaXe.Properties.DataSource = xControl.getAllDataMaTenMau();
            lueMaXe.Properties.DisplayMember = "MAXE";

            gcDSXe.DataSource = xControl.getDataXeTrongCuaHangUCHoaDon();
            frmMain.DatLaiTenCotCuaGridView(gvDSXe);
            gcDSKH.DataSource = khControl.getAllDataMaTenCMND();
            frmMain.DatLaiTenCotCuaGridView(gvDSKH);

            gcDanhSachHoaDonBanXe.DataSource = hdBanXeControl.getDataHomNay(frmDangNhap.MaNhanVien.Trim());
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachHoaDonBanXe);
        }

        private void enable(bool k)
        {
            lueMaKhachHang.Enabled = txtTenKhachHang.Enabled = lueMaXe.Enabled = txtTenXe.Enabled = txtMauXe.Enabled = layoutControl1.Enabled = btnHuy.Enabled = btnLuu.Enabled = k;
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
            lueMaKhachHang.Text = txtTenKhachHang.Text = lueMaXe.Text = txtTenXe.Text = txtMauXe.Text = txtMaHoaDon.Text = txtDonGia.Text = txtSoLuong.Text = txtThueVAT.Text = txtDonViTinh.Text = dateNgayBan.Text = string.Empty;
        }

        private void gcDSKH_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvDSKH.FocusedRowHandle;
            object makh = gvDSKH.GetRowCellValue(HangDangChon, "MAKH");
            if (makh != null) lueMaKhachHang.Text = (makh as string).Trim();
        }

        private void lueMaKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMaKhachHang.Text != string.Empty) txtTenKhachHang.Text = khControl.getTenKhachHang(lueMaKhachHang.Text.Trim());
        }

        private void gcDSXe_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvDSXe.FocusedRowHandle;
            object maxe = gvDSXe.GetRowCellValue(HangDangChon, "MAXE");

            if (maxe != null) lueMaXe.Text = (maxe as string).Trim();
            txtThueVAT.Text = "";
        }

        private void lueMaXe_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMaXe.Text != string.Empty)
            {
                txtTenXe.Text = xControl.getTenXe(lueMaXe.Text.Trim());
                txtMauXe.Text = xControl.getMauXe(lueMaXe.Text.Trim());
                txtDonGia.Text = xControl.getDonGiaBanXe(lueMaXe.Text.Trim());
                txtSoLuong.Text = "1";
            }
        }

        private void txtDonGia_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != string.Empty && txtDonGia.Text != string.Empty && txtThueVAT.Text != string.Empty)
            {
                string s = txtDonGia.Text.Trim();
                if (char.IsDigit(s[s.Length - 1]))
                {
                    int soluong = 0, dongia = 0; double thue = 0;
                    try
                    {
                        soluong = Convert.ToInt32(txtSoLuong.Text.Trim());
                        dongia = Convert.ToInt32(txtDonGia.Text.Trim());
                        thue = Convert.ToDouble(txtThueVAT.Text.Trim());
                        lblThanhTien.Text = "Thành tiền: " + (soluong * dongia + soluong * dongia * thue / 100);
                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("Nhập không đúng định dạng.\nĐề nghị nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else XtraMessageBox.Show("Nhập không đúng định dạng.\nĐề nghị nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); txtDonGia.Focus();
            }
        }

        private void txtSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            //if (txtSoLuong.Text != "1") XtraMessageBox.Show("Nhập sai số lượng.\nĐề nghị nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtThueVAT_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != string.Empty && txtDonGia.Text != string.Empty && txtThueVAT.Text != string.Empty)
            {
                string s = txtThueVAT.Text.Trim();
                if ((char.IsDigit(s[s.Length - 1]) || (s[s.Length - 1] == '.' && s.Count(x => x == '.') == 1)))
                {
                    bool kt = true;
                    int soluong = 0, dongia = 0; double thue = 0;
                    try
                    {
                        kt = true;
                        soluong = Convert.ToInt32(txtSoLuong.Text.Trim());
                        dongia = Convert.ToInt32(txtDonGia.Text.Trim());
                        thue = Convert.ToDouble(txtThueVAT.Text.Trim());
                    }
                    catch (Exception)
                    {
                        kt = false;
                    }

                    if (kt) lblThanhTien.Text = "Thành tiền: " + (soluong * dongia + soluong * dongia * thue / 100);
                    else XtraMessageBox.Show("Nhập không đúng định dạng.\nĐề nghị nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    XtraMessageBox.Show("Nhập không đúng định dạng.\nĐề nghị nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); txtThueVAT.Focus();

                }
            }
        }

        int flag = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            enable(true);
            txtSoLuong.Enabled = false;
            deleteText();
            flag = 1;
            lblThanhTien.Text = string.Empty;
            txtMaHoaDon.Text = frm.MaSoTuTang("HDBX", hdBanXeControl.getAllDataHD());
            dateNgayBan.Text = DateTime.Today.ToString().Split(' ')[0];
            txtDonViTinh.Text = "Chiếc";
            txtSoLuong.Text = "1";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int HangDangChon = gvDanhSachHoaDonBanXe.FocusedRowHandle;
                object value = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "MAHDBAN");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (hdBanXeControl.deleteData(ma))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ucHoaDonBanXeMay_Load(sender, e);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            enable(true);
            txtSoLuong.Enabled = false;
            flag = 2;
            int HangDangChon = gvDanhSachHoaDonBanXe.FocusedRowHandle;
            object value1 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "MAHDBAN");
            if (value1 != null)
            {
                object value2 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "MAKH");
                object value4 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "MAXE");
                object value5 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "NGAYBAN");
                object value6 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "SOLUONG");
                object value7 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "THUEVAT");
                object value8 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "DONVITINH");

                txtMaHoaDon.Text = value1 as string;
                lueMaKhachHang.Text = value2 as string;
                lueMaXe.Text = value4 as string;
                dateNgayBan.Text = value5.ToString().Split(' ')[0];
                txtSoLuong.Text = value6.ToString();
                txtThueVAT.Text = value7.ToString();
                txtDonViTinh.Text = value8 as string;
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucHoaDonBanXeMay_Load(sender, e);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ucHoaDonBanXeMay_Load(sender, e);
        }


        bool kiemTra = true;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            hdBanXeObj.MaNV = frmDangNhap.MaNhanVien;
            hdBanXeObj.MaHDBanXe = txtMaHoaDon.EditValue.ToString().Trim();

            if (lueMaKhachHang.Text != string.Empty) hdBanXeObj.MaKH = lueMaKhachHang.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hdBanXeObj.MaKH = string.Empty;
                lueMaKhachHang.Focus();
            }


            if (lueMaXe.Text != "") hdBanXeObj.MaXe = lueMaXe.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã xe", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hdBanXeObj.MaXe = string.Empty;
                lueMaXe.Focus();
            }

            if (dateNgayBan.Text != "") hdBanXeObj.NgayBan = dateNgayBan.EditValue.ToString().Trim().Split(' ')[0];
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Ngày bán xe máy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateNgayBan.Focus();
            }

            if (txtSoLuong.Text != string.Empty)
            {
                try
                {
                    kiemTra = true;
                    hdBanXeObj.SoLuong = Convert.ToInt32(txtSoLuong.EditValue.ToString().Trim());
                }
                catch (Exception)
                {
                    kiemTra = false;
                    XtraMessageBox.Show("Số lượng nhập không đúng định dạng,\nNhập lại với kiểu số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.Text = string.Empty;
                    txtSoLuong.Focus();
                }

            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Số lượng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
            }

            if (txtThueVAT.Text != string.Empty)
            {
                try
                {
                    kiemTra = true;
                    hdBanXeObj.ThueVAT = Convert.ToDouble(txtThueVAT.EditValue.ToString().Trim());
                }
                catch (Exception)
                {
                    kiemTra = false;
                    XtraMessageBox.Show("Thuế VAT nhập không đúng định dạng,\nNhập lại với kiểu số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtThueVAT.Text = string.Empty;
                    txtThueVAT.Focus();
                }

            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Thuế VAT", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtThueVAT.Focus();
            }

            if (txtDonViTinh.Text != "") hdBanXeObj.DonViTinh = txtDonViTinh.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Đơn vị tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hdBanXeObj.DonViTinh = string.Empty;
                txtDonViTinh.Focus();
            }

            try
            {
                if (flag == 1)
                {
                    if (txtMaHoaDon.Text != string.Empty && lueMaKhachHang.Text != string.Empty &&
                        lueMaXe.Text != string.Empty &&
                        txtDonViTinh.Text != string.Empty && dateNgayBan.Text != string.Empty &&
                        txtSoLuong.Text != string.Empty && txtThueVAT.Text != string.Empty && kiemTra)
                    {
                        if (hdBanXeControl.addData(hdBanXeObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucHoaDonBanXeMay_Load(sender, e);
                        }
                    }
                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                else if (flag == 2)
                {

                    if (txtMaHoaDon.Text != string.Empty && lueMaKhachHang.Text != string.Empty &&
                       lueMaXe.Text != string.Empty &&
                        txtDonViTinh.Text != string.Empty && dateNgayBan.Text != string.Empty &&
                        txtSoLuong.Text != string.Empty && txtThueVAT.Text != string.Empty && kiemTra)
                    {
                        if (hdBanXeControl.updateData(hdBanXeObj))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucHoaDonBanXeMay_Load(sender, e);
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

        private void gcDanhSachHoaDonBanXe_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvDanhSachHoaDonBanXe.FocusedRowHandle;
            object value1 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "MAHDBAN");
            if (value1 != null)
            {
                object value2 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "MAKH");
                object value4 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "MAXE");
                object value5 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "NGAYBAN");
                object value6 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "SOLUONG");
                object value7 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "THUEVAT");
                object value8 = gvDanhSachHoaDonBanXe.GetRowCellValue(HangDangChon, "DONVITINH");

                txtMaHoaDon.Text = value1 as string;
                lueMaKhachHang.Text = value2 as string;
                lueMaXe.Text = value4 as string;
                dateNgayBan.Text = value5.ToString().Split(' ')[0];
                txtSoLuong.Text = value6.ToString();
                txtThueVAT.Text = value7.ToString();
                txtDonViTinh.Text = value8 as string;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            var mahdban = gvDanhSachHoaDonBanXe.GetRowCellValue(gvDanhSachHoaDonBanXe.FocusedRowHandle, "MAHDBAN");
            if (mahdban != null) 
            {
                XtraReport rp = new XtraReport();
                rp.DataSource = hdBanXeControl.inHoaDon(mahdban.ToString().Trim());

                rp.LoadLayout(Application.StartupPath + @"\ReportHoaDonBanXeMay.repx");
                //if (textEdit1.Text == "1") rp.ShowDesignerDialog();
                //else rp.ShowPreviewDialog();
                rp.ShowPreviewDialog();
            }
            else XtraMessageBox.Show("Bạn chưa chọn đối tượng cần in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnXemToanBo_Click(object sender, EventArgs e)
        {
            gcDanhSachHoaDonBanXe.DataSource = hdBanXeControl.getAllDataHD();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachHoaDonBanXe);
        }

        private void btnXemHomNay_Click(object sender, EventArgs e)
        {
            gcDanhSachHoaDonBanXe.DataSource = hdBanXeControl.getDataHomNay(frmDangNhap.MaNhanVien.Trim());
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachHoaDonBanXe);
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            gcDanhSachHoaDonBanXe.DataSource = hdBanXeControl.getDataChiTiet(frmDangNhap.MaNhanVien);
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachHoaDonBanXe);
        }

    }
}
