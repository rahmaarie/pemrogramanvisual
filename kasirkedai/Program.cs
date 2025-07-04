using System;
using System.Windows.Forms;

namespace kasirkedai
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tampilkan splash screen (Form1)
            Form1 splash = new Form1();
            splash.Show();
            Application.DoEvents(); // agar splash screen dirender

            // Tunggu beberapa detik
            System.Threading.Thread.Sleep(4000);

            splash.Close();

            // Tampilkan form login
            Application.Run(new Form1());
        }
    }
}
