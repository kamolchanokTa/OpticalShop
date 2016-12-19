using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticalShop.Models.Bill
{
    public class BillOrderModel
    {
        public string BillId { get; set; }

        public string CustomerId { get; set; }

        public List<SelectListItem> CustomerName { get; set; }

        public string ProductId { get; set; }

        public List<SelectListItem> ProductName { get; set; }

        public string LensId { get; set; }

        public int Amount { get; set; }

        public bool IsCuttingStock { get; set; }

        public string CuttingStockDate { get; set; }
    }
}