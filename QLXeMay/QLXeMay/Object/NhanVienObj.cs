using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class NhanVienObj
    {
        string manv, tennv, ngaySinh, gioiTinh, soCMND, chucVu, diaChi, sdt;
        int luongCoBan;

        public int LuongCoBan
        {
            get { return luongCoBan; }
            set { luongCoBan = value; }
        }

        public string Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        public string Tennv
        {
            get { return tennv; }
            set { tennv = value; }
        }

        public string NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        public string SoCMND
        {
            get { return soCMND; }
            set { soCMND = value; }
        }

        public string ChucVu
        {
            get { return chucVu; }
            set { chucVu = value; }
        }


        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        //Hàm dựng (Constructor)

        public NhanVienObj() { }

        public NhanVienObj(string manv, string tennv, string ngaySinh, string gioiTinh, string soCMND, string chucVu, int luongCoBan, string diaChi, string sdt)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.soCMND = soCMND;
            this.chucVu = chucVu;
            this.luongCoBan = luongCoBan;
            this.diaChi = diaChi;
            this.sdt = sdt;
        }
    }
}
