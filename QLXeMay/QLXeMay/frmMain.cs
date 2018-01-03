using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using QLXeMay.View;
using QLXeMay.Control;

namespace QLXeMay
{
    public partial class frmMain : RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            InitSkinGallery();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            timer.Start();

            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Xmas 2008 Blue");
            this.StartPosition = FormStartPosition.CenterScreen;
            xtraTabMain.TabPages[0].Text = "Trang chủ";

            barbtnThemTaiKhoanDangNhap.Enabled = false;
            barbtnSuaTaiKhoanDangNhap.Enabled = false;
            barbtnKhachHang.Enabled = false;
            barbtnNhanVien.Enabled = false;
            barbtnNhaCungCap.Enabled = false;
            barbtnXeMay.Enabled = false;
            barbtnPhuTung.Enabled = false;
            barbtnNhapXe.Enabled = false; NavBarNhapXe.Enabled = false;
            barbtnNhapPT.Enabled = false; NavBarNhapPhuTung.Enabled = false;
            NavBarBanXeMay.Enabled = false; barbtnBanXeMay.Enabled = false;
            NavBarBanPhuTung.Enabled = false; barbtnBanPhuTung.Enabled = false;
            barbtnBaoHanhXeMay.Enabled = false;
            barbtnThongKeXeMayHomNay.Enabled = false;
            barbtnThongKeHangNhapThang.Enabled = false;
            barbtnThongKeBanHangThang.Enabled = false;
            barbtnThongKeNhapHangNam.Enabled = false;
            barbtnThongKeBanHangNam.Enabled = false;
            barbtnThongKeNhapHangKhoangThoiGian.Enabled = false;
            barbtnThongKeBanHangKhoangThoiGian.Enabled = false;


            var arr = frmDangNhap.QuyenTruyCap.Split('-').ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                switch (Convert.ToInt32(arr[i]))
                {
                    case 1: barbtnThemTaiKhoanDangNhap.Enabled = true; break;
                    case 2: barbtnSuaTaiKhoanDangNhap.Enabled = true; break;
                    case 3: barbtnKhachHang.Enabled = true; break;
                    case 4: barbtnNhanVien.Enabled = true; break;
                    case 5: barbtnNhaCungCap.Enabled = true; break;
                    case 6: barbtnXeMay.Enabled = true; break;
                    case 7: barbtnPhuTung.Enabled = true; break;
                    case 8: barbtnNhapXe.Enabled = true; NavBarNhapXe.Enabled = true; break;
                    case 9: barbtnNhapPT.Enabled = true; NavBarNhapPhuTung.Enabled = true; break;
                    case 10: NavBarBanXeMay.Enabled = true; barbtnBanXeMay.Enabled = true; break;
                    case 11: NavBarBanPhuTung.Enabled = true; barbtnBanPhuTung.Enabled = true; break;
                    case 12: barbtnBaoHanhXeMay.Enabled = true; break;
                    case 13: barbtnThongKeXeMayHomNay.Enabled = true; break;
                    case 14: barbtnThongKeHangNhapThang.Enabled = true; break;
                    case 15: barbtnThongKeBanHangThang.Enabled = true; break;
                    case 16: barbtnThongKeNhapHangNam.Enabled = true; break;
                    case 17: barbtnThongKeBanHangNam.Enabled = true; break;
                    case 18: barbtnThongKeNhapHangKhoangThoiGian.Enabled = true; break;
                    case 19: barbtnThongKeBanHangKhoangThoiGian.Enabled = true; break;

                }
            }
        }

        NhanVienControl nvControl = new NhanVienControl();
        int x = 0; bool b = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            lblTenNV.Text = "Xin chào " + nvControl.getTenNV(frmDangNhap.MaNhanVien);
            x++;
            if (x == 5)
            {
                timer.Stop();
                if (!b)
                {
                    lblNgay.Text = DateTime.Now.ToString("HH:mm:ss");
                    b = true;
                }
                else { b = false; lblNgay.Text = DateTime.Now.ToShortDateString(); }
                lblNgay.ForeColor = Color.FromArgb(rd.Next(0, 256), rd.Next(0, 256), rd.Next(0, 256));
                lblTenNV.ForeColor = Color.FromArgb(rd.Next(0, 256), rd.Next(0, 256), rd.Next(0, 256));
                timer.Start();
                x = 0;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult m = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không ", "Thông báo", MessageBoxButtons.YesNo);
            if (m == DialogResult.Yes) Application.Exit();
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
            var frm = new frmDangNhap();
            frm.Show();
        }

        //Chuyển GridView sang DataTable
        public DataTable ChuyenGridViewSangDataTable(DevExpress.XtraGrid.Views.Grid.GridView gridview)
        {
            DataTable dt = new DataTable();
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridview.VisibleColumns)
            {
                dt.Columns.Add(column.FieldName, column.ColumnType);
            }
            for (int i = 0; i < gridview.DataRowCount; i++)
            {
                DataRow row = dt.NewRow();
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridview.VisibleColumns)
                {
                    row[column.FieldName] = gridview.GetRowCellValue(i, column);
                }
                dt.Rows.Add(row);
            }
            //MessageBox.Show(dt.Rows.Count.ToString());
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    MessageBox.Show(dt.Rows[i][0].ToString());
            //}
            return dt;
        }

        public static bool KiemTraTen_MatKhau(string s)
        {
            var list = new List<char>();
            for (char i = 'a'; i <= 'z'; i++) list.Add(i);
            for (char i = 'A'; i <= 'A'; i++) list.Add(i);
            for (char i = '0'; i <= '9'; i++) list.Add(i);
            //list.Add('_');
            for (int i = 0; i < s.Length; i++)
            {
                if (!list.Contains(s[i])) return false;
            }
            return true;
        }

        private static string ThayTheChuoi(string s)
        {
            return s.Replace("MABH", "Mã bảo hành")
                .Replace("THOIGIANBH", "Thời gian BH")
                .Replace("MAKH", "Mã khách hàng")
                .Replace("MAXE", "Mã xe máy")
                .Replace("MACTBH", "Mã chi tiết bảo hành")
                .Replace("MABH", "Mã bảo hành")
                .Replace("MANV", "Mã nhân viên")
                .Replace("CONGVIEC", "Công việc BH")
                .Replace("SOKM", "Số KM")
                .Replace("MACTN", "Mã chi tiết nhập")
                .Replace("MANHAP", "Mã nhập")
                .Replace("DONGIANHAP", "Đơn giá nhập")
                .Replace("SOLUONG", "Số lượng")
                .Replace("DONVITINH", "Đơn vị tính")
                .Replace("MACTNPT", "Mã chi tiết nhập PT")
                .Replace("MANPT", "Mã nhập PT")
                .Replace("MADN", "Mã đăng nhập")
                .Replace("TENDN", "Tên đăng nhập")
                .Replace("MATKHAU", "Mật khẩu")
                .Replace("QUYENTC", "Quyền truy cập")
                .Replace("MAPT", "Mã phụ tùng")
                .Replace("MAHDBAN", "Mã HĐ bán xe")
                .Replace("NGAYBAN", "Ngày bán")
                .Replace("THUEVAT", "Thuế VAT")
                .Replace("MAHDBANPT", "Mã HĐ bán PT")
                .Replace("TENKH", "Tên khách hàng")
                .Replace("NGAYSINH", "Ngày sinh")
                .Replace("GIOITINH", "Giới tính")
                .Replace("SOCMND", "Số CMND")
                .Replace("DIACHI", "Địa chỉ")
                .Replace("SDT", "Số điện thoại")
                .Replace("MANHACC", "Mã nhà cung cấp")
                .Replace("TENNHACC", "Tên nhà cung cấp")
                .Replace("DIENTHOAI", "Số điện thoại")
                .Replace("EMAIL", "Email")
                .Replace("TENNV", "Tên nhân viên")
                .Replace("LUONGCOBAN", "Lương")
                .Replace("CHUCVU", "Chức vụ")
                .Replace("NGAYNHAP", "Ngày nhập")
                .Replace("MATTPT", "Mã TT phụ tùng")
                .Replace("LOAIPT", "Loại phụ tùng")
                .Replace("TENPT", "Tên phụ tùng")
                .Replace("MATTXE", "Mã TT xe")
                .Replace("TENXE", "Tên xe")
                .Replace("MAUXE", "Màu xe")
                .Replace("DUNGTICH", "Dung tích")
                .Replace("SOKHUNG", "Số khung")
                .Replace("SOMAY", "Số máy")
                .Replace("DONGIABAN", "Đơn giá bán")
                .Replace("NAMSANXUAT", "Năm sản xuất")
                .Replace("THANHTIEN", "Thành tiền")
                .Replace("HANGXE", "Hãng xe")
                .Replace("TIENNHAP", "Tiền nhập")
                .Replace("TIENBAN", "Tiền bán")
                .Replace("TIENLAI", "Tiền lãi")
                .Replace("NAM", "Năm")
                .Replace("THANG", "Tháng");
        }

        public static string DoiTien(string s)
        {
            int i = s.Length - 1;
            int dem = 0;
            while (i > 0)
            {
                dem++;
                if (dem == 3)
                {
                    s = s.Insert(i, ",");
                    dem = 0;
                }
                i--;
            }
            return s;
        }

        public static void DatLaiTenCotCuaGridView(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                gv.Columns[i].Caption = ThayTheChuoi(gv.Columns[i].FieldName);
            }
        }

        public string MaSoTuTang(string chuoiMaCoDinh, DataTable dt)
        {
            var hashset = new HashSet<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                hashset.Add(Convert.ToInt32(dt.Rows[i][0].ToString().Remove(0, chuoiMaCoDinh.Length)));
            }

            for (int i = 0; i < hashset.Count; i++)
            {
                if (!hashset.Contains(i + 1)) return i + 1 < 10 ? string.Format("{0}00{1}", chuoiMaCoDinh, ++i) : i + 1 < 100 ? string.Format("{0}0{1}", chuoiMaCoDinh, ++i) : chuoiMaCoDinh + ++i;
            }
            return hashset.Count + 1 < 10 ? string.Format("{0}00{1}", chuoiMaCoDinh, (hashset.Count + 1)) : hashset.Count + 1 < 100 ? string.Format("{0}0{1}", chuoiMaCoDinh, (hashset.Count + 1)) : chuoiMaCoDinh + (hashset.Count + 1);
        }



        public void xtraTabMain_CloseButtonClick(object sender, EventArgs e)
        {
            int a = xtraTabMain.SelectedTabPageIndex;
            if (a == xtraTabMain.TabPages.Count - 1 && a != 0)
            {
                xtraTabMain.TabPages.Remove(xtraTabMain.SelectedTabPage);
                xtraTabMain.SelectedTabPageIndex = a - 1;
            }
            else if (a > 0 && a < xtraTabMain.TabPages.Count - 1)
            {
                xtraTabMain.TabPages.Remove(xtraTabMain.SelectedTabPage);
                xtraTabMain.SelectedTabPageIndex = a;
            }

        }

        //Sắp xếp theo thứ tự tăng/giảm dần gridview
        public static void SapXepLaiGridView(DevExpress.XtraGrid.Views.Grid.GridView gv, string tenCotCanSapXep, bool Tang_True_Giam_False)
        {
            gv.BeginSort();

            try
            {
                gv.ClearSorting();
                if (Tang_True_Giam_False) gv.Columns[tenCotCanSapXep].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                else gv.Columns[tenCotCanSapXep].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            }

            finally
            {
                gv.EndSort();
            }
        }

        private void btnTrangChu_ItemClick(object sender, ItemClickEventArgs e)
        {
            xtraTabMain.SelectedTabPageIndex = 0;
        }


        //RIBBON
        private void barbtnKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Khách hàng", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucKhachHang uc = new ucKhachHang();
                uc.Dock = DockStyle.Fill;

                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Khách hàng";
                tp.Controls.Add(uc);

                xtraTabMain.TabPages.Add(tp);

                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Nhân viên", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucNhanVien uc = new ucNhanVien();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Nhân viên";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnNhaCungCap_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Nhà cung cấp", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucNhaCungCap uc = new ucNhaCungCap();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Nhà cung cấp";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnXeMay_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Xe máy", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucXe uc = new ucXe();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Xe máy";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }


        private void barbtnPhuTung_ItemClick(object sender, ItemClickEventArgs e)
        {

            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Phụ tùng", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucPhuTung uc = new ucPhuTung();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Phụ tùng";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnNhapPT_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Nhập phụ tùng", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucNhapPhuTungNavBar uc = new ucNhapPhuTungNavBar();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Nhập phụ tùng";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnNhapXe_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Nhập xe máy", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucNhapXeNavBar uc = new ucNhapXeNavBar();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Nhập xe máy";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnBanPT_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Bán phụ tùng", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucHoaDonBanPhuTung uc = new ucHoaDonBanPhuTung();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Bán phụ tùng";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnBanXeMay_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Bán xe máy", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucHoaDonBanXeMay uc = new ucHoaDonBanXeMay();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Bán xe máy";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;

        }


        //NAVBAR

        private void NavBarTimKiemNhanVien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Tìm kiếm Nhân viên", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucTimKiemNhanVien uc = new ucTimKiemNhanVien();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Tìm kiếm Nhân viên";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void NavBarTimKiemKhachHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Tìm kiếm Khách hàng", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucTimKiemKhachHang uc = new ucTimKiemKhachHang();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Tìm kiếm Khách hàng";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void NavBarTimKiemXeMay_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Tìm kiếm Xe máy", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucTimKiemXeMay uc = new ucTimKiemXeMay();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Tìm kiếm Xe máy";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void NavBarTimKiemPhuTung_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Tìm kiếm Phụ tùng", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucTimKiemPhuTung uc = new ucTimKiemPhuTung();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Tìm kiếm Phụ tùng";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void NavBarDanhMucNhanVien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Danh sách nhân viên", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucDanhSachNhanVien uc = new ucDanhSachNhanVien();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Danh sách nhân viên";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void NavBarNhapXe_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Nhập xe máy", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucNhapXeNavBar uc = new ucNhapXeNavBar();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Nhập xe máy";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void NavBarDanhMucNhaCungCap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Danh sách nhà cung cấp", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucDanhSachNhaCungCap uc = new ucDanhSachNhaCungCap();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Danh sách nhà cung cấp";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void NavBarDanhSachXeCoTrongCuaHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Danh sách xe có trong cửa hàng", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucDanhSachXeCoTrongCuaHang uc = new ucDanhSachXeCoTrongCuaHang();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Danh sách xe có trong cửa hàng";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void NavBarDanhSachPhuTungCoTrongCuaHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Danh sách phụ tùng có trong cửa hàng", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucDanhSachPhuTungCoTrongCuaHang uc = new ucDanhSachPhuTungCoTrongCuaHang();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Danh sách phụ tùng có trong cửa hàng";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void NavBarNhapPhuTung_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Nhập phụ tùng", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucNhapPhuTungNavBar uc = new ucNhapPhuTungNavBar();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Nhập phụ tùng";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnBaoHanhXeMay_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Bảo hành xe máy", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucBaoHanhXeMay uc = new ucBaoHanhXeMay();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Bảo hành xe máy";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void NavBarBanXeMay_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Bán xe máy", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucHoaDonBanXeMay uc = new ucHoaDonBanXeMay();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Bán xe máy";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void NavBarBanPhuTung_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Bán phụ tùng", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucHoaDonBanPhuTung uc = new ucHoaDonBanPhuTung();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Bán phụ tùng";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnThongKeHomNay_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Thống kê theo ngày", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucThongKeTheoNgay uc = new ucThongKeTheoNgay();
                uc.Dock = DockStyle.Fill;

                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Thống kê theo ngày";
                tp.Controls.Add(uc);

                xtraTabMain.TabPages.Add(tp);

                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;

        }

        private void barbtnThongKeHangNhapThang_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Thống kê nhập theo tháng", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucThongKeNhapTheoThang uc = new ucThongKeNhapTheoThang();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Thống kê nhập theo tháng";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnThongKeBanHangThang_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Thống kê bán theo tháng", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucThongKeBanTheoThang uc = new ucThongKeBanTheoThang();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Thống kê bán theo tháng";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnThongKeNhapHangNam_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Thống kê nhập theo năm", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucThongKeNhapHangTheoNam uc = new ucThongKeNhapHangTheoNam();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Thống kê nhập theo năm";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnThongKeBanHangNam_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Thống kê bán theo năm", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucThongKeBanHangTheoNam uc = new ucThongKeBanHangTheoNam();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Thống kê bán theo năm";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

     
        private void barbtnThongKeNhapHangKhoangThoiGian_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Thống kê nhập theo khoảng thời gian", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucThongKeNhapTheoKhoangThoiGian uc = new ucThongKeNhapTheoKhoangThoiGian();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Thống kê nhập theo khoảng thời gian";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnThongKeBanHangKhoangThoiGian_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Thống kê bán theo khoảng thời gian", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucThongKeBanHangTheoKhoangThoiGian uc = new ucThongKeBanHangTheoKhoangThoiGian();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Thống kê bán theo khoảng thời gian";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnThongTinPhanMem_ItemClick(object sender, ItemClickEventArgs e)
        {
            //AboutBoxThongTinPhanMem ab = new AboutBoxThongTinPhanMem();
            //ab.ShowDialog();
            frmThongTinPhanMem frm = new frmThongTinPhanMem();
            frm.ShowDialog();
        }

        private void barbtnThemTaiKhoanDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tabindex = 0;
            for (int i = 0; i < xtraTabMain.TabPages.Count; i++)
            {
                if (String.Compare("Thêm tài khoản", xtraTabMain.TabPages[i].Text.Trim()) == 0)
                {
                    tabindex = i;
                    break;
                }
            }

            if (tabindex == 0)
            {
                ucThemTaiKhoanDangNhap uc = new ucThemTaiKhoanDangNhap();
                uc.Dock = DockStyle.Fill;
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Text = "Thêm tài khoản";
                tp.Controls.Add(uc);
                xtraTabMain.TabPages.Add(tp);
                xtraTabMain.SelectedTabPageIndex = xtraTabMain.TabPages.Count - 1;
            }
            else xtraTabMain.SelectedTabPageIndex = tabindex;
        }

        private void barbtnSuaTaiKhoanDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThayDoiThongTinDangNhap frm = new frmThayDoiThongTinDangNhap();
            frm.ShowDialog();
        }

        private void barbtnHuongDanSD_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmHuongDanSuDung frm = new frmHuongDanSuDung();
            frm.Show();
        }








    }
}