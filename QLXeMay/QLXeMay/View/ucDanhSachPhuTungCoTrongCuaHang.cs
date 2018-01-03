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
    public partial class ucDanhSachPhuTungCoTrongCuaHang : UserControl
    {
        public ucDanhSachPhuTungCoTrongCuaHang()
        {
            InitializeComponent();
        }

        PhuTungControl ptControl = new PhuTungControl();

        private void ucDanhSachPhuTungCoTrongCuaHang_Load(object sender, EventArgs e)
        {
            gcDanhSachPhuTungCoTrongCuaHang.DataSource = ptControl.danhSachPhuTungCoTrongCuaHang();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachPhuTungCoTrongCuaHang);
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            XtraReport rp = new XtraReport();
            rp.DataSource = ptControl.danhSachPhuTungCoTrongCuaHang();
            //rp.ShowDesignerDialog();
            rp.LoadLayout(Application.StartupPath + @"\ReportDanhSachPhuTungTrongCuaHang.repx");
            //if(textBox1.Text == "1") rp.ShowPreviewDialog();
            //rp.ShowDesignerDialog();
            rp.ShowPreviewDialog();
        }
    }
}
