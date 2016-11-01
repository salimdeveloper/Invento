using Strado.InVento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Strado.InVento.Controllers.Api
{
    public class HomeController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpDelete]
        public IHttpActionResult UsersCount()
        {
            //var user = _unitOfWork.U
            //if (_category == null || _category.IsDelete)
            //    return NotFound();

            //_category.Deleted();
            //_unitOfWork.Complete();
            return Ok();
        }

    }
}
