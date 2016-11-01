using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.Models;
using Strado.InVento.Core.ViewModels;
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
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CategoriesViewModel
            {
                Heading = "Add new category"
            };
            return View(viewModel);
          
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriesViewModel _viewModel)
        {
            if (!ModelState.IsValid)
            {
                _viewModel.Heading = "Add new category";
                return View("Create", _viewModel);
            }
            var _categoryModel = new Categories
            {
                CategoryName = _viewModel.CategoryName
               
            };
            _unitOfWork.Categories.AddCategory(_categoryModel);
            _unitOfWork.Complete();
            return RedirectToAction("CategoriesList", "Categories");
           
        }

        [Authorize]
        public ActionResult Edit(int id)
        {

            Categories category = _unitOfWork.Categories.GetCategoryWithCategoryId(id);

            var viewModel = new CategoriesViewModel
            {
                Heading = "Edit Category",
                CategoryName = category.CategoryName,
                Id=category.Id
                
            };

            return View("Create", viewModel);
        }

     
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Update(CategoriesViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Update Category";
                return View("Create", viewModel);
            }
            var category = _unitOfWork.Categories.GetCategoryWithCategoryId(viewModel.Id);
            category.Modify(viewModel.CategoryName);

            _unitOfWork.Complete();
            return RedirectToAction("CategoriesList", "Categories");
        }
    }
}