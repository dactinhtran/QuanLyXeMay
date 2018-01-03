using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QLXeMay.Control;
using DevExpress.XtraEditors;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;

namespace QLXeMay.View
{
    public partial class ucKhachHang : UserControl
    {
        public ucKhachHang()
        {
            InitializeComponent();
        }

        KhachHangControl khControl = new KhachHangControl();

        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            gcDanhSachKhachHang.DataSource = khControl.getAllData();
        }

        private void gvDanhSachKhachHang_RowCountChanged(object sender, EventArgs e)
        {
            lblTong.Text = "Tổng khách hàng: " + gvDanhSachKhachHang.RowCount;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.flag = true;
            frm.ShowDialog();
            ucKhachHang_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int hangDangChon = gvDanhSachKhachHang.FocusedRowHandle;
            var value1 = gvDanhSachKhachHang.GetRowCellValue(hangDangChon, "MAKH");

            if (value1 != null)
            {
                var value2 = gvDanhSachKhachHang.GetRowCellValue(hangDangChon, "TENKH");
                var value3 = gvDanhSachKhachHang.GetRowCellValue(hangDangChon, "NGAYSINH");
                var value4 = gvDanhSachKhachHang.GetRowCellValue(hangDangChon, "GIOITINH");
                var value5 = gvDanhSachKhachHang.GetRowCellValue(hangDangChon, "SOCMND");
                var value6 = gvDanhSachKhachHang.GetRowCellValue(hangDangChon, "DIACHI");
                var value7 = gvDanhSachKhachHang.GetRowCellValue(hangDangChon, "SDT");

                frmKhachHang frm = new frmKhachHang();
                frm.flag = false;
                frm.maKH = value1 as string;
                frm.tenKH = value2 as string;
                frm.ngaySinh = (DateTime)value3;
                frm.gioiTinh = value4 as string;
                frm.soCMND = value5 as string;
                frm.diaChi = value6 as string;
                frm.sdt = value7 as string;

                frm.ShowDialog();
                ucKhachHang_Load(sender, e);
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int HangDangChon = gvDanhSachKhachHang.FocusedRowHandle;
                object value = gvDanhSachKhachHang.GetRowCellValue(HangDangChon, "MAKH");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (khControl.deleteData(ma))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ucKhachHang_Load(sender, e);
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

        int hang = -1;
        private void gvDanhSachKhachHang_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                hang = e.HitInfo.RowHandle;
                e.Menu.Items.Clear();

                DXMenuItem menu2 = new DXMenuItem("Thêm khách hàng mới", new EventHandler(ThemKhachHang));
                e.Menu.Items.Add(menu2);

                DXMenuItem menu = new DXMenuItem("Xóa thông tin khách hàng", new EventHandler(XoaHangDangChon));
                e.Menu.Items.Add(menu);

                DXMenuItem menu1 = new DXMenuItem("Sửa thông tin khách hàng", new EventHandler(SuaHangDangChon));
                e.Menu.Items.Add(menu1);
            }
        }

        void XoaHangDangChon(object sender, EventArgs e)
        {
            btnXoa.PerformClick();
        }

        void SuaHangDangChon(object sender, EventArgs e)
        {
            btnSua.PerformClick();
        }

        void ThemKhachHang(object sender, EventArgs e)
        {
            btnThem.PerformClick();
        }
    }
}
