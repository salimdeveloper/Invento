using Microsoft.AspNet.Identity;
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
    public class BrandsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public BrandsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Brand _brand = _unitOfWork.Brands.GetBrandWithBrandId(id);
            if (_brand == null)
            {
                return NotFound();
            }
            _unitOfWork.Brands.DeleteBrandWithBrand(_brand);
            _unitOfWork.Complete();
            return Ok();
        }
    }

}
