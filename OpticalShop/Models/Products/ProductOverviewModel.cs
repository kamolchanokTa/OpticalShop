﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticalShop.Models.Products
{
    public class ProductOverviewModel
    {
        public List<ProductModel> Products { get; set; }

        public string ProductType { get; set; }
    }
}