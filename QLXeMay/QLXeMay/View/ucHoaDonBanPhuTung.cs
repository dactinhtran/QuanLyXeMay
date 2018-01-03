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
    public partial class ucHoaDonBanPhuTung : UserControl
    {
        public ucHoaDonBanPhuTung()
        {
            InitializeComponent();
        }

        HoaDonBanPhuTungObj hdbPTObj = new HoaDonBanPhuTungObj();
        HoaDonBanPhuTungControl hdbPTControl = new HoaDonBanPhuTungControl();
        PhuTungControl ptControl = new PhuTungControl();
        KhachHangControl khControl = new KhachHangControl();
        NhanVienControl nvControl = new NhanVienControl();
        frmMain frm = new frmMain();
        ChiTietHoaDonBanPhuTungControl cthdbPhuTungControl = new ChiTietHoaDonBanPhuTungControl();
        ChiTietHoaDonBanPhuTungObj cthdbPhuTungObj = new ChiTietHoaDonBanPhuTungObj();


        private void ucHoaDonBanPhuTung_Load(object sender, EventArgs e)
        {
            splitContainerControl1.FixedPanel = SplitFixedPanel.None;
            splitContainerControl2.FixedPanel = SplitFixedPanel.None;
            deleteText();
            enable(true);
            txtMaHoaDonBanPT.Enabled = false;

            txtMaHoaDonBanPT.Text = frm.MaSoTuTang("BPT", hdbPTControl.getAllData());

            lueMaKhachHang.Properties.DataSource = khControl.getAllDataMaTenCMND();
            lueMaKhachHang.Properties.DisplayMember = "MAKH";

            lueMaNhanVien.Properties.DataSource = nvControl.getDataMaTen();
            lueMaNhanVien.Properties.DisplayMember = "MANV";
            lueMaNhanVien.Text = frmDangNhap.MaNhanVien;
            dateNgayBan.Text = DateTime.Today.ToShortDateString();
            gcPhuTungTrongCuaHang.DataSource = ptControl.getPhuTungCoTrongCuaHangUCHD();
            frmMain.DatLaiTenCotCuaGridView(gvPhuTungTrongCuaHang);
        }

        private void deleteText()
        {
            txtMaHoaDonBanPT.Text = txtTenKhachHang.Text = txtTenNhanVien.Text = lueMaKhachHang.Text = lueMaNhanVien.Text = string.Empty;
        }

        private void enable(bool k)
        {
            dateNgayBan.Enabled = lueMaKhachHang.Enabled = txtTenKhachHang.Enabled = btnChonPhuTung.Enabled = k;
            gcPhuTungTrongCuaHang.Enabled = gcPhuTungDaChon.Enabled = btnHuy.Enabled = !k;
        }

        private void lueMaKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMaKhachHang.Text != string.Empty) txtTenKhachHang.Text = khControl.getTenKhachHang(lueMaKhachHang.Text.Trim());
        }

        private void lueMaNhanVien_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMaNhanVien.Text != string.Empty) txtTenNhanVien.Text = nvControl.getTenNV(lueMaNhanVien.Text.Trim());
        }

        int kiemTraClickChonPT = 2;
        private void btnChonPhuTung_Click(object sender, EventArgs e)
        {
            bool kiemTraHoaDonBan = true;
            if (txtMaHoaDonBanPT.Text != "") hdbPTObj.MaHoaDonBanPhuTung = txtMaHoaDonBanPT.EditValue.ToString().Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã hóa đơn bán phụ tùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kiemTraHoaDonBan = false;
                hdbPTObj.MaHoaDonBanPhuTung = string.Empty;
                txtMaHoaDonBanPT.Focus();
            }

            hdbPTObj.MaNV = lueMaNhanVien.Text.Trim();

            if (lueMaKhachHang.Text != "") hdbPTObj.MaKH = lueMaKhachHang.Text.Trim();
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Mã khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kiemTraHoaDonBan = false;
                hdbPTObj.MaKH = string.Empty;
                lueMaKhachHang.Focus();
            }

            if (dateNgayBan.Text != "") hdbPTObj.NgayBan = dateNgayBan.EditValue.ToString().Trim().Split(' ')[0];
            else
            {
                XtraMessageBox.Show("Bạn chưa nhập Ngày bán phụ tùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kiemTraHoaDonBan = false;
                dateNgayBan.Focus();
            }

            if (kiemTraHoaDonBan)
            {

                enable(false);
                try
                {
                    if (txtMaHoaDonBanPT.Text != string.Empty && lueMaNhanVien.Text != string.Empty &&
                       lueMaKhachHang.Text != string.Empty && dateNgayBan.Text != string.Empty)
                    {
                        if (hdbPTControl.addData(hdbPTObj))
                        {
                            kiemTraClickChonPT = 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                gvPhuTungTrongCuaHang.OptionsSelection.MultiSelect = true;
                gvPhuTungTrongCuaHang.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                gvPhuTungDaChon.OptionsSelection.MultiSelect = true;
                gvPhuTungDaChon.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            }

        }

        private void gvPhuTungTrongCuaHang_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add)
            {
                cthdbPhuTungObj.MaChiTietHoaDonBanPhuTung = frm.MaSoTuTang("CTBPT", cthdbPhuTungControl.getAllData());
                var mapt = gvPhuTungTrongCuaHang.GetRowCellValue(e.ControllerRow, "MAPT");
                cthdbPhuTungObj.MaPhuTung = mapt.ToString().Trim();
                cthdbPhuTungObj.MaHoaDonBanPhuTung = txtMaHoaDonBanPT.Text.Trim();
                cthdbPhuTungObj.SoLuong = 1;
                //MessageBox.Show(cthdbPhuTungObj.MaChiTietHoaDonBanPhuTung + " " + cthdbPhuTungObj.MaHoaDonBanPhuTung + " " + cthdbPhuTungObj.MaPhuTung + " " + cthdbPhuTungObj.SoLuong);
                try
                {
                    if (cthdbPhuTungControl.addData(cthdbPhuTungObj))
                    {
                        // MessageBox.Show("Them ok");
                    }
                    // else MessageBox.Show("Them ngu roi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                gcPhuTungTrongCuaHang.DataSource = ptControl.getPhuTungCoTrongCuaHangUCHD();
                gcPhuTungDaChon.DataSource = ptControl.getPhuTungDaChonKhiMuaPT(txtMaHoaDonBanPT.Text.Trim());
                frmMain.DatLaiTenCotCuaGridView(gvPhuTungDaChon);
                // MessageBox.Show(a.ToString());
                // MessageBox.Show(e.ControllerRow.ToString());
            }
        }

        private void gvPhuTungDaChon_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add)
            {
                var mapt = gvPhuTungDaChon.GetRowCellValue(e.ControllerRow, "MAPT");
                string mactbpt = cthdbPhuTungControl.getMaCTHoaDonBanPTTuMaPT(mapt.ToString());

                try
                {
                    if (cthdbPhuTungControl.deleteData(mactbpt)){}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                gcPhuTungTrongCuaHang.DataSource = ptControl.getPhuTungCoTrongCuaHangUCHD();
                gcPhuTungDaChon.DataSource = ptControl.getPhuTungDaChonKhiMuaPT(txtMaHoaDonBanPT.Text.Trim());
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            var dtChiTietHDBanPT = new DataTable();
            dtChiTietHDBanPT = cthdbPhuTungControl.getMaCTHoaDonBanPTTuMaHDBanPT(txtMaHoaDonBanPT.Text.Trim());
            if (dtChiTietHDBanPT.Rows.Count > 0)
            {
                for (int i = 0; i < dtChiTietHDBanPT.Rows.Count; i++)
                {
                    if (cthdbPhuTungControl.deleteData(dtChiTietHDBanPT.Rows[i][0].ToString())) { }
                }
            }

            if (hdbPTControl.deleteData(txtMaHoaDonBanPT.Text.Trim())) { }
            ucHoaDonBanPhuTung_Load(sender, e);
            gcPhuTungTrongCuaHang.DataSource = ptControl.getPhuTungCoTrongCuaHangUCHD();
            gcPhuTungDaChon.DataSource = ptControl.getPhuTungDaChonKhiMuaPT(txtMaHoaDonBanPT.Text.Trim());
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (kiemTraClickChonPT == 1)
            {

                if (XtraMessageBox.Show("Bạn có muốn in hóa đơn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    XtraReport rp = new XtraReport();
                    rp.DataSource = hdbPTControl.getAllDataPrint(txtMaHoaDonBanPT.Text.Trim());
                    rp.LoadLayout(Application.StartupPath + @"\ReportHoaDonBanPhuTung.repx");
                    //rp.ShowDesignerDialog();
                    rp.ShowPreviewDialog();
                }
                ucHoaDonBanPhuTung_Load(sender, e);
                kiemTraClickChonPT++;
                gcPhuTungDaChon.DataSource = ptControl.getPhuTungDaChonKhiMuaPT(txtMaHoaDonBanPT.Text.Trim());
            }
            else
            {
                kiemTraClickChonPT++;
                XtraMessageBox.Show("Chưa chọn phụ tùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmDanhSachHoaDonBanPhuTung f = new frmDanhSachHoaDonBanPhuTung();
            f.ShowDialog();
            ucHoaDonBanPhuTung_Load(sender, e);
        }
    }
}
