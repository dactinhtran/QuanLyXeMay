using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLXeMay.Model;
using System.Data;

namespace QLXeMay.Control
{
    class ThongKeControl
    {
        ThongKeMode thongKeMod = new ThongKeMode();

        public DataTable thongKeXeNgay(string ngay)
        {
            return thongKeMod.ThongKeXeNgay(ngay);
        }

        public DataTable thongKePhuTungNgay(string ngay)
        {
            return thongKeMod.ThongKePhuTungNgay(ngay);
        }

        public DataTable thongKeNhapThang(int thang, int nam)
        {
            return thongKeMod.ThongKeNhapThang(thang, nam);
        }

        public DataTable thongKeNhapPhuTungThang(int thang, int nam)
        {
            return thongKeMod.ThongKeNhapPhuTungThang(thang, nam);
        }

        public DataTable thongKeBanXeTheoThang(string thang, string nam)
        {
            return thongKeMod.ThongKeBanXeTheoThang(thang, nam);
        }

        public DataTable thongKeBanPhuTungTheoThang(string thang, string nam)
        {
            return thongKeMod.ThongKeBanPhuTungTheoThang(thang, nam);
        }

        public DataTable thongKeNhapXeTheoNam(int nam)
        {
            return thongKeMod.ThongKeNhapXeTheoNam(nam);
        }

        public DataTable thongKeNhapPhuTungTheoNam(int nam)
        {
            return thongKeMod.ThongKeNhapPhuTungTheoNam(nam);
        }
        public DataTable thongKeBanXeTheoNam(string nam)
        {
            return thongKeMod.ThongKeBanXeTheoNam(nam);
        }

        public DataTable thongKeBanPhuTungTheoNam(string nam)
        {
            return thongKeMod.ThongKeBanPhuTungTheoNam(nam);
        }

        public DataTable thongKeNhapXeTheoKhoangThoiGian(string tuNgay, string denNgay)
        {
            return thongKeMod.ThongKeNhapXeTheoKhoangThoiGian(tuNgay, denNgay);
        }

        public DataTable thongKeNhapPhuTungTheoKhoangThoiGian(string tuNgay, string denNgay)
        {
            return thongKeMod.ThongKeNhapPhuTungTheoKhoangThoiGian(tuNgay, denNgay);
        }

        public DataTable thongKeBanXeTheoKhoangThoiGian(string tuNgay, string denNgay)
        {
            return thongKeMod.ThongKeBanXeTheoKhoangThoiGian(tuNgay, denNgay);
        }

        public DataTable thongKeBanPhuTungTheoKhoangThoiGian(string tuNgay, string denNgay)
        {
            return thongKeMod.ThongKeBanPhuTungTheoKhoangThoiGian(tuNgay, denNgay);
        }
    }
}
