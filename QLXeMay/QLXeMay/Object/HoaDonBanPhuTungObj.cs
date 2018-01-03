using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class HoaDonBanPhuTungObj
    {
        string maHoaDonBanPhuTung, maKH, maNV, ngayBan;

        public string NgayBan
        {
            get { return ngayBan; }
            set { ngayBan = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }

        public string MaHoaDonBanPhuTung
        {
            get { return maHoaDonBanPhuTung; }
            set { maHoaDonBanPhuTung = value; }
        }


    }
}
