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

namespace QLXeMay.View
{
    public partial class ucDanhSachNhanVien : UserControl
    {
        public ucDanhSachNhanVien()
        {
            InitializeComponent();
        }

        NhanVienControl nvControl = new NhanVienControl();

        private void ucDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            gcDanhSachNhanVien.DataSource = nvControl.getAllData();
            lblTongNV.Text = "Tổng cộng: " + nvControl.getAllData().Rows.Count + " nhân viên.";
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachNhanVien);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            XtraReport rp = new XtraReport();
            rp.DataSource = nvControl.getAllData();
           // rp.ShowDesignerDialog();
            rp.LoadLayout(Application.StartupPath + @"\ReportDanhSachNhanVien.repx");
            rp.ShowPreviewDialog();
            //rp.ShowDesignerDialog();
        }
    }
}
