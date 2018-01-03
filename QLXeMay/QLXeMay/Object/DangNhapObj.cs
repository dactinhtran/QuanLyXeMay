using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class DangNhapObj
    {
        string maDN, maNV, tenDN, matKhau, quyenTC;

        public string TenDN
        {
          get { return tenDN; }
          set { tenDN = value; }
        }

        public string QuyenTC
        {
            get { return quyenTC; }
            set { quyenTC = value; }
        }

        public string MatKhau
        {
          get { return matKhau; }
          set { matKhau = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string MaDN
        {
            get { return maDN; }
            set { maDN = value; }
        }

        //Hàm dựng
        public DangNhapObj() { }
        public DangNhapObj(string maDN, string maNV, string tenDN, string matKhau, string quyenTC)
        {
            this.maDN = maDN;
            this.maNV = maNV;
            this.tenDN = tenDN;
            this.matKhau = matKhau;
            this.quyenTC = quyenTC;
        }

    }
}
