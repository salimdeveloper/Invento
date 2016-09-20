using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.Models;

namespace Strado.InVento.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IApplicationDbContext _context;
        public CategoriesRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteCategoryWithCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Categories> GetAllNonDeleteCategories()
        {
            return _context.Categories
                .Where(c=>c.IsDelete==false)
                .ToList();
        }

        public Categories GetCategoryWithCategoryId(int id)
        {
            return _context.Categories.Single(c => c.Id == id && c.IsDelete == false);
        }
    }
}