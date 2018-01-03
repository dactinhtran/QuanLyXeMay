using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class ChiTietNhapPhuTungMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MACTNPT, MANPT, MATTPT, DONGIANHAP, SOLUONG FROM tblChiTietNhapPhuTung";
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

        public bool AddData(ChiTietNhapPhuTungObj CTNhapPTObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblChiTietNhapPhuTung (MACTNPT, MANPT, MATTPT, DONGIANHAP, SOLUONG) VALUES ('{0}', '{1}', '{2}', {3}, {4})", CTNhapPTObj.MaCTNhapPT, CTNhapPTObj.MaNhapPT, CTNhapPTObj.MaTTPT, CTNhapPTObj.DonGiaNhap, CTNhapPTObj.SoLuong); 
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

        public bool UpdateData(ChiTietNhapPhuTungObj CTNhapPTObj)
        {
            cmd.CommandText = string.Format("UPDATE tblChiTietNhapPhuTung SET MACTNPT = '{0}', MANPT = '{1}', MATTPT = '{2}', DONGIANHAP = {3}, SOLUONG = {4} WHERE (MACTNPT = '{0}')", CTNhapPTObj.MaCTNhapPT, CTNhapPTObj.MaNhapPT, CTNhapPTObj.MaTTPT, CTNhapPTObj.DonGiaNhap, CTNhapPTObj.SoLuong);
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
            cmd.CommandText = "DELETE FROM tblChiTietNhapPhuTung WHERE (MACTNPT = '" + ma + "')";
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
            cmd.CommandText = "SELECT MACTNPT FROM tblChiTietNhapPhuTung";
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

        public DataTable GetAllDataUCNhapPT()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblChiTietNhapPhuTung.MACTNPT, tblChiTietNhapPhuTung.MANPT, tblNhapPhuTung.NGAYNHAP, tblChiTietNhapPhuTung.MATTPT, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblChiTietNhapPhuTung.DONGIANHAP, tblChiTietNhapPhuTung.SOLUONG FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT INNER JOIN tblNhapPhuTung ON tblChiTietNhapPhuTung.MANPT = tblNhapPhuTung.MANPT";
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

        public DataTable GetAllDataUCNhapPTMaNhapPTThayDoi(string maNhap)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblChiTietNhapPhuTung.MACTNPT, tblChiTietNhapPhuTung.MANPT, tblChiTietNhapPhuTung.MATTPT, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, tblChiTietNhapPhuTung.DONGIANHAP, tblChiTietNhapPhuTung.SOLUONG, tblChiTietNhapPhuTung.DONGIANHAP * tblChiTietNhapPhuTung.SOLUONG AS THANHTIEN FROM tblChiTietNhapPhuTung INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT WHERE (tblChiTietNhapPhuTung.MANPT = '{0}')", maNhap);
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

        public DataTable GetAllDataDanhSachChiTiet(string maNhapPT)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblChiTietHDBanPT.MACTHDBANPT, tblChiTietHDBanPT.MAPT, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblChiTietNhapPhuTung.DONGIANHAP, tblTTPhuTung.DONVITINH FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT INNER JOIN tblePhuTung ON tblChiTietNhapPhuTung.MACTNPT = tblePhuTung.MACTNPT INNER JOIN tblChiTietHDBanPT ON tblePhuTung.MAPT = tblChiTietHDBanPT.MAPT WHERE (tblChiTietHDBanPT.MAHDBANPT = '{0}')", maNhapPT);
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
