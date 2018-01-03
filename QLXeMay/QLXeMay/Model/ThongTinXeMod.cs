using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class ThongTinXeMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MATTXE, TENXE, MAUXE, DUNGTICH, HANGXE FROM tblTTXe";
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

        //Lấy Tên xe dựa vào mã xe
        public string GetTenXe(string ma)
        {
            cmd.CommandText = string.Format("SELECT TENXE FROM tblTTXe WHERE (MATTXE = '{0}')", ma);
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

        //Lấy Màu xe dựa vào mã xe
        public string GetMauXe(string ma)
        {
            cmd.CommandText = string.Format("SELECT MAUXE FROM tblTTXe WHERE (MATTXE = '{0}')", ma);
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

        //Lấy Dung tích dựa vào mã xe
        public string GetDungTich(string ma)
        {
            cmd.CommandText = string.Format("SELECT DUNGTICH FROM tblTTXe WHERE (MATTXE = '{0}')", ma);
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

        public bool AddData(ThongTinXeObj TTXeObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblTTXe (MATTXE, HANGXE, TENXE, MAUXE, DUNGTICH) VALUES ('{0}', N'{1}', N'{2}', N'{3}', {4})", TTXeObj.MaThongTinXe, TTXeObj.HangXe, TTXeObj.TenXe, TTXeObj.MauXe, TTXeObj.DungTich);
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

        public bool UpdateData(ThongTinXeObj TTXeObj)
        {
            cmd.CommandText = string.Format("UPDATE tblTTXe SET MATTXE = '{0}', HANGXE = N'{1}', TENXE = N'{2}', MAUXE = N'{3}', DUNGTICH = {4} WHERE (MATTXE = '{0}')", TTXeObj.MaThongTinXe, TTXeObj.HangXe, TTXeObj.TenXe, TTXeObj.MauXe, TTXeObj.DungTich);
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
            cmd.CommandText = string.Format("DELETE FROM tblTTXe WHERE (MATTXE = '{0}')", ma);
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
