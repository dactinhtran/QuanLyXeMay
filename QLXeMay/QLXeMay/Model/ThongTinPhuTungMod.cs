using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLXeMay.Object;
using System.Data;
using System.Data.SqlClient;

namespace QLXeMay.Model
{
    class ThongTinPhuTungMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MATTPT, LOAIPT, TENPT, DONVITINH FROM tblTTPhuTung ORDER BY MATTPT DESC";
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

        public bool AddData(ThongTinPhuTungObj TTPTObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblTTPhuTung (MATTPT, LOAIPT, TENPT, DONVITINH)VALUES ('{0}', N'{1}', N'{2}', N'{3}')", TTPTObj.MaTTPT, TTPTObj.LoaiPT, TTPTObj.TenPT, TTPTObj.DonViTinh);
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

        public bool UpdateData(ThongTinPhuTungObj TTPTObj)
        {
            cmd.CommandText = string.Format("UPDATE tblTTPhuTung SET MATTPT = '{0}', LOAIPT = N'{1}', TENPT = N'{2}', DONVITINH = N'{3}' WHERE (MATTPT = '{0}')", TTPTObj.MaTTPT, TTPTObj.LoaiPT, TTPTObj.TenPT, TTPTObj.DonViTinh);
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
            cmd.CommandText = string.Format("DELETE FROM tblTTPhuTung WHERE (MATTPT = '{0}')", ma);
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

        //Lấy Loại phụ tùng dựa vào mã phụ tùng
        public string GetLoaiPhuTung(string ma)
        {
            cmd.CommandText = string.Format("SELECT LOAIPT FROM tblTTPhuTung WHERE (MATTPT = '{0}')", ma);
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

        //Lấy Tên phụ tùng dựa vào mã phụ tùng
        public string GetTenPhuTung(string ma)
        {
            cmd.CommandText = string.Format("SELECT TENPT FROM tblTTPhuTung WHERE (MATTPT = '{0}')", ma);
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

        //Lấy Đơn vị tính dựa vào mã phụ tùng
        public string GetDonViTinh(string ma)
        {
            cmd.CommandText = string.Format("SELECT DONVITINH FROM tblTTPhuTung WHERE (MATTPT = '{0}')", ma);
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
