using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace kasirkedai
{
    class DatabaseDM

    {

        private string connectionString = "Data Source=LAPTOP-2A7QU8GB;Initial Catalog=kasirkedaidb;Integrated Security=True;TrustServerCertificate=True;";

            // Membuat koneksi ke database
            private SqlConnection CreateConnection()
            {
                return new SqlConnection(connectionString);
            }

            // Menjalankan query tanpa return data (Insert, Update, Delete)
            public void ExecuteNonQuery(string query, List<SqlParameter> parameters = null)
            {
                using (SqlConnection conn = CreateConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Menjalankan query yang mengembalikan satu nilai (Select, Get)
            public object ExecuteScalar(string query, List<SqlParameter> parameters = null)
            {
                using (SqlConnection conn = CreateConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }

            // Menjalankan query yang mengembalikan banyak data (Select)
            public DataTable ExecuteQuery(string query, List<SqlParameter> parameters = null)
            {
                using (SqlConnection conn = CreateConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }

            }
    }
}
