﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CreateProduct
    {
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public Boolean IsActive { get; set; }
    }
}
