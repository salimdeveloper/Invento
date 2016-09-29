using Strado.InVento.Core.Interfaces;
using System;
using System.Collections.Generic;
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
    }
}