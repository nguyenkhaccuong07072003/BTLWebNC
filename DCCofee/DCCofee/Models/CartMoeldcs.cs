﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCCofee.Models
{
    public class CartMoeldcs
    {
        public int Id { get; set; }
        public Models.SanPham ChiTiet { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }
    }
}