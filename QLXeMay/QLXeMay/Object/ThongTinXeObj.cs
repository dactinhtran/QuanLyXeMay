using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class ThongTinXeObj
    {
        string maThongTinXe, hangXe, tenXe, mauXe;
        int dungTich;

        public int DungTich
        {
            get { return dungTich; }
            set { dungTich = value; }
        }

        public string MauXe
        {
            get { return mauXe; }
            set { mauXe = value; }
        }

        public string TenXe
        {
            get { return tenXe; }
            set { tenXe = value; }
        }

        public string HangXe
        {
            get { return hangXe; }
            set { hangXe = value; }
        }

        public string MaThongTinXe
        {
            get { return maThongTinXe; }
            set { maThongTinXe = value; }
        }
        
    }
}
