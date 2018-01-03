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
    public partial class ucNhapXeNavBar : UserControl
    {
        public ucNhapXeNavBar()
        {
            InitializeComponent();
        }

        NhapXeControl nhapxeCtl = new NhapXeControl();
        NhapXeObj nhapxeObj = new NhapXeObj();
        NhaCungCapControl nccControl = new NhaCungCapControl();
        frmMain frm = new frmMain();
        ChiTietNhapXeControl ctnxControl = new ChiTietNhapXeControl();
        ChiTietNhapXeObj ctnxObj = new ChiTietNhapXeObj();
        ThongTinXeControl ttXeControl = new ThongTinXeControl();
        

        private void ucNhapXeNavBar_Load(object sender, EventArgs e)
        {
            //Không cho sửa GridView
            //gvDanhSachNhapXe.OptionsBehavior.Editable = false;

            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            enableSplitPannel(0);
            enableNhapXe(false);
            enableChiTietNhapXe(false);
            DeleteText();
            XoaTextChiTietNhapXe();

            gcDanhSachNhapXe.DataSource = nhapxeCtl.getAllDataToDay();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachNhapXe);

            LookUpEditMaNhaCungCap.Properties.DataSource = nccControl.getDataMaTen();
            LookUpEditMaNhaCungCap.Properties.DisplayMember = "MANHACC";

            lookUpEditMaNhap.Properties.DataSource = nhapxeCtl.getDataMa();
            lookUpEditMaNhap.Properties.DisplayMember = "MANHAP";

            lueMaThongTinXeMay.Properties.DataSource = ttXeControl.getAllData();
            lueMaThongTinXeMay.Properties.DisplayMember = "MATTXE";

            btnXoaDuLieu.Visible = false;
            lblThanhTien.Text = string.Empty;
            txtDonGiaNhap.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
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

        #region Nhập xe máy

        private void enableNhapXe(bool kt)
        {
            LookUpEditMaNhaCungCap.Enabled = kt;
            dateNgayNhap.Enabled = kt;
            btnHuy.Enabled = kt;
            btnLuu.Enabled = kt;
            txtTenNhaCC.Enabled = kt;
            btnThem.Enabled = !kt;
            btnSua.Enabled = !kt;
            btnXoa.Enabled = !kt;
            if (kt)
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

        private void DeleteText()
        {
            txtMaNhapXeMay.EditValue = string.Empty;
            LookUpEditMaNhaCungCap.EditValue = string.Empty;
            dateNgayNhap.EditValue = string.Empty;
        }

        int flag = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            enableSplitPannel(2);
            flag = 1;
            enableNhapXe(true);
            DeleteText();
            txtMaNhapXeMay.Text = frm.MaSoTuTang("NX", nhapxeCtl.getAllData());
            dateNgayNhap.Text = DateTime.Now.ToString().Split(' ')[0];
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            enableSplitPannel(2);
            flag = 2;
            enableNhapXe(true);
            txtMaNhapXeMay.Enabled = false;
            int HangDangChon = gvDanhSachNhapXe.FocusedRowHandle;
            object value1 = gvDanhSachNhapXe.GetRowCellValue(HangDangChon, "MANHAP");

            if (value1 != null)
            {
                object value3 = gvDanhSachNhapXe.GetRowCellValue(HangDangChon, "MANHACC");
                object value4 = gvDanhSachNhapXe.GetRowCellValue(HangDangChon, "NGAYNHAP");
                txtMaNhapXeMay.Text = value1.ToString();
                LookUpEditMaNhaCungCap.Text = value3.ToString();
                dateNgayNhap.Text = value4.ToString().Split(' ')[0];
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucNhapXeNavBar_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int HangDangChon = gvDanhSachNhapXe.FocusedRowHandle;
                object value = gvDanhSachNhapXe.GetRowCellValue(HangDangChon, "MANHAP");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (nhapxeCtl.deleteData(ma))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ucNhapXeNavBar_Load(sender, e);
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
                ucNhapXeNavBar_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            nhapxeObj.MaNV = frmDangNhap.MaNhanVien;
            nhapxeObj.MaNhap = txtMaNhapXeMay.EditValue.ToString().Trim();

            if (LookUpEditMaNhaCungCap.Text != "") nhapxeObj.MaNhaCC = LookUpEditMaNhaCungCap.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nhapxeObj.MaNhaCC = string.Empty;
                LookUpEditMaNhaCungCap.Focus();
            }

            
            if (dateNgayNhap.Text != "") nhapxeObj.NgayNhap = dateNgayNhap.EditValue.ToString().Trim().Split(' ')[0];
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Ngày nhập xe máy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateNgayNhap.Focus();
            }
            
            try
            {
                if (flag == 1)
                {
                    if (txtMaNhapXeMay.Text != string.Empty && LookUpEditMaNhaCungCap.Text != string.Empty &&
                       dateNgayNhap.Text != string.Empty && kiemTra)
                    {
                        if (nhapxeCtl.addData(nhapxeObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucNhapXeNavBar_Load(sender, e);
                        }
                    }
                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                else if(flag == 2)
                {
                    if (txtMaNhapXeMay.Text != string.Empty && LookUpEditMaNhaCungCap.Text != string.Empty &&
                       dateNgayNhap.Text != string.Empty && kiemTra)
                    {
                        if (nhapxeCtl.updateData(nhapxeObj))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucNhapXeNavBar_Load(sender, e);
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
            ucNhapXeNavBar_Load(sender, e);
        }


        private void gcDanhSachNhapXe_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvDanhSachNhapXe.FocusedRowHandle;
            object value1 = gvDanhSachNhapXe.GetRowCellValue(HangDangChon, "MANHAP");

            if (value1 != null)
            {
                object value3 = gvDanhSachNhapXe.GetRowCellValue(HangDangChon, "MANHACC");
                object value4 = gvDanhSachNhapXe.GetRowCellValue(HangDangChon, "NGAYNHAP");
                txtMaNhapXeMay.Text = value1.ToString();
                LookUpEditMaNhaCungCap.Text = value3.ToString();
                dateNgayNhap.Text = value4.ToString().Split(' ')[0];
                lookUpEditMaNhap.Text = value1.ToString();
            }
        }

        #endregion

        #region ChiTietNhapXe

        private void enableChiTietNhapXe(bool k)
        {
            speSoLuong.Enabled = k;
            lueMaThongTinXeMay.Enabled = k;
            txtDonGiaNhap.Enabled = k;
            txtTenXe.Enabled = k;
            txtMauXe.Enabled = k;
            txtDungTich.Enabled = k;
            btnThemChiTiet.Enabled = !k;
            btnXoaChiTiet.Enabled = !k;
            btnSuaChiTiet.Enabled = !k;
            btnLuuChiTiet.Enabled = k;
            btnIn.Enabled = !k;
            btnHuyChiTiet.Enabled = k;

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

        private void XoaTextChiTietNhapXe()
        {
            txtMaChiTietNhapXeMay.Text = string.Empty;
            txtDonGiaNhap.Text = string.Empty;
            speSoLuong.Text = string.Empty;
            lueMaThongTinXeMay.Text = string.Empty;
            lookUpEditMaNhap.Text = string.Empty;
            txtDonViTinh.Text = string.Empty;
            txtTenXe.Text = string.Empty;
            txtMauXe.Text = string.Empty;
            txtDungTich.Text = string.Empty;
            lblThanhTien.Text = string.Empty;
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            enableSplitPannel(1);
            enableChiTietNhapXe(true);
            XoaTextChiTietNhapXe();
            flag = 3;
            txtMaChiTietNhapXeMay.Text = frm.MaSoTuTang("CTNX", ctnxControl.getAllData());
            txtDonViTinh.Text = "Chiếc";
            
        }

        private void btnSuaChiTiet_Click(object sender, EventArgs e)
        {
            enableSplitPannel(1);
            flag = 4;
            enableChiTietNhapXe(true);
            txtMaChiTietNhapXeMay.Enabled = false;
            btnXoaDuLieu.Visible = true;

            int HangDangChon = gvDanhSachChiTietNhapXe.FocusedRowHandle; 
            object value1 = gvDanhSachChiTietNhapXe.GetRowCellValue(HangDangChon, "MACTN"); 

            if (value1 != null)
            {
                object value2 = gvDanhSachChiTietNhapXe.GetRowCellValue(HangDangChon, "MANHAP");
                object value3 = gvDanhSachChiTietNhapXe.GetRowCellValue(HangDangChon, "MATTXE");
                object value4 = gvDanhSachChiTietNhapXe.GetRowCellValue(HangDangChon, "DONGIANHAP");
                object value5 = gvDanhSachChiTietNhapXe.GetRowCellValue(HangDangChon, "SOLUONG");
                object value6 = gvDanhSachChiTietNhapXe.GetRowCellValue(HangDangChon, "DONVITINH");

                txtMaChiTietNhapXeMay.Text = value1.ToString();
                lookUpEditMaNhap.Text = value2.ToString();
                lueMaThongTinXeMay.Text = value3.ToString();
                txtDonGiaNhap.Text = value4.ToString();
                speSoLuong.Text = value5.ToString();
                txtDonViTinh.Text = value6.ToString();
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucNhapXeNavBar_Load(sender, e);
            }
            
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int row_index = gvDanhSachChiTietNhapXe.FocusedRowHandle;
                object value = gvDanhSachChiTietNhapXe.GetRowCellValue(row_index, "MACTN");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (ctnxControl.deleteData(ma))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lookUpEditMaNhap_EditValueChanged(sender, e);
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
            if (txtMaChiTietNhapXeMay.Text != "") ctnxObj.MaCTN = txtMaChiTietNhapXeMay.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã chi tiết nhập xe máy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctnxObj.MaCTN = string.Empty;
                txtMaChiTietNhapXeMay.Focus();
            }

            if (lookUpEditMaNhap.Text != "") ctnxObj.MaNhap = lookUpEditMaNhap.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã nhập xe máy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctnxObj.MaNhap = string.Empty;
                lookUpEditMaNhap.Focus();
            }

            if (lueMaThongTinXeMay.Text != "") ctnxObj.MaThongTinXe = lueMaThongTinXeMay.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã thông tin xe máy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctnxObj.MaThongTinXe = string.Empty;
                lueMaThongTinXeMay.Focus();
            }

            if (txtDonGiaNhap.Text != string.Empty)
            {
                try
                {
                    kiemTra = true;
                    ctnxObj.DonGia = Convert.ToInt32(txtDonGiaNhap.EditValue.ToString().Trim());
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
                txtDonViTinh.Focus();
            }

            if (speSoLuong.Text != string.Empty)
            {
                try
                {
                    kiemTra = true;
                    ctnxObj.SoLuong = Convert.ToInt32(speSoLuong.EditValue.ToString().Trim());
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
                speSoLuong.Focus();
            }

            if (txtDonViTinh.Text != "") ctnxObj.DonViTinh = txtDonViTinh.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Đơn vị tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctnxObj.DonViTinh = string.Empty;
                txtDonViTinh.Focus();
            }

            try
            {
                if (flag == 3)
                {
                    if (txtMaChiTietNhapXeMay.Text != string.Empty && lueMaThongTinXeMay.Text != string.Empty &&
                        txtDonViTinh.Text != string.Empty && speSoLuong.Text != string.Empty &&
                        txtDonGiaNhap.Text != string.Empty && lookUpEditMaNhap.Text != string.Empty && kiemTra)
                    {
                        if (ctnxControl.addData(ctnxObj))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lookUpEditMaNhap_EditValueChanged(sender, e);
                            enableChiTietNhapXe(false);
                            enableSplitPannel(0);
                            XoaTextChiTietNhapXe();
                        }
                    }
                    else MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
                else if (flag == 4)
                {

                    if (txtMaChiTietNhapXeMay.Text != string.Empty && lueMaThongTinXeMay.Text != string.Empty &&
                        txtDonViTinh.Text != string.Empty && speSoLuong.Text != string.Empty &&
                        txtDonGiaNhap.Text != string.Empty && lookUpEditMaNhap.Text != string.Empty && kiemTra)
                    {
                        if (ctnxControl.updateData(ctnxObj))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lookUpEditMaNhap_EditValueChanged(sender, e);
                            enableChiTietNhapXe(false);
                            enableSplitPannel(0);
                            XoaTextChiTietNhapXe();
                            btnXoaDuLieu.Visible = false;
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
            ucNhapXeNavBar_Load(sender, e);
        }

        private void lookUpEditMaNhap_EditValueChanged(object sender, EventArgs e)
        {
            gcDanhSachChiTietNhapXe.DataSource = ctnxControl.getDataChiTietNhapXeMayThayDoi(lookUpEditMaNhap.Text.Trim());
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachChiTietNhapXe);
        }

        #endregion

        private void btnXoaDuLieu_Click(object sender, EventArgs e)
        {
            txtDonViTinh.Text = string.Empty;
            speSoLuong.Text = string.Empty;
            lueMaThongTinXeMay.Text = string.Empty;
            txtDonGiaNhap.Text = string.Empty;
        }

        private void btnDayDuNhapXe_Click(object sender, EventArgs e)
        {
            gcDanhSachNhapXe.DataSource = nhapxeCtl.getDataChiTiet(frmDangNhap.MaNhanVien);
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachNhapXe);
        }

        private void btnHienTaiNhapXe_Click(object sender, EventArgs e)
        {
            gcDanhSachNhapXe.DataSource = nhapxeCtl.getAllDataToDay();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachNhapXe);
        }

        private void btnDayDuNhapXeChiTiet_Click(object sender, EventArgs e)
        {
            gcDanhSachChiTietNhapXe.DataSource = ctnxControl.getDataChiTiet(frmDangNhap.MaNhanVien);
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachChiTietNhapXe);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            int HangDangChon = gvDanhSachNhapXe.FocusedRowHandle;
            object maNhap = gvDanhSachNhapXe.GetRowCellValue(HangDangChon, "MANHAP");

            if (maNhap != null)
            {
                DataTable dt = new DataTable();
                dt = nhapxeCtl.getAllDataPrint((maNhap as string).Trim());

                XtraReport rp = new XtraReport();
                rp.DataSource = nhapxeCtl.getAllDataPrint((maNhap as string).Trim());
                rp.LoadLayout(Application.StartupPath + @"\ReportHoaDonNhapXeMay.repx");
                //rp.ShowDesignerDialog();
                rp.ShowPreviewDialog();
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần in ấn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void lueMaThongTinXeMay_EditValueChanged(object sender, EventArgs e)
        {
            txtTenXe.Text = ttXeControl.getTenXe(lueMaThongTinXeMay.Text).Trim();
            txtMauXe.Text = ttXeControl.getMauXe(lueMaThongTinXeMay.Text).Trim();
            txtDungTich.Text = ttXeControl.getDungTich(lueMaThongTinXeMay.Text).Trim();
        }

        private void txtSoLuong_EditValueChanged(object sender, EventArgs e)
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

        private void btnThemThongTinXe_Click(object sender, EventArgs e)
        {
            frmThongTinXe frmTT = new frmThongTinXe();
            frmTT.ShowDialog();
            ucNhapXeNavBar_Load(sender, e);
            lueMaThongTinXeMay.Properties.DataSource = ttXeControl.getAllData();
            lueMaThongTinXeMay.Properties.DisplayMember = "MATTXE";
        }

        private void gcDanhSachChiTietNhapXe_Click(object sender, EventArgs e)
        {

            int HangDangChon = gvDanhSachChiTietNhapXe.FocusedRowHandle;
            object value1 = gvDanhSachChiTietNhapXe.GetRowCellValue(HangDangChon, "MACTN");

            if (value1 != null)
            {
                object value2 = gvDanhSachChiTietNhapXe.GetRowCellValue(HangDangChon, "MANHAP");
                object value3 = gvDanhSachChiTietNhapXe.GetRowCellValue(HangDangChon, "MATTXE");
                object value4 = gvDanhSachChiTietNhapXe.GetRowCellValue(HangDangChon, "DONGIANHAP");
                object value5 = gvDanhSachChiTietNhapXe.GetRowCellValue(HangDangChon, "SOLUONG");
                object value6 = gvDanhSachChiTietNhapXe.GetRowCellValue(HangDangChon, "DONVITINH");

                txtMaChiTietNhapXeMay.Text = value1.ToString();
                lookUpEditMaNhap.Text = value2.ToString();
                lueMaThongTinXeMay.Text = value3.ToString();
                txtDonGiaNhap.Text = value4.ToString();
                speSoLuong.Text = value5.ToString();
                txtDonViTinh.Text = value6.ToString();
            }
        }

        private void LookUpEditMaNhaCungCap_EditValueChanged(object sender, EventArgs e)
        {
            txtTenNhaCC.Text = nccControl.tenNhaCungCap(LookUpEditMaNhaCungCap.Text.Trim());
        }

        private void btnFull_Click(object sender, EventArgs e)
        {
            gcDanhSachNhapXe.DataSource = nhapxeCtl.getAllData();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachNhapXe);
        }

        private void btnFullChiTiet_Click(object sender, EventArgs e)
        {
            gcDanhSachChiTietNhapXe.DataSource = ctnxControl.getAllData();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachChiTietNhapXe);
        }
    }
}
