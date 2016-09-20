using Strado.InVento.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Strado.InVento.Persistence.EntityConfigurations
{
   public class AddressConfigurations : EntityTypeConfiguration<Address>
    {
        public AddressConfigurations()
        {
            Property(a => a.Address1)
                 .IsRequired()
                 .HasMaxLength(255);

            Property(a => a.City)
               .IsRequired()
               .HasMaxLength(125);

            Property(a => a.State)
            .IsRequired()
            .HasMaxLength(125);

            Property(a => a.ContactName)
            .IsRequired()
            .HasMaxLength(25);

            Property(a => a.ContactNo)
            .IsRequired()
            .HasMaxLength(12);

            Property(a => a.Pin)
            .IsRequired()
            .HasMaxLength(7);
        }
    }
}