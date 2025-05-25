using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kasirkedai.Models;
using Microsoft.Data.SqlClient;

namespace kasirkedai.Models
{
    class UserRepository
    {
        public bool ValidateUser(string username, string password)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM tbkaryawan WHERE Username = @Username AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    int result = (int)cmd.ExecuteScalar();
                    return result > 0;
                }
            }
        }
    }
}
