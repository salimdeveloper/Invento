using System;
using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.Models;
using Strado.InVento.Persistence.Data;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace Strado.InVento.Persistence.Repositories
{
    internal class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddInventory(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
        }

        public void DeleteInventory(Inventory _inventory)
        {
            _context.Inventory.Remove(_inventory);
        }

        public IEnumerable<Inventory> GetAllInventories()
        {
            return _context.Inventory
                  .Include(p => p.Parts)
                  .Include(b=>b.Parts.Brands).OrderBy(x=>x.LastUpdated).ToList();
        }

        public Inventory GetInventoryByPartsId(int partsId)
        {
            return _context.Inventory.SingleOrDefault(i => i.PartsId == partsId);
        }

        public void UpdateInventory(Inventory _inventory)
        {
            throw new NotImplementedException();
        }
    }
}