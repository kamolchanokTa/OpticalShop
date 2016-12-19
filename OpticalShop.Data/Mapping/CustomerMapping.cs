using OpticalShop.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace OpticalShop.Data.Mapping
{
    public class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            ToTable("Customer");

            HasKey(c => c.Id);

            Property(c => c.Address);
            Property(c => c.FirstName);
            Property(c => c.FamilyName);
            Property(c => c.DateOfBirth);
            Property(c => c.Tel);
            Property(c => c.Mobile);
            Property(c => c.Allergy);
            Property(c => c.RightSph);
            Property(c => c.RightCyl);
            Property(c => c.RightAxis);
            Property(c => c.RightAdd);
            Property(c => c.LeftAdd);
            Property(c => c.LeftAxis);
            Property(c => c.LeftSph);
            Property(c => c.LeftCyl);
            Property(c => c.PD);
            Property(c => c.PH);
            Property(c => c.Prism);

        }
    }
}
