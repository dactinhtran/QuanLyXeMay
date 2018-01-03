using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class ChiTietHoaDonBanPhuTungObj
    {
        string maChiTietHoaDonBanPhuTung, maHoaDonBanPhuTung, maPhuTung;
        int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public string MaChiTietHoaDonBanPhuTung
        {
            get { return maChiTietHoaDonBanPhuTung; }
            set { maChiTietHoaDonBanPhuTung = value; }
        }

        public string MaHoaDonBanPhuTung
        {
            get { return maHoaDonBanPhuTung; }
            set { maHoaDonBanPhuTung = value; }
        }

        public string MaPhuTung
        {
            get { return maPhuTung; }
            set { maPhuTung = value; }
        }
    }
}
