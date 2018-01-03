using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class NhanVienMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        //lấy toàn bộ dữ liệu
        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MANV, TENNV, NGAYSINH, GIOITINH, SOCMND, LUONGCOBAN, CHUCVU, DIACHI, SDT FROM tblNhanVien";
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
        public bool AddData(NhanVienObj nvObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblNhanVien (MANV, TENNV, NGAYSINH, GIOITINH, SOCMND, LUONGCOBAN, CHUCVU, DIACHI, SDT) VALUES ('{0}', N'{1}', CONVERT(DATE, '{2}', 103), N'{3}', '{4}', {5}, N'{6}', N'{7}', '{8}')", nvObj.Manv, nvObj.Tennv, nvObj.NgaySinh, nvObj.GioiTinh, nvObj.SoCMND, nvObj.LuongCoBan, nvObj.ChucVu, nvObj.DiaChi, nvObj.Sdt);
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
        public bool UpdateData(NhanVienObj nvObj)
        {
            cmd.CommandText = string.Format("UPDATE tblNhanVien SET MANV = '{0}', TENNV = N'{1}', NGAYSINH = CONVERT(date, '{2}', 103), GIOITINH = N'{3}', SOCMND = '{4}', LUONGCOBAN = {5}, CHUCVU = N'{6}', DIACHI = N'{7}', SDT = '{8}' WHERE (MANV = '{0}')", nvObj.Manv, nvObj.Tennv, nvObj.NgaySinh, nvObj.GioiTinh, nvObj.SoCMND, nvObj.LuongCoBan, nvObj.ChucVu, nvObj.DiaChi, nvObj.Sdt);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            //Lấy dữ liệu về
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
            cmd.CommandText = string.Format("DELETE FROM tblNhanVien WHERE (MANV = N'{0}')", ma);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            //Lấy dữ liệu về
            try
            {
                con.openCon();
                //Xếp xuống
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

        //lấy dữ liệu tìm kiếm
        public DataTable GetDataSearch(string timKiemNhanVien)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT MANV, TENNV, NGAYSINH, GIOITINH, SOCMND, LUONGCOBAN, CHUCVU, DIACHI, SDT FROM tblNhanVien WHERE {0}", timKiemNhanVien);
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

        public DataTable GetDataMa()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MANV FROM tblNhanVien";
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

        //Lấy mã tên nhân viên
        public DataTable GetDataMaTen()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MANV, TENNV FROM tblNhanVien";
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

        //Lấy tên nhân viên từ bảng nhân viên
        public string GetTenNV(string ma)
        {
            cmd.CommandText = string.Format("SELECT TENNV FROM tblNhanVien WHERE (MANV = '{0}')", ma);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.openCon();
                var value = cmd.ExecuteScalar();
                con.closeCon();
                return value.ToString();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }
            return string.Empty;
        }

        //Lấy manv không nằm trong đăng nhập UCThemTKDangNhap
        public DataTable GetMaTenChucVuUCThemDangNhap()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MANV, TENNV, CHUCVU FROM tblNhanVien WHERE (MANV NOT IN (SELECT MANV FROM tbleDangNhap))";
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

        //Lấy chức vụ nhân viên từ bảng nhân viên
        public string GetChucVuNV(string ma)
        {
            cmd.CommandText = string.Format("SELECT CHUCVU FROM tblNhanVien WHERE (MANV = '{0}')", ma);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.openCon();
                var value = cmd.ExecuteScalar();
                con.closeCon();
                return value.ToString();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.closeCon();
            }
            return string.Empty;
        }
    }
}
