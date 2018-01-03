using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using QLXeMay.Control;

namespace QLXeMay.View
{
    public partial class frmChaoMung : XtraForm
    {
        public frmChaoMung()
        {
            InitializeComponent();
            
        }

        frmMain frm = new frmMain();
        int x = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            x++;
            if (x == 3) 
            {
                timer1.Stop();
                this.Hide();
                frm.Show();
            }  
        }

        private void frmChaoMung_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frm.Show();
        }

        NhanVienControl nvControl = new NhanVienControl();
        private void frmChaoMung_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Pumpkin");
            lblTen.Text = nvControl.getTenNV(frmDangNhap.MaNhanVien);
            
        }
    }
}
