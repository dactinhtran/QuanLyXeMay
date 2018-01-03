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
    public partial class ucThongKeBanTheoThang : UserControl
    {
        public ucThongKeBanTheoThang()
        {
            InitializeComponent();
        }

        frmMain frm = new frmMain();
        ThongKeControl thongkeControl = new ThongKeControl();

        private void ucThongKeBanTheoThang_Load(object sender, EventArgs e)
        {
            lueLoaiThongKe.EditValue = string.Empty;
            var list = new List<string>();
            list.Add("Xe máy");
            list.Add("Phụ tùng");
            lueLoaiThongKe.Properties.DataSource = list;
            lueLoaiThongKe.Text = "Xe máy";

            spedThang.Text = DateTime.Today.ToShortDateString().Split('/', '.', '-')[1];
            cboNam.Text = DateTime.Today.ToShortDateString().Split('/', '.', '-')[2];
            cboNam.Properties.Items.Clear();
            for (int i = 2017; i <= 2050; i++)
            {
                cboNam.Properties.Items.Add(i);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (lueLoaiThongKe.Text == "Xe máy")
            {
                gcDanhSachThongKe.DataSource = null;
                gcDanhSachThongKe.DataSource = thongkeControl.thongKeBanXeTheoThang(spedThang.Text.Trim(), cboNam.Text.Trim());
                gcDanhSachThongKe.MainView.PopulateColumns();
                frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
                ThemTextChoLable();
                groupControl1.Text = string.Format("Danh sách thống kê xe máy tháng {0} năm {1}", spedThang.Text.Trim(), cboNam.Text.Trim());
            }
            else
            {
                gcDanhSachThongKe.DataSource = null;
                gcDanhSachThongKe.DataSource = thongkeControl.thongKeBanPhuTungTheoThang(spedThang.Text.Trim(), cboNam.Text.Trim());
                gcDanhSachThongKe.MainView.PopulateColumns();
                frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
                ThemTextChoLable();
                groupControl1.Text = string.Format("Danh sách thống kê phụ tùng tháng {0} năm {1}", spedThang.Text.Trim(), cboNam.Text.Trim());
            }
        }

        void ThemTextChoLable()
        {
            int soluong = 0;
            long tienban = 0, tiennhap = 0, tienlai = 0;
            if (lueLoaiThongKe.Text == "Xe máy" && gvDanhSachThongKe.RowCount > 0)
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
            else if (lueLoaiThongKe.Text == "Phụ tùng" && gvDanhSachThongKe.RowCount > 0)
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
                //rp.ShowDesignerDialog();
                if (lueLoaiThongKe.Text == "Xe máy") rp.LoadLayout(Application.StartupPath + @"\ReportThongKeBanXeMayThang.repx");
                else rp.LoadLayout(Application.StartupPath + @"\ReportThongKeBanPhuTungTheoThang.repx");
                //if (textBox1.Text == "1") 
                //rp.ShowDesignerDialog();
                //else rp.ShowPreviewDialog();
                rp.ShowPreviewDialog();

            }
            else XtraMessageBox.Show("Không có dữ liệu để in", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
