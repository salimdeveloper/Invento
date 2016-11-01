using Strado.InVento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Strado.InVento.Persistence.Data;
using Strado.InVento.Core.ViewModels;
using Strado.InVento.Core.Models;

namespace Strado.InVento.Persistence.Repositories
{
    public class PartsPurchaseRecordsReposiroty : IPartsPurchaseRecordsReposiroty
    {
        private readonly ApplicationDbContext _context;

        public PartsPurchaseRecordsReposiroty(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddRecord(PartsPurchaseRecordsViewModel ViewModel)
        {
            var _PartsPurchaseRecords = new PartsPurchaseRecords
            {
                PartsId = ViewModel.PartsId,
                PurchaseDate = ViewModel.PurchaseDate,
                PurchasePrice = ViewModel.PurchasePrice,
                PurchaseQty = ViewModel.PurchaseQty,
                SuppliersId = ViewModel.SuppliersId
            };
            
                
            
            _context.PartsPurchaseRecords.Add(_PartsPurchaseRecords);
        }

        public IEnumerable<PartsPurchaseRecords> GetAllPartsPurchaseRecords()
        {
            return _context.PartsPurchaseRecords
                .Include(p=>p.Parts)
                .Include(b=>b.Parts.Brands)
                .Include(c=>c.Parts.Categories)
                .OrderByDescending(x=>x.PurchaseDate)
                .ToList();
        }

        public PartsPurchaseRecords GetPurchaseRecordsWithId(int id)
        {
            return _context.PartsPurchaseRecords.Include(p => p.Parts)
                .Include(b => b.Parts.Brands)
                .Include(c => c.Parts.Categories).Where(x => x.Id == id).SingleOrDefault();
        }
    }
}