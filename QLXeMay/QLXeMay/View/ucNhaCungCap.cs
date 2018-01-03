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
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;

namespace QLXeMay.View
{
    public partial class ucNhaCungCap : UserControl
    {
        public ucNhaCungCap()
        {
            InitializeComponent();
           
        }

        NhaCungCapControl nccControl = new NhaCungCapControl();

        private void ucNhaCungCap_Load(object sender, EventArgs e)
        {
            gcDanhSachNhaCungCap.DataSource = nccControl.getAllData();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frm = new frmNhaCungCap();
            frm.flag = true;
            frm.ShowDialog();
            ucNhaCungCap_Load(sender, e);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int hangDangChon = gvDanhSachNhaCungCap.FocusedRowHandle;
            var value1 = gvDanhSachNhaCungCap.GetRowCellValue(hangDangChon, "MANHACC");
            if (value1 != null)
            {
                var value2 = gvDanhSachNhaCungCap.GetRowCellValue(hangDangChon, "TENNHACC");
                var value3 = gvDanhSachNhaCungCap.GetRowCellValue(hangDangChon, "DIACHI");
                var value4 = gvDanhSachNhaCungCap.GetRowCellValue(hangDangChon, "DIENTHOAI");
                var value5 = gvDanhSachNhaCungCap.GetRowCellValue(hangDangChon, "EMAIL");

                frmNhaCungCap frm = new frmNhaCungCap();
                frm.flag = false;
                frm.maNCC = value1 as string;
                frm.tenNCC = value2 as string;
                frm.diaChi = value3 as string;
                frm.sdt = value4 as string;
                frm.email = value5 as string;

                frm.ShowDialog();
                ucNhaCungCap_Load(sender, e);
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
                int HangDangChon = gvDanhSachNhaCungCap.FocusedRowHandle;
                object value = gvDanhSachNhaCungCap.GetRowCellValue(HangDangChon, "MANHACC");
                if (value != null)
                {
                    string ma = value.ToString().Trim();
                    if (nccControl.deleteData(ma))
                    {
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ucNhaCungCap_Load(sender, e);
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
        private void gvDanhSachNhaCungCap_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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
