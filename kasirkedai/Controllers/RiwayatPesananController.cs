using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kasirkedai.Models;
using static kasirkedai.DatabaseHelper;
using Microsoft.Data.SqlClient;

namespace kasirkedai.Controllers
{
    public class RiwayatPesananController
    {
        private readonly RiwayatPesananModel model;

        public RiwayatPesananController()
        {
            model = new RiwayatPesananModel();
        }

        public DataTable LoadData()
        {
            return model.GetRiwayat();
        }

        public void UpdateData(string id, string namaPemesan, string metode, string lokasi, int jumlah, decimal harga)
        {
            model.UpdateTransaksi(id, namaPemesan, metode, lokasi, jumlah, harga);
        }

        public void DeleteData(string id)
        {
            model.DeleteTransaksi(id);
        }
    }
}