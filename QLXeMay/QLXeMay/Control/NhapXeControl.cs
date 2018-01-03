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
    class NhapXeControl
    {
        NhapXeMod nhapxmod = new NhapXeMod();

        public DataTable getAllData()
        {
            return nhapxmod.GetAllData();
        }

        public bool addData(NhapXeObj nhapxObj)
        {
            return nhapxmod.AddData(nhapxObj);
        }

        public bool updateData(NhapXeObj nhapxObj)
        {
            return nhapxmod.UpdateData(nhapxObj);
        }

        public bool deleteData(string ma)
        {
            return nhapxmod.DeleteData(ma);
        }

        public DataTable getDataMa()
        {
            return nhapxmod.GetDataMa();
        }

        public DataTable getAllDataToDay()
        {
            return nhapxmod.GetAllDataToDay();
        }

        public DataTable getAllDataPrint(string ma)
        {
            return nhapxmod.GetAllDataPrint(ma);
        }

        public DataTable getDataChiTiet(string ma)
        {
            return nhapxmod.GetDataChiTiet(ma);
        }
    }
}
