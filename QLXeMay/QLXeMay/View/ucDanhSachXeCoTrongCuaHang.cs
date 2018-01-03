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
    public partial class ucDanhSachXeCoTrongCuaHang : UserControl
    {
        public ucDanhSachXeCoTrongCuaHang()
        {
            InitializeComponent();
        }

        XeControl xControl = new XeControl();

        private void ucDanhSachXeCoTrongCuaHang_Load(object sender, EventArgs e)
        {
            gcDanhSachXeCoTrongCuaHang.DataSource = xControl.xeCoTrongCuaHang();
            frmMain.DatLaiTenCotCuaGridView(gvDanhSachXeCoTrongCuaHang);
            lblTong.Text = "Tổng cộng: " + xControl.xeCoTrongCuaHang().Rows.Count + " xe máy.";
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            XtraReport rp = new XtraReport();
            rp.DataSource = xControl.xeCoTrongCuaHang();
            //rp.ShowDesignerDialog();
            rp.LoadLayout(Application.StartupPath + @"\ReportDanhSachXeCoTrongCuaHang.repx");
            //if(textBox1.Text == "1") rp.ShowPreviewDialog();
            //else rp.ShowDesignerDialog();
            rp.ShowPreviewDialog();
        }
    }
}
