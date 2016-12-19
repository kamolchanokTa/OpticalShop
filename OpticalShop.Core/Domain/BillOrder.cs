using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Core.Domain
{
    public class BillOrder : EntityBase
    {
        public string BillId { get; set; }

        public string CustomerId { get; set; }

        public string ProductId { get; set; }

        public string LensId { get; set; }

        public int Amount { get; set; }

        public bool IsCuttingStock { get; set; }

        public string CuttingStockDate { get; set; }
    }
}
