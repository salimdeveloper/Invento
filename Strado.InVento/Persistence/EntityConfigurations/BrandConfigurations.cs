using Strado.InVento.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Strado.InVento.Persistence.EntityConfigurations
{
    public class BrandConfigurations: EntityTypeConfiguration<Brand>
    {
        public BrandConfigurations()
        {
            
            Property(b => b.BrandName)
                .IsRequired()
                .HasMaxLength(255);

            Property(b => b.LogoImgSrc).HasMaxLength(255);
        }
    }
}