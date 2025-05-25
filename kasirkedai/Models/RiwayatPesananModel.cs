using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static kasirkedai.DatabaseHelper;

namespace kasirkedai.Models
{
    public class RiwayatPesananModel
    {
        public DataTable GetRiwayat()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
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

        public void UpdateTransaksi(string id, string namaPemesan, string metode, string lokasi, int jumlah, decimal harga)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                string updateTransaksi = @"
                    UPDATE tbtransaksi
                    SET namaPemesan = @namaPemesan,
                        MetodePembayaran = @metode,
                        Lokasi = @lokasi
                    WHERE IdTransaksi = @id";

                string updateDetail = @"
                    UPDATE tbdetailpesanan
                    SET Jumlah = @jumlah,
                        Harga = @harga
                    WHERE IdTransaksi = @id";

                using (var cmd1 = new SqlCommand(updateTransaksi, conn))
                using (var cmd2 = new SqlCommand(updateDetail, conn))
                {
                    cmd1.Parameters.AddWithValue("@namaPemesan", namaPemesan);
                    cmd1.Parameters.AddWithValue("@metode", metode);
                    cmd1.Parameters.AddWithValue("@lokasi", lokasi);
                    cmd1.Parameters.AddWithValue("@id", id);

                    cmd2.Parameters.AddWithValue("@jumlah", jumlah);
                    cmd2.Parameters.AddWithValue("@harga", harga);
                    cmd2.Parameters.AddWithValue("@id", id);

                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTransaksi(string id)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string deleteDetail = "DELETE FROM tbdetailpesanan WHERE IdTransaksi = @id";
                string deleteTransaksi = "DELETE FROM tbtransaksi WHERE IdTransaksi = @id";

                using (var cmd1 = new SqlCommand(deleteDetail, conn))
                using (var cmd2 = new SqlCommand(deleteTransaksi, conn))
                {
                    cmd1.Parameters.AddWithValue("@id", id);
                    cmd2.Parameters.AddWithValue("@id", id);

                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                }
            }
        }
    }
}