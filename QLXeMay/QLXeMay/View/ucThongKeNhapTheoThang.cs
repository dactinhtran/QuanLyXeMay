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
    public partial class ucThongKeNhapTheoThang : UserControl
    {
        public ucThongKeNhapTheoThang()
        {
            InitializeComponent();
        }

        ThongKeControl thongkeControl = new ThongKeControl();
        frmMain frm = new frmMain();
        int kiemTraClick = 0;
        int kiemtra = 0;
        private void ucThongKeNhapTheoThang_Load(object sender, EventArgs e)
        {
            visible(false);
            XoaText();
        }

        private void visible(bool k)
        {
            rdogrChon.Visible = k;
            grcThang.Visible = k;
            grctNam.Visible = k;
            grctDanhSach.Visible = k;
            btnIn.Visible = k;
        }
        private void XoaText()
        {
            lblSoLuong.Text = lblTienNhap.Text = string.Empty;
        }

        private void btnXeMay_Click(object sender, EventArgs e)
        {
            XoaText();
            kiemTraClick = 1;
            visible(true); grcThang.Visible = false; grctNam.Visible = false;
            grctNam.Visible = false; grcThang.Visible = false;
            rdogrChon.SelectedIndex = 0;
            XeThangHienTai();
            ThemTextChoLable();
        }

        private void btnPhuTung_Click(object sender, EventArgs e)
        {
            XoaText();
            kiemTraClick = 2;
            visible(true); grcThang.Visible = false; grctNam.Visible = false;
            grctNam.Visible = false; grcThang.Visible = false;
            rdogrChon.SelectedIndex = 0;
            PhuTungThangHienTai();
            ThemTextChoLable();
        }

        void XeThangHienTai()
        {
            kiemtra = 1;
            gcDanhSachThongKe.DataSource = null;
            gcDanhSachThongKe.DataSource = thongkeControl.thongKeNhapThang(Convert.ToInt32(DateTime.Today.ToShortDateString().Split('/', '-', '.')[1]), Convert.ToInt32(DateTime.Today.ToShortDateString().Split('/', '.', '-')[2]));
            gcDanhSachThongKe.MainView.PopulateColumns();
            ThemTextChoLable();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
            grctDanhSach.Text = "Danh sách thống kê nhập xe máy tháng này";
        }

        void XeThangBatKy()
        {
            kiemtra = 2;
            gcDanhSachThongKe.DataSource = null;
            gcDanhSachThongKe.DataSource = thongkeControl.thongKeNhapThang(Convert.ToInt32(spinEditThang.Text.Trim()), Convert.ToInt32(spinEditNam.Text.Trim()));
            gcDanhSachThongKe.MainView.PopulateColumns();
            ThemTextChoLable();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
            grctDanhSach.Text = string.Format("Danh sách thống kê nhập xe máy tháng {0} năm {1}",spinEditThang.Text.Trim(), spinEditNam.Text.Trim());
        }
        void ThemTextChoLable()
        {
            if (gvDanhSachThongKe.RowCount > 0)
            {
                DataTable dt = frm.ChuyenGridViewSangDataTable(gvDanhSachThongKe);
                ulong tiennhap = 0, soLuong = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (kiemTraClick == 1)
                    {
                        tiennhap += Convert.ToUInt64(dt.Rows[i][5].ToString().Split('.', ',')[0]);
                        soLuong += Convert.ToUInt64(dt.Rows[i][3].ToString().Split('.', ',')[0]);
                    }
                    else
                    {
                        tiennhap += Convert.ToUInt64(dt.Rows[i][6].ToString().Split('.', ',')[0]);
                        soLuong += Convert.ToUInt64(dt.Rows[i][4].ToString().Split('.', ',')[0]);
                    }
                }
                lblTienNhap.Text = string.Format("Tổng tiền nhập: {0} VNĐ", frmMain.DoiTien(tiennhap.ToString()));
                lblSoLuong.Text = string.Format("Tổng số lượng: {0}", frmMain.DoiTien(soLuong.ToString()));
            }
            else
            {
                lblTienNhap.Text = "Tổng tiền nhập: 0";
                lblSoLuong.Text = "Tổng số lượng: 0";
            }
        }

        private void rdogrChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            XoaText();
            if (kiemTraClick == 1)
            {
                if (rdogrChon.SelectedIndex == 0)
                {
                    XeThangHienTai();
                    grctNam.Visible = false;
                    grcThang.Visible = false;

                }
                else
                {
                    grcThang.Visible = true; grctNam.Visible = true;
                    gcDanhSachThongKe.DataSource = null;
                    gcDanhSachThongKe.DataSource = null;
                    gcDanhSachThongKe.MainView.PopulateColumns();
                }
            }
            else if (kiemTraClick == 2) 
            {
                if (rdogrChon.SelectedIndex == 0)
                {
                    PhuTungThangHienTai();
                    grcThang.Visible = grctNam.Visible = false;
                }
                else {
                    grctNam.Visible = grcThang.Visible = true;
                    gcDanhSachThongKe.DataSource = null;
                    gcDanhSachThongKe.DataSource = null;
                    gcDanhSachThongKe.MainView.PopulateColumns();
                }
            }

        }

        void PhuTungThangHienTai()
        {
            kiemtra = 3;
            gcDanhSachThongKe.DataSource = null;
            gcDanhSachThongKe.DataSource = thongkeControl.thongKeNhapPhuTungThang(Convert.ToInt32(DateTime.Today.ToShortDateString().Split('/', '-', '.')[1]), Convert.ToInt32(DateTime.Today.ToShortDateString().Split('/', '-', '.')[2]));
            gcDanhSachThongKe.MainView.PopulateColumns();
            ThemTextChoLable();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
            grctDanhSach.Text = "Danh sách thống kê nhập phụ tùng tháng này";
        }

        void PhuTungThangBatKy()
        {
            kiemtra = 4;
            gcDanhSachThongKe.DataSource = null;
            gcDanhSachThongKe.DataSource = thongkeControl.thongKeNhapPhuTungThang(Convert.ToInt32(spinEditThang.Text.Trim()), Convert.ToInt32(spinEditNam.Text.Trim()));
            gcDanhSachThongKe.MainView.PopulateColumns();
            ThemTextChoLable();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
            grctDanhSach.Text = string.Format("Danh sách thống kê nhập phụ tùng tháng {0} năm {1}", spinEditThang.Text.Trim(), spinEditNam.Text.Trim());
        }

        private void spinEditThang_EditValueChanged(object sender, EventArgs e)
        {
            if (kiemTraClick == 1) XeThangBatKy();
            else PhuTungThangBatKy();
        }

        private void spinEditNam_EditValueChanged(object sender, EventArgs e)
        {
            if (kiemTraClick == 1) XeThangBatKy();
            else PhuTungThangBatKy();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (gvDanhSachThongKe.RowCount > 0)
            {
                XtraReport rp = new XtraReport();
                rp.DataSource = frm.ChuyenGridViewSangDataTable(gvDanhSachThongKe);
                //rp.ShowDesignerDialog();
                if (kiemtra == 1) rp.LoadLayout(Application.StartupPath + @"\ReportThongKeNhapXeMayThangHienTai.repx");
                else if (kiemtra == 2) rp.LoadLayout(Application.StartupPath + @"\ReportThongKeNhapXeMayThangBatKy.repx");
                else if (kiemtra == 3) rp.LoadLayout(Application.StartupPath + @"\ReportThongKeNhapPhuTungThangHienTai.repx");
                else if (kiemtra == 4) rp.LoadLayout(Application.StartupPath + @"\ReportThongKeNhapPhuTungThangBatKy.repx");
                //if (textBox1.Text == "1") rp.ShowDesignerDialog();
                //else rp.ShowPreviewDialog();
                rp.ShowPreviewDialog();

            }
            else XtraMessageBox.Show("Không có dữ liệu để in", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
