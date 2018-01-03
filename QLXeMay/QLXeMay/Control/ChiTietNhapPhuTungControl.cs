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
    class ChiTietNhapPhuTungControl
    {
        ChiTietNhapPhuTungMod CTNhapPTMod = new ChiTietNhapPhuTungMod();

        public DataTable getAllData()
        {
            return CTNhapPTMod.GetAllData();
        }

        public bool addData(ChiTietNhapPhuTungObj CTNhapPTObj)
        {
            return CTNhapPTMod.AddData(CTNhapPTObj);
        }

        public bool updateData(ChiTietNhapPhuTungObj CTNhapPTObj)
        {
            return CTNhapPTMod.UpdateData(CTNhapPTObj);
        }

        public bool deleteData(string ma)
        {
            return CTNhapPTMod.DeleteData(ma);
        }

        public DataTable getDataMa()
        {
            return CTNhapPTMod.GetDataMa();
        }

        public DataTable getAllDataUCNhapPT()
        {
            return CTNhapPTMod.GetAllDataUCNhapPT();
        }

        public DataTable getDataUCNhapPTMaNhapPTThayDoi(string maNhap)
        {
            return CTNhapPTMod.GetAllDataUCNhapPTMaNhapPTThayDoi(maNhap);
        }

        public DataTable getAllDataDanhSachChiTiet(string maNhapPT)
        {
            return CTNhapPTMod.GetAllDataDanhSachChiTiet(maNhapPT);
        }
    }
}
