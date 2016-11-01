using Microsoft.AspNet.Identity.EntityFramework;
using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.Models;
using Strado.InVento.Persistence.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Strado.InVento.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Parts> Parts { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<PartsWithdrawHistory>  PartsWithdrawlHistory { get; set; }
        public DbSet<PartsPurchaseRecords> PartsPurchaseRecords { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BrandConfigurations());

            modelBuilder.Configurations.Add(new PartsConfigurations());

            modelBuilder.Configurations.Add(new AddressConfigurations());

            modelBuilder.Configurations.Add(new SuppliersConfigurations());

            modelBuilder.Configurations.Add(new InventoryConfigurations());

            modelBuilder.Configurations.Add(new PartsWithdrawHistoryConfigurations());

            modelBuilder.Configurations.Add(new PartsPurchaseRecordsConfigurations());
        
            base.OnModelCreating(modelBuilder); 
        }
    }
}