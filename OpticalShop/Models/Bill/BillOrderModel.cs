using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticalShop.Models.Bill
{
    public class BillOrderModel
    {
        public string Id { get; set; }
        public string BillId { get; set; }

        public string CustomerId { get; set; }

        public List<SelectListItem> CustomersName { get; set; }

        public string CustomerName { get; set; }

        public string ProductId { get; set; }

        public List<SelectListItem> ProductsName { get; set; }

        public string ProductName { get; set; }

        public string LensId { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public double PriceperOne { get; set; }

        public bool IsCuttingStock { get; set; }

        public string CuttingStockDate { get; set; }

        public bool IsEnough { get; set; }

        public List<SelectListItem> ProductCategories { get; set; }

        public string SelectedProductCategory { get; set; }
    }
}