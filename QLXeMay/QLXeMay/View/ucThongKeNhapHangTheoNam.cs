using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLXeMay.Control;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;

namespace QLXeMay.View
{
    public partial class ucThongKeNhapHangTheoNam : UserControl
    {
        public ucThongKeNhapHangTheoNam()
        {
            InitializeComponent();
        }

        ThongKeControl thongkeControl = new ThongKeControl();
        frmMain frm = new frmMain();
        private void ucThongKeNhapHangTheoNam_Load(object sender, EventArgs e)
        {
            lueChonLoaiThongKe.EditValue = lueChonNam.EditValue = string.Empty;
            var list = new List<string>();
            list.Add("Xe máy");
            list.Add("Phụ tùng");
            lueChonLoaiThongKe.Properties.DataSource = list;
            lueChonLoaiThongKe.Text = "Xe máy";

            var list1 = new List<string>();
            for (int i = 2017; i <= 2050; i++)
            {
                list1.Add(i.ToString());
            }
            lueChonNam.Properties.DataSource = list1;
            lueChonNam.Text = DateTime.Now.ToString("yyyy");
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (lueChonLoaiThongKe.Text == "Xe máy")
            {
                gcDanhSachThongKe.DataSource = null;
                gcDanhSachThongKe.DataSource = thongkeControl.thongKeNhapXeTheoNam(Convert.ToInt32(lueChonNam.Text.Trim()));
                gcDanhSachThongKe.MainView.PopulateColumns();
                frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
                ThemTextChoLable();
                groupControl1.Text = string.Format("Danh sách thống kê nhập xe máy năm {0}", lueChonNam.Text.Trim());
            }
            else
            {
                gcDanhSachThongKe.DataSource = null;
                gcDanhSachThongKe.DataSource = thongkeControl.thongKeNhapPhuTungTheoNam(Convert.ToInt32(lueChonNam.Text.Trim()));
                gcDanhSachThongKe.MainView.PopulateColumns();
                frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
                ThemTextChoLable();
                groupControl1.Text = string.Format("Danh sách thống kê nhập phụ tùng năm {0}", lueChonNam.Text.Trim());
            }
        }

        void ThemTextChoLable()
        {

            int soluong = 0;
            long tiennhap = 0;
            if (lueChonLoaiThongKe.Text == "Xe máy" && gvDanhSachThongKe.RowCount > 0)
            {
                var dt = frm.ChuyenGridViewSangDataTable(gvDanhSachThongKe);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    soluong += Convert.ToInt32(dt.Rows[i][3].ToString().Split('.', ',')[0]);
                    tiennhap += Convert.ToInt64(dt.Rows[i][5].ToString().Split('.', ',')[0]);
                }
            }
            else if (lueChonLoaiThongKe.Text == "Phụ tùng" && gvDanhSachThongKe.RowCount > 0)
            {
                var dt = frm.ChuyenGridViewSangDataTable(gvDanhSachThongKe);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    soluong += Convert.ToInt32(dt.Rows[i][4].ToString().Split('.', ',')[0]);
                    tiennhap += Convert.ToInt64(dt.Rows[i][6].ToString().Split('.', ',')[0]);
                }
            }
            else
            {
                lblTienNhap.Text = "Tổng tiền nhập: 0";
                lblSoLuong.Text = "Tổng số lượng: 0";
            }
            lblTienNhap.Text = string.Format("Tổng tiền nhập: {0} VNĐ", frmMain.DoiTien(tiennhap.ToString()));
            lblSoLuong.Text = string.Format("Tổng số lượng: {0}", frmMain.DoiTien(soluong.ToString()));
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (gvDanhSachThongKe.RowCount > 0)
            {
                XtraReport rp = new XtraReport();
                rp.DataSource = frm.ChuyenGridViewSangDataTable(gvDanhSachThongKe);
                //rp.ShowDesignerDialog();
                if (lueChonLoaiThongKe.Text == "Xe máy") rp.LoadLayout(Application.StartupPath + @"\ReportThongKeNhapXeMayTheoNam.repx");
                else rp.LoadLayout(Application.StartupPath + @"\ReportThongKeNhapPhuTungTheoNam.repx");
                //if (textBox1.Text == "1") 
               // rp.ShowDesignerDialog();
                //else rp.ShowPreviewDialog();
                rp.ShowPreviewDialog();

            }
            else XtraMessageBox.Show("Không có dữ liệu để in", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
