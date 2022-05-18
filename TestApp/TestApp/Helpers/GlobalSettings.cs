using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;

namespace TestApp.Helpers
{
    class GlobalSettings
    {
        public static SqlConnection Connection()
        {
            SqlConnection sqlConn = new SqlConnection(
                @"Data Source=DESKTOP-VC8JTUE\SQLEXPRESS;Initial Catalog=notown;Integrated Security=True;"
            );
            return sqlConn;
        }
    }
}
