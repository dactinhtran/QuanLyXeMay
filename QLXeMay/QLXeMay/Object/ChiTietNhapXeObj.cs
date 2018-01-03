using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class ChiTietNhapXeObj
    {
        string maCTN, maNhap, donViTinh, maThongTinXe;

        public string MaThongTinXe
        {
            get { return maThongTinXe; }
            set { maThongTinXe = value; }
        }
        int donGia, soLuong;

        public int DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public string DonViTinh
        {
            get { return donViTinh; }
            set { donViTinh = value; }
        }

        public string MaNhap
        {
            get { return maNhap; }
            set { maNhap = value; }
        }

        public string MaCTN
        {
            get { return maCTN; }
            set { maCTN = value; }
        }

    }
}
