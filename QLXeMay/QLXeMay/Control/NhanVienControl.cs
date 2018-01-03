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
    class NhanVienControl
    {
        NhanVienMod nvMod = new NhanVienMod();
        public DataTable getAllData()
        {
            return nvMod.GetAllData();
        }

        public bool addData(NhanVienObj nvObj)
        {
            return nvMod.AddData(nvObj);
        }

        public bool updateData(NhanVienObj nvObj)
        {
            return nvMod.UpdateData(nvObj);
        }

        public bool deleteData(string ma)
        {
            return nvMod.DeleteData(ma);
        }

        public DataTable getDataSearch(string dieuKienTimKiemNhanVien)
        {
            return nvMod.GetDataSearch(dieuKienTimKiemNhanVien);
        }

        public DataTable getDataMaTen()
        {
            return nvMod.GetDataMaTen();
        }

        public DataTable getDataMa()
        {
            return nvMod.GetDataMa();
        }

        //Lấy tên nhân viên từ bảng nhân viên
        public string getTenNV(string ma)
        {
            return nvMod.GetTenNV(ma);
        }


        public DataTable getMaTenChucVuUCThemDangNhap()
        {
            return nvMod.GetMaTenChucVuUCThemDangNhap();
        }

        //Lấy chức vụ nhân viên từ bảng nhân viên
        public string getChucVuNV(string ma)
        {
            return nvMod.GetChucVuNV(ma);
        }
    }
}
