using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLXeMay.Object;

namespace QLXeMay.Model
{
    class PhuTungMod
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT MAPT, MACTNPT, DONGIABAN FROM tblePhuTung";
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


        public DataTable GetAllDataUCPhuTung()
        {
            DataTable dt = new DataTable();
            //cmd.CommandText = "SELECT tblePhuTung.MAPT, tblePhuTung.MACTNPT, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblePhuTung.DONGIABAN, tblTTPhuTung.DONVITINH FROM tblePhuTung INNER JOIN tblChiTietNhapPhuTung ON tblePhuTung.MACTNPT = tblChiTietNhapPhuTung.MACTNPT INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT WHERE (tblePhuTung.MAPT NOT IN (SELECT MAPT FROM tblChiTietHDBanPT))";
            cmd.CommandText = "SELECT tblePhuTung.MAPT, tblePhuTung.MACTNPT, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblePhuTung.DONGIABAN, tblTTPhuTung.DONVITINH, tblNhapPhuTung.NGAYNHAP FROM tblePhuTung INNER JOIN tblChiTietNhapPhuTung ON tblePhuTung.MACTNPT = tblChiTietNhapPhuTung.MACTNPT INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT INNER JOIN tblNhapPhuTung ON tblChiTietNhapPhuTung.MANPT = tblNhapPhuTung.MANPT WHERE (tblePhuTung.MAPT NOT IN (SELECT MAPT FROM tblChiTietHDBanPT))";
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

        public bool AddData(PhuTungObj PTObj)
        {
            cmd.CommandText = string.Format("INSERT INTO tblePhuTung (MAPT, MACTNPT, DONGIABAN) VALUES ('{0}', '{1}', {2})", PTObj.MaPT, PTObj.MaCTNhapPT, PTObj.DonGiaBan);
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

        public bool UpdateData(PhuTungObj PTObj)
        {
            cmd.CommandText = string.Format("UPDATE tblePhuTung SET MAPT = '{0}', MACTNPT = '{1}', DONGIABAN = {2} WHERE (MAPT = '{0}')", PTObj.MaPT, PTObj.MaCTNhapPT, PTObj.DonGiaBan);
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
            cmd.CommandText = string.Format("DELETE FROM tblePhuTung WHERE (MAPT = '{0}')", ma);
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

        //Dữ liệu tìm kiếm phụ tùng đã nhập
        public DataTable TimKiemPhuTungDaNhap(string timKiemPTDaNhap)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblChiTietNhapPhuTung.DONGIANHAP, tblChiTietNhapPhuTung.SOLUONG, tblChiTietNhapPhuTung.DONGIANHAP * tblChiTietNhapPhuTung.SOLUONG AS THANHTIEN, tblTTPhuTung.DONVITINH, tblNhapPhuTung.NGAYNHAP, tblNhaCC.TENNHACC, tblNhanVien.TENNV FROM tblChiTietNhapPhuTung INNER JOIN tblNhapPhuTung ON tblChiTietNhapPhuTung.MANPT = tblNhapPhuTung.MANPT INNER JOIN tblNhaCC ON tblNhapPhuTung.MANHACC = tblNhaCC.MANHACC INNER JOIN tblNhanVien ON tblNhapPhuTung.MANV = tblNhanVien.MANV INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT WHERE ({0})", timKiemPTDaNhap);
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

        //Dữ liệu tìm kiếm phu tùng đã bán
        public DataTable TimKiemPhuTungDaBan(string timKiemPhuTungDaBan)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblePhuTung.MAPT, tblTTPhuTung.TENPT, tblTTPhuTung.LOAIPT, tblePhuTung.DONGIABAN, tblChiTietHDBanPT.SOLUONG, tblePhuTung.DONGIABAN * tblChiTietHDBanPT.SOLUONG AS THANHTIEN, tblHDBanPhuTung.NGAYBAN, tblKhachHang.TENKH, tblNhanVien.TENNV FROM tblePhuTung INNER JOIN tblChiTietHDBanPT ON tblePhuTung.MAPT = tblChiTietHDBanPT.MAPT INNER JOIN tblHDBanPhuTung ON tblChiTietHDBanPT.MAHDBANPT = tblHDBanPhuTung.MAHDBANPT INNER JOIN tblNhanVien ON tblHDBanPhuTung.MANV = tblNhanVien.MANV INNER JOIN tblKhachHang ON tblHDBanPhuTung.MAKH = tblKhachHang.MAKH INNER JOIN tblChiTietNhapPhuTung ON tblePhuTung.MACTNPT = tblChiTietNhapPhuTung.MACTNPT INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT WHERE ({0})", timKiemPhuTungDaBan);
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

        //Dữ liệu phụ tùng có trong cửa hàng
        public DataTable TimKiemPhuTungCoTrongCuaHang(string timKiemPTCoTrongCuaHang)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblePhuTung.MAPT, tblTTPhuTung.TENPT, tblePhuTung.DONGIABAN, tblChiTietNhapPhuTung.SOLUONG, tblePhuTung.DONGIABAN * tblChiTietNhapPhuTung.SOLUONG AS THANHTIEN, tblNhapPhuTung.NGAYNHAP, tblNhaCC.TENNHACC, tblNhanVien.TENNV FROM tblePhuTung INNER JOIN tblChiTietNhapPhuTung ON tblePhuTung.MACTNPT = tblChiTietNhapPhuTung.MACTNPT INNER JOIN tblNhapPhuTung ON tblChiTietNhapPhuTung.MANPT = tblNhapPhuTung.MANPT INNER JOIN tblNhaCC ON tblNhapPhuTung.MANHACC = tblNhaCC.MANHACC INNER JOIN tblNhanVien ON tblNhapPhuTung.MANV = tblNhanVien.MANV INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT WHERE (tblePhuTung.MAPT NOT IN (SELECT MAPT FROM tblChiTietHDBanPT)) AND ({0})", timKiemPTCoTrongCuaHang);
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

        //Phụ tùng có trong cửa hàng (Số lượng đã nhập mà chưa bán)//Danh mục xe trong cửa hàng
        public DataTable DanhSachPhuTungCoTrongCuaHang()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblePhuTung.DONGIABAN, SUM(tblChiTietNhapPhuTung.SOLUONG) AS SOLUONG, SUM(tblePhuTung.DONGIABAN * tblChiTietNhapPhuTung.SOLUONG) AS THANHTIEN, tblTTPhuTung.DONVITINH FROM tblePhuTung INNER JOIN tblChiTietNhapPhuTung ON tblePhuTung.MACTNPT = tblChiTietNhapPhuTung.MACTNPT INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT WHERE (tblePhuTung.MAPT NOT IN (SELECT MAPT FROM tblChiTietHDBanPT)) GROUP BY tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblePhuTung.DONGIABAN, tblChiTietNhapPhuTung.SOLUONG, tblTTPhuTung.DONVITINH ORDER BY tblTTPhuTung.LOAIPT";
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

        //Lấy toàn bộ Mã chi tiết nhập mà nhân viên đã nhập
        public DataTable GetAllDataNhanVienDaNhap()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblChiTietNhapPhuTung.MACTNPT, tblChiTietNhapPhuTung.SOLUONG, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, tblChiTietNhapPhuTung.DONGIANHAP FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT";
            //cmd.CommandText = "SELECT tblChiTietNhapPhuTung.MACTNPT, tblChiTietNhapPhuTung.SOLUONG, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, tblChiTietNhapPhuTung.DONGIANHAP, tblNhapPhuTung.NGAYNHAP FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT INNER JOIN tblNhapPhuTung ON tblChiTietNhapPhuTung.MANPT = tblNhapPhuTung.MANPT";
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

        //Danh sách phụ tùng có trong cửa hàng với điều kiện tổng số giống nhau mã chi tiết nhập = số lượng
        public DataTable GetAllDataSoLuongBangMaChiTietNhapPT()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblChiTietNhapPhuTung.MACTNPT, tblChiTietNhapPhuTung.SOLUONG, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, tblChiTietNhapPhuTung.DONGIANHAP FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT INNER JOIN tblePhuTung ON tblChiTietNhapPhuTung.MACTNPT = tblePhuTung.MACTNPT GROUP BY tblChiTietNhapPhuTung.MACTNPT, tblChiTietNhapPhuTung.SOLUONG, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblTTPhuTung.DONVITINH, tblChiTietNhapPhuTung.DONGIANHAP HAVING (COUNT(tblChiTietNhapPhuTung.MACTNPT) = tblChiTietNhapPhuTung.SOLUONG) ORDER BY tblChiTietNhapPhuTung.MACTNPT";
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

        public DataTable GetDataMaTenCTPT()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblChiTietNhapPhuTung.MACTNPT, tblTTPhuTung.TENPT FROM tblChiTietNhapPhuTung INNER JOIN tblTTPhuTung ON tblChiTietNhapPhuTung.MATTPT = tblTTPhuTung.MATTPT";
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

        //Lấy Loại phụ tùng dựa vào MACTNPT dùng trong ucPhuTung
        public string GetLoaiPT(string ma)
        {
            cmd.CommandText = string.Format("SELECT tblTTPhuTung.LOAIPT FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT WHERE (tblChiTietNhapPhuTung.MACTNPT = '{0}')", ma);
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

        //Lấy Tên phụ tùng dựa vào MACTNPT dùng trong ucPhuTung
        public string GetTenPT(string ma)
        {
            cmd.CommandText = string.Format("SELECT tblTTPhuTung.TENPT FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT WHERE (tblChiTietNhapPhuTung.MACTNPT = '{0}')", ma);
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

        //Lấy Đơn giá nhâp dựa vào MACTNPT dùng trong ucPhuTung
        public string GetDonGiaNhap(string ma)
        {
            cmd.CommandText = string.Format("SELECT tblChiTietNhapPhuTung.DONGIANHAP FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT WHERE (tblChiTietNhapPhuTung.MACTNPT = '{0}')", ma);
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

        //Lấy Số lượng dựa vào MACTNPT dùng trong ucPhuTung
        public string GetSoLuong(string ma)
        {
            cmd.CommandText = string.Format("SELECT tblChiTietNhapPhuTung.SOLUONG FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT WHERE (tblChiTietNhapPhuTung.MACTNPT = '{0}')", ma);
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

        //Lấy Đơn vị tính dựa vào MACTNPT dùng trong ucPhuTung
        public string GetDonViTinh(string ma)
        {
            cmd.CommandText = string.Format("SELECT tblTTPhuTung.DONVITINH FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT WHERE (tblChiTietNhapPhuTung.MACTNPT = '{0}')", ma);
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


        //Phụ tùng có trong cửa hàng UCHoaDonBanPT
        public DataTable GetPhuTungCoTrongCuaHangUCHD()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblePhuTung.MAPT, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT,tblePhuTung.DONGIABAN, tblTTPhuTung.DONVITINH FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT INNER JOIN tblePhuTung ON tblChiTietNhapPhuTung.MACTNPT = tblePhuTung.MACTNPT WHERE (tblePhuTung.MAPT NOT IN (SELECT MAPT FROM tblChiTietHDBanPT))";
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

        //Phụ tùng với mã hóa đơn bán = {chuỗi mã truyền vào} UCHoaDonBanPT. Lấy danh sách các phụ tùng cùng 1 hóa đơn
        public DataTable GetPhuTungDaChonKhiMuaPT(string mahdbPT)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = string.Format("SELECT tblePhuTung.MAPT, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT, tblePhuTung.DONGIABAN, tblTTPhuTung.DONVITINH FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT INNER JOIN tblePhuTung ON tblChiTietNhapPhuTung.MACTNPT = tblePhuTung.MACTNPT INNER JOIN tblChiTietHDBanPT ON tblePhuTung.MAPT = tblChiTietHDBanPT.MAPT INNER JOIN tblHDBanPhuTung ON tblChiTietHDBanPT.MAHDBANPT = tblHDBanPhuTung.MAHDBANPT WHERE (tblHDBanPhuTung.MAHDBANPT = '{0}')", mahdbPT);
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

        //Mã - tên - loại PT có trong cửa hàng
        public DataTable GetMaTenLoaiPhuTungCoTrongCuaHang()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT tblePhuTung.MAPT, tblTTPhuTung.LOAIPT, tblTTPhuTung.TENPT FROM tblTTPhuTung INNER JOIN tblChiTietNhapPhuTung ON tblTTPhuTung.MATTPT = tblChiTietNhapPhuTung.MATTPT INNER JOIN tblePhuTung ON tblChiTietNhapPhuTung.MACTNPT = tblePhuTung.MACTNPT WHERE (tblePhuTung.MAPT NOT IN (SELECT MAPT FROM tblChiTietHDBanPT))";
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
