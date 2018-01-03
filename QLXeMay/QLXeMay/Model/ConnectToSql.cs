using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace QLXeMay.Model
{
    class ConnectToSql
    {
        private SqlConnection _con;
        public SqlConnection Connection
        {
            get { return _con; }
        }

        private SqlCommand _cmd;
        public SqlCommand Cmd
        {
            get { return _cmd; }
            set { _cmd = value; }
        }

        string strCon; string path;
        //Hàm dựng
        public ConnectToSql()
        {
           
            path = Path.GetFullPath(Environment.CurrentDirectory);
            strCon = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + path + @"\Database\QLXeMay.mdf;Integrated Security=True;User Instance=True";
            _con = new SqlConnection(strCon);
        }

        private string error;
        public string Error
        {
            get { return error; }
            set { error = value; }
        }
        //Xử lý ngoại lệ khi đóng mở kết nối
        public bool openCon()
        {
            try
            {
                if (_con.State == ConnectionState.Closed) _con.Open();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        public bool closeCon()
        { 
            try
            {
                if (_con.State == ConnectionState.Open) _con.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

    }
}
