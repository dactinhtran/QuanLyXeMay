using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class HoaDonBanXeObj
    {
        string maHDBanXe, maKH, maNV, ngayBan, maXe, donViTinh;
        int soLuong, donGia;
        double thueVAT;

        public double ThueVAT
        {
            get { return thueVAT; }
            set { thueVAT = value; }
        }


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

        public string MaXe
        {
            get { return maXe; }
            set { maXe = value; }
        }

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

        public string MaHDBanXe
        {
            get { return maHDBanXe; }
            set { maHDBanXe = value; }
        }
    }
}
