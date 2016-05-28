using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Atenda.Conn
{
    public class SqlConn
    {

        private static SqlConnection conn = new SqlConnection();
        private static SqlCommand cmd = new SqlCommand();
        private static SqlDataReader dr;

        public static string StrConn = "Server=tcp:atenda.database.windows.net;" +
                                        "Database=Atenda;" +
                                        "User ID=anderson_cardoso@atenda;" +
                                        "Password=Atenda9818;";

        public static bool Connect()
        {

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.ConnectionString = StrConn;
                conn.Open();
            }

            return true;
        }

        public static bool Close()
        {
            conn.Close();
            return true;
        }

        public static bool CommandPersist(SqlCommand pCmd)
        {
            Connect();

            if (dr != null && !dr.IsClosed)
                dr.Close();

            pCmd.Connection = conn;
            pCmd.ExecuteNonQuery();
            return true;
        }

        public static SqlDataReader Get(string pSql)
        {
            Connect();
            if (dr != null && !dr.IsClosed)
                dr.Close();

            cmd = new SqlCommand(pSql, conn);

            dr = cmd.ExecuteReader();

            return dr;
        }

    }

}

