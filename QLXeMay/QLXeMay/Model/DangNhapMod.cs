using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class DangNhapMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        //Lấy dữ liệu kiểm tra tên đăng nhập và mật khẩu
        public DataTable GetDangNhapData(string tenDN, string matKhau)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT MADN, MANV, TENDN, MATKHAU, QUYENTC FROM tbleDangNhap WHERE (TENDN = '{0}') AND (MATKHAU = '{1}')", tenDN, matKhau);
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

        //Lấy toàn bộ dữ liệu
        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MADN, MANV, TENDN, MATKHAU, QUYENTC FROM tbleDangNhap";
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

        //Thêm dữ liệu
        public bool AddData(DangNhapObj dnObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tbleDangNhap (MADN, MANV, TENDN, MATKHAU, QUYENTC) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", dnObj.MaDN, dnObj.MaNV, dnObj.TenDN, dnObj.MatKhau, dnObj.QuyenTC);
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

        //Sửa dữ liệu
        public bool UpdateData(DangNhapObj dnObj)
        {
            cmd.CommandText = string.Format("UPDATE tbleDangNhap SET MADN = '{0}', MANV = '{1}', TENDN = '{2}', MATKHAU = '{3}', QUYENTC = '{4}' WHERE (MADN = '{0}')", dnObj.MaDN, dnObj.MaNV, dnObj.TenDN, dnObj.MatKhau, dnObj.QuyenTC);
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

        //Xóa dữ liệu
        public bool DeleteData(string ma)
        {
            cmd.CommandText = string.Format("DELETE FROM tbleDangNhap WHERE (MADN = '{0}')", ma);
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

        //Lấy toàn bộ dữ liệu
        public DataTable GetFullData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tbleDangNhap.MADN, tbleDangNhap.MANV, tblNhanVien.TENNV, tblNhanVien.CHUCVU, tbleDangNhap.TENDN, tbleDangNhap.MATKHAU, tbleDangNhap.QUYENTC FROM tblNhanVien INNER JOIN tbleDangNhap ON tblNhanVien.MANV = tbleDangNhap.MANV";
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
