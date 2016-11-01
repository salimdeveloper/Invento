using Strado.InVento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Strado.InVento.Core.Models;

namespace Strado.InVento.Persistence.Repositories
{
    public class PartsRepository : IPartsRepository
    {
        private readonly IApplicationDbContext _context;
        public PartsRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPart(Parts parts)
        {
            _context.Parts.Add(parts);
        }

        public IEnumerable<Parts> GetAllParts()
        {
            return _context.Parts
                .Where(p => p.IsDelete == false).Include(c=>c.Categories).Include(b=>b.Brands)
                .ToList();
        }
        public IEnumerable<Parts> GetAllPartsIncludeDeleted()
        {
            return _context.Parts
                .Include(c => c.Categories).Include(b => b.Brands)
                .ToList();
        }
        public IEnumerable<Parts> GetAllPartsExcludeDeleted()
        {
            return _context.Parts.Where(p=>p.IsDelete==false)
                .Include(c => c.Categories).Include(b => b.Brands)
                .ToList();
        }

        public Parts GetPartsWithPartId(int id)
        {
            return _context.Parts.SingleOrDefault(p => p.Id == id);
        }
    }
}