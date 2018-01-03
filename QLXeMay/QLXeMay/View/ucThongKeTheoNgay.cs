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
    public partial class ucThongKeTheoNgay : UserControl
    {
        public ucThongKeTheoNgay()
        {
            InitializeComponent();
        }

        ThongKeControl thongkeControl = new ThongKeControl();
        frmMain frm = new frmMain();
        int kiemTra = 0, kiemTraClick = 0;
        private void ucThongKeTheoNgay_Load(object sender, EventArgs e)
        {
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            panelControl1.Visible = false;
            panelControl2.Visible = false;
        }

        private void btnXeMay_Click(object sender, EventArgs e)
        {
            kiemTraClick = 1;
            panelControl1.Visible = true;
            panelControl2.Visible = true;
            splitContainerControl1.Panel2.Enabled = false;
            splitContainerControl1.Panel1.Enabled = true;
            grcPT.Visible = false;
            grcXeMay.Visible = false;
            XeMayHomNay();
            rdogrXeMay.SelectedIndex = 0;
        }

        private void btnPhuTung_Click(object sender, EventArgs e)
        {
            kiemTraClick = 2;
            panelControl1.Visible = true;
            panelControl2.Visible = true;
            splitContainerControl1.Panel1.Enabled = false;
            splitContainerControl1.Panel2.Enabled = true;
            grcPT.Visible = false;
            grcXeMay.Visible = false;
            PhuTungHomNay();
            rdogrPT.SelectedIndex = 0;
        }

        private void rdogrXeMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteTextLabel();
            if (rdogrXeMay.SelectedIndex == 0)
            {
                XeMayHomNay();
                grcXeMay.Visible = false;

            }
            else
            {
                grcXeMay.Visible = true;
                gcDanhSachThongKe.DataSource = null;
                gcDanhSachThongKe.DataSource = null;
                gcDanhSachThongKe.MainView.PopulateColumns();
            }
        }

        private void dateXe_EditValueChanged(object sender, EventArgs e)
        {
            XeMayNgayBatKy();
        }

        private void rdogrPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteTextLabel();
            if (rdogrPT.SelectedIndex == 0)
            {
                PhuTungHomNay();
                grcPT.Visible = false;
            }
            else
            {
                grcPT.Visible = true;
                gcDanhSachThongKe.DataSource = null;
                gcDanhSachThongKe.DataSource = null;
                gcDanhSachThongKe.MainView.PopulateColumns();
            }
        }

        private void datePT_EditValueChanged(object sender, EventArgs e)
        {
            PhuTungNgayBatKy();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (gvDanhSachThongKe.RowCount > 0)
            {
                XtraReport rp = new XtraReport();
                rp.DataSource = frm.ChuyenGridViewSangDataTable(gvDanhSachThongKe);
                //rp.ShowDesignerDialog();
                if (kiemTra == 1) rp.LoadLayout(Application.StartupPath + @"\ReportThongKeXeMayHomNay.repx");
                else if (kiemTra == 2) rp.LoadLayout(Application.StartupPath + @"\ReportThongKePhuTungHomNay.repx");
                else if (kiemTra == 3) rp.LoadLayout(Application.StartupPath + @"\ReportThongKeXeMayNgayBatKy.repx");
                else if (kiemTra == 4) rp.LoadLayout(Application.StartupPath + @"\ReportThongKePhuTungNgayBatKy.repx");
                //if (textBox1.Text == "1") rp.ShowDesignerDialog();
                //else rp.ShowPreviewDialog();
                rp.ShowPreviewDialog();

            }
            else XtraMessageBox.Show("Không có dữ liệu để in", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        void XeMayHomNay()
        {
            kiemTra = 1;
            gcDanhSachThongKe.DataSource = null;
            gcDanhSachThongKe.DataSource = thongkeControl.thongKeXeNgay("{ fn CURDATE() }");
            gcDanhSachThongKe.MainView.PopulateColumns();
            ThemTextChoLable();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
            grcDanhSachThongKe.Text = "Danh sách thống kê xe máy hôm nay";
        }

        void XeMayNgayBatKy()
        {
            kiemTra = 3;
            gcDanhSachThongKe.DataSource = null;
            gcDanhSachThongKe.DataSource = thongkeControl.thongKeXeNgay(string.Format("CONVERT(date, '{0}', 103)", dateXe.Text.Trim()));
            gcDanhSachThongKe.MainView.PopulateColumns();
            ThemTextChoLable();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
            grcDanhSachThongKe.Text = "Danh sách thống kê xe máy ngày " + dateXe.Text.Trim();
        }

        void PhuTungHomNay()
        {
            kiemTra = 2;
            gcDanhSachThongKe.DataSource = null;
            gcDanhSachThongKe.DataSource = thongkeControl.thongKePhuTungNgay("{ fn CURDATE() }");
            gcDanhSachThongKe.MainView.PopulateColumns();
            ThemTextChoLable();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
            grcDanhSachThongKe.Text = "Danh sách thống kê phụ tùng hôm nay";
        }

        void PhuTungNgayBatKy()
        {
            kiemTra = 4;
            gcDanhSachThongKe.DataSource = null;
            gcDanhSachThongKe.DataSource = thongkeControl.thongKePhuTungNgay(string.Format("CONVERT(date, '{0}', 103)", datePT.Text.Trim()));
            gcDanhSachThongKe.MainView.PopulateColumns();
            ThemTextChoLable();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachThongKe);
            grcDanhSachThongKe.Text = "Danh sách thống kê phụ tùng ngày " + datePT.Text.Trim();
        }

        void ThemTextChoLable()
        {
            if (gvDanhSachThongKe.RowCount > 0)
            {
                DataTable dt = frm.ChuyenGridViewSangDataTable(gvDanhSachThongKe);
                int tiennhap = 0, soLuong = 0, tienban = 0, tienLai = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (kiemTraClick == 1)
                    {
                        tiennhap += Convert.ToInt32(dt.Rows[i][9].ToString().Split('.', ',')[0]);
                        soLuong += Convert.ToInt32(dt.Rows[i][5].ToString().Split('.', ',')[0]);
                        tienban += Convert.ToInt32(dt.Rows[i][8].ToString().Split('.', ',')[0]);
                        tienLai += Convert.ToInt32(dt.Rows[i][10].ToString().Split('.', ',')[0]);
                    }
                    else
                    {
                        tiennhap += Convert.ToInt32(dt.Rows[i][8].ToString().Split('.', ',')[0]);
                        soLuong += Convert.ToInt32(dt.Rows[i][6].ToString().Split('.', ',')[0]);
                        tienban += Convert.ToInt32(dt.Rows[i][10].ToString().Split('.', ',')[0]);
                        tienLai += Convert.ToInt32(dt.Rows[i][11].ToString().Split('.', ',')[0]);
                    }
                }
                lblTienNhap.Text = string.Format("Tổng tiền nhập: {0} VNĐ", frmMain.DoiTien(tiennhap.ToString()));
                lblSoLuong.Text = string.Format("Tổng số lượng: {0}", frmMain.DoiTien(soLuong.ToString()));
                lblTienBan.Text = string.Format("Tổng tiền bán: {0} VNĐ", frmMain.DoiTien(tienban.ToString()));
                lblTienLai.Text = string.Format("Tổng tiền lãi: {0} VNĐ", frmMain.DoiTien(tienLai.ToString()));
            }
            else
            {
                lblTienNhap.Text = "Tổng tiền nhập: 0";
                lblTienBan.Text = "Tổng tiền bán: 0";
                lblTienLai.Text = "Tổng tiền lãi: 0";
                lblSoLuong.Text = "Tổng số lượng: 0";
            }
        }

        void DeleteTextLabel()
        {
            lblSoLuong.Text = lblTienBan.Text = lblTienLai.Text = lblTienNhap.Text = string.Empty;
        }
    }
}
