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
using DevExpress.Utils.Menu;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;

namespace QLXeMay.View
{
    public partial class frmDanhSachHoaDonBanPhuTung : XtraForm
    {
        public frmDanhSachHoaDonBanPhuTung()
        {
            InitializeComponent();
        }

        HoaDonBanPhuTungControl hdbptControl = new HoaDonBanPhuTungControl();
        ChiTietHoaDonBanPhuTungControl cthdbptControl = new ChiTietHoaDonBanPhuTungControl();

        public void frmDanhSachHoaDonBanPhuTung_Load(object sender, EventArgs e)
        {
            gcHoaDon.DataSource = hdbptControl.getDataDanhSachHoaDon();
            frmMain.DatLaiTenCotCuaGridView(gvHoaDon);
        }

        private void gcHoaDon_Click(object sender, EventArgs e)
        {
            var value1 = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MAHDBANPT");

            if (value1 != null)
            {
                gcChiTietHoaDon.DataSource = cthdbptControl.getAllDataDanhSachChiTiet(value1.ToString().Trim());
                frmMain.DatLaiTenCotCuaGridView(gvChiTietHoaDon);
            }
        }

        int hangDangChon = -1;
        private void gvHoaDon_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                hangDangChon = e.HitInfo.RowHandle;
                e.Menu.Items.Clear();

                DXMenuItem menu = new DXMenuItem("Xóa hóa đơn bán phụ tùng", new EventHandler(XoaHangDangChon)); 
                e.Menu.Items.Add(menu);

                DXMenuItem menu1 = new DXMenuItem("Sửa hóa đơn bán phụ tùng", new EventHandler(SuaHangDangChon));
                e.Menu.Items.Add(menu1);

                DXMenuItem menu2 = new DXMenuItem("In hóa đơn bán phụ tùng", new EventHandler(InHangDangChon));
                e.Menu.Items.Add(menu2);
            }
        }

        void XoaHangDangChon(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                object value = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MAHDBANPT");
                if (value != null)
                {
                    if (hdbptControl.deleteData(value.ToString().Trim()))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmDanhSachHoaDonBanPhuTung_Load(sender, e);
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public static string mahd, makh, tenkh, ngayban;
        void SuaHangDangChon(object sender, EventArgs e)
        {
            mahd = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MAHDBANPT").ToString();
            makh = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MAKH").ToString();
            tenkh = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "TENKH").ToString();
            ngayban = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "NGAYBAN").ToString().Split(' ')[0];
            frmCapNhatHoaDonBanPhuTung frm = new frmCapNhatHoaDonBanPhuTung();
            frm.ShowDialog();
            frmDanhSachHoaDonBanPhuTung_Load(sender, e);
            
        }

        void InHangDangChon(object sender, EventArgs e)
        {
            XtraReport rp = new XtraReport();
            rp.DataSource = hdbptControl.getAllDataPrint(gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MAHDBANPT").ToString());
            //rp.ShowDesignerDialog();
            rp.LoadLayout(Application.StartupPath + @"\ReportHoaDonBanPhuTung.repx");
            // rp.ShowDesignerDialog();
            rp.ShowPreviewDialog();
        }


        int hangctDangChon = -1;
        private void gvChiTietHoaDon_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                hangctDangChon = e.HitInfo.RowHandle;
                e.Menu.Items.Clear();

                DXMenuItem menu = new DXMenuItem("Xóa phụ tùng đã chọn", new EventHandler(XoaPTDangChon));
                e.Menu.Items.Add(menu);
            }
        }

        void XoaPTDangChon(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                object value = gvChiTietHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MACTHDBANPT");
                if (value != null)
                {
                    if (cthdbptControl.deleteData(value.ToString().Trim()))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmDanhSachHoaDonBanPhuTung_Load(sender, e);
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

    }
}
