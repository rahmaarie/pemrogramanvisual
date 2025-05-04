using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kasirkedai
{
    public partial class CekRiwayatPesan: Form
    {
        private string selectedIdTransaksi; // ← Letakkan di sini, ini variabel global
        public CekRiwayatPesan()
        {
            InitializeComponent();

        }

        private void CekRiwayatPesan_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            string connStr = "Data Source=LAPTOP-2A7QU8GB;Initial Catalog=kasirkedaidb;Integrated Security=True;TrustServerCertificate=True;";
            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
                    SELECT t.IdTransaksi, t.Tanggal, t.namaPemesan, m.namamenu, d.Jumlah, d.Harga, 
                           (d.Jumlah * d.Harga) AS TotalHarga, t.MetodePembayaran, t.Lokasi
                    FROM tbtransaksi t
                    JOIN tbdetailpesanan d ON t.IdTransaksi = d.IdTransaksi
                    JOIN tbmenu m ON d.IdMenu = m.IdMenu
                ";

                Microsoft.Data.SqlClient.SqlDataAdapter adapter = new Microsoft.Data.SqlClient.SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewRiwayat.DataSource = dt;

                // Tambah tombol "Cek"
                dataGridViewRiwayat.DataSource = null;
                dataGridViewRiwayat.Columns.Clear(); // kalau memang mau mulai bersih

                dataGridViewRiwayat.DataSource = dt;

                // Tambah tombol cek lagi jika belum ada
                if (dataGridViewRiwayat.Columns["btnCek"] == null)
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    btn.HeaderText = "Aksi";
                    btn.Name = "btnCek";
                    btn.Text = "Cek";
                    btn.UseColumnTextForButtonValue = true;
                    dataGridViewRiwayat.Columns.Add(btn);
                }

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Menyembunyikan form saat ini
            this.Hide();

            // Membuka form DaftarMenu.cs
            DaftarMenu daftarMenu = new DaftarMenu();
            daftarMenu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewRiwayat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewRiwayat.Columns[e.ColumnIndex].Name == "btnCek")
            {
                // Tampilkan GroupBox
                groupBox1.Visible = true;
                groupBox1.BackColor = Color.LightYellow; // Efek highlight

                // Ambil data dari baris yang dipilih
                DataGridViewRow row = dataGridViewRiwayat.Rows[e.RowIndex];

                // Simpan ID transaksi yang dipilih
                selectedIdTransaksi = row.Cells["IdTransaksi"].Value.ToString();

                // Isi semua TextBox di GroupBox
                textBox1.Text = row.Cells["namaPemesan"].Value?.ToString() ?? "";
                textBox2.Text = row.Cells["namamenu"].Value?.ToString() ?? "";
                textBox3.Text = row.Cells["Jumlah"].Value?.ToString() ?? "";
                textBox4.Text = row.Cells["Harga"].Value?.ToString() ?? "";
                textBox5.Text = row.Cells["TotalHarga"].Value?.ToString() ?? "";
                textBox6.Text = row.Cells["MetodePembayaran"].Value?.ToString() ?? "";
                textBox7.Text = row.Cells["Lokasi"].Value?.ToString() ?? "";
                

                // Scroll ke bawah jika perlu
                groupBox1.Focus();
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox9.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dataGridViewRiwayat.Rows)
            {
                if (row.IsNewRow) continue;

                // Ambil nilai dari semua kolom yang ingin dicari
                string namaPemesan = row.Cells["namaPemesan"].Value?.ToString().ToLower() ?? "";
                string namaMenu = row.Cells["namamenu"].Value?.ToString().ToLower() ?? "";
                string jumlah = row.Cells["Jumlah"].Value?.ToString().ToLower() ?? "";
                string hargaSatuan = row.Cells["Harga"].Value?.ToString().ToLower() ?? "";
                string totalHarga = row.Cells["TotalHarga"].Value?.ToString().ToLower() ?? "";
                string pembayaran = row.Cells["MetodePembayaran"].Value?.ToString().ToLower() ?? "";
                string lokasi = row.Cells["Lokasi"].Value?.ToString().ToLower() ?? "";
                string tanggal = row.Cells["Tanggal"].Value?.ToString().ToLower() ?? "";

                // Jika kosong, tampilkan semua
                if (string.IsNullOrEmpty(keyword))
                {
                    row.Visible = true;
                }
                else
                {
                    bool isMatch = namaPemesan.Contains(keyword) || namaMenu.Contains(keyword) ||
                                 jumlah.Contains(keyword) || hargaSatuan.Contains(keyword) ||
                                 totalHarga.Contains(keyword) || pembayaran.Contains(keyword) ||
                                 lokasi.Contains(keyword) || tanggal.Contains(keyword);

                    row.Visible = isMatch;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIdTransaksi))
            {
                MessageBox.Show("Silakan pilih data yang ingin diupdate terlebih dahulu.");
                return;
            }

            // Validasi input sederhana
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Nama pemesan dan jumlah tidak boleh kosong.");
                return;
            }

            // Parsing jumlah dan harga
            bool jumlahValid = int.TryParse(textBox3.Text, out int jumlah);
            bool hargaValid = decimal.TryParse(textBox4.Text, out decimal harga);

            if (!jumlahValid || !hargaValid)
            {
                MessageBox.Show("Jumlah dan harga harus berupa angka yang valid.");
                return;
            }

            string namaPemesan = textBox1.Text.Trim();
            string metodePembayaran = textBox6.Text.Trim();
            string lokasi = textBox7.Text.Trim();

            string connStr = "Data Source=LAPTOP-2A7QU8GB;Initial Catalog=kasirkedaidb;Integrated Security=True;TrustServerCertificate=True;";
            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connStr))
            {
                conn.Open();

                // Update tbtransaksi (namaPemesan, MetodePembayaran, Lokasi)
                string updateTransaksi = @"
            UPDATE tbtransaksi
            SET namaPemesan = @namaPemesan,
                MetodePembayaran = @metode,
                Lokasi = @lokasi
            WHERE IdTransaksi = @id";

                // Update tbdetailpesanan (Jumlah, Harga)
                string updateDetail = @"
            UPDATE tbdetailpesanan
            SET Jumlah = @jumlah,
                Harga = @harga
            WHERE IdTransaksi = @id";

                using (var cmd1 = new Microsoft.Data.SqlClient.SqlCommand(updateTransaksi, conn))
                using (var cmd2 = new Microsoft.Data.SqlClient.SqlCommand(updateDetail, conn))
                {
                    cmd1.Parameters.AddWithValue("@namaPemesan", namaPemesan);
                    cmd1.Parameters.AddWithValue("@metode", metodePembayaran);
                    cmd1.Parameters.AddWithValue("@lokasi", lokasi);
                    cmd1.Parameters.AddWithValue("@id", selectedIdTransaksi);

                    cmd2.Parameters.AddWithValue("@jumlah", jumlah);
                    cmd2.Parameters.AddWithValue("@harga", harga);
                    cmd2.Parameters.AddWithValue("@id", selectedIdTransaksi);

                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data berhasil diupdate.");
            groupBox1.Visible = false;
            selectedIdTransaksi = null;
            CekRiwayatPesan_Load(null, null); // Refresh data grid
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIdTransaksi))
            {
                MessageBox.Show("Silakan pilih data yang ingin dihapus terlebih dahulu.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Apakah Anda yakin ingin menghapus data ini?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                string connStr = "Data Source=LAPTOP-2A7QU8GB;Initial Catalog=kasirkedaidb;Integrated Security=True;TrustServerCertificate=True;";
                using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connStr))
                {
                    conn.Open();

                    // Pertama hapus dari detail dulu karena ada foreign key
                    string deleteDetail = "DELETE FROM tbdetailpesanan WHERE IdTransaksi = @id";
                    string deleteTransaksi = "DELETE FROM tbtransaksi WHERE IdTransaksi = @id";

                    using (var cmd1 = new Microsoft.Data.SqlClient.SqlCommand(deleteDetail, conn))
                    using (var cmd2 = new Microsoft.Data.SqlClient.SqlCommand(deleteTransaksi, conn))
                    {
                        cmd1.Parameters.AddWithValue("@id", selectedIdTransaksi);
                        cmd2.Parameters.AddWithValue("@id", selectedIdTransaksi);

                        cmd1.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data berhasil dihapus.");
                selectedIdTransaksi = null;
                groupBox1.Visible = false;
                CekRiwayatPesan_Load(null, null); // Refresh DataGridView
            }
        }

        private void ResetForm()
        {
            // Bersihkan semua TextBox di dalam groupBox1
            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
            }

            // Sembunyikan kembali GroupBox
            groupBox1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
                // Sembunyikan GroupBox
                groupBox1.Visible = false;

                // Tampilkan DataGridView kembali
                dataGridViewRiwayat.Visible = true;

                // Bersihkan form jika perlu
                ResetForm();
            
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            // Menutup form saat ini (CekRiwayatPesan)
            this.Close();

            // Membuka FormLogin
            FormLogin loginForm = new FormLogin();
            loginForm.Show(); // atau loginForm.ShowDialog() jika ingin menunggu hingga form login ditutup
        }

        private void dateTimePickerTanggal_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
