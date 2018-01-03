using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QLXeMay.Model
{
    class ThongKeMode
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public DataTable ThongKeXeNgay(string ngay)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblHDBan.MAHDBAN, tblKhachHang.TENKH, tblNhanVien.TENNV, tblTTXe.TENXE, tblHDBan.NGAYBAN, tblHDBan.SOLUONG, tblXe.DONGIABAN, tblHDBan.THUEVAT, tblHDBan.SOLUONG * tblXe.DONGIABAN + tblHDBan.THUEVAT * (tblHDBan.SOLUONG * tblXe.DONGIABAN) / 100 AS THANHTIEN, tblChiTietNhap.DONGIANHAP, tblHDBan.SOLUONG * tblXe.DONGIABAN + tblHDBan.THUEVAT * (tblHDBan.SOLUONG * tblXe.DONGIABAN) / 100 - tblChiTietNhap.DONGIANHAP AS TIENLAI FROM tblXe INNER JOIN tblHDBan ON tblXe.MAXE = tblHDBan.MAXE INNER JOIN tblNhanVien ON tblHDBan.MANV = tblNhanVien.MANV INNER JOIN tblKhachHang ON tblHDBan.MAKH = tblKhachHang.MAKH INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblHDBan.NGAYBAN = {0})", ngay);
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

        public DataTable ThongKePhuTungNgay(string ngay)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblHDBanPhuTung.MAHDBANPT, tblKhachHang.TENKH, tblNhanVien.TENNV, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblHDBanPhuTung.NGAYBAN, SUM(tblChiTietHDBanPT.SOLUONG) AS SOLUONG, tblChiTietNhapPhuTung.DONGIANHAP, tblChiTietNhapPhuTung.DONGIANHAP * SUM(tblChiTietHDBanPT.SOLUONG) AS TIENNHAP, tblePhuTung.DONGIABAN, SUM(tblChiTietHDBanPT.SOLUONG) * tblePhuTung.DONGIABAN AS TIENBAN, SUM(tblChiTietHDBanPT.SOLUONG) * tblePhuTung.DONGIABAN - tblChiTietNhapPhuTung.DONGIANHAP * SUM(tblChiTietHDBanPT.SOLUONG) AS TIENLAI FROM tblePhuTung INNER JOIN tblChiTietHDBanPT ON tblePhuTung.MAPT = tblChiTietHDBanPT.MAPT INNER JOIN tblHDBanPhuTung ON tblChiTietHDBanPT.MAHDBANPT = tblHDBanPhuTung.MAHDBANPT INNER JOIN tblKhachHang ON tblHDBanPhuTung.MAKH = tblKhachHang.MAKH INNER JOIN tblNhanVien ON tblHDBanPhuTung.MANV = tblNhanVien.MANV INNER JOIN tblChiTietNhapPhuTung ON tblePhuTung.MACTNPT = tblChiTietNhapPhuTung.MACTNPT INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT WHERE (tblHDBanPhuTung.NGAYBAN = {0}) GROUP BY tblHDBanPhuTung.MAHDBANPT, tblKhachHang.TENKH, tblNhanVien.TENNV, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblHDBanPhuTung.NGAYBAN, tblChiTietHDBanPT.SOLUONG, tblePhuTung.DONGIABAN, tblChiTietNhapPhuTung.DONGIANHAP", ngay);
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

        public DataTable ThongKeNhapThang(int thang, int nam)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT MONTH(tblNhap.NGAYNHAP) AS THANG, tblTTXe.TENXE, tblTTXe.MAUXE, SUM(tblChiTietNhap.SOLUONG) AS SOLUONG, tblChiTietNhap.DONGIANHAP, SUM(tblChiTietNhap.SOLUONG) * tblChiTietNhap.DONGIANHAP AS THANHTIEN, tblChiTietNhap.DONVITINH, tblTTXe.DUNGTICH, tblNhanVien.TENNV, tblNhaCC.TENNHACC FROM tblTTXe INNER JOIN tblChiTietNhap ON tblTTXe.MATTXE = tblChiTietNhap.MATTXE INNER JOIN tblNhap ON tblChiTietNhap.MANHAP = tblNhap.MANHAP INNER JOIN tblNhaCC ON tblNhap.MANHACC = tblNhaCC.MANHACC INNER JOIN tblNhanVien ON tblNhap.MANV = tblNhanVien.MANV WHERE (MONTH(tblNhap.NGAYNHAP) = {0}) AND (YEAR(tblNhap.NGAYNHAP) = {1}) GROUP BY MONTH(tblNhap.NGAYNHAP), tblTTXe.TENXE, tblTTXe.MAUXE, tblChiTietNhap.DONGIANHAP, tblNhaCC.TENNHACC, tblNhanVien.TENNV, tblTTXe.DUNGTICH, tblChiTietNhap.DONVITINH", thang, nam);
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

        public DataTable ThongKeNhapPhuTungThang(int thang, int nam)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT MONTH(tblNhapPhuTung.NGAYNHAP) AS THANG, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, SUM(tblChiTietNhapPhuTung.SOLUONG) AS SOLUONG, tblChiTietNhapPhuTung.DONGIANHAP, SUM(tblChiTietNhapPhuTung.SOLUONG) * tblChiTietNhapPhuTung.DONGIANHAP AS THANHTIEN, tblNhaCC.TENNHACC, tblNhanVien.TENNV FROM tblNhaCC INNER JOIN tblNhapPhuTung ON tblNhaCC.MANHACC = tblNhapPhuTung.MANHACC INNER JOIN tblChiTietNhapPhuTung ON tblNhapPhuTung.MANPT = tblChiTietNhapPhuTung.MANPT INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT INNER JOIN tblNhanVien ON tblNhapPhuTung.MANV = tblNhanVien.MANV WHERE (MONTH(tblNhapPhuTung.NGAYNHAP) = {0}) AND (YEAR(tblNhapPhuTung.NGAYNHAP) = {1}) GROUP BY MONTH(tblNhapPhuTung.NGAYNHAP), tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, tblChiTietNhapPhuTung.DONGIANHAP, tblTTPhuTung.DONVITINH, tblNhaCC.TENNHACC, tblNhanVien.TENNV", thang, nam);
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


        public DataTable ThongKeBanXeTheoThang(string thang, string nam)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT MONTH(tblHDBan.NGAYBAN) AS THANG, tblTTXe.TENXE, tblTTXe.MAUXE, tblTTXe.DUNGTICH, SUM(tblHDBan.SOLUONG) AS SOLUONG, SUM(tblHDBan.SOLUONG * tblXe.DONGIABAN + tblHDBan.THUEVAT * (tblHDBan.SOLUONG * tblXe.DONGIABAN) / 100) AS TIENBAN, SUM(tblChiTietNhap.DONGIANHAP) AS TIENNHAP, SUM(tblHDBan.SOLUONG * tblXe.DONGIABAN + tblHDBan.THUEVAT * (tblHDBan.SOLUONG * tblXe.DONGIABAN) / 100) - SUM(tblChiTietNhap.DONGIANHAP) AS TIENLAI FROM tblXe INNER JOIN tblHDBan ON tblXe.MAXE = tblHDBan.MAXE INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (MONTH(tblHDBan.NGAYBAN) = {0}) AND (YEAR(tblHDBan.NGAYBAN) = {1}) GROUP BY MONTH(tblHDBan.NGAYBAN), tblTTXe.TENXE, tblChiTietNhap.DONGIANHAP, tblXe.DONGIABAN, tblHDBan.THUEVAT, tblHDBan.SOLUONG, tblTTXe.MAUXE, tblTTXe.DUNGTICH", thang, nam);
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

        public DataTable ThongKeBanPhuTungTheoThang(string thang, string nam)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT MONTH(tblHDBanPhuTung.NGAYBAN) AS THANG, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, SUM(tblChiTietHDBanPT.SOLUONG) AS SOLUONG, tblChiTietNhapPhuTung.DONGIANHAP, tblChiTietNhapPhuTung.DONGIANHAP * SUM(tblChiTietHDBanPT.SOLUONG) AS TIENNHAP, tblePhuTung.DONGIABAN, SUM(tblChiTietHDBanPT.SOLUONG) * tblePhuTung.DONGIABAN AS TIENBAN, SUM(tblChiTietHDBanPT.SOLUONG) * tblePhuTung.DONGIABAN - tblChiTietNhapPhuTung.DONGIANHAP * SUM(tblChiTietHDBanPT.SOLUONG) AS TIENLAI, tblTTPhuTung.DONVITINH FROM tblePhuTung INNER JOIN tblChiTietHDBanPT ON tblePhuTung.MAPT = tblChiTietHDBanPT.MAPT INNER JOIN tblHDBanPhuTung ON tblChiTietHDBanPT.MAHDBANPT = tblHDBanPhuTung.MAHDBANPT INNER JOIN tblChiTietNhapPhuTung ON tblePhuTung.MACTNPT = tblChiTietNhapPhuTung.MACTNPT INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT WHERE (MONTH(tblHDBanPhuTung.NGAYBAN) = {0}) AND (YEAR(tblHDBanPhuTung.NGAYBAN) = {1}) GROUP BY tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, MONTH(tblHDBanPhuTung.NGAYBAN), tblChiTietHDBanPT.SOLUONG, tblePhuTung.DONGIABAN, tblChiTietNhapPhuTung.DONGIANHAP, tblTTPhuTung.DONVITINH", thang, nam);
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

        public DataTable ThongKeNhapXeTheoNam(int nam)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT YEAR(tblNhap.NGAYNHAP) AS NAM, tblTTXe.TENXE, tblTTXe.MAUXE, SUM(tblChiTietNhap.SOLUONG) AS SOLUONG, tblChiTietNhap.DONGIANHAP, SUM(tblChiTietNhap.SOLUONG) * tblChiTietNhap.DONGIANHAP AS THANHTIEN, tblChiTietNhap.DONVITINH, tblTTXe.DUNGTICH, tblNhanVien.TENNV, tblNhaCC.TENNHACC FROM tblTTXe INNER JOIN tblChiTietNhap ON tblTTXe.MATTXE = tblChiTietNhap.MATTXE INNER JOIN tblNhap ON tblChiTietNhap.MANHAP = tblNhap.MANHAP INNER JOIN tblNhaCC ON tblNhap.MANHACC = tblNhaCC.MANHACC INNER JOIN tblNhanVien ON tblNhap.MANV = tblNhanVien.MANV WHERE (YEAR(tblNhap.NGAYNHAP) = {0}) GROUP BY YEAR(tblNhap.NGAYNHAP), tblTTXe.TENXE, tblTTXe.MAUXE, tblChiTietNhap.DONGIANHAP, tblNhaCC.TENNHACC, tblNhanVien.TENNV, tblTTXe.DUNGTICH, tblChiTietNhap.DONVITINH",nam);
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

        public DataTable ThongKeNhapPhuTungTheoNam(int nam)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT YEAR(tblNhapPhuTung.NGAYNHAP) AS NAM, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, SUM(tblChiTietNhapPhuTung.SOLUONG) AS SOLUONG, tblChiTietNhapPhuTung.DONGIANHAP, SUM(tblChiTietNhapPhuTung.SOLUONG) * tblChiTietNhapPhuTung.DONGIANHAP AS THANHTIEN, tblNhaCC.TENNHACC, tblNhanVien.TENNV FROM tblNhaCC INNER JOIN tblNhapPhuTung ON tblNhaCC.MANHACC = tblNhapPhuTung.MANHACC INNER JOIN tblChiTietNhapPhuTung ON tblNhapPhuTung.MANPT = tblChiTietNhapPhuTung.MANPT INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT INNER JOIN tblNhanVien ON tblNhapPhuTung.MANV = tblNhanVien.MANV WHERE (YEAR(tblNhapPhuTung.NGAYNHAP) = {0}) GROUP BY YEAR(tblNhapPhuTung.NGAYNHAP), tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, tblChiTietNhapPhuTung.DONGIANHAP, tblTTPhuTung.DONVITINH, tblNhaCC.TENNHACC, tblNhanVien.TENNV", nam);
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

        public DataTable ThongKeBanXeTheoNam(string nam)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT YEAR(tblHDBan.NGAYBAN) AS NAM, tblTTXe.TENXE, tblTTXe.MAUXE, tblTTXe.DUNGTICH, SUM(tblHDBan.SOLUONG) AS SOLUONG, SUM(tblHDBan.SOLUONG * tblXe.DONGIABAN + tblHDBan.THUEVAT * (tblHDBan.SOLUONG * tblXe.DONGIABAN) / 100) AS TIENBAN, SUM(tblChiTietNhap.DONGIANHAP) AS TIENNHAP, SUM(tblHDBan.SOLUONG * tblXe.DONGIABAN + tblHDBan.THUEVAT * (tblHDBan.SOLUONG * tblXe.DONGIABAN) / 100) - SUM(tblChiTietNhap.DONGIANHAP) AS TIENLAI FROM tblXe INNER JOIN tblHDBan ON tblXe.MAXE = tblHDBan.MAXE INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (YEAR(tblHDBan.NGAYBAN) = {0}) GROUP BY YEAR(tblHDBan.NGAYBAN), tblTTXe.TENXE, tblChiTietNhap.DONGIANHAP, tblXe.DONGIABAN, tblHDBan.THUEVAT, tblHDBan.SOLUONG, tblTTXe.MAUXE, tblTTXe.DUNGTICH", nam);
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

        public DataTable ThongKeBanPhuTungTheoNam(string nam)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT YEAR(tblHDBanPhuTung.NGAYBAN) AS YEAR, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, SUM(tblChiTietHDBanPT.SOLUONG) AS SOLUONG, tblChiTietNhapPhuTung.DONGIANHAP, tblChiTietNhapPhuTung.DONGIANHAP * SUM(tblChiTietHDBanPT.SOLUONG) AS TIENNHAP, tblePhuTung.DONGIABAN, SUM(tblChiTietHDBanPT.SOLUONG) * tblePhuTung.DONGIABAN AS TIENBAN, SUM(tblChiTietHDBanPT.SOLUONG) * tblePhuTung.DONGIABAN - tblChiTietNhapPhuTung.DONGIANHAP * SUM(tblChiTietHDBanPT.SOLUONG) AS TIENLAI, tblTTPhuTung.DONVITINH FROM tblePhuTung INNER JOIN tblChiTietHDBanPT ON tblePhuTung.MAPT = tblChiTietHDBanPT.MAPT INNER JOIN tblHDBanPhuTung ON tblChiTietHDBanPT.MAHDBANPT = tblHDBanPhuTung.MAHDBANPT INNER JOIN tblChiTietNhapPhuTung ON tblePhuTung.MACTNPT = tblChiTietNhapPhuTung.MACTNPT INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT WHERE (YEAR(tblHDBanPhuTung.NGAYBAN) = {0}) GROUP BY tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, YEAR(tblHDBanPhuTung.NGAYBAN), tblChiTietHDBanPT.SOLUONG, tblePhuTung.DONGIABAN, tblChiTietNhapPhuTung.DONGIANHAP, tblTTPhuTung.DONVITINH", nam);
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


        public DataTable ThongKeNhapXeTheoKhoangThoiGian(string tuNgay, string denNgay)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblNhap.NGAYNHAP, tblTTXe.TENXE, tblTTXe.MAUXE, SUM(tblChiTietNhap.SOLUONG) AS SOLUONG, tblChiTietNhap.DONGIANHAP, SUM(tblChiTietNhap.SOLUONG) * tblChiTietNhap.DONGIANHAP AS THANHTIEN, tblChiTietNhap.DONVITINH, tblTTXe.DUNGTICH, tblNhanVien.TENNV, tblNhaCC.TENNHACC FROM tblTTXe INNER JOIN tblChiTietNhap ON tblTTXe.MATTXE = tblChiTietNhap.MATTXE INNER JOIN tblNhap ON tblChiTietNhap.MANHAP = tblNhap.MANHAP INNER JOIN tblNhaCC ON tblNhap.MANHACC = tblNhaCC.MANHACC INNER JOIN tblNhanVien ON tblNhap.MANV = tblNhanVien.MANV WHERE (tblNhap.NGAYNHAP BETWEEN CONVERT(date, '{0}', 103) AND CONVERT(date, '{1}', 103)) GROUP BY tblNhap.NGAYNHAP, tblTTXe.TENXE, tblTTXe.MAUXE, tblChiTietNhap.DONGIANHAP, tblNhaCC.TENNHACC, tblNhanVien.TENNV, tblTTXe.DUNGTICH, tblChiTietNhap.DONVITINH", tuNgay, denNgay);
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


        public DataTable ThongKeNhapPhuTungTheoKhoangThoiGian(string tuNgay, string denNgay)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblNhapPhuTung.NGAYNHAP, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, SUM(tblChiTietNhapPhuTung.SOLUONG) AS SOLUONG, tblChiTietNhapPhuTung.DONGIANHAP, SUM(tblChiTietNhapPhuTung.SOLUONG) * tblChiTietNhapPhuTung.DONGIANHAP AS THANHTIEN, tblNhaCC.TENNHACC, tblNhanVien.TENNV FROM tblNhaCC INNER JOIN tblNhapPhuTung ON tblNhaCC.MANHACC = tblNhapPhuTung.MANHACC INNER JOIN tblChiTietNhapPhuTung ON tblNhapPhuTung.MANPT = tblChiTietNhapPhuTung.MANPT INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT INNER JOIN tblNhanVien ON tblNhapPhuTung.MANV = tblNhanVien.MANV WHERE (tblNhapPhuTung.NGAYNHAP BETWEEN CONVERT(date, '{0}', 103) AND CONVERT(date, '{1}', 103)) GROUP BY tblNhapPhuTung.NGAYNHAP, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, tblChiTietNhapPhuTung.DONGIANHAP, tblTTPhuTung.DONVITINH, tblNhaCC.TENNHACC, tblNhanVien.TENNV", tuNgay, denNgay);
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

        public DataTable ThongKeBanXeTheoKhoangThoiGian(string tuNgay, string denNgay)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblHDBan.NGAYBAN, tblTTXe.TENXE, tblTTXe.MAUXE, tblTTXe.DUNGTICH, SUM(tblHDBan.SOLUONG) AS SOLUONG, SUM(tblHDBan.SOLUONG * tblXe.DONGIABAN + tblHDBan.THUEVAT * (tblHDBan.SOLUONG * tblXe.DONGIABAN) / 100) AS TIENBAN, SUM(tblChiTietNhap.DONGIANHAP) AS TIENNHAP, SUM(tblHDBan.SOLUONG * tblXe.DONGIABAN + tblHDBan.THUEVAT * (tblHDBan.SOLUONG * tblXe.DONGIABAN) / 100) - SUM(tblChiTietNhap.DONGIANHAP) AS TIENLAI FROM tblXe INNER JOIN tblHDBan ON tblXe.MAXE = tblHDBan.MAXE INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblHDBan.NGAYBAN BETWEEN CONVERT(date, '{0}', 103) AND CONVERT(date, '{1}', 103)) GROUP BY tblHDBan.NGAYBAN, tblTTXe.TENXE, tblChiTietNhap.DONGIANHAP, tblXe.DONGIABAN, tblHDBan.THUEVAT, tblHDBan.SOLUONG, tblTTXe.MAUXE, tblTTXe.DUNGTICH", tuNgay, denNgay);
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

        public DataTable ThongKeBanPhuTungTheoKhoangThoiGian(string tuNgay, string denNgay)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblHDBanPhuTung.NGAYBAN, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, SUM(tblChiTietHDBanPT.SOLUONG) AS SOLUONG, tblChiTietNhapPhuTung.DONGIANHAP, tblChiTietNhapPhuTung.DONGIANHAP * SUM(tblChiTietHDBanPT.SOLUONG) AS TIENNHAP, tblePhuTung.DONGIABAN, SUM(tblChiTietHDBanPT.SOLUONG) * tblePhuTung.DONGIABAN AS TIENBAN, SUM(tblChiTietHDBanPT.SOLUONG) * tblePhuTung.DONGIABAN - tblChiTietNhapPhuTung.DONGIANHAP * SUM(tblChiTietHDBanPT.SOLUONG) AS TIENLAI, tblTTPhuTung.DONVITINH FROM tblePhuTung INNER JOIN tblChiTietHDBanPT ON tblePhuTung.MAPT = tblChiTietHDBanPT.MAPT INNER JOIN tblHDBanPhuTung ON tblChiTietHDBanPT.MAHDBANPT = tblHDBanPhuTung.MAHDBANPT INNER JOIN tblChiTietNhapPhuTung ON tblePhuTung.MACTNPT = tblChiTietNhapPhuTung.MACTNPT INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT WHERE (tblHDBanPhuTung.NGAYBAN BETWEEN CONVERT(date, '{0}', 103) AND CONVERT(date, '{1}', 103)) GROUP BY tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblHDBanPhuTung.NGAYBAN, tblChiTietHDBanPT.SOLUONG, tblePhuTung.DONGIABAN, tblChiTietNhapPhuTung.DONGIANHAP, tblTTPhuTung.DONVITINH",tuNgay, denNgay);
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
