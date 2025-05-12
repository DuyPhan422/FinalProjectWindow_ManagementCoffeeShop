using System;
using System.Data.SqlClient;
using System.Drawing;

namespace Management_Coffee_Shop
{
    public abstract class Connection
    {
        private static readonly string ConnectionString1 =
            @"Data Source=DESKTOP-7S1UU42\SQLEXPRESS;Initial Catalog=""Management Coffee Shop"";User ID=sa;Password=1234;TrustServerCertificate=True";

        private static readonly string ConnectionString2 =

            "Data Source=.\\DUYSQL;Initial Catalog=Management Coffee Shop; Integrated Security = True; TrustServerCertificate=True";
        private static readonly string ConnectionString3 =
            @"Data Source=DESKTOP-331CJKC;Initial Catalog =""Management Coffee Shop"";User ID = sa; Password=123;TrustServerCertificate=True";

        private static readonly string connectionString = GetActiveConnectionString();

        private static string GetActiveConnectionString()
        {
            string machineName = Environment.MachineName;
            if (machineName.Contains("DESKTOP-7S1UU42"))
            {
                return ConnectionString1;
            }
            else if (machineName.Contains(".\\DUYSQL"))
            {
                return ConnectionString2;
            }
            else if (machineName.Contains("DESKTOP-331CJKC"))
            {
                return ConnectionString3;
            }
            return ConnectionString2;
        }

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}