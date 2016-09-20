using Strado.InVento.Core.Models;
using System.Collections.Generic;

namespace Strado.InVento.Core.Interfaces
{
    public interface IBrandsRepository
    {
        void AddBrand(Brand model);
        IEnumerable<Brand> GetAllBrands();
        Brand GetBrandWithBrandId(int id);
        void DeleteBrandWithBrand(Brand brand);
    }
}