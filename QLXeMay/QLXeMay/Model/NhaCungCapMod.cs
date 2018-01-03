using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class NhaCungCapMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        //lấy toàn bộ dữ liệu
        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MANHACC, TENNHACC, DIACHI, DIENTHOAI, EMAIL FROM tblNhaCC";
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
        public bool AddData(NhaCungCapObj nccObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblNhaCC (MANHACC, TENNHACC, DIACHI, DIENTHOAI, EMAIL) VALUES ('{0}', N'{1}', N'{2}', '{3}', '{4}')", nccObj.MaNCC, nccObj.TenNCC, nccObj.DiaChi, nccObj.Sdt, nccObj.Email);
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

        //Sửa dữ liệu
        public bool UpdateData(NhaCungCapObj nccObj)
        {
            cmd.CommandText = string.Format("UPDATE tblNhaCC SET MANHACC = '{0}', TENNHACC = N'{1}', DIACHI = N'{2}', DIENTHOAI = '{3}', EMAIL = '{4}' WHERE (MANHACC = '{0}')", nccObj.MaNCC, nccObj.TenNCC, nccObj.DiaChi, nccObj.Sdt, nccObj.Email);
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
            cmd.CommandText = string.Format("DELETE FROM tblNhaCC WHERE (MANHACC = N'{0}')", ma);
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

        //lấy mã nhà cung cấp
        public DataTable GetDataMa()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MANHACC FROM tblNhaCC";
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
            cmd.CommandText = "SELECT MANHACC, TENNHACC FROM tblNhaCC";
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

        //lấy tên nhà cung cấp từ mã nhà cung cấp
        public string TenNhaCungCap(string ma)
        {
            cmd.CommandText = string.Format("SELECT TENNHACC FROM tblNhaCC WHERE (MANHACC = '{0}')", ma);
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
            return "";
        }
    }
}
