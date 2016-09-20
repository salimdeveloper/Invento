using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Strado.InVento.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Categories _category = _unitOfWork.Categories.GetCategoryWithCategoryId(id);
            if (_category == null|| _category.IsDelete)
                return NotFound();

            _category.Deleted();
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
