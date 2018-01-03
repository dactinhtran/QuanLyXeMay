using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QLXeMay.Object;
using QLXeMay.Model;

namespace QLXeMay.Control
{
    class ChiTietHoaDonBanPhuTungControl
    {
        ChiTietHoaDonBanPhuTungMod chiTietHDbanPTMod = new ChiTietHoaDonBanPhuTungMod();

        public DataTable getAllData()
        {
            return chiTietHDbanPTMod.GetAllData();
        }

        public bool addData(ChiTietHoaDonBanPhuTungObj chiTietHDBanPTObj)
        {
            return chiTietHDbanPTMod.AddData(chiTietHDBanPTObj);
        }

        public bool updateData(ChiTietHoaDonBanPhuTungObj chiTietHDBanPTObj)
        {
            return chiTietHDbanPTMod.UpdateData(chiTietHDBanPTObj);
        }

        public bool deleteData(string ma)
        {
            return chiTietHDbanPTMod.DeleteData(ma);
        }

        
        //Lấy MaHDBPT từ MAPT
        public string getMaCTHoaDonBanPTTuMaPT(string mapt)
        {
            return chiTietHDbanPTMod.GetMaCTHoaDonBanPTTuMaPT(mapt);
        }

         //Lấy mã chi tiết hóa đơn bán phụ tùng từ mã hóa đơn bán phụ tùng
        public DataTable getMaCTHoaDonBanPTTuMaHDBanPT(string mahdBanPT)
        {
            return chiTietHDbanPTMod.GetMaCTHoaDonBanPTTuMaHDBanPT(mahdBanPT);
        }

        public DataTable getAllDataDanhSachChiTiet(string maNhapPT)
        {
            return chiTietHDbanPTMod.GetAllDataDanhSachChiTiet(maNhapPT);
        }
    }
}
