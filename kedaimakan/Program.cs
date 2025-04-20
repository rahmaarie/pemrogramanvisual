namespace kedaimakan
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Tampilkan splash screen (Form1)
            Form1 splash = new Form1();
            splash.Show();
            Application.DoEvents(); // biar UI splash muncul dulu

            // Tunggu 10 detik (3000 ms)
            System.Threading.Thread.Sleep(3000);

            splash.Close();

            // Tampilkan form login (Form2)
            Application.Run(new FormLogin());
        }
    }
}
