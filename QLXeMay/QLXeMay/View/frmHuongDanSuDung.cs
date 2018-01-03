using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace QLXeMay.View
{
    public partial class frmHuongDanSuDung : XtraForm
    {
        public frmHuongDanSuDung()
        {
            InitializeComponent();
        }
        private void pdfViewer1_Load(object sender, EventArgs e)
        {   
            pdfViewer1.DocumentFilePath = Path.GetFullPath(Environment.CurrentDirectory) + @"\HuongDanSuDung.pdf";
          
        }
    }
}
