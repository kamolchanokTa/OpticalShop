using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticalShop.Models.Products
{
    public class LenseModel
    {
        public string FamilyLense { get; set; }

        public string FamilyLenseText { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }
        public string CategoryText { get; set; }

        public string Process { get; set; }
        public string ProcessText { get; set; }

        public string Index { get; set; }

        public string IndexText { get; set; }

        public string Material { get; set; }
        public string MaterialText { get; set; }

        public string Chromatics { get; set; }
        public string ChromaticsText { get; set; }

        public string ProductName { get; set; }

        public double SPHMIN { get; set; }

        public double SPHMAX { get; set; }

        public double CYLMIN { get; set; }

        public double CYLMAX { get; set; }

        public double ADDMIN { get; set; }

        public double ADDMAX { get; set; }

        public string Type { get; set; }

        public string ProductType { get; set; }

        public string Brand { get; set; }

        public string LenseId { get; set; }
        public int InStock { get; set; }
    }
}