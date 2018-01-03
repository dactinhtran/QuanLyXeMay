using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QLXeMay.Object;
using QLXeMay.Model;

namespace QLXeMay.Control
{
    class KhachHangControl
    {
        KhachHangMod khMod = new KhachHangMod();
        public DataTable getAllData()
        {
            return khMod.GetAllData();
        }

        public bool addData(KhachHangObj khObj)
        {
            return khMod.AddData(khObj);
        }

        public bool updateData(KhachHangObj khObj)
        {
            return khMod.UpdateData(khObj);
        }

        public bool deleteData(string ma)
        {
            return khMod.DeleteData(ma);
        }

        public DataTable getAllDataSeach(string timkiemKhachHang)
        {
            return khMod.GetAllDataSearch(timkiemKhachHang);
        }

        public DataTable getDataMa()
        {
            return khMod.GetDataMa();
        }

        public DataTable getAllDataMaTen()
        {
            return khMod.GetDataMaTen();
        }

        public DataTable getAllDataMaTenCMND()
        {
            return khMod.GetAllDataMaTenCMND();
        }

        public string getTenKhachHang(string ma)
        {
            return khMod.GetTenKhachHang(ma);
        }
    }
}
