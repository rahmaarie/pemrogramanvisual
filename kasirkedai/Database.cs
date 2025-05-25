using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace kasirkedai
{
    internal class Database
    {
        // Ganti dengan connection string 
        private static readonly string connectionString = @"Data Source=RAHMA;Initial Catalog=kasirkedaidb;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
