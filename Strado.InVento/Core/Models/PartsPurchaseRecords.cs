using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Models
{
    public class PartsPurchaseRecords
    {
        public int Id { get; set; }
        public int PartsId { get; set; }
        public Parts Parts { get; set; }
        public double PurchasePrice { get; set; }
        public int PurchaseQty { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int SuppliersId { get; set; }
        public Suppliers Suppliers { get; set; }

        internal void Modify(double purchasePrice, int purchaseQty, DateTime purchaseDate, int suppliersId)
        {
            PurchaseDate = purchaseDate;
            PurchasePrice = purchasePrice;
            PurchaseQty = purchaseQty;
            SuppliersId = suppliersId;
            
        }
    }
}