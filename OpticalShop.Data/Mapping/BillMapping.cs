using OpticalShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Data.Mapping
{
    public class BillMapping : EntityTypeConfiguration<Bill>
    {
        public BillMapping()
        {
            ToTable("Bill");

            HasKey(c => c.Id);

            Property(c => c.BillingDate);

            Property(c => c.BillName);
            Property(c => c.Comment);
            Property(c => c.TotalPrice);
            Property(c => c.IsCuttingStockAll);
        }
    }
}
