using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class HoaDonBanXeMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        //sửa sau
        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MAHDBAN, MAKH, MANV, NGAYBAN, MAXE, SOLUONG, THUEVAT, DONGIA, DONVITINH FROM tblHDBan";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.openCon();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.closeCon();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }

            return dt;
        }

        public DataTable GetAllDataHD()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblHDBan.MAHDBAN, tblHDBan.MAKH, tblHDBan.MANV, tblHDBan.MAXE, tblHDBan.NGAYBAN, tblHDBan.SOLUONG, tblHDBan.THUEVAT, tblHDBan.DONVITINH, tblXe.DONGIABAN, tblXe.DONGIABAN * tblHDBan.THUEVAT / 100 + tblXe.DONGIABAN AS THANHTIEN FROM tblNhanVien INNER JOIN tblHDBan ON tblNhanVien.MANV = tblHDBan.MANV INNER JOIN tblXe ON tblHDBan.MAXE = tblXe.MAXE INNER JOIN tblKhachHang ON tblHDBan.MAKH = tblKhachHang.MAKH INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE ORDER BY tblHDBan.MAHDBAN DESC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.openCon();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.closeCon();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }

            return dt;
        }

        //
        public bool AddData(HoaDonBanXeObj HDBanXeObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblHDBan (MAHDBAN, MAKH, MANV, MAXE, NGAYBAN, SOLUONG, THUEVAT, DONVITINH) VALUES ('{0}', '{1}', '{2}', '{3}', CONVERT(date, '{4}', 103), {5}, {6}, N'{7}')", HDBanXeObj.MaHDBanXe, HDBanXeObj.MaKH, HDBanXeObj.MaNV, HDBanXeObj.MaXe, HDBanXeObj.NgayBan, HDBanXeObj.SoLuong, HDBanXeObj.ThueVAT, HDBanXeObj.DonViTinh);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.openCon();
                cmd.ExecuteNonQuery();
                con.closeCon();
                return true;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }

            return false;
        }

        public bool UpdateData(HoaDonBanXeObj HDBanXeObj)
        {
            cmd.CommandText = string.Format("UPDATE tblHDBan SET MAHDBAN = '{0}', MAKH = '{1}', MANV = '{2}', MAXE = '{4}', NGAYBAN = CONVERT(date, '{3}', 103), SOLUONG = {5}, THUEVAT = {6}, DONVITINH = N'{7}' WHERE (MAHDBAN = '{0}')", HDBanXeObj.MaHDBanXe, HDBanXeObj.MaKH, HDBanXeObj.MaNV, HDBanXeObj.NgayBan, HDBanXeObj.MaXe, HDBanXeObj.SoLuong, HDBanXeObj.ThueVAT, HDBanXeObj.DonViTinh);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.openCon();
                cmd.ExecuteNonQuery();
                con.closeCon();
                return true;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }

            return false;
        }

        public bool DeleteData(string ma)
        {
            cmd.CommandText = "DELETE FROM tblHDBan WHERE (MAHDBAN = '" + ma + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.openCon();
                cmd.ExecuteNonQuery();
                con.closeCon();
                return true;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }

            return false;
        }

        public DataTable getDataInHoaDon(string maHoaDon)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblHDBan.MAHDBAN, tblHDBan.NGAYBAN, tblKhachHang.TENKH, tblKhachHang.NGAYSINH, tblKhachHang.DIACHI, tblKhachHang.SDT, tblXe.TENXE, tblHDBan.DONGIA, tblHDBan.SOLUONG, tblHDBan.DONVITINH, tblHDBan.THUEVAT, tblHDBan.DONGIA * tblHDBan.SOLUONG AS THANHTIEN, tblHDBan.DONGIA * tblHDBan.SOLUONG + tblHDBan.THUEVAT AS TONGTHANHTOAN, tblNhanVien.TENNV FROM tblHDBan INNER JOIN tblKhachHang ON tblHDBan.MAKH = tblKhachHang.MAKH INNER JOIN tblXe ON tblHDBan.MAXE = tblXe.MAXE INNER JOIN tblNhanVien ON tblHDBan.MANV = tblNhanVien.MANV WHERE (tblHDBan.MAHDBAN = '{0}')", maHoaDon);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.openCon();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.closeCon();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }

            return dt;
        }

        //Lấy dữ liệu để in ấn
        public DataTable InHoaDon(string maHDBan)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblHDBan.MAHDBAN, tblHDBan.NGAYBAN, tblKhachHang.TENKH, tblKhachHang.NGAYSINH, tblKhachHang.DIACHI, tblKhachHang.SDT, tblTTXe.TENXE, tblXe.DONGIABAN, tblHDBan.SOLUONG, tblHDBan.DONVITINH, tblHDBan.THUEVAT, tblXe.DONGIABAN * tblHDBan.SOLUONG AS THANHTIEN, tblXe.DONGIABAN * tblHDBan.SOLUONG + tblHDBan.THUEVAT * (tblXe.DONGIABAN * tblHDBan.SOLUONG) / 100 AS TONGTHANHTOAN, tblNhanVien.TENNV FROM tblHDBan INNER JOIN tblKhachHang ON tblHDBan.MAKH = tblKhachHang.MAKH INNER JOIN tblXe ON tblHDBan.MAXE = tblXe.MAXE INNER JOIN tblNhanVien ON tblHDBan.MANV = tblNhanVien.MANV INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblHDBan.MAHDBAN = '{0}')", maHDBan);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.openCon();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.closeCon();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }

            return dt;
        }

        public DataTable GetDataHomNay(string manhanvien)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblHDBan.MAHDBAN, tblHDBan.MAKH, tblHDBan.MANV, tblHDBan.MAXE, tblHDBan.NGAYBAN, tblHDBan.SOLUONG, tblHDBan.THUEVAT, tblHDBan.DONVITINH, tblXe.DONGIABAN, tblXe.DONGIABAN * tblHDBan.THUEVAT / 100 + tblXe.DONGIABAN AS THANHTIEN FROM tblNhanVien INNER JOIN tblHDBan ON tblNhanVien.MANV = tblHDBan.MANV INNER JOIN tblXe ON tblHDBan.MAXE = tblXe.MAXE INNER JOIN tblKhachHang ON tblHDBan.MAKH = tblKhachHang.MAKH INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE  WHERE (tblHDBan.NGAYBAN = {{ fn CURDATE() }}) AND (tblHDBan.MANV = '{0}') ORDER BY tblHDBan.MAHDBAN DESC", manhanvien);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.openCon();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.closeCon();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }

            return dt;
        }

        public DataTable GetDataChiTiet(string maNhanVien)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblHDBan.MAHDBAN, tblHDBan.MAKH, tblHDBan.MANV, tblHDBan.MAXE, tblHDBan.NGAYBAN, tblHDBan.SOLUONG, tblHDBan.THUEVAT, tblHDBan.DONVITINH, tblXe.DONGIABAN, tblXe.DONGIABAN * tblHDBan.THUEVAT / 100 + tblXe.DONGIABAN AS THANHTIEN FROM tblNhanVien INNER JOIN tblHDBan ON tblNhanVien.MANV = tblHDBan.MANV INNER JOIN tblXe ON tblHDBan.MAXE = tblXe.MAXE INNER JOIN tblKhachHang ON tblHDBan.MAKH = tblKhachHang.MAKH INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblHDBan.MANV = '{0}') ORDER BY tblHDBan.MAHDBAN DESC", maNhanVien);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.openCon();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.closeCon();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }

            return dt;
        }
    }
}
