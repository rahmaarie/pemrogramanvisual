using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kasirkedai.Models
{
    public class ReceiptItem
    {
        public int No { get; set; }          // Nomor urut
        public string Nama { get; set; }     // Nama menu
        public int Qty { get; set; }         // Jumlah beli
        public decimal Harga { get; set; }   // Harga satuan

        // Otomatis menghitung harga x qty
        public decimal SubTotal => Qty * Harga;
    }

    public class ReceiptPayload
    {
        public string NoPesanan { get; set; }        // ID transaksi
        public DateTime Tanggal { get; set; }        // Tanggal transaksi
        public List<ReceiptItem> Items { get; set; } = new List<ReceiptItem>();

        // Total dari seluruh item
        public decimal TotalHarga => Items.Sum(item => item.SubTotal);
    }
}
