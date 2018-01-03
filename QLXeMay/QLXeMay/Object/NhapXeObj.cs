using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class NhapXeObj
    {
        string maNhaCC, maNV, maNhap, ngayNhap;

        public string NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }

        public string MaNhap
        {
            get { return maNhap; }
            set { maNhap = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string MaNhaCC
        {
            get { return maNhaCC; }
            set { maNhaCC = value; }
        }

    }
}
