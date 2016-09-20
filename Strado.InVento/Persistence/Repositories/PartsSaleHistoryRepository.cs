using Strado.InVento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Persistence.Repositories
{
    public class PartsSaleHistoryRepository:IPartsSaleHistoryRepository
    {
        private readonly IApplicationDbContext _context;
        public PartsSaleHistoryRepository(IApplicationDbContext context)
        {
            _context = context;
        }
    }
}