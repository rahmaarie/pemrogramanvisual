using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static kasirkedai.DatabaseHelper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace kasirkedai.Models
{

    public class MenuService
    {
        public static List<string> GetNamaMenu()
        {
            List<string> menuList = new List<string>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT namamenu FROM tbmenu";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            menuList.Add(reader["namamenu"].ToString());
                        }
                    }
                }
            }
            return menuList;
        }

        public static decimal GetHargaMenu(string namaMenu)
        {
            decimal harga = 0;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT Harga FROM tbmenu WHERE namamenu = @nama";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", namaMenu);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        harga = Convert.ToDecimal(result);
                    }
                }
            }
            return harga;
        }

        public static int InsertTransaksi(string metodePembayaran, string lokasi, string namaPemesan, DateTime tanggal)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"INSERT INTO tbtransaksi (MetodePembayaran, Lokasi, NamaPemesan, Tanggal)
                         VALUES (@metodePembayaran, @lokasi, @namaPemesan, @tanggal);
                         SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@metodePembayaran", metodePembayaran);
                    cmd.Parameters.AddWithValue("@lokasi", lokasi);
                    cmd.Parameters.AddWithValue("@namaPemesan", namaPemesan);
                    cmd.Parameters.AddWithValue("@tanggal", tanggal);

                    int idTransaksi = Convert.ToInt32(cmd.ExecuteScalar());
                    return idTransaksi;
                }
            }
        }

        public static void InsertDetailPesanan(int idTransaksi, string namaMenu, int jumlah, decimal harga)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string getIdMenuQuery = "SELECT IdMenu FROM tbmenu WHERE namamenu = @nama";
                using (SqlCommand cmdMenu = new SqlCommand(getIdMenuQuery, conn))
                {
                    cmdMenu.Parameters.AddWithValue("@nama", namaMenu);
                    object idMenuResult = cmdMenu.ExecuteScalar();
                    if (idMenuResult != null)
                    {
                        int idMenu = Convert.ToInt32(idMenuResult);
                        string insertDetail = "INSERT INTO tbdetailpesanan (IdTransaksi, IdMenu, Jumlah, Harga) VALUES (@idTrans, @idMenu, @jumlah, @harga)";
                        using (SqlCommand cmdDetail = new SqlCommand(insertDetail, conn))
                        {
                            cmdDetail.Parameters.AddWithValue("@idTrans", idTransaksi);
                            cmdDetail.Parameters.AddWithValue("@idMenu", idMenu);
                            cmdDetail.Parameters.AddWithValue("@jumlah", jumlah);
                            cmdDetail.Parameters.AddWithValue("@harga", harga);
                            cmdDetail.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static DataTable GetRiwayatPesanan()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT t.IdTransaksi, t.Tanggal, t.namaPemesan, m.namamenu, d.Jumlah, d.Harga, 
                           (d.Jumlah * d.Harga) AS TotalHarga, t.MetodePembayaran, t.Lokasi
                    FROM tbtransaksi t
                    JOIN tbdetailpesanan d ON t.IdTransaksi = d.IdTransaksi
                    JOIN tbmenu m ON d.IdMenu = m.IdMenu";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
