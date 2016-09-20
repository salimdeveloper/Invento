using Strado.InVento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Strado.InVento.Core.Models;
using Strado.InVento.Persistence.Utilies;

namespace Strado.InVento.Persistence.Repositories
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly IApplicationDbContext _context;
        public BrandsRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBrand(Brand model)
        {
            _context.Brands.Add(model);
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _context.Brands.ToList();
        }

        public Brand GetBrandWithBrandId(int id)
        {
            return _context.Brands.Single(x => x.Id == id);
        }
        public void DeleteBrandWithBrand(Brand brand)
        {
            _context.Brands.Remove(brand);
        }
    }
}