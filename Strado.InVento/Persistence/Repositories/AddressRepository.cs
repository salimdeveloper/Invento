using System;
using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.Models;
using Strado.InVento.Persistence.Data;
using System.Linq;

namespace Strado.InVento.Persistence.Repositories
{
    class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Address GetAddressWithId(int id)
        {
            return _context.Address.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}