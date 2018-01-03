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
    public partial class ucNhapPhuTungNavBar : UserControl
    {
        public ucNhapPhuTungNavBar()
        {
            InitializeComponent();
        }

        NhapPhuTungControl nhapPTControl = new NhapPhuTungControl();
        NhapPhuTungObj nhapPTObj = new NhapPhuTungObj();
        NhaCungCapControl nccControl = new NhaCungCapControl();
        frmMain frm = new frmMain();
        ChiTietNhapPhuTungControl ctnhapPTControl = new ChiTietNhapPhuTungControl();
        ChiTietNhapPhuTungObj ctnhapPTObj = new ChiTietNhapPhuTungObj();
        ThongTinPhuTungControl TTPTControl = new ThongTinPhuTungControl();

        private void ucNhapPhuTungNavBar_Load(object sender, EventArgs e)
        {
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            enableChiTietPhuTung(false);
            enablePhuTung(false);
            enableSplitPannel(0);
            DeleteText();
            DeleteTextChiTiet();
            lblThanhTien.Text = string.Empty;
            
            gcDanhSachNhapPhuTung.DataSource = nhapPTControl.getAllData();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachNhapPhuTung);
            frmMain.SapXepLaiGridView(gvDanhSachNhapPhuTung, "MANPT", false);

            lueMaNhaCungCap.Properties.DataSource = nccControl.getDataMaTen();
            lueMaNhaCungCap.Properties.DisplayMember = "MANHACC";

            lueMaNhapPhuTung.Properties.DataSource = nhapPTControl.getDataMa();
            lueMaNhapPhuTung.Properties.DisplayMember = "MANPT";

            lueMaTTPhuTung.Properties.DataSource = TTPTControl.getAllData();
            lueMaTTPhuTung.Properties.DisplayMember = "MATTPT";
            
            txtDonViTinh.Text = "";
        }


        #region Nhập phụ tùng
        
        
        private void enablePhuTung(bool k)
        {
            layoutControl1.Enabled = k;
            btnLuu.Enabled = k;
            btnHuy.Enabled = k;
            btnThem.Enabled = !k;
            btnSua.Enabled = !k;
            btnXoa.Enabled = !k;
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

        private void DeleteText()
        {
            txtMaNhapPhuTung.EditValue = string.Empty;
            lueMaNhaCungCap.EditValue = string.Empty;
            dateNgayNhap.EditValue = string.Empty;
        }

        int flag = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            enablePhuTung(true);
            enableSplitPannel(2);
            DeleteText();
            txtMaNhapPhuTung.Text = frm.MaSoTuTang("NPT", nhapPTControl.getAllData());
            dateNgayNhap.Text = DateTime.Today.ToString().Split(' ')[0];
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            enablePhuTung(true);
            enableSplitPannel(2);
            flag = 2;
            txtMaNhapPhuTung.Enabled = false;
            int HangDangChon = gvDanhSachNhapPhuTung.FocusedRowHandle;
            object value1 = gvDanhSachNhapPhuTung.GetRowCellValue(HangDangChon, "MANPT");

            if (value1 != null)
            {
                object value2 = gvDanhSachNhapPhuTung.GetRowCellValue(HangDangChon, "MANHACC");
                object value4 = gvDanhSachNhapPhuTung.GetRowCellValue(HangDangChon, "NGAYNHAP");
                txtMaNhapPhuTung.Text = value1.ToString();
                lueMaNhaCungCap.Text = value2.ToString();
                dateNgayNhap.Text = value4.ToString().Split(' ')[0];
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucNhapPhuTungNavBar_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int HangDangChon = gvDanhSachNhapPhuTung.FocusedRowHandle;
                object value = gvDanhSachNhapPhuTung.GetRowCellValue(HangDangChon, "MANPT");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (nhapPTControl.deleteData(ma))
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
                gcDanhSachNhapPhuTung.DataSource = nhapPTControl.getAllData();
                frmMain.DatLaiTenCotCuaGridView(gvDanhSachNhapPhuTung);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            nhapPTObj.MaNV = frmDangNhap.MaNhanVien;

            if (txtMaNhapPhuTung.Text != "") nhapPTObj.MaNhapPhuTung = txtMaNhapPhuTung.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã nhập phụ tùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nhapPTObj.MaNhapPhuTung = string.Empty;
                txtMaNhapPhuTung.Focus();
            }

            if (lueMaNhaCungCap.Text != "") nhapPTObj.MaNhaCungCap = lueMaNhaCungCap.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nhapPTObj.MaNhaCungCap = string.Empty;
                lueMaNhaCungCap.Focus();
            }

           
           

            if (dateNgayNhap.Text != "") nhapPTObj.NgayNhap = dateNgayNhap.EditValue.ToString().Trim().Split(' ')[0];
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Ngày nhập phụ tùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateNgayNhap.Focus();
            }

            try
            {
                if (flag == 1)
                {
                    if (txtMaNhapPhuTung.Text != string.Empty && lueMaNhaCungCap.Text != string.Empty && dateNgayNhap.Text != string.Empty)
                    {
                        if (nhapPTControl.addData(nhapPTObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucNhapPhuTungNavBar_Load(sender, e);
                        }
                    }
                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                else if (flag == 2)
                {
                    if (txtMaNhapPhuTung.Text != string.Empty && lueMaNhaCungCap.Text != string.Empty && dateNgayNhap.Text != string.Empty)
                    {
                        if (nhapPTControl.updateData(nhapPTObj))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucNhapPhuTungNavBar_Load(sender, e);
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
            ucNhapPhuTungNavBar_Load(sender, e);
        }

        private void gcDanhSachNhapPhuTung_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvDanhSachNhapPhuTung.FocusedRowHandle;
            object value1 = gvDanhSachNhapPhuTung.GetRowCellValue(HangDangChon, "MANPT");

            if (value1 != null)
            {
                object value2 = gvDanhSachNhapPhuTung.GetRowCellValue(HangDangChon, "MANHACC");
                object value4 = gvDanhSachNhapPhuTung.GetRowCellValue(HangDangChon, "NGAYNHAP");
                txtMaNhapPhuTung.Text = value1.ToString();
                lueMaNhaCungCap.Text = value2.ToString();
                dateNgayNhap.Text = value4.ToString().Split(' ')[0];
                lueMaNhapPhuTung.Text = value1 as string;
            }

            //Xóa text cũ
            txtMaChiTietNhapPhuTung.Text = lueMaTTPhuTung.Text = txtDonGiaNhap.Text = speSoLuong.Text = txtDonViTinh.Text = txtLoaiPT.Text = txtTenPT.Text = string.Empty;
        }

        private void lueMaNhapPhuTung_EditValueChanged(object sender, EventArgs e)
        {
            gcDanhSachChiTietNhapPhuTung.DataSource = ctnhapPTControl.getDataUCNhapPTMaNhapPTThayDoi(lueMaNhapPhuTung.Text.Trim());
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachChiTietNhapPhuTung);
        }

        #endregion

        #region ChiTietNhapPT
        //Chi Tiêt nhập phụ tùng

        private void DeleteTextChiTiet()
        {
            txtMaChiTietNhapPhuTung.Text = lueMaNhapPhuTung.Text = txtDonGiaNhap.Text = speSoLuong.Text = txtDonViTinh.Text = txtLoaiPT.Text = txtTenPT.Text = lueMaTTPhuTung.Text = string.Empty;
            lblThanhTien.Text = "";
        }

        private void enableChiTietPhuTung(bool k)
        {
            layoutControl2.Enabled = btnLuuChiTiet.Enabled = btnHuyChiTiet.Enabled = layoutControl3.Enabled = k;
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
            enableChiTietPhuTung(true);
            DeleteTextChiTiet();
            txtMaChiTietNhapPhuTung.Text = frm.MaSoTuTang("CTNPT", ctnhapPTControl.getAllData());
        }

        private void btnSuaChiTiet_Click(object sender, EventArgs e)
        {
            flag = 4;
            enableChiTietPhuTung(true);
            enableSplitPannel(1);
            txtMaChiTietNhapPhuTung.Enabled = false;

            int HangDangChon = gvDanhSachChiTietNhapPhuTung.FocusedRowHandle;
            object value1 = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(HangDangChon, "MACTNPT");

            if (value1 != null)
            {
                object value2 = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(HangDangChon, "MANPT");
                object value3 = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(HangDangChon, "MATTPT");
                object value4 = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(HangDangChon, "DONGIANHAP");
                object value5 = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(HangDangChon, "SOLUONG");
                object value6 = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(HangDangChon, "THANHTIEN");

                txtMaChiTietNhapPhuTung.Text = value1.ToString();
                lueMaNhapPhuTung.Text = value2.ToString();
                lueMaTTPhuTung.Text = value3.ToString();
                txtDonGiaNhap.Text = value4.ToString();
                speSoLuong.Text = value5.ToString();
                lblThanhTien.Text = "Thành tiền: " + value6.ToString();
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucNhapPhuTungNavBar_Load(sender, e);
            }
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int row_index = gvDanhSachChiTietNhapPhuTung.FocusedRowHandle;
                object value = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(row_index, "MACTNPT");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (ctnhapPTControl.deleteData(ma))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lueMaNhapPhuTung_EditValueChanged(sender, e);
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
            if (txtMaChiTietNhapPhuTung.Text != "") ctnhapPTObj.MaCTNhapPT = txtMaChiTietNhapPhuTung.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã chi tiết nhập phụ tùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctnhapPTObj.MaCTNhapPT = string.Empty;
                txtMaChiTietNhapPhuTung.Focus();
            }

            if (lueMaNhapPhuTung.Text != "") ctnhapPTObj.MaNhapPT = lueMaNhapPhuTung.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã nhập phụ tùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctnhapPTObj.MaNhapPT = string.Empty;
                lueMaNhapPhuTung.Focus();
            }

            if (lueMaTTPhuTung.Text != "") ctnhapPTObj.MaTTPT = lueMaTTPhuTung.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã thông tin phụ tùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctnhapPTObj.MaTTPT = string.Empty;
                lueMaTTPhuTung.Focus();
            }

            if (txtDonGiaNhap.Text != "")
            {
                try
                {
                    kiemTra = true;
                    ctnhapPTObj.DonGiaNhap = Convert.ToInt32(txtDonGiaNhap.Text.Trim());
                }
                catch (Exception)
                {
                    kiemTra = false;
                    XtraMessageBox.Show("Đơn giá nhập không đúng định dạng,\nNhập lại với kiểu số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDonGiaNhap.Text = string.Empty;
                    txtDonGiaNhap.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Đơn giá nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctnhapPTObj.DonGiaNhap = 0;
                txtDonGiaNhap.Focus();
            }

            if (speSoLuong.Text != "" && speSoLuong.Text != "0")
            {
                try
                {
                    kiemTra = true;
                    ctnhapPTObj.SoLuong = Convert.ToInt32(speSoLuong.Text.Trim());
                }
                catch (Exception)
                {
                    kiemTra = false;
                    XtraMessageBox.Show("Số lượng nhập không đúng định dạng,\nNhập lại với kiểu số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    speSoLuong.Text = string.Empty;
                    speSoLuong.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Số lượng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctnhapPTObj.SoLuong = 0;
                speSoLuong.Focus();
            }

            try
            {
                if (flag == 3)
                {
                    if (txtMaChiTietNhapPhuTung.Text != string.Empty && lueMaNhapPhuTung.Text != string.Empty &&
                        lueMaTTPhuTung.Text != string.Empty && txtDonGiaNhap.Text != string.Empty &&
                        speSoLuong.Text != string.Empty && kiemTra && Convert.ToInt32(speSoLuong.Text) != 0 && Convert.ToInt32(txtDonGiaNhap.Text) != 0)
                    {
                        if (ctnhapPTControl.addData(ctnhapPTObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lueMaNhapPhuTung_EditValueChanged(sender, e);
                            enableChiTietPhuTung(false);
                            enableSplitPannel(0);
                            DeleteTextChiTiet();
                        }
                    }
                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                else if (flag == 4)
                {
                    if (txtMaChiTietNhapPhuTung.Text != string.Empty && lueMaNhapPhuTung.Text != string.Empty &&
                        lueMaTTPhuTung.Text != string.Empty && txtDonGiaNhap.Text != string.Empty &&
                        speSoLuong.Text != string.Empty && kiemTra)
                    {
                        if (ctnhapPTControl.updateData(ctnhapPTObj))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lueMaNhapPhuTung_EditValueChanged(sender, e);
                            enableChiTietPhuTung(false);
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

        private void btnHuyChiTiet_Click(object sender, EventArgs e)
        {
            ucNhapPhuTungNavBar_Load(sender, e);
        }

        private void btnInChiTiet_Click(object sender, EventArgs e)
        {

        }

        private void btnThemThongTinPhuTung_Click(object sender, EventArgs e)
        {
            frmThongTinPhuTung frm = new frmThongTinPhuTung();
            frm.ShowDialog();
            lueMaTTPhuTung.Properties.DataSource = TTPTControl.getAllData();
            lueMaTTPhuTung.Properties.DisplayMember = "MATTPT";
        }

        private void lueMaTTPhuTung_EditValueChanged(object sender, EventArgs e)
        {
            txtLoaiPT.Text = TTPTControl.getLoaiPhuTung(lueMaTTPhuTung.Text.Trim());
            txtTenPT.Text = TTPTControl.getTenPhuTung(lueMaTTPhuTung.Text.Trim());
            txtDonViTinh.Text = TTPTControl.getDonViTinh(lueMaTTPhuTung.Text.Trim());
        }


        #endregion

        private void gcDanhSachChiTietNhapPhuTung_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvDanhSachChiTietNhapPhuTung.FocusedRowHandle;
            object value1 = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(HangDangChon, "MACTNPT");

            if (value1 != null)
            {
                object value2 = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(HangDangChon, "MANPT");
                object value3 = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(HangDangChon, "MATTPT");
                object value4 = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(HangDangChon, "DONGIANHAP");
                object value5 = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(HangDangChon, "SOLUONG");
                object value6 = gvDanhSachChiTietNhapPhuTung.GetRowCellValue(HangDangChon, "THANHTIEN");

                txtMaChiTietNhapPhuTung.Text = value1.ToString();
                lueMaNhapPhuTung.Text = value2.ToString();
                lueMaTTPhuTung.Text = value3.ToString();
                txtDonGiaNhap.Text = value4.ToString();
                speSoLuong.Text = value5.ToString();
                lblThanhTien.Text = "Thành tiền: " + value6;
                txtLoaiPT.Text = TTPTControl.getLoaiPhuTung(lueMaTTPhuTung.Text.Trim());
                txtTenPT.Text = TTPTControl.getTenPhuTung(lueMaTTPhuTung.Text.Trim());
                txtDonViTinh.Text = TTPTControl.getDonViTinh(lueMaTTPhuTung.Text.Trim());
            }
        }

        private void txtDonGiaNhap_EditValueChanged(object sender, EventArgs e)
        {
            if (speSoLuong.Text != string.Empty && txtDonGiaNhap.Text != string.Empty)
            {
                try
                {
                    lblThanhTien.Text = "Thành tiền: " + (Convert.ToInt32(txtDonGiaNhap.Text) * Convert.ToInt32(speSoLuong.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Vui lòng chọn giá trị thấp hơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void speSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            if (speSoLuong.Text != string.Empty && txtDonGiaNhap.Text != string.Empty)
            {
                try
                {
                    lblThanhTien.Text = "Thành tiền: " + (Convert.ToInt32(txtDonGiaNhap.Text) * Convert.ToInt32(speSoLuong.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Vui lòng chọn giá trị thấp hơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvDanhSachNhapPhuTung.FocusedRowHandle;
            var maNhapPT = gvDanhSachNhapPhuTung.GetRowCellValue(HangDangChon, "MANPT");

            if (maNhapPT != null)
            {
                XtraReport rp = new XtraReport();
                rp.DataSource = nhapPTControl.getAllDataPrint((maNhapPT as string).Trim());
                //rp.ShowDesignerDialog();
                rp.LoadLayout(Application.StartupPath + @"\ReportHoaDonNhapPhuTung.repx");
                //rp.ShowDesignerDialog();
                rp.ShowPreviewDialog();
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần in ấn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lueMaNhaCungCap_EditValueChanged(object sender, EventArgs e)
        {
            txtTenNhaCungCap.Text = nccControl.tenNhaCungCap(lueMaNhaCungCap.Text.Trim());
        }
    }
}
