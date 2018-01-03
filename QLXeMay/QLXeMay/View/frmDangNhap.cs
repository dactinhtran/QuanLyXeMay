using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLXeMay.Control;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using QLXeMay.View;
using QLXeMay.Model;

namespace QLXeMay
{
    public partial class frmDangNhap : XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Pumpkin");
            label1.BackColor = label2.BackColor = Color.Transparent;
            label1.ForeColor = label2.ForeColor = Color.Yellow;
            // KiemTraKetNoi.Connect();
        }

       
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
            this.MaximizeBox = false;
            
        }

        DangNhapControl dnControl = new DangNhapControl();
        public static string maNhanVien;
        public static string quyenTruyCap, maDangNhap, tenDangNhap, matKhau;

        public static string MatKhau
        {
            get { return frmDangNhap.matKhau; }
            set { frmDangNhap.matKhau = value; }
        }

        public static string TenDangNhap
        {
            get { return frmDangNhap.tenDangNhap; }
            set { frmDangNhap.tenDangNhap = value; }
        }

        public static string MaDangNhap
        {
            get { return frmDangNhap.maDangNhap; }
            set { frmDangNhap.maDangNhap = value; }
        }
        public static string QuyenTruyCap
        {
            get { return frmDangNhap.quyenTruyCap; }
            set { frmDangNhap.quyenTruyCap = value; }
        }

        public static string MaNhanVien
        {
            get { return frmDangNhap.maNhanVien; }
            set { frmDangNhap.maNhanVien = value; }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtDangNhap.Text.Trim();
            string MK = txtMatKhau.Text.Trim();
            DataTable dtDangNhap = new DataTable();
            dtDangNhap = dnControl.getDangNhapData(tenDN, MK);

            if (dtDangNhap.Rows.Count > 0)
            {
                maDangNhap = dtDangNhap.Rows[0][0].ToString();
                maNhanVien = dtDangNhap.Rows[0][1].ToString();
                tenDangNhap = dtDangNhap.Rows[0][2].ToString();
                matKhau = dtDangNhap.Rows[0][3].ToString();
                quyenTruyCap = dtDangNhap.Rows[0][4].ToString();
                //frmMain frm = new frmMain();
                frmChaoMung frm = new frmChaoMung();
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu chưa chính xác\rVui lòng kiểm tra lại", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
