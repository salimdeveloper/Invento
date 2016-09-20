using Strado.InVento.Core.Models;
using System.Collections.Generic;

namespace Strado.InVento.Core.Interfaces
{
    public interface ISupplierRepository
    {
        void AddSupplier(Suppliers _supplier);
        IEnumerable<Suppliers> GetAllSuppliers();
        Suppliers GetSupplierWithId(int id);
        void DeleteSupplierWithId(int id);
    }
}