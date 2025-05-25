﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace kasirkedai.Models
{
    class MenuItem
    {
        public string Nama { get; set; }
        public int Jumlah { get; set; }
        public decimal Harga { get; set; }

        public decimal Total => Harga * Jumlah;
    }
}

