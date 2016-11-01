using System.Collections.Generic;
using Strado.InVento.Core.Models;

namespace Strado.InVento.Core.Interfaces
{
    public interface IPartsWithdrawHistoryRepository
    {
        void AddPartWithdrawl(PartsWithdrawHistory _partsSaleHistory);
        IEnumerable<PartsWithdrawHistory> GetAllPartsWithdrawl();
        PartsWithdrawHistory GetPartsWithdrawlByWithdrawalId(int id);
        void DeletePartsWithDrawHistoryById(int id);
    }
}