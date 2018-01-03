using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class ChiTietNhapXeMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MACTN, MANHAP, MATTXE, DONGIANHAP, SOLUONG, DONVITINH FROM tblChiTietNhap";
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

        public bool AddData(ChiTietNhapXeObj CTNhapxObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblChiTietNhap (MACTN, MANHAP, MATTXE, DONGIANHAP, SOLUONG, DONVITINH) VALUES ('{0}', '{1}', '{2}', {3}, {4}, N'{5}')", CTNhapxObj.MaCTN, CTNhapxObj.MaNhap, CTNhapxObj.MaThongTinXe, CTNhapxObj.DonGia, CTNhapxObj.SoLuong, CTNhapxObj.DonViTinh);
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

        public bool UpdateData(ChiTietNhapXeObj CTNhapxObj)
        {
            cmd.CommandText = string.Format("UPDATE tblChiTietNhap SET MACTN = '{0}', MANHAP = '{1}', MATTXE = '{2}', DONGIANHAP = {3}, SOLUONG = {4}, DONVITINH = N'{5}' WHERE (MACTN = '{0}')", CTNhapxObj.MaCTN, CTNhapxObj.MaNhap, CTNhapxObj.MaThongTinXe, CTNhapxObj.DonGia, CTNhapxObj.SoLuong, CTNhapxObj.DonViTinh);
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
            cmd.CommandText = "DELETE FROM tblChiTietNhap WHERE (MACTN = '" + ma + "')";
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

        
        public DataTable GetDataChiTietThayDoi(string maNhap)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblChiTietNhap.MACTN, tblChiTietNhap.MANHAP, tblChiTietNhap.MATTXE, tblChiTietNhap.DONVITINH, tblTTXe.HANGXE, tblTTXe.TENXE, tblTTXe.MAUXE, tblChiTietNhap.DONGIANHAP, tblChiTietNhap.SOLUONG, tblTTXe.DUNGTICH FROM tblChiTietNhap INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblChiTietNhap.MANHAP = '{0}')", maNhap);
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

        public DataTable GetDataMaChiTiet()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblChiTietNhap.MACTN, tblChiTietNhap.MANHAP, tblTTXe.TENXE FROM tblChiTietNhap INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE ORDER BY tblChiTietNhap.MACTN DESC";
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

        //Xem toàn bộ chi tiết nhập của 1 nhân viên
        public DataTable GetDataChiTiet(string maNhanVien)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblChiTietNhap.MACTN, tblChiTietNhap.MANHAP, tblChiTietNhap.MATTXE, tblChiTietNhap.DONGIANHAP, tblChiTietNhap.SOLUONG, tblChiTietNhap.DONVITINH FROM tblChiTietNhap INNER JOIN tblNhap ON tblChiTietNhap.MANHAP = tblNhap.MANHAP INNER JOIN tblNhanVien ON tblNhap.MANV = tblNhanVien.MANV WHERE (tblNhap.MANV = '{0}')", maNhanVien);
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
