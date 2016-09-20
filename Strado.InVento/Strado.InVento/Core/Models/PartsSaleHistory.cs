using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Models
{
    public class PartsSaleHistory
    {
        public int Id { get; set; }
        public int PartsId { get; set; }
        public Parts Parts { get; set; }
        public DateTime SoldDate { get; set; }
        public double SoldPrice { get; set; }
        public int QtyWithdrawn { get; set; }
        public PartWithdrawlReason WithdrawlReason { get; set; }
    }
}