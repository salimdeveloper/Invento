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
    public class SupplierController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpDelete]
        public IHttpActionResult Deactivate(int id)
        {
            Suppliers _suppliers = _unitOfWork.Suppliers.GetSupplierWithId(id);
            if (_suppliers == null) 
                return NotFound();

            if(!_suppliers.IsDeactive)
            _suppliers.Deactivate();

            else if (_suppliers.IsDeactive)
                _suppliers.Activate();

            _unitOfWork.Complete();
            return Ok();
        }
    }
}
