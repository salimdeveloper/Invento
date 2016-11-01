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
    public class PartsPurchaseRecordsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PartsPurchaseRecordsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: PartsPurchaseRecords
        public ActionResult PurchaseDetails()
        {
            var _partsPurchaseRecordsViewModel = _unitOfWork.PartsPurchaseRecords.GetAllPartsPurchaseRecords();
            return View(_partsPurchaseRecordsViewModel);
        }
        [Authorize]
        public ActionResult AddRecords()
        {
            var _partsPurchaseRecordsViewModel = new PartsPurchaseRecordsViewModel
            {
                Heading = "Add Purchase Record",
                Suppliers = _unitOfWork.Suppliers.GetAllSuppliers(),
                Parts = _unitOfWork.Parts.GetAllParts()

            };
            return View(_partsPurchaseRecordsViewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRecords(PartsPurchaseRecordsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Add Purchase Records";
                viewModel.Suppliers = _unitOfWork.Suppliers.GetAllSuppliers();
                viewModel.Parts = _unitOfWork.Parts.GetAllParts();
                return View("AddRecords", viewModel);
            }

            _unitOfWork.PartsPurchaseRecords.AddRecord(new PartsPurchaseRecordsViewModel
            {
                PartsId = viewModel.PartsId,
                PurchaseDate = viewModel.PurchaseDate,
                PurchasePrice = viewModel.PurchasePrice,
                PurchaseQty = viewModel.PurchaseQty,
                SuppliersId = viewModel.SuppliersId
            });

            var _inventory = _unitOfWork.Inventory.GetInventoryByPartsId(viewModel.PartsId);
            if (_inventory != null)
            {
                _inventory.AddStockQuantity
                    (viewModel.PartsId,
                    viewModel.PurchaseQty,
                    viewModel.PurchaseDate);
            }
            else
            {
                _unitOfWork.Inventory.AddInventory(new Inventory
                {
                    LastUpdated = viewModel.PurchaseDate,
                    PartsId = viewModel.PartsId,
                    QtyInStock = viewModel.PurchaseQty
                });
            }

            _unitOfWork.Complete();

            return View(viewModel);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            PartsPurchaseRecords _purchaseRecord = _unitOfWork.PartsPurchaseRecords.GetPurchaseRecordsWithId(id);
            var viewModel = new PartsPurchaseRecordsViewModel()
            {
                Heading = "Edit Purchase Records",
                Id = _purchaseRecord.Id,
                Parts = _unitOfWork.Parts.GetAllPartsIncludeDeleted(),
                Suppliers = _unitOfWork.Suppliers.GetAllSuppliers(),
                PartsId = _purchaseRecord.PartsId,
                PurchaseDate = Convert.ToDateTime(_purchaseRecord.PurchaseDate.ToShortDateString()),
                PurchasePrice = _purchaseRecord.PurchasePrice,
                PurchaseQty = _purchaseRecord.PurchaseQty,
                SuppliersId = _purchaseRecord.SuppliersId

            };
            return View("AddRecords", viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Update(PartsPurchaseRecordsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Parts = _unitOfWork.Parts.GetAllPartsIncludeDeleted();
                viewModel.Suppliers = _unitOfWork.Suppliers.GetAllSuppliers();
                return View("AddRecords", viewModel);
            }

            var _partsRecord = _unitOfWork.PartsPurchaseRecords.GetPurchaseRecordsWithId(viewModel.Id);
            var _initalPartsQuantity = _partsRecord.PurchaseQty;
            _partsRecord.Modify(viewModel.PurchasePrice, viewModel.PurchaseQty, viewModel.PurchaseDate, viewModel.SuppliersId);

            var _inventory = _unitOfWork.Inventory.GetInventoryByPartsId(viewModel.PartsId);
            if (_inventory != null)
                _inventory.UpdateStockQuantity(viewModel.PartsId,_initalPartsQuantity,_partsRecord.PurchaseQty);

            _unitOfWork.Complete();
            return RedirectToAction("PurchaseDetails", "PartsPurchaseRecords");
        }
    }
}