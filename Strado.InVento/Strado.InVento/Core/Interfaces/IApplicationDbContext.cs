using Strado.InVento.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strado.InVento.Core.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<Categories> Categories { get; set; }
        DbSet<Parts> Parts { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<Suppliers> Suppliers { get; set; }
        DbSet<Inventory> Inventory { get; set; }
        DbSet<PartsSaleHistory> PartsSaleHistory { get; set; }
    }
}
