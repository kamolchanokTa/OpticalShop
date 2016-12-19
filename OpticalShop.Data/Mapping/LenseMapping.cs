using OpticalShop.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace OpticalShop.Data.Mapping
{
    public  class LenseMapping : EntityTypeConfiguration<Lense>
    {
        public LenseMapping()
        {
            ToTable("Lense");

            HasKey(c => c.Id);
            Property(c => c.ADDMAX);
            Property(c => c.ADDMIN);
            Property(c => c.Category);
            Property(c => c.Chromatics);
            Property(c => c.CYLMAX);
            Property(c => c.CYLMIN);
            Property(c => c.FamilyLense);
            Property(c => c.Index);
            Property(c => c.Material);
            Property(c => c.Process);
            Property(c => c.ProductName);
            Property(c => c.SPHMAX);
            Property(c => c.SPHMIN);
            Property(c => c.Type);
            Property(c => c.ProductType);
            Property(c => c.Brand);
            Property(c => c.Price);
            Property(c => c.InStock);

            HasRequired(m => m.Product)
                .WithMany(m => m.LenseItems)
                .HasForeignKey(m => m.ProductId);
        }
    }
}
