using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class BaoHanhMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MABH, MAKH, THOIGIANBH, MAXE FROM tblBaoHanh";
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

        public DataTable GetAllDataChoGridControl()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblBaoHanh.MABH, tblBaoHanh.MAKH, tblKhachHang.TENKH, tblBaoHanh.MAXE, tblTTXe.TENXE, tblTTXe.MAUXE, tblXe.SOKHUNG, tblXe.SOMAY, tblBaoHanh.THOIGIANBH FROM tblChiTietNhap INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE INNER JOIN tblXe ON tblChiTietNhap.MACTN = tblXe.MACTN INNER JOIN tblBaoHanh INNER JOIN tblKhachHang ON tblBaoHanh.MAKH = tblKhachHang.MAKH ON tblXe.MAXE = tblBaoHanh.MAXE ORDER BY tblBaoHanh.MABH DESC";
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

        public bool AddData(BaoHanhObj BHObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblBaoHanh (MABH, MAKH, THOIGIANBH, MAXE) VALUES ('{0}', '{1}', {2}, '{3}')", BHObj.MaBaoHanh, BHObj.MaKH, BHObj.ThoiGianBaoHanh, BHObj.MaXe);
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


        public bool UpdateData(BaoHanhObj BHObj)
        {
            cmd.CommandText = string.Format("UPDATE tblBaoHanh SET MABH = '{0}', MAKH = '{1}', THOIGIANBH = {2}, MAXE = '{3}' WHERE (MABH = '{0}')", BHObj.MaBaoHanh, BHObj.MaKH, BHObj.ThoiGianBaoHanh, BHObj.MaXe);
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
            cmd.CommandText = string.Format("DELETE FROM tblBaoHanh WHERE (MABH = '{0}')", ma);
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
    }
}
