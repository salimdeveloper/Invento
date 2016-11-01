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
    public class SupplierController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Supplier
        [Authorize]
        public ActionResult SupplierList()
        {
            var _supplier = _unitOfWork.Suppliers.GetAllSuppliers();
            return View(_supplier);
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new SupplierViewModel
            {
                Heading = "Add a supplier"
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(SupplierViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Add a supplier";
                return View("Create", viewModel);
            }
            var _supplier = new Suppliers
            {
                
                SupplierName = viewModel.SupplierName,
                AddressId = viewModel.AddressId,
                Address = new Address
                {
                    Address1 = viewModel.Address.Address1,
                    Address2 = viewModel.Address.Address2,
                    City = viewModel.Address.City,
                    ContactName = viewModel.Address.ContactName,
                    ContactNo = viewModel.Address.ContactNo,
                    State = viewModel.Address.State,
                    Pin = viewModel.Address.Pin
                }
            };
            _unitOfWork.Suppliers.AddSupplier(_supplier);
            _unitOfWork.Complete();

            return RedirectToAction("SupplierList", "Supplier");
        }
        public ActionResult Edit(int id)
        {

            Suppliers supplier = _unitOfWork.Suppliers.GetSupplierWithId(id);

            var viewModel = new SupplierViewModel
            {
                Heading = "Edit supplier",
                SupplierName = supplier.SupplierName,
                Address = new Address
                {
                    Address1 = supplier.Address.Address1,
                    Address2 = supplier.Address.Address2,
                    City = supplier.Address.City,
                    ContactName = supplier.Address.ContactName,
                    ContactNo = supplier.Address.ContactNo,
                    Id = supplier.Address.Id,
                    Pin = supplier.Address.Pin,
                    State = supplier.Address.State
                },
                AddressId = supplier.AddressId,
                Id = supplier.Id

            };

            return View("Create", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Update(SupplierViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Add a supplier";
                return View("Create", viewModel);
            }

            var supplier = _unitOfWork.Suppliers.GetSupplierWithId(viewModel.Id);
            var address = _unitOfWork.Addresses.GetAddressWithId(supplier.AddressId);
            supplier.Modify(viewModel.SupplierName,viewModel.AddressId);
            address.Modify(viewModel.Address);
            _unitOfWork.Complete();

            return RedirectToAction("SupplierList", "Supplier");
        }
    }
}