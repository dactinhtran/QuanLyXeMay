using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QLXeMay.Object;
using QLXeMay.Model;

namespace QLXeMay.Control
{
    class ChiTietBaoHanhControl
    {
        ChiTietBaoHanhMod CTBHMod = new ChiTietBaoHanhMod();

        public DataTable getAllData()
        {
            return CTBHMod.GetAllData();
        }

        public bool addData(ChiTietBaoHanhObj CTBHObj)
        {
            return CTBHMod.AddData(CTBHObj);
        }

        public bool updateData(ChiTietBaoHanhObj CTBHObj)
        {
            return CTBHMod.UpdateData(CTBHObj);
        }

        public bool deleteData(string ma)
        {
            return CTBHMod.DeleteData(ma);
        }
        //Lấy dữ liệu khi lueMaBHThayDoi
        public DataTable getDataMalueMaBHThayDoi(string maBH)
        {
            return CTBHMod.GetDataMalueMaBHThayDoi(maBH);
        }
    }
}
