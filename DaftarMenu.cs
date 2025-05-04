using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace kasirkedai
{
    public partial class DaftarMenu: Form
    {
        public object NamaPemesan { get; private set; }

        public DaftarMenu()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.DaftarMenu_Load);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-2A7QU8GB;Initial Catalog=kasirkedaidb;Integrated Security=True;TrustServerCertificate=True;";
            int jumlah = int.Parse(textBox1.Text);
            string namaMenu = comboBox1.Text;
            string pembayaran = comboBox2.Text;
            string lokasi = comboBox3.Text;
            string namaPemesan = textBox2.Text; // Ambil dari TextBox input nama

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                conn.Open();

                // Ambil IdMenu dan Harga dari tbmenu
                string queryMenu = "SELECT IdMenu, Harga FROM tbmenu WHERE namamenu = @nama";
                Microsoft.Data.SqlClient.SqlCommand cmdMenu = new Microsoft.Data.SqlClient.SqlCommand(queryMenu, conn);
                cmdMenu.Parameters.AddWithValue("@nama", namaMenu);
                Microsoft.Data.SqlClient.SqlDataReader reader = cmdMenu.ExecuteReader();

                if (reader.Read())
                {
                    int idMenu = (int)reader["IdMenu"];
                    decimal harga = (decimal)reader["Harga"];
                    reader.Close();

                    // 1. Insert ke tbtransaksi
                    string insertTransaksi = "INSERT INTO tbtransaksi (Tanggal, MetodePembayaran, Lokasi, NamaPemesan) VALUES (@tanggal, @pembayaran, @lokasi, @namaPemesan); SELECT SCOPE_IDENTITY();";
                    Microsoft.Data.SqlClient.SqlCommand cmdTrans = new Microsoft.Data.SqlClient.SqlCommand(insertTransaksi, conn);
                    cmdTrans.Parameters.AddWithValue("@tanggal", DateTime.Now);
                    cmdTrans.Parameters.AddWithValue("@pembayaran", pembayaran);
                    cmdTrans.Parameters.AddWithValue("@lokasi", lokasi);
                    cmdTrans.Parameters.AddWithValue("@namaPemesan", namaPemesan);

                    int idTransaksi = Convert.ToInt32(cmdTrans.ExecuteScalar());

                    // 2. Insert ke tbdetailpesanan
                    string insertDetail = "INSERT INTO tbdetailpesanan (IdTransaksi, IdMenu, Jumlah, Harga) VALUES (@idTrans, @idMenu, @jumlah, @harga)";
                    Microsoft.Data.SqlClient.SqlCommand cmdDetail = new Microsoft.Data.SqlClient.SqlCommand(insertDetail, conn);
                    cmdDetail.Parameters.AddWithValue("@idTrans", idTransaksi);
                    cmdDetail.Parameters.AddWithValue("@idMenu", idMenu);
                    cmdDetail.Parameters.AddWithValue("@jumlah", jumlah);
                    cmdDetail.Parameters.AddWithValue("@harga", harga);

                    cmdDetail.ExecuteNonQuery();

                    MessageBox.Show("Pesanan berhasil disimpan!");
                }
                else
                {
                    MessageBox.Show("Menu tidak ditemukan!");
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Menutup form saat ini (CekRiwayatPesan)
            this.Close();

            // Membuka FormLogin
            FormLogin loginForm = new FormLogin();
            loginForm.Show(); // atau loginForm.ShowDialog() jika ingin menunggu hingga form login ditutup
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DaftarMenu_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-2A7QU8GB;Initial Catalog=kasirkedaidb;Integrated Security=True;TrustServerCertificate=True;";
            string query = "SELECT namamenu FROM tbmenu";

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                    Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["namamenu"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengambil data menu: " + ex.Message);
                }
            }
            comboBox2.Items.Add("Cash");
            comboBox2.Items.Add("QRIS");
            comboBox2.Items.Add("Debit");

            comboBox3.Items.Add("Dine In");
            comboBox3.Items.Add("Take Away");
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void RiwayatPesanan_Click(object sender, EventArgs e)
        {
            CekRiwayatPesan formRiwayat = new CekRiwayatPesan();
            formRiwayat.Show(); // atau .ShowDialog(); jika ingin modal
            this.Hide(); // jika ingin menyembunyikan form saat ini
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Membuka form DaftarMenu.cs
            DaftarMenu daftarMenu = new DaftarMenu();
            daftarMenu.Show();
        }

        private void DaftarMenu_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
