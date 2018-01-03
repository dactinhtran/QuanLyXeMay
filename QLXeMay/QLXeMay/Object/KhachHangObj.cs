using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class KhachHangObj
    {
        string maKH, tenKH, ngaySinh, gioiTinh, soCMND, diaChi, sdt;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }

        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
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

        //Hàm dựng
        public KhachHangObj() { }
        public KhachHangObj(string maKH, string tenKH, string ngaySinh, string gioiTinh, string soCMND, string diaChi, string sdt)
        {
            this.MaKH = maKH;
            this.tenKH = tenKH;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.soCMND = soCMND;
            this.diaChi = diaChi;
            this.sdt = sdt;
        }
    }
}
