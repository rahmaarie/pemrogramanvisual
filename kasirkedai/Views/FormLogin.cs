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
using kasirkedai.Controllers;
using kasirkedai.Models;


namespace kasirkedai
{
    public partial class FormLogin: Form
    {
        private LoginController loginController;
        public FormLogin()
        {
            InitializeComponent();
            loginController = new LoginController();
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
            string username = input_username.Text;
            string password = input_password.Text;

            bool isValid = loginController.AuthenticateUser(username, password);

            if (isValid)
            {
                MessageBox.Show("Login berhasil!");
                new DaftarMenu().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau password salah!");
            }
        }


        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
