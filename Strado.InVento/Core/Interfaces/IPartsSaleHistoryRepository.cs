using Strado.InVento.Core.Models;

namespace Strado.InVento.Core.Interfaces
{
    public interface IPartsSaleHistoryRepository
    {
        void AddPartWithdrawl(PartsSaleHistory _partsSaleHistory);
    }
}