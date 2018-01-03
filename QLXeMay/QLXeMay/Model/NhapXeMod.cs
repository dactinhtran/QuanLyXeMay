using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class NhapXeMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MANHAP, MANV, MANHACC, NGAYNHAP FROM tblNhap ORDER BY MANHAP DESC";
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

        public DataTable GetAllDataToDay()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MANHAP, MANV, MANHACC, NGAYNHAP FROM tblNhap WHERE (NGAYNHAP = { fn CURDATE() })";
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

        public bool AddData(NhapXeObj nhapxObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblNhap (MANHAP, MANV, MANHACC, NGAYNHAP) VALUES ('{0}', '{1}', '{2}', CONVERT(date, '{3}', 103))", nhapxObj.MaNhap, nhapxObj.MaNV, nhapxObj.MaNhaCC, nhapxObj.NgayNhap);
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

        public bool UpdateData(NhapXeObj nhapxObj)
        {
            cmd.CommandText = string.Format("UPDATE tblNhap SET MANHAP = '{0}', MANV = '{1}', MANHACC = '{2}', NGAYNHAP = CONVERT(date, '{3}', 103) WHERE (MANHAP = '{0}')", nhapxObj.MaNhap, nhapxObj.MaNV, nhapxObj.MaNhaCC, nhapxObj.NgayNhap);
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
            cmd.CommandText = "DELETE FROM tblNhap WHERE (MANHAP = '" + ma + "')";
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

        public DataTable GetDataMa()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MANHAP FROM tblNhap";
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

        public DataTable GetAllDataPrint(string ma)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblNhap.MANHAP, tblTTXe.TENXE, tblChiTietNhap.DONGIANHAP, tblChiTietNhap.SOLUONG, tblChiTietNhap.DONVITINH, tblChiTietNhap.DONGIANHAP * tblChiTietNhap.SOLUONG AS THANHTIEN, tblNhaCC.TENNHACC, tblNhaCC.DIACHI, tblNhaCC.DIENTHOAI, tblNhaCC.EMAIL, tblNhap.NGAYNHAP, tblNhanVien.TENNV, tblTTXe.MAUXE, tblTTXe.DUNGTICH, tblTTXe.HANGXE FROM tblNhaCC INNER JOIN tblNhap ON tblNhaCC.MANHACC = tblNhap.MANHACC INNER JOIN tblChiTietNhap ON tblNhap.MANHAP = tblChiTietNhap.MANHAP INNER JOIN tblNhanVien ON tblNhap.MANV = tblNhanVien.MANV INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblNhap.MANHAP = '{0}')", ma);
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

        public DataTable GetDataChiTiet(string ma)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT MANHAP, MANV, MANHACC, NGAYNHAP FROM tblNhap WHERE (MANV = '{0}') ORDER BY MANHAP DESC", ma);
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
