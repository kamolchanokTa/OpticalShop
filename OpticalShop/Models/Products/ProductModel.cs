using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticalShop.Models.Products
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
        public string BrandText { get; set; }
        public double Price { get; set; }
        public string LenseId { get; set; }
        public string Coating { get; set; }
        public string Tint { get; set; }
        public byte[] ProductImage { get; set; }
        public double Sph { get; set; }
        public double Cyl { get; set; }
        public double Axis { get; set; }
        public double Add { get; set; }
        public string Id { get; set; }
        public int InStock { get; set; }

        public List<SelectListItem> Brands { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}