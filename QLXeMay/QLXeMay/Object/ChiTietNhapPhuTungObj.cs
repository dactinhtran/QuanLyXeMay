using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class ChiTietNhapPhuTungObj
    {
        string maCTNhapPT, maNhapPT, maTTPT;

        public string MaTTPT
        {
            get { return maTTPT; }
            set { maTTPT = value; }
        }
        int soLuong, donGiaNhap;

        public int DonGiaNhap
        {
            get { return donGiaNhap; }
            set { donGiaNhap = value; }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
       
        public string MaNhapPT
        {
            get { return maNhapPT; }
            set { maNhapPT = value; }
        }

        public string MaCTNhapPT
        {
            get { return maCTNhapPT; }
            set { maCTNhapPT = value; }
        }
    }
}
