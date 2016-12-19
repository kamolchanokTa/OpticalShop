using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OpticalShop.Models.Bill
{
    public class BillModel
    {
        public string Id { get; set; }
        public string Comment { get; set; }

        public string OrderDate { get; set; }

        public string BillingDate { get; set; }

        public double TotalPrice { get; set; }

        public string BillName { get; set; }

        public bool IsCuttingStockAll { get; set; }

        public string FamilyName { get; set; }

        public List<BillOrderModel> BillOrders { get; set; }

        public List<SelectListItem> FamiliesName { get; set; }

        public string SelectedFamilyName { get; set; }
    }
}