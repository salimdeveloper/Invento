using System.Collections.Generic;
using Strado.InVento.Core.Models;
using Strado.InVento.Core.ViewModels;

namespace Strado.InVento.Core.Interfaces
{
    public interface IPartsPurchaseRecordsReposiroty
    {
        void AddRecord(PartsPurchaseRecordsViewModel _partsPurchaseRecordsViewModel);
        IEnumerable<PartsPurchaseRecords> GetAllPartsPurchaseRecords();
        PartsPurchaseRecords GetPurchaseRecordsWithId(int id);
    }
}