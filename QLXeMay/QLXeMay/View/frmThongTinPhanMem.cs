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
    public partial class frmThongTinPhanMem : XtraForm
    {
        public frmThongTinPhanMem()
        {
            InitializeComponent();
        }

        private void labelControl7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.google.com");
        }

        private void labelControl8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.google.com");
        }
    }
}
