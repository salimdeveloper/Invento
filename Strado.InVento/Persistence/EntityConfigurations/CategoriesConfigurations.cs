using Strado.InVento.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Strado.InVento.Persistence.EntityConfigurations
{
    public class CategoriesConfigurations : EntityTypeConfiguration<Categories>
    {
        public CategoriesConfigurations()
        {
            Property(c => c.CategoryName).IsRequired().HasMaxLength(255);
        }
    }
}