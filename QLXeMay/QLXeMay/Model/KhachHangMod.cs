using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;
using System.Windows.Forms;

namespace QLXeMay.Model
{
    class KhachHangMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        //Lấy toàn bộ dữ liệu
        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MAKH, TENKH, NGAYSINH, GIOITINH, SOCMND, DIACHI, SDT FROM tblKhachHang";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            
            //Lấy dữ liệu về
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
        public bool AddData(KhachHangObj khObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblKhachHang (MAKH, TENKH, NGAYSINH, GIOITINH, SOCMND, DIACHI, SDT) VALUES ('{0}', N'{1}', CONVERT(date, '{2}', 103), N'{3}', '{4}', N'{5}', '{6}')", khObj.MaKH, khObj.TenKH, khObj.NgaySinh, khObj.GioiTinh, khObj.SoCMND, khObj.DiaChi, khObj.Sdt);
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

        //Cập nhật dữ liệu
        public bool UpdateData(KhachHangObj khObj)
        {
            cmd.CommandText = string.Format("UPDATE tblKhachHang SET MAKH = N'{0}', TENKH = N'{1}', NGAYSINH = CONVERT(date, '{2}', 103), GIOITINH = N'{3}', SOCMND = N'{4}', DIACHI = N'{5}', SDT = N'{6}' WHERE (MAKH = '{0}')", khObj.MaKH, khObj.TenKH, khObj.NgaySinh, khObj.GioiTinh, khObj.SoCMND, khObj.DiaChi, khObj.Sdt);
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
            cmd.CommandText = string.Format("DELETE FROM tblKhachHang WHERE (MAKH = N'{0}')", ma);
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

        //Lấy dữ liệu khi tìm kiếm
        public DataTable GetAllDataSearch(string timKiemKhachHang)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT MAKH, TENKH, NGAYSINH, GIOITINH, SOCMND, DIACHI, SDT FROM tblKhachHang WHERE ({0})", timKiemKhachHang);
                //(TENKH LIKE N'%Nguyễn%')

            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            //Lấy dữ liệu về
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
            cmd.CommandText = "SELECT MAKH FROM tblKhachHang";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            //Lấy dữ liệu về
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

        public DataTable GetDataMaTen()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MAKH, TENKH FROM tblKhachHang";

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

        public DataTable GetAllDataMaTenCMND()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MAKH, TENKH, SOCMND FROM tblKhachHang";

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

        //Lấy tên khách hàng dựa vào mã khách hàng
        public string GetTenKhachHang(string ma)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT TENKH FROM tblKhachHang WHERE (MAKH = '{0}')", ma);
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
    }
}
