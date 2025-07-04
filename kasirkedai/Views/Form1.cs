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
    public partial class Form1: Form
    {
        private Timer splashTimer;
        public Form1()
        {
            InitializeComponent();
            splashTimer = new Timer();
            splashTimer.Interval = 3000;
            splashTimer.Tick += splashTimer_Tick;
            splashTimer.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            splashTimer.Start();
        }
        private void splashTimer_Tick(object sender, EventArgs e)
        {
            splashTimer.Stop();
            new FormLogin().Show();
            this.Hide();
        }
    }
}
