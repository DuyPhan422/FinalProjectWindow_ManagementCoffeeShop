using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Coffee_Shop
{
    internal class Connection
    {
        private static string stringConnection = @"Data Source=DESKTOP-7S1UU42\SQLEXPRESS;Initial Catalog=""Management Coffee Shop"";User ID=sa;Password=1234;TrustServerCertificate=True";
        public static SqlConnection StringConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
