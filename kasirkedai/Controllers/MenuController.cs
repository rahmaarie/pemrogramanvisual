using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kasirkedai.Models;


namespace kasirkedai.Controllers
{
    internal class MenuController
    {
        private List<string> selectedMenus = new List<string>();
        private List<int> selectedQuantities = new List<int>();
        private List<decimal> selectedPrices = new List<decimal>();

        public IReadOnlyList<string> SelectedMenus => selectedMenus.AsReadOnly();
        public IReadOnlyList<int> SelectedQuantities => selectedQuantities.AsReadOnly();
        public IReadOnlyList<decimal> SelectedPrices => selectedPrices.AsReadOnly();

        public List<string> LoadMenuList()
        {
            return MenuService.GetNamaMenu();
        }

        public decimal GetHargaMenu(string namaMenu)
        {
            return MenuService.GetHargaMenu(namaMenu);
        }

        public void TambahMenu(string namaMenu, int jumlah)
        {
            decimal harga = GetHargaMenu(namaMenu);
            selectedMenus.Add(namaMenu);
            selectedQuantities.Add(jumlah);
            selectedPrices.Add(harga);
        }

        public void ClearSelectedMenus()
        {
            selectedMenus.Clear();
            selectedQuantities.Clear();
            selectedPrices.Clear();
        }

        public bool SimpanPesanan(string metodePembayaran, string lokasi, string namaPemesan, out string pesan)
        {
            if (selectedMenus.Count == 0)
            {
                pesan = "Tambahkan menu terlebih dahulu sebelum memesan!";
                return false;
            }

            try
            {
                int idTransaksi = MenuService.InsertTransaksi(metodePembayaran, lokasi, namaPemesan, DateTime.Now);

                for (int i = 0; i < selectedMenus.Count; i++)
                {
                    MenuService.InsertDetailPesanan(idTransaksi, selectedMenus[i], selectedQuantities[i], selectedPrices[i]);
                }
                ClearSelectedMenus();
                pesan = "Pesanan berhasil disimpan!";
                return true;
            }
            catch (Exception ex)
            {
                pesan = "Gagal menyimpan pesanan: " + ex.Message;
                return false;
            }
        }

    }
}


