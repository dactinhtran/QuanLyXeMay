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
    class NhaCungCapControl
    {
        NhaCungCapMod nccMod = new NhaCungCapMod();

        public DataTable getAllData()
        {
            return nccMod.GetAllData();
        }

        public bool addData(NhaCungCapObj nccObj)
        {
            return nccMod.AddData(nccObj);
        }

        public bool updateData(NhaCungCapObj nccObj)
        {
            return nccMod.UpdateData(nccObj);
        }

        public bool deleteData(string ma)
        {
            return nccMod.DeleteData(ma);
        }

        public DataTable getDataMa()
        {
            return nccMod.GetDataMa();
        }

        public DataTable getDataMaTen()
        {
            return nccMod.GetDataMaTen();
        }

        //lấy tên nhà cung cấp từ mã nhà cung cấp
        public string tenNhaCungCap(string ma)
        {
            return nccMod.TenNhaCungCap(ma);
        }
    }
}
