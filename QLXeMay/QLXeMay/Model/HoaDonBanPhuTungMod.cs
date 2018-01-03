using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class HoaDonBanPhuTungMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MAHDBANPT, MAKH, MANV, NGAYBAN FROM tblHDBanPhuTung";
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

        public bool AddData(HoaDonBanPhuTungObj HDBanPhuTungObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblHDBanPhuTung (MAHDBANPT, MAKH, MANV, NGAYBAN) VALUES ('{0}', '{1}', '{2}', CONVERT(date, '{3}', 103))", HDBanPhuTungObj.MaHoaDonBanPhuTung, HDBanPhuTungObj.MaKH, HDBanPhuTungObj.MaNV, HDBanPhuTungObj.NgayBan);
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

        public bool UpdateData(HoaDonBanPhuTungObj HDBanPhuTungObj)
        {
            cmd.CommandText = string.Format("UPDATE tblHDBanPhuTung SET MAHDBANPT = '{0}', MAKH = '{1}', MANV = '{2}', NGAYBAN = CONVERT(date, '{3}', 103) WHERE (MAHDBANPT = '{0}')", HDBanPhuTungObj.MaHoaDonBanPhuTung, HDBanPhuTungObj.MaKH, HDBanPhuTungObj.MaNV, HDBanPhuTungObj.NgayBan);
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
            cmd.CommandText = "DELETE FROM tblHDBanPhuTung WHERE (MAHDBANPT = '" + ma + "')";
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

        public DataTable GetAllDataPrint(string maHoaDonBanPT)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblHDBanPhuTung.MAHDBANPT, tblHDBanPhuTung.NGAYBAN, tblNhanVien.TENNV, tblKhachHang.TENKH, SUM(tblChiTietHDBanPT.SOLUONG) AS SOLUONG, tblePhuTung.DONGIABAN, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, SUM(tblChiTietHDBanPT.SOLUONG) * tblePhuTung.DONGIABAN AS THANHTIEN FROM tblNhanVien INNER JOIN tblHDBanPhuTung ON tblNhanVien.MANV = tblHDBanPhuTung.MANV INNER JOIN tblKhachHang ON tblHDBanPhuTung.MAKH = tblKhachHang.MAKH INNER JOIN tblChiTietHDBanPT ON tblHDBanPhuTung.MAHDBANPT = tblChiTietHDBanPT.MAHDBANPT INNER JOIN tblePhuTung ON tblChiTietHDBanPT.MAPT = tblePhuTung.MAPT INNER JOIN tblChiTietNhapPhuTung ON tblePhuTung.MACTNPT = tblChiTietNhapPhuTung.MACTNPT INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT WHERE (tblHDBanPhuTung.MAHDBANPT = '{0}') GROUP BY tblHDBanPhuTung.MAHDBANPT, tblHDBanPhuTung.NGAYBAN, tblNhanVien.TENNV, tblKhachHang.TENKH, tblePhuTung.DONGIABAN, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, tblChiTietHDBanPT.SOLUONG", maHoaDonBanPT);
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

        public DataTable GetDataDanhSachHoaDon()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblHDBanPhuTung.MAHDBANPT, tblHDBanPhuTung.MAKH, tblKhachHang.TENKH, tblHDBanPhuTung.NGAYBAN FROM tblHDBanPhuTung INNER JOIN tblKhachHang ON tblHDBanPhuTung.MAKH = tblKhachHang.MAKH ORDER BY tblHDBanPhuTung.MAHDBANPT DESC";
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
