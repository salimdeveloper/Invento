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
    public class PartsController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public PartsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Parts _parts = _unitOfWork.Parts.GetPartsWithPartId(id);
            if (_parts == null || _parts.IsDelete)
                return NotFound();
            _parts.Deleted();
            _unitOfWork.Complete();
            return Ok();
        
        }
    }
}
