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
    class PhuTungControl
    {
        PhuTungMod PTMod = new PhuTungMod();

        public DataTable getAlldata()
        {
            return PTMod.GetAllData();
        }

        public DataTable getAllDataUCPhuTung()
        {
            return PTMod.GetAllDataUCPhuTung();
        }

        public bool addData(PhuTungObj PTObj)
        {
            return PTMod.AddData(PTObj);
        }

        public bool updateData(PhuTungObj PTObj)
        {
            return PTMod.UpdateData(PTObj);
        }

        public bool deleteData(string ma)
        {
            return PTMod.DeleteData(ma);
        }

        public DataTable timKiemPhuTungDaNhap(string timKiem)
        {
            return PTMod.TimKiemPhuTungDaNhap(timKiem);
        }

        public DataTable timKiemPhuTungDaBan(string timKiem)
        {
            return PTMod.TimKiemPhuTungDaBan(timKiem);
        }

        public DataTable timKiemPhuTungCoTrongCuaHang(string timKiem)
        {
            return PTMod.TimKiemPhuTungCoTrongCuaHang(timKiem);
        }

        //Phụ tùng có trong cửa hàng (Số lượng đã nhập mà chưa bán)//Danh mục xe trong cửa hàng
        public DataTable danhSachPhuTungCoTrongCuaHang()
        {
            return PTMod.DanhSachPhuTungCoTrongCuaHang();
        }

        //Danh sách PT nhân viên đã nhập
        public DataTable getAllDataNhanVienDaNhap()
        {
            return PTMod.GetAllDataNhanVienDaNhap();
        }

        //Danh sách phụ tùng có trong cửa hàng với điều kiện tổng số giống nhau mã chi tiết nhập = số lượng
        public DataTable getAllDataSoLuongBangMaChiTietNhapPT()
        {
            return PTMod.GetAllDataSoLuongBangMaChiTietNhapPT();
        }

        public DataTable getDataMaTenCTPT()
        {
            return PTMod.GetDataMaTenCTPT();
        }

        //Lấy Loại phụ tùng dựa vào MACTNPT dùng trong ucPhuTung
        public string  getLoaiPT(string ma)
        {
            return PTMod.GetLoaiPT(ma);
        }

        //Lấy Tên phụ tùng dựa vào MACTNPT dùng trong ucPhuTung
        public string getTenPT(string ma)
        {
            return PTMod.GetTenPT(ma);
        }

        //Lấy Đơn giá nhâp dựa vào MACTNPT dùng trong ucPhuTung
        public string getDonGiaNhap(string ma)
        {
            return PTMod.GetDonGiaNhap(ma);
        }

        //Lấy Số lượng dựa vào MACTNPT dùng trong ucPhuTung
        public string getSoLuong(string ma)
        {
            return PTMod.GetSoLuong(ma);
        }

        //Lấy Đơn vị tính dựa vào MACTNPT dùng trong ucPhuTung
        public string getDonViTinh(string ma)
        {
            return PTMod.GetDonViTinh(ma);
        }

        //Phụ tùng có trong cửa hàng UCHoaDonBanPT
        public DataTable getPhuTungCoTrongCuaHangUCHD()
        {
            return PTMod.GetPhuTungCoTrongCuaHangUCHD();
        }
        //Phụ tùng với mã hóa đơn bán = {chuỗi mã truyền vào} UCHoaDonBanPT. Lấy danh sách các phụ tùng cùng 1 hóa đơn
        public DataTable getPhuTungDaChonKhiMuaPT(string mahdbPT)
        {
            return PTMod.GetPhuTungDaChonKhiMuaPT(mahdbPT);
        }

         //Mã - tên - loại PT có trong cửa hàng
        public DataTable getMaTenLoaiPhuTungCoTrongCuaHang()
        {
            return PTMod.GetMaTenLoaiPhuTungCoTrongCuaHang();
        }

      
    }
}
