using Strado.InVento.Core.Models;
using System.Collections.Generic;

namespace Strado.InVento.Core.Interfaces
{
    public interface IPartsRepository
    {
        IEnumerable<Parts> GetAllParts();
        void AddPart(Parts parts);
        Parts GetPartsWithPartId(int id);
    }
}