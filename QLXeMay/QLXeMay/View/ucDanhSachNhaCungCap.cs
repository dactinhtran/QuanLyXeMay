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
    public partial class ucDanhSachNhaCungCap : UserControl
    {
        public ucDanhSachNhaCungCap()
        {
            InitializeComponent();
        }

        NhaCungCapControl nccControl = new NhaCungCapControl();

        private void ucDanhSachNhaCungCap_Load(object sender, EventArgs e)
        {
            gcDanhSachNhaCungCap.DataSource = nccControl.getAllData();
            labelControl2.Text = "Tổng: " + nccControl.getAllData().Rows.Count + " nhà cung cấp";
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachNhaCungCap);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            XtraReport rp = new XtraReport();
            rp.DataSource = nccControl.getAllData();
           // rp.ShowDesignerDialog();
            rp.LoadLayout(Application.StartupPath + @"\ReportDanhSachNhaCungCap.repx");
            //rp.ShowDesignerDialog();
           rp.ShowPreview();
        }
    }
}
