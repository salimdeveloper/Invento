using Strado.InVento.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Strado.InVento.Persistence.EntityConfigurations
{
    internal class PartsPurchaseRecordsConfigurations : EntityTypeConfiguration<PartsPurchaseRecords>
    {
        public PartsPurchaseRecordsConfigurations()
        {

            Property(p => p.PartsId)
                .IsRequired();
            Property(p => p.PurchaseDate)
                .IsRequired();
            Property(p => p.PurchaseQty)
                .IsRequired();
            Property(p => p.SuppliersId)
                .IsRequired();
            Property(p => p.PurchasePrice)
                .IsRequired();

        }
    }
}