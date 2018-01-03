using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLXeMay.Object
{
    class NhaCungCapObj
    {
        string maNCC, tenNCC, diaChi, email, sdt;

        public string MaNCC
        {
            get { return maNCC; }
            set { maNCC = value; }
        }

        public string TenNCC
        {
            get { return tenNCC; }
            set { tenNCC = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
    }
}
