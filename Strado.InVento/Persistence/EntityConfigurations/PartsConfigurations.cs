using Strado.InVento.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Strado.InVento.Persistence.EntityConfigurations
{
    public class PartsConfigurations:EntityTypeConfiguration<Parts>
    {
        public PartsConfigurations()
        {
            Property(p => p.PartName)
                .IsRequired()
                .HasMaxLength(255);

            Property(p => p.PartImageUrl)
              .HasMaxLength(255);

            Property(p => p.PartDetails)
              .IsRequired()
              .IsMaxLength();

            
              
        }
    }
}