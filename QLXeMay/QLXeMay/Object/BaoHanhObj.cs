using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class BaoHanhObj
    {
        string maBaoHanh, maKH, maXe;
        int thoiGianBaoHanh;

        public int ThoiGianBaoHanh
        {
            get { return thoiGianBaoHanh; }
            set { thoiGianBaoHanh = value; }
        }

        public string MaBaoHanh
        {
            get { return maBaoHanh; }
            set { maBaoHanh = value; }
        }

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }

        public string MaXe
        {
            get { return maXe; }
            set { maXe = value; }
        }


    }
}
