using Strado.InVento.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Strado.InVento.Persistence.EntityConfigurations
{
    internal class PartsWithdrawHistoryConfigurations : EntityTypeConfiguration<PartsWithdrawHistory>
    {
        public PartsWithdrawHistoryConfigurations()
        {
            Property(ps => ps.PartsId).IsRequired();

            Property(ps => ps.SoldDate).IsRequired();

            Property(ps => ps.QtyWithdrawn).IsRequired();

            Property(ps => ps.WithdrawlReason).IsRequired();
        }
    }
}