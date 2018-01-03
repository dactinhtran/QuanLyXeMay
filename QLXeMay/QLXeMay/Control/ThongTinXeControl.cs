using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QLXeMay.Object;
using QLXeMay.Model;

namespace QLXeMay.Control
{
    class ThongTinXeControl
    {
        ThongTinXeMod ttXeMod = new ThongTinXeMod();

        public DataTable getAllData()
        {
            return ttXeMod.GetAllData();
        }

        //Lấy Tên xe dựa vào mã xe
        public string getTenXe(string ma)
        {
            return ttXeMod.GetTenXe(ma);
        }

        //Lấy Màu xe dựa vào mã xe
        public string getMauXe(string ma)
        {
            return ttXeMod.GetMauXe(ma);
        }

        //Lấy Dung tích dựa vào mã xe
        public string getDungTich(string ma)
        {
            return ttXeMod.GetDungTich(ma);
        }

        public bool addData(ThongTinXeObj TTXeObj)
        {
            return ttXeMod.AddData(TTXeObj);
        }

        public bool updateData(ThongTinXeObj TTXeObj)
        {
            return ttXeMod.UpdateData(TTXeObj);
        }

        public bool deleteData(string ma)
        {
            return ttXeMod.DeleteData(ma);
        }
    }
}
