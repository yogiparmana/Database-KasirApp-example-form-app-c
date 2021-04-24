using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//database Sql import class
using System.Data.SqlClient;


namespace KasirApp
{
    class Conn
    {
        public SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection(); //ambil class sqlconnection
            conn.ConnectionString = "Data source = DESKTOP-DC1CU9U; " + //server
                "initial catalog = DB_KASIR; " + // database
                "integrated security = true"; // security
            return conn;
        }
    }
}
