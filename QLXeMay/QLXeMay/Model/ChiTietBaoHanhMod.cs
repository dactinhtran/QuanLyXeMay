using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class ChiTietBaoHanhMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MACTBH, MABH, MANV, CONGVIEC, SOKM FROM tblChiTietBaoHanh";
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

        public bool AddData(ChiTietBaoHanhObj CTBHObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblChiTietBaoHanh (MACTBH, MABH, MANV, CONGVIEC, SOKM) VALUES ('{0}', '{1}', '{2}', N'{3}', {4})", CTBHObj.MaChiTietBaoHanh, CTBHObj.MaBaoHanh, CTBHObj.MaNV, CTBHObj.CongViec, CTBHObj.SoKM);
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

        public bool UpdateData(ChiTietBaoHanhObj CTBHObj)
        {
            cmd.CommandText = string.Format("UPDATE tblChiTietBaoHanh SET MACTBH = '{0}', MABH = '{1}', MANV = '{2}', CONGVIEC = N'{3}', SOKM = {4} WHERE  (MACTBH = '{0}')", CTBHObj.MaChiTietBaoHanh, CTBHObj.MaBaoHanh, CTBHObj.MaNV, CTBHObj.CongViec, CTBHObj.SoKM);
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
            cmd.CommandText = "DELETE FROM tblChiTietBaoHanh WHERE (MACTBH = '" + ma + "')";
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

        //Lấy dữ liệu khi lueMaBHThayDoi
        public DataTable GetDataMalueMaBHThayDoi(string maBH)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblChiTietBaoHanh.MACTBH, tblChiTietBaoHanh.MABH, tblChiTietBaoHanh.MANV, tblNhanVien.TENNV, tblChiTietBaoHanh.CONGVIEC, tblChiTietBaoHanh.SOKM FROM tblChiTietBaoHanh INNER JOIN tblNhanVien ON tblChiTietBaoHanh.MANV = tblNhanVien.MANV WHERE (tblChiTietBaoHanh.MABH = '{0}')", maBH);
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
