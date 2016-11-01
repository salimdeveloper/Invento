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
    public class PartsPurchaseRecordsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public PartsPurchaseRecordsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            PartsPurchaseRecords _purchaseRecords = _unitOfWork.PartsPurchaseRecords.GetPurchaseRecordsWithId(id);
            Inventory _inventory = _unitOfWork.Inventory.GetInventoryByPartsId(id);
            if (_inventory == null || _purchaseRecords.IsDelete)
                return NotFound();

        }
    }
}
