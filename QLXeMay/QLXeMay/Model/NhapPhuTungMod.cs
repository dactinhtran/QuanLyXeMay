using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLXeMay.Object;
using System.Data;
using System.Data.SqlClient;

namespace QLXeMay.Model
{
    class NhapPhuTungMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MANPT, MANHACC, MANV, NGAYNHAP FROM tblNhapPhuTung";
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

        public bool AddData(NhapPhuTungObj NhapPTObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblNhapPhuTung (MANPT, MANHACC, MANV, NGAYNHAP) VALUES ('{0}', '{1}', '{2}', CONVERT(date, '{3}', 103))", NhapPTObj.MaNhapPhuTung, NhapPTObj.MaNhaCungCap, NhapPTObj.MaNV, NhapPTObj.NgayNhap);
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

        public bool UpdateData(NhapPhuTungObj NhapPTObj)
        {
            cmd.CommandText = string.Format("UPDATE tblNhapPhuTung SET MANPT = '{0}', MANHACC = '{1}', MANV = '{2}', NGAYNHAP = CONVERT(date, '{3}', 103) WHERE (MANPT = '{0}')", NhapPTObj.MaNhapPhuTung, NhapPTObj.MaNhaCungCap, NhapPTObj.MaNV, NhapPTObj.NgayNhap);
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
            cmd.CommandText = "DELETE FROM tblNhapPhuTung WHERE (MANPT = '" + ma + "')";
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
            cmd.CommandText = "SELECT MANPT FROM tblNhapPhuTung";
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

        public DataTable GetAllDataPrint(string maNhapPT)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblNhaCC.TENNHACC, tblNhaCC.DIACHI, tblNhaCC.DIENTHOAI, tblNhanVien.TENNV, tblNhapPhuTung.MANPT, tblNhapPhuTung.NGAYNHAP, tblChiTietNhapPhuTung.DONGIANHAP, tblChiTietNhapPhuTung.SOLUONG, tblTTPhuTung.DONVITINH, tblTTPhuTung.TENPT, tblNhaCC.EMAIL,  tblChiTietNhapPhuTung.DONGIANHAP * tblChiTietNhapPhuTung.SOLUONG AS THANHTIEN, tblTTPhuTung.LOAIPT FROM tblNhaCC INNER JOIN tblNhapPhuTung ON tblNhaCC.MANHACC = tblNhapPhuTung.MANHACC INNER JOIN tblChiTietNhapPhuTung ON tblNhapPhuTung.MANPT = tblChiTietNhapPhuTung.MANPT INNER JOIN tblNhanVien ON tblNhapPhuTung.MANV = tblNhanVien.MANV INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT WHERE (tblNhapPhuTung.MANPT = '{0}')", maNhapPT);
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
