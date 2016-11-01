using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Strado.InVento.Controllers.Api
{
    public class PartsWithdrawHistoriesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public PartsWithdrawHistoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            PartsWithdrawHistory _history = _unitOfWork.PartsWithdrawHistories.GetPartsWithdrawlByWithdrawalId(id);
            Inventory _inventory = _unitOfWork.Inventory.GetInventoryByPartsId(_history.PartsId);
            _unitOfWork.PartsWithdrawHistories.DeletePartsWithDrawHistoryById(id);
            if (_inventory != null)
                _inventory.AddStockQuantity(_history.PartsId, _history.QtyWithdrawn,DateTime.Now);
            
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
