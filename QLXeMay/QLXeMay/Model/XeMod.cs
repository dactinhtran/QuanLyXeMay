using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class XeMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        //Lấy toàn bộ dữ liệu
        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblXe.MAXE, tblXe.MACTN, tblXe.SOKHUNG, tblXe.SOMAY, tblXe.DONGIABAN, tblXe.NAMSANXUAT, tblTTXe.HANGXE, tblTTXe.TENXE, tblTTXe.MAUXE FROM tblXe INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE"; 
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
        public bool AddData(XeObj xeObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblXe (MAXE, MACTN, SOKHUNG, SOMAY, DONGIABAN, NAMSANXUAT) VALUES ('{0}', '{1}', '{2}', '{3}', {4}, {5})", xeObj.MaXe, xeObj.MaCTN, xeObj.SoKhung, xeObj.SoMay, xeObj.DonGiaban, xeObj.NamSX);
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
        public bool UpdateData(XeObj xeObj)
        {
            cmd.CommandText = string.Format("UPDATE tblXe SET MAXE = '{0}', MACTN = '{1}', SOKHUNG = '{2}', SOMAY = '{3}', DONGIABAN = {4}, NAMSANXUAT = {5} WHERE (MAXE = '{0}')", xeObj.MaXe, xeObj.MaCTN, xeObj.SoKhung, xeObj.SoMay, xeObj.DonGiaban, xeObj.NamSX);
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
            cmd.CommandText = string.Format("DELETE FROM tblXe WHERE (MAXE = '{0}')", ma);
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

        //Dữ liệu tìm kiếm xe đã nhập
        public DataTable TimKiemXeDaNhap(string tkXeDaNhap)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblTTXe.TENXE, tblTTXe.MAUXE, tblChiTietNhap.SOLUONG, tblChiTietNhap.DONGIANHAP, tblNhap.NGAYNHAP, tblNhaCC.TENNHACC, tblNhanVien.TENNV, tblTTXe.DUNGTICH, tblChiTietNhap.DONVITINH FROM tblChiTietNhap INNER JOIN tblNhap ON tblChiTietNhap.MANHAP = tblNhap.MANHAP INNER JOIN tblNhaCC ON tblNhap.MANHACC = tblNhaCC.MANHACC INNER JOIN tblNhanVien ON tblNhap.MANV = tblNhanVien.MANV INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE ({0})", tkXeDaNhap);
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

        //Dữ liệu tìm kiếm xe đã bán
        public DataTable TimKiemXeDaBan(string tkXeDaBan)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblXe.MAXE, tblTTXe.TENXE, tblTTXe.MAUXE, tblXe.SOKHUNG, tblXe.NAMSANXUAT, tblXe.DONGIABAN, tblHDBan.THUEVAT, tblXe.DONGIABAN + tblXe.DONGIABAN * tblHDBan.THUEVAT / 100 AS THANHTIEN, tblHDBan.NGAYBAN, tblKhachHang.TENKH, tblNhanVien.TENNV FROM tblXe INNER JOIN tblHDBan ON tblXe.MAXE = tblHDBan.MAXE INNER JOIN tblNhanVien ON tblHDBan.MANV = tblNhanVien.MANV INNER JOIN tblKhachHang ON tblHDBan.MAKH = tblKhachHang.MAKH INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE ({0})", tkXeDaBan);
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

        //Lấy dữ liệu tìm kiếm xe có trong cửa hàng
        public DataTable TimKiemXeCoTrongCuaHang(string tkXeCoTrongCuaHang)
        {
            DataTable dt = new DataTable(); 
            cmd.CommandText = string.Format("SELECT tblXe.MAXE, tblTTXe.TENXE, tblTTXe.MAUXE, tblXe.SOKHUNG, tblXe.SOMAY, tblTTXe.DUNGTICH, tblXe.NAMSANXUAT, tblXe.DONGIABAN FROM tblXe INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblNhap ON tblChiTietNhap.MANHAP = tblNhap.MANHAP INNER JOIN tblNhaCC ON tblNhap.MANHACC = tblNhaCC.MANHACC INNER JOIN tblNhanVien ON tblNhap.MANV = tblNhanVien.MANV INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblXe.MAXE NOT IN (SELECT MAXE FROM tblHDBan)) AND ({0})", tkXeCoTrongCuaHang);
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

        public DataTable XeCoTrongCuaHang()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblXe.MAXE, tblTTXe.TENXE, tblTTXe.HANGXE, tblTTXe.MAUXE, tblXe.SOKHUNG, tblXe.SOMAY, tblTTXe.DUNGTICH, tblXe.NAMSANXUAT, tblXe.DONGIABAN FROM tblXe INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblNhap ON tblChiTietNhap.MANHAP = tblNhap.MANHAP INNER JOIN tblNhaCC ON tblNhap.MANHACC = tblNhaCC.MANHACC INNER JOIN tblNhanVien ON tblNhap.MANV = tblNhanVien.MANV INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblXe.MAXE NOT IN (SELECT MAXE FROM tblHDBan))";
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
            cmd.CommandText = "SELECT MAXE FROM tblXe";
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


        public DataTable GetDataMaSoLuongXeNhanVienDaNhap()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblChiTietNhap.MACTN, tblChiTietNhap.SOLUONG, tblTTXe.HANGXE, tblTTXe.TENXE, tblTTXe.MAUXE, tblTTXe.DUNGTICH, tblChiTietNhap.DONGIANHAP FROM tblChiTietNhap INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE ORDER BY tblChiTietNhap.MACTN";
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

        public DataTable GetDataMaSoLuongXeTrongCuahang()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblChiTietNhap.MACTN, tblChiTietNhap.SOLUONG, tblTTXe.HANGXE, tblTTXe.TENXE, tblTTXe.MAUXE, tblTTXe.DUNGTICH, tblChiTietNhap.DONGIANHAP FROM tblChiTietNhap INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE INNER JOIN tblXe ON tblChiTietNhap.MACTN = tblXe.MACTN GROUP BY tblTTXe.TENXE, tblChiTietNhap.SOLUONG, tblChiTietNhap.MACTN, tblTTXe.HANGXE, tblTTXe.MAUXE, tblTTXe.DUNGTICH, tblChiTietNhap.DONGIANHAP HAVING (COUNT(tblChiTietNhap.MACTN) = tblChiTietNhap.SOLUONG) ORDER BY tblChiTietNhap.MACTN";
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

        public DataTable GetAllDataMaTenMau()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblXe.MAXE, tblTTXe.TENXE, tblTTXe.MAUXE FROM tblXe INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE";
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

        public DataTable GetAllDataUCXe()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblXe.MAXE, tblXe.MACTN, tblXe.SOKHUNG, tblXe.SOMAY, tblXe.DONGIABAN, tblXe.NAMSANXUAT, tblTTXe.HANGXE, tblTTXe.TENXE, tblTTXe.MAUXE FROM tblXe INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblXe.MAXE NOT IN (SELECT MAXE FROM tblHDBan))";
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

        //Tổng số xe chưa bán có trong cửa hàng, dùng trong ucHoaDon
        public DataTable GetDataXeTrongCuaHangUCHoaDon()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblXe.MAXE, tblTTXe.TENXE, tblTTXe.MAUXE, tblXe.SOKHUNG, tblXe.SOMAY, tblXe.DONGIABAN, tblXe.NAMSANXUAT, tblTTXe.HANGXE FROM tblXe INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblXe.MAXE NOT IN (SELECT MAXE FROM tblHDBan))";
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

        //Lấy tên xe dựa vào MAXE dùng trong ucHoaDonBanXe
        public string GetTenXe(string ma)
        {
            cmd.CommandText = string.Format("SELECT tblTTXe.TENXE FROM tblXe INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblXe.MAXE = '{0}')", ma);
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
            return string.Empty;
        }

        //Lấy đon giá bán xe dựa vào MAXE dùng trong ucHoaDonBanXe
        public string GetDonGiaBanXe(string ma)
        {
            cmd.CommandText = string.Format("SELECT  tblXe.DONGIABAN FROM tblXe INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblXe.MAXE = '{0}')", ma);
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
            return string.Empty;
        }

        //Lấy màu xe theo mã xe
        public string GetMauXe(string ma)
        {
            cmd.CommandText = string.Format("SELECT tblTTXe.MAUXE FROM tblXe INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblXe.MAXE = '{0}')", ma);
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
            return string.Empty;
        }

        //Lấy tên xe dựa vào MACTN dùng trong ucXe
        public string GetTenXeUCXe(string ma)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblTTXe.TENXE FROM tblTTXe INNER JOIN tblChiTietNhap ON tblTTXe.MATTXE = tblChiTietNhap.MATTXE WHERE (tblChiTietNhap.MACTN = '{0}')", ma);
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
            return string.Empty;
        }

        //Lấy màu xe dựa vào MACTN dùng trong ucXe
        public string GetMauXeUCXe(string ma)
        {
            cmd.CommandText = string.Format("SELECT tblTTXe.MAUXE FROM tblTTXe INNER JOIN tblChiTietNhap ON tblTTXe.MATTXE = tblChiTietNhap.MATTXE WHERE (tblChiTietNhap.MACTN = '{0}')", ma);
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
            return string.Empty;
        }

        //Lấy dung tích dựa vào MACTN dùng trong ucXe
        public string GetDungTichUCXe(string ma)
        {
            cmd.CommandText = string.Format("SELECT tblTTXe.DUNGTICH FROM tblTTXe INNER JOIN tblChiTietNhap ON tblTTXe.MATTXE = tblChiTietNhap.MATTXE WHERE (tblChiTietNhap.MACTN = '{0}')", ma);
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
            return string.Empty;
        }

        ////Xe máy chưa đăng ký bảo hành
        //public DataTable GetXeChuaBaoDangKyBaoHanh()
        //{
        //    DataTable dt = new DataTable();
        //    cmd.CommandText = "SELECT tblXe.MAXE, tblTTXe.TENXE, tblTTXe.MAUXE, tblXe.SOKHUNG, tblXe.SOMAY FROM tblXe INNER JOIN tblChiTietNhap ON tblXe.MACTN = tblChiTietNhap.MACTN INNER JOIN tblTTXe ON tblChiTietNhap.MATTXE = tblTTXe.MATTXE WHERE (tblXe.MAXE NOT IN (SELECT MAXE FROM tblBaoHanh))";
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con.Connection;
        //    try
        //    {
        //        con.openCon();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        con.closeCon();
        //    }
        //    catch (Exception ex)
        //    {
        //        string mes = ex.Message;
        //        cmd.Dispose();
        //        con.closeCon();
        //    }
        //    return dt;
        //}

        //Mã xe máy cho lueMaXe UCBaoHanh
        public DataTable GetMaXeCholueMaXeUCBaoHanh()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblXe.MAXE, tblTTXe.TENXE, tblTTXe.MAUXE, tblXe.SOKHUNG, tblXe.SOMAY FROM tblTTXe INNER JOIN tblChiTietNhap ON tblTTXe.MATTXE = tblChiTietNhap.MATTXE INNER JOIN tblXe ON tblChiTietNhap.MACTN = tblXe.MACTN ORDER BY tblXe.MAXE DESC";
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
