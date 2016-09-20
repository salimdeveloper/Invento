using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.Models;
using Strado.InVento.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strado.InVento.Controllers
{
    public class PartsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private string _imageurl;
        public PartsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Parts
        public ActionResult PartsList()
        {
            var _parts = _unitOfWork.Parts.GetAllParts();
            return View(_parts);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new PartsFormViewModel {
                Categories = _unitOfWork.Categories.GetAllNonDeleteCategories(),
                Brands = _unitOfWork.Brands.GetAllBrands()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(PartsFormViewModel viewModel, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _unitOfWork.Categories.GetAllNonDeleteCategories();
                viewModel.Brands = _unitOfWork.Brands.GetAllBrands();
                return View("Create", viewModel);
            }
            ImageUpload(image);

            var _partsModel = new Parts {
                PartName = viewModel.PartName,
                PartImageUrl = _imageurl,
                PartDetails=viewModel.PartDetails,
                CategoriesId=viewModel.CategoriesId,
                BrandId=viewModel.BrandId
                


            };

           _unitOfWork.Parts.AddPart(_partsModel);
            _unitOfWork.Complete();
            return RedirectToAction("PartsList", "Parts");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Update(PartsFormViewModel viewModel)
        {

            return View();
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