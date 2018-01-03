using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class ThongTinPhuTungObj
    {
        string maTTPT, loaiPT, tenPT, donViTinh;

        public string DonViTinh
        {
            get { return donViTinh; }
            set { donViTinh = value; }
        }

        public string TenPT
        {
            get { return tenPT; }
            set { tenPT = value; }
        }

        public string LoaiPT
        {
            get { return loaiPT; }
            set { loaiPT = value; }
        }

        public string MaTTPT
        {
            get { return maTTPT; }
            set { maTTPT = value; }
        }

    }
}
