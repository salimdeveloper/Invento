using System;
using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.Models;
using Strado.InVento.Persistence.Data;
using System.Linq;

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