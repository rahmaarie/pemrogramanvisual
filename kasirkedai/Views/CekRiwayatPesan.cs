using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kasirkedai.Controllers;
using kasirkedai.Models;
using System.Drawing.Printing;




namespace kasirkedai
{
    public partial class CekRiwayatPesan: Form
    {
        
        private RiwayatPesananController controller;
        private DataTable dt;
        private string selectedIdTransaksi;
        public CekRiwayatPesan()
        {
            InitializeComponent();
            controller = new RiwayatPesananController();
        }

        private void CekRiwayatPesan_Load(object sender, EventArgs e)
        {

            groupBox1.Visible = false;
            LoadDataGrid();

        }
        private void LoadDataGrid()
        {
            dt = controller.LoadData();

            dataGridViewRiwayat.DataSource = null;
            dataGridViewRiwayat.Columns.Clear();
            dataGridViewRiwayat.DataSource = dt;

            if (dataGridViewRiwayat.Columns["btnCek"] == null)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn
                {
                    HeaderText = "Aksi",
                    Name = "btnCek",
                    Text = "Cek",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewRiwayat.Columns.Add(btn);
            }
        }

        // ... kode lain tetap sama seperti button klik, textbox search dll ...



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

            dataGridViewRiwayat.CurrentCell = null;

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

                bool isMatch = string.IsNullOrEmpty(keyword) || (
                    namaPemesan.Contains(keyword) || namaMenu.Contains(keyword) ||
                    jumlah.Contains(keyword) || hargaSatuan.Contains(keyword) ||
                    totalHarga.Contains(keyword) || pembayaran.Contains(keyword) ||
                    lokasi.Contains(keyword) || tanggal.Contains(keyword)
                );

                row.Visible = isMatch;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIdTransaksi))
            {
                MessageBox.Show("Silakan pilih data yang ingin diupdate dengan menekan tombol 'Cek' terlebih dahulu.");
                return;
            }

            string namaPemesan = textBox1.Text.Trim();
            string metode = textBox6.Text.Trim();
            string lokasi = textBox7.Text.Trim();

            if (!int.TryParse(textBox3.Text.Trim(), out int jumlah))
            {
                MessageBox.Show("Jumlah harus berupa angka valid.");
                return;
            }

            if (!decimal.TryParse(textBox4.Text.Trim(), out decimal harga))
            {
                MessageBox.Show("Harga harus berupa angka desimal.");
                return;
            }

            try
            {
                controller.UpdateData(selectedIdTransaksi, namaPemesan, metode, lokasi, jumlah, harga);
                MessageBox.Show("Data berhasil diupdate!");

                LoadDataGrid();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal melakukan update data.\n" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIdTransaksi))
            {
                MessageBox.Show("Silakan pilih transaksi terlebih dahulu dengan menekan tombol 'Cek'.");
                return;
            }

            var confirmResult = MessageBox.Show("Apakah Anda yakin ingin menghapus transaksi ini?",
                                                 "Konfirmasi Hapus",
                                                 MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    controller.DeleteData(selectedIdTransaksi);
                    MessageBox.Show("Transaksi berhasil dihapus!");

                    LoadDataGrid();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus transaksi: " + ex.Message);
                }
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
        private ReceiptPayload BuildReceiptPayload()
        {
            var payload = new ReceiptPayload
            {
                NoPesanan = textBox1.Text,
                Tanggal = dateTimePickerTanggal.Value
            };

            foreach (DataGridViewRow row in dataGridViewRiwayat.Rows)
            {
                if (row.IsNewRow) continue;

                payload.Items.Add(new ReceiptItem
                {
                    No = payload.Items.Count + 1,
                    Nama = row.Cells["namamenu"].Value?.ToString(),   // samakan dengan nama kolom
                    Qty = Convert.ToInt32(row.Cells["Jumlah"].Value),
                    Harga = Convert.ToDecimal(row.Cells["TotalHarga"].Value)
                });
            }

            return payload;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (dataGridViewRiwayat.CurrentRow == null)
            {
                MessageBox.Show("Pilih riwayat pesanan dulu");
                return;
            }

            var payload = BuildReceiptPayload();   // ← panggil method yang baru dibetulkan


        }

        private void btnprint_Click_1(object sender, EventArgs e)
        {
            // Pastikan data lengkap
            if (string.IsNullOrEmpty(selectedIdTransaksi))
            {
                MessageBox.Show("Pilih transaksi dulu dengan tombol Cek.");
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";   // pilih printer PDF bawaan Windows:contentReference[oaicite:0]{index=0}
            pd.DocumentName = $"Struk_{selectedIdTransaksi}";

            // Gambar struk di sini
            pd.PrintPage += (s, args) =>
            {
                float y = 20;
                Font font = new Font("Segoe UI", 10);

                // Header
                args.Graphics.DrawString($"No Pesanan : {textBox1.Text}", font, Brushes.Black, 20, y); y += 20;
                args.Graphics.DrawString($"Tanggal    : {dateTimePickerTanggal.Value:dd/MM/yyyy}", font, Brushes.Black, 20, y); y += 30;

                // Detail item tunggal (atau beberapa bila mau)
                args.Graphics.DrawString($"Menu       : {textBox2.Text}", font, Brushes.Black, 20, y); y += 20;
                args.Graphics.DrawString($"Qty        : {textBox3.Text}", font, Brushes.Black, 20, y); y += 20;
                args.Graphics.DrawString($"Harga      : {textBox4.Text}", font, Brushes.Black, 20, y); y += 20;
                args.Graphics.DrawString($"Total      : {textBox5.Text}", font, Brushes.Black, 20, y); y += 30;

                // Footer
                args.Graphics.DrawString($"Pembayaran : {textBox6.Text}", font, Brushes.Black, 20, y); y += 20;
                args.Graphics.DrawString($"Lokasi     : {textBox7.Text}", font, Brushes.Black, 20, y);
            };

            // Akan mem‑popup dialog “Save Print Output As…”
            pd.Print();

        }
    }   
}
