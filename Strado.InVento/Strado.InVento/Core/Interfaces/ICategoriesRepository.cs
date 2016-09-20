using Strado.InVento.Core.Models;
using System.Collections;
using System.Collections.Generic;

namespace Strado.InVento.Core.Interfaces
{
    public interface ICategoriesRepository
    {
        IEnumerable<Categories> GetAllCategories();
        Categories GetCategoryWithCategoryId(int id);
        void DeleteCategoryWithCategoryId(int id);
        IEnumerable<Categories> GetAllNonDeleteCategories();
    }
}