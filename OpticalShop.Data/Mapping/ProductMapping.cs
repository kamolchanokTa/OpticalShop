using OpticalShop.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace OpticalShop.Data.Mapping
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            ToTable("Product");

            HasKey(c => c.Id);
            Property(c => c.ProductName);
            Property(c => c.ProductType);
            Property(c => c.Brand);
            Property(c => c.Price);
            Property(c => c.LenseId);
            Property(c => c.Coating);
            Property(c => c.Tint);
            Property(c => c.ProductImage);
            Property(c => c.Sph);
            Property(c => c.Cyl);
            Property(c => c.Axis);
            Property(c => c.Add);
            Property(c => c.InStock);
        }
    }
}
