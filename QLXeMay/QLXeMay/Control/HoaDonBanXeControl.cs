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
    class HoaDonBanXeControl
    {
        HoaDonBanXeMod HDBanXeMod = new HoaDonBanXeMod();

        public DataTable getAllData()
        {
            return HDBanXeMod.GetAllData();
        }

        public DataTable getAllDataHD()
        {
            return HDBanXeMod.GetAllDataHD();
        }

        public bool addData(HoaDonBanXeObj HDBanXeObj)
        {
            return HDBanXeMod.AddData(HDBanXeObj);
        }

        public bool updateData(HoaDonBanXeObj HDBanXeObj)
        {
            return HDBanXeMod.UpdateData(HDBanXeObj);
        }

        public bool deleteData(string ma)
        {
            return HDBanXeMod.DeleteData(ma);
        }

        public DataTable getDataInHoaDon(string maHoaDon)
        {
            return HDBanXeMod.getDataInHoaDon(maHoaDon);
        }

         //Lấy dữ liệu để in ấn
        public DataTable inHoaDon(string maHDBan)
        {
            return HDBanXeMod.InHoaDon(maHDBan);
        }

        public DataTable getDataHomNay(string ma)
        {
            return HDBanXeMod.GetDataHomNay(ma);
        }

        public DataTable getDataChiTiet(string maNhanVien)
        {
            return HDBanXeMod.GetDataChiTiet(maNhanVien);
        }
    }
}
