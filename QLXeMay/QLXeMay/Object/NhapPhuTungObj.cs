using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class NhapPhuTungObj
    {
        string maNhapPhuTung, maNhaCungCap, maNV, ngayNhap;

        public string NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string MaNhaCungCap
        {
            get { return maNhaCungCap; }
            set { maNhaCungCap = value; }
        }

        public string MaNhapPhuTung
        {
            get { return maNhapPhuTung; }
            set { maNhapPhuTung = value; }
        }

    }
}
