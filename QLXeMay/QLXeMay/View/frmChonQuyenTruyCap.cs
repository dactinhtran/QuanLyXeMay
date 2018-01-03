using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLXeMay.View
{
    public partial class frmChonQuyenTruyCap : XtraForm
    {
        public frmChonQuyenTruyCap()
        {
            InitializeComponent();
        }

        private void btnChonTatCa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbQuyenTruyCap.Items.Count; i++)
            {
                clbQuyenTruyCap.Items[i].CheckState = CheckState.Checked;
            }
        }

        public string daChon = "";
        private void frmChonQuyenTruyCap_Load(object sender, EventArgs e)
        {
            
            daChon = ucThemTaiKhoanDangNhap.quyen;
            var arr = daChon.Split('-').ToArray();
            try
            {
                foreach(var i in arr) clbQuyenTruyCap.Items[Convert.ToInt32(i) - 1].CheckState = CheckState.Checked;
            }
            catch (Exception)
            {

            }
        }

        public static string traVe;
        private void btnOK_Click(object sender, EventArgs e)
        {
            traVe = string.Empty;
            for (int i = 0; i < clbQuyenTruyCap.Items.Count; i++)
            {
                if (clbQuyenTruyCap.GetItemChecked(i)) traVe += (i+1) + "-";
            }
            if (traVe != string.Empty) traVe = traVe.Remove(traVe.Length - 1);
            this.Hide();
        }

        private void frmChonQuyenTruyCap_FormClosed(object sender, FormClosedEventArgs e)
        {
            traVe = daChon;
        }
    }
}
