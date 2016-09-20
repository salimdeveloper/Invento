using Strado.InVento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strado.InVento.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Categories
        [Authorize]
        public ViewResult CategoriesList()
        {
            var _categories = _unitOfWork.Categories.GetAllNonDeleteCategories();
            return View(_categories);
            
        }
    }
}