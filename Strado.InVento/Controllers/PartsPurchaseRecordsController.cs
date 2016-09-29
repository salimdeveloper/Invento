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
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult AddRecords()
        {
            var _partsPurchaseRecordsViewModel = new PartsPurchaseRecordsViewModel
            {

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
                viewModel.Suppliers = _unitOfWork.Suppliers.GetAllSuppliers();
                viewModel.Parts = _unitOfWork.Parts.GetAllParts();
                return View("AddRecords", viewModel);
            }
            var _partsPurchaseRecordsViewModel = new PartsPurchaseRecordsViewModel
            {
                PartsId=viewModel.PartsId,
                PurchaseDate=viewModel.PurchaseDate,
                PurchasePrice=viewModel.PurchasePrice,
                PurchaseQty=viewModel.PurchaseQty,
                SuppliersId=viewModel.SuppliersId
                
            };
            
            
            _unitOfWork.PartsPurchaseRecords.AddRecord(_partsPurchaseRecordsViewModel);
            var _inventory = _unitOfWork.Inventory.GetInventoryByPartsId(viewModel.PartsId);
            if (_inventory!=null)
            {
                _inventory.AddStockQuantity(viewModel.PartsId, viewModel.PurchaseQty, viewModel.PurchaseDate);
            }
            else
            {
                _unitOfWork.Inventory.AddInventory(new Inventory
                {
                    LastUpdated =viewModel.PurchaseDate,
                    PartsId=viewModel.PartsId,
                    QtyInStock=viewModel.PurchaseQty
                });
            }
            _unitOfWork.Complete();
            return View(viewModel);
        }
    }
}