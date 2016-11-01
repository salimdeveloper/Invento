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
        private string UPLOAD_DIRECTORY = "~/Images/PartsImages/";
        public PartsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Parts
        [Authorize]
        public ActionResult PartsList()
        {
            var _parts = _unitOfWork.Parts.GetAllParts();
            return View(_parts);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new PartsFormViewModel
            {
                Heading="Add a part",
                Categories = _unitOfWork.Categories.GetAllNonDeleteCategories(),
                Brands = _unitOfWork.Brands.GetAllBrands()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(PartsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _unitOfWork.Categories.GetAllNonDeleteCategories();
                viewModel.Brands = _unitOfWork.Brands.GetAllBrands();
                return View("Create", viewModel);
            }
            ImageUpload(viewModel.PartImage, UPLOAD_DIRECTORY);

            var _partsModel = new Parts
            {
                PartName = viewModel.PartName,
                PartImageUrl = Path.Combine(UPLOAD_DIRECTORY, viewModel.PartImage.FileName),
                PartDetails = viewModel.PartDetails,
                CategoriesId = viewModel.CategoriesId,
                BrandId = viewModel.BrandId
            };

            _unitOfWork.Parts.AddPart(_partsModel);
            _unitOfWork.Complete();
            return RedirectToAction("PartsList", "Parts");
        }
        [Authorize]
        public ActionResult Edit(int id)
        {

            Parts part = _unitOfWork.Parts.GetPartsWithPartId(id);

            var viewModel = new PartsFormViewModel
            {
                Heading="Edit part",
                Categories = _unitOfWork.Categories.GetAllNonDeleteCategories(),
                Brands = _unitOfWork.Brands.GetAllBrands(),
                PartName = part.PartName,
                PartDetails = part.PartDetails,
                Id = part.Id,
                BrandId =part.BrandId,
                CategoriesId =part.CategoriesId,
                ImageUrl=part.PartImageUrl
                
            };

            return View("Create", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Update(PartsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                viewModel.Categories = _unitOfWork.Categories.GetAllNonDeleteCategories();
                viewModel.Brands = _unitOfWork.Brands.GetAllBrands();
                return View("Create", viewModel);
            }
            var part= _unitOfWork.Parts.GetPartsWithPartId(viewModel.Id);
            part.Modify(viewModel.PartName,viewModel.PartDetails,viewModel.BrandId,viewModel.CategoriesId,UpdateImageUpload(viewModel.PartImage,UPLOAD_DIRECTORY,viewModel.ImageUrl));

            _unitOfWork.Complete();
            return RedirectToAction("PartsList", "Parts");
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
        private string UpdateImageUpload(HttpPostedFileBase _image, string _uploadDir,string _uploadedImgUrl)
        {
            if (_image != null && _image.ContentLength > 0)
            {
                var imagePath = Path.Combine(Server.MapPath(_uploadDir), _image.FileName);
                _image.SaveAs(imagePath);
                return Path.Combine(_uploadDir, _image.FileName);
            }
            else
                return _uploadedImgUrl;
        }
        #endregion
    }
}