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
        private string _imageurl;

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
            
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(BrandsViewModel _viewModel, HttpPostedFileBase image)
        {
            

            if (!ModelState.IsValid)
            {
                return View("Create");
            }
           
            ImageUpload(image);
            var _brandModel = new Brand
            {
                BrandName = _viewModel.BrandName,
                LogoImgSrc = _imageurl
            };
            _unitOfWork.Brands.AddBrand(_brandModel);
            _unitOfWork.Complete();
            return RedirectToAction("BrandList", "Brands");
        }


        //Refactor::Implement Seperation Of Concern
        #region Image Upload Code
        private void ImageUpload(HttpPostedFileBase _image)
        {

            var validImageTypes = new string[]
                             {
                     "image/gif",
                     "image/jpeg",
                     "image/pjpeg",
                     "image/png"
                             };

            if (_image == null || _image.ContentLength == 0)
            {
                ModelState.AddModelError("BrandLogo", "This field is required");
            }
            else if (!validImageTypes.Contains(_image.ContentType))
            {
                ModelState.AddModelError("BrandLogo", "Please choose either a GIF, JPG or PNG image");
            }
            if (_image != null && _image.ContentLength > 0)
            {
                var uploadDir = "/Images/BrandImages/";
                var imagePath = Path.Combine(Server.MapPath(uploadDir), _image.FileName);
                _imageurl = Path.Combine(uploadDir, _image.FileName);
                _image.SaveAs(imagePath);

            }
        }
        #endregion
    }
}