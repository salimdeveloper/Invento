using Strado.InVento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Strado.InVento.Core.Models;

namespace Strado.InVento.Persistence.Repositories
{
    public class SupplierRepository:ISupplierRepository
    {
        private readonly IApplicationDbContext _context;

        public SupplierRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddSupplier(Suppliers _supplier)
        {
            _context.Suppliers.Add(_supplier);
        }

        public void DeleteSupplierWithId(int id)
        {
            var _supplier = this.GetSupplierWithId(id);
            _context.Address.Remove(_supplier.Address);
            _context.Suppliers.Remove(_supplier);
            
        }

        public IEnumerable<Suppliers> GetAllSuppliers()
        {
            return _context.Suppliers.Include(a=>a.Address).ToList();
        }

        public Suppliers GetSupplierWithId(int id)
        {
            return _context.Suppliers.Include(a=>a.Address).SingleOrDefault(s => s.Id == id);
        }
    }
}