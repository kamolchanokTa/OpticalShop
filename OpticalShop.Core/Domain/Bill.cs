using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Core.Domain
{
    public class Bill : EntityBase
    {
        public string Comment { get; set; }

        public string OrderDate { get; set; }

        public string BillingDate { get; set; }

        public double TotalPrice { get; set; }

        public string BillName { get; set; }

        public bool IsCuttingStockAll { get; set; }
    }
}
