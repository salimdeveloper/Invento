using Strado.InVento.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.ViewModels
{
    public class PartsSaleHistoryViewModel
    {
        public int Id { get; set; }
        public int PartsId { get; set; }
        public IEnumerable<Parts> Parts { get; set; }
        public DateTime SoldDate { get; set; }
        public double SoldPrice { get; set; }
        public int QtyWithdrawn { get; set; }
        public PartWithdrawlReason WithdrawlReason { get; set; }
    }
}