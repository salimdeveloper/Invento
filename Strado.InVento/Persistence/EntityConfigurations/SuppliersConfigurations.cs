using Strado.InVento.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Strado.InVento.Persistence.EntityConfigurations
{
    internal class SuppliersConfigurations : EntityTypeConfiguration<Suppliers>
    {
        public SuppliersConfigurations()
        {
            Property(s => s.SupplierName)
               .IsRequired()
               .HasMaxLength(255);

            Property(s => s.AddressId)
               .IsRequired();
               
        }
    }
}