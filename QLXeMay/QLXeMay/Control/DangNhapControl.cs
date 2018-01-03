using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLXeMay.Object;
using QLXeMay.Model;
using System.Data;
using System.Data.SqlClient;

namespace QLXeMay.Control
{
    class DangNhapControl
    {
        DangNhapMod dnMod = new DangNhapMod();

        public DataTable getDangNhapData(string tenDN, string matKhau)
        {
            return dnMod.GetDangNhapData(tenDN, matKhau);
        }
        public DataTable getAllData()
        {
            return dnMod.GetAllData();
        }

        public bool addData(DangNhapObj dnObj)
        {
            return dnMod.AddData(dnObj);
        }

        public bool updateData(DangNhapObj dnObj)
        {
            return dnMod.UpdateData(dnObj);
        }

        public bool deleteData(string ma)
        {
            return dnMod.DeleteData(ma);
        }

         //Lấy toàn bộ dữ liệu
        public DataTable getFullData()
        {
            return dnMod.GetFullData();
        }
    }
}
