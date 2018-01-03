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
    class NhapPhuTungControl
    {
        NhapPhuTungMod NhapPTMod = new NhapPhuTungMod();

        public DataTable getAllData()
        {
            return NhapPTMod.GetAllData();
        }

        public bool addData(NhapPhuTungObj NhapPhuTungObj)
        {
            return NhapPTMod.AddData(NhapPhuTungObj);
        }

        public bool updateData(NhapPhuTungObj NhapPhuTungObj)
        {
            return NhapPTMod.UpdateData(NhapPhuTungObj);
        }

        public bool deleteData(string ma)
        {
            return NhapPTMod.DeleteData(ma);
        }

        public DataTable getDataMa()
        {
            return NhapPTMod.GetDataMa();
        }

          public DataTable getAllDataPrint(string maNhapPT)
        {
            return NhapPTMod.GetAllDataPrint(maNhapPT);
        }
    }
}
