using Strado.InVento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Strado.InVento.Core.Models;

namespace Strado.InVento.Persistence.Repositories
{
    public class PartsSaleHistoryRepository:IPartsSaleHistoryRepository
    {
        private readonly IApplicationDbContext _context;
        public PartsSaleHistoryRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPartWithdrawl(PartsSaleHistory _partsSaleHistory)
        {
            _context.PartsSaleHistory.Add(_partsSaleHistory);
        }
    }
}