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
    class XeControl
    {
        XeMod xmod = new XeMod();

        public DataTable getAllData()
        {
            return xmod.GetAllData();
        }

        public bool addData(XeObj xObj)
        {
            return xmod.AddData(xObj);
        }

        public bool updateData(XeObj xObj)
        {
            return xmod.UpdateData(xObj);
        }

        public bool deleteData(string ma)
        {
            return xmod.DeleteData(ma);
        }

        public DataTable timKiemXeDaNhap(string tkXeDaNhap)
        {
            return xmod.TimKiemXeDaNhap(tkXeDaNhap);
        }

        public DataTable timKiemXeDaBan(string tkXeDaBan)
        {
            return xmod.TimKiemXeDaBan(tkXeDaBan);
        }

        public DataTable timKiemXeCoTrongCuaHang(string tkXe)
        {
            return xmod.TimKiemXeCoTrongCuaHang(tkXe);
        }

        public DataTable xeCoTrongCuaHang()
        {
            return xmod.XeCoTrongCuaHang();
        }

        public DataTable getDataMa()
        {
            return xmod.GetDataMa();
        }

        public DataTable getDataMaSoLuongXeNhanVienDaNhap()
        {
            return xmod.GetDataMaSoLuongXeNhanVienDaNhap();
        }

        public DataTable getDataMaSoLuongXeTrongCuahang()
        {
            return xmod.GetDataMaSoLuongXeTrongCuahang();
        }

        public DataTable getAllDataMaTenMau()
        {
            return xmod.GetAllDataMaTenMau();
        }

        public DataTable getAllDataUCXe()
        {
            return xmod.GetAllDataUCXe();
        }

        public DataTable getDataXeTrongCuaHangUCHoaDon()
        {
            return xmod.GetDataXeTrongCuaHangUCHoaDon();
        }

        //Lấy tên xe dựa vào MAXE dùng trong ucHoaDonBanXe
        public string getTenXe(string ma)
        {
            return xmod.GetTenXe(ma);
        }

        //Lấy màu xe dựa vào MAXE dùng trong ucHoaDonBanXe
        public string getMauXe(string ma)
        {
            return xmod.GetMauXe(ma);
        }

        //Lấy đon giá bán xe dựa vào MAXE dùng trong ucHoaDonBanXe
        public string getDonGiaBanXe(string ma)
        {
            return xmod.GetDonGiaBanXe(ma);
        }

        //Lấy tên xe dựa vào MACTN dùng trong ucXe
        public string getTenXeUCXe(string ma)
        {
            return xmod.GetTenXeUCXe(ma);
        }

        //Lấy màu xe dựa vào MACTN dùng trong ucXe
        public string getMauXeUCXe(string ma)
        {
            return xmod.GetMauXeUCXe(ma);
        }

        //Lấy dung tích dựa vào MACTN dùng trong ucXe
        public string getDungTichUCXe(string ma)
        {
            return xmod.GetDungTichUCXe(ma);
        }

        //public DataTable getXeChuaBaoDangKyBaoHanh()
        //{
        //    return xmod.GetXeChuaBaoDangKyBaoHanh();
        //}

        public DataTable getMaXeCholueMaXeUCBaoHanh()
        {
            return xmod.GetMaXeCholueMaXeUCBaoHanh();
        }
    }
}
