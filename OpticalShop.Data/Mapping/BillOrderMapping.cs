using OpticalShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Data.Mapping
{
    public class BillOrderMapping : EntityTypeConfiguration<BillOrder>
    {
        public BillOrderMapping()
        {
            ToTable("BillOrder");

            HasKey(c => c.Id);

            Property(c => c.Amount);

            Property(c => c.BillId);
            Property(c => c.CustomerId);
            Property(c => c.IsCuttingStock);
            Property(c => c.LensId);
            Property(c => c.ProductId);
            Property(c => c.CuttingStockDate);
        }
    }
}
