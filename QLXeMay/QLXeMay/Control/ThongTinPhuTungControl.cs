using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLXeMay.Object;
using QLXeMay.Model;
using System.Data;


namespace QLXeMay.Control
{
    class ThongTinPhuTungControl
    {
        ThongTinPhuTungMod TTPTMod = new ThongTinPhuTungMod();
        public DataTable getAllData()
        {
            return TTPTMod.GetAllData();
        }
        
        //Lấy Loại phụ tùng dựa vào mã
        public string getLoaiPhuTung(string ma)
        {
            return TTPTMod.GetLoaiPhuTung(ma);
        }

        public bool addData(ThongTinPhuTungObj TTPTObj)
        {
            return TTPTMod.AddData(TTPTObj);
        }

        public bool updateData(ThongTinPhuTungObj TTPTObj)
        {
            return TTPTMod.UpdateData(TTPTObj);
        }

        public bool deleteData(string ma)
        {
            return TTPTMod.DeleteData(ma);
        }

        //Lấy Tên phụ tùng dựa vào mã
        public string getTenPhuTung(string ma)
        {
            return TTPTMod.GetTenPhuTung(ma);
        }

        //Lấy Đơn vị tính dựa vào mã
        public string getDonViTinh(string ma)
        {
            return TTPTMod.GetDonViTinh(ma);
        }

    }
}
