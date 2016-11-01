using Strado.InVento.Core.Interfaces;
using Strado.InVento.Persistence.Data;
using Strado.InVento.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBrandsRepository Brands { get; private set; }

        public ICategoriesRepository Categories { get; private set; }

        public IPartsRepository Parts { get; private set; }

        public ISupplierRepository Suppliers { get; private set; }

        public IPartsWithdrawHistoryRepository PartsWithdrawHistories { get; private set; }

        public IPartsPurchaseRecordsReposiroty PartsPurchaseRecords { get; private set; }

        public IInventoryRepository Inventory { get; private set; }

        public IAddressRepository Addresses { get; private set; }
        
            

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Brands = new BrandsRepository(context);
            Categories = new CategoriesRepository(context);
            Parts = new PartsRepository(context);
            Suppliers = new SupplierRepository(context);
            PartsWithdrawHistories = new PartsWithdrawHistoryRepository(context);
            PartsPurchaseRecords = new PartsPurchaseRecordsReposiroty(context);
            Inventory = new InventoryRepository(context);
            Addresses = new AddressRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}