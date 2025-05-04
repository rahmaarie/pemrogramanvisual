using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace kasirkedai
{
    public partial class FormLogin: Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            input_username.Text = "";
            input_password.Text = "";
            input_password.UseSystemPasswordChar = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Ganti connection string sesuai dengan nama server & database kamu
            string connectionString = @"Data Source=LAPTOP-2A7QU8GB;Initial Catalog=kasirkedaidb;Integrated Security=True;TrustServerCertificate=True;";

            using (Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "SELECT COUNT(*) FROM tbkaryawan WHERE Username = @Username AND Password = @Password";
                    using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", input_username.Text);
                        cmd.Parameters.AddWithValue("@Password", input_password.Text);

                        int result = (int)cmd.ExecuteScalar();

                        if (result > 0)
                        {
                            MessageBox.Show("Login berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Tampilkan form menu utama
                            DaftarMenu formMenu = new DaftarMenu();
                            formMenu.Show();

                            this.Hide(); // Sembunyikan form login
                        }
                        else
                        {
                            MessageBox.Show("Username atau password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
