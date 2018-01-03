using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QLXeMay.Object;
using QLXeMay.Model;

namespace QLXeMay.Control
{
    class BaoHanhControl
    {
        BaoHanhMod BHMod = new BaoHanhMod();

        public DataTable getAllData()
        {
            return BHMod.GetAllData();
        }

        public DataTable getAllDataChoGridControl()
        {
            return BHMod.GetAllDataChoGridControl();
        }

        public bool addData(BaoHanhObj BHObj)
        {
            return BHMod.AddData(BHObj);
        }

        public bool updateData(BaoHanhObj BHObj)
        {
            return BHMod.UpdateData(BHObj);
        }

        public bool deleteData(string ma)
        {
            return BHMod.DeleteData(ma);
        }
    }
}
