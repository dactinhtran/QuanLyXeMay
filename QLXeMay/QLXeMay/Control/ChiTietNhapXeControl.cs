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
    class ChiTietNhapXeControl
    {
        ChiTietNhapXeMod CTNhapMod = new ChiTietNhapXeMod();

        public DataTable getAllData()
        {
            return CTNhapMod.GetAllData();
        }

        public bool addData(ChiTietNhapXeObj CTNhapObj)
        {
            return CTNhapMod.AddData(CTNhapObj);
        }

        public bool updateData(ChiTietNhapXeObj CTNhapObj)
        {
            return CTNhapMod.UpdateData(CTNhapObj);
        }

        public bool deleteData(string ma)
        {
            return CTNhapMod.DeleteData(ma);
        }

        public DataTable getDataChiTietNhapXeMayThayDoi(string ma)
        {
            return CTNhapMod.GetDataChiTietThayDoi(ma);
        }

        public DataTable getDataMaChiTiet()
        {
            return CTNhapMod.GetDataMaChiTiet();
        }

         //Xem toàn bộ chi tiết nhập của 1 nhân viên
        public DataTable getDataChiTiet(string maNhanVien)
        {
            return CTNhapMod.GetDataChiTiet(maNhanVien);
        }
    }
}
