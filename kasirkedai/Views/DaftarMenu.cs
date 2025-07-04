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
using kasirkedai.Controllers;


namespace kasirkedai
{
    public partial class DaftarMenu : Form
    {
        private MenuController controller;

        public object NamaPemesan { get; private set; }

        public DaftarMenu()
        {
            InitializeComponent();
            controller = new MenuController();

            this.Load += DaftarMenu_Load;

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string namaMenu = comboBox1.Text.Trim();
            string metodePembayaran = comboBox2.Text.Trim(); // ✅ sudah dideklarasikan
            string lokasi = comboBox3.Text.Trim();
            string namaPemesan = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(metodePembayaran) || string.IsNullOrEmpty(lokasi) || string.IsNullOrEmpty(namaPemesan))
            {
                MessageBox.Show("Harap isi semua data pemesanan!");
                return;
            }


            bool berhasil = controller.SimpanPesanan(metodePembayaran, lokasi, namaPemesan, out string pesan);
            MessageBox.Show(pesan);

            if (berhasil)
            {
                listBox1.Items.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                textBox2.Clear();
                numericUpDown1.Value = 1;
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
            try
            {
                var menus = controller.LoadMenuList();
                comboBox1.Items.AddRange(menus.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data menu: " + ex.Message);
            }

            // ✅ HAPUS baris comboBox1 = new ComboBox();
            comboBox2.Items.AddRange(new string[] { "Cash", "QRIS", "Debit" });
            comboBox3.Items.AddRange(new string[] { "Dine In", "Take Away" });

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
     


        private void button2_Click(object sender, EventArgs e)
        {
            string namaMenu = comboBox1.Text.Trim();
            int jumlah = (int)numericUpDown1.Value;

            if (string.IsNullOrEmpty(namaMenu))
            {
                MessageBox.Show("Pilih menu terlebih dahulu.");
                return;
            }

            controller.TambahMenu(namaMenu, jumlah);
            decimal harga = controller.GetHargaMenu(namaMenu);
            decimal total = jumlah * harga;

            listBox1.Items.Add($"{namaMenu} x{jumlah} = Rp{total:N0}");
            MessageBox.Show("Menu berhasil ditambahkan!");

            comboBox1.SelectedIndex = -1;
            numericUpDown1.Value = 1;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

