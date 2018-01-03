using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class ChiTietHoaDonBanPhuTungMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MACTHDBANPT, MAHDBANPT, MAPT, SOLUONG FROM tblChiTietHDBanPT";
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

        public bool AddData(ChiTietHoaDonBanPhuTungObj chiTietHDBanPTObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblChiTietHDBanPT (MACTHDBANPT, MAHDBANPT, MAPT, SOLUONG) VALUES ('{0}', '{1}', '{2}', {3})", chiTietHDBanPTObj.MaChiTietHoaDonBanPhuTung, chiTietHDBanPTObj.MaHoaDonBanPhuTung, chiTietHDBanPTObj.MaPhuTung, chiTietHDBanPTObj.SoLuong);
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

        public bool UpdateData(ChiTietHoaDonBanPhuTungObj chiTietHDBanPTObj)
        {
            cmd.CommandText = string.Format("UPDATE tblChiTietHDBanPT SET MACTHDBANPT = '{0}', MAHDBANPT = '{1}', MAPT = '{2}', SOLUONG = {3} WHERE (MACTHDBANPT = '{4}')", chiTietHDBanPTObj.MaChiTietHoaDonBanPhuTung, chiTietHDBanPTObj.MaHoaDonBanPhuTung, chiTietHDBanPTObj.MaPhuTung, chiTietHDBanPTObj.SoLuong);
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
            cmd.CommandText = "DELETE FROM tblChiTietHDBanPT WHERE (MACTHDBANPT = '" + ma + "')";
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

        //Lấy MaCTHDBPT từ MAPT
        public string GetMaCTHoaDonBanPTTuMaPT(string mapt)
        {
            cmd.CommandText = string.Format("SELECT MACTHDBANPT FROM tblChiTietHDBanPT WHERE (MAPT = '{0}')", mapt);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.openCon();
                var value = cmd.ExecuteScalar();
                con.closeCon();
                return value.ToString().Trim();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }

            return "";
        }

        //Lấy mã chi tiết hóa đơn bán phụ tùng từ mã hóa đơn bán phụ tùng
        public DataTable GetMaCTHoaDonBanPTTuMaHDBanPT(string mahdBanPT)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT MACTHDBANPT FROM tblChiTietHDBanPT WHERE (MAHDBANPT = '{0}')", mahdBanPT);
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
            cmd.CommandText = string.Format("SELECT tblChiTietHDBanPT.MACTHDBANPT, tblChiTietHDBanPT.MAPT, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblePhuTung.DONGIABAN, tblTTPhuTung.DONVITINH FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT INNER JOIN tblePhuTung ON tblChiTietNhapPhuTung.MACTNPT = tblePhuTung.MACTNPT INNER JOIN tblChiTietHDBanPT ON tblePhuTung.MAPT = tblChiTietHDBanPT.MAPT WHERE (tblChiTietHDBanPT.MAHDBANPT = '{0}')", maNhapPT);
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
