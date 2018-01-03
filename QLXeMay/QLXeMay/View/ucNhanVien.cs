using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QLXeMay.Control;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;

namespace QLXeMay.View
{
    public partial class ucNhanVien : UserControl
    {
        public ucNhanVien()
        {
            InitializeComponent();
        }

        NhanVienControl nvControl = new NhanVienControl();
        
        private void ucNhanVien_Load(object sender, EventArgs e)
        {
            gcDanhSachNhanVien.DataSource = nvControl.getAllData();
        }

        private void gvDanhSachNhanVien_RowCountChanged(object sender, EventArgs e)
        {
            lblTong.Text = "Tổng nhân viên: " + gvDanhSachNhanVien.RowCount;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.flag = true;
            frm.ShowDialog();
            ucNhanVien_Load(sender, e);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int hangDangChon = gvDanhSachNhanVien.FocusedRowHandle;
            var value1 = gvDanhSachNhanVien.GetRowCellValue(hangDangChon, "MANV");

            if (value1 != null)
            {
                var value2 = gvDanhSachNhanVien.GetRowCellValue(hangDangChon, "TENNV");
                var value3 = gvDanhSachNhanVien.GetRowCellValue(hangDangChon, "NGAYSINH");
                var value4 = gvDanhSachNhanVien.GetRowCellValue(hangDangChon, "GIOITINH");
                var value5 = gvDanhSachNhanVien.GetRowCellValue(hangDangChon, "SOCMND");
                var value6 = gvDanhSachNhanVien.GetRowCellValue(hangDangChon, "LUONGCOBAN");
                var value7 = gvDanhSachNhanVien.GetRowCellValue(hangDangChon, "CHUCVU");
                var value8 = gvDanhSachNhanVien.GetRowCellValue(hangDangChon, "DIACHI");
                var value9 = gvDanhSachNhanVien.GetRowCellValue(hangDangChon, "SDT");

                frmNhanVien frm = new frmNhanVien();
                frm.flag = false;
                frm.maNV = value1 as string;
                frm.tenNV = value2 as string;
                frm.ngaySinh = (DateTime)value3;
                frm.gioiTinh = value4 as string;
                frm.soCMND = value5 as string;
                frm.luongcoban = (int)value6;
                frm.chucVu = value7 as string;
                frm.diaChi = value8 as string;
                frm.sdt = value9 as string;

                frm.ShowDialog();
                ucNhanVien_Load(sender, e);
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn đối tượng cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa dòng dữ liệu đã chọn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int HangDangChon = gvDanhSachNhanVien.FocusedRowHandle;
                object value = gvDanhSachNhanVien.GetRowCellValue(HangDangChon, "MANV");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (nvControl.deleteData(ma))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ucNhanVien_Load(sender, e);
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
        private void gvDanhSachNhanVien_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                hang = e.HitInfo.RowHandle;
                e.Menu.Items.Clear();

                DXMenuItem menu2 = new DXMenuItem("Thêm nhân viên mới", new EventHandler(ThemKhachHang));
                e.Menu.Items.Add(menu2);

                DXMenuItem menu = new DXMenuItem("Xóa thông tin nhân viên", new EventHandler(XoaHangDangChon));
                e.Menu.Items.Add(menu);

                DXMenuItem menu1 = new DXMenuItem("Sửa thông tin nhân viên", new EventHandler(SuaHangDangChon));
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
