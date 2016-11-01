using Strado.InVento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Strado.InVento.Core.Models;
using System.Data.Entity;

namespace Strado.InVento.Persistence.Repositories
{
    public class PartsWithdrawHistoryRepository:IPartsWithdrawHistoryRepository
    {
        private readonly IApplicationDbContext _context;
        public PartsWithdrawHistoryRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPartWithdrawl(PartsWithdrawHistory _partsSaleHistory)
        {
            _context.PartsWithdrawlHistory.Add(_partsSaleHistory);
        }

        public void DeletePartsWithDrawHistoryById(int id)
        {
            _context.PartsWithdrawlHistory.Remove(GetPartsWithdrawlByWithdrawalId(id));
        }

        public IEnumerable<PartsWithdrawHistory> GetAllPartsWithdrawl()
        {
            return _context.PartsWithdrawlHistory.OrderBy(d => d.SoldDate)
                .Include(p=>p.Parts).ToList();
        }

        public PartsWithdrawHistory GetPartsWithdrawlByWithdrawalId(int id)
        {
            return _context.PartsWithdrawlHistory
                
                .Where(w => w.Id == id)
                .Include(p => p.Parts)
                .SingleOrDefault();
        }
    }
}