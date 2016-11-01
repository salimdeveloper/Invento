using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Strado.InVento.Core.Models;

namespace Strado.InVento.Core.ViewModels
{
    public class DashbordViewModel
    {
        public IEnumerable<Inventory> Inventories { get; set; }
        public IEnumerable<PartsWithdrawHistory> PartsWithdrawls { get; set; }
        public IEnumerable<PartsPurchaseRecords> PartsPurchases { get; set; }
    }
}