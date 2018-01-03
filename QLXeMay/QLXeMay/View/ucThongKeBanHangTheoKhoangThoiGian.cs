using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLXeMay.Control;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace QLXeMay.View
{
    public partial class ucThongKeBanHangTheoKhoangThoiGian : UserControl
    {
        ThongKeControl thongkeControl = new ThongKeControl();
        frmMain frm = new frmMain();
        public ucThongKeBanHangTheoKhoangThoiGian()
        {
            InitializeComponent();
        }

        private void ucThongKeBanHangTheoKhoangThoiGian_Load(object sender, EventArgs e)
        {
            lueChonLoaiThongKe.EditValue = string.Empty;
            dateTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dateDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            var list = new List<string>();
            list.Add("Xe máy");
            list.Add("Phụ tùng");
            lueChonLoaiThongKe.Properties.DataSource = list;
            lueChonLoaiThongKe.Text = "Xe máy";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (lueChonLoaiThongKe.Text == "Xe máy")
            {
                gcDanhSachThongKe.DataSource = null;
                gcDanhSachThongKe.DataSource = thongkeControl.thongKeBanXeTheoKhoangThoiGian(dateTuNgay.Text.Trim().Split('.', ':', ' ')[0], dateDenNgay.Text.Trim().Split('.', ':', ' ')[0]);
                gcDanhSachThongKe.MainView.PopulateColumns();
                frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
                ThemTextChoLable();
                groupControl1.Text = string.Format("Danh sách thống kê bán xe máy từ ngày {0} đến ngày {1}", dateTuNgay.Text.Trim().Split('.', ':', ' ')[0], dateDenNgay.Text.Trim().Split('.', ':', ' ')[0]);
            }
            else
            {
                gcDanhSachThongKe.DataSource = null;
                gcDanhSachThongKe.DataSource = thongkeControl.thongKeBanPhuTungTheoKhoangThoiGian(dateTuNgay.Text.Trim().Split('.', ':', ' ')[0], dateDenNgay.Text.Trim().Split('.', ':', ' ')[0]);
                gcDanhSachThongKe.MainView.PopulateColumns();
                frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
                ThemTextChoLable();
                groupControl1.Text = string.Format("Danh sách thống kê bán phụ tùng từ ngày {0} đến ngày {1}", dateTuNgay.Text.Trim().Split('.', ':', ' ')[0], dateDenNgay.Text.Trim().Split('.', ':', ' ')[0]);
            }
           
        }


        void ThemTextChoLable()
        {
            var soluong = 0;
            long tienban = 0, tiennhap = 0, tienlai = 0;
            if (lueChonLoaiThongKe.Text == "Xe máy" && gvDanhSachThongKe.RowCount > 0)
            {
                var dt = frm.ChuyenGridViewSangDataTable(gvDanhSachThongKe);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    soluong += Convert.ToInt32(dt.Rows[i][4].ToString().Split('.', ',')[0]);
                    tienban += Convert.ToInt64(dt.Rows[i][5].ToString().Split('.', ',')[0]);
                    tiennhap += Convert.ToInt64(dt.Rows[i][6].ToString().Split('.', ',')[0]);
                    tienlai += Convert.ToInt64(dt.Rows[i][7].ToString().Split('.', ',')[0]);
                }
            }
            else if (lueChonLoaiThongKe.Text == "Phụ tùng" && gvDanhSachThongKe.RowCount > 0)
            {
                var dt = frm.ChuyenGridViewSangDataTable(gvDanhSachThongKe);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    soluong += Convert.ToInt32(dt.Rows[i][3].ToString().Split('.', ',')[0]);
                    tienban += Convert.ToInt64(dt.Rows[i][7].ToString().Split('.', ',')[0]);
                    tiennhap += Convert.ToInt64(dt.Rows[i][4].ToString().Split('.', ',')[0]);
                    tienlai += Convert.ToInt64(dt.Rows[i][8].ToString().Split('.', ',')[0]);
                }
            }
            else
            {
                lblTienNhap.Text = "Tổng tiền nhập: 0";
                lblTienBan.Text = "Tổng tiền bán: 0";
                lblTienLai.Text = "Tổng tiền lãi: 0";
                lblSoLuong.Text = "Tổng số lượng: 0";
            }
            lblTienNhap.Text = string.Format("Tổng tiền nhập: {0} VNĐ", frmMain.DoiTien(tiennhap.ToString()));
            lblSoLuong.Text = string.Format("Tổng số lượng: {0}", frmMain.DoiTien(soluong.ToString()));
            lblTienBan.Text = string.Format("Tổng tiền bán: {0} VNĐ", frmMain.DoiTien(tienban.ToString()));
            lblTienLai.Text = string.Format("Tổng tiền lãi: {0} VNĐ", frmMain.DoiTien(tienlai.ToString()));
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (gvDanhSachThongKe.RowCount > 0)
            {
                XtraReport rp = new XtraReport();
                rp.DataSource = frm.ChuyenGridViewSangDataTable(gvDanhSachThongKe);
                if (lueChonLoaiThongKe.Text == "Xe máy") rp.LoadLayout(Application.StartupPath + @"\ReportThongKeBanXeMayTheoKhoangThoiGian.repx");
                else rp.LoadLayout(Application.StartupPath + @"\ReportThongKeBanPhuTungTheoKhoangThoiGian.repx");
                ////if (textBox1.Text == "1") 
                //rp.ShowDesignerDialog();
                ////else rp.ShowPreviewDialog();
                rp.ShowPreviewDialog();

            }
            else XtraMessageBox.Show("Không có dữ liệu để in", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
