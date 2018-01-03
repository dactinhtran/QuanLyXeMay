using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;
using QLXeMay.Model;

namespace QLXeMay.Control
{
    class HoaDonBanPhuTungControl
    {
        HoaDonBanPhuTungMod HDBanPhuTungMod = new HoaDonBanPhuTungMod();

        public DataTable getAllData()
        {
            return HDBanPhuTungMod.GetAllData();
        }

        public bool addData(HoaDonBanPhuTungObj HDBanPhuTungObj)
        {
            return HDBanPhuTungMod.AddData(HDBanPhuTungObj);
        }

        public bool updateData(HoaDonBanPhuTungObj HDBanPhuTungObj)
        {
            return HDBanPhuTungMod.UpdateData(HDBanPhuTungObj);
        }

        public bool deleteData(string ma)
        {
            return HDBanPhuTungMod.DeleteData(ma);
        }

        public DataTable getAllDataPrint(string maHoaDonBanPT)
        {
            return HDBanPhuTungMod.GetAllDataPrint(maHoaDonBanPT);
        }
        public DataTable getDataDanhSachHoaDon()
        {
            return HDBanPhuTungMod.GetDataDanhSachHoaDon();
        }
    }
}
