using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLXeMay
{
    class KiemTraKetNoi
    {
        public static SqlConnection con; //Khai báo đối tượng kết nối
        public static void Connect()
        {
            string strCon = @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Projects\QLXeMay\QLXeMay\Database\QLXeMay.mdf;Integrated Security=True;User Instance=True";
            con = new SqlConnection(strCon);
            con.Open();
            if (con.State == ConnectionState.Open) MessageBox.Show("Kết nối thành công");
            else MessageBox.Show("Kết nối với dữ liệu thất bại");
        }

        public static void Disconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close(); //đóng kết nối
                con.Dispose();// Giải phóng tài nguyên
                con = null;

            }
        }
    }
}
