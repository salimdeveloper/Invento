using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.ViewModels;
using Strado.InVento.Core.Models;
using System.IO;

namespace Strado.InVento.Controllers
{
    public class BrandsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private string UPLOAD_DIRECTORY="/Images/BrandImages/";

        public BrandsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: Brands

        [Authorize]
        public ViewResult BrandList()
        {

            var _brands = _unitOfWork.Brands.GetAllBrands();
            return View(_brands);


        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new BrandsViewModel
            {
                Heading = "Add a part"
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BrandsViewModel _viewModel)
        {
            

            if (!ModelState.IsValid)
            {
                _viewModel.Heading = "Add a part";
                return View("Create", _viewModel);
            }
           
            ImageUpload(_viewModel.BrandLogo,UPLOAD_DIRECTORY);
            var _brandModel = new Brand
            {
                BrandName = _viewModel.BrandName,
                LogoImgSrc = Path.Combine(UPLOAD_DIRECTORY, _viewModel.BrandLogo.FileName)
            };
            _unitOfWork.Brands.AddBrand(_brandModel);
            _unitOfWork.Complete();
            return RedirectToAction("BrandList", "Brands");
        }
        [Authorize]
        public ActionResult Edit(int id)
        {

            Brand brand = _unitOfWork.Brands.GetBrandWithBrandId(id);

            var viewModel = new BrandsViewModel
            {
                Heading = "Edit Brand",
                BrandName=brand.BrandName,
                ImageUrl = brand.LogoImgSrc,
                Id=brand.Id

            };

            return View("Create", viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Update(BrandsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Update Brand";
                return View("Create", viewModel);
            }
            var brand = _unitOfWork.Brands.GetBrandWithBrandId(viewModel.Id);
            brand.Modify(viewModel.BrandName,viewModel.ImageUrl);

            _unitOfWork.Complete();
            return RedirectToAction("BrandList", "Brands");
        }

        //Refactor::Implement Seperation Of Concern
                #region Image Upload Code
        private void ImageUpload(HttpPostedFileBase _image, string _uploadDir)
        {
            if (_image != null && _image.ContentLength > 0)
            {
                var imagePath = Path.Combine(Server.MapPath(_uploadDir), _image.FileName);
                _image.SaveAs(imagePath);

            }
        }
        #endregion
    }
}