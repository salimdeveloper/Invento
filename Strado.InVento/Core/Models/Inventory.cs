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



        public void DeleteStockQuantity(int _partId, int _qty, DateTime _dateTime)
        {
            if (this.PartsId != _partId)
                throw new ArgumentException(nameof(PartsId));
            this.QtyInStock = QtyInStock - _qty;
            this.LastUpdated = _dateTime;
        }
        public void AddStockQuantity(int _partId, int _qty, DateTime _dateTime)
        {
            if (this.PartsId != _partId)
                throw new ArgumentException(nameof(PartsId));
            this.QtyInStock = QtyInStock + _qty;
            this.LastUpdated = _dateTime;
        }

        internal void UpdateStockQuantity(int _partID, int _currentQty, int _newQty)
        {   
            if (this.PartsId != _partID)
                throw new ArgumentException(nameof(PartsId));

            if (_currentQty < _newQty)
                this.QtyInStock = this.QtyInStock + Math.Abs(_currentQty - _newQty);

            else if (_currentQty > _newQty)
                this.QtyInStock = this.QtyInStock - Math.Abs(_currentQty - _newQty);
            else
            this.QtyInStock = QtyInStock;

            this.LastUpdated = DateTime.Now;

        }
    }
}