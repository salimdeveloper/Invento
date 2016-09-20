using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int PartsId { get; set; }
        public Parts Parts { get; set; }
        public int QtyInStock { get; set; }
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Adds New Items Inventory
        /// </summary>
        /// <param name="_partId"></param>
        /// <param name="_qtyToAdd"></param>
        /// <param name="_dateTime"></param>
        public void AddInventory(int _partId,int _qtyToAdd,DateTime _dateTime)
        {
            this.PartsId = _partId;
            this.QtyInStock = _qtyToAdd;
            this.LastUpdated = _dateTime;
        }

        public void DeleteStockQuantity(int _partId, int _qty, DateTime _dateTime)
        {
            if (this.PartsId != _partId)
                throw new ArgumentException(nameof(PartsId));
            this.QtyInStock = QtyInStock - _qty;
            this.LastUpdated = _dateTime;
        }
    }
}