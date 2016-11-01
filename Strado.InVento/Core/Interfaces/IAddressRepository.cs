using Strado.InVento.Core.Models;

namespace Strado.InVento.Core.Interfaces
{
    public interface IAddressRepository
    {
        Address GetAddressWithId(int id);
    }
}