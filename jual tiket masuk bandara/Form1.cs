using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jual_tiket_masuk_bandara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HAIN24I\TIKET;Initial Catalog=BandaraDB;TrustServerCertificate=True;Integrated Security=True;");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into Tickets values(@no,@date,@from,@destination)", con);
            cnn.Parameters.AddWithValue("@No", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@From", textBox3.Text);
            cnn.Parameters.AddWithValue("@Destination", textBox4.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HAIN24I\TIKET;Initial Catalog=BandaraDB;TrustServerCertificate=True;Integrated Security=True;");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from Tickets", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HAIN24I\TIKET;Initial Catalog=BandaraDB;TrustServerCertificate=True;Integrated Security=True;");
            con.Open();
            SqlCommand cnn = new SqlCommand("update Tickets set date=@date,[from]=@from,destination=@destination where no=@no", con);
            cnn.Parameters.AddWithValue("@No", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@From", textBox3.Text);
            cnn.Parameters.AddWithValue("@Destination", textBox4.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HAIN24I\TIKET;Initial Catalog=BandaraDB;TrustServerCertificate=True;Integrated Security=True;");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete Tickets where no=@no", con);
            cnn.Parameters.AddWithValue("@No", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HAIN24I\TIKET;Initial Catalog=BandaraDB;TrustServerCertificate=True;Integrated Security=True;");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from Tickets", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;

        }

    }
}
