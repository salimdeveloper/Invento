using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Strado.InVento.Core.ViewModels;

namespace Strado.InVento.Core.Models
{
    public class PartsWithdrawHistory
    {
        public int Id { get; set; }
        public int PartsId { get; set; }
        public Parts Parts { get; set; }
        public DateTime SoldDate { get; set; }
        public double SoldPrice { get; set; }
        public int QtyWithdrawn { get; set; }
        public PartWithdrawlReason WithdrawlReason { get; set; }

        internal void Modify(int partsId, int qtyWithdrawn, PartWithdrawlReason withdrawlReason, double soldPrice, DateTime soldDate)
        {
            this.PartsId = partsId;
            this.QtyWithdrawn = qtyWithdrawn;
            this.WithdrawlReason = withdrawlReason;
            this.SoldPrice = soldPrice;
            this.SoldDate = soldDate;
            
        }
    }
}