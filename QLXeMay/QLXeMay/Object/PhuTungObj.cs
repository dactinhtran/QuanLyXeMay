using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class PhuTungObj
    {
        string maPT, maCTNhapPT;
        int donGiaBan;

        public int DonGiaBan
        {
            get { return donGiaBan; }
            set { donGiaBan = value; }
        }

        public string MaCTNhapPT
        {
            get { return maCTNhapPT; }
            set { maCTNhapPT = value; }
        }

        public string MaPT
        {
            get { return maPT; }
            set { maPT = value; }
        }
    }
}
