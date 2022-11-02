using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace T_Komp_proj.Helpers
{
    public class DataAccess
    {
        public static SqlConnection Get_DB_Connection()
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.cn);
            return cn;
        }

        public static void Set_DB_Connection_String(SqlConnectionStringBuilder cn)
        {
            Properties.Settings.Default.cn = cn.ToString();
        }
    }
}
