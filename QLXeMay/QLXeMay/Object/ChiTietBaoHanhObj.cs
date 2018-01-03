using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class ChiTietBaoHanhObj
    {
        string maChiTietBaoHanh, maBaoHanh, maNV, congViec;
        int soKM;

        public int SoKM
        {
            get { return soKM; }
            set { soKM = value; }
        }

        public string MaChiTietBaoHanh
        {
            get { return maChiTietBaoHanh; }
            set { maChiTietBaoHanh = value; }
        }

        public string MaBaoHanh
        {
            get { return maBaoHanh; }
            set { maBaoHanh = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string CongViec
        {
            get { return congViec; }
            set { congViec = value; }
        }

    }
}
