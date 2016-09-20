using Strado.InVento.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Strado.InVento.Persistence.EntityConfigurations
{
    public class InventoryConfigurations : EntityTypeConfiguration<Inventory>
    {
        public InventoryConfigurations()
        {
            Property(i => i.PartsId)
                .IsRequired();
            Property(i => i.QtyInStock)
                            .IsRequired();
            Property(i => i.LastUpdated)
                            .IsRequired();
        }
    }
}